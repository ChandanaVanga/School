 using School.DTOs;

namespace School.Models;


public record Subjects
{
    public long SubjectId { get; set; }
    public string SubjectName { get; set; }

    

    public SubjectsDTO asDto => new SubjectsDTO
    {
        SubjectId = SubjectId,
        SubjectName = SubjectName,
       
    };
}