CREATE DATABASE [UpVoteDb]

USE [UpVoteDb]

CREATE TABLE Users (
	[Id] int primary key identity,
	[Nickname] nvarchar(30) null,
	[Password] nvarchar(30),
	[CreationDate] datetime2
)

CREATE TABLE Discussions (
	[Id] int primary key identity,
	[Name] nvarchar(60),
)

CREATE TABLE UsersDiscussions (
	[Id] int primary key identity,
	[UserId] int foreign key references Users(Id),
	[DiscussionId] int foreign key references Discussions(Id),
)

CREATE TABLE Sections (
	[Id] int primary key identity,
	[Name] nvarchar(30),
	[CreationDate] datetime2,
)

CREATE TABLE DiscussionsSections (
	[Id] int primary key identity,
	[DiscussionId] int foreign key references Discussions(Id),
	[SectionId] int foreign key references Sections(Id),
)