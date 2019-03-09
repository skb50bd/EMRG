$(document).ready(function()
{
	$("#menu-toggle").click(function (e) {
		e.preventDefault();
		$("#wrapper").toggleClass("toggled");
    });

    $('#date-of-birth').datetimepicker({
        format: 'DD/MM/YYYY',
        useCurrent: false
    });
});
