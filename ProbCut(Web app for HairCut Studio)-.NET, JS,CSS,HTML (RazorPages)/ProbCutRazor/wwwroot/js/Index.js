// when page loads
$(window).on('load', function ()
{
	toastr.options.positionClass = 'toast-bottom-right';
	if (window.location.href.includes('loggedin'))
		toastr['success'](fetchLanguageData('NotificationSuccessfulLogin'));
	else if (window.location.href.includes('registered'))
		toastr['success'](fetchLanguageData('NotificationSuccessfulRegister'));
	else if (window.location.href.includes('loggedout'))
		toastr['success'](fetchLanguageData('NotificationSuccessfulLogout'));
	else if (window.location.href.includes('deleted'))
		toastr['success'](fetchLanguageData('NotificationSuccessfulDeleteAccount'));
});

// fetching language data from resource files
function fetchLanguageData(resourceName)
{
	return $.ajax({
		type: "GET",
		url: "Index?handler=LangData&resourceName=" + resourceName,
		contentType: "application/json; charset=utf-8",
		async: false,
		dataType: "json"
	}).responseJSON;
}

// changing Google Map div class based on screen size
if ($(window).width() < 601)
{
	$('#map').removeClass('embed-responsive embed-responsive-16by9');
	$('#map').addClass('embed-responsive embed-responsive-4by3');
}

$(window).on('resize', function ()
{
	$('#map').removeClass('embed-responsive embed-responsive-16by9');
	$('#map').addClass('embed-responsive embed-responsive-4by3');
})


// function for displaying counters (triggered on scroll)
var done = false;
$(window).scroll(function ()
{
	var hT = $('#scrolled1').offset().top,
		hH = $('#scrolled1').outerHeight(),
		wH = $(window).height(),
		wS = $(this).scrollTop();
	if (wS > (hT + hH - wH) && !done)
	{
		var countFrizeri = new CountUp("counterFrizeri", 0, 12, 0, 3, null);
		var countMusterije = new CountUp("counterMusterije", 0, 341, 0, 2, null);
		var countRealizovaniTermini = new CountUp("counterTermini", 0, 927, 0, 2, null);
		countFrizeri.start();
		countMusterije.start();
		countRealizovaniTermini.start();
		done = true;
	}

	if (wS < (hT + hH - wH))
		done = false;
});