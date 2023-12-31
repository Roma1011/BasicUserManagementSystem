﻿using Domain.Abstractions;
using Domain.Entities;
using Domain.Exceptions;
using Domain.IServices.ISecuriyServices;
using MediatR;

namespace Application.UserManagement.UserManagementRootCommand.CreateProfile;

public class CreateProfileHandler:IRequestHandler<CreateProfileCommand,bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordService _passwordService;
    public CreateProfileHandler(IUnitOfWork unitOfWork, IPasswordService passwordService)
    {
        _unitOfWork = unitOfWork;
        _passwordService = passwordService;
    }

    public async Task<bool> Handle(CreateProfileCommand request, CancellationToken cancellationToken)
    {
        var result=await _unitOfWork.UserRepository.AnyAsync(i => i.Email == request.ProfileDto.Email || request.ProfileDto.PersonalNumber==i.UserProfile.PersonalNumber && i.IsActive==false);
        var resultdublicate=await _unitOfWork.UserRepository.AnyAsync(i => i.Email == request.ProfileDto.Email || request.ProfileDto.PersonalNumber==i.UserProfile.PersonalNumber && i.IsActive==true);
        if (result && resultdublicate)
        {
            throw new ContaxtYourSapportException();
        }
        else if (resultdublicate)
        {
            throw new UserAlreadyExistsException();
        }
        User user = new User
        {
            UserName = request.ProfileDto.UserName,
            Password = _passwordService.HashPassword( request.ProfileDto.Password),
            Email =  request.ProfileDto.Email,
            IsActive = true,
            UserProfile = new UserProfile
            {
                FirstName =  request.ProfileDto.FirstName,
                LastName =  request.ProfileDto.LastName,
                PersonalNumber =  request.ProfileDto.PersonalNumber
            }
        };
        _unitOfWork.UserRepository.Add(user);
        await _unitOfWork.SaveAsync();

        return true;
    }
}