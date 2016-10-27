$(function() {
	//$(".nav a").on("click", function (e) {
	//	$(".nav").find(".active").removeClass("active");
	//	$(this).parent().addClass("active");
	//});

	// http://stackoverflow.com/a/19310428/4035
	var url = window.location;
	$('.navbar .nav').find('.active').removeClass('active');
	$('.navbar .nav li a').each(function () {
		if (this.href == url) {
			$(this).parent().addClass('active');
		}
	});
});