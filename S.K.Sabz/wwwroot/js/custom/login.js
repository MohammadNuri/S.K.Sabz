document.addEventListener("DOMContentLoaded", function () {
    // Attach an event listener to the input field to handle Enter key press
    document.getElementById("PhoneNumber").addEventListener("keypress", function (event) {
        if (event.key === "Enter") {
            event.preventDefault(); // Prevent the default form submission
            Login(event); // Call the Login function
        }
    });
});

function Login(event) {
    // Prevent the default form submission behavior
    event.preventDefault();

    // Get the phone number from the input field
    var PhoneNumber = $("#PhoneNumber").val();

    // Create an object with the phone number
    var postData = {
        'PhoneNumber': PhoneNumber
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
        url: "/Authentication/Login",
        data: postData,
        success: function (data) {
            console.log("Received response data:", data); // Log the response data
            // Check if the login was successful
            if (data.isSuccess == true) {
                // Check if there's a redirect URL in the query parameters
                var queryParams = new URLSearchParams(window.location.search);
                var redirectUrl = queryParams.get('redirectUrl');
                console.log("Redirect URL:", redirectUrl); // Log the redirect URL
                // Dismiss the loading spinner
                swal.close();
                // Display a success message using SweetAlert
                swal.fire(
                    'موفق!',
                    data.message,
                    'success'
                ).then(function (isConfirm) {
                    // Redirect the user to the previous page or the main page after dismissing the alert
                    if (redirectUrl) {
                        console.log("Redirecting to:", redirectUrl); // Log the redirection URL
                        window.location.href = redirectUrl;
                    } else {
                        console.log("Redirecting to default page."); // Log the default redirection
                        window.location.href = "/";
                    }
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