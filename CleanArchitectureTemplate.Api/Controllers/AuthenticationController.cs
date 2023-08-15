using CleanArchitectureTemplate.Application.Services.Authentication;
using CleanArchitectureTemplate.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureTemplate.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController : ControllerBase
{
    
    private readonly ILogger<AuthenticationController> _logger;
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(ILogger<AuthenticationController> logger, IAuthenticationService authenticationService)
    {
        _logger = logger;
        _authenticationService = authenticationService;
    }
    

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        await Task.Delay(1000);
        var result = _authenticationService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password
        );

        var response = new AuthenticationResponse(
            result.Id,
            result.FirstName,
            result.LastName,
            result.Email,
            result.Token
        );

        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        await Task.Delay(1000);
        var result = _authenticationService.Login(
            request.Email,
            request.Password
        );

        var response = new AuthenticationResponse(
            result.Id,
            result.FirstName,
            result.LastName,
            result.Email,
            result.Token
        );

        return Ok(response);
    }
}
