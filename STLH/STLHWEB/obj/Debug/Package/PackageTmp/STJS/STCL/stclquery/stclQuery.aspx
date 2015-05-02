<%@ Page Title="" Language="C#" MasterPageFile="~/MASTER/Main1.Master" AutoEventWireup="true" CodeBehind="stclQuery.aspx.cs" Inherits="STLHWEB.STJS.STCL.stclQuery" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>社团成立申请查询</title>
<link href="/CSS/stjsStyle.css" type="text/css" rel="Stylesheet" />
<link href="/CSS/pictureEnlarge.css" type="text/css" rel="Stylesheet" />
<style type="text/css">
panel{text-align:center;}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <div><h2 class="title">社团成立申请查询</h2></div><%--上传文件--%>
        
        <div>                                          <%--基本信息--%>
        	<table class="contentTable">
             <tr class="titlet"><th class="align" colspan="2"><span class="align">审核结果</span></th></tr>
            <tr  style="height:50px;vertical-align:middle;"><th colspan="2" class="pz" >
                <asp:Panel ID="pnl_examOn" runat="server" Visible="false">
                    您所申请成立的社团正在审核中,请耐心等待!</asp:Panel>
                <asp:Panel ID="pnl_examSuccess" runat="server" Visible="false">
                 <table><tr class="pz">
   
            <td style="float:left;">您所申请的社团审核成功！&nbsp;&nbsp;&nbsp;时间：</td>
            <td  style="float:left;" ><span class="dynamic"><asp:Label ID="lab_positiveDate" runat="server" Text="" ></asp:Label></span></td>
            <td style="float:left;">转正批准人：</td>
            <td style="float:left;"><span class="dynamic"><asp:Label ID="lab_positiveName" runat="server" Text="" > </asp:Label></span></td>
           
 </tr></table>

                </asp:Panel>     
                     
                <asp:Panel ID="pnl_examAfail" runat="server" style="height:250px; width:875px; border:1px double #479ac7;" 
                    Visible="false">
<span style="clear:both;float:left;font-size:16px;padding:10px 0 5px 10px;">审核部门修改意见&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
                  <span style="font-size:12px;padding:15px 0 0 10px; float:right; color:#8e8dc0; font-weight:100;">如提示未通过审核，请进入社团申请页面修改，或放弃申请</span>
                   <hr style="clear:both;text-align:left;width:875px;color:#9be8cc;"/>
                    <iframe id="stclAail" src="/STJS/STCL/stclquery/stclAfail.aspx" runat="server" style="height:200px;width:100%;border:0px solid #9be8cc;" 
    ></iframe>
                    </asp:Panel>

                </th></tr>
       
            <tr class="titlet"><th class="align" colspan="2"><span class="align">基本信息</span></th></tr>
            <tr><td class="text">&nbsp;&nbsp;社团名称</td>
           	  <td class="textBox"><asp:TextBox ID="stName" CssClass="box" readonly="true"
    style="cursor:not-allowed;" runat="server"></asp:TextBox></td></tr>      
            <tr><td class="text">&nbsp;&nbsp;社团类别</td>
           	<td class="textBox"><asp:TextBox ID="stType" CssClass="box" runat="server" readonly="true"
    style="cursor:not-allowed;" ></asp:TextBox></td></tr>
            <tr><td class="text">&nbsp;&nbsp;会费</td>
           	  <td class="textBox"><asp:TextBox ID="fee" CssClass="box" runat="server" readonly="true"
    style="cursor:not-allowed;" /></td></tr>
            <tr><td class="text">&nbsp;&nbsp;会长学号</td>
           	  <td class="textBox"><asp:TextBox ID="stuId" CssClass="box" 
                      runat="server" ReadOnly="True"     style="cursor:not-allowed;"/></td></tr>
            <tr><td class="text">&nbsp;&nbsp;联系方式</td>
           	  <td class="textBox"><asp:TextBox ID="stuTel" CssClass="box" readonly="true"
    style="cursor:not-allowed;"  runat="server"/></td></tr>
            <tr><td class="text">&nbsp;&nbsp;宿舍</td>
           	  <td class="textBox"><asp:TextBox ID="hzDormitory" CssClass="box" readonly="true"
    style="cursor:not-allowed;"  runat="server"/></td></tr>
            <tr><td class="text">&nbsp;&nbsp;指导教师</td>
           	  <td class="textBox"><asp:TextBox ID="guideTeacher" CssClass="box" readonly="true"
    style="cursor:not-allowed;"  runat="server">未定</asp:TextBox>
                </td></tr>
            <tr><td class="text">&nbsp;&nbsp;挂靠单位</td>
           	  <td class="textBox"><asp:TextBox ID="guideUnit" CssClass="box" readonly="true"
    style="cursor:not-allowed;"  runat="server">未定</asp:TextBox>
                </td></tr>
            </table>
        </div>
 		
        <div>
        	<table class="contentTable">
            <tr class="titlet"><th class="align"><span class="align">社团申请书</span></th></tr>
            <tr><td style="text-align:center;width:100%;border:1px solid #C7D1CC; ">
                   <asp:Label id="stApplication"  runat="server" CssClass="textlabel"></asp:Label></td></tr>
            </table>
        </div>
         <div>
        	<table class="contentTable">
            <tr class="titlet"><th class="align"><span class="align">会长自荐书</span></th></tr>                 
            <tr><td style="text-align:center;width:100%;border:1px solid #C7D1CC; ">
                    <asp:Label id="presidentRecommend"  runat="server" CssClass="textlabel"></asp:Label></td></tr>
            </table>
		 </div>


          <div>                                                 <%--上传文件--%>
        	<table class="contentTable">
            <tr class="titlet"><th class="align" colspan="4"><span class="align">上传文件</span></th></tr>
           
            <tr><td class="txt">社团成立申请表</td><td></td><td class="txt">挂靠单位申请</td></tr>
            <tr class="trsc">
                    <td class="tdimgExam">
                    <a id="a_stAppPic"  class="smallimage" target="_blank" runat="server">
                    <asp:Image ID="img_stAppPic" runat="server"  CssClass="imgQuery" onerror="this.src='/IMAGE/11.PNG'" />
                    </a></td>
                    
                    <td class="downloadButton">
                    <asp:ImageButton ID="imgbtn_stAppPic" runat="server" 
                            AlternateText="下载" class="imgbutton" Enabled="true" ImageUrl="~/IMAGE/downloadButton.png"
                            onclick="imgbtn_stAppPic_Click" />
                    </td>
                 <td class="tdimgExam" >
                <a id="a_unitPic" class="smallimage" target="_blank" runat="server">
                <asp:Image ID="img_unitPic" runat="server"  CssClass="imgQuery" onerror="this.src='/IMAGE/11.PNG'"/>
                </a></td>
                
                <td class="downloadButton"><asp:ImageButton ID="imgbtn_unitPic" runat="server" 
                        AlternateText="下载" class="imgbutton" Enabled="true" ImageUrl="~/IMAGE/downloadButton.png"
                        onclick="imgbtn_unitPic_Click" />
                 </td>
                 </tr>

            <tr><td class="txt">指导教师简介</td><td></td><td class="txt">word大全</td></tr>
            <tr class="trsc">
                   <td class="tdimgExam" >
                <a id="a_guidTeacherPic" class="smallimage" target="_blank" runat="server">
                <asp:Image ID="img_guideTeacherPic" runat="server"  CssClass="imgQuery" onerror="this.src='/IMAGE/11.PNG'" />
                </a></td>
                
                <td class="downloadButton"><asp:ImageButton ID="imgbtn_guideTeacherPic" runat="server" 
                        AlternateText="下载" class="imgbutton" Enabled="true" ImageUrl="~/IMAGE/downloadButton.png"
                        onclick="imgbtn_guideTeacherPic_Click" />
               </td>

                 <td class="tdimgExam" >
                <a id="a_otherFile" class="smallimage" target="_blank" runat="server">
                <asp:Image ID="img_wordDocument" runat="server"  CssClass="imgQuery" onerror="this.src='/IMAGE/11.PNG'"/>
                </a></td>

                <td class="downloadButton"><asp:ImageButton ID="imgbtn_wordDocument" runat="server" 
                        AlternateText="下载" class="imgbutton" Enabled="true" ImageUrl="~/IMAGE/downloadButton.png"
                        onclick="imgbtn_wordDocument_Click" />
                 </td>
                 </tr>

            </table>
		 </div>
        
         <br />
         <br />
         
    <script type="text/javascript" src="/JS/jquery.min.js"></script>
    <script type="text/javascript" src="/JS/pictureEnlarge.js"></script>
</asp:Content>
