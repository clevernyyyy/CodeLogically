
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
        <input type="hidden" id="nick" />
        @*<div id="dialog" title="Enter your name to start a chat.">
            <input type="text" id="nick" />
        </div>*@
    </div>


@*<h2>Chat Application</h2>
<div class="container">
    <input type="text" id="message" />
    <input type="button" id="sendmessage" value="Send" />
    <input type="hidden" id="displayname" />
    <ul id="discussion"></ul>
</div>*@


@section scripts
    <script src="~/Scripts/jquery-1.6.4.js"></script>
    <script src="~/Scripts/jquery-ui-1.11.1.min.js"></script>
    <script src="~/Scripts/jquery.signalR-2.1.1.js"></script>
    <script type="text/javascript" src="/signalr/hubs"></script>

    <script type="text/javascript">
        //$(function () {

        //    var chat = $.connection.chatHub;
        //    // Create a function that the hub can call back to display messages.
        //    chat.client.addNewMessageToPage = function (name, message) {
        //        // Add the message to the page. 
        //        $('#discussion').append('<li><strong>' + htmlEncode(name)
        //            + '</strong>: ' + htmlEncode(message) + '</li>');
        //    };
        //    // Get the user name and store it to prepend to messages.
        //    $('#displayname').val(prompt('Enter your name:', ''));
        //    // Set initial focus to message input box.
        //    $('#message').focus();
        //    // Start the connection.
        //    $.connection.hub.start().done(function () {
        //        $('#sendmessage').click(function () {
        //            // Call the Send method on the hub. 
        //            chat.server.send($('#displayname').val(), $('#message').val());
        //            // Clear text box and reset focus for next comment. 
        //            $('#message').val('').focus();
        //        });
        //    });
        //});
        //// This optional function html-encodes messages for display in the page.
        //function htmlEncode(value) {
        //    var encodedValue = $('<div />').text(value).html();
        //    return encodedValue;
        //}



        $(function () {
            showModalUserNickName();
        });

        function showModalUserNickName() {


            //$("#dialog").dialog({
            //    modal: true,
            //    //dialogClass: "no-close",
            //    position: "absolute",
            //    width: 650,
            //    height: 400,
            //    fluid: true,
            //    //buttons: [{
            //    //   text: "Ok", click: function () {
            //    //        $(this).dialog("close");
            //    //        startChatHub();
            //    //    }
            //    //}],
            //    closeOnEscape: false
            // }).css('z-index', '1005');
            ////return false;


            // Get the user name and store it to prepend to messages.
            $('#nick').val(prompt('Enter your name:', ''));
            startChatHub();
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
                message = message.replace(":)", "<img src=\"../../../../img/smile.gif\" class=\"smileys\" />");
                message = message.replace(":D", "<img src=\"../../../../img/laugh.gif\" class=\"smileys\" />");
                message = message.replace(":o", "<img src=\"../../../../img/cool.gif\" class=\"smileys\" />");

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