using Microsoft.EntityFrameworkCore;
using Application.Shared;
using Domain.Abstractions;
using Domain.Exceptions;
using MediatR;

namespace Application.UserManagement.Command.GetProfile
{
    public class GetProfileHandler : IRequestHandler<GetProfileCommand, Shared.GetProfile>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetProfileHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Shared.GetProfile> Handle(GetProfileCommand request, CancellationToken cancellationToken)
        {
            var profile = await (
                    from user in _unitOfWork.UserRepository.Set
                    join userProfile in _unitOfWork.UserProfileRepository.Set on user.UserProfileId equals userProfile.UserProfileId
                    where user.UserId == request.UserId && user.IsActive 
                    select new Shared.GetProfile
                    {
                        UserName = user.UserName,
                        Email = user.Email,
                        FirstName = userProfile.FirstName,
                        LastName = userProfile.LastName
                    })
                .FirstOrDefaultAsync(cancellationToken);

            if (profile is null)
                throw new UserNotAvailableException();
            
            return profile;
        }
    }
}