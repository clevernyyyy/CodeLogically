
@*<h2>SignalRChat</h2>*@

<div id="container">
    <div class="col-xs-12 col-sm-12">
        <input type="hidden" id="nickname" />
        <div id="chatlog" style="width:400px"></div>
        <div id="onlineusers">
            <b>Online Users</b>
        </div>
        <div id="chatarea">
            <div class="messagelog">
                <textarea spellcheck="true" id="message" class="messagebox" maxlength="400"></textarea>
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
        <input type="hidden" id="nick" maxlength="25" />
    </div>
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

            // Create a function that the hub can call to broadcast chat messages.  (to All)
            chat.client.broadcastMessage = function (name, message) {
                //Interpret smileys
                message = interpretSmileys(message);
              
                //display the message
                $('#chatlog').append('<div class="border"><span style="color:orange">' + name + '</span>: ' + message + '</div>');
            };

            // Create a function that the hub can call to broadcast chat messages.  (to User)
            chat.client.broadcastMessageUser = function (name, message, user) {
                //Interpret smileys
                message = interpretSmileys(message);

                //display the message
                $('#chatlog').append('<div class="border"><span style="color:blue"> @@' + user + '</span>: ' +
                    + '</div>' +
                    '<div class="border"><span style="color:orange">'
                    + name + '</span>: ' + message +
                    '</div>');
            };
            

            chat.client.disconnected = function (name) {
                //Calls when someone leaves the page
                $('#chatlog').append('<div style="font-style:italic;"><i>' + name + ' leaves the conversation</i></div>');
                $('#onlineusers div').remove(":contains('" + name + "')");
                $("#users option").remove(":contains('" + name + "')");
            }


            //$("#message").keypress(function (e) {
            //    if (e.which == 13) {
            //        //submit form via ajax, this is not JS but server side scripting so not showing here
            //        //$("#chatlog").append($(this).val() + "<br/>");
            //        $('#chatlog').append('<div class="border"><span style="color:orange">' + $('#nickname').val() + '</span>: ' + $(this).val() + '</div>');
            //        $(this).val("");
            //        e.preventDefault();
            //    }
            //});

            // Start the connection.
            $.connection.hub.start().done(function () {
                //Calls the notify method of the server
                chat.server.notify($('#nickname').val(), $.connection.hub.id);

                $("#message").keypress(function (e) {
                    if (e.which == 13) {
                        //submit form via ajax, this is not JS but server side scripting so not showing here
                        if ($("#users").val() == "All") {
                            // Call the Send method on the hub.
                            chat.server.send($('#nickname').val(), $('#message').val());
                        }
                        else {
                            chat.server.sendToSpecific($('#nickname').val(), $('#message').val(), $("#users").val());
                        }
                        // Clear text box and reset focus for next comment.
                        var k = jQuery.Event("keyup");
                        k.ctrlKey = false;
                        k.which = 20;

                        $('#message').trigger(k);
                        $('#message').val('').focus();
                    }
                });

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


            function interpretSmileys(message) {
                message = message.replace(":)", "<img src=\"../../../../img/emoticons/smile.png\" class=\"smileys\" />");
                message = message.replace(":D", "<img src=\"../../../../img/emoticons/grin.png\" class=\"smileys\" />");
                message = message.replace(":o", "<img src=\"../../../../img/emoticons/surprised.png\" class=\"smileys\" />");
                message = message.replace("-_-", "<img src=\"../../../../img/emoticons/mad.png\" class=\"smileys\" />");
                message = message.replace(":(", "<img src=\"../../../../img/emoticons/sad.png\" class=\"smileys\" />");
                message = message.replace(":\\", "<img src=\"../../../../img/emoticons/sick.png\" class=\"smileys\" />");
                message = message.replace(":P", "<img src=\"../../../../img/emoticons/tongue.png\" class=\"smileys\" />");
                message = message.replace("8)", "<img src=\"../../../../img/emoticons/sunglasses.png\" class=\"smileys\" />");
                message = message.replace(":)", "<img src=\"../../../../img/emoticons/smile.png\" class=\"smileys\" />");
                message = message.replace("P)", "<img src=\"../../../../img/emoticons/smartass.png\" class=\"smileys\" />");
                message = message.replace(":/", "<img src=\"../../../../img/emoticons/sorry.png\" class=\"smileys\" />");
                message = message.replace(";)", "<img src=\"../../../../img/emoticons/blink.png\" class=\"smileys\" />");
                message = message.replace("<3)", "<img src=\"../../../../img/emoticons/love.png\" class=\"smileys\" />");
                return message;
            };
        }
    </script>
end section