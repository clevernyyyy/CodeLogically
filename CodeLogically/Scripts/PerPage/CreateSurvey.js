$(document).ready(function () {

});

var winH = $(window).height() - 100;

function OpenSurveyEditor() {
    $("#divCreateSurvey").dialog({
        appendTo: "#CreateSurveyPage",
        modal: true,
        //dialogClass: "no-close",
        position: "absolute",
        width: 650,
        height: winH,
        fluid: true,
        title: "Survey Editor",
        show: { effect: "size", duration: 800 },
        hide: { effect: "clip", duration: 800 },
        closeOnEscape: false,
        open: function (event, ui) {
            //$(this).css('overflow', 'hidden'); //this line does the actual hiding
        }
    }).css('z-index', '1005');
    return false;
}


function OpenSurveyEditorFast() {
    $("#divCreateSurvey").dialog({
        appendTo: "#CreateSurveyPage",
        modal: true,
        dialogClass: "no-close",
        width: 650,
        height: winH,
        fluid: true,
        title: "Survey Editor",
        hide: { effect: "clip", duration: 800 },
        closeOnEscape: false,
        open: function (event, ui) {
            $(this).css('overflow', 'hidden'); //this line does the actual hiding
        }
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



// on window resize run function
$(window).resize(function () {
    fluidDialog();
});

// catch dialog if opened within a viewport smaller than the dialog width
$(document).on("dialogopen", ".ui-dialog", function (event, ui) {
    fluidDialog();
});

function fluidDialog() {
    var $visible = $(".ui-dialog:visible");
    // each open dialog
    $visible.each(function () {
        var $this = $(this);
        var dialog = $this.find(".ui-dialog-content").data("ui-dialog");
        // if fluid option == true
        if (dialog.options.fluid) {
            var wWidth = $(window).width();
            // check window width against dialog width
            if (wWidth < (parseInt(dialog.options.maxWidth) + 50)) {
                // keep dialog from filling entire screen
                $this.css("max-width", "90%");
            } else {
                // fix maxWidth bug
                $this.css("max-width", dialog.options.maxWidth + "px");
            }
            //reposition dialog
            dialog.option("position", dialog.options.position);
        }
    });

}