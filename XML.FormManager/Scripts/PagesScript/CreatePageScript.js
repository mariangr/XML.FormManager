/// <reference path="../jquery-2.1.3.min.js" />
var CreateModule = CreateModule || {};

$(document).ready(function () {
    CreateModule.CodeLogic.setVisibility();
    CreateModule.CodeLogic.manageFormVisibility();
})

var NewContractVM = function (contractNumber, contractDate, contractDate2, community, contractEmployer, contractAddress, agencyNumber, contractEmployee, employeeCity, employeeIDN, identityCardNumber, identityCardCreateDate, firstSpecialty, firstDiplomaNumber, firstDiplomaDate, firstDiplomaCreator, secondSpecialty, secondDiplomaNumber, secondDiplomaDate, secondDiplomaCreator, workExperienceYears, workExperienceMonths, workExperienceDays, workExperienceYearsWords, workExperienceMonthsWords, workExperienceDaysWords, workPosition, positionCode, workPlace, workTime, testTerm, payment, paymentWords, dateStartJob) {
    var self = this;
    self.contractNumber = contractNumber;
    self.contractDate = contractDate;
    self.contractDate2 = contractDate2;
    self.community = community;
    self.contractEmployer = contractEmployer;
    self.contractAddress = contractAddress;
    self.agencyNumber = agencyNumber;
    self.contractEmployee = contractEmployee;
    self.employeeCity = employeeCity;
    self.employeeIDN = employeeIDN;
    self.identityCardNumber = identityCardNumber;
    self.identityCardCreateDate = identityCardCreateDate;
    self.firstSpecialty = firstSpecialty;
    self.firstDiplomaNumber = firstDiplomaNumber;
    self.firstDiplomaDate = firstDiplomaDate;
    self.firstDiplomaCreator = firstDiplomaCreator;
    self.secondSpecialty = secondSpecialty;
    self.secondDiplomaNumber = secondDiplomaNumber;
    self.secondDiplomaDate = secondDiplomaDate;
    self.secondDiplomaCreator = secondDiplomaCreator;
    self.workExperienceYears = workExperienceYears;
    self.workExperienceMonths = workExperienceMonths;
    self.workExperienceDays = workExperienceDays;
    self.workExperienceYearsWords = workExperienceYearsWords;
    self.workExperienceMonthsWords = workExperienceMonthsWords;
    self.workExperienceDaysWords = workExperienceDaysWords;
    self.workPosition = workPosition;
    self.positionCode = positionCode;
    self.workPlace = workPlace;
    self.workTime = workTime;
    self.testTerm = testTerm;
    self.payment = payment;
    self.paymentWords = paymentWords;
    self.dateStartJob = dateStartJob;
}

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
        var newContract = new NewContractVM(
            contractNumber = $('#contractNumber').val(),
            contractDate = $('#contractDate').val(),
            contractDate2 = $('#contractDate2').val(),
            community = $('#community').val(),
            contractEmployer = $('#contractEmployer').val(),
            contractAddress = $('#contractAddress').val(),
            agencyNumber = $('#agencyNumber').val(),
            contractEmployee = $('#contractEmployee').val(),
            employeeCity = $('#employeeCity').val(),
            employeeIDN = $('#employeeIDN').val(),
            identityCardNumber = $('#identityCardNumber').val(),
            identityCardCreateDate = $('#identityCardCreateDate').val(),
            firstSpecialty = $('#firstSpecialty').val(),
            firstDiplomaNumber = $('#firstDiplomaNumber').val(),
            firstDiplomaDate = $('#firstDiplomaDate').val(),
            firstDiplomaCreator = $('#firstDiplomaCreator').val(),
            secondSpecialty = $('#secondSpecialty').val(),
            secondDiplomaNumber = $('#secondDiplomaNumber').val(),
            secondDiplomaDate = $('#secondDiplomaDate').val(),
            secondDiplomaCreator = $('#secondDiplomaCreator').val(),
            workExperienceYears = $('#workExperienceYears').val(),
            workExperienceMonths = $('#workExperienceMonths').val(),
            workExperienceDays = $('#workExperienceDays').val(),
            workExperienceYearsWords = $('#workExperienceYearsWords').val(),
            workExperienceMonthsWords = $('#workExperienceMonthsWords').val(),
            workExperienceDaysWords = $('#workExperienceDaysWords').val(),
            workPosition = $('#workPosition').val(),
            positionCode = $('#positionCode').val(),
            workPlace = $('#workPlace').val(),
            workTime = $('#workTime').val(),
            testTerm = $('#testTerm').val(),
            payment = $('#payment').val(),
            paymentWords = $('#paymentWords').val(),
            dateStartJob = $('#dateStartJob').val())

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