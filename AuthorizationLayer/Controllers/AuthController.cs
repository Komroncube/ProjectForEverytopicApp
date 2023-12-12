using AuthorizationLayer.JWT;
using AuthorizationLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationLayer.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly AuthDbContext _dbContext;
    private readonly JWTGenerator _jwtGenerator;

    public AuthController(AuthDbContext dbContext, JWTGenerator jwtGenerator)
    {
        _dbContext = dbContext;
        _jwtGenerator = jwtGenerator;
    }
    [HttpPost]
    public IActionResult Login(AuthRequest auth)
    {
        var user = _dbContext.AuthModels.FirstOrDefault(x=>x.Username == auth.Username && x.Password == auth.Password);
        if (user == null)
        {
            return BadRequest();
        }
        var token = _jwtGenerator.GenerateToken(user);
        return Ok(token);
    }
    [HttpPost]
    public IActionResult Register(AuthModel authModel)
    {
        _dbContext.AuthModels.Add(authModel);
        _dbContext.SaveChanges();
        return Ok(authModel);
    }
}
