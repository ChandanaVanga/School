using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using School.Models;

namespace School.DTOs;

public record TeacherDTO
{
    [JsonPropertyName("teacher_id")]
    public long TeacherId { get; set; }

    [JsonPropertyName("teacher_name")]
    public string TeacherName { get; set; }

    [JsonPropertyName("gender")]
    public string Gender { get; set; }

    [JsonPropertyName("mobile")]
    public long Mobile { get; set; }

    [JsonPropertyName("date_of_joining")]
    public DateTimeOffset DateOfJoining { get; set; }

   
   [JsonPropertyName("subject_id")]
    public long SubjectId { get; set; }

   

}

public record TeacherCreateDTO
{
    
    [JsonPropertyName("teacher_id")]
    public long TeacherId { get; set; }

    [JsonPropertyName("teacher_name")]
    public string TeacherName { get; set; }

    // [JsonPropertyName("gender")]
    // public string Gender { get; set; }

    [JsonPropertyName("mobile")]
    public long Mobile { get; set; }

    // [JsonPropertyName("date_of_joining")]
    // public DateTimeOffset DateOfJoining { get; set; }

   
   [JsonPropertyName("subject_id")]
    public long SubjectId { get; set; }
}

public record TeacherUpdateDTO
{
    [JsonPropertyName("teacher_id")]
    public long TeacherId { get; set; }

    [JsonPropertyName("teacher_name")]
    public string TeacherName { get; set; }

    [JsonPropertyName("gender")]
    public string Gender { get; set; }

    [JsonPropertyName("mobile")]
    public long Mobile { get; set; }

    [JsonPropertyName("date_of_joining")]
    public DateTimeOffset DateOfJoining { get; set; }

   
   [JsonPropertyName("subject_id")]
    public long SubjectId { get; set; }


    // [JsonPropertyName("orders")]
    // public List<OrdersDTO> Orders { get; set; }

}