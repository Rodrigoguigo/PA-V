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

function showTarefasPopup(){
    $("#popUpTarefas").dialog({
        title: "Cadastrar nova tarefa",
        width: 'auto',
        modal: true,
        resizable: false,
        responsive: true,
        clickOut: true
    }).prev(".ui-dialog-titlebar").css("background", "#a7b3e6");
}

function showProjetosPopup() {
    $("#popUpProjetos").dialog({
        title: "Cadastrar novo projeto",
        width: 'auto',
        modal: true,
        resizable: false,
        responsive: true,
        clickOut: true
    }).prev(".ui-dialog-titlebar").css("background", "#a7b3e6");
}