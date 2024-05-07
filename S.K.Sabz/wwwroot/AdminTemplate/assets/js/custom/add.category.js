

function AddParentCategory(event) {
    // Prevent the default form submission behavior
    event.preventDefault();

    // Get the name from the input field
    var Name = $("#Name").val();

    // Create an object with the name
    var postData = {
        'Name': Name,
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
        url: "/Admin/Categories/AddNewCategory",
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
                    window.location.replace("/Admin/Categories");
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


function AddChildCategory(event, parentId) {
    // Prevent the default form submission behavior
    event.preventDefault();


    // Get the name from the input field in the modal
    var ChildName = $("#ChildName").val();
    var parentId = $("#parentIdInput").val();


    // Create an object with the name and parentId
    var postData = {
        'Name': ChildName,
        'ParentId': parentId
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
        url: "/Admin/Categories/AddNewCategory",
        data: postData,
        success: function (data) {
            // Log the response data
            console.log("Received response data:", data);

            // Check if the operation was successful
            if (data.isSuccess == true) {
                // Dismiss the modal
                $('#add-category').modal('hide');

                // Display a success message using SweetAlert
                swal.fire(
                    'موفق!',
                    data.message,
                    'success'
                ).then(function (isConfirm) {
                    // Redirect the user to the main page after dismissing the alert
                    window.location.replace("/Admin/Categories");
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


// Function to handle when a category is clicked
$(document).on("click", ".text-hover-primary", function () {
    // Remove active class from all categories
    $(".text-hover-primary").removeClass("active-category");

    // Add active class to the clicked category
    $(this).addClass("active-category");
});