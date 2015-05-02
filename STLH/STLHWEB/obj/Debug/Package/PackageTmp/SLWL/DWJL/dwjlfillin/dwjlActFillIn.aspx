<%@ Page Language="C#" MasterPageFile="~/MASTER/Main1.Master" AutoEventWireup="true" 
CodeBehind="dwjlActFillIn.aspx.cs" Inherits="STLHWEB.SLWL.DWJL.dwjlActFillIn" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>对外交流活动信息</title>
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
     <div><h2 class="title"> 交流活动信息</h2><hr/></div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
       <div> 
       <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true"><ContentTemplate>        
           <table  class="contentTable">

            <tr class="pz">
   
            <td style="float:left;">填表人:</td>
            <td  style="float:left;" ><span class="dynamic"><asp:Label ID="lab_positiveListPerson2" runat="server" Text="" ></asp:Label></span></td>
            <td style="float:left;">填表时间:</td>
            <td style="float:left;"><span class="dynamic"><asp:Label ID="lab_positiveListDate2" runat="server" Text="" > </asp:Label></span></td>
            <td style="float:left;">状态:</td>
            <td  style="float:left;"><span class="dynamic"> <asp:Label ID="lab_positiveListState2" runat="server" Text=""  ></asp:Label></span></td>
 
            </tr></table>


            
        	<table class="contentTable">
             <tr class="titlet"><th  class="align" colspan="2"><span class="align">基本信息填写</span></th></tr>
            
            <tr><td class="text">&nbsp;&nbsp;发起方名称</td>
           	    <td class="textBox"><asp:TextBox ID="txtbox_sponsor1" CssClass="box" 
                        style="width:350px;" runat="server" maxlength="20" 
                        onpropertychange="checklen(this)" ></asp:TextBox>
<asp:TextBoxWatermarkExtender ID="tbwExd_sponsor1" runat="server" 
TargetControlID="txtbox_sponsor1" WatermarkText="必填" WatermarkCssClass="Watermark"></asp:TextBoxWatermarkExtender>
<asp:RequiredFieldValidator ID="rf_sponsor1" runat="server" ControlToValidate="txtbox_sponsor1" Display="None" ErrorMessage="请输入发起者名，不超出20字">
                        </asp:RequiredFieldValidator>
<asp:ValidatorCalloutExtender ID="vcExd_sponsor1" runat="server" TargetControlID="rf_sponsor1" HighlightCssClass="Validator">
                        </asp:ValidatorCalloutExtender></td></tr>

              <tr><td class="text">&nbsp;&nbsp;受邀方名称</td>
           	  <td class="textBox"><asp:TextBox ID="txtbox_invitee1" CssClass="box" style="width:350px;"  maxlength="20" onpropertychange="checklen(this)"   runat="server"></asp:TextBox>
<asp:TextBoxWatermarkExtender ID="tbwExd_invitee1" runat="server" 
TargetControlID="txtbox_invitee1" WatermarkText="必填" WatermarkCssClass="Watermark"></asp:TextBoxWatermarkExtender>
<asp:RequiredFieldValidator ID="rf_invitee1" runat="server" ControlToValidate="txtbox_invitee1" Display="None" ErrorMessage="请输入受邀方名，不超出20字">
                        </asp:RequiredFieldValidator>
<asp:ValidatorCalloutExtender ID="vcExd_invitee1" runat="server" TargetControlID="rf_invitee1" HighlightCssClass="Validator">
                        </asp:ValidatorCalloutExtender></td>  </tr>

              <tr><td class="text">&nbsp;&nbsp;交流活动名称</td>
           	  <td class="textBox"><asp:TextBox ID="txtbox_activityName1" CssClass="box" style="width:350px;" maxlength="20" onpropertychange="checklen(this)" runat="server"></asp:TextBox>
<asp:TextBoxWatermarkExtender ID="tbwExd_activityName1" runat="server" 
TargetControlID="txtbox_activityName1" WatermarkText="必填" WatermarkCssClass="Watermark"></asp:TextBoxWatermarkExtender>
<asp:RequiredFieldValidator ID="rf_activityName1" runat="server" ControlToValidate="txtbox_activityName1" Display="None" ErrorMessage="请输入交流活动名称，不超出20字">
                        </asp:RequiredFieldValidator>
<asp:ValidatorCalloutExtender ID="vcExd_activityName1" runat="server" TargetControlID="rf_activityName1" HighlightCssClass="Validator">
                        </asp:ValidatorCalloutExtender></td></tr>
<tr><td class="text">&nbsp;&nbsp;交流活动时间</td>
<td class="textBox">
<asp:TextBox ID="txtbox_activityTime1"  class="two box" style="width:350px;" name="date"  runat="server"></asp:TextBox>

<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                         ControlToValidate="txtbox_activityTime1" ErrorMessage="日期格式不匹配，如2013-01-04 12：00！" display="None"
                         SetFocusOnError="True" ValidationExpression="^([1][7-9][0-9][0-9]|[2][0][0-9][0-9])(\-)([0][1-9]|[1][0-2])(\-)([0-2][1-9]|[3][0-1])( )([0-1][0-9]|[2][0-3])(:)([0-5][0-9])(:)([0-5][0-9])$"></asp:RegularExpressionValidator>

<asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RegularExpressionValidator1" HighlightCssClass="Validator">
                        </asp:ValidatorCalloutExtender> </td>
</tr>


              <tr><td class="text">&nbsp;&nbsp;交流活动地点</td>
           	  <td class="textBox"><asp:TextBox ID="txtbox_activityPlace1" CssClass="box" style="width:350px;" maxlength="20" onpropertychange="checklen(this)" runat="server"  ></asp:TextBox>
<asp:TextBoxWatermarkExtender ID="tbwExd_activityPlace1" runat="server" 
TargetControlID="txtbox_activityPlace1" WatermarkText="必填" WatermarkCssClass="Watermark"></asp:TextBoxWatermarkExtender>
               <asp:RequiredFieldValidator ID="rf_activityPlace1" runat="server" ControlToValidate="txtbox_activityPlace1" Display="None" ErrorMessage="请输入交流活动地点，不超出20字">
                        </asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="vcExd_activityPlace1" runat="server" TargetControlID="rf_activityPlace1" HighlightCssClass="Validator">
                        </asp:ValidatorCalloutExtender></td></tr>

              <tr><td class="text">&nbsp;&nbsp;邀请人数</td>
           	  <td class="textBox"><asp:TextBox ID="txtbox_invitedNumber1" CssClass="box" style="width:350px;"  runat="server"></asp:TextBox></td></tr>

               <tr><td class="text">&nbsp;&nbsp;联系人姓名</td>
           	  <td class="textBox"><asp:TextBox ID="txtbox_linkmanName1" CssClass="box" style="width:350px;" maxlength="10" onpropertychange="checklen(this)" runat="server"></asp:TextBox></td></tr>

              <tr><td class="text">&nbsp;&nbsp;联系人电话</td>
           	  <td class="textBox"><asp:TextBox ID="txtbox_linkmanPhone1" CssClass="box" style="width:350px;" runat="server"></asp:TextBox>
              <asp:RegularExpressionValidator ID="rf_linkmanPhone1" runat="server" 
                         ControlToValidate="txtbox_linkmanPhone1" ErrorMessage="电话格式不匹配！" display="None"
                         SetFocusOnError="True" ValidationExpression="((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)"></asp:RegularExpressionValidator>
              <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="rf_linkmanPhone1" HighlightCssClass="Validator">
                        </asp:ValidatorCalloutExtender>
              </td></tr>


              <tr><td class="text">&nbsp;&nbsp;校内负责人姓名</td>
           	  <td class="textBox"><asp:TextBox ID="txtbox_schoolPrincipal1" CssClass="box" style="width:350px;" maxlength="10" onpropertychange="checklen(this)" runat="server"></asp:TextBox>
                 
<asp:TextBoxWatermarkExtender ID="tbwExd_schoolPrincipal1" runat="server" 
TargetControlID="txtbox_schoolPrincipal1" WatermarkText="必填" WatermarkCssClass="Watermark"></asp:TextBoxWatermarkExtender>
               <asp:RequiredFieldValidator ID="rf_schoolPrincipal1" runat="server" ControlToValidate="txtbox_schoolPrincipal1" Display="None" ErrorMessage="请输入校内负责人姓名，不超出20 字">
                        </asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="vcExd_schoolPrincipal1" runat="server" TargetControlID="rf_schoolPrincipal1" HighlightCssClass="Validator">
                        </asp:ValidatorCalloutExtender> </td></tr>

              <tr><td class="text">&nbsp;&nbsp;负责人电话</td>
           	  <td class="textBox"><asp:TextBox ID="txtbox_schoolPrincipalPhone1" CssClass="box" style="width:350px;" runat="server"></asp:TextBox>
              
<asp:TextBoxWatermarkExtender ID="tbwExd_schoolPrincipalPhone1" runat="server" 
TargetControlID="txtbox_schoolPrincipalPhone1" WatermarkText="必填" WatermarkCssClass="Watermark"></asp:TextBoxWatermarkExtender>
<asp:RequiredFieldValidator ID="rf_schoolPrincipalPhone1" runat="server" ControlToValidate="txtbox_schoolPrincipalPhone1" Display="None" ErrorMessage="请输入负责人电话">
                        </asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="rf_schoolPrincipalPhone2" runat="server" 
                         ControlToValidate="txtbox_schoolPrincipalPhone1" ErrorMessage="电话格式不匹配！" display="None"
                         SetFocusOnError="True" ValidationExpression="((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)"></asp:RegularExpressionValidator>
<asp:ValidatorCalloutExtender ID="vcExd_schoolPrincipalPhone1" runat="server" TargetControlID="rf_schoolPrincipalPhone1" HighlightCssClass="Validator">
                        </asp:ValidatorCalloutExtender>  

<asp:ValidatorCalloutExtender ID="vcExd_schoolPrincipalPhone2" runat="server" TargetControlID="rf_schoolPrincipalPhone2" HighlightCssClass="Validator">
                        </asp:ValidatorCalloutExtender>  </td> </tr>
          
              <tr align="center"><td colspan="2" align="right"><div>
         <br/><hr /><br />
                  <asp:Button ID="uncover" runat="server" Text="不覆盖"  CssClass="btn"  Visible="false"
               onclick="uncover_Click" />
          <asp:Button ID="cover" runat="server" Text="覆盖"  CssClass="btn"  Visible="false"
               onclick="cover_Click" />
             <asp:Button ID="save" runat="server" Text="保存"  CssClass="btn" 
               onclick="save_Click" />
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Button ID="cancel" runat="server" Text="清空" CssClass="btn" 
               onclick="cancel_Click" />
           <br /><br />
         </div></td></tr>
              <tr class="titlet"><th  class="align" colspan="2"><span class="align">对外交流人员</span></th></tr></table>
        </ContentTemplate>
 <Triggers>

      <asp:PostBackTrigger    ControlID="cancel" />
       <asp:PostBackTrigger    ControlID="uncover" />
      <asp:PostBackTrigger    ControlID="cover" />
 <asp:PostBackTrigger ControlID="save" />
 </Triggers>
    </asp:UpdatePanel>     <!-- <asp:AsyncPostBackTrigger ControlID="save"  />-->
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="conditional" ChildrenAsTriggers="true">
     <ContentTemplate>
              <div style="height:35px; vertical-align:middle;text-align:center;" > 
    <table border="0" cellspacing="0" cellpadding="0" width="100%" style="text-align:center; vertical-align:middle;">
    	<tr style="height:25px;">
    		<td style="text-align:center; vertical-align:middle;">对外交流参与人员学号
            <asp:textbox  id="txtbox_participatorId" runat="server"></asp:textbox>
                <asp:TextBoxWatermarkExtender ID="tbwExd_participatorId" 
                TargetControlID="txtbox_participatorId" WatermarkText="请输入学号" WatermarkCssClass="Watermark" runat="server">
                </asp:TextBoxWatermarkExtender>
                <asp:RequiredFieldValidator ID="rf_participatorId" runat="server" 
                 ControlToValidate="txtbox_participatorId" Display="None" ErrorMessage="学号不能为空！" ValidationGroup="participatorIdNotNull"></asp:RequiredFieldValidator>
                <asp:ValidatorCalloutExtender ID="vcExd_participatorId" runat="server" TargetControlID="rf_participatorId" HighlightCssClass="Validator">
                </asp:ValidatorCalloutExtender>
             <asp:button ID="btn_add" Text="添加" runat="server" onclick="btn_add_Click"  ValidationGroup="participatorIdNotNull"/>
             </td>

    	</tr>
    </table>
 </div >
 <div><table  style="width:878px; border:1px double #479ac7;"><tr style="border:1px double #9be8cc;"><td>
               <asp:GridView ID="gvw_dwjlActFillIn" runat="server"  AutoGenerateColumns="False" 
        CellPadding="4"  ForeColor="#333333" 
         style="text-align:center; vertical-align:middle;" PageSize="50" Width="98%"
            HeaderStyle-CssClass="table_title"
                                    CssClass = "table-box"
                                    HeaderStyle-HorizontalAlign="Center"    
                                    cellspacing="1"
                                    BorderWidth="0px"
                                    BackColor="White"
                                    RowStyle-HorizontalAlign="Center"     
                                    RowStyle-Height="28px"
                                    RowStyle-CssClass="row" 
                                    AlternatingRowStyle-CssClass="row1"  DataKeyNames="participatorId"
        GridLines="None"  AllowSorting="True" AllowPaging="True" 
        onpageindexchanged="gvw_dwjlActFillIn_PageIndexChanged" 
        onpageindexchanging="gvw_dwjlActFillIn_PageIndexChanging" 
        onrowdatabound="gvw_dwjlActFillIn_RowDataBound" 
        onsorting="gvw_dwjlActFillIn_Sorting" 

        onrowdeleting="gvw_dwjlActFillIn_RowDeleting"  >
        <AlternatingRowStyle BackColor="White" />
        <Columns>
      
          <asp:BoundField HeaderText="序号" ReadOnly="true" HeaderStyle-Width="5px">
              <ItemStyle HorizontalAlign="Center" />
              <HeaderStyle HorizontalAlign="Center" Width="5%" />
          </asp:BoundField>
            <asp:BoundField DataField="participatorId" HeaderText="学号"  ReadOnly="true"
                SortExpression="participatorId" >
            </asp:BoundField>
            <asp:BoundField DataField="participatorName" HeaderText="姓名"  
                SortExpression="participatorName" >

            </asp:BoundField>
            <asp:BoundField DataField="participatorGender" HeaderText="性别"
                SortExpression="participatorGender" >
            </asp:BoundField>
           
            <asp:BoundField DataField="fillDate" HeaderText="填写时间"  ReadOnly="true"
                SortExpression="fillDate" >
            </asp:BoundField>

            <asp:CommandField HeaderText="删除" 
                HeaderStyle-Width="50px" EditText="删除" ShowDeleteButton="True" >
            <ControlStyle Font-Underline="True" ForeColor="#FF6600" Font-Overline="False" />
            <HeaderStyle Width="50px" />
            </asp:CommandField>

        </Columns>
        <EditRowStyle BackColor="#2461BF" />

        <FooterStyle BackColor="#507CD1" Font-Bold="false" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="false" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="false" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>    </td></tr></table>
 
        </div> 	         
       </ContentTemplate>
        <Triggers>

          <asp:AsyncPostBackTrigger ControlID="btn_add" />
        </Triggers>
     </asp:UpdatePanel>   </div><br />

    <script type="text/javascript" src="/JS/cal.js"></script>
    <script type="text/javascript">
      jQuery(document).ready(function () {
	    var now = new Date ();
        var startYear = now.getFullYear ();//获取四位数年数
		var endYear=startYear+10;
        $('input.two').simpleDatepicker({ startdate:startYear, enddate:endYear}); //定义年的范围，一般用这个
      });
    </script>
<script type="text/javascript" language="javascript" src="/JS/lengthCheck.js"></script>

</asp:Content>
