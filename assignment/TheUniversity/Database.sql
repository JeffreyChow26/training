USE master;
GO

DROP DATABASE IF EXISTS TheUniversity;
GO

CREATE DATABASE TheUniversity;
GO

USE TheUniversity;
GO

CREATE TABLE [StudentGuardian](
  Id        INT IDENTITY,
  FirstName VARCHAR(64)    NOT NULL,
  LastName  VARCHAR(64)    NOT NULL,

  PRIMARY KEY(Id)
);

CREATE TABLE [Student](
  Id         INT IDENTITY,
  FirstName  VARCHAR(64)   NOT NULL,
  LastName   VARCHAR(64)   NOT NULL,
  Phone      VARCHAR(64)   NOT NULL,
  DoB        DATE          NOT NULL,
  GuardianId INT           NOT NULL,

  PRIMARY KEY(Id),
  FOREIGN KEY(GuardianId) REFERENCES StudentGuardian(Id)
);

CREATE TABLE [Subject](
  Id     INT IDENTITY,
  [Name] VARCHAR(32)       NOT NULL UNIQUE,

  PRIMARY KEY(Id)
);

CREATE TABLE [SubjectResult](
  Id		INT IDENTITY,
  SubjectId INT			   NOT NULL,
  StudentId INT            NOT NULL,
  Grade     INT            NOT NULL,

  PRIMARY KEY(Id),
  FOREIGN KEY(SubjectId) REFERENCES [Subject](Id),
  FOREIGN KEY(StudentId) REFERENCES Student(Id)
);

CREATE TABLE [User](
  Id           INT IDENTITY,
  Email        VARCHAR(320) NOT NULL UNIQUE,
  PasswordHash BINARY(32)   NOT NULL,
  Roles        INT          NOT NULL,
  StudentId    INT              NULL UNIQUE,

  PRIMARY KEY(Id),
  FOREIGN KEY(StudentId) REFERENCES Student(Id)
);

CREATE INDEX UserEmailIndex ON [User](Email);