
//Enclose all JS within this namespace
var shengbo = shengbo || {}; 

(function($) {
  /*
   * Breadcrumbs
   */
	shengbo.Carousel = {
    
		init: function() {
		  this.attachCarouselEvents();
		},
		
		attachCarouselEvents: function() {
			shengbo.Carousel.activateCarousels();
		},
		
		activateCarousels: function() {
		  this.activateHeroshot();
		},
		
		activateHeroshot: function() {
		  $('#heroshot').carouselb88({
			horizontalNav: true,
			horizontalNavDisplay: 'hidden',
			bulletNav: true,
			autoPlay: 'on',
			duration: 12
		  });
		  
		  //Add class cav to show left/right navigation arrows in the carousel.
		  $('#heroshot').children('div').addClass('cav');      
		}
	}
  
	//$(document).ready(function() { 
	// shengbo.Carousel.init();
	// });  

}(jQuery));

//Enclose all JS within this namespace
var shengbo = shengbo || {}; 
(function($) {
	/**
	* Utilities
	*/
	shengbo.utils = {
		init: function() {
			var width = $(document.body).width();
			var W2 =(width-1000)/2+150;
			$(".logo").css("width",W2);
		},
		slideUpBtn: function() {
			$("#main-nav li").hover(function() {
				$(this).find("img").stop().animate({bottom:"0"},{queue:false, duration:150});
			}, function() {
				$(this).find("img").stop().animate({bottom:"-265px"},{queue:false, duration:100});
			});
		},
		addImgHover: function(cls) {
			$(cls).css("opacity","1").hover(
				function(){
				   $(this).stop().animate({'opacity': 0.6}, 350);
				}, function(){
				   $(this).stop().animate({'opacity': 1}, 350);
				}
			);

		},
		addImgResize: function() {
			$(window).resize(function() {
				var width = $(document.body).width();
				var W2 =(width-1000)/2+150;
				$(".logo").css("width",W2);
			});
		}
		
	};
	shengbo.utils.init();
	shengbo.utils.slideUpBtn();
	shengbo.utils.addImgResize();
			
}(jQuery));

// 設為首頁
function setFirst(sURL) {
	try {
		document.body.style.behavior = 'url(#default#homepage)';  
		document.body.setHomePage(sURL);  
	} catch(e) {
		if (window.netscape) {
			try {
				netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect");
			} catch(e) {
				alert("抱歉，此操作被浏览器拒绝！\n\r请在浏览器地址栏输入“about:config”并回车\n\r然后将 [signed.applets.codebase_principal_support]的值设置为'true',双击即可。");
			}
		} else {
			alert("抱歉，您的浏览器不支持，请按照下面步骤操作：\n\r1.打开浏览器设置。\n\r2.点击设置网页。\n\r3.输入：" + sURL + "点击确定。");
		}
	}
}
// 加入最愛
function bookMarksite(sURL, sTitle) {
	try {
		window.external.addFavorite(sURL, sTitle);
	} catch(e) {
		try {
			window.sidebar.addPanel(sTitle, sURL, "");
		} catch(e) {
			alert("抱歉，您所使用的浏览器无法完成此操作。\n\r加入收藏失败，请使用Ctrl+D进行添加");
		}
	}
}
function cancelMouse() {
    return false
}

document.oncontextmenu = cancelMouse;

function mover(A) {
    A.style.backgroundPosition = "0 bottom"
}
function mout(A) {
    A.style.backgroundPosition = "0 top"
}
function MM_openBrWindow(C, B, A) {
    window.open(C, B, A)
}
function subWin(A) {
    window.open(A, "gameOpen", "width=1024,height=768")
}
function subWinRule(A) {
    window.open(A, "gameOpenRule", "width=1024,height=768,scrollbars=yes")
};
function winOpen(url,width,height,left,top,name)
{
	var temp = "menubar=no,toolbar=no,directories=no,scrollbars=yes,resizable=no,location=no";
	if (parseInt(width)>0) {
	temp += ',width=' + width;
	} else {
	width = window.screen.availWidth;
	}
	if (parseInt(height)>0) {
	temp += ',height=' + height;
	} else {
	height = window.screen.availHeight;
	}
	if (parseInt(left)>0) {
	temp += ',left=' + left;
	} else {
	temp += ',left='
	+ Math.round((window.screen.availWidth - parseInt(width)) / 2);
	}
	if (parseInt(top)>0) {
	temp += ',top=' + top;
	} else {
	temp += ',top='
	+ Math.round((window.screen.availHeight - parseInt(height)) / 2);
	}
	if(typeof(name)=="undefined"){
		name="";
	}
	if(name=="game")
	{
		//alert(temp);
		var obj=window.open (url,name,temp);
		obj.moveTo(0,0);
		obj.resizeTo(window.screen.availWidth,window.screen.availHeight);	
		//window.setTimeout("obj.document.location=url",3000);
	}
	else{
		window.open (url,name,temp);
	}
}