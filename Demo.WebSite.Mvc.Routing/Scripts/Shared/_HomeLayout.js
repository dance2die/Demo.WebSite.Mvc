$(function () {
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


	var getPage = function (e) {
		var $a = $(this);

		var options = {
			url: $a.attr('href'),
			type: 'get',
			data: $('form').serialize()
		};

		$.ajax(options).done(function(data) {
			var target = $a.parents('div.pagedList').attr('data-oft-target');
			$(target).replaceWith(data);
		});

		e.preventDefault();
	};

	$('.main-content').on('click', '.pagedList a', getPage);
});