
//*************************************************************
// UTILS
//*************************************************************

function fnSoloLetras(sCampo) {
    $("#" + sCampo).keyup(function () {
        if (this.value.match(/[^a-zA-Z ]/g)) {
            this.value = this.value.replace(/[^a-zA-Z ]/g, '');
        }
    });
}

function fnSoloNumeros(sCampo) {
    $("#" + sCampo).keyup(function () {
        if (this.value.match(/[^0-9,]/g)) {
            this.value = this.value.replace(/[^0-9]/g, '');
        }
    });

}

function fnSoloNumerosU(sCampo) {
    $("#" + sCampo).keyup(function () {
        if (this.value.match(/[^0-9]/g)) {
            this.value = this.value.replace(/[^0-9]/g, '');
        }
    });

}


function fnSoloAlfaNumericos(sCampo) {
    $("#" + sCampo).keyup(function () {
        if (this.value.match(/[^a-zA-Z0-9 .]/g)) {
            this.value = this.value.replace(/[^a-zA-Z0-9 .]/g, '');
        }
    });

}

