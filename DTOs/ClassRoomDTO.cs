using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using School.Models;

namespace School.DTOs;

public record ClassRoomDTO
{
    [JsonPropertyName("class_id")]
    public long ClassId { get; set; }

    [JsonPropertyName("class_name")]
    public string ClassName { get; set; }
 

}

public record ClassRoomCreateDTO
{
    
    [JsonPropertyName("class_id")]
    public long ClassId { get; set; }

    [JsonPropertyName("class_name")]
    public string ClassName { get; set; }
 



}

public record ClassRoomUpdateDTO
{
    [JsonPropertyName("class_id")]
    public long ClassId { get; set; }

    [JsonPropertyName("class_name")]
    public string ClassName { get; set; }
 


    // [JsonPropertyName("orders")]
    // public List<OrdersDTO> Orders { get; set; }

}