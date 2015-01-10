/// <reference path="../jquery-2.1.3.min.js" />
var CreateModule = CreateModule || {};
var contractItems = ["contractNumber", "contractDate", "contractDate2", 'contractNumber', 'contractDate', 'contractDate2', 'community', 'contractEmployer', 'contractAddress', 'agencyNumber', 'contractEmployee', 'employeeCity', 'employeeIDN', 'identityCardNumber', 'identityCardCreateDate', 'firstSpecialty', 'firstDiplomaNumber', 'firstDiplomaDate', 'firstDiplomaCreator', 'secondSpecialty', 'secondDiplomaNumber', 'secondDiplomaDate', 'secondDiplomaCreator', 'workExperienceYears', 'workExperienceMonths', 'workExperienceDays', 'workExperienceYearsWords', 'workExperienceMonthsWords', 'workExperienceDaysWords', 'workPosition', 'positionCode', 'workPlace', 'workTime', 'testTerm', 'payment', 'paymentWords', 'dateStartJob'];

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

    var submitContractForm = function (event) {
        var newContract = {};
        for (var i = 0; i < contractItems.length ; i++) {
            newContract[contractItems[i]] = $('#' + contractItems[i]).val();
        }

        CreateModule.Requests.saveContractRequest(newContract);
    }

    return {
        setVisibility: setVisibility,
        manageFormVisibility: manageFormVisibility,
        submitContractForm: submitContractForm,

    }
}()

CreateModule.Requests = function () {
    var saveContractRequest = function (newContract) {
        $.ajax({
            type: 'POST',
            url: '/Create/NewContract/',
            data: newContract,
            success: function (result) {
                window.location = "/Home/AllDocs"
            },
            error: function (result) {
                alert(result.status);
            }
        })
    }

    return {
        saveContractRequest: saveContractRequest
    }
}()