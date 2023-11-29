using Domain.Abstractions;
using Domain.Exceptions;
using Domain.IServices.ISecuriyServices;
using MediatR;

namespace Application.UserManagement.UserManagementRootCommand.UpdateProfile;

public class UpdateProfileHandler : IRequestHandler<UpdateProfileCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordService _passwordService;

    public UpdateProfileHandler(IUnitOfWork unitOfWork, IPasswordService passwordService)
    {
        _unitOfWork = unitOfWork;
        _passwordService = passwordService;
    }

    public async Task<bool> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
    {
        var userToUpdate = await _unitOfWork.UserRepository.GetAsync(i => i.Email == request.ProfileDto.Email && i.IsActive !=false);
        if (userToUpdate is null)
        {
            throw new UserNotAvailableException();
        }
        
        userToUpdate.UserName = request.ProfileDto.UserName;
        userToUpdate.Email = request.ProfileDto.Email;
        userToUpdate.Password = _passwordService.HashPassword(request.ProfileDto.Password);
        userToUpdate.UserProfile.FirstName = request.ProfileDto.FirstName;
        userToUpdate.UserProfile.LastName = request.ProfileDto.LastName;
        userToUpdate.UserProfile.PersonalNumber = request.ProfileDto.PersonalNumber;
        
        await _unitOfWork.SaveAsync();
        
        return true;
    }
}
