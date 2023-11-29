"# BasicUserManagementSystem" 
hi this is main user email and pass

AdminAdmin@gmail.com
AdminAdmin

you can use this credential for check othr user profile deactive profile and update if you create new user also possible loggin and perform the same actions

also please check UserManagementProj where you can see DbScripts and DbBeckoup

You can use migrations or beckoup db inside appsettings.json have ConnectionStrings you can use they or change but it work perfectly fine

Migration command

cd Your Directory

dotnet ef database update --context UserManagementDbContext --project .\Persistance\Persistance.csproj --startup-project .\BasicUserManagementSystem.Api\BasicUserManagementSystem.Api.csproj

dotnet ef database update --context UserManagementDbContext --project .\Persistance\Persistance.csproj --startup-project .\BasicUserManagementSystem.Api\BasicUserManagementSystem.Api.csproj

please when you use migrations here no one user is created disable [Authorize] and create user and later anable if you use Beckoup way just use upper field

thanks.
