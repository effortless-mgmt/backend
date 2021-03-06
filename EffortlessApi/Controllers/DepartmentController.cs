using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EffortlessApi.Core;
using EffortlessApi.Core.Models;
using EffortlessApi.Persistence;
using EffortlessLibrary.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EffortlessApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DepartmentController(EffortlessContext context, IMapper mapper)
        {
            _unitOfWork = new UnitOfWork(context);
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            AddressDTO addressDTO;
            CompanySimpleDTO companyDTO;

            var departmentModels = await _unitOfWork.Departments.GetAllAsync();
            if (departmentModels == null) return NotFound();

            var departmentDTOs = _mapper.Map<List<DepartmentDTO>>(departmentModels);

            foreach (DepartmentDTO d in departmentDTOs)
            {
                companyDTO = _mapper.Map<CompanySimpleDTO>(await _unitOfWork.Companies.GetByIdAsync(d.CompanyId));
                addressDTO = _mapper.Map<AddressDTO>(await _unitOfWork.Addresses.GetByIdAsync(d.AddressId));
                d.Company = companyDTO;
                d.Address = addressDTO;
            }

            return Ok(departmentDTOs);
        }

        [Authorize]
        [HttpGet("{id}", Name = "GetDepartment")]
        public async Task<IActionResult> GetById(long id)
        {
            var departmentModel = await _unitOfWork.Departments.GetByIdAsync(id);
            if (departmentModel == null) return NotFound($"Department {departmentModel.Name} could not be found.");

            var departmentDTO = _mapper.Map<DepartmentDTO>(departmentModel);

            return Ok(departmentDTO);
        }

        [Authorize]
        [HttpGet("{id}/workperiod")]
        public async Task<IActionResult> GetWorkPeriodsById(long id, bool? today)
        {
            var departmentModel = await _unitOfWork.Departments.GetByIdAsync(id);
            if (departmentModel == null) return NotFound($"Department {departmentModel.Name} does not exist.");

            var workPeriodDTOs = _mapper.Map<List<WorkPeriodOutDTO>>(await _unitOfWork.WorkPeriods.GetByDepartmentIdAsync(id));
            foreach (WorkPeriodOutDTO wp in workPeriodDTOs)
            {
                if (today != null)
                {
                    wp.Appointments = _mapper.Map<List<AppointmentWpDTO>>(await _unitOfWork.Appointments.GetByWorkPeriodId(wp.Id)).Where(a => a.Start.Date == System.DateTime.Today).OrderBy(a => a.Start).ToList();
                }
                else
                {
                    wp.Appointments = _mapper.Map<List<AppointmentWpDTO>>(await _unitOfWork.Appointments.GetByWorkPeriodId(wp.Id));
                }
                wp.UserWorkPeriods = _mapper.Map<List<UserWorkPeriodDTO>>(await _unitOfWork.UserWorkPeriods.GetByWorkPeriodId(wp.Id));

                foreach (UserWorkPeriodDTO u in wp.UserWorkPeriods)
                {
                    u.User = _mapper.Map<UserSimpleDTO>(await _unitOfWork.Users.GetByIdAsync(u.UserId));
                }
            }

            if (today != null)
            {
                var todaysWorkPeriods = workPeriodDTOs.Where(wp => wp.Appointments.Count > 0).ToList();
                return Ok(todaysWorkPeriods);
            }
            return Ok(workPeriodDTOs);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] DepartmentDTO departmentDTO)
        {
            Address addressModel;

            if (departmentDTO == null) return BadRequest();

            var companyModel = await _unitOfWork.Companies.FindByVat(departmentDTO.Company.Vat);
            if (companyModel == null) return BadRequest("You must create a company before creating a company department.");

            var departmentModel = _mapper.Map<Department>(departmentDTO);
            var companyDTO = _mapper.Map<CompanySimpleDTO>(companyModel);
            departmentModel.CompanyId = companyModel.Id;

            ///<text>
            ///If department is created without an address, the address will be assigned to that of the parent company.
            ///</text>
            var addressDTO = departmentDTO.Address;
            if (addressDTO == null)
            {
                addressModel = await _unitOfWork.Addresses.GetByIdAsync(companyModel.AddressId);
                addressDTO = _mapper.Map<AddressDTO>(addressModel);
                departmentModel.AddressId = addressModel.Id;
            }
            else
            {
                addressModel = _mapper.Map<Address>(addressDTO);
                await _unitOfWork.Addresses.AddAsync(addressModel);
                await _unitOfWork.CompleteAsync();
            }

            await _unitOfWork.Departments.AddAsync(departmentModel);
            await _unitOfWork.CompleteAsync();

            departmentDTO = _mapper.Map<DepartmentDTO>(departmentModel);

            return CreatedAtRoute("GetDepartment", new { id = departmentDTO.Id }, departmentDTO);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, DepartmentDTO departmentDTO)
        {
            var existing = await _unitOfWork.Departments.GetByIdAsync(id);
            if (existing == null) return NotFound($"department {id} could not be found.");

            if (departmentDTO.Address != null)
            {
                var departmentAddressModel = _mapper.Map<Address>(departmentDTO.Address);
                await _unitOfWork.Addresses.AddAsync(departmentAddressModel);
                await _unitOfWork.CompleteAsync();

                departmentDTO.AddressId = departmentAddressModel.Id;
            }

            var companyModel = await _unitOfWork.Companies.GetByIdAsync(existing.CompanyId);
            var departmentModel = _mapper.Map<Department>(departmentDTO);
            await _unitOfWork.Departments.UpdateAsync(id, departmentModel);
            await _unitOfWork.CompleteAsync();

            var addressModel = await _unitOfWork.Addresses.GetByIdAsync(existing.Id);
            departmentDTO = _mapper.Map<DepartmentDTO>(existing);

            return Ok(departmentDTO);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var department = await _unitOfWork.Departments.GetByIdAsync(id);

            if (department == null) return NoContent();

            _unitOfWork.Departments.Remove(department);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}