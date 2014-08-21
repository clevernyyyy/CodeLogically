// JavaScript Document

function showAsPopup(content, buttonName, buttonWidth) {
    buttonName = buttonName || "OK";
    buttonWidth = buttonWidth || "80px";
    var fadeTime = 500;
    var fadeTo = .7;

    $("<div />") //Create popup BG
        .addClass("popupWindowBG") //Add the appropriate class
        .css("width", $(document).width()) //Fill sentire doc
        .css("height", $(document).height()) //Fill entire doc
        .fadeTo(fadeTime, fadeTo) //Fade up to set opacity
        .click(function () { closeAsPopup($(this).next(), fadeTime); })
    .insertBefore($(content)); //Add to document
    
     //Create close button
    $("<div class='popupWindowCloseButton'>x</div>")
        .click(function() { closeAsPopup($(this).parent(), fadeTime); })
    .appendTo($(content));
    
    //Create OK button
    $("<div class='popupButtonHolder' style='margin: auto; margin-top: 10px; width: " + buttonWidth + ";'></div>")
        .append("<a class='greenbuttonLink'><span class='greenbutton buttonText' style='width: " + buttonWidth +";'>" + buttonName +"</span></a>")
        .corner("5px")
        .click(function() { closeAsPopup($(this).parent(), fadeTime); })
    .appendTo($(content));
    
    fixGreenButtonOldIE();
    
    $(content)
        .addClass("popUpWindow")
        .css("marginLeft", - $(content).innerWidth() / 2)
        .css("marginTop", - $(content).innerHeight() / 2)
        .fadeIn(fadeTime); //Fade in
}  

function closeAsPopup(content, fadeTime) {
    $(content).prev().fadeOut(fadeTime); //Fade out background
    $(content).fadeOut(fadeTime,function() { //Fade out content
        $(content).removeClass("popUpWindow") //Remove class
        $(content).find(".popupWindowCloseButton").remove(); //Remove close X
        $(content).find(".popupButtonHolder").remove(); //Remove close button
    });
}
	
function MM_swapImgRestore() { //v3.0
  var i,x,a=document.MM_sr; for(i=0;a&&i<a.length&&(x=a[i])&&x.oSrc;i++) x.src=x.oSrc;
}
function MM_preloadImages() { //v3.0
  var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
    var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
    if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}

function MM_findObj(n, d) { //v4.01
  var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
    d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
  if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
  for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
  if(!x && d.getElementById) x=d.getElementById(n); return x;
}

function openBrWindow(theURL,winName,features) { //v2.0
  window.open(theURL,winName,features);
}

function changeReportClaim(){		
	document.getElementById('home_reportclaim_button').style.display='none';
	document.getElementById('claims_contactus').style.display='';
		
	//change manage policy
	document.getElementById('home_managepolicy_button').style.display='';
	document.getElementById('home_managepolicy').style.display='none';
		
	//change business partner
	document.getElementById('home_buspartner_button').style.display='';
	document.getElementById('homebuspartner').style.display='none';
}

function changeBusPartner(){		
    document.getElementById('home_buspartner_button').style.display='none';
    document.getElementById('home_buspartner').style.display='';
    
    //change manage policy
    document.getElementById('home_managepolicy_button').style.display='';
    document.getElementById('home_managepolicy').style.display='none';
    
    //change report claim
    document.getElementById('home_reportclaim_button').style.display='';
    document.getElementById('claims_contactus').style.display='none';
}

function changeManagePolicy(){		
    document.getElementById('home_managepolicy_button').style.display='none';
    document.getElementById('home_managepolicy').style.display='';
    
    //change report claim
    document.getElementById('home_reportclaim_button').style.display='';
    document.getElementById('claims_contactus').style.display='none';
    
    //change business partner
    document.getElementById('home_buspartner_button').style.display='';
    document.getElementById('home_buspartner').style.display='none';

}

function changeFindAgent(){		
    document.getElementById('home_getaquote_exp').style.display='';
    document.getElementById('home_getaquote').style.display='none';
    
}

function hideBoxes() {
    	
    //on load -- should start with Manage Your Policy expanded
    document.getElementById('claims_contactus').style.display='none';
    document.getElementById('home_buspartner').style.display='none';
    document.getElementById('home_managepolicy_button').style.display='none';
    
    //expand Business Partners instead
    //document.getElementById('home_buspartner_button').style.display='none';
    //document.getElementById('home_managepolicy').style.display='none';
    
    //should start with Find An Agent hidden
    document.getElementById('home_getaquote_exp').style.display='none';
   
}

function findAgent() {
		
	//should start with Find An Agent hidden
	document.getElementById('home_getaquote_exp').style.display='none';

}


function hideJobs() {
    $("[id^='jobdetail']").hide();
}

function showJobs(boxVal) {
    var row = $("[id='jobdetail" + boxVal + "']");
  
  if (row.is(':visible')) {
      row.hide();
  }
  else {
    hideJobs();
    row.show();
    _gaq.push(['_trackEvent', 'Current Openings', boxVal]);
  }
}

function GAQEvent(category, action) {
    _gaq.push(['_trackEvent', category, action]);
}

function findAgent_ZipEntered(txtZip,txtCity,ddlState)
{
    if (txtZip.value != '')
    {
        txtCity.value = '';
        ddlState.selectedIndex = 0;
    }
}
function findAgent_StateEntered(txtZip,txtCity,ddlState)
{
    if ((ddlState.value != '') || (txtCity.value != ''))
        txtZip.value = '';
}

function isNumberKey(evt)
{
 var charCode = (evt.which) ? evt.which : event.keyCode
 return isNumber(charCode);
}

function isNumber(charCode)
{
if ((charCode == 9) || (charCode == 36) || (charCode == 35)) //tab, home, end
  return true;
if (charCode > 31 && (charCode < 48 || charCode > 57) && 
  (charCode < 96 || charCode > 105) && charCode != 46 && (charCode < 37 || charCode > 40))
    return false;
return true;
}

/***** PHONE VALIDATION FUNCTIONS *****/
//USED IN POLICY SERVICES TAB, BILLING TAB, AND BIND TAB
function isNumberKey_Phone(evt, txtPhone) {
    var charCode = (evt.which) ? evt.which : event.keyCode;
    if (isNumber(charCode) == false)
        return false;
    else {
        // a number key may be pressed, but if the shift key is also pressed, it's not a number
        if (evt.shiftKey && (charCode != 9))
            return false;

        //Allow backspace, left/right arrow, delete, home and end keys to function normally
        if ((charCode != 8) && (charCode != 37) && (charCode != 39) && (charCode != 46) && (charCode != 36) && (charCode != 35)) {
            ValidatePhone(txtPhone);
        }
        return true;
    }
}