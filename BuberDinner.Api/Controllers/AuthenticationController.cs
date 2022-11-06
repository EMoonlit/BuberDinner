using BuderDinner.Application.Authentication;
using BuderDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuderDinner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationservice;
    public AuthenticationController(IAuthenticationService authenticationservice)
    {
        _authenticationservice = authenticationservice;
    }
    
    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var result = _authenticationservice.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

        var response = new AuthenticationResponse(
            result.Id,
            result.FirstName,
            result.LastName,
            result.Email,
            result.Token);
        
        return Ok(response);
    }
    
    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
       
        var result = _authenticationservice.Login(
            request.Email,
            request.Password);

        var response = new AuthenticationResponse(
            result.Id,
            result.FirstName,
            result.LastName,
            result.Email,
            result.Token);
        
        return Ok(response);
    }
}