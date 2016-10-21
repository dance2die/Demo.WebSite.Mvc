$(function() {
	//$('#item_IsVoided').each(function () {
	//$('input[type="checkbox"]').each(function () {
	$('input[name="item.IsVoided"]').each(function () {
		var $this = $(this);

		if ($this.is(":checked")) {
			$this.prop('disabled', true);
		}
	});
});









