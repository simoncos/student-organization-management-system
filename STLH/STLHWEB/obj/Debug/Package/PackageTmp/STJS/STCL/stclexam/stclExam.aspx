<%@ Page Title="" Language="C#" MasterPageFile="~/MASTER/Main1.Master" AutoEventWireup="true" CodeBehind="stclExam.aspx.cs" Inherits="STLHWEB.STJS.STCL.stclExam" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>社团成立申请审核</title>
<link href="/CSS/stjsStyle.css" type="text/css" rel="Stylesheet" />
<link href="/CSS/pictureEnlarge.css" type="text/css" rel="Stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <div><h2 class="title">社团成立申请审核</h2></div><%--总标题--%>
        
        <div>                                          <%--基本信息--%>
        	<table class="contentTable">
            <tr class="titlet"><th class="align" colspan="2"><span class="align">基本信息</span></th></tr>
            <tr><td class="text">&nbsp;&nbsp;社团名称</td>
           	  <td class="textBox"><asp:TextBox ID="stName" CssClass="box" runat="server" 
                      readonly="true"
    style="cursor:not-allowed;" ></asp:TextBox></td></tr>
            <tr><td class="text">&nbsp;&nbsp;社团类别</td>
           	<td class="textBox"><asp:TextBox ID="stType" CssClass="box" runat="server" 
                      readonly="true" style="cursor:not-allowed"></asp:TextBox></td></tr>
              <tr><td class="text">&nbsp;&nbsp;会费</td>
           	  <td class="textBox"><asp:TextBox ID="fee" CssClass="box" runat="server"/></td></tr>
            <tr><td class="text">&nbsp;&nbsp;会长学号</td>
           	  <td class="textBox"><asp:TextBox ID="stuId" CssClass="box" readonly="true" style="cursor:not-allowed"
                      runat="server"  /></td></tr>
            <tr><td class="text">&nbsp;&nbsp;联系方式</td>
           	  <td class="textBox"><asp:TextBox ID="stuTel" CssClass="box" runat="server" readonly="true" style="cursor:not-allowed"/></td></tr>
            <tr><td class="text">&nbsp;&nbsp;宿舍</td>
           	  <td class="textBox"><asp:TextBox ID="stuDormitory" CssClass="box" runat="server" readonly="true" style="cursor:not-allowed"/></td></tr>
            <tr><td class="text">&nbsp;&nbsp;指导教师</td>
           	  <td class="textBox"><asp:TextBox ID="guideTeacher" CssClass="box" runat="server" 
                      readonly="true" style="cursor:not-allowed">未定</asp:TextBox>
                </td></tr>
            <tr><td class="text">&nbsp;&nbsp;挂靠单位</td>
           	  <td class="textBox"><asp:TextBox ID="guideUnit" CssClass="box" runat="server" 
                      readonly="true" style="cursor:not-allowed">未定</asp:TextBox>
                </td></tr>
            </table>
        </div>
 		
        <div>
        	<table class="contentTable">
            <tr class="titlet"><th class="align"><span class="align">社团申请书</span></th></tr>
            <tr><td style="text-align:center; width:100%;border:1px solid #C7D1CC;">
                <asp:Label id="stApplication"  runat="server" CssClass="textlabel"></asp:Label></td></tr>
            </table>
        </div>
        
         <div>
        	<table class="contentTable">
            <tr class="titlet"><th align="left">会长自荐书</th></tr>
            <tr><td style="text-align:center;width:100%;border:1px solid #C7D1CC;">  
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
         
         <div>
          <hr />
        	<table class="contentTable">
            <tr><th class="pz">修改建议</th></tr>
            <tr><td style="text-align: center;">
                <asp:TextBox id="txtbox_amendments" TextMode="MultiLine" runat="server" 
                    CssClass="sugtextfied"  placeholder="未批准申请则填写此项"></asp:TextBox></td></tr>
                    </table>           
		</div>	
         <div><br/><hr /><br />
             <asp:Button ID="save" runat="server" Text="提交修改建议" onclick="save_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button
                 ID="putIn" runat="server" Text="审核通过" onclick="putIn_Click"/><br /><br /></div>

    <script type="text/javascript" src="/JS/jquery.min.js"></script>
    <script type="text/javascript" src="/JS/pictureEnlarge.js"></script>
</asp:Content>
