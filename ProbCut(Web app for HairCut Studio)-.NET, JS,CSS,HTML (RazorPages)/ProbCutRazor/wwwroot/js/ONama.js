// changing Google Map div class based on screen size
if ($(window).width() < 601)
{
    $('#mapAboutUs').removeClass('embed-responsive embed-responsive-16by9');
    $('#mapAboutUs').addClass('embed-responsive embed-responsive-4by3');
}

$(window).on('resize', function ()
{
    $('#mapAboutUs').removeClass('embed-responsive embed-responsive-16by9');
    $('#mapAboutUs').addClass('embed-responsive embed-responsive-4by3');
})

// function for displaying counters & graph (triggered on scroll)
var done = false;
$(window).scroll(function ()
{
	var hT = $('#scrolled2').offset().top,
		hH = $('#scrolled2').outerHeight(),
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

        var ctx = document.getElementById('myChart').getContext('2d');
        var myChart = new Chart(ctx, {
            type: 'doughnut',
            data: {
                labels: ['Frizeri', 'Musterije', 'Realizovani termini'],
                datasets: [{
                    data: [18, 56, 200],
                    backgroundColor: [
                        'rgba(255, 99, 132, 0.2)',
                        'rgba(54, 162, 235, 0.2)',
                        'rgba(127, 188, 101, 0.2)',
                    ],
                    borderColor: [
                        'rgba(255, 99, 132, 1)',
                        'rgba(54, 162, 235, 1)',
                        'rgba(127, 188, 101, 1)',
                    ],
                    borderWidth: 1
                }]
            },
            options: {
                scales: {
                    yAxes: [{
                        ticks: {
                            beginAtZero: true
                        }
                    }]
                },
                animation: {
                    duration: 2500
                },
                tooltips: {
                    callbacks: {
                        label: function (tooltipItem, data)
                        {
                            return data.labels[tooltipItem.index];
                        }
                    }
                },
                responsive: true
            }
        });

		done = true;
	}

	if (wS < (hT + hH - wH))
		done = false;
});