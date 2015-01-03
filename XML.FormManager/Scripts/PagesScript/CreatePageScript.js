/// <reference path="../jquery-2.1.3.min.js" />
var CreateModule = CreateModule || {};

$(document).ready(function () {
    CreateModule.CodeLogic.setVisibility();
    CreateModule.CodeLogic.manageFormVisibility();
})

CreateModule.CodeLogic = function () {
    var manageFormVisibility = function () {
        $('#formSelect').on('change', function () {
            var selectedForm = $(this).val();
            $('.XmlForm').hide();
            $(selectedForm).show();
        })
    }

    var setVisibility = function () {
        var selectedForm = $('#formSelect').val();
        $('.XmlForm').hide();
        $(selectedForm).show();
    }

    return {
        setVisibility: setVisibility,
        manageFormVisibility: manageFormVisibility,

    }
}()