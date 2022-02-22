using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentBioData.Data;
using StudentBioData.IRepository;
using StudentBioData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentBioData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<StudentController> _logger;
        private readonly IMapper _mapper;

        public StudentController(IUnitOfWork unitOfWork, ILogger<StudentController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        
        public async Task<IActionResult> GetStudents()
        {
            try
            {
                var students = await _unitOfWork.Students.GetAll();
                var results = _mapper.Map<IList<StudentDTO>>(students);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"something went wrong in the { nameof(GetStudents)}");
                return StatusCode(500);
            }
        }



        [HttpGet("{id}", Name = "GetStudent")]

        public async Task<IActionResult> GetStudent(int id)
        {
            try
            {
                var student = await _unitOfWork.Students.Get(q => q.Id == id);
                var result = _mapper.Map<StudentDTO>(student);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"something went wrong in the { nameof(GetStudent)}");
                return StatusCode(500, "interner server error, try again later");
            }
        }


        [HttpPost]

        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentDTO studentDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateStudent)}");
                return BadRequest(ModelState);
            }

            try
            {
                var student = _mapper.Map<Student>(studentDTO);
                await _unitOfWork.Students.Insert(student);
                await _unitOfWork.Save();

                return CreatedAtRoute("GetStudent", new { id = student.Id }, student);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(CreateStudent)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateStudent(int id, [FromBody] UpdateStudentDTO studentDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateStudent)}");
                return BadRequest(ModelState);
            }

            try
            {
                var student = await _unitOfWork.Students.Get(q => q.Id == id);
                if (student == null)
                {
                    _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateStudent)}");
                    return BadRequest("Submitted data is invalid");
                }

                _mapper.Map(studentDTO, student);
                _unitOfWork.Students.Update(student);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(UpdateStudent)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }


        }


        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteStudent(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteStudent)}");
                return BadRequest();
            }

            try
            {
                var student = await _unitOfWork.Students.Get(q => q.Id == id);
                if (student == null)
                {
                    _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteStudent)}");
                    return BadRequest("Submitted data is invalid");
                }

                await _unitOfWork.Students.Delete(id);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(DeleteStudent)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }
    }
}
