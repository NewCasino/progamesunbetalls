/*
* 必须结合jQuery使用
* url 表示请求地址,datas表示请求的参数格式为(String类型:'字符串',Int类型:20)
* asy 同步请求还是异步请求，true 为同步，false 为异步
* cache 是否缓存页面,true为缓存,false为不缓存
* toSuccess 请求成功的回调函数
* toError 请求失败的回调函数
*/
function AjaxCommon(url,datas,asy,cache,toSuccess,toError){
    jQuery.ajax({
                contentType:"application/json",
                type:"POST",
                dataType:"json",
                url:url,
				cache:cache,
                data:"{"+datas+"}",
                async:asy,
                success:function(json){
                    toSuccess(json);
                }
                ,
                error:function(err){
                    toError(err);
                }
        });
}
function toError(err)
{
    alert("服务器正在维修,请稍后再试...");
	//alert(err.responseText);
}
Date.prototype.format = function(format) {   
             var o = {
              "M+" : this.getMonth()+1, 
              "d+" : this.getDate(),
              "h+" : this.getHours(),  
              "m+" : this.getMinutes(), 
              "s+" : this.getSeconds(), 
              "q+" : Math.floor((this.getMonth()+3)/3), 
              "S" : this.getMilliseconds() 
             }
             if(/(y+)/.test(format)) format = format.replace(RegExp.$1, (this.getFullYear()+"").substr(4 - RegExp.$1.length));
             for(var k in o)
              if(new RegExp("("+ k +")").test(format))
             format = format.replace(RegExp.$1, RegExp.$1.length==1 ? o[k] : ("00"+ o[k]).substr((""+ o[k]).length));
             return format;
            }
function convertDate(d) {
	var ds = eval("\"" + d + "\"");
	var i = ds.substring(6,19);
	var dd = new Date(parseInt(i)); 
	return dd.format("yyyy-MM-dd hh:mm:ss")
}

