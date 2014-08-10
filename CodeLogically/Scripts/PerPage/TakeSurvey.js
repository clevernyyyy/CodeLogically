$(document).ready(function () {

});

function OpenSurveyEditor() {
    $("#divTakeSurvey").dialog({
        appendTo: "#TakeSurveyPage",
        modal: true,
        dialogClass: "no-close",
        width: 950,
        height: 750,
        title: "Survey Editor",
        closeOnEscape: false,
    }).css('z-index', '1005');
    return false;
}

