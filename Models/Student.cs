 using School.DTOs;

namespace School.Models;


public record Student
{
   
    public long StudentId { get; set; }
    public string StudentName { get; set; }

    public string Gender { get; set; }
   
    public DateTimeOffset DateOfBirth { get; set; }
    public long ParentMobile { get; set; }

    public long ClassId { get; set; }



    

    public StudentDTO asDto => new StudentDTO
    {
        StudentId = StudentId,
        StudentName = StudentName,
        Gender = Gender.ToString().ToLower(),
        DateOfBirth = DateOfBirth,
        ParentMobile = ParentMobile,
        ClassId = ClassId,
        
        
    };
}