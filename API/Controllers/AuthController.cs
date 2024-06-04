using Core.DTOs;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IAuthenticateService _authenticate;

    public AuthController(IConfiguration configuration, IAuthenticateService authenticate)
    {
        _configuration = configuration;
        _authenticate = authenticate;
    }

    [HttpPost("Register")]
    public async Task<ActionResult<TokenModelDTO>> Register([FromBody] RegisterModelDTO model)
    {
        if (model.Password != model.ConfirmPassword)
        {
            ModelState.AddModelError("ConfirmPassword", "As senhas não conferem");
            return BadRequest(ModelState);
        }
        var result = await _authenticate.RegisterUser(model.Email, model.Password);

        if (result)
        {
            return Ok($"Usuário {model.Email} criado com sucesso");
        }
        else
        {
            ModelState.AddModelError("CreateUser", "Registro inválido.");
            return BadRequest(ModelState);
        }
    }

    [HttpPost("Login")]
    public async Task<ActionResult<TokenModelDTO>> Login([FromBody] LoginModelDTO login)
    {
        var result = await _authenticate.Authenticate(login.Email, login.Password);

        if (result)
        {
            return GenerateToken(login);
        }
        else
        {
            ModelState.AddModelError("LoginUser", "Login inválido.");
            return BadRequest(ModelState);
        }
    }

    private ActionResult<TokenModelDTO> GenerateToken(LoginModelDTO login)
    {
        var claims = new[]
        {
            new Claim("email", login.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var expiration = DateTime.UtcNow.AddMinutes(20);

        JwtSecurityToken token = new JwtSecurityToken(
            issuer: _configuration["Jwt:ValidIssuer"],
            audience: _configuration["Jwt:ValidAudience"],
            claims: claims,
            expires: expiration,
            signingCredentials: creds);

        return new TokenModelDTO()
        {
            AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = expiration,
        };
    }
}
