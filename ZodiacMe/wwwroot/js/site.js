$('#Mes').change(function (e) {
    let dia = $(this).val();
    let now = new Date();
    let year = now.getFullYear();
    let numDays = daysInMonth(dia, year);
    addDias(numDays);
});

function daysInMonth(month, year) {
    return new Date(year, month, 0).getDate();
}

function addDias(diasTotales) {
    $('#Dia').find('option').not(':first').remove();
    for (var i = 1; i <= diasTotales; i++) {
        $('#Dia').append($('<option>', {
            value: i,
            text: i
        }));
    }
}

// Initialize Editor
$('.textarea-editor').summernote({
    height: 300, // set editor height
    minHeight: 400, // set minimum height of editor
    maxHeight: 400, // set maximum height of editor
    focus: true // set focus to editable area after initializing summernote
});