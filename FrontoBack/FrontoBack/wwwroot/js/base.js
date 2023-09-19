
$(document).ready(function () {
    $(document).on('keyup', '#input-search', function () {
        $(this).parent().parent().children().slice(1).remove();
        axios.get(`/Product/Search?value=${$(this).val()}`).then(data => {
            $(this).parent().parent().append(data.data);
        })
    })
})


