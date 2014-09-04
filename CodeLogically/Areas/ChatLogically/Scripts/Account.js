

function CallServerLogin(baseUrl) {
    var user = $('#Id').val();
    ShowWaitScreen();
    $.post(baseUrl + 'Account/Login?Id=' + user, function (data) {
        RemoveWaitSCreen();
        $('#login').empty();
        $('#login').append(data);
        location = '';
        //signalr uses the same authentication , therefore- connection Id breaks
        //OnAuth(user);
      
    });
}

function CallServerSignOut(baseUrl) {
    ShowWaitScreen();
    OnSignOut();
    $.post(baseUrl + 'Account/SignOut', function (data) {
        RemoveWaitSCreen();
        $('#login').empty();
        $('#login').append(data);
        location = '';
    });
}