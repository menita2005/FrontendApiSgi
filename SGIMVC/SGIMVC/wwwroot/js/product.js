document.addEventListener('DOMContentLoaded', function () {
    loadProductos();
});

function loadProductos() {
    fetch('/Productos/GetAllProductos') // Asegúrate de reemplazar con la ruta correcta
        .then(response => response.json())
        .then(data => {
            initializeDataTable(data.data);
        })
        .catch(error => console.error('Error:', error));
}


function initializeDataTable(producto) {
    let table = document.getElementById('tblProducto');
    if (!table) {
        table = document.createElement('table');
        table.id = 'tblProducto';
        table.className = 'display'; // Clase necesaria para DataTables
        document.getElementById('productosContainer').appendChild(table);
    }

    $(table).DataTable({
        responsive: true,
        data: producto,
        columns: [
            { title: "ID", data: "id", className: "column-id" },
            { title: "ProductoNombre", data: "productoNombre", className: "column-productoNombre" },
            { title: "ProveedorId", data: "proveedorId", className: "column-supplierid" },
            { title: "Precio", data: "recio", className: "column-precio" },
            { title: "CategoriaId", data: "zategoriaId", className: "column-categoriaId" },
            {
                title: "Acciones",
                data: "id",
                render: function (data) {
                    return `<div class="text-center">
                                <a href="/Productos/Detail/${data}" class="btn btn-primary"><i class="fa fa-eye"></i></a>
                                <a href="/Productos/Edit/${data}" class="btn btn-secondary"><i class="fa fa-edit"></i></a>
                                <a onclick="Delete('/Productos/Delete/${data}')" class="btn btn-danger"><i class="fa fa-trash"></i></a>
                            </div>`;
                },
                className: "column-actions"
            }
        ]
    });
}


function Delete(url) {
    Swal.fire({
        title: "¿Está seguro de querer borrar el registro?",
        text: "¡Esta acción no puede ser revertida!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Sí, bórralo!',
        cancelButtonText: 'Cancelar'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: 'DELETE',
                url: url,
                success: function (response) {
                    if (response && response.success) {
                        toastr.success(response.message || "Registro eliminado con éxito.");
                        // Recargar DataTables
                        $('#productosTable').DataTable().clear().destroy();
                        loadProductos();
                    } else {
                        toastr.error(response.message || "Ocurrió un error desconocido.");
                    }
                },
                error: function (error) {
                    toastr.error("Error al intentar eliminar el registro.");
                    console.error('Error:', error);
                }
            });
        }
    });
}