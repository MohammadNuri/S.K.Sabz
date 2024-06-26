﻿document.addEventListener("DOMContentLoaded", function () {
    // Attach an event listener to the form submission
    document.getElementById("commentForm").addEventListener("submit", function (event) {
        event.preventDefault(); // Prevent the default form submission
        AddComment(event, '@Model.Id'); // Call the AddComment function
    });

    // Add an event listener to the delete buttons
    document.querySelectorAll('.delete-btn').forEach(function (btn) {
        btn.addEventListener('click', function (event) {
            event.preventDefault();
            var commentId = this.getAttribute('data-comment-id');
            DeleteComment(event, commentId);
        });
    });
});

function AddComment(event, postId) {
    // Prevent the default form submission behavior
    event.preventDefault();

    // Get the comment text from the textarea
    var commentText = document.getElementById("commentText").value;

    // Create a URLSearchParams object with the form data
    var postData = new URLSearchParams();
    postData.append('Text', commentText);

    // Log the data being sent
    console.log("Sending AJAX request with data:", postData.toString(), "PostId:", postId);

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
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        dataType: 'json',
        type: "POST",
        url: `/BlogList/AddNewComment?postId=${postId}`,
        data: postData.toString(),
        success: function (data) {
            // Log the response data
            console.log("Received response data:", data);

            // Check if the comment submission was successful
            if (data.isSuccess) {
                // Dismiss the loading spinner
                swal.close();

                // Display a success message using SweetAlert
                swal.fire(
                    'موفق!',
                    data.message,
                    'success'
                ).then(function () {
                    // Optionally, you can reload the page or update the comments section dynamically
                    location.reload();
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

// Add an event listener to the reply buttons
document.querySelectorAll('.reply-btn').forEach(function (btn) {
    btn.addEventListener('click', function (event) {
        event.preventDefault();

        // Get the comment ID from the data attribute of the button
        var commentId = this.getAttribute('data-comment-id');

        // Set the comment ID in the hidden input field
        document.getElementById('ReplyCommentId').value = commentId;

        // Get the postId from the hidden input field in the form
        var postId = document.getElementById('postId').value;

        // Call the AddReply function with postId as an argument
        AddReply(event, postId);
    });
});

// Function to handle the reply submission
function AddReply(event, postId) {
    event.preventDefault();

    // Get the reply text from the input field in the modal
    var replyText = document.getElementById('Reply').value;

    // Get the comment ID from the hidden input field in the modal
    var commentId = $('#ReplyCommentId').val();

    // Create a URLSearchParams object with the form data
    var replyData = new URLSearchParams();
    replyData.append('Text', replyText);
    replyData.append('ParentCommentId', commentId);

    // Log the data being sent
    console.log("Sending AJAX request with data:", replyData.toString());

    // Display a loading spinner while waiting for the response
    swal.fire({
        title: 'لطفاً صبر کنید',
        html: 'در حال ارسال پاسخ...',
        allowOutsideClick: false,
        allowEscapeKey: false,
        onBeforeOpen: () => {
            swal.showLoading();
        }
    });

    // Send an AJAX request to the server
    $.ajax({
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        dataType: 'json',
        type: "POST",
        url: `/BlogList/AddNewComment?postId=${postId}`,
        data: replyData.toString(),
        success: function (data) {
            // Log the response data
            console.log("Received response data:", data);

            // Check if the reply submission was successful
            if (data.isSuccess) {
                // Dismiss the loading spinner
                swal.close();

                // Display a success message using SweetAlert
                swal.fire(
                    'موفق!',
                    data.message,
                    'success'
                ).then(function () {
                    // Optionally, you can reload the page or update the comments section dynamically
                    location.reload();
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


function DeleteComment(event, commentId) {
    event.preventDefault();

    swal.fire({
        title: 'حذف نظر',
        text: "مدیر گرامی از حذف نظر مطمئن هستید؟",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#d33',
        cancelButtonColor: '#7cacbe',
        confirmButtonText: 'بله، نظر حذف شود',
        cancelButtonText: 'خیر'
    }).then((result) => {
        if (result.value) {
            console.log("Confirmed, proceeding with AJAX request to delete comment with ID:", commentId);

            $.ajax({
                url: "/BlogList/DeleteComment",
                type: "POST",
                contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                dataType: 'json',
                data: { commentId: commentId },
                success: function (data) {
                    console.log("AJAX request successful, received response:", data);

                    if (data.isSuccess) {
                        swal.fire(
                            'موفق!',
                            data.message,
                            'success'
                        ).then(function () {
                            location.reload();
                        });
                    } else {
                        swal.fire(
                            'هشدار!',
                            data.message,
                            'warning'
                        );
                    }
                },
                error: function (request, status, error) {
                    console.error("Error occurred during AJAX request:", error);
                    console.error("Request status:", status);
                    console.error("Request responseText:", request.responseText);

                    swal.fire(
                        'هشدار!',
                        'خطایی رخ داده است. لطفا دوباره تلاش کنید.',
                        'warning'
                    );
                }
            });
        } else {
            console.log("Deletion canceled by user.");
        }
    }).catch(error => {
        console.error("Error with SweetAlert:", error);
    });
}
