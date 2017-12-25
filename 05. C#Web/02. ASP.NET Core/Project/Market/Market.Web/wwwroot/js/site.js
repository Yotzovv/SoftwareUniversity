// Write your JavaScript code.

$(function () {
	$(".heading-compose").click(function () {
		$(".side-two").css({
			"left": "0"
		});
	});

	$(".newMessage-back").click(function () {
		$(".side-two").css({
			"left": "-100%"
		});
	});
})

// Stop carousel
$('.carousel').carousel({
	interval: false
});