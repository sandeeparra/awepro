USE ISW

IF OBJECT_ID(N'dbo.MigrationType',N'U') IS NOT NULL
BEGIN
DROP TABLE dbo.MigrationType
END

CREATE TABLE MigrationType(ID int identity(1,1), name nvarchar(100))
insert into MigrationType values('E2E to O365 ')
insert into MigrationType values('GDrive to O365 ')
insert into MigrationType values('N2E to O365 ')
insert into MigrationType values('OD4B ')
insert into MigrationType values('GDrive ')
insert into MigrationType values('Box to OD4B ')
insert into MigrationType values('FS to OD4B ')
insert into MigrationType values('O365 MT Exchange Hybrid ')
insert into MigrationType values('O365 MT Notes ')
insert into MigrationType values('O365 MT OD4B ')
insert into MigrationType values('O365 MT IMAP ')
insert into MigrationType values('FS to Team Sites ')
insert into MigrationType values('IMAP ')
insert into MigrationType values('Exchange - Hybrid  ')
insert into MigrationType values('O365 MT Gdrive ')
insert into MigrationType values('O365 MT Exchange Cutover ')
insert into MigrationType values('FS to O365 ')

