$(document).ready(function () {

});

function OpenSurveyEditor() {
    $("#divCreateSurvey").dialog({
        appendTo: "#CreateSurveyPage",
        modal: true,
        dialogClass: "no-close",
        width: 950,
        height: 750,
        title: "Survey Editor",
        show: { effect: "size", duration: 800 },
        closeOnEscape: false,
    }).css('z-index', '1005');
    return false;
}

