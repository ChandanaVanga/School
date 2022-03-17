using School.DTOs;
using School.Models;
using School.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace School.Controllers;

[ApiController]
[Route("api/subjects")]
public class SubjectsController : ControllerBase
{
    private readonly ILogger<SubjectsController> _logger;
    private readonly ISubjectsRepository _subjects;
    //private readonly IOrdersRepository _orders;

    public SubjectsController(ILogger<SubjectsController> logger,
    ISubjectsRepository subjects)
    {
        _logger = logger;
        _subjects = subjects;
      // _orders = orders;
    }

    [HttpGet]
    public async Task<ActionResult<List<SubjectsDTO>>> GetList()
    {
        var subjectsList = await _subjects.GetList();

        // User -> UserDTO
       // var dtoList = studentList.Select(x => x.asDto);

        return Ok(subjectsList);
    }

    [HttpGet("{subject_id}")]
    public async Task<ActionResult<SubjectsDTO>> GetById([FromRoute] long subject_id)
    {
        var subject = await _subjects.GetById(subject_id);

        if (subject is null)
            return NotFound("No subject found with given subject id");

        var dto = subject.asDto;

       // dto.MyOrders = (await _orders.GetListByCustomerId(student_id)).Select(x => x.asDto).ToList();

        return Ok(dto);
    }

   
}