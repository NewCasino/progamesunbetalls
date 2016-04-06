var select;

function selectAll(check) {

    if (check) {

        select = true;

    } else {

        select = false;

    }

}

function checkAll(checkboxName) {

    var elements = document.getElementsByName(checkboxName);

    var temp = document.getElementById("all");

    var sss = new Array();

    for (var i = 0; i < elements.length; i++) {

        if (elements[i].checked == true) {

            sss[i] = 1;

        } else

            sss[i] = 0;

    }

    if (select) {

        temp.checked = true;

        for (var i = 0; i < elements.length; i++) {

            elements[i].checked = true;

        }

    } else {

        temp.checked = false;

        for (var i = 0; i < elements.length; i++) {

            if (sss[i] == 1)

                elements[i].checked = false;

            else

                elements[i].checked = true;

        }

    }

} 
