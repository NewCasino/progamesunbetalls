//±í¸ñ
function addLoadEvent(func) {
  var oldonload = window.onload;
  if (typeof window.onload != 'function') {
    window.onload = func;
  } else {
    window.onload = function() {
      oldonload();
      func();
    }
  }
}

function addClass(element,value) {
  if (!element.className) {
    element.className = value;
  } else {
    newClassName = element.className;
    newClassName+= " ";
    newClassName+= value;
    element.className = newClassName;
  }
}

function removeClassName(oElm, strClassName){
	var oClassToRemove = new RegExp((strClassName + "\s?"), "i");
	oElm.className = oElm.className.replace(oClassToRemove, "").replace(/^\s?|\s?$/g, "");
}


function stripeTables() {
	var tables = document.getElementsByTagName("table");
	for (var m=0; m<tables.length; m++) {
		if (tables[m].className == "pickme") {
			var tbodies = tables[m].getElementsByTagName("tbody");
			for (var i=0; i<tbodies.length; i++) {
				var odd = true;
				var rows = tbodies[i].getElementsByTagName("tr");
				for (var j=0; j<rows.length; j++) {
					if (odd == false) {
						odd = true;
					} else {
						addClass(rows[j],"odd");
						odd = false;
					}
				}
			}
		}
	}
}
function highlightRows() {
  if(!document.getElementsByTagName) return false;
  	var tables = document.getElementsByTagName("table");
	for (var m=0; m<tables.length; m++) {
		if (tables[m].className == "pickme") {
			  var tbodies = tables[m].getElementsByTagName("tbody");
			  for (var j=0; j<tbodies.length; j++) {
				 var rows = tbodies[j].getElementsByTagName("tr");
				 for (var i=0; i<rows.length; i++) {
					   rows[i].oldClassName = rows[i].className
					   rows[i].onmouseover = function() {
						  if( this.className.indexOf("selected") == -1)
							 addClass(this,"highlight");
					   }
					   rows[i].onmouseout = function() {
						  if( this.className.indexOf("selected") == -1)
							 this.className = this.oldClassName
					   }
				 }
			  }
		}
	}
}

function selectRowRadio(row) {
	var radio = row.getElementsByTagName("input")[0];
	radio.checked = true;
}

function removeSelectedStateFromOtherRows() {
	var tables = document.getElementsByTagName("table");
	for (var m=0; m<tables.length; m++) {
		if (tables[m].className == "pickme") {
			var tbodies = tables[m].getElementsByTagName("tbody");
			for (var j=0; j<tbodies.length; j++) {
				var rows = tbodies[j].getElementsByTagName("tr");
				for (var i=0; i<rows.length; i++) {
					if (rows[i].className.indexOf("selected") != -1) {
						removeClassName(rows[i], "selected");
						removeClassName(rows[i], "highlight");
					}
				}
			}
		}
	}
}

function lockRow() {
  	var tables = document.getElementsByTagName("table");
	for (var m=0; m<tables.length; m++) {
		if (tables[m].className == "pickme") {
			var tbodies = tables[m].getElementsByTagName("tbody");
			for (var j=0; j<tbodies.length; j++) {
				var rows = tbodies[j].getElementsByTagName("tr");
				for (var i=0; i<rows.length; i++) {
					rows[i].oldClassName = rows[i].className;
					rows[i].onclick = function() {
						if (this.className.indexOf("selected") != -1) {
							this.className = this.oldClassName;
						} else {
							removeSelectedStateFromOtherRows();
							addClass(this,"selected");
						}
						selectRowRadio(this);
					}
				}
			}
		}
	}
}

addLoadEvent(stripeTables);
addLoadEvent(highlightRows);
addLoadEvent(lockRow);


function lockRowUsingRadio() {
	var tables = document.getElementsByTagName("table");
	for (var m=0; m<tables.length; m++) {
		if (tables[m].className == "pickme") {
			var tbodies = tables[m].getElementsByTagName("tbody");
			for (var j=0; j<tbodies.length; j++) {
				var radios = tbodies[j].getElementsByTagName("input");
				for (var i=0; i<radios.length; i++) {
					radios[i].onclick = function(evt) {
						if (this.parentNode.parentNode.className.indexOf("selected") != -1){
							this.parentNode.parentNode.className = this.parentNode.parentNode.oldClassName;
						} else {
							removeSelectedStateFromOtherRows();
							addClass(this.parentNode.parentNode,"selected");
						}
						if (window.event && !window.event.cancelBubble) {
							window.event.cancelBubble = "true";
						} else {
							evt.stopPropagation();
						}
					}
				}
			}
		}
	}
}
addLoadEvent(lockRowUsingRadio);