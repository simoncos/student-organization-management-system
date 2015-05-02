<%@ Page Title="" Language="C#" MasterPageFile="~/MASTER/Main1.Master" AutoEventWireup="true" 
CodeBehind="zzglActQuery.aspx.cs" Inherits="STLHWEB.SLWL.ZZGL.zzglActQuery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>赞助活动详细信息查看</title>
<link href="/CSS/stjsStyle.css" type="text/css" rel="Stylesheet" />
<link href="/CSS/publicStyle.css" type="text/css" rel="Stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <div><h2 class="title">赞助活动详细信息</h2><hr /></div>
<div>
 <table  class="contentTable">

            <tr class="pz">
   
            <td style="float:left;">填表人:</td>
            <td  style="float:left;" ><span class="dynamic"><asp:Label ID="lab_positiveListPerson3" runat="server" Text="" ></asp:Label></span></td>
            <td style="float:left;">填表时间:</td>
            <td style="float:left;"><span class="dynamic"><asp:Label ID="lab_positiveListDate3" runat="server" Text="" > </asp:Label></span></td>
            <td style="float:left;">状态:</td>
            <td  style="float:left;"><span class="dynamic"> <asp:Label ID="lab_positiveListState3" runat="server" Text=""  ></asp:Label></span></td>
 
            </tr></table>
            
 
        	<table class="contentTable">
            

            <tr><td class="text">&nbsp;&nbsp;赞助商</td>
           	  <td class="textBox"><asp:TextBox ID="zzActName3" CssClass="box" runat="server">
              </asp:TextBox>
              </td></tr>

            <tr><td class="text">&nbsp;&nbsp;赞助方式</td>                                        
           	  <td class="textBox"><asp:TextBox ID="zzActType3" CssClass="box" runat="server" >
                  </asp:TextBox></td></tr>

            <tr><td class="text">&nbsp;&nbsp;活动场地</td>                                        
           	  <td class="textBox"><asp:TextBox ID="zzActPlace3" CssClass="box" runat="server" >
                  </asp:TextBox></td></tr>

            <tr><td class="text">&nbsp;&nbsp;预约时间段</td>
           	  <td class="textBox"><asp:TextBox ID="zzActTime3" CssClass="box" runat="server">
              </asp:TextBox>
             </td></tr>


            <tr><td class="text">&nbsp;&nbsp;预算金额</td>
           	  <td class="textBox"><asp:TextBox ID="zzActFund3" CssClass="box" runat="server">
              </asp:TextBox>
             </td></tr>

            <tr><td class="text">&nbsp;&nbsp;实际时间</td>
           	  <td class="textBox"><asp:TextBox ID="zzActNowTime3" CssClass="box" runat="server">
              </asp:TextBox>
             </td></tr>

             <tr><td class="text">&nbsp;&nbsp;实际金额</td>
           	  <td class="textBox"><asp:TextBox ID="zzActNowFund3" CssClass="box" runat="server">
              </asp:TextBox>
             </td></tr>

            <tr><td class="text">&nbsp;&nbsp;负责人</td>
           	  <td class="textBox"><asp:TextBox ID="zzActManager3" CssClass="box" runat="server">
              </asp:TextBox>
             </td></tr></table>

             </div>
         <br />
</asp:Content>
