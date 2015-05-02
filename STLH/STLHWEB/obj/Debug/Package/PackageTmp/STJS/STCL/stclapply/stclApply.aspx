<%@ Page Title="" Language="C#" MasterPageFile="~/MASTER/Main1.Master" AutoEventWireup="true" CodeBehind="stclApply.aspx.cs" Inherits="STLHWEB.STJS.STCL.stclApply" MaintainScrollPositionOnPostback="true" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>社团成立申请</title>
   <link href="/CSS/publicStyle.css" type="text/css" rel="Stylesheet" />
<link href="/CSS/upLoadFileStyle.css" type="text/css" rel="Stylesheet" />
<link href="/CSS/stjsStyle.css" type="text/css" rel="Stylesheet" />
<link href="/CSS/pictureEnlarge.css" type="text/css" rel="Stylesheet" />
 <style type="text/css">
 .Watermark{color:#bebebe;}
.Validator{background-color:#f5f7fb;}
 </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">

     <div> <h2 class="title">社团成立申请</h2></div> 
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div> 
        	<table class="contentTable">
            <tr class="titlet"><th class="align" colspan="2"><span class="align">基本信息</span></th></tr>

            <tr><td class="text">&nbsp;&nbsp;社团名称</td>
           	  <td class="textBox">
              <asp:TextBox ID="stName" CssClass="box" runat="server" style="width:350px;" maxlength="20" onpropertychange="checklen(this)"></asp:TextBox>
                    <asp:TextBoxWatermarkExtender ID="tbwExd_stName" runat="server"  
TargetControlID="stName" WatermarkText="必填" WatermarkCssClass="Watermark"></asp:TextBoxWatermarkExtender>
                     <asp:RequiredFieldValidator ID="stName_checkTip" runat="server" 
                         ErrorMessage="请输入社团名,不超过20字" ControlToValidate="stName"  Display="None"
                         SetFocusOnError="True"></asp:RequiredFieldValidator>
                     <asp:ValidatorCalloutExtender ID="vcExd_stName_checkTip" runat="server" TargetControlID="stName_checkTip" HighlightCssClass="Validator">
                     </asp:ValidatorCalloutExtender>     
                         
                         
                         </td></tr>
            <tr><td class="text">&nbsp;&nbsp;社团类别</td>                                        
           	  <td class="textBox"><asp:DropDownList ID="stType" CssClass="ddl" runat="server" >
                  <asp:ListItem>其他</asp:ListItem>
                  <asp:ListItem>文艺</asp:ListItem>
                  <asp:ListItem>体育</asp:ListItem>
                  <asp:ListItem>公益</asp:ListItem>
                  <asp:ListItem>就业</asp:ListItem>
                  <asp:ListItem>学习</asp:ListItem>
                  </asp:DropDownList></td></tr>
            <tr><td class="text">&nbsp;&nbsp;会费</td>
           	  <td class="textBox"><asp:TextBox ID="fee" CssClass="box" runat="server">0</asp:TextBox>
                </td></tr>
            <tr><td class="text">&nbsp;&nbsp;会长学号</td><%--会长学号——源自系统。--%>
           	  <td class="textBox"><asp:TextBox ID="stuId" CssClass="box" 
                      runat="server" ReadOnly="True" onkeydown="if(event.keyCode==8)return false;" /></td></tr>
            <tr><td class="text">&nbsp;&nbsp;联系电话</td>
           	  <td class="textBox"><asp:TextBox ID="stuTel" CssClass="box" style="width:350px;" runat="server"/>
          
                     <asp:TextBoxWatermarkExtender ID="tbwExd_stuTel" runat="server" 
TargetControlID="stuTel" WatermarkText="必填" WatermarkCssClass="Watermark"></asp:TextBoxWatermarkExtender>
                     
                     <asp:RequiredFieldValidator ID="stuTel_checkTip" runat="server" 
                         ErrorMessage="联系电话不能为空！" ControlToValidate="stuTel" Display="None" 
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                              <asp:ValidatorCalloutExtender ID="vcExd_stuTel1" runat="server" TargetControlID="stuTel_checkTip" HighlightCssClass="Validator">
                        </asp:ValidatorCalloutExtender>  


                     <asp:RegularExpressionValidator ID="stuTel_checkTip1" runat="server" 
                         ControlToValidate="stuTel" ErrorMessage="电话格式不匹配！" Display="None"
                         SetFocusOnError="True" ValidationExpression="((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)"></asp:RegularExpressionValidator>
<asp:ValidatorCalloutExtender ID="vcExd_stuTel2" runat="server" TargetControlID="stuTel_checkTip1" HighlightCssClass="Validator">
                        </asp:ValidatorCalloutExtender> 

               
               
               
                </td></tr>
            <tr><td class="text">&nbsp;&nbsp;宿舍地址</td>
           	  <td class="textBox"><asp:TextBox ID="stuDormitory" CssClass="box"  style="width:350px;"   maxlength="20" onpropertychange="checklen(this)" runat="server"/>&nbsp;&nbsp;
                <asp:TextBoxWatermarkExtender ID="tbwExd_stuDormitory" runat="server" 
TargetControlID="stuDormitory" WatermarkText="必填" WatermarkCssClass="Watermark"></asp:TextBoxWatermarkExtender>

                     <asp:RequiredFieldValidator ID="stuDormitory_checkTip" runat="server" 
                         ErrorMessage="宿舍号不能为空，不超过20字" ControlToValidate="stuDormitory" Display="None"
                         SetFocusOnError="True"></asp:RequiredFieldValidator>
                   <asp:ValidatorCalloutExtender ID="vcExd_stuDormitory_checkTip" runat="server" TargetControlID="stuDormitory_checkTip" HighlightCssClass="Validator">
                        </asp:ValidatorCalloutExtender>     
                         </td></tr>
            <tr><td class="text">&nbsp;&nbsp;指导教师</td><%--指导教师如果不为未定，则触发上传文件中指导教师简介需填写，否则指导教师简介不能上传文件。--%>
           	  <td class="textBox"><asp:TextBox ID="guideTeacher" CssClass="box" maxlength="20" onpropertychange="checklen(this)" runat="server" placeholder="未定"></asp:TextBox>
                </td></tr>
            <tr><td class="text">&nbsp;&nbsp;挂靠单位</td><%--指导教师如果不为未定，则触发上传文件中指导教师简介需填写，否则指导教师简介不能上传文件。--%>
           	  <td class="textBox"><asp:TextBox ID="guideUnit" CssClass="box" maxlength="20" onpropertychange="checklen(this)" runat="server" placeholder="未定"></asp:TextBox>
                </td></tr>
 
            </table>
        </div>
 		
        <div>
        	<table class="contentTable">
            <tr class="titlet"><th class="align"><span class="align">社团申请书</span></th><td style="float:left;">
             <asp:RequiredFieldValidator ID="stApplication_checkTip" runat="server" 
                    ErrorMessage="请输入社团申请书!" ControlToValidate="stApplication" 
                    Display="Dynamic" 
                    CssClass="rf" SetFocusOnError="True"></asp:RequiredFieldValidator>
            </td></tr>
            <tr><td style="text-align: left;" colspan="2" >
                <asp:TextBox id="stApplication" TextMode="MultiLine" 
                    runat="server" CssClass="textfield" style="width:876px;Height:212px;" ></asp:TextBox>

                        <asp:TextBoxWatermarkExtender ID="tbwExd_stApplication" runat="server" 
TargetControlID="stApplication" WatermarkText="必填" WatermarkCssClass="Watermark" ></asp:TextBoxWatermarkExtender>

                    </td></tr>
            </table>
        </div>
        
         <div>
        	<table class="contentTable">
            <tr class="titlet"><th class="align"><span class="align">会长自荐书</span></th><td style="float:left;">
            <asp:RequiredFieldValidator ID="presidentRecommend_checkTip" runat="server" 
                    ErrorMessage="请输入会长自荐书!" ControlToValidate="presidentRecommend"  Display="Dynamic" CssClass="rf"
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
             
                &nbsp;&nbsp;</td></tr>
            <tr><td colspan="2" style="text-align: left;">
                <asp:TextBox id="presidentRecommend" CssClass="textfield" TextMode="MultiLine" runat="server" style="width:876px;Height:212px;"></asp:TextBox>
                 <asp:TextBoxWatermarkExtender ID="tbwExd_presidentRecommend" runat="server" 
TargetControlID="presidentRecommend" WatermarkText="必填" WatermarkCssClass="Watermark"></asp:TextBoxWatermarkExtender>
                </td></tr>
            </table>
		 </div>


          <div>                                                 <%--上传文件--%>
        	<table class="contentTable">
            <tr class="titlet"><th class="align" colspan="3"><span class="align">上传文件</span></th></tr>
           
            <tr><th class="txt" colspan="3"  >社团成立申请表(.jpg、.jepg、.gif、.png,不超过1M)</th></tr>
            <tr class="trsc">
                    <td class="upLoad classifyTL1">
                    <a class="btn_addPic" href="javascript:void(0);"><span><em>+</em>添加图片</span>
                    <asp:FileUpload ID="fpd_stAppPic" runat="server" CssClass="filePrew" />
                    </a>
                 
                    </td>
                    <td class="tdimgbtn classifyT1"><asp:ImageButton ID="imgbtn_stAppPic" runat="server" 
                            AlternateText="上传" class="imgbutton"  ImageUrl="~/IMAGE/uploadButton.png" onclick="imgbtn_stAppPic_Click" /></td>
                    <td class="tdimg">

                        <a id="a_stAppPic"  class="smallimage" target="_blank" runat="server">
                        <asp:Image ID="img_stAppPic" runat="server" ImageAlign="Left" Visible="false" CssClass="img" onerror="this.src='/IMAGE/11.PNG'"/>
                        </a>
                     
                        <span class="align margin"><asp:Label ID="lab_stAppPic" runat="server" CssClass="label" Visible="false"></asp:Label></span></td></tr>
                 
            <tr >
                <th   class="txt"  colspan="3">挂靠单位申请(.jpg、.jepg、.gif、.png,不超过1M)</th></tr>
            <tr class="trsc" >
                <td class="upLoad classifyTL2">
                <a class="btn_addPic" href="javascript:void(0);"><span><em>+</em>添加图片</span>
                <asp:FileUpload ID="fpd_unitPic" runat="server"  CssClass="filePrew" />
                </a>
                </td>
                 <td class="tdimgbtn classifyT2"><asp:ImageButton ID="imgbtn_unitPic" runat="server"  
                         AlternateText="上传" class="imgbutton" onclick="imgbtn_unitPic_Click" 
                         ImageUrl="~/IMAGE/uploadButton.png" /></td>
                 <td class="tdimg">
                    <a id="a_unitPic" class="smallimage" target="_blank" runat="server">
                    <asp:Image ID="img_unitPic" runat="server" ImageAlign="Left" Visible="false"
                         CssClass="img" onerror="this.src='/IMAGE/11.PNG'"/>
                         </a>
                    <span class="align margin"><asp:Label ID="lab_unitPic" runat="server"  class="label" Visible="false"></asp:Label></span></td></tr>
                    <%-- 在label中添加验证弹出信息--%>


			<tr><th class="txt" colspan="3" >指导老师简介(.jpg、.jepg、.gif、.png,不超过1M)</th></tr>
            <tr class="trsc">
                <td class="upLoad classifyTL1" >
                <a class="btn_addPic" href="javascript:void(0);"><span><em>+</em>添加图片</span>
                <asp:FileUpload ID="fpd_guideTeacherPic" runat="server" CssClass="filePrew" />
                </a>
                </td>
                <td class="tdimgbtn classifyT1"><asp:ImageButton ID="imgbtn_guideTeacherPic" runat="server" 
                        AlternateText="上传" class="imgbutton" ImageUrl="~/IMAGE/uploadButton.png" onclick="imgbtn_guideTeacherPic_Click" /></td>
                <td class="tdimg">
                <a id="a_guidTeacherPic" class="smallimage" target="_blank" runat="server">
                    <asp:Image ID="img_guidTeacherPic" runat="server" ImageAlign="Left" Visible="false"
                        CssClass="img" onerror="this.src='/IMAGE/11.PNG'" />
                        </a>
                  <span class="align margin">  <asp:Label ID="lab_guidTeacherPic" runat="server"  CssClass="label" Visible="false"></asp:Label></span></td></tr>
            <tr><th class="txt" colspan="3">word大全(.doc、.docx)</th></tr>
            <tr class="trsc">
                <td class="upLoad classifyTL2">
                <a class="btn_addPic" href="javascript:void(0);"><span><em>+</em>添加文档</span>
                <asp:FileUpload ID="fpd_otherFile" runat="server" CssClass="filePrew" />
                </a>
                </td>
                
                <td  class="tdimgbtn classifyT2">
                <asp:ImageButton ID="imgbtn_otherFile" runat="server" 
                        AlternateText="上传" class="imgbutton" ImageUrl="~/IMAGE/uploadButton.png"  onclick="imgbtn_otherFile_Click"   />
                </td>

                <td class="tdimg">

                <a id="a_otherFile" target="_blank" runat="server">
                    <asp:Image ID="img_otherFile" runat="server"  ImageAlign="Left" Visible="false"
                        CssClass="img" onerror="this.src='/IMAGE/11.PNG'"/>
                        </a>
                <span class="align margin" >    <asp:Label ID="lab_otherFile" runat="server" CssClass="label" Visible="false"></asp:Label></span></td></tr>
             <%--此处文件可以为空--%>
            </table>
		 </div>
         <br />
         <br /><br/><hr /><br />
         <div>
             <asp:Button ID="save" runat="server" Text="保存草稿" onserverclick="save_Click" 
                 CssClass="btn" onclick="save_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           <asp:Button ID="putIn" runat="server" Text="提交申请" CssClass="btn" 
                 onserverclick="putIn_Click" onclick="putIn_Click" /> <br /><br /></div><%--提示框--%>
    <script type="text/javascript" src="/JS/pictureEnlarge.js"></script>
    <script type="text/javascript" language="javascript" src="/JS/lengthCheck.js"></script>
    <%--<script type="text/javascript" language="javascript" src="/JS/alertWin.js"></script>--%>
</asp:Content>














