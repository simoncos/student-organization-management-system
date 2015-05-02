--FrameWork1.0.7�洢���̸���
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sys_ModuleInsertUpdateDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sys_ModuleInsertUpdateDelete]
GO

-- ��������ɾ��
CREATE PROCEDURE [dbo].[sys_ModuleInsertUpdateDelete]
(	

	@ModuleID	 int = 0,	-- ����ģ��ID��
	@M_ApplicationID	 int = 0,	-- ����Ӧ�ó���ID
	@M_ParentID	 int = 0,	-- ��������ģ��ID��ModuleID����,0Ϊ����
	@M_PageCode	 varchar(100) = '',	-- ģ�����ParentΪ0,��ΪS00(xx),����ΪS00M00(xx)
	@M_CName	 nvarchar(50) = '',	-- ģ��/��Ŀ���Ƶ�ParentIDΪ0Ϊģ������
	@M_Directory	 nvarchar(255) = '',	-- ģ��/��ĿĿ¼��
	@M_OrderLevel	 varchar(4) = '',	-- ��ǰ�������򼶱�֧��˫��99���˵�
	@M_IsSystem	 tinyint = 0,	-- �Ƿ�Ϊϵͳģ��1:��0:����Ϊϵͳ���޷��޸�
	@M_Close	 tinyint = 0,	-- �Ƿ�ر�1:��0:��
	@M_Icon	 varchar(255) = '',	-- ģ��Icon
	@M_Info	 nvarchar(500) = '',	-- ģ��˵��
	@DB_Option_Action_  nvarchar(20) = ''		-- �������� Insert:���� Update:�޸� Delete:ɾ�� 
)
AS
	DECLARE @ReturnValue int -- ���ز������
	
	SET @ReturnValue = -1
	
	-- ����
	IF (@DB_Option_Action_='Insert')
	BEGIN
		INSERT INTO sys_Module( 
			M_ApplicationID,
			M_ParentID,
			M_PageCode,
			M_CName,
			M_Directory,
			M_OrderLevel,
			M_IsSystem,
			M_Close,
			M_Icon,
			M_Info
		) VALUES (	
			@M_ApplicationID,
			@M_ParentID,
			@M_PageCode,
			@M_CName,
			@M_Directory,
			@M_OrderLevel,
			@M_IsSystem,
			@M_Close,
			@M_Icon,
			@M_Info
		)
		SET @ReturnValue = @@IDENTITY
	END
	
	-- ����
	IF (@DB_Option_Action_='Update')
	BEGIN
		UPDATE sys_Module SET	
			M_ApplicationID = @M_ApplicationID,
			M_ParentID = @M_ParentID,
			M_PageCode = @M_PageCode,
			M_CName = @M_CName,
			M_Directory = @M_Directory,
			M_OrderLevel = @M_OrderLevel,
			M_IsSystem = @M_IsSystem,
			M_Close = @M_Close,
			M_Icon = @M_Icon,
			M_Info = @M_Info
		WHERE (ModuleID = @ModuleID)
		
		SET @ReturnValue = @@ROWCOUNT
	END
	
	-- ɾ��
	IF (@DB_Option_Action_='Delete')
	BEGIN
		DELETE sys_Module	WHERE (ModuleID = @ModuleID)
		SET @ReturnValue = @@ROWCOUNT
  	END

SELECT @ReturnValue

go

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[sys_UserInsertUpdateDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sys_UserInsertUpdateDelete]
GO

-- ��������ɾ��
CREATE PROCEDURE [dbo].[sys_UserInsertUpdateDelete]
(	

	@UserID	 int = 0,	-- �û�ID��
	@U_LoginName	 nvarchar(20) = '',	-- ��½��
	@U_Password	 varchar(32) = '',	-- ����md5�����ַ�
	@U_CName	 nvarchar(20) = '',	-- ��������
	@U_EName	 varchar(50) = '',	-- Ӣ����
	@U_GroupID	 int = 0,	-- ����ID����sys_Group����GroupID����
	@U_Email	 varchar(100) = '',	-- �����ʼ�
	@U_Type	 tinyint = 0,	-- �û�����0:�����û�1:��ͨ�û�
	@U_Status	 tinyint = 0,	-- ��ǰ״̬0:���� 1:��ֹ��½ 2:ɾ��
	@U_Licence	 varchar(30) = '',	-- �û����к�
	@U_Mac	 varchar(50) = '',	-- ��������Ӳ����ַ
	@U_Remark	 nvarchar(200) = '',	-- ��ע˵��
	@U_IDCard	 varchar(30) = '',	-- ���֤����
	@U_Sex	 tinyint = 0,	-- �Ա�1:��0:Ů
	@U_BirthDay	 datetime = Null,	-- ��������
	@U_MobileNo	 varchar(15) = '',	-- �ֻ���
	@U_UserNO	 varchar(20) = '',	-- Ա�����
	@U_WorkStartDate	 datetime = Null,	-- ��ְ����
	@U_WorkEndDate	 datetime = Null,	-- ��ְ����
	@U_CompanyMail	 varchar(255) = '',	-- ��˾�ʼ���ַ
	@U_Title	 int = 0,	-- ְ����Ӧ���ֶι���
	@U_Extension	 varchar(10) = '',	-- �ֻ���
	@U_HomeTel	 varchar(20) = '',	-- ���е绰
	@U_PhotoUrl	 nvarchar(255) = '',	-- �û���Ƭ��ַ
	@U_DateTime	 datetime = Null,	-- ����ʱ��
	@U_LastIP	 varchar(15) = '',	-- ������IP
	@U_LastDateTime	 datetime = Null,	-- ������ʱ��
	@U_ExtendField	 ntext  = '',	-- ��չ�ֶ�
	@U_LoginType	 varchar(255) = '',	-- ��������(Ϊ��ϵͳ��֤,����ֵΪ������֤)
	@DB_Option_Action_  nvarchar(20) = ''		-- �������� Insert:���� Update:�޸� Delete:ɾ�� 
)
AS
	DECLARE @ReturnValue int -- ���ز������
	
	SET @ReturnValue = -1
	
	-- ����
	IF (@DB_Option_Action_='Insert')
	BEGIN
		INSERT INTO sys_User( 
			U_LoginName,
			U_Password,
			U_CName,
			U_EName,
			U_GroupID,
			U_Email,
			U_Type,
			U_Status,
			U_Licence,
			U_Mac,
			U_Remark,
			U_IDCard,
			U_Sex,
			U_BirthDay,
			U_MobileNo,
			U_UserNO,
			U_WorkStartDate,
			U_WorkEndDate,
			U_CompanyMail,
			U_Title,
			U_Extension,
			U_HomeTel,
			U_PhotoUrl,
			U_DateTime,
			U_LastIP,
			U_LastDateTime,
			U_ExtendField,
			U_LoginType
		) VALUES (	
			@U_LoginName,
			@U_Password,
			@U_CName,
			@U_EName,
			@U_GroupID,
			@U_Email,
			@U_Type,
			@U_Status,
			@U_Licence,
			@U_Mac,
			@U_Remark,
			@U_IDCard,
			@U_Sex,
			@U_BirthDay,
			@U_MobileNo,
			@U_UserNO,
			@U_WorkStartDate,
			@U_WorkEndDate,
			@U_CompanyMail,
			@U_Title,
			@U_Extension,
			@U_HomeTel,
			@U_PhotoUrl,
			@U_DateTime,
			@U_LastIP,
			@U_LastDateTime,
			@U_ExtendField,
			@U_LoginType
		)
		SET @ReturnValue = @@IDENTITY
	END
	
	-- ����
	IF (@DB_Option_Action_='Update')
	BEGIN
		UPDATE sys_User SET	
			U_LoginName = @U_LoginName,
			U_Password = @U_Password,
			U_CName = @U_CName,
			U_EName = @U_EName,
			U_GroupID = @U_GroupID,
			U_Email = @U_Email,
			U_Type = @U_Type,
			U_Status = @U_Status,
			U_Licence = @U_Licence,
			U_Mac = @U_Mac,
			U_Remark = @U_Remark,
			U_IDCard = @U_IDCard,
			U_Sex = @U_Sex,
			U_BirthDay = @U_BirthDay,
			U_MobileNo = @U_MobileNo,
			U_UserNO = @U_UserNO,
			U_WorkStartDate = @U_WorkStartDate,
			U_WorkEndDate = @U_WorkEndDate,
			U_CompanyMail = @U_CompanyMail,
			U_Title = @U_Title,
			U_Extension = @U_Extension,
			U_HomeTel = @U_HomeTel,
			U_PhotoUrl = @U_PhotoUrl,
			U_DateTime = @U_DateTime,
			U_LastIP = @U_LastIP,
			U_LastDateTime = @U_LastDateTime,
			U_ExtendField = @U_ExtendField,
			U_LoginType = @U_LoginType
		WHERE (UserID = @UserID)
		
		SET @ReturnValue = @@ROWCOUNT
	END
	
	-- ɾ��
	IF (@DB_Option_Action_='Delete')
	BEGIN
		DELETE sys_User	WHERE (UserID = @UserID)
		SET @ReturnValue = @@ROWCOUNT
  	END

SELECT @ReturnValue


GO

