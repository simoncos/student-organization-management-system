--FrameWork1.08���ݸ���.sql by supesoft.com 2011/3/5
--����sys_Module �� ����M_Info
Alter table sys_Module Add M_Info nvarchar(500) null
go
--�޸�sys_Module���޸�M_PageCode����Ϊ100
alter table sys_Module drop constraint PK_Sys_Module
go
Alter table sys_Module alter column M_PageCode varchar(100) not null
go
alter table sys_Module add constraint PK_Sys_Module primary key ([M_ApplicationID],[M_PageCode])
go
--����sys_User �� ����U_LoginType
Alter table sys_User Add U_LoginType varchar(255) null


