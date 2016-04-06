<%@ Page Title="" Language="C#" MasterPageFile="~/Bootstrap/Admin/Main.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="admin.Bootstrap.Admin.Index.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content" class="span10">
	    <!-- content starts -->
			

	    <div>
		    <ul class="breadcrumb">
			    <li>
				    <a href="#">首页</a> <span class="divider">/</span>
			    </li>
			    <li>
				    <a href="#">系统概况</a>
			    </li>
		    </ul>
	    </div>
	    <div class="sortable row-fluid">
		    <a data-rel="tooltip" title="今天新增会员6人" class="well span3 top-block" href="#">
			    <span class="icon32 icon-red icon-user"></span>
			    <div>注册会员</div>
			    <div><span id='_userNumber'></span></div>
			    <span class="notification">6</span>
		    </a>
               
		    <a data-rel="tooltip" title="当天存款 ¥0" class="well span3 top-block" href="#">
			    <span class="icon32 icon-color icon-cart"></span>
			    <div>本月存款</div>
			    <div>¥<span id='_bankSavings'></span></div>
			    <span class="notification yellow">¥0</span>
		    </a>
				
             <a data-rel="tooltip" title="当天取款 ¥0" class="well span3 top-block" href="#">
			    <span class="icon32 icon-color icon-star-on"></span>
			    <div>本月取款</div>
			    <div>¥<span id='_withdrawals'></span></div>
			    <span class="notification green">¥0</span>
		    </a>

		    <a data-rel="tooltip" title="今天站内信息2" class="well span3 top-block" href="#">
			    <span class="icon32 icon-color icon-envelope-closed"></span>
			    <div>本月站内信息</div>
			    <div><span id='_message'>56</span></div>
			    <span class="notification red">2</span>
		    </a>
	    </div>
			
	   	<div class="row-fluid sortable">
				
				<div class="box">
					<div class="box-header well">
						<h2><i class="icon-list-alt"></i> 今年各数据趋势图</h2>
						<div class="box-icon">							
							<a href="#" class="btn btn-minimize btn-round"><i class="icon-chevron-up"></i></a>
							<a href="#" class="btn btn-close btn-round"><i class="icon-remove"></i></a>
						</div>
					</div>
					<div class="box-content">
						<div id="sincos"  class="center" style="height:300px" ></div>
						<p id="hoverdata">移动坐标在： (<span id="x">0</span>, <span id="y">0</span>). <span id="clickdata"></span></p>
					</div>
                  
				</div>
				
			 

			</div><!--/row-->
					
		  
	    </div><!--/row-->
       
			  
    <script language="javascript" type="text/JavaScript">
        (function () {

            var Getdata = function () {
                var data = "",
                    url = "/ServicesFile/UserService.asmx/UserStatistics";

                $.AjaxCommon(url, data, true, false, function (json) {
                    if (json.d == "-1") {
                        SysLoginOut();
                    } else {
                        var re = $.parseJSON(json.d);
                        var easy = -re.dd;
                        var ptsy = -re.gg;
                        $('#_userNumber').html(re.a);
                        $('#_bankSavings').html(re.e);
                        $('#_withdrawals').html(re.g);
                        

                    }
                });
            };

            Getdata();
        })();
    </script>        
</asp:Content>
