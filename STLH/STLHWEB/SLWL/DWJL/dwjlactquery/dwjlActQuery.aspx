<%@ Page Title="" Language="C#" MasterPageFile="~/MASTER/Main1.Master" AutoEventWireup="true" 
CodeBehind="dwjlActQuery.aspx.cs" Inherits="STLHWEB.SLWL.DWJL.dwjlActQuery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <title>对外交流活动详细信息</title>
     <link href="/CSS/publicStyle.css" type="text/css" rel="Stylesheet" />
 <link href="/CSS/stjsStyle.css" type="text/css" rel="Stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <div><h2 class="title">交流活动详细信息</h2><hr /><br/></div>
        
       <div> 
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
           	  <td class="textBox"><asp:TextBox ID="txtbox_sponsor3" CssClass="box" runat="server"></asp:TextBox></td></tr>

              <tr><td class="text">&nbsp;&nbsp;受邀方</td>
           	  <td class="textBox"><asp:TextBox ID="txtbox_invitee3" CssClass="box" runat="server"></asp:TextBox></td></tr>

              <tr><td class="text">&nbsp;&nbsp;交流活动名称</td>
           	  <td class="textBox"><asp:TextBox ID="txtbox_activityName3" CssClass="box" runat="server"></asp:TextBox></td></tr>

              <tr><td class="text">&nbsp;&nbsp;交流活动时间</td>
           	  <td class="textBox"><asp:TextBox ID="txtbox_activityTime3" CssClass="box" runat="server"></asp:TextBox></td></tr>

              <tr><td class="text">&nbsp;&nbsp;交流活动地点</td>
           	  <td class="textBox"><asp:TextBox ID="txtbox_activityPlace3" CssClass="box" runat="server"></asp:TextBox></td></tr>

              <tr><td class="text">&nbsp;&nbsp;邀请人数</td>
           	  <td class="textBox"><asp:TextBox ID="txtbox_invitedNumber3" CssClass="box" runat="server"></asp:TextBox></td></tr>

               <tr><td class="text">&nbsp;&nbsp;联系人姓名</td>
           	  <td class="textBox"><asp:TextBox ID="txtbox_linkmanName3" CssClass="box" runat="server"></asp:TextBox></td></tr>

              <tr><td class="text">&nbsp;&nbsp;联系人电话</td>
           	  <td class="textBox"><asp:TextBox ID="txtbox_linkmanPhone3" CssClass="box" runat="server"></asp:TextBox></td></tr>
               <tr class="titlet"><th class="align" colspan="2"><span class="align">对外交流人员</span></th></tr></table>

               <table  style="width:878px; border:1px double #479ac7;"><tr style="border:1px double #9be8cc;"><td>
               <asp:GridView ID="gvw_dwjlActDetailQuery" runat="server"  AutoGenerateColumns="False" 
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
        onpageindexchanged="gvw_dwjlActDetailQuery_PageIndexChanged" 
        onpageindexchanging="gvw_dwjlActDetailQuery_PageIndexChanging" 
        onrowdatabound="gvw_dwjlActDetailQuery_RowDataBound" 
        onsorting="gvw_dwjlActDetailQuery_Sorting"  >
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
          <br /><br />
        </div>
</asp:Content>
