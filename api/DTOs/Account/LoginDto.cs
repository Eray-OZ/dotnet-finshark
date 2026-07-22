using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;

namespace api.DTOs;

public class LoginDto
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password{ get; set; }
}
