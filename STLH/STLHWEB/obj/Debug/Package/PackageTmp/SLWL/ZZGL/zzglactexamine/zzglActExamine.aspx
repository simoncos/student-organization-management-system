<%@ Page Title="" Language="C#" MasterPageFile="~/MASTER/Main1.Master" AutoEventWireup="true" 
CodeBehind="zzglActExamine.aspx.cs" Inherits="STLHWEB.SLWL.ZZGL.zzglActExamine" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <title>赞助活动审核</title>
 <link href="/CSS/publicStyle.css" type="text/css" rel="Stylesheet" />
<link href="/CSS/stjsStyle.css" type="text/css" rel="Stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
  <div><h2 class="title">赞助活动审核</h2><hr /></div>

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
        
       
        	<table class="contentTable"> <hr /><br />
            

            <tr><td class="text">&nbsp;&nbsp;赞助商</td>
           	  <td class="textBox"><asp:TextBox ID="zzActName2" CssClass="box" runat="server"> </asp:TextBox>
              </td></tr>

            <tr><td class="text">&nbsp;&nbsp;赞助方式</td>                                        
           	  <td class="textBox"><asp:TextBox ID="zzActType2" CssClass="box" runat="server" > </asp:TextBox></td></tr>

            <tr><td class="text">&nbsp;&nbsp;活动场地</td>                                        
           	  <td class="textBox"><asp:TextBox ID="zzActPlace2" CssClass="box" runat="server" > </asp:TextBox></td></tr>

            <tr><td class="text">&nbsp;&nbsp;预约时间段</td>
           	  <td class="textBox"><asp:TextBox ID="zzActTime2" CssClass="box" runat="server"> </asp:TextBox>
             </td></tr>


            <tr><td class="text">&nbsp;&nbsp;预算金额</td>
           	  <td class="textBox"><asp:TextBox ID="zzActFund2" CssClass="box" runat="server"></asp:TextBox>
             </td></tr>

            <tr><td class="text">&nbsp;&nbsp;实际时间</td>
           	  <td class="textBox"><asp:TextBox ID="zzActNowTime2" CssClass="box" runat="server"></asp:TextBox>
             </td></tr>

             <tr>
             <td class="text">&nbsp;&nbsp;实际金额</td>
           	  <td class="textBox"><asp:TextBox ID="zzActNowFund2" CssClass="box" runat="server"></asp:TextBox>
             </td>
             </tr>

            <tr><td class="text">&nbsp;&nbsp;负责人</td>
           	  <td class="textBox"><asp:TextBox ID="zzActManager2" CssClass="box" runat="server"></asp:TextBox>
             </td></tr>

             
         
      </table>
        <div><br/><hr /><br />
             <asp:Button ID="pass" runat="server" Text="结束活动"  
                CssClass="btn" onclick="pass_Click" /><%--onserverclick="pass_Click"--%><%--onclick="pass_Click"--%>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Button ID="cancel" runat="server" Text="取消活动" CssClass="btn" 
                onclick="cancel_Click" />
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Button ID="unPass" runat="server" Text="未通过" CssClass="btn" onclick="unPass_Click" 
                /></div>
                </asp:Content>