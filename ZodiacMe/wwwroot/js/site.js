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