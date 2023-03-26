function GetUserSecret() {
    var inputString = $("#SecretInput").val();
    var url = '/Home/GetSecret/';
    $.ajax({
        type: 'POST',
        url: url,
        data: { "key": inputString },
        success: function (response) {
            if (response.responseCode === 0) {
                console.log(response.responseCode)
                if ($("#ErrorOutput").is(':hidden')) {
                    $("#ErrorOutput").prop('hidden', false);
                }

                if (!$('#SecretOutput_Success').is(':hidden')) {
                    $('#SecretOutput_Success').prop('hidden', true);
                    $('#UserSecretID').val('');
                    $('#SecretKey').val('');
                    $('#SecretValue').val('');
                }

                $('#ErrorOutput').text(response.responseMessage);
            } else {
                if (!$('#ErrorOutput').is(':hidden')) {
                    $('#ErrorOutput').prop('hidden', true);
                }
                var secret = JSON.parse(response.responseMessage);
                $('#SecretOutput_Success').prop('hidden', false);
                $('#UserSecretID').val(secret.UserSecretID);
                $('#SecretKey').val(secret.SecretKey);
                $('#SecretValue').val(secret.SecretValue);
            }
        }
    })
}