using Application.Shared.JsonplaceholderObjects;
using Application.UserManagement.JsonplaceholderCommand.GetComments;
using Application.UserManagement.JsonplaceholderCommand.GetPhotos;
using Application.UserManagement.JsonplaceholderCommand.GetPosts;
using Application.UserManagement.UserManagementRootCommand.GetProfile;
using AutoMapper;
using BasicUserManagementSystem.Models;
using Newtonsoft.Json;
using BasicUserManagementSystem.Models.UserManagement;
using BasicUserManagementSystem.Models.UserManagement.ResponseModels;
using BasicUserManagementSystem.Validations.UserManagement;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BasicUserManagementSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class JsonplaceholderController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    
    public JsonplaceholderController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpGet("getuserposts")]
    public async Task<IActionResult> GetPosts([FromQuery]UserProfile profile, CancellationToken cancellationToken = default)
    {
        GetProfileValidator validator = new GetProfileValidator();
        ValidationResult validationResult = await validator.ValidateAsync(profile);
        var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
        if (!validationResult.Errors.Any())
        {
            GetProfileCommand command = _mapper.Map<GetProfileCommand>(profile);
            var responses = await _mediator.Send(command, cancellationToken);
            if (responses is not null)
            {
                GetPostCommand photoCommand = _mapper.Map<GetPostCommand>(profile.UserId);
                var photoResponses = await _mediator.Send(photoCommand, cancellationToken);
                return Ok(photoResponses);
            }
        }
        return BadRequest(new BaseResponseModel(false, "Validation failed", errors, 400));
    }
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpGet("getusercomments")]
    public async Task<IActionResult> GetComments([FromQuery]UserProfile profile, CancellationToken cancellationToken = default)
    {
        GetProfileValidator validator = new GetProfileValidator();
        ValidationResult validationResult = await validator.ValidateAsync(profile);

        if (!validationResult.Errors.Any())
        {
            GetProfileCommand command = _mapper.Map<GetProfileCommand>(profile);
            var responses = await _mediator.Send(command, cancellationToken);
            if (responses is not null)
            {
                GetCommentCommand photoCommand = _mapper.Map<GetCommentCommand>(profile.UserId);
                var photoResponses = await _mediator.Send(photoCommand, cancellationToken);
                return Ok(photoResponses);
            }
        }
        
        var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
        return BadRequest(new BaseResponseModel(false, "Validation failed", errors, 400));
                
    }
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpGet("getuserphotos")]
    public async Task<IActionResult> GetPhotos([FromQuery]UserProfile profile, CancellationToken cancellationToken = default)
    {
        GetProfileValidator validator = new GetProfileValidator();
        ValidationResult validationResult = await validator.ValidateAsync(profile);

        if (!validationResult.Errors.Any())
        {
            GetProfileCommand command = _mapper.Map<GetProfileCommand>(profile);
            var responses = await _mediator.Send(command, cancellationToken);
            if (responses is not null)
            {
                GetPhotoCommand photoCommand = _mapper.Map<GetPhotoCommand>(profile.UserId);
                var photoResponses = await _mediator.Send(photoCommand, cancellationToken);
                return Ok(photoResponses);
            }
        }
        var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
        return BadRequest(new BaseResponseModel(false, "Validation failed", errors, 400));
                
    }
}