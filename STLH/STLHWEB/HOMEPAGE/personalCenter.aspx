<%@ Page Title="" Language="C#" MasterPageFile="~/MASTER/Main1.Master" AutoEventWireup="true" CodeBehind="personalCenter.aspx.cs" Inherits="STLHWEB.HOMEPAGE.personalCenter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
<div>

<div class="contentmodule">
            <div class="moduletitle">
                <h3>重要通知</h3>
               
                <span >
		        <a href="#">更多 >> </a> 
		        </span>
            </div>
		    <div id="newNotice" class="modulelist">


			</div>
	    </div>
        
        <div class="contentmodule">
            <div class="moduletitle">
                <h3>重要通知</h3>
            
                <span >
		        <a href="#">更多 >> </a> 
		        </span>
            </div>
		    <div class="modulelist">
				<ul>
					<li>
                        <span>[2013-04-09]</span>
                        <a href="#" title="[开题与答辩]2013上半年开题通知">[开题与答辩]2013上</a>
                        <img src='/MASTER/perCenterM/new.gif' border='0' alt=""/>  
					</li>
                    <li>
                        <span>[2013-04-09]</span>
                        <a href="#" title="[开题与答辩]2013上半年开题通知">[开题与答辩]2013上</a>
                        <img src='/MASTER/perCenterM/new.gif' border='0' alt=""/>  
					</li>
                    <li>
                        <span>[2013-04-09]</span>
                        <a href="#" title="[开题与答辩]2013上半年开题通知">[开题与答辩]2013上</a>
                        <img src='/MASTER/perCenterM/new.gif' border='0' alt=""/>  
					</li>
                    <li>
                        <span>[2013-04-09]</span>
                        <a href="#" title="[开题与答辩]2013上半年开题通知">[开题与答辩]2013上</a>
                        <img src='/MASTER/perCenterM/new.gif' border='0' alt=""/>  
					</li>
                    <li>
                        <span>[2013-04-09]</span>
                        <a href="#" title="[开题与答辩]2013上半年开题通知">[开题与答辩]2013上</a>
                        <img src='/MASTER/perCenterM/new.gif' border='0' alt=""/>  
					</li>
				</ul>
			</div>
	    </div>

        </div>
        <script type="text/javascript" language="javascript">
           
            mainLoop = function () {

                var url = "personalCenter.ashx?param=pc";
                $.post(url, function (data) {
                    $("#newNotice").html(data);
                });
                setTimeout('mainLoop()', 10000);
                return true;
            }
            mainLoop();
        </script>

</asp:Content>
