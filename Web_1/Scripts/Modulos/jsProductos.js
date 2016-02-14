$(document).ready(function () {

    fnInicializaVariables();

    //Registra Producto
    $("#btnRegistrar").on("click", function () {
        if (fnValidaCampos()) {
            fn_msjConfirmacion({
                title: "CONFIRMACIÓN",
                text: "¿Estás seguro de registrar los datos del producto ?",
                confirm: function (button) {
                    $("#RegistrarProducto").submit();
                },
                cancel: function (button) { },
                confirmButton: "SI",
                cancelButton: "NO"
            });
        }
    });
    // Eliminar Producto
    $("#btnEliminar").on("click", function () {
        fn_msjConfirmacion({
            title: "CONFIRMACIÓN",
            text: "¿Estás seguro de eliminar los datos del producto ?",
            confirm: function (button) {
                $("#EliminarProducto").submit();
            },
            cancel: function (button) { },
            confirmButton: "SI",
            cancelButton: "NO"
        });
    }) 
    //EditarProducto
    $("#btnEditar").on("click", function () {
        if (fnValidaCampos()) {
            fn_msjConfirmacion({
                title: "CONFIRMACIÓN",
                text: "¿Estás seguro de actualizar los datos del producto ?",
                confirm: function (button) {
                    $("#EditarProducto").submit();
                },
                cancel: function (button) { },
                confirmButton: "SI",
                cancelButton: "NO"
            });
        }
    })

});

//Inicializa las Variables
function fnInicializaVariables() {
    fnSoloLetras("vNombreProducto");
    fnSoloLetras("vDescripcionProducto");
    fnSoloNumeros("nPrecioCompra");
    fnSoloNumeros("nPrecioVenta");
    fnSoloNumeros("iStockActual");
    fnSoloNumeros("iStockMinimo");
    $("#vNombreProducto").attr("maxlength", "50");
    $("#vDescripcionProducto").attr("maxlength", "100");

}


function fnValidaCampos() {
    $("#hddMessage").html("");
    var br = false;

    var ddlCategoria = $("#iIdCategoria").val();
    var ddlProveedor = $("#iIdProveedor").val();
    var sNombreProducto = $("#vNombreProducto").val();
    var sDescripcionProducto = $("#vDescripcionProducto").val();
    var nPrecioCompra = $("#nPrecioCompra").val();
    var nPrecioVenta = $("#nPrecioVenta").val();
    var iStockActual = $("#iStockActual").val();
    var iStockMinimo = $("#iStockMinimo").val();
    if ($.trim(ddlCategoria) == 0) {
        br = true;
        $("#hddMessage").append("Por favor seleccione la categoria <br/>");
    }
    if ($.trim(ddlProveedor) == 0)
    {
        br = true;
        $("#hddMessage").append("Por favor seleccione el proveedor <br/>");
    }

    if ($.trim(sNombreProducto).length == 0) {
        br = true;
        $("#hddMessage").append("Por favor escriba el nombre del producto <br/>");
    }
    if ($.trim(sDescripcionProducto).length == 0)
    {
        br = true;
        $("#hddMessage").append("Por favor escriba la descripcion del producto <br/>");
    }

    if ($.trim(nPrecioCompra).length == 0) {
        br = true;
        $("#hddMessage").append("Por favor escriba el precio de compra <br/>");
    }

    if ($.trim(nPrecioVenta).length == 0) {
        br = true;
        $("#hddMessage").append("Por favor escriba el precio de venta <br/>");
    }

    if ($.trim(iStockActual).length == 0) {
        br = true;
        $("#hddMessage").append("Por favor escriba el stock actual <br/>");
    }

    if ($.trim(iStockMinimo).length == 0) {
        br = true;
        $("#hddMessage").append("Por favor escriba el stock minimo <br/>");
    }

    if ($("input[name='iEstado']:radio").is(':checked') == false) {
        br = true;
        $("#hddMessage").append("Por favor seleccione el estado del producto <br/>");
    }
    

    if (br) {
        $("#myModal2").modal("show");
        return false;
    } else {

        return true;
    }


    return;
}


function fn_msjConfirmacion(options) {

    var dataOptions = {};
    if (options.button) {
        var dataOptionsMapping = {
            'title': 'title',
            'text': 'text',
            'confirm-button': 'confirmButton',
            'cancel-button': 'cancelButton',
            'confirm-button-class': 'confirmButtonClass',
            'cancel-button-class': 'cancelButtonClass',
            'dialog-class': 'dialogClass'
        };
        $.each(dataOptionsMapping, function (attributeName, optionName) {
            var value = options.button.data(attributeName);
            if (value) {
                dataOptions[optionName] = value;
            }
        });
    }

    // Default options
    var settings = $.extend({}, options, {
        confirm: function () {

        },
        cancel: function (o) {
        },
        button: null
    }, dataOptions, options);

    // Modal
    var modalHeader =
                '<div class="modal-header css-modal-header">' +
                    '<div class="modal-title css-modal-title-text">' +
                    'Trabajo Cibertec' +
                    '</div>' +
                '</div>';

    var modalHTML =
            '<div class="modal fade in" tabindex="-1500" role="dialog">' +
                '<div class="modal-dialog modal-md css-modal-timer">' +
                    '<div class="modal-content css-modal-border-redondo">' +
                       modalHeader +
                        '<div class="modal-body">' +
                            '<div class="row">' +
                                '<div class="col-xs-12">' +
                                    '<div class="css-modal-timer-text text-justify">' +
                                        '<i class="pull-left fa fa-exclamation-circle fa-4x" style="color: #F56868"></i>' +
                                        '<span>' + settings.text + '</span>' +
                                    '</div>' +
                                '</div>' +
                            '</div>' +
                        '</div>' +
                        '<div class="modal-footer css-modal-footer">' +
                                '<button class="confirm btn btn-primary btn-xs"  type="button" data-dismiss="modal">' + settings.confirmButton +
                                '</button>' +
                                '<button class="cancel btn btn-xs btn-danger" type="button" data-dismiss="modal">' + settings.cancelButton +
                                '</button>' +
                        '</div>' +
                    '</div>' +
                '</div>' +
            '</div>';

    var modal = $(modalHTML);

    modal.on('shown.bs.modal', function () {
        modal.find(".btn-primary:first").focus();
    });
    modal.on('hidden.bs.modal', function () {
        modal.remove();
    });
    modal.find(".confirm").click(function () {
        settings.confirm(settings.button);
    });
    modal.find(".cancel").click(function () {
        settings.cancel(settings.button);
    });

    // Show the modal
    $("body").append(modal);
    modal.modal('show');
};


