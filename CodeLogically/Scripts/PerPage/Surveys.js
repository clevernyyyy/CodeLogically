$(document).ready(function () {

});

function OpenLoginDialog() {
    $("#divLoginOpen").dialog({
        //autoOpen: true,
        //appendTo: "#divSurveyMainPage",
        modal: true,
        dialogClass: "no-close",
        width: 650,
        height: 400,
        title: "Login Please",
        show: { effect: "size", duration: 800   },
        hide: { effect: "clip", duration: 800   },
        closeOnEscape: false
    }).css('z-index', '1005');
    return false;
}

function OpenLoginDialogFast() {
    $("#divLoginOpen").dialog({
        //autoOpen: true,
        modal: true,
        width: 650,
        height: 400,
        title: "Login Please",
        hide: {
            effect: "clip",
            duration: 800
        },
        closeOnEscape: false
    }).css('z-index', '1005');
    return false;
}


function OpenRegister() {
    $("#divRegisterControl").dialog({
        //autoOpen: true,
        modal: true,
        width: 650,
        height: 650,
        title: "Register",
        show: {
            effect: "size",
            duration: 800
        },
        hide: {
            effect: "clip",
            duration: 800
        },
        closeOnEscape: false
    }).css('z-index', '1005');
    return false;
}
