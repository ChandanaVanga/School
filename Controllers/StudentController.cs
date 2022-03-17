using School.DTOs;
using School.Models;
using School.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace School.Controllers;

[ApiController]
[Route("api/student")]
public class StudentController : ControllerBase
{
    private readonly ILogger<StudentController> _logger;
    private readonly IStudentRepository _student;
    private readonly ITeacherRepository _teacher;

    private readonly ISubjectsRepository _subjects;

    public StudentController(ILogger<StudentController> logger,
    IStudentRepository student, ITeacherRepository teacher, ISubjectsRepository subjects)
    {
        _logger = logger;
        _student = student;
        _teacher = teacher;
        _subjects = subjects;
      
    }

    [HttpGet]
    public async Task<ActionResult<List<StudentDTO>>> GetList()
    {
        var studentList = await _student.GetList();

        // User -> UserDTO
       // var dtoList = studentList.Select(x => x.asDto);

        return Ok(studentList);
    }

    [HttpGet("{student_id}")]
    public async Task<ActionResult<StudentDTO>> GetById([FromRoute] long student_id)
    {
        var student = await _student.GetById(student_id);

        if (student is null)
            return NotFound("No student found with given student id");

        var dto = student.asDto;

        dto.Teacher = (await _teacher.GetTeacherByStudentId(student.StudentId));
        dto.Subjects = (await _subjects.GetSubjectsByStudentId(student.StudentId));

        return Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult<StudentDTO>> CreateStudent([FromBody] StudentCreateDTO Data)
    {
       

        var toCreateStudent = new Student
        {
            StudentId = Data.StudentId,
            StudentName = Data.StudentName.Trim(),
            ParentMobile = Data.ParentMobile,
           
        };

        var createdStudent = await _student.Create(toCreateStudent);

        return StatusCode(StatusCodes.Status201Created, createdStudent.asDto);
    }

    [HttpPut("{student_id}")]
    public async Task<ActionResult> UpdateStudent([FromRoute] long student_id,
    [FromBody] StudentUpdateDTO Data)
    {
        var existing = await _student.GetById(student_id);
        if (existing is null)
            return NotFound("No student found with given student id");

        var toUpdateStudent = existing with
        {
            StudentName = Data.StudentName?.Trim()?.ToLower() ?? existing.StudentName,
            ParentMobile = existing.ParentMobile,
           
        };

        var didUpdate = await _student.Update(toUpdateStudent);

        if (!didUpdate)
            return StatusCode(StatusCodes.Status500InternalServerError, "Could not update student");

        return NoContent();
    }


}