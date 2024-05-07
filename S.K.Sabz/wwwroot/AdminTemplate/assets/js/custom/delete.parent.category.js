function DeleteCategory(CatId) {
	swal.fire({
		title: 'حذف دسته بندی',
		text: "کاربر گرامی از حذف دسته بندی مطمئن هستید؟",
		icon: 'warning',
		showCancelButton: true,
		confirmButtonColor: '#d33',
		cancelButtonColor: '#7cacbe',
		confirmButtonText: 'بله ، دسته بندی حذف شود',
		cancelButtonText: 'خیر'
	}).then((result) => {
		if (result.value) {
			var postData = {
				'CatId': CatId,
			};

			$.ajax({
				contentType: 'application/x-www-form-urlencoded',
				dataType: 'json',
				type: "POST",
				url: "/Admin/Categories/DeleteCategory",
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