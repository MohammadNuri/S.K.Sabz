function UserStatusChange(userId) {
            swal.fire({
                title: 'تغییر وضعیت کاربر',
                text: "کاربر گرامی از تغییر وضعیت کاربر مطمئن هستید؟",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#d33',
                cancelButtonColor: '#7cacbe',
                confirmButtonText: 'بله ، تغییر وضعیت انجام شود',
                cancelButtonText: 'خیر'
            }).then((result) => {
                if (result.value) {

                    var postData = {
                        'userId': userId,
                    };

                    $.ajax({
                        contentType: 'application/x-www-form-urlencoded',
                        dataType: 'json',
                        type: "POST",
                        url: "/Admin/User/UserStatusChange",
                        data: postData,
                        success: function (data) {
                            if (data.isSuccess == true) {
                                swal.fire(
                                    'موفق!',
                                    data.message,
                                    'success'
                                ).then(function (isConfirm) {
                                    location.reload();
                                });
                            }
                            else {

                                swal.fire(
                                    'هشدار!',
                                    data.message,
                                    'warning'
                                );

                            }
                        },
                        error: function (request, status, error) {
                            alert(request.responseText);
                        }

                    });

                }
            })
        }