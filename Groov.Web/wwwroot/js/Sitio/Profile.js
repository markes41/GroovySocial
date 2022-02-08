(function (self, $, undefined) {
    self.Inicializar = function () {
        //Functions
        $('#js-Agregar').on('click', AgregarPersona_Click);
    };

    function AgregarPersona_Click() {

    }


}(windows.Profile = window.Profile || {}, jQuery));

$(function () {
    Profile.Inicializar();
});