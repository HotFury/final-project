$('#uploadImage').on('change', function (e) {
    e.preventDefault();
    var files = document.getElementById('uploadImage').files;
    if (files.length > 0) {
        if (window.FormData !== undefined) {
            var data = new FormData();
            data.append("image", files[0]);
            $.ajax({
                type: "POST",
                url: '@Url.Action("AttachImage", "Admin")',
                contentType: false,
                processData: false,
                data: data,
                success: function (result) {
                    $("#result").replaceWith(result);
                },
                error: function (xhr, status, p3) {
                    $("#result").replaceWith(xhr.responseText);
                }
            });
        } else {
            alert("Браузер не поддерживает загрузку файлов HTML5!");
        }
    }
});