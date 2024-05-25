document.addEventListener("DOMContentLoaded", function () {
	var searchInput = document.getElementById("searchInput");

	searchInput.addEventListener("keypress", function (event) {
		if (event.key === "Enter") {
			event.preventDefault();
			var searchKey = searchInput.value;
			if (searchKey.trim() !== "") {
				var url = new URL(window.location.href);
				url.searchParams.set("SearchKey", searchKey);
				window.location.href = url.toString();
			}
		}
	});
});