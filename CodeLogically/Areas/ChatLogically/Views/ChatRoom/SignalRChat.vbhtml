﻿@section scripts
    <script type="text/javascript" src="~/Scripts/site_scripts/jquery-ui-1.10.4.custom.min.js" ></script>
    <script type="text/javascript" src="~/Scripts/jquery.signalR-2.1.1.js"></script>
    <script type="text/javascript" src="/signalr/hubs"></script>

    <script type="text/javascript">
        $(function () {
            showModalUserNickName();
        });

        function showModalUserNickName() {
            $("#dialog").dialog({
                modal: true,
                buttons: {
                    Ok: function () {
                        $(this).dialog("close");
                        startChatHub();
                    }
                }
            });
        }

        function startChatHub() {
            var chat = $.connection.chatHub;

            // Get the user name.
            $('#nickname').val($('#nick').val());
            chat.client.differentName = function (name) {
                showModalUserNickName();
                return false;
                // Prompts for different user name
                $('#nickname').val($('#nick').val());
                chat.server.notify($('#nickname').val(), $.connection.hub.id);
            };

            chat.client.online = function (name) {
                // Update list of users
                if (name == $('#nickname').val())
                    $('#onlineusers').append('<div class="border" style="color:green">You: ' + name + '</div>');
                else {
                    $('#onlineusers').append('<div class="border">' + name + '</div>');
                    $("#users").append('<option value="' + name + '">' + name + '</option>');
                }
            };

            chat.client.enters = function (name) {
                $('#chatlog').append('<div style="font-style:italic;"><i>' + name + ' joins the conversation</i></div>');
                $("#users").append('<option value="' + name + '">' + name + '</option>');
                $('#onlineusers').append('<div class="border">' + name + '</div>');
            };
            // Create a function that the hub can call to broadcast chat messages.
            chat.client.broadcastMessage = function (name, message) {
                //Interpret smileys
                message = message.replace(":)", "<img src=\"/images/smile.gif\" class=\"smileys\" />");
                message = message.replace(":D", "<img src=\"/images/laugh.gif\" class=\"smileys\" />");
                message = message.replace(":o", "<img src=\"/images/cool.gif\" class=\"smileys\" />");

                //display the message
                $('#chatlog').append('<div class="border"><span style="color:orange">' + name + '</span>: ' + message + '</div>');
            };

            chat.client.disconnected = function (name) {
                //Calls when someone leaves the page
                $('#chatlog').append('<div style="font-style:italic;"><i>' + name + ' leaves the conversation</i></div>');
                $('#onlineusers div').remove(":contains('" + name + "')");
                $("#users option").remove(":contains('" + name + "')");
            }

            // Start the connection.
            $.connection.hub.start().done(function () {
                //Calls the notify method of the server
                chat.server.notify($('#nickname').val(), $.connection.hub.id);

                $('#btnsend').click(function () {
                    if ($("#users").val() == "All") {
                        // Call the Send method on the hub.
                        chat.server.send($('#nickname').val(), $('#message').val());
                    }
                    else {
                        chat.server.sendToSpecific($('#nickname').val(), $('#message').val(), $("#users").val());
                    }
                    // Clear text box and reset focus for next comment.
                    $('#message').val('').focus();
                });
            });
        }
    </script>
end section
<h2>SignalRChat</h2>

<div id="container">
    <input type="hidden" id="nickname" />
    <div id="chatlog"></div>
    <div id="onlineusers">
        <b>Online Users</b>
    </div>
    <div id="chatarea">
        <div class="messagelog">
            <textarea spellcheck="true" id="message" class="messagebox"></textarea>
        </div>
        <div class="actionpane">
            <input type="button" id="btnsend" value="Send" />
        </div>
        <div class="actionpane">
            <select id="users">
                <option value="All">All</option>
            </select>
        </div>
    </div>
    <div id="dialog" title="Enter your name to start a chat.">
        <input type="text" id="nick" />
    </div>
</div>
