$(document).ready(function () {

});

function OpenSurveyEditor() {
    $("#divCreateSurvey").dialog({
        appendTo: "#CreateSurveyPage",
        modal: true,
        dialogClass: "no-close",
        width: 650,
        height: 680,
        title: "Survey Editor",
        show: { effect: "size", duration: 800 },
        hide: { effect: "clip", duration: 800 },
        closeOnEscape: false
    }).css('z-index', '1005');
    return false;
}


function OpenSurveyEditorFast() {
    $("#divCreateSurvey").dialog({
        appendTo: "#CreateSurveyPage",
        modal: true,
        dialogClass: "no-close",
        width: 650,
        height: 680,
        title: "Survey Editor",
        hide: { effect: "clip", duration: 800 },
        closeOnEscape: false,
    }).css('z-index', '1005');
    return false;
}


function addQuestion() {
    if(true)
        loadNextQuestion();
    else
        loadFail();
}

function loadNextQuestion()
{
    $.ajax({
        type: "POST",
        url: "/AddQuestion.asmx/AddQuestion/",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: loadSuccess(),
        error: fillFail()
    });
}

function loadFail() {
    //alert("failure on load!");
}

function loadSuccess() {
    return function (jqXhr, textStatus) {
        if (textStatus == "success") {
            alert("success!");
        }
    };
}

function fillFail(results) {
    //alert("failure on fill");
}


function OpenSurveyEditorAndHelp() {
    $("#divQuestionTypeDefinitions").dialog({
        //autoOpen: true,
        modal: true,
        width: 400,
        height: 650,
        title: "Question Type Definitions",
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