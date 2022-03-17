using School.DTOs;
using School.Models;
using School.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace School.Controllers;

[ApiController]
[Route("api/classroom")]
public class ClassRoomController : ControllerBase
{
    private readonly ILogger<ClassRoomController> _logger;
    private readonly IClassRoomRepository _classroom;
    //private readonly IOrdersRepository _orders;

    public ClassRoomController(ILogger<ClassRoomController> logger,
    IClassRoomRepository classroom)
    {
        _logger = logger;
        _classroom = classroom;
      // _orders = orders;
    }

    [HttpGet]
    public async Task<ActionResult<List<ClassRoomDTO>>> GetList()
    {
        var classroomsList = await _classroom.GetList();

        // User -> UserDTO
       // var dtoList = studentList.Select(x => x.asDto);

        return Ok(classroomsList);
    }

    [HttpGet("{class_id}")]
    public async Task<ActionResult<ClassRoomDTO>> GetById([FromRoute] long class_id)
    {
        var classroom = await _classroom.GetById(class_id);

        if (classroom is null)
            return NotFound("No class found with given class id");

         var dto = classroom.asDto;

       // dto.MyOrders = (await _orders.GetListByCustomerId(student_id)).Select(x => x.asDto).ToList();

        return Ok(dto);
    }

   
}