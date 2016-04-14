$(document).ready(function () {
    LoadPage();
})

// carrega todos os botões da tela inicial de cada projeto
function LoadPage() {

    var _btnNovaHomolog = $("#btn-add-modal");
    var _btnAlterar = $("a[id*='btn-alt-modal-']");

    _btnNovaHomolog.click(function () {
        var _rota = $(this).data('url');
        var _modelContent = $("#modelContent");
        var _modelReport = $('#modelReport');

        $.ajax({
            type: "GET",
            url: _rota,
            datatype: "json",
            cache: false,
        })
        .success(function (data) {

            _modelContent.html(data);
            habilitarComponentesModal();
            _modelReport.modal('show')

        })
        .error(function (xhr, ajaxOptions, thrownError) {
            alert(thrownError)
        });
    });

    _btnAlterar.click(function () {
        var _rota = $(this).data('url');
        var _modelContent = $("#modelContent");
        var _modelReport = $('#modelReport');
        $.ajax({
            type: "GET",
            url: _rota,
            datatype: "json",
            cache: false,
        })
        .success(function (data) {

            _modelContent.html(data);
            habilitarComponentesModal();
            _modelReport.modal('show')

        })
        .error(function (xhr, ajaxOptions, thrownError) {
            alert(thrownError)
        });
    });
}
//--------------------------------------------------------
function retornoModalAjax(form, rota, id) {
    var _msg;
    var _inputObservacao = $("#Observacao");

    if ($('.validation-summary-errors ul li').length > 0) {
        _msg = '<div class="alert alert-warning"><strong>Atenção:</strong> Existem erros no formulario. Você pode ter esquecido alguma informação.</div>'
    }
    else if (form == 1) { //form vir preenchido com 1 está vindo de uma nova homoçogação
        _msg = '<div class="alert alert-success alert-dismissable"><p><strong>Sucesso!</strong> Tarefa Cadastrada. A tela sendo <strong>Atualizada!</strong>...</p></div>';
        setTimeout("location.reload();", 3000);

    }
    else {
        _msg = '<div class="alert alert-success alert-dismissable"><p><strong>Sucesso!</strong> Tarefa Atualizada</p></div>';
        AtualizarListagem(id, rota);
    }
    $("#modelAlert").html(_msg);
    _inputObservacao.text("");
}

function habilitaBotaoVoltar() {
    $(function () {

        var _btnVoltar = $("a[id*='btn-voltar-modal-']")

        _btnVoltar.click(function () {
            var _rota = $(this).data('url');
            var _modelContent = $("#modelContent");

            $.ajax({
                type: "GET",
                url: _rota,
                datatype: "json",
                cache: false,
            })
            .success(function (data) {
                _modelContent.html(data);

                habilitarComponentesModal();

            })
            .error(function (xhr, ajaxOptions, thrownError) {
                alert(thrownError)
            });
        });
    });
}

function habilitarComponentesModal() {

    $(function () {
        var _btnObs = $("a[id*='btn-obs-modal-']");
        var _modelContent = $("#modelContent");
        var _modelReport = $('#modelReport');

        _btnObs.click(function () {
            var rota = $(this).data('url');
            $.ajax({
                type: "GET",
                url: rota,
                datatype: "json",
                cache: false,
            })
            .success(function (data) {
                _modelContent.html(data);
                habilitaBotaoVoltar();

            })
            .error(function (xhr, ajaxOptions, thrownError) {
                alert(thrownError)
            });

        });

    });//Atribuindo click no botao e direcionando a pagina de obs no modal

    $(function () {

        var _inputObservacao = $("#Observacao");
        var _labelContador = $("#contador");

        _inputObservacao.keyup(function () {
            var limite = 600;
            var tamanho = $(this).val().length;
            if (tamanho > limite)
                tamanho -= 1;

            var contador = limite - tamanho;
            if (contador < 0) contador = 0;

            _labelContador.text(contador + " Caracteres");

            if (tamanho >= limite) {
                var txt = $(this).val().substring(0, limite);
                $(this).val(txt);
            }
        });
    });//habilita contador no modal
}

function HabilitarClick(id) {
    var _btnEditar = $("#btn-alt-modal-" + id);

    _btnEditar.click(function () {
        var _rota = $(this).data('url');
        var _modelContent = $("#modelContent");
        var _modelReport = $('#modelReport');

        $.ajax({
            type: "GET",
            url: _rota,
            datatype: "json",
            cache: false,
        })
        .success(function (data) {

            _modelContent.html(data);
            _modelReport.modal('show')

        })
        .error(function (xhr, ajaxOptions, thrownError) {
            alert("Erro ao carregar click botão");
            //alert(thrownError);
        });
    });
}

function AtualizarListagem(id, rota) {
    var _LinhaAtualizar = $("#Tarefa" + id);
    var _rota = rota + id;

    $.ajax({
        type: "GET",
        url: _rota,
        datatype: "json",
        cache: false,
    })
       .success(function (data) {
           _LinhaAtualizar.empty();
           $(data).appendTo(_LinhaAtualizar);
           HabilitarClick(id);
       })
       .error(function (xhr, ajaxOptions, thrownError) {
           alert("Erro ao atualizar listagem");
       });
}
//---------------------------------------------------------

$(document).ajaxStart(function () {
    $("#loading").show();
});

$(document).ajaxStop(function () {

    $("#loading").hide();
});