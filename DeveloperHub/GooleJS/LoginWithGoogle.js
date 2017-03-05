function onSignIn(googleUser) {
     
    // Useful data for your client-side scripts:
   var profile = googleUser.getBasicProfile();
    //console.log("ID: " + profile.getId()); // Don't send this directly to your server!
    //console.log('Full Name: ' + profile.getName());
    //alert(profile.getName());
    //console.log('Given Name: ' + profile.getGivenName());
    //console.log('Family Name: ' + profile.getFamilyName());
    //console.log("Image URL: " + profile.getImageUrl());
    //console.log("Email: " + profile.getEmail());

    // The ID token you need to pass to your backend:
     var id_token = googleUser.getAuthResponse().id_token;
   SendDataGooleLoginData(id_token,profile.getName(),profile.getEmail());
}
function SendDataGooleLoginData(AccessToken, UserName, Email) {
    $.ajax({
        type: "Post",
        url: '/Account/LoginWithGoogle/',
        data: "{ 'AccessToken': '" + AccessToken + "','UserName':'" + UserName + "','Email':'" + Email + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            alert("Update ..");
            alert(msg);
            var url = '/Account/GoogleSuccessLogin';
            window.location.href = url;
        },
        error: function (e) {
            alert(" erro. in ajax call" + e.error);
            alert("wrong");
        }
    });
}


