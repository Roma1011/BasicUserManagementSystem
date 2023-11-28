using Application.Auth.Command;
using AutoMapper;
using BasicUserManagementSystem.Models;
using BasicUserManagementSystem.Models.Auth;
using BasicUserManagementSystem.Models.UserManagement.ResponseModels;
using BasicUserManagementSystem.Validations.Auth;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BasicUserManagementSystem.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AuthController:ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public AuthController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Authorize([FromBody] AuthModel authModel, CancellationToken cancellationToken = default)
    {
        AuthModelValidator validator = new AuthModelValidator();
        ValidationResult validationResult = await validator.ValidateAsync(authModel);
        if (!validationResult.Errors.Any())
        {
            string token = await _mediator.Send(_mapper.Map<AuthUserCommand>(authModel), cancellationToken);
            var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
            return Ok(token.Length > 0
                ? new AuthResponseModel(token, true, "Success", 200)
                : BadRequest(new BaseResponseModel(false, "Something Is Wrong", errors, 400)));
        }
        else
        {
            var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
            return BadRequest(new BaseResponseModel(false, "Validation failed", errors, 400));
        }
    }
}