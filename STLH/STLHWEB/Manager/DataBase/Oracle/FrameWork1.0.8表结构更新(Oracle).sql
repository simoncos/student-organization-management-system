--FrameWork1.08��ṹ����.sql by supesoft.com 2011/3/5
--sys_Module �� ���� M_Info��
alter table SYS_MODULE add M_INFO VARCHAR2(500 BYTE);
--sys_Module ���޸�M_PageCode����Ϊ100
alter table SYS_MODULE modify (M_PAGECODE varchar2(100 BYTE));

--sys_User �� ���� U_LoginType��
alter table SYS_USER add U_LOGINTYPE VARCHAR2(255 BYTE);
