$(document).ready(function () {

});

function OpenLoginDialog() {
    $("#divLogin").dialog({
        appendTo: "#divSurveyMainPage",
        modal: true,
        dialogClass: "no-close",
        width: 650,
        height: 400,
        title: "Login Please",
        show: { effect: "size", duration: 800 },
        hide: { effect: "clip", duration: 800 },
        closeOnEscape: false
    }).css('z-index', '1005');
    return false;
}


function OpenLoginDialogFast() {
    $("#divLogin").dialog({
        appendTo: "#divSurveyMainPage",
        modal: true,
        dialogClass: "no-close",
        width: 650,
        height: 400,
        title: "Login Please",
        hide: { effect: "clip", duration: 800 },
        closeOnEscape: false,
    }).css('z-index', '1005');
    return false;
}
