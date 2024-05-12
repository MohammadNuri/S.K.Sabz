function MakeAdmin(userId) {
	swal.fire({
		title: 'تغییر نقش به مدیر!',
		text: "مدیر گرامی از تغییر نقش کاربر به مدیر مطمئن هستید؟",
		icon: 'warning',
		showCancelButton: true,
		confirmButtonColor: '#d33',
		cancelButtonColor: '#7cacbe',
		confirmButtonText: 'بله ، انجام شود',
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
				url: "/Admin/User/MakeRoleAdmin",
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


function MakeCustomer(userId) {
	swal.fire({
		title: 'تغییر نقش به کاربر معمولی!',
		text: "مدیر گرامی از تغییر نقش کاربر به کاربر معمولی مطمئن هستید؟",
		icon: 'warning',
		showCancelButton: true,
		confirmButtonColor: '#d33',
		cancelButtonColor: '#7cacbe',
		confirmButtonText: 'بله ، انجام شود',
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
				url: "/Admin/User/MakeRoleCustomer",
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