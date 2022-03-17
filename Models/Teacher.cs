 using School.DTOs;

namespace School.Models;


public record Teacher
{
    public long TeacherId { get; set; }
    public string TeacherName { get; set; }

    public string Gender { get; set; }
    
    public long Mobile { get; set; }

     public DateTimeOffset DateOfJoining { get; set; }

    public long SubjectId { get; set; }

    

    public TeacherDTO asDto => new TeacherDTO
    {
        TeacherId = TeacherId,
        TeacherName = TeacherName,
        Gender = Gender.ToString().ToLower(),
        Mobile = Mobile,
        DateOfJoining = DateOfJoining,
        SubjectId = SubjectId,
        
        
    };
}