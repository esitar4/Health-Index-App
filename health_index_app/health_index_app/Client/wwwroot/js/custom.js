$('.collapse').on('show.bs.collapse', function () {
    var groupId = $('#expander').attr('data-group-id');
    if (groupId) {
        $('#grandparentIcon').html('v');
    }
});

$('.collapse').on('hide.bs.collapse', function () {
    var groupId = $('#expander').attr('data-group-id');
    if (groupId) {
        $('#' + groupId + 'Icon').html('>');
    }
});
