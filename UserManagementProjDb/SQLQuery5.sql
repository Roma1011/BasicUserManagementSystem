Use master
GO

CREATE DATABASE UserManagementSystem

Use UserManagementSystem
GO
CREATE TABLE UserProfiles(
	UserProfileId INTEGER PRIMARY KEY IDENTITY NOT NULL,
	FirstName NVARCHAR(60) NOT NULL,
	LastName NVARCHAR(60) NOT NULL,
	PersonalNumber BIGINT NOT NULL,
)

CREATE TABLE Users (
	UserId INTEGER PRIMARY KEY IDENTITY NOT NULL,
	UserName NVARCHAR(60) NOT NULL,
	Password VARBINARY(500) NOT NULL,
	Email NVARCHAR(60) NOT NULL,
	IsActive BIT NOT NULL,
	UserProfileId INTEGER FOREIGN KEY REFERENCES UserProfiles(UserProfileId) NOT NULL
)