using Application.Auth.Command;
using Application.Shared;
using Application.UserManagement.Command.CreateProfile;
using Application.UserManagement.Command.DeactiveProfile;
using Application.UserManagement.Command.GetProfile;
using Application.UserManagement.Command.UpdateProfile;
using AutoMapper;
using BasicUserManagementSystem.Models.Auth;
using BasicUserManagementSystem.Models.UserManagement;

namespace BasicUserManagementSystem;

public class AutoMapperProfiler:Profile
{
    public AutoMapperProfiler()
    {
        #region Auth
        CreateMap<AuthModel, AuthUserCommand>().ReverseMap();
        #endregion
        #region UserManagement
        CreateMap<UserProfile, GetProfileCommand>().ReverseMap();
        CreateMap<DynamicProfileModel, CreateProfileCommand>()
            .ConstructUsing(src => new CreateProfileCommand(new DynamicProfileDto(
                src.UserName,
                src.Password,
                src.Email,
                src.FirstName,
                src.LastName,
                src.PersonalNumber
            )));
        CreateMap<DynamicProfileModel, UpdateProfileCommand>()
            .ConstructUsing((src, context) => new UpdateProfileCommand(
                Id: 0,
                ProfileDto: context.Mapper.Map<DynamicProfileDto>(src)
            ));
        CreateMap<DynamicProfileModel,UpdateProfileCommand>().ReverseMap();
        CreateMap<UserProfile,DeactiveProfileCommand>().ReverseMap();
        #endregion
        
        
    }
}