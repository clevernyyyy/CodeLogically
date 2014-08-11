
$(document).ready(function () {
    InitSiteJS();
});


function OpenSurveyEditor() {
    $("#divTakeSurvey").dialog({
        appendTo: "#TakeSurveyPage",
        modal: true,
        dialogClass: "no-close",
        width: 950,
        height: 750,
        title: "Survey Editor",
        show: { effect: "size", duration: 800 },
        hide: { effect: "clip", duration: 800 },
        closeOnEscape: false,
    }).css('z-index', '1005');
    return false;
}

$(function () {
    $('.curve').corner();
    $('.bottomCurve').corner('bottom');
    $('.topCurve').corner('top');
});

function InitSiteJS() {
    InitSiteFieldMasking();
}

function InitSiteFieldMasking() {
    //Standard date picker & masking
    $('input[type="text"][id$="Date"],.dateField').datepicker({
        buttonImage: '../img/cal.gif',
        buttonText: "Choose",
        buttonImageOnly: true,
        showOn: 'both',
        changeYear: true,
        changeMonth: true,
        yearRange: 'c-100:c+100'
        //minDate: new Date(), //today
    }).mask("99/99/9999");
}
