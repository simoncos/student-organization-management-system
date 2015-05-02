/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2000                    */
/* Created on:     2011/3/10 21:56:33                           */
/*==============================================================*/


if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.sys_Applications')
            and   type = 'U')
   drop table dbo.sys_Applications
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.sys_Event')
            and   type = 'U')
   drop table dbo.sys_Event
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.sys_Field')
            and   type = 'U')
   drop table dbo.sys_Field
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.sys_FieldValue')
            and   type = 'U')
   drop table dbo.sys_FieldValue
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.sys_Group')
            and   type = 'U')
   drop table dbo.sys_Group
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.sys_Module')
            and   type = 'U')
   drop table dbo.sys_Module
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.sys_ModuleExtPermission')
            and   type = 'U')
   drop table dbo.sys_ModuleExtPermission
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.sys_Online')
            and   type = 'U')
   drop table dbo.sys_Online
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.sys_RoleApplication')
            and   type = 'U')
   drop table dbo.sys_RoleApplication
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.sys_RolePermission')
            and   type = 'U')
   drop table dbo.sys_RolePermission
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.sys_Roles')
            and   type = 'U')
   drop table dbo.sys_Roles
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.sys_SystemInfo')
            and   type = 'U')
   drop table dbo.sys_SystemInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.sys_User')
            and   type = 'U')
   drop table dbo.sys_User
go

if exists (select 1
            from  sysobjects
           where  id = object_id('dbo.sys_UserRoles')
            and   type = 'U')
   drop table dbo.sys_UserRoles
go

/*==============================================================*/
/* Table: sys_Applications                                      */
/*==============================================================*/
create table dbo.sys_Applications (
   ApplicationID        int                  identity,
   A_AppName            nvarchar(50)         null,
   A_AppDescription     nvarchar(200)        null,
   A_AppUrl             varchar(50)          null,
   A_Order              int                  null,
   constraint PK_SYS_APPLICATIONS primary key nonclustered (ApplicationID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   'Ӧ�ñ�',
   'user', 'dbo', 'table', 'sys_Applications'
go

execute sp_addextendedproperty 'MS_Description', 
   '�Զ�ID 1:Ϊϵͳ����Ӧ��',
   'user', 'dbo', 'table', 'sys_Applications', 'column', 'ApplicationID'
go

execute sp_addextendedproperty 'MS_Description', 
   'Ӧ������',
   'user', 'dbo', 'table', 'sys_Applications', 'column', 'A_AppName'
go

execute sp_addextendedproperty 'MS_Description', 
   'Ӧ�ý���',
   'user', 'dbo', 'table', 'sys_Applications', 'column', 'A_AppDescription'
go

execute sp_addextendedproperty 'MS_Description', 
   'Ӧ��Url��ַ',
   'user', 'dbo', 'table', 'sys_Applications', 'column', 'A_AppUrl'
go

execute sp_addextendedproperty 'MS_Description', 
   'Ӧ������',
   'user', 'dbo', 'table', 'sys_Applications', 'column', 'A_Order'
go

/*==============================================================*/
/* Table: sys_Event                                             */
/*==============================================================*/
create table dbo.sys_Event (
   EventID              int                  identity,
   E_U_LoginName        nvarchar(20)         null,
   E_UserID             int                  null,
   E_DateTime           datetime             not null default getdate(),
   E_ApplicationID      int                  null,
   E_A_AppName          nvarchar(50)         null,
   E_M_Name             nvarchar(50)         null,
   E_M_PageCode         varchar(6)           null,
   E_From               nvarchar(500)        null,
   E_Type               tinyint              not null default 1,
   E_IP                 varchar(15)          null,
   E_Record             nvarchar(500)        null,
   constraint PK_SYS_EVENT primary key nonclustered (EventID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   'ϵͳ�ռǱ�',
   'user', 'dbo', 'table', 'sys_Event'
go

execute sp_addextendedproperty 'MS_Description', 
   '�¼�ID��',
   'user', 'dbo', 'table', 'sys_Event', 'column', 'EventID'
go

execute sp_addextendedproperty 'MS_Description', 
   '�û���',
   'user', 'dbo', 'table', 'sys_Event', 'column', 'E_U_LoginName'
go

execute sp_addextendedproperty 'MS_Description', 
   '����ʱ�û�ID��sys_Users��UserID',
   'user', 'dbo', 'table', 'sys_Event', 'column', 'E_UserID'
go

execute sp_addextendedproperty 'MS_Description', 
   '�¼����������ڼ�ʱ��',
   'user', 'dbo', 'table', 'sys_Event', 'column', 'E_DateTime'
go

execute sp_addextendedproperty 'MS_Description', 
   '����Ӧ�ó���ID��sys_Applicatio',
   'user', 'dbo', 'table', 'sys_Event', 'column', 'E_ApplicationID'
go

execute sp_addextendedproperty 'MS_Description', 
   '����Ӧ������',
   'user', 'dbo', 'table', 'sys_Event', 'column', 'E_A_AppName'
go

execute sp_addextendedproperty 'MS_Description', 
   'PageCodeģ��������sys_Module��ͬ',
   'user', 'dbo', 'table', 'sys_Event', 'column', 'E_M_Name'
go

execute sp_addextendedproperty 'MS_Description', 
   '�����¼�ʱģ������',
   'user', 'dbo', 'table', 'sys_Event', 'column', 'E_M_PageCode'
go

execute sp_addextendedproperty 'MS_Description', 
   '��Դ',
   'user', 'dbo', 'table', 'sys_Event', 'column', 'E_From'
go

execute sp_addextendedproperty 'MS_Description', 
   '�ռ�����,1:�����ռ�2:��ȫ��־3',
   'user', 'dbo', 'table', 'sys_Event', 'column', 'E_Type'
go

execute sp_addextendedproperty 'MS_Description', 
   '�ͻ���IP��ַ',
   'user', 'dbo', 'table', 'sys_Event', 'column', 'E_IP'
go

execute sp_addextendedproperty 'MS_Description', 
   '��ϸ����',
   'user', 'dbo', 'table', 'sys_Event', 'column', 'E_Record'
go

/*==============================================================*/
/* Table: sys_Field                                             */
/*==============================================================*/
create table dbo.sys_Field (
   FieldID              int                  identity,
   F_Key                varchar(50)          null,
   F_CName              nvarchar(50)         null,
   F_Remark             nvarchar(200)        null,
   constraint PK_Sys_Field primary key nonclustered (FieldID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   'ϵͳӦ���ֶ�',
   'user', 'dbo', 'table', 'sys_Field'
go

execute sp_addextendedproperty 'MS_Description', 
   'Ӧ���ֶ�ID��',
   'user', 'dbo', 'table', 'sys_Field', 'column', 'FieldID'
go

execute sp_addextendedproperty 'MS_Description', 
   'Ӧ���ֶιؼ���',
   'user', 'dbo', 'table', 'sys_Field', 'column', 'F_Key'
go

execute sp_addextendedproperty 'MS_Description', 
   'Ӧ���ֶ�����˵��',
   'user', 'dbo', 'table', 'sys_Field', 'column', 'F_CName'
go

execute sp_addextendedproperty 'MS_Description', 
   '����˵��',
   'user', 'dbo', 'table', 'sys_Field', 'column', 'F_Remark'
go

/*==============================================================*/
/* Table: sys_FieldValue                                        */
/*==============================================================*/
create table dbo.sys_FieldValue (
   ValueID              int                  identity,
   V_F_Key              varchar(50)          null,
   V_Text               nvarchar(100)        null,
   V_Code               varchar(100)         null,
   V_ShowOrder          int                  not null default 0,
   constraint PK_Sys_FieldValue primary key nonclustered (ValueID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   'Ӧ���ֶ�ֵ',
   'user', 'dbo', 'table', 'sys_FieldValue'
go

execute sp_addextendedproperty 'MS_Description', 
   '����ID��',
   'user', 'dbo', 'table', 'sys_FieldValue', 'column', 'ValueID'
go

execute sp_addextendedproperty 'MS_Description', 
   '��sys_Field����F_Key�ֶι���',
   'user', 'dbo', 'table', 'sys_FieldValue', 'column', 'V_F_Key'
go

execute sp_addextendedproperty 'MS_Description', 
   '����˵��',
   'user', 'dbo', 'table', 'sys_FieldValue', 'column', 'V_Text'
go

execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', 'dbo', 'table', 'sys_FieldValue', 'column', 'V_Code'
go

execute sp_addextendedproperty 'MS_Description', 
   'ͬ����ʾ˳��',
   'user', 'dbo', 'table', 'sys_FieldValue', 'column', 'V_ShowOrder'
go

/*==============================================================*/
/* Table: sys_Group                                             */
/*==============================================================*/
create table dbo.sys_Group (
   GroupID              int                  identity,
   G_CName              nvarchar(50)         null,
   G_ParentID           int                  not null default 0,
   G_ShowOrder          int                  not null default 0,
   G_Level              int                  null,
   G_ChildCount         int                  null,
   G_Delete             tinyint              null,
   constraint PK_SYS_GROUP primary key nonclustered (GroupID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', 'dbo', 'table', 'sys_Group'
go

execute sp_addextendedproperty 'MS_Description', 
   '����ID��',
   'user', 'dbo', 'table', 'sys_Group', 'column', 'GroupID'
go

execute sp_addextendedproperty 'MS_Description', 
   '��������˵��',
   'user', 'dbo', 'table', 'sys_Group', 'column', 'G_CName'
go

execute sp_addextendedproperty 'MS_Description', 
   '�ϼ�����ID0:Ϊ��߼�',
   'user', 'dbo', 'table', 'sys_Group', 'column', 'G_ParentID'
go

execute sp_addextendedproperty 'MS_Description', 
   '��ʾ˳��',
   'user', 'dbo', 'table', 'sys_Group', 'column', 'G_ShowOrder'
go

execute sp_addextendedproperty 'MS_Description', 
   '��ǰ�������ڲ���',
   'user', 'dbo', 'table', 'sys_Group', 'column', 'G_Level'
go

execute sp_addextendedproperty 'MS_Description', 
   '��???�����ӷ�����',
   'user', 'dbo', 'table', 'sys_Group', 'column', 'G_ChildCount'
go

execute sp_addextendedproperty 'MS_Description', 
   '�Ƿ�ɾ��1:��0:��',
   'user', 'dbo', 'table', 'sys_Group', 'column', 'G_Delete'
go

/*==============================================================*/
/* Table: sys_Module                                            */
/*==============================================================*/
create table dbo.sys_Module (
   ModuleID             int                  identity,
   M_ApplicationID      int                  not null,
   M_ParentID           int                  not null,
   M_PageCode           varchar(100)         not null,
   M_CName              nvarchar(50)         null,
   M_Directory          nvarchar(255)        null,
   M_OrderLevel         varchar(4)           null,
   M_IsSystem           tinyint              null,
   M_Close              tinyint              null,
   M_Icon               varchar(255)         null,
   M_Info               nvarchar(500)        null,
   constraint PK_Sys_Module primary key nonclustered (M_PageCode, M_ApplicationID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '����ģ��',
   'user', 'dbo', 'table', 'sys_Module'
go

execute sp_addextendedproperty 'MS_Description', 
   '����ģ��ID��',
   'user', 'dbo', 'table', 'sys_Module', 'column', 'ModuleID'
go

execute sp_addextendedproperty 'MS_Description', 
   '����Ӧ�ó���ID',
   'user', 'dbo', 'table', 'sys_Module', 'column', 'M_ApplicationID'
go

execute sp_addextendedproperty 'MS_Description', 
   '��������ģ��ID��ModuleID����,0Ϊ����',
   'user', 'dbo', 'table', 'sys_Module', 'column', 'M_ParentID'
go

execute sp_addextendedproperty 'MS_Description', 
   'ģ�����ParentΪ0,��ΪS00(xx),����ΪS00M00(xx)',
   'user', 'dbo', 'table', 'sys_Module', 'column', 'M_PageCode'
go

execute sp_addextendedproperty 'MS_Description', 
   'ģ��/��Ŀ���Ƶ�ParentIDΪ0Ϊģ������',
   'user', 'dbo', 'table', 'sys_Module', 'column', 'M_CName'
go

execute sp_addextendedproperty 'MS_Description', 
   'ģ��/��Ŀ???¼��',
   'user', 'dbo', 'table', 'sys_Module', 'column', 'M_Directory'
go

execute sp_addextendedproperty 'MS_Description', 
   '��ǰ�������򼶱�֧��˫��99���˵�',
   'user', 'dbo', 'table', 'sys_Module', 'column', 'M_OrderLevel'
go

execute sp_addextendedproperty 'MS_Description', 
   '�Ƿ�Ϊϵͳģ��1:��0:����Ϊϵͳ���޷��޸�',
   'user', 'dbo', 'table', 'sys_Module', 'column', 'M_IsSystem'
go

execute sp_addextendedproperty 'MS_Description', 
   '�Ƿ�ر�1:��0:��',
   'user', 'dbo', 'table', 'sys_Module', 'column', 'M_Close'
go

execute sp_addextendedproperty 'MS_Description', 
   'ģ��Icon',
   'user', 'dbo', 'table', 'sys_Module', 'column', 'M_Icon'
go

execute sp_addextendedproperty 'MS_Description', 
   'ģ��˵��',
   'user', 'dbo', 'table', 'sys_Module', 'column', 'M_Info'
go

/*==============================================================*/
/* Table: sys_ModuleExtPermission                               */
/*==============================================================*/
create table dbo.sys_ModuleExtPermission (
   ExtPermissionID      int                  identity,
   ModuleID             int                  not null,
   PermissionName       nvarchar(100)        not null,
   PermissionValue      int                  not null,
   constraint PK_SYS_MODULEEXTPERMISSION primary key nonclustered (ModuleID, PermissionValue)
)
go

execute sp_addextendedproperty 'MS_Description', 
   'ģ����չȨ��',
   'user', 'dbo', 'table', 'sys_ModuleExtPermission'
go

execute sp_addextendedproperty 'MS_Description', 
   '��չȨ��ID',
   'user', 'dbo', 'table', 'sys_ModuleExtPermission', 'column', 'ExtPermissionID'
go

execute sp_addextendedproperty 'MS_Description', 
   'ģ��ID',
   'user', 'dbo', 'table', 'sys_ModuleExtPermission', 'column', 'ModuleID'
go

execute sp_addextendedproperty 'MS_Description', 
   'Ȩ������',
   'user', 'dbo', 'table', 'sys_ModuleExtPermission', 'column', 'PermissionName'
go

execute sp_addextendedproperty 'MS_Description', 
   'Ȩ��ֵ',
   'user', 'dbo', 'table', 'sys_ModuleExtPermission', 'column', 'PermissionValue'
go

/*==============================================================*/
/* Table: sys_Online                                            */
/*==============================================================*/
create table dbo.sys_Online (
   OnlineID             int                  identity,
   O_SessionID          varchar(24)          not null,
   O_UserName           nvarchar(20)         not null,
   O_Ip                 varchar(15)          not null,
   O_LoginTime          datetime             not null,
   O_LastTime           datetime             not null,
   O_LastUrl            nvarchar(500)        not null,
   constraint PK_SYS_ONLINE primary key nonclustered (O_SessionID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '�����û���',
   'user', 'dbo', 'table', 'sys_Online'
go

execute sp_addextendedproperty 'MS_Description', 
   '�Զ�ID',
   'user', 'dbo', 'table', 'sys_Online', 'column', 'OnlineID'
go

execute sp_addextendedproperty 'MS_Description', 
   '�û�SessionID',
   'user', 'dbo', 'table', 'sys_Online', 'column', 'O_SessionID'
go

execute sp_addextendedproperty 'MS_Description', 
   '�û���',
   'user', 'dbo', 'table', 'sys_Online', 'column', 'O_UserName'
go

execute sp_addextendedproperty 'MS_Description', 
   '�û�IP��ַ',
   'user', 'dbo', 'table', 'sys_Online', 'column', 'O_Ip'
go

execute sp_addextendedproperty 'MS_Description', 
   '��½ʱ��',
   'user', 'dbo', 'table', 'sys_Online', 'column', 'O_LoginTime'
go

execute sp_addextendedproperty 'MS_Description', 
   '������ʱ��',
   'user', 'dbo', 'table', 'sys_Online', 'column', 'O_LastTime'
go

execute sp_addextendedproperty 'MS_Description', 
   '���������վ',
   'user', 'dbo', 'table', 'sys_Online', 'column', 'O_LastUrl'
go

/*==============================================================*/
/* Table: sys_RoleApplication                                   */
/*==============================================================*/
create table dbo.sys_RoleApplication (
   A_RoleID             int                  not null,
   A_ApplicationID      int                  not null,
   constraint PK_SYS_ROLEAPPLICATION primary key nonclustered (A_RoleID, A_ApplicationID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '��ɫӦ�ñ�',
   'user', 'dbo', 'table', 'sys_RoleApplication'
go

execute sp_addextendedproperty 'MS_Description', 
   '��ɫID��sys_Roles��RoleID���',
   'user', 'dbo', 'table', 'sys_RoleApplication', 'column', 'A_RoleID'
go

execute sp_addextendedproperty 'MS_Description', 
   'Ӧ��ID��sys_Applications��Appl',
   'user', 'dbo', 'table', 'sys_RoleApplication', 'column', 'A_ApplicationID'
go

/*==============================================================*/
/* Table: sys_RolePermission                                    */
/*==============================================================*/
create table dbo.sys_RolePermission (
   PermissionID         int                  identity,
   P_RoleID             int                  not null,
   P_ApplicationID      int                  not null,
   P_PageCode           varchar(20)          not null,
   P_Value              int                  null,
   constraint PK_sys_RolePermission primary key nonclustered (P_RoleID, P_ApplicationID, P_PageCode)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '��ɫӦ��Ȩ�ޱ�',
   'user', 'dbo', 'table', 'sys_RolePermission'
go

execute sp_addextendedproperty 'MS_Description', 
   '��ɫӦ��Ȩ���Զ�ID',
   'user', 'dbo', 'table', 'sys_RolePermission', 'column', 'PermissionID'
go

execute sp_addextendedproperty 'MS_Description', 
   '��ɫID��sys_Roles����RoleID��',
   'user', 'dbo', 'table', 'sys_RolePermission', 'column', 'P_RoleID'
go

execute sp_addextendedproperty 'MS_Description', 
   '��ɫ����Ӧ��ID��sys_Applicatio',
   'user', 'dbo', 'table', 'sys_RolePermission', 'column', 'P_ApplicationID'
go

execute sp_addextendedproperty 'MS_Description', 
   '��ɫӦ����ҳ��Ȩ�޴���',
   'user', 'dbo', 'table', 'sys_RolePermission', 'column', 'P_PageCode'
go

execute sp_addextendedproperty 'MS_Description', 
   'Ȩ��ֵ',
   'user', 'dbo', 'table', 'sys_RolePermission', 'column', 'P_Value'
go

/*==============================================================*/
/* Table: sys_Roles                                             */
/*==============================================================*/
create table dbo.sys_Roles (
   RoleID               int                  identity,
   R_UserID             int                  not null,
   R_RoleName           nvarchar(50)         not null,
   R_Description        nvarchar(255)        null,
   constraint PK_sys_Roles primary key nonclustered (RoleID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '��ɫ��',
   'user', 'dbo', 'table', 'sys_Roles'
go

execute sp_addextendedproperty 'MS_Description', 
   '��ɫID�Զ�ID',
   'user', 'dbo', 'table', 'sys_Roles', 'column', 'RoleID'
go

execute sp_addextendedproperty 'MS_Description', 
   '�ǽ������û�ID',
   'user', 'dbo', 'table', 'sys_Roles', 'column', 'R_UserID'
go

execute sp_addextendedproperty 'MS_Description', 
   '��ɫ����',
   'user', 'dbo', 'table', 'sys_Roles', 'column', 'R_RoleName'
go

execute sp_addextendedproperty 'MS_Description', 
   '��ɫ����',
   'user', 'dbo', 'table', 'sys_Roles', 'column', 'R_Description'
go

/*==============================================================*/
/* Table: sys_SystemInfo                                        */
/*==============================================================*/
create table dbo.sys_SystemInfo (
   SystemID             int                  identity,
   S_Name               nvarchar(50)         null,
   S_Version            nvarchar(50)         null,
   S_SystemConfigData   image                null,
   S_Licensed           varchar(50)          null,
   constraint PK_SYS_SYSTEMINFO primary key nonclustered (SystemID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   'ϵͳ��Ϣ��',
   'user', 'dbo', 'table', 'sys_SystemInfo'
go

execute sp_addextendedproperty 'MS_Description', 
   '�Զ�ID',
   'user', 'dbo', 'table', 'sys_SystemInfo', 'column', 'SystemID'
go

execute sp_addextendedproperty 'MS_Description', 
   'ϵͳ����',
   'user', 'dbo', 'table', 'sys_SystemInfo', 'column', 'S_Name'
go

execute sp_addextendedproperty 'MS_Description', 
   '�汾��',
   'user', 'dbo', 'table', 'sys_SystemInfo', 'column', 'S_Version'
go

execute sp_addextendedproperty 'MS_Description', 
   'ϵͳ������Ϣ',
   'user', 'dbo', 'table', 'sys_SystemInfo', 'column', 'S_SystemConfigData'
go

execute sp_addextendedproperty 'MS_Description', 
   '���к�',
   'user', 'dbo', 'table', 'sys_SystemInfo', 'column', 'S_Licensed'
go

/*==============================================================*/
/* Table: sys_User                                              */
/*==============================================================*/
create table dbo.sys_User (
   UserID               int                  identity,
   U_LoginName          nvarchar(20)         not null,
   U_Password           varchar(32)          not null,
   U_CName              nvarchar(20)         null,
   U_EName              varchar(50)          null,
   U_GroupID            int                  not null,
   U_Email              varchar(100)         null,
   U_Type               tinyint              not null default 1,
   U_Status             tinyint              not null default 1,
   U_Licence            varchar(30)          null,
   U_Mac                varchar(50)          null,
   U_Remark             nvarchar(200)        null,
   U_IDCard             varchar(30)          null,
   U_Sex                tinyint              null,
   U_BirthDay           datetime             null,
   U_MobileNo           varchar(15)          null,
   U_UserNO             varchar(20)          null,
   U_WorkStartDate      datetime             null,
   U_WorkEndDate        datetime             null,
   U_CompanyMail        varchar(255)         null,
   U_Title              int                  null,
   U_Extension          varchar(10)          null,
   U_HomeTel            varchar(20)          null,
   U_PhotoUrl           nvarchar(255)        null,
   U_DateTime           datetime             null,
   U_LastIP             varchar(15)          null,
   U_LastDateTime       datetime             null,
   U_ExtendField        ntext                null,
   U_LoginType          varchar(255)         null,
   constraint PK_Sys_User primary key nonclustered (UserID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '�û���',
   'user', 'dbo', 'table', 'sys_User'
go

execute sp_addextendedproperty 'MS_Description', 
   '�û�ID��',
   'user', 'dbo', 'table', 'sys_User', 'column', 'UserID'
go

execute sp_addextendedproperty 'MS_Description', 
   '��½��',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_LoginName'
go

execute sp_addextendedproperty 'MS_Description', 
   '����md5�����ַ�',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_Password'
go

execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_CName'
go

execute sp_addextendedproperty 'MS_Description', 
   'Ӣ����',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_EName'
go

execute sp_addextendedproperty 'MS_Description', 
   '����ID����sys_Group����GroupID����',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_GroupID'
go

execute sp_addextendedproperty 'MS_Description', 
   '�����ʼ�',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_Email'
go

execute sp_addextendedproperty 'MS_Description', 
   '�û�����0:�����û�1:��ͨ�û�',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_Type'
go

execute sp_addextendedproperty 'MS_Description', 
   '��ǰ״̬0:���� 1:��ֹ��½ 2:ɾ��',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_Status'
go

execute sp_addextendedproperty 'MS_Description', 
   '�û����к�',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_Licence'
go

execute sp_addextendedproperty 'MS_Description', 
   '��������Ӳ����ַ',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_Mac'
go

execute sp_addextendedproperty 'MS_Description', 
   '��ע˵��',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_Remark'
go

execute sp_addextendedproperty 'MS_Description', 
   '���֤����',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_IDCard'
go

execute sp_addextendedproperty 'MS_Description', 
   '�Ա�1:��0:Ů',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_Sex'
go

execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_BirthDay'
go

execute sp_addextendedproperty 'MS_Description', 
   '�ֻ���',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_MobileNo'
go

execute sp_addextendedproperty 'MS_Description', 
   'Ա�����',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_UserNO'
go

execute sp_addextendedproperty 'MS_Description', 
   '��ְ����',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_WorkStartDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '��ְ����',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_WorkEndDate'
go

execute sp_addextendedproperty 'MS_Description', 
   '��˾�ʼ���ַ',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_CompanyMail'
go

execute sp_addextendedproperty 'MS_Description', 
   'ְ����Ӧ���ֶι���',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_Title'
go

execute sp_addextendedproperty 'MS_Description', 
   '�ֻ���',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_Extension'
go

execute sp_addextendedproperty 'MS_Description', 
   '���е绰',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_HomeTel'
go

execute sp_addextendedproperty 'MS_Description', 
   '�û���Ƭ��ַ',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_PhotoUrl'
go

execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_DateTime'
go

execute sp_addextendedproperty 'MS_Description', 
   '������IP',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_LastIP'
go

execute sp_addextendedproperty 'MS_Description', 
   '������ʱ��',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_LastDateTime'
go

execute sp_addextendedproperty 'MS_Description', 
   '��չ�ֶ�',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_ExtendField'
go

execute sp_addextendedproperty 'MS_Description', 
   '��������(Ϊ��ϵͳ��֤,����ֵΪ������֤)',
   'user', 'dbo', 'table', 'sys_User', 'column', 'U_LoginType'
go

/*==============================================================*/
/* Table: sys_UserRoles                                         */
/*==============================================================*/
create table dbo.sys_UserRoles (
   R_UserID             int                  not null,
   R_RoleID             int                  not null,
   constraint PK_SYS_USERROLES primary key nonclustered (R_UserID, R_RoleID)
)
go

execute sp_addextendedproperty 'MS_Description', 
   '�û���ɫ��',
   'user', 'dbo', 'table', 'sys_UserRoles'
go

execute sp_addextendedproperty 'MS_Description', 
   '�û�ID��sys_User����UserID���',
   'user', 'dbo', 'table', 'sys_UserRoles', 'column', 'R_UserID'
go

execute sp_addextendedproperty 'MS_Description', 
   '�û�������ɫID��Sys_Roles����',
   'user', 'dbo', 'table', 'sys_UserRoles', 'column', 'R_RoleID'
go

