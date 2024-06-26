﻿function UpdateUserInfo(event) {
    // Prevent the default form submission behavior
    event.preventDefault();

    // Get the name from the input field
    var FirstName = $("#FirstName").val();
    var LastName = $("#LastName").val();

    // Create an object with the name
    var postData = {
        'FirstName': FirstName,
        'LastName': LastName
    };

    // Log the data being sent
    console.log("Sending AJAX request with data:", postData);

    // Display a loading spinner while waiting for the response
    swal.fire({
        title: 'لطفاً صبر کنید',
        html: 'در حال انجام عملیات...',
        allowOutsideClick: false,
        allowEscapeKey: false,
        onBeforeOpen: () => {
            swal.showLoading();
        }
    });

    // Send an AJAX request to the server
    $.ajax({
        contentType: 'application/x-www-form-urlencoded',
        dataType: 'json',
        type: "POST",
        url: "/Authentication/UpdateUserInfo",
        data: postData,
        success: function (data) {
            // Log the response data
            console.log("Received response data:", data);

            // Check if the login was successful
            if (data.isSuccess == true) {
                // Dismiss the loading spinner
                swal.close();

                // Display a success message using SweetAlert
                swal.fire(
                    'موفق!',
                    data.message,
                    'success'
                ).then(function (isConfirm) {
                    // Redirect the user to the main page after dismissing the alert
                    window.location.replace("/Authentication/UserInfo");
                });
            } else {
                // Dismiss the loading spinner
                swal.close();

                // Display a warning message using SweetAlert
                swal.fire(
                    'هشدار!',
                    data.message,
                    'warning'
                );
            }
        },
        error: function (request, status, error) {
            // Log any errors
            console.error("Error occurred:", error);

            // Dismiss the loading spinner
            swal.close();

            // Display a warning message using SweetAlert
            swal.fire(
                'هشدار!',
                request.responseText,
                'warning'
            );
        }
    });
}