var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {

    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "nome", "width": "50%" },
            { "data": "valor_Inicial", "width": "20%" },
            {
                "data": "id_produto",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="Edit/${data}" class='btn btn-success text-white' style='cursor:pointer; width:100px;'>
                                     Editar
                                </a>
                                &nbsp;
                                <a onclick=Delete("Delete/${data}") class='btn btn-danger text-white' style='cursor:pointer; width:100px;'>
                                 Deletar
                                </a>
                            </div>
                            `;
                }, "width": "30%"
            }
        ],
        "language": {
            "emptyTable": "No records found."
        },
        "width": "100%"
    });
}

function Delete(url) {
    swal({
        title: "Você tem certeza que quer deletar??",
        text: "Não será possível recuperar os dados!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Sim, exclua!",
        closeOnconfirm: true
    }, function () {
        $.ajax({
            type: 'DELETE',
            url: url,
            success: function (data) {
                if (data.success) {
                    toastr.success(data.message);
                    dataTable.ajax.reload();
                }
                else {
                    toastr.error(data.message);
                }
            }
        });
    });
}