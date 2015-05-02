<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="STLHWEB.LOGIN.login"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="Server">
	
	<meta charset="utf-8" />
	
	<title>用户登录</title>
	<link rel="stylesheet" href="/css/flexi-background.css" type="text/css" media="screen" />
	<link rel="stylesheet" href="/css/login_styles.css" type="text/css" media="screen" />
	
</head>
<body>
	<script src="/JS/flexi-background.js" type="text/javascript" charset="utf-8"></script>
	<div id="box">
		<img src="/IMAGE/STLHMS1.png" class="logo" alt="yourlogo" />
		<h1>登 录</h1>
		<form id="login_form" method="post" runat="server">
			<input id="loginstuId" type="text" runat="server" onclick="this.value='';" onfocus="this.select()" onblur="this.value=!this.value?'用户名':this.value;" value="用户名" />
			<input id="loginPwd" type="password" runat="server" onclick="this.value='';" onfocus="this.select()" onblur="this.value=!this.value?'Password':this.value;" value="Password" />
			<input id="remember" type="checkbox" runat="server" value="Remember" />
			<div class="hover-opacity" runat="Server"><label for="remember">记住我</label></div>
			<input id="commit" type="submit" runat="server" name="" value="进  入" OnServerClick="login_commit_onclick"/>
		</form>
	</div>
	<a href="#" class="forgot">© by NetLeague</a>
</body>
</html>
