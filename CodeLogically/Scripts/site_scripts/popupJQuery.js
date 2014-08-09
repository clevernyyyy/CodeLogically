// JScript File
//SETTING UP OUR POPUP  
//0 means disabled; 1 means enabled;  
var popupStatus = 0;  

//Obsolete! loading popup with jQuery magic!
function loadPopup(strType) {
    document.body.style.cursor = 'default';
    //loads popup only if it is disabled
    if(popupStatus==0){
        $("#background" + strType).css({
            "opacity": "0.7"
        });
        $("#background" + strType).fadeIn("slow");
        $("#popup" + strType).fadeIn("slow");
        popupStatus = 1;
    }
    return false;
}

//Deprecated!
function loadPopupNew(cType) {
    document.body.style.cursor = 'default';

    if ($("#backgroundPopup").length == 0) {
        $('body').prepend('<div id="backgroundPopup" class="backgroundPopup"></div>');
    }

    $("#backgroundPopup").fadeTo("slow",.5);

    $("#popup" + cType).fadeIn("slow");
    return false;
}

//Shiny like bacon grease, new as of 11 19 13
function loadPopupObj(obj, objfocus) {
    document.body.style.cursor = 'default';
    if ($("#backgroundPopup").length == 0) {
        $('body').prepend('<div id="backgroundPopup" class="backgroundPopup"></div>');
    }
    $("#backgroundPopup").fadeTo("slow", .5);
    obj.fadeIn("slow", function () {
        if (objfocus != undefined) {
            $(window).scrollTop(0);
            objfocus.focus();
        }
    });
    return false;
}


function disablePopups() {
    $(".backgroundPopup").fadeOut("slow");
    $("#backgroundPopup").fadeOut("slow");
    $(".popup").fadeOut("slow");
}

//disabling popup with jQuery magic!
function disablePopup(strType){
    //disables popup only if it is enabled
    if(popupStatus==1){
        $("#background" + strType).fadeOut("slow");
        $("#popup" + strType).fadeOut("slow");
        popupStatus = 0;
    }
}

//centering popup
function centerPopup(strType){
//request data for centering
var windowWidth = document.documentElement.clientWidth;
var windowHeight = document.documentElement.clientHeight;
var popupHeight = $("#popup" + strType).height();
var popupWidth = $("#popup" + strType).width();
}

//Using this function instead of the standard javascript alert()
function jqueryAlert(msg, title)
{
  if ((title == null) || (title == ''))
    title = 'Warning';

  $("[id*='_popupAlert_lblPopUpTitle']").text(title);
  msg = msg.replace('\n','<BR>');
  $("[id$='_lblAlertMsg']")[0].innerHTML = msg + '<BR>';

  var popObj = $("[id$='popupAlert_popup']")
  if (popObj.length > 0)
      loadPopupObj(popObj);
  else
    loadPopupNew('Alert');

}

//$(document).ready(function () {

//  PopUp_InitPageFunctions();

//  var prm = Sys.WebForms.PageRequestManager.getInstance();
//  prm.add_endRequest(function () {
//    PopUp_InitPageFunctions();
//  });
//});

function PopUp_InitPageFunctions() { 
  //CLOSING POPUP
    $(".backgroundPopup").click(function () {
        var visiblePopup = null;
        var hidden = $("[id*='" + this.id.replace('backgroundP', 'p') + "_hClickOutAllowed']");
        var lDisable = true;

        if ($(".popup").filter(":visible").css('display') != 'none') {
            visiblePopup = $(".popup").filter(":visible").next("[id*='_hClickOutAllowed']");
        }

        if (visiblePopup != null) {
            if (visiblePopup.val() == "false") {
                lDisable = false;
            }
        }else if (hidden != null) {
            if (hidden.val() == "false") {
                lDisable = false;
            }
        }

        if (lDisable)
            disablePopups();
    });

  //Press Escape event!
    $(document).keypress(function (e) {
        if (e.keyCode == 27) {
            var visiblePopup = null;
            var lDisable = true;

            if ($(".popup").filter(":visible").css('display') != 'none') {
                visiblePopup = $(".popup").filter(":visible").next("[id*='_hClickOutAllowed']");
            }

            if (visiblePopup != null) {
              if (visiblePopup.val() == "false") {
                lDisable = false;
              }
            }

            if (lDisable)
                disablePopups();
        }
    });
}