using School.DTOs;
using School.Models;
using School.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace School.Controllers;

[ApiController]
[Route("api/teacher")]
public class TeacherController : ControllerBase
{
    private readonly ILogger<TeacherController> _logger;
    private readonly ITeacherRepository _teacher;
    //private readonly ICustomerRepository _hardware;

    public TeacherController(ILogger<TeacherController> logger,
    ITeacherRepository teacher)
    {
        _logger = logger;
        _teacher = teacher;
       // _hardware = hardware;
    }

    [HttpGet]
    public async Task<ActionResult<List<TeacherDTO>>> GetAllTeacher()
    {
        var teacherList = await _teacher.GetList();

        // User -> UserDTO
       // var dtoList = teacherList.Select(x => x.asDto);

        return Ok(teacherList);
    }

    [HttpGet("{teacher_id}")]
    public async Task<ActionResult<TeacherDTO>> GetById([FromRoute] long teacher_id)
    {
        var teacher = await _teacher.GetById(teacher_id);

        if (teacher is null)
            return NotFound("No Teacher found with given teacher id");

        var dto = teacher.asDto;

        // dto.Products = (await _products.GetListByProductId(product_id)).Select(x => x.asDto).ToList();

        return Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult<TeacherDTO>> CreateTeacher([FromBody] TeacherCreateDTO Data)
    {
        // var products = await _products.GetById(Data.ProductId);
        // if (products is null)
        //     return NotFound("No Product found with given product id");

        var toCreateTeacher = new Teacher
        {
            TeacherId = Data.TeacherId,
            TeacherName = Data.TeacherName.Trim(),
            Mobile = Data.Mobile,
            

        };

        var createdTeacher = await _teacher.Create(toCreateTeacher);

        return StatusCode(StatusCodes.Status201Created, createdTeacher.asDto);
    }

    [HttpPut("{teacher_id}")]
    public async Task<ActionResult> UpdateTeacher([FromRoute] long teacher_id,
    [FromBody] TeacherUpdateDTO Data)
    {
        var existing = await _teacher.GetById(teacher_id);
        if (existing is null)
          return NotFound("No Teacher found with given teacher id");

        var toUpdateTeacher = existing with
        {
            TeacherName = Data.TeacherName?.Trim()?.ToLower() ?? existing.TeacherName,
            Mobile = existing.Mobile,
           
        };

        var didUpdate = await _teacher.Update(toUpdateTeacher);

        if (!didUpdate)
            return StatusCode(StatusCodes.Status500InternalServerError, "Could not update teacher");

        return NoContent();
    }

    // [HttpDelete("{product_id}")]
    // public async Task<ActionResult> DeleteProducts([FromRoute] long product_id)
    // {
    //     var existing = await _products.GetById(product_id);
    //     if (existing is null)
    //         return NotFound("No product found with given product id");

    //     var didDelete = await _products.Delete(product_id);

    //     return NoContent();
    // }
}