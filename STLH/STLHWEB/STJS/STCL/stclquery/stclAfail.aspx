<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="stclAfail.aspx.cs" Inherits="STLHWEB.STJS.STCL.stclAfail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
             <asp:DataList ID="stcl_Afail" runat="server">
             <ItemTemplate>
                 <div>
                     <table>
                         <tr>
                             <td style="text-align:left; font-size:smaller; color:#8e8dc0;">
                                 审核人：<asp:Label ID="lab_checker" style="text-align:left;" runat="server"><%# DataBinder.Eval(Container.DataItem, "opiniorName")%></asp:Label>
                                 &nbsp;&nbsp;
                                 审核时间：<asp:Label ID="lab_checktime" style=" text-align:left;" runat="server"><%# DataBinder.Eval(Container.DataItem, "opinionDate")%></asp:Label>
                             </td>
                         </tr>
                         <tr>
                             <td style="text-align:left;border:1px solid #8e8dc0;width:870px;">
                                 <asp:Label ID="lab_amendments" runat="server" CssClass="sugtextfied"><%# DataBinder.Eval(Container.DataItem, "amendments")%></asp:Label>
                             </td>
                         </tr>
                         <tr><td style="height:15px;"></td></tr>
                     </table>
                 </div>
             </ItemTemplate>
    </asp:DataList>
    </div>
    </form>
</body>
</html>
