$(document).ready(function () {

    fnInicializaVariables();

    //Registra Rol
    $("#btnRegistrar").on("click", function () {
        if (fnValidaCampos()) {
            fn_msjConfirmacion({
                title: "CONFIRMACIÓN",
                text: "¿Estás seguro de registrar los datos del Usuario ?",
                confirm: function (button) {
                    //LoadingDialog.show();
                    $("#RegistrarUsuario").submit();
                },
                cancel: function (button) { },
                confirmButton: "SI",
                cancelButton: "NO"
            });
        }
    });
    // Eliminar Rol
    $("#btnEliminar").on("click", function () {
        fn_msjConfirmacion({
            title: "CONFIRMACIÓN",
            text: "¿Estás seguro de eliminar los datos del Usuario ?",
            confirm: function (button) {
                //LoadingDialog.show();
                $("#EliminarUsuario").submit();
            },
            cancel: function (button) { },
            confirmButton: "SI",
            cancelButton: "NO"
        });
    })
    //Editar Rol
    $("#btnEditar").on("click", function () {
        if (fnValidaCampos()) {
            fn_msjConfirmacion({
                title: "CONFIRMACIÓN",
                text: "¿Estás seguro de actualizar los datos del Usuario ?",
                confirm: function (button) {
                    //LoadingDialog.show();
                    $("#EditarUsuario").submit();
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
    fnSoloLetras("vNombreUsuario");
    fnSoloAlfaNumericos("vPassword");
    fnSoloLetras("vNombre");
    fnSoloLetras("vApellidos");
    $("#vNombreUsuario").attr("maxlength", "30");
    $("#vPassword").attr("type", "password");
    $("#vPassword").attr("maxlength", "20");
    $("#vNombreUsuario").attr("maxlength", "50");
    $("#vApellidos").attr("maxlength", "120");
}


function fnValidaCampos() {
    $("#hddMessage").html("");
    var br = false;


    var ddlRol = $("#iIdRol").val();
    var sNombreUsuario = $("#vNombreUsuario").val();
    var sPassword = $("#vPassword").val();
    var sNombre = $("#vNombre").val();
    var sApellidos = $("#vApellidos").val();
    var file = $("#files").val();

    if ($.trim(ddlRol) == 0) {
        br = true;
        $("#hddMessage").append("Por favor seleccione el rol del usuario a registrar <br/>");
    }

    //if ($.trim(file).length == 0)
    //{
    //    br = true;
    //    $("#hddMessage").append("Agrega una imagen <br/>");
    //}
    if ($.trim(sNombreUsuario).length == 0) {
        br = true;
        $("#hddMessage").append("Por favor escriba el nombre de usuario <br/>");
    }
    if ($.trim(sPassword).length == 0) {
        br = true;
        $("#hddMessage").append("Por favor escriba la constraseña del usuario<br/>");
    } else if ($.trim(sPassword).length < 6) {
        br = true;
        $("#hddMessage").append("La contraseña tiene que ser mayor a 5 digitos<br/>");
    }

    if ($.trim(sNombre).length == 0) {
        br = true;
        $("#hddMessage").append("Por favor escriba el nombre del usuario<br/>");
    }

    if ($.trim(sApellidos).length == 0) {
        br = true;
        $("#hddMessage").append("Por favor escriba el apellido(s) del usuario<br/>");
    }

    if ($("input[name='iEstado']:radio").is(':checked') == false) {
        br = true;
        $("#hddMessage").append("Por favor seleccione el estado <br/>");
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


