let viewModel = {

    table: ko.observable(),

    BindTable: function () {
            this.table = $('#tableData').DataTable({
                dom: 'Bfrtip',
                "buttons": [
                    {
                        text: '<i class="fa fa-plus" aria-hidden="true"></i>',
                        action: function (e, dt, node, config) {
                            viewModel.RedirectoCreatePage();
                        },
                        className: 'btn-add'
                    }
                ],
                "paging": true,
                "responsive": true,
                "lengthChange": false,
                "searching": true,
                "ordering": true,
                "info": true,
                "autoWidth": true,
                "serverSide": true,
                "processing": true,
                "ajax": {
                    url: "api/ApiProductCategory/ViewGrid",
                    type: "GET"
                },
                "columns": [
                    { data: "Name", title: "Nama" }
                ]

            });
    },
    RedirectoCreatePage: function ()
    {
        window.location.href = "/ProductCategory/Create";
    }
}

$(function ()
{
    ko.applyBindings(viewModel);
    viewModel.BindTable();
});