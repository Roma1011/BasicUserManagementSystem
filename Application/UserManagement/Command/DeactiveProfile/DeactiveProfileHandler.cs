using Domain.Abstractions;
using Domain.Exceptions;
using MediatR;

namespace Application.UserManagement.Command.DeactiveProfile;

public class DeactiveProfileHandler:IRequestHandler<DeactiveProfileCommand,bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeactiveProfileHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<bool> Handle(DeactiveProfileCommand request, CancellationToken cancellationToken)
    {
        var user =await _unitOfWork.UserRepository.GetAsync(i => i.UserId == request.UserId && i.IsActive!=false);

        if (user is null)
            throw new UserNotAvailableException();
        
        user.IsActive = false;
        _unitOfWork.UserRepository.Update(user);
        await _unitOfWork.SaveAsync();
        
        return true;
    }
}