// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function ModalDialogWithContent(title, content) {
    const isSuccess = title === "Sucesso!";
    const randomId = 'modal_' + Math.random().toString().replace('.', '');

    const dialog = `
        <div id="${randomId}" class="modal fade" tabindex="-1">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header ${isSuccess ? 'bg-success text-white' : 'bg-danger text-white'}">
                        <h5 class="modal-title">${title}</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Fechar"></button>
                    </div>
                    <div class="modal-body">
                        <div class="alert ${isSuccess ? 'alert-success' : 'alert-danger'}" role="alert">
                            ${content}
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Fechar</button>
                    </div>
                </div>
            </div>
        </div>
    `;

    $('body').append(dialog);
    const modal = new bootstrap.Modal(document.getElementById(randomId));
    modal.show();

    // Remove o modal da DOM ao fechar
    $(`#${randomId}`).on('hidden.bs.modal', function () {
        $(this).remove();
    });
}

function ModalDialog(type, text) {
    let title = (type === "Success") ? "Sucesso!" : "Erro";
    ModalDialogWithContent(title, `<p>${text}</p>`);
}

$(document).ready(function () {
    $('#dtgDados').DataTable({
        "ordering": true,
        "paging": true,
        "searching": true,
        "oLanguage": {
            "sEmptyTable": "Nenhum registro encontrado na tabela",
            "sInfo": "Mostrar _START_ até _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrar 0 até 0 de 0 Registros",
            "sInfoFiltered": "(Filtrar de _MAX_ total registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Mostrar _MENU_ registros por pagina",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Pesquisar",
            "oPaginate": {
                "sNext": "Proximo",
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Ultimo"
            },
            "oAria": {
                "sSortAscending": ": Ordenar colunas de forma ascendente",
                "sSortDescending": ": Ordenar colunas de forma descendente"
            }
        },
        columnDefs: [
            {
                defaultContent: "-",
                targets:"_all"
            }
        ]
    });
});
function abrirPopupUsuario(id, nome, controller) {

    document.getElementById('input_texto_contato').textContent = "Deseja realmente apagar o Usuario (" + nome + ")?";
    document.getElementById('texto_popup').textContent = "Apagar Usuario";

    abrirPopup(id, nome, controller);
}
function abrirPopupContato(id, nome, controller) {

    document.getElementById('input_texto_contato').textContent = "Deseja realmente apagar o contato (" + nome + ")?";
    document.getElementById('texto_popup').textContent = "Apagar Contato";
 
    abrirPopup(id, nome, controller);
}
function abrirPopup(id, nome, controller) {
    document.getElementById('idParaExcluir').value = id;
    const form = document.getElementById('formApagar');
    form.setAttribute("action", `${controller}/Apagar`);

    $('#popUpApagar').modal('show');
}

document.addEventListener("DOMContentLoaded", function () {
    document.addEventListener('hide.bs.modal', function (event) {
        if (document.activeElement) {
            document.activeElement.blur();
        }
    });
});

