$(document).ready(function () {

});

function OpenSurveyEditor() {
    $("#divCreateSurvey").dialog({
        appendTo: "#CreateSurveyPage",
        modal: true,
        dialogClass: "no-close",
        width: 650,
        height: 780,
        title: "Survey Editor",
        show: { effect: "size", duration: 800 },
        hide: { effect: "clip", duration: 800 },
        closeOnEscape: false,
//        buttons: {
//            Cancel: function () {
//                $(this).dialog("close");
//            },
//            "Finish Survey": function () {
//                $(this).dialog("close");
//            }
//        },
    }).css('z-index', '1005');
    return false;
}

function OpenSurveyEditorFast() {
    $("#divCreateSurvey").dialog({
        appendTo: "#CreateSurveyPage",
        modal: true,
        dialogClass: "no-close",
        width: 650,
        height: 780,
        title: "Survey Editor",
        hide: { effect: "clip", duration: 800 },
        closeOnEscape: false,
    }).css('z-index', '1005');
    return false;
}


function OpenQuestionTypeDefinitions() {
    $("#divQuestionTypeDefinitions").dialog({
        appendTo: "#QuestionTypeDefinitions",
        modal: true,
        dialogClass: "no-close",
        width: 400,
        height: 600,
        title: "Question Type Definitions",
        show: { effect: "size", duration: 800 },
        hide: { effect: "clip", duration: 800 },
        closeOnEscape: false,
        buttons: {
            OK: function () {
                $(this).dialog("close");
            }
        },
    }).css('z-index', '1005');
    return false;
}