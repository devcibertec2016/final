$(document).ready(function () {

    fnInicializaVariables();

    //Registra Proveedores
    $("#btnRegistrar").on("click", function () {
        if (fnValidaCampos()) {
            fn_msjConfirmacion({
                title: "CONFIRMACIÓN",
                text: "¿Estás seguro de registrar los datos del proveedor ?",
                confirm: function (button) {
                    $("#RegistrarProveedor").submit();
                },
                cancel: function (button) { },
                confirmButton: "SI",
                cancelButton: "NO"
            });
        }
    });
    // Eliminar Proveedores
    $("#btnEliminar").on("click", function () {
        fn_msjConfirmacion({
            title: "CONFIRMACIÓN",
            text: "¿Estás seguro de eliminar los datos del proveedor ?",
            confirm: function (button) {
                $("#EliminarProveedor").submit();
            },
            cancel: function (button) { },
            confirmButton: "SI",
            cancelButton: "NO"
        });
    })
    //Editar Proveedores
    $("#btnEditar").on("click", function () {
        if (fnValidaCampos()) {
            fn_msjConfirmacion({
                title: "CONFIRMACIÓN",
                text: "¿Estás seguro de actualizar los datos del proveedor ?",
                confirm: function (button) {
                    $("#EditarProveedor").submit();
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
    fnSoloLetras("vNombreProveedor");
    fnSoloAlfaNumericos("vDireccion");
    fnSoloNumerosU("vRuc");
    fnSoloNumerosU("vTelefono1");
    fnSoloNumerosU("vTelefono2");
    $("#vNombreProveedor").attr("maxlength", "50");
    $("#vDireccion").attr("maxlength", "250");
    $("#vRuc").attr("maxlength", "11");
    $("#vTelefono1").attr("maxlength", "9");
    $("#vTelefono2").attr("maxlength", "9");
}


function fnValidaCampos() {
    $("#hddMessage").html("");
    var br = false;

   
    var sNombreProveedor = $("#vNombreProveedor").val();
    var sDireccion= $("#vDireccion").val();
    var sRuc = $("#vRuc").val();
    var sTelefono1 = $("#vTelefono1").val();
    var sTelefono2 = $("#vTelefono2").val();

   
    if ($.trim(sNombreProveedor).length == 0) {
        br = true;
        $("#hddMessage").append("Por favor escriba el nombre del proveedor <br/>");
    }
    if ($.trim(sDireccion).length == 0) {
        br = true;
        $("#hddMessage").append("Por favor escriba la direccion del proveedor<br/>");
    }

    if ($.trim(sRuc).length == 0) {
        br = true;
        $("#hddMessage").append("Por favor escriba el ruc del proveedor <br/>");
    } else if ($.trim(sRuc).length < 11) {
        br = true;
        $("#hddMessage").append("El número de ruc son 11 digitos<br/>");
    }

    if ($.trim(sTelefono1).length == 0) {
        br = true;
        $("#hddMessage").append("Por favor escriba el número telefonico # 1 <br/>");
    } else if ($.trim(sTelefono1).length < 9) {
        br = true;
        $("#hddMessage").append("El número telefonico #1 debe tener 9 digitos <br/>");
    }

    if ($.trim(sTelefono2).length == 0) {
        br = true;
        $("#hddMessage").append("Por favor escriba el número telefonico #2 <br/>");
    } else if ($.trim(sTelefono2).length < 7) {
        br = true;
        $("#hddMessage").append("El número telefonico #2 debe tener 7 digitos <br/>");
    }
    else if ($.trim(sTelefono2).length > 7) {
        br = true;
        $("#hddMessage").append("El número telefonico #2 no debe tener más 7 digitos  <br/>");
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


