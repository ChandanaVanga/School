using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using School.Models;

namespace School.DTOs;

public record StudentDTO
{
    [JsonPropertyName("student_id")]
    public long StudentId { get; set; }

    [JsonPropertyName("student_name")]
    public string StudentName { get; set; }

    [JsonPropertyName("gender")]
    public string Gender { get; set; }


    [JsonPropertyName("date_of_birth")]
    public DateTimeOffset DateOfBirth { get; set; }

    [JsonPropertyName("parent_mobile")]
    public long ParentMobile { get; set; }

   [JsonPropertyName("class_id")]
    public long ClassId { get; set; }

    [JsonPropertyName("teacher")]
    public List<TeacherDTO> Teacher { get; set; }


    [JsonPropertyName("subjects")]
    public List<SubjectsDTO> Subjects { get; set; }


}

public record StudentCreateDTO
{
    [JsonPropertyName("student_id")]
    public long StudentId { get; set; }

    [JsonPropertyName("student_name")]
    public string StudentName { get; set; }

    [JsonPropertyName("gender")]
    public string Gender { get; set; }


    [JsonPropertyName("date_of_birth")]
    public DateTimeOffset DateOfBirth { get; set; }

    [JsonPropertyName("parent_mobile")]
    public long ParentMobile { get; set; }

   [JsonPropertyName("class_id")]
    public long ClassId { get; set; }

}

public record StudentUpdateDTO
{
    [JsonPropertyName("student_id")]
    public long StudentId { get; set; }

    [JsonPropertyName("student_name")]
    public string StudentName { get; set; }

    [JsonPropertyName("gender")]
    public string Gender { get; set; }


    [JsonPropertyName("date_of_birth")]
    public DateTimeOffset DateOfBirth { get; set; }

    [JsonPropertyName("parent_mobile")]
    public long ParentMobile { get; set; }

   [JsonPropertyName("class_id")]
    public long ClassId { get; set; }

    // [JsonPropertyName("orders")]
    // public List<OrdersDTO> Orders { get; set; }

}