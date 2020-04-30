//var messages = new Messages();
//var commonModel = new CommonModel();
//var loginService = new LoginService();

function LogInnSubmit() {
    $('#ErrorMSg').css("display", "none");
    var Validation = 0;
    var UserName = $("#txtUserName").val().trim();
    var Password = $("#txtPassword").val().trim();

    if (UserName == "") {
        $('#ErrorMSgtxtUserName').html("<p>User Name is required.</p>");
        $('#ErrorMSgtxtUserName').css("display", "block");
        Validation = 1;
    }
    else {
        $('#ErrorMSgtxtUserName').css("display", "none");
    }
    if (Password == "") {
        $('#ErrorMSgtxtPassword').html("<p>Password is required.</p>");
        $('#ErrorMSgtxtPassword').css("display", "block");
        Validation = 1;
    }
    else {
        $('#ErrorMSgtxtPassword').css("display", "none");
    }
    if (Validation > 0) {
        return false;
    }
    else {
        return true;
    }
}
function validateEmail() {
    var Email = $("#txtEmail").val();
    var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    if (!regex.test(Email)) {
        $('#ErrorMSgEmail').html("<p>Invalid Email Id.</p>");
        $('#ErrorMSgEmail').css("display", "block");
        return false;
    }
    else {
        $('#ErrorMSgEmail').css("display", "none");
        return true;
    }
}

function OpenForgotPasswordPopup() {
    $("#txtmail").val("");
    $('#SucessMSgtxtmail').empty();
    $('#ErrorMSgtxtmail').empty();
    var dialogBoxValues = messages.getDialogBoxValues(300, 300, 'Forgot Password');
    messages.displayForLogin('dialog-ForgotPassword', dialogBoxValues);
}

function closeDialog(id) {
    $("#" + id).dialog("close");
    $("#txtmail").focus();
}

function sendEmailToUser() {  
    $('#ErrorMSgtxtmail').css("display", "none");
    $('#SucessMSgtxtmail').css("display", "none");  
    var Validation = 0;
    var Email = $("#txtmail").val().trim();

    if (Email == "") {
        $('#ErrorMSgtxtmail').html("<p>Email Id is required.</p>");
        $('#ErrorMSgtxtmail').css("display", "block");
        Validation = 1;
    }
    else {
        $('#ErrorMSgtxtmail').css("display", "none");
    }
    if (Validation > 0) {
        return false;
    }
    else {
        loginService.forgotPassword(Email).then(function (response) {            
            if (response.success == "SUCCESS") {                           
                $('#SucessMSgtxtmail').html("<p>Password reset link sent.Please check your inbox.</p>");
                $('#SucessMSgtxtmail').css("display", "block");
                $('#ErrorMSgtxtmail').css("display", "none");
                $("#txtmail").val("");
            }
            else if (response.success == "NOTREGISTERD") {                
                $('#ErrorMSgtxtmail').html("<p>User is not registered.</p>");
                $('#ErrorMSgtxtmail').css("display", "block");
                $('#SucessMSgtxtmail').css("display", "none");
            }
            else if (response.success == "FAIL") {                
                $('#ErrorMSgtxtmail').html("<p>Forgot password fail.</p>");
                $('#ErrorMSgtxtmail').css("display", "block");
                $('#SucessMSgtxtmail').css("display", "none");
            } else {                
                $('#ErrorMSgtxtmail').html("<p>Only Admin User can apply for forgot password.</p>");
                $('#ErrorMSgtxtmail').css("display", "block");
                $('#SucessMSgtxtmail').css("display", "none");
            }
        }, function (xhr) {
            $('#ErrorMSgtxtmail').html("<p>There is error to send message.Please contact administrator</p>");
            $('#ErrorMSgtxtmail').css("display", "block");
        });
    }
}
function validateEmail() {
    var Email = $("#txtmail").val();
    var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    if (!regex.test(Email)) {
        $('#ErrorMSgtxtmail').html("<p>Invalid Email Id.</p>");
        $('#ErrorMSgtxtmail').css("display", "block");
        return false;
    }
    else {
        $('#ErrorMSgtxtmail').css("display", "none");
        return true;
    }
}
function isDisplayMessage(isDisplay) {
    if (isDisplay) {
        $('#errorDiv').css('display', 'block');
    } else {
        $('#errorDiv').css('display', 'none');
    }
}