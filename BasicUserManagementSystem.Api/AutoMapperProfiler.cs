using Application.Auth.Command;
using Application.Shared;
using Application.UserManagement.JsonplaceholderCommand.GetComments;
using Application.UserManagement.JsonplaceholderCommand.GetPhotos;
using Application.UserManagement.JsonplaceholderCommand.GetPosts;
using Application.UserManagement.UserManagementRootCommand.CreateProfile;
using Application.UserManagement.UserManagementRootCommand.DeactiveProfile;
using Application.UserManagement.UserManagementRootCommand.GetProfile;
using Application.UserManagement.UserManagementRootCommand.UpdateProfile;
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
            .ConstructUsing(src => new UpdateProfileCommand(new DynamicProfileDto(
                src.UserName,
                src.Password,
                src.Email,
                src.FirstName,
                src.LastName,
                src.PersonalNumber
            ))).ReverseMap();
        CreateMap<UserProfile,DeactiveProfileCommand>().ReverseMap();
        #endregion
        #region JsonPlaceHolder
        CreateMap<int, GetPhotoCommand>()
            .ConstructUsing(userId => new GetPhotoCommand(userId));

        CreateMap<int, GetCommentCommand>()
            .ConstructUsing(userId => new GetCommentCommand(userId));

        CreateMap<int, GetPostCommand>()
            .ConstructUsing(userId => new GetPostCommand(userId));

        #endregion
    }
}