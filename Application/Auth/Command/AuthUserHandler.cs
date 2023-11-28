using Domain.Abstractions;
using Domain.Entities;
using Domain.Exceptions;
using Domain.IServices.ISecuriyServices;
using MediatR;

namespace Application.Auth.Command;

public class AuthUserHandler : IRequestHandler<AuthUserCommand, string>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITokenService _tokenService;
    private readonly IPasswordService _passwordService;
    private readonly IMediator _mediator;

    public AuthUserHandler(IUnitOfWork unitOfWork, ITokenService tokenService, IPasswordService passwordService, IMediator mediator)
    {
        _unitOfWork = unitOfWork;
        _tokenService = tokenService;
        _passwordService = passwordService;
        _mediator = mediator;
    }

    public async Task<string> Handle(AuthUserCommand request, CancellationToken cancellationToken)
    {
        ArgumentException.ThrowIfNullOrEmpty(request.Email);
        ArgumentException.ThrowIfNullOrEmpty(request.Password);
        User? user =
            await _unitOfWork.UserRepository
                .GetAsNoTrackingAsync(i => i.Email.Equals(request.Email), cancellationToken);
        
        if (!_passwordService.IsValidPasswordHash(request.Password, user.Password))
        {
            throw new InvalidUserCredentialsException();
        }
        string token = _tokenService.Generate(user.UserName);
        return token;
    }
}