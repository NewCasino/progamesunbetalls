// JavaScript Document
(function() {
    function showdiv(){
    if($('.m_menu').is(':visible')){
	    $(".m_menu").slideUp();
    }else{
	    $(".m_menu").slideDown();
    }
    }

    function sunbet77(){
	
    return true;
    }

    var left_top = 140, right_top = 140, float_list = [];
	    $(function(){
	    var page = "first";
	    var otherPage = "";
    if( page=="MAdvertis"){
	    if(otherPage == "MemberExclusiveII"){
		    $(".LS-pre").find('a').addClass("over77");
	    }
    }else{
	    $(".LS-" + page).find('a').addClass("over77");
    }	
	
	    // 厅主自改 - 浮动图
    $(".floatDiv").each(function(i){
	    float_list[i] = $(this);
    });
    for (var i in float_list) {
	    var self = float_list[i]; 
		
	    var picfloat = (self.attr('picfloat') == 'right') ? 1 : 0;
	    self.show().Float({'floatRight' : picfloat, 'topSide' : ((picfloat == 1) ? right_top : left_top)});
	    
	    // ie6 png bug
	    if (navigator.userAgent.toLowerCase().indexOf('msie 6') != -1) {
	        $.each(self.find('span'), function(){
	    	    $(this).css({'width':$(this).width(),'height' : $(this).height()});
	        });
	    }
	    
	    if (picfloat) {
	        right_top = right_top + (self.find('a > span').height() || 300);
	    } else {
	        left_top = left_top + (self.find('a > span').height() || 300);
	    }
	    
	    self.find('.floatBox div').click(function() {
	        event.cancelBubble = true;
	        $(this).parent('.floatBox').hide();
	    });
    }	
	    $(".kf-close").click(function() {
		    $(this).parents(".floatDiv").fadeOut(300);
	    });

	    var objOpen = "a[sign='open']";
	    var objClose = "a[sign='close']";
	    $(objClose).find(".img_png").animate({ 
		    height: 'toggle'
			    }, 0 );	
	    $(".kf-top").toggle(
		    function () {
		    $(objOpen).find(".img_png").animate({ 
			    height: 'toggle'
			    }, 200 );		
		    $(objClose).find(".img_png").animate({ 
			    height: 'toggle'
			    }, 200 );	
		    $(this).toggleClass("img-png-l");
		    },
		    function () {
		    $(objOpen).find(".img_png").animate({ 
			    height: 'toggle'
			    }, 200 );		
		    $(objClose).find(".img_png").animate({ 
			    height: 'toggle'
			    }, 200 );
		    $(this).toggleClass("img-png-l");
		    }
	    );	
		
    })
})();