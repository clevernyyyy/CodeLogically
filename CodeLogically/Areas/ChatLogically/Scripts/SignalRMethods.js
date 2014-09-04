
//Constructors.
$(function () {
    // Declare a proxy to reference the hub. 
    var chatHub = $.connection.chatHub;
    // Start Hub
    $.connection.hub.start().done(function () {
        SetClientMethods();
    });

});

//Add the active users list
function RegisterNewClient() {

    var chatHub = $.connection.chatHub;
    $.connection.hub.stateChanged(function (change) {
        if ($.signalR.connectionState["connected"] === change.newState) {

        } else {
            $.connection.hub.start().done(function () {
                SetClientMethods();
            });
        }
    });
}

//Table of the server to be applied to the list if user.length > 0
function OnAuth(user) {
    $.connection.hub.start().done(function () {
        var chatHub = $.connection.chatHub;
        SetClientMethods();
        chatHub.server.addPersonToGroup(user);
    });

}

//Table of the server to be removed from the list
function OnSignOut() {
    //location = '';
        var chatHub = $.connection.chatHub;
        SetClientMethods();
        chatHub.server.removePersonFromGroup();
}

//Registers callback functions no Hub
function SetClientMethods() {
    var Hubs = $.connection.chatHub;

    //All the news
    Hubs.client.sendToGlobal = function (username, msg) {
        var generalChatBox = $('#GlobalMessages');
        var message = '<div class="GlobMsg"> <b>' + username + '</b>: ' + msg + '</div>';
        generalChatBox.append(message);
        generalChatBox.scrollTop(9999999999999999);
    }

    //When you receive a private message
    Hubs.client.sendPrivateMessage = function (partnerId, sender, msg) {
        //Open the dialog window if still open
        CallPrivateMessageDialog(partnerId);
        var chatMessages = $('#' + partnerId + '_msgContent');
        var message = '<div class=""> <b>' + sender + '</b>: ' + msg + '</div>';
        chatMessages.append(message);
        chatMessages.scrollTop(9999999999999999);
    }

    //Error logs
    Hubs.client.sendErrorMessage = function (user, msg) {
        var message = '<div class="GlobMsg" style="Color:Red">' + user + ': ' + msg + '</div>';
        $('#GlobalMessages').append(message);
        $('#GlobalMessages').scrollTop(9999999999999999);
    }

    //All the news that has come a new user
    Hubs.client.onConnection = function (allUsers) {

        var userList = $('#ActiveUserCount');
        userList.empty();
        for (i = 0; i < allUsers.length; i++) {
            var users = '<a href="#"><div onmousedown="javascript:CallPrivateMessageDialog(this.id)" class="ActiveUser" id="'
                + allUsers[i].Connection + '">' + allUsers[i].Name + '</div></a>';
            userList.append(users);
        }
    }

    //offline user
    Hubs.client.onDisconnection = function (connId, userName) {
        $('#' + connId).remove();
    }

    //Error notification
    Hubs.client.sendErrorAlert = function (message) {
        ShowErrorWindows(message);
    }
}

//Global news for all
function SendGlobalMessage(message) {
    if (message.val().length > 0) {
        var Hubs = $.connection.chatHub;
        Hubs.server.globalMessages(message.val());
        message.val("");
        message.focus();
    }
}

//private Message
function SendPrivateMessageToServer(msgVal, toConnId) {
    var Hubs = $.connection.chatHub;
    Hubs.server.sendPrivateMessage(msgVal, toConnId);
}

//ATV dialogue
//Item - Elements Id which is connId;
function CallPrivateMessageDialog(item) {
    var msgDialog = $('#' + item + '_dialog');
    //Open a new modal window
    if (msgDialog.length == 0) {
        ShowWaitScreen();

        $.ajax({
            url: 'Home/GetPrivateMessageDialog',
            data: "Id=" + item,
            type: "POST",
            async: false,
            success: function (data) {
                $('#DialogContent').append(data).hide().show('slow');
                $('.DialogTable').draggable();
                RemoveWaitSCreen();
            }
        });
    }
}






