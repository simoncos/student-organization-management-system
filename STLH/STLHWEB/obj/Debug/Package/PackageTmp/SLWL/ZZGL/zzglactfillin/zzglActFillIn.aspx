<%@ Page Title="" Language="C#" MasterPageFile="~/MASTER/Main1.Master" AutoEventWireup="true" 
CodeBehind="zzglActFillIn.aspx.cs" Inherits="STLHWEB.SLWL.ZZGL.zzglActFillIn" MaintainScrollPositionOnPostback="true" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>赞助活动登记</title>

<link href="/CSS/publicStyle.css" type="text/css" rel="Stylesheet" />
<link href="/CSS/stjsStyle.css" type="text/css" rel="Stylesheet" />
<link href="/CSS/calendar.css" type="text/css" rel="Stylesheet" />
 <style type="text/css">
 .Watermark{color:#bebebe;}
.Validator{background-color:#f5f7fb;}
 </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">

 
    <asp:ScriptManager ID="ScriptManager1" runat="server"/>
    <div><h2 class="title">赞助活动登记</h2><hr/></div>

    <div>

  <table  class="contentTable">

            <tr class="pz">
   
            <td style="float:left;">填表人:</td>
            <td  style="float:left;" ><span class="dynamic"><asp:Label ID="lab_positiveListPerson1" runat="server" Text="" ></asp:Label></span></td>
            <td style="float:left;">填表时间:</td>
            <td style="float:left;"><span class="dynamic"><asp:Label ID="lab_positiveListDate1" runat="server" Text="" > </asp:Label></span></td>
            <td style="float:left;">状态:</td>
            <td  style="float:left;"><span class="dynamic"> <asp:Label ID="lab_positiveListState1" runat="server" Text=""  ></asp:Label></span></td>
 
            </tr></table>
            
            <table class="contentTable">
            <tr class="titlet"><th  class="align" colspan="2"><span class="align">基本信息填写</span></th></tr>
            <tr><td class="text">&nbsp;&nbsp;赞助商</td>
           	  <td class="textBox"><asp:DropDownList ID="zzActName1" CssClass="ddl" runat="server"  >
              </asp:DropDownList>
              </td></tr>
            <tr><td class="text">&nbsp;&nbsp;赞助方式</td>                                        
           	  <td class="textBox"><asp:TextBox ID="zzActType1"  CssClass="box" style="width:350px;" runat="server" maxlength="20" 
                        onpropertychange="checklen(this)"> </asp:TextBox>
           <asp:TextBoxWatermarkExtender ID="tbwExd_zzActType1" runat="server" 
TargetControlID="zzActType1" WatermarkText="必填" WatermarkCssClass="Watermark"></asp:TextBoxWatermarkExtender>
              <asp:RequiredFieldValidator ID="zzActType_checkTip1" runat="server" 
                    ErrorMessage="请填写赞助方式,不超过20字" ControlToValidate="zzActType1" Display="None"></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="vcExd_zzActType1" runat="server" TargetControlID="zzActType_checkTip1" HighlightCssClass="Validator">
                        </asp:ValidatorCalloutExtender>
                    </td>
              </tr>
            <tr><td class="text">&nbsp;&nbsp;活动场地</td>
           	  <td class="textBox">
                  <asp:DropDownList ID="zzActPlace1" CssClass="ddl"   
                      runat="server" AutoPostBack="True" 
                      onselectedindexchanged="zzActPlace1_SelectedIndexChanged" >     
              </asp:DropDownList>     
            <asp:TextBox ID="location" runat="server" Visible="false"  Width="200px"></asp:TextBox></td></tr>
            <tr><td class="text">&nbsp;&nbsp;活动立项时间</td>
           	  <td class="textBox"><asp:TextBox ID="setupTime" CssClass="box" runat="server" style="width:350px;" name="date"></asp:TextBox> 
              <asp:RequiredFieldValidator
                         ID="RegularExpressionValidator1" runat="server" ErrorMessage="日期格式不匹配，如2013-01-04 12：00！" display="None"
                      ControlToValidate="setupTime"
                      ValidationExpression="^([1][7-9][0-9][0-9]|[2][0][0-9][0-9])(\-)([0][1-9]|[1][0-2])(\-)([0-2][1-9]|[3][0-1])( )([0-1][0-9]|[2][0-3])(:)([0-5][0-9])(:)([0-5][0-9])$"></asp:RequiredFieldValidator>
               <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RegularExpressionValidator1" HighlightCssClass="Validator">
                        </asp:ValidatorCalloutExtender></td></tr>
            <tr><td class="text">&nbsp;&nbsp;预约时间段</td>
           	  <td class="textBox"><asp:TextBox ID="zzActTime1" CssClass="box" style="width:350px;" runat="server"></asp:TextBox>
<asp:TextBoxWatermarkExtender ID="tbwExd_zzActTime1" runat="server" 
TargetControlID="zzActTime1" WatermarkText="必填"  WatermarkCssClass="Watermark"></asp:TextBoxWatermarkExtender>

              <asp:RequiredFieldValidator
                         ID="RequiredFieldValidator2"  Display="None"  runat="server" ErrorMessage="请填写预约时间段" 
                      ControlToValidate="zzActTime1" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:ValidatorCalloutExtender ID="vcExd_activityName1" runat="server" TargetControlID="RequiredFieldValidator2" HighlightCssClass="Validator">
                        </asp:ValidatorCalloutExtender>
             </td></tr>

            <tr><td class="text">&nbsp;&nbsp;预算金额</td>
           	  <td class="textBox"><asp:TextBox ID="zzActFund1" CssClass="box" style="width:350px;" runat="server"></asp:TextBox>
              <asp:TextBoxWatermarkExtender ID="tbwExd_activityName1" runat="server" 
TargetControlID="zzActFund1" WatermarkText="单位：元" WatermarkCssClass="Watermark"></asp:TextBoxWatermarkExtender>
             </td></tr>
            <tr><td class="text">&nbsp;&nbsp;实际时间</td>
           	  <td class="textBox"><asp:TextBox ID="zzActNowTime1" CssClass="box" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;格式：xxxx-xx-xx
             </td></tr>
             <tr><td class="text">&nbsp;&nbsp;实际金额</td>
           	  <td class="textBox"><asp:TextBox ID="zzActNowFund1" CssClass="box" style="width:350px;" runat="server"></asp:TextBox>             
               <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" 
TargetControlID="zzActNowFund1" WatermarkText="单位：元" WatermarkCssClass="Watermark"></asp:TextBoxWatermarkExtender>
             </td></tr>

        <tr><td class="text">&nbsp;&nbsp;负责人姓名</td>
           	  <td class="textBox"><asp:TextBox ID="zzActManager1" CssClass="box" style="width:350px;" runat="server"></asp:TextBox>
               <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" 
TargetControlID="zzActManager1" WatermarkText="必填" WatermarkCssClass="Watermark"></asp:TextBoxWatermarkExtender>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="请填写负责人" ControlToValidate="zzActManager1" ForeColor="Red"></asp:RequiredFieldValidator>
 <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator1" HighlightCssClass="Validator">
                        </asp:ValidatorCalloutExtender>
             </td></tr>
    
         </table>  </div>
        <div><br/><br/><br/><hr /><br />
             <asp:Button ID="Save" runat="server" Text="保存"
                 CssClass="btn" onclick="Save_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:Button ID="putIn" runat="server" Text="提交" CssClass="btn" 
                onclick="putIn_Click" /><br /><br /></div> 
  
    <script type="text/javascript" src="/JS/cal.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            var now = new Date();
            var startYear = now.getFullYear(); //获取四位数年数
            var endYear = startYear + 10;
            $('input.two').simpleDatepicker({ startdate: startYear, enddate: endYear }); //定义年的范围，一般用这个
        });
    </script>
<script type="text/javascript" language="javascript" src="/JS/lengthCheck.js"></script>
<script type="text/javascript" language="javascript" src="/JS/lookup.js"></script>
 
		<script type="text/javascript">
		    mainLoop = function () {
		        val = escape(queryField.value);
		        if (lastVal != val) {
		            var url = "fillin.ashx?param=" + val;
		            $.post(url, function (data) {
		                var re = data.split(",");
		                var response=new Array();
		                for (var i = 1; i < re.length; i++) {
		                    response[i - 1] = re[i];
		                }

		                showQueryDiv(response);
		            });

		            lastVal = val;
		        }
		        setTimeout('mainLoop()', 100);
		        return true;
		    }        
        </script>
    <script  type="text/javascript">
        InitQueryCode("" + '<%= zzActManager1.ClientID %>' + "");
    </script>   
</asp:Content>