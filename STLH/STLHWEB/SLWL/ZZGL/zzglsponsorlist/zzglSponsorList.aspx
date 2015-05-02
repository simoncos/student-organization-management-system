<%@ Page Title="" Language="C#" MasterPageFile="~/MASTER/Main1.Master" AutoEventWireup="true" CodeBehind="zzglSponsorList.aspx.cs" Inherits="STLHWEB.SLWL.ZZGL.zzglSponsorList" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>商家信息记录表</title>
 <link href="/CSS/stjsStyle.css" type="text/css" rel="Stylesheet" />
    <link href="/CSS/slwlStyle.css" type="text/css" rel="Stylesheet" />
    <link href="/CSS/publicStyle.css" type="text/css" rel="Stylesheet" />
   
 <style type="text/css">
input[type=text]{
    width: 60px;
     border-radius: 1px;
    }
 .table_titleOwn {
    FONT: 12px Tahoma, Verdana;	
    COLOR: #ffffff;	
    BACKGROUND-COLOR: #804D61;
    HEIGHT: 30px;
    PADDING-LEFT: 5px;
    PADDING-RIGHT:5px;
}
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
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
 <div><h2 class="title">商家信息记录表</h2><hr /></div> 
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>  
        <div><br />
                <table id="tableData" style="width:878px; border:1px double #479ac7;" >
         <tr style="border:1px double #9be8cc; text-align:center; vertical-align:middle;">
             <td  style=" text-align:center; vertical-align:middle;"><%--border:1px  solid #9be8cc;--%>
        <table style="width:100%;  text-align:center; vertical-align:middle;"><%--border:1px double #479ac7;--%>
                    <tr><td>赞助商名称：<asp:TextBox ID="txtbox_sponsorName" runat="server" style="width:250px;border-radius: 3px;"
                    maxlength="20" onpropertychange="checklen(this)"></asp:TextBox><asp:TextBoxWatermarkExtender ID="tbwExd_sponsorName" runat="server" 
TargetControlID="txtbox_sponsorName" WatermarkText="必填" WatermarkCssClass="Watermark"></asp:TextBoxWatermarkExtender>
                        <asp:RequiredFieldValidator ID="rf_sponsorName" runat="server" ControlToValidate="txtbox_sponsorName" Display="None" ErrorMessage="请输入赞助商名称，不超出20 字">
                        </asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="vcExd_sponsorName" runat="server" TargetControlID="rf_sponsorName" HighlightCssClass="Validator">
                        </asp:ValidatorCalloutExtender></td>

                        <td>联系人姓名：<asp:TextBox ID="txtbox_contactName" runat="server" style="width:250px;  border-radius: 3px;"></asp:TextBox></td>
                        </tr>
                    
                    <tr> <td>负责人姓名：<asp:TextBox ID="txtbox_leaderName"  style="width:250px;border-radius: 3px;" runat="server" maxlength="10" onpropertychange="checklen(this)"></asp:TextBox>
                    <asp:TextBoxWatermarkExtender ID="tbwExd_leaderName" runat="server" 
TargetControlID="txtbox_leaderName" WatermarkText="必填" WatermarkCssClass="Watermark"></asp:TextBoxWatermarkExtender>
                        <asp:RequiredFieldValidator ID="rf_leaderName" runat="server" ControlToValidate="txtbox_leaderName" Display="None" ErrorMessage="请输入负责人姓名，不超出20 字">
                        </asp:RequiredFieldValidator>
                        <asp:ValidatorCalloutExtender ID="vcExd_leaderName" runat="server" TargetControlID="rf_leaderName" HighlightCssClass="Validator">
                        </asp:ValidatorCalloutExtender>        </td>
                        <td>联系人电话：<asp:TextBox ID="txtbox_contactTel" runat="server" style="width:250px;border-radius: 3px;" ></asp:TextBox>
                         <asp:RegularExpressionValidator ID="rf_linkmanPhone1" runat="server" 
                         ControlToValidate="txtbox_contactTel" ErrorMessage="电话格式不匹配！" display="None"
                         SetFocusOnError="True" ValidationExpression="((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)"></asp:RegularExpressionValidator>
              <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="rf_linkmanPhone1" HighlightCssClass="Validator">
                        </asp:ValidatorCalloutExtender>
                        
                        </td>
                        
                        </tr>
                        
                  <tr> <td>负责人电话：<asp:TextBox ID="txtbox_leaderTel" style="width:250px;border-radius: 3px;" runat="server"></asp:TextBox>                    <asp:TextBoxWatermarkExtender ID="tbwExd_leaderTel" runat="server" 
TargetControlID="txtbox_leaderTel" WatermarkText="必填" WatermarkCssClass="Watermark"></asp:TextBoxWatermarkExtender>
                        <asp:RequiredFieldValidator ID="rf_leaderTel" runat="server" ControlToValidate="txtbox_leaderTel" Display="None" ErrorMessage="请输入负责人电话">
                        </asp:RequiredFieldValidator>
<asp:RegularExpressionValidator ID="rf_leaderTel2" runat="server" 
                         ControlToValidate="txtbox_leaderTel" ErrorMessage="电话格式不匹配！" display="None"
                         SetFocusOnError="True" ValidationExpression="((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)"></asp:RegularExpressionValidator>
                        <asp:ValidatorCalloutExtender ID="vcExd_leaderTel" runat="server" TargetControlID="rf_leaderTel" HighlightCssClass="Validator">
                        </asp:ValidatorCalloutExtender>  

                        <asp:ValidatorCalloutExtender ID="vcExd_leaderTel2" runat="server" TargetControlID="rf_leaderTel2" HighlightCssClass="Validator">
                        </asp:ValidatorCalloutExtender>  
                         </td>
                    <td>联系人职位：<asp:TextBox ID="txtbox_contactPosition" runat="server" style="width:250px;border-radius: 3px;" ></asp:TextBox></td></tr>

                    <tr> <td>负责人职位：<asp:TextBox ID="txtbox_leaderPosition"  style="width:250px;border-radius: 3px;" runat="server"></asp:TextBox></td>
                      <td>  <asp:button ID="btn_putIn" Text="提交" runat="server" onclick="btn_putIn_Click"/>&nbsp;&nbsp;
                        <asp:button id="btn_clear" text="清除" runat="server" onclick="btn_clear_Click"/></td>
                        
                        </tr>
                    </table>
                </td>
                </tr>  
                </table>
        </div> 
    </ContentTemplate>
    <Triggers>
         <asp:AsyncPostBackTrigger    ControlID="btn_clear" />
    </Triggers>
</asp:UpdatePanel>

<div><p><br /></p>
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>  
<table  style="width:878px; border:1px double #479ac7;"><tr style="border:1px double #9be8cc;"><td>
    <asp:GridView ID="gvw_zzglSponsorList" runat="server"  AutoGenerateColumns="False" 
        CellPadding="4"  ForeColor="#333333" 
         style="text-align:center; vertical-align:middle;" PageSize="50" Width="100%"
          HeaderStyle-CssClass="table_titleOwn"
                                    CssClass = "table-box"
                                    HeaderStyle-HorizontalAlign="Center"    
                                    cellspacing="1"
                                    BorderWidth="0px"
                                    BackColor="White"
                                    RowStyle-HorizontalAlign="Center"     
                                    RowStyle-Height="28px"
                                    RowStyle-CssClass="row" 
                                    AlternatingRowStyle-CssClass="row1"  DataKeyNames="sponsorName"
        GridLines="None"  AllowSorting="True" AllowPaging="True" 
        onpageindexchanged="gvw_zzglSponsorList_PageIndexChanged" 
        onpageindexchanging="gvw_zzglSponsorList_PageIndexChanging" 
        onrowdatabound="gvw_zzglSponsorList_RowDataBound" 
        onsorting="gvw_zzglSponsorList_Sorting" 
        onrowdeleting="gvw_zzglSponsorList_RowDeleting" 
        onrowcancelingedit="gvw_zzglSponsorList_RowCancelingEdit" 
        onrowediting="gvw_zzglSponsorList_RowEditing" 
        onrowupdating="gvw_zzglSponsorList_RowUpdating" >
        <AlternatingRowStyle BackColor="White" />
        <Columns>
      
          <asp:BoundField HeaderText="序号" ReadOnly="true" HeaderStyle-Width="5px">
              <ItemStyle HorizontalAlign="Center" />
              <HeaderStyle HorizontalAlign="Center" Width="5%" />
          </asp:BoundField>
            <asp:BoundField DataField="sponsorName" HeaderText="赞助商名称"  HeaderStyle-Width="120px" ReadOnly="true"
                SortExpression="sponsorName" >
            <HeaderStyle Width="120px" />
            </asp:BoundField>

            <asp:BoundField DataField="leaderName" HeaderText="负责人姓名"  HeaderStyle-Width="80px"
                SortExpression="leaderName" >
            <HeaderStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="leaderPosition" HeaderText="负责人职位"  HeaderStyle-Width="80px"
                SortExpression="leaderPosition" >
            <HeaderStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="leaderTel" HeaderText="负责人电话" HeaderStyle-Width="80px"
                SortExpression="leaderTel" >
            <HeaderStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="contactName" HeaderText="联系人姓名" HeaderStyle-Width="80px"
                SortExpression="contactName" >
            <HeaderStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="contactPosition" HeaderText="联系人职位" HeaderStyle-Width="80px"
                SortExpression="contactPosition" >
            <HeaderStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="contactTel" HeaderText="联系人电话" HeaderStyle-Width="80px"
                SortExpression="contactTel" >
            <HeaderStyle Width="80px" />
            </asp:BoundField>
<%--            <asp:BoundField DataField="fillName" HeaderText="填写人姓名" HeaderStyle-Width="50px"
                SortExpression="fillName" />--%>
            <asp:BoundField DataField="fillDate" HeaderText="填写时间" HeaderStyle-Width="120px" ReadOnly="true"
                SortExpression="fillDate" >
            <HeaderStyle Width="120px" />
            </asp:BoundField>

       <asp:CommandField DeleteText="" HeaderText="编辑" InsertText="" NewText=""  HeaderStyle-Width="70px"
                SelectText="" ShowEditButton="True" >
            <ControlStyle Font-Bold="False" Font-Underline="True" ForeColor="#FF6600" />
            <HeaderStyle Width="70px" />
            </asp:CommandField>
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
    </asp:GridView></td></tr></table>

        </ContentTemplate>
        <Triggers>
         <asp:AsyncPostBackTrigger   ControlID="btn_putIn" />
        </Triggers>
        </asp:UpdatePanel> 
</div>
 <script src="/JS/lengthCheck.js" type="text/javascript" language="javascript"></script>
    </asp:Content>
