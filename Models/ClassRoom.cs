 using School.DTOs;

namespace School.Models;


public record ClassRoom
{
    public long ClassId { get; set; }
    public string ClassName { get; set; }


    public ClassRoomDTO asDto => new ClassRoomDTO
    {
        ClassId = ClassId,
        ClassName = ClassName,
       
        
    };
}