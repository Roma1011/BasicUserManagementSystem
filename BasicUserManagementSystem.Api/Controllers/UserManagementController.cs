using Application.UserManagement.Command.CreateProfile;
using Application.UserManagement.Command.DeactiveProfile;
using Application.UserManagement.Command.GetProfile;
using Application.UserManagement.Command.UpdateProfile;
using AutoMapper;
using BasicUserManagementSystem.Models;
using BasicUserManagementSystem.Models.Auth;
using BasicUserManagementSystem.Models.UserManagement;
using BasicUserManagementSystem.Models.UserManagement.ResponseModels;
using BasicUserManagementSystem.Validations.Auth;
using BasicUserManagementSystem.Validations.UserManagement;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BasicUserManagementSystem.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UserManagementController:ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public UserManagementController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpGet("getuserprofile")]
    public async Task<IActionResult> GetProfile([FromQuery]UserProfile profile,CancellationToken cancellationToken=default)
    {
        GetProfileValidator validator = new GetProfileValidator();
        ValidationResult validationResult = await validator.ValidateAsync(profile);
        
        if (!validationResult.Errors.Any())
        {
            GetProfileCommand command = _mapper.Map<GetProfileCommand>(profile);
            var responses=await _mediator.Send(command, cancellationToken);
            
            var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
            return Ok(responses is not null
                ? new UserProfileResponseModel(responses.UserName,responses.Email,responses.FirstName,responses.LastName ,true, "success", 200)
                : NotFound(new BaseResponseModel(false, "The user is not available", errors, 400)));
        }
        else
        {
            var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
            return BadRequest(new BaseResponseModel(false, "Validation failed", errors, 400));
        }
    }

    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [HttpPost("createUser")]
    public async Task<IActionResult> CreateProfile([FromBody]DynamicProfileModel profileModel, CancellationToken cancellationToken = default)
    {
        DynamicCreateValidator validator = new DynamicCreateValidator();
        ValidationResult validationResult = await validator.ValidateAsync(profileModel);

        if (!validationResult.Errors.Any())
        {
            CreateProfileCommand command = _mapper.Map<CreateProfileCommand>(profileModel);
            var responses=await _mediator.Send(command,cancellationToken);
            var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
            return Ok(responses
                ? new UserProfileResponseModel(profileModel.UserName,profileModel.Email,profileModel.FirstName,profileModel.LastName ,true, "success", 200)
                : BadRequest(new BaseResponseModel(false, "Something Is Wrong", errors, 400)));
        }
        else
        {
            var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
            return BadRequest(new BaseResponseModel(false, "Validation failed", errors, 400));
        }
    }
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [HttpPut("updateuser")]
    public async Task<IActionResult> UpdateProfile([FromBody]DynamicProfileModel profileModel, CancellationToken cancellationToken = default)
    {
        DynamicCreateValidator validator = new DynamicCreateValidator();
        ValidationResult validationResult = await validator.ValidateAsync(profileModel);

        if (!validationResult.Errors.Any())
        {
            UpdateProfileCommand command=_mapper.Map<UpdateProfileCommand>(profileModel);
            
            var responses=await _mediator.Send(command,cancellationToken);
            var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
            return Ok(responses
                ? new UserProfileResponseModel(profileModel.UserName,profileModel.Email,profileModel.FirstName,profileModel.LastName ,true, "success", 200)
                : BadRequest(new BaseResponseModel(false, "Something Is Wrong", errors, 400)));
        }
        else
        {
            var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
            return BadRequest(new BaseResponseModel(false, "Validation failed", errors, 400));
        }
    }
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [HttpDelete("deleteuser")]
    public async Task<IActionResult> DeactiveProfile(UserProfile profile, CancellationToken cancellationToken = default)
    {
        GetProfileValidator validator = new GetProfileValidator();
        ValidationResult validationResult = await validator.ValidateAsync(profile);
        if (!validationResult.Errors.Any())
        {
            DeactiveProfileCommand deactiveProfileCommand = _mapper.Map<DeactiveProfileCommand>(profile);
            
            var responses=await _mediator.Send(deactiveProfileCommand,cancellationToken);
            var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
            return Ok(responses
                ? new BaseResponseModel(true, "User Deleted Successful", errors, 201)
                : BadRequest(new BaseResponseModel(false, "Something Is Wrong", errors, 400)));
        }
        else
        {
            var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
            return BadRequest(new BaseResponseModel(false, "Validation failed", errors, 400));
        }
    }
}

//AdminAdmin
//AdminAdmin
//AdminAdmin@gmail.com