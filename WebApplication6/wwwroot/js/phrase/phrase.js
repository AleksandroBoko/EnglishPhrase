$(function () {
    $('#button-add').click(function (event) {        
        $.ajax({
            url: '/Phrase/Index?handler=AddForm',
            success: function (data) {
                if (data) {
                    $('#edit-container').html(data);
                }
            }
        });
    });
});
