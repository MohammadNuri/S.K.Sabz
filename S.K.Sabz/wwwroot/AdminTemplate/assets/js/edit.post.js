function EditPost(event) {
    // Prevent the default form submission behavior
    event.preventDefault();

    // Extract postId from the URL
    var urlParams = new URLSearchParams(window.location.search);
    var postId = urlParams.get('postId');

    var postData = new FormData();

    // Add postId to the FormData
    postData.append("PostId", postId);

    // Get Data From Inputs
    postData.append("Title", $("#Title").val());
    postData.append("Description", getEditorContent());
    postData.append("Slug", $("#Slug").val());
    postData.append("IsSpecial", $("input[name='is_special']:checked").val() === "true");
    postData.append("CategoryId", $('#Category').val());
    postData.append("Displayed", $('#kt_ecommerce_add_product_status_select').val());
    postData.append("Position", $('#Position').val());

    // Get Images
    var postImages = document.getElementById("Images");
    if (postImages.files.length > 0) {
        for (var i = 0; i < postImages.files.length; i++) {
            postData.append('Images-' + i, postImages.files[i]);
        }
    }

    // Log the data being sent
    console.log("Sending AJAX request with data:", postData);

    // Display a loading spinner while waiting for the response
    swal.fire({
        title: 'لطفاً صبر کنید',
        html: 'در حال انجام عملیات...',
        allowOutsideClick: false,
        allowEscapeKey: false,
        willOpen: () => {
            swal.showLoading();
        }
    });

    $.ajax({
        contentType: false,
        processData: false,
        type: "POST",
        url: "/Admin/BlogList/EditPost",
        data: postData,
        success: function (data) {
            // Log the response data
            console.log("Received response data:", data);

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
                    window.location.replace("/Admin/BlogList");
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

// Function to get the content of the Quill editor
function getEditorContent() {
    var quill = new Quill('#kt_ecommerce_add_product_description', {
        modules: {
            toolbar: false // Hide toolbar if not needed
        },
        theme: 'snow'
    });
    return quill.root.innerHTML;
}