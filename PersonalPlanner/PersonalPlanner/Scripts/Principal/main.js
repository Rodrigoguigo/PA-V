$('#btnProjeto').on('click', function () {
    $('#projeto').show();
    $('#hoje').hide();
    $('#MenuAtual').html('Projeto Aplicado V');
});

$('#btnHoje').on('click', function () {
    $('#hoje').show();
    $('#projeto').hide();
    $('#MenuAtual').html('Hoje');
});