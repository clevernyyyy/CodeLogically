$(document).ready(function () {

});

function OpenSurveyEditor() {
    $("#divCreateSurvey").dialog({
        appendTo: "#CreateSurveyPage",
        modal: true,
        dialogClass: "no-close",
        width: 1100,
        height: 750,
        title: "Survey Editor",
        closeOnEscape: false,
    }).css('z-index', '1005');
    return false;
}

