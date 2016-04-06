function open2()
{
	var diag = new Dialog();
	diag.Width = 500;
	diag.Height = 180;
	//diag.Title = "激活账户";
	diag.URL = "suncity-13-1.html";
	diag.show();
}

function pww()
{
	var diag = new Dialog();
	diag.Width = 500;
	diag.Height = 180;
	//diag.Title = "激活账户";
	diag.URL = "suncity-71-1.html";
	diag.show();
}
function can()
{
	var diag = new Dialog();
	diag.Width = 500;
	diag.Height = 180;
	//diag.Title = "激活账户";
	diag.URL = "suncity-67-1.html";
	diag.show();
}
function login()
{
	var diag = new Dialog();
	diag.Width = 600;
	diag.Height = 340;
	//diag.Title = "激活账户";
	diag.URL = "index.html";
	diag.show();
}

function video()
{
	var diag = new Dialog();
	diag.Width = 500;
	diag.Height = 340;
	//diag.Title = "视频";
	diag.URL = "video.html";
	diag.show();
}
function winconfirm(){
    question = confirm("请登录游戏内投注")
    if (question != "0"){
        window.open("http://www.70suncity.com/lobby.aspx?langCd=zh-CN")
    }
}