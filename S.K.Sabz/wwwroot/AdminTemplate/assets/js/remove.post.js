function RemovePost(postId) {
	swal.fire({
		title: 'حذف پست',
		text: "کاربر گرامی از حذف پست مطمئن هستید؟",
		icon: 'warning',
		showCancelButton: true,
		confirmButtonColor: '#d33',
		cancelButtonColor: '#7cacbe',
		confirmButtonText: 'بله ، دسته بندی حذف شود',
		cancelButtonText: 'خیر'
	}).then((result) => {
		if (result.value) {
			var postData = {
				'postId': postId,
			};

			$.ajax({
				contentType: 'application/x-www-form-urlencoded',
				dataType: 'json',
				type: "POST",
				url: "/Admin/BlogList/RemovePost",
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