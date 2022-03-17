using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using School.Models;

namespace School.DTOs;

public record SubjectsDTO
{
    [JsonPropertyName("subject_id")]
    public long SubjectId { get; set; }

    [JsonPropertyName("subject_name")]
    public string SubjectName { get; set; }
 

}

public record SubjectsCreateDTO
{
    
    [JsonPropertyName("subject_id")]
    public long SubjectId { get; set; }

    [JsonPropertyName("subject_name")]
    public string SubjectName { get; set; }



}

public record SubjectsUpdateDTO
{
   [JsonPropertyName("subject_id")]
    public long SubjectId { get; set; }

    [JsonPropertyName("subject_name")]
    public string SubjectName { get; set; }


    // [JsonPropertyName("orders")]
    // public List<OrdersDTO> Orders { get; set; }

}