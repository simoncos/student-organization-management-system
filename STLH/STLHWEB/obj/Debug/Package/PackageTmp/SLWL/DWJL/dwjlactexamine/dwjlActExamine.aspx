<%@ Page Title="" Language="C#" MasterPageFile="~/MASTER/Main1.Master" AutoEventWireup="true" 
CodeBehind="dwjlActExamine.aspx.cs" Inherits="STLHWEB.SLWL.DWJL.dwjlActExamine" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>对外交流活动审核</title>
 <link href="/CSS/publicStyle.css" type="text/css" rel="Stylesheet" />
<link href="/CSS/stjsStyle.css" type="text/css" rel="Stylesheet" />
<link href="/CSS/slwlStyle.css" type="text/css" rel="Stylesheet" />
 <style type="text/css">
 .Watermark
{
    color:#bebebe;
}
.Validator
{
	background-color:#f5f7fb;
}
 </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   <div><h2 class="title">交流活动审核</h2><hr /><br/></div>
        
       <div> 
       <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
       <table  class="contentTable">

            <tr class="pz">
   
            <td style="float:left;">填表人:</td>
            <td  style="float:left;" ><span class="dynamic"><asp:Label ID="lab_positiveListPerson2" runat="server" Text=""></asp:Label></span></td>
            <td style="float:left;">填表时间:</td>
            <td style="float:left;"><span class="dynamic"><asp:Label ID="lab_positiveListDate2" runat="server" Text="" > </asp:Label></span></td>
            <td style="float:left;">状态:</td>
            <td  style="float:left;"><span class="dynamic"> <asp:Label ID="lab_positiveListState2" runat="server" Text=""  ></asp:Label></span></td>
 
            </tr></table>

        	<table class="contentTable">
            
              <tr class="titlet"><th  class="align" colspan="2"><span class="align">基本信息</span></th></tr>
            <tr><td class="text">&nbsp;&nbsp;发起方</td>
           	  <td class="textBox"><asp:TextBox ID="txtbox_sponsor2" CssClass="box" runat="server" ReadOnly="true" style="cursor:not-allowed;"></asp:TextBox></td></tr>

              <tr><td class="text">&nbsp;&nbsp;受邀方</td>
           	  <td class="textBox"><asp:TextBox ID="txtbox_invitee2" CssClass="box" runat="server" ReadOnly="true" style="cursor:not-allowed;"></asp:TextBox></td></tr>

              <tr><td class="text">&nbsp;&nbsp;交流活动名称</td>
           	  <td class="textBox"><asp:TextBox ID="txtbox_activityName2" CssClass="box" runat="server" ReadOnly="true" style="cursor:not-allowed;"></asp:TextBox></td></tr>

              <tr><td class="text">&nbsp;&nbsp;交流活动时间</td>
           	  <td class="textBox"><asp:TextBox ID="txtbox_activityTime2" CssClass="box" runat="server" ReadOnly="true" style="cursor:not-allowed;"></asp:TextBox></td></tr>

              <tr><td class="text">&nbsp;&nbsp;交流活动地点</td>
           	  <td class="textBox"><asp:TextBox ID="txtbox_activityPlace2" CssClass="box" runat="server"></asp:TextBox></td></tr>

              <tr><td class="text">&nbsp;&nbsp;邀请人数</td>
           	  <td class="textBox"><asp:TextBox ID="txtbox_invitedNumber2" CssClass="box" runat="server"></asp:TextBox></td></tr>

               <tr><td class="text">&nbsp;&nbsp;联系人姓名</td>
           	  <td class="textBox"><asp:TextBox ID="txtbox_linkmanName2" CssClass="box" runat="server"></asp:TextBox></td></tr>

              <tr><td class="text">&nbsp;&nbsp;联系人电话</td>
           	  <td class="textBox"><asp:TextBox ID="txtbox_linkmanPhone2" CssClass="box" runat="server"></asp:TextBox></td></tr>

              <tr><td class="text">&nbsp;&nbsp;校内负责人</td>
           	  <td class="textBox"><asp:TextBox ID="txtbox_schoolPrincipal2" CssClass="box" runat="server"></asp:TextBox></td></tr>

              <tr><td class="text">&nbsp;&nbsp;负责人电话</td>
           	  <td class="textBox"><asp:TextBox ID="txtbox_schoolPrincipalPhone2" CssClass="box" runat="server"></asp:TextBox></td></tr>
                            
         <tr align="center"><td colspan="2"><div>
         <br/><hr /><br />
             <asp:Button ID="save" runat="server" Text="保存"  CssClass="btn" 
               onclick="save_Click" />
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Button ID="pass" runat="server" Text="结束活动" CssClass="btn" 
               onclick="pass_Click" />
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Button ID="cancel" runat="server" Text="取消活动" CssClass="btn" 
               onclick="cancel_Click" />
           <br /><br />
         </div></td></tr>
                                <tr class="titlet"><th  class="align" colspan="2"><span class="align">对外交流人员</span></th></tr></table>                       	  
    </ContentTemplate>
 <Triggers>
      <asp:AsyncPostBackTrigger    ControlID="cancel" />
 </Triggers>
    </asp:UpdatePanel>
 		 <asp:UpdatePanel ID="UpdatePanel2" runat="server">
     <ContentTemplate>
              <div style="height:35px; vertical-align:middle;text-align:center;" > 
    <table border="0" cellspacing="0" cellpadding="0" width="100%" style="text-align:center; vertical-align:middle;">
    	<tr style="height:25px;">
    		<td style="text-align:center; vertical-align:bottom;">对外交流参与人员学号
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
               <asp:GridView ID="gvw_dwjlActExamine" runat="server"  AutoGenerateColumns="False" 
        CellPadding="4"  ForeColor="#333333" 
         style="text-align:center; vertical-align:middle;" PageSize="50" Width="100%"
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
        onpageindexchanged="gvw_dwjlActExamine_PageIndexChanged" 
        onpageindexchanging="gvw_dwjlActExamine_PageIndexChanging" 
        onrowdatabound="gvw_dwjlActExamine_RowDataBound" 
        onsorting="gvw_dwjlActExamine_Sorting" 

        onrowdeleting="gvw_dwjlActExamine_RowDeleting"  >
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
          <asp:AsyncPostBackTrigger   ControlID="btn_add" />
        </Triggers>
     </asp:UpdatePanel>   </div><br />
      

       
</asp:Content>
