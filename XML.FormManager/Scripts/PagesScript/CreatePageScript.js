/// <reference path="../jquery-2.1.3.min.js" />
var CreateModule = CreateModule || {};
var contractItems = ["contractNumber", "contractDate", "contractDate2", 'contractNumber', 'contractDate', 'contractDate2', 'community', 'contractEmployer', 'contractAddress', 'agencyNumber', 'contractEmployee', 'employeeCity', 'employeeIDN', 'identityCardNumber', 'identityCardCreateDate', 'firstSpecialty', 'firstDiplomaNumber', 'firstDiplomaDate', 'firstDiplomaCreator', 'secondSpecialty', 'secondDiplomaNumber', 'secondDiplomaDate', 'secondDiplomaCreator', 'workExperienceYears', 'workExperienceMonths', 'workExperienceDays', 'workExperienceYearsWords', 'workExperienceMonthsWords', 'workExperienceDaysWords', 'workPosition', 'positionCode', 'workPlace', 'workTime', 'testTerm', 'payment', 'paymentWords', 'dateStartJob'];
var internshipItems = ["internshipNumber", "internshipDate", "internshipCompany", "internshipCompanyTown", "internshipCompanyNumber", "internshipCompanyBulstat", "internshipCompanyLeaderName", "internshipCompanyLeaderEgn", "internshipStudentName", "internshipStudentEgn", "internshipStudentLK", "internshipStudentLKMVR", "internshipStudentLKDate", "internshipStudentAddressTown", "internshipStudentAddressStreet", "internshipStudentAddressStreetNumber", "internshipStudentTelephoneNumber", "internshipStudentUniversity", "internshipStudentUniversityTown", "internshipStudentCourse", "internshipStudentGrade", "internshipStudentFaculty", "internshipStudentNumber", "internshipName", "internshipTasks", "internshipMentorName", "internshipMentorPosition", "internshipAcquiredSkills", "internshipRecommendations", "internshipAppraisalWord", "internshipAppraisal", "internshipCurrentDate", "internshipCurrentTown"];
var mentorItems = ["mentorNumber", "mentorDay", "mentorMonth", "mentorYear", "mentorFirstName", "mentorMiddleName", "mentorLastName", "mentorOrganization", "mentorFirstNameStudent", "mentorMiddleNameStudent", "mentorLastNameStudent", "mentorStudentDay", "mentorStudentMonth", "mentorStudentYear", "mentorStudentArrivalHour", "mentorStudentArrivalMinutes", "mentorStudentLeavingHour", "mentorStudentLeavingMinutes", "mentorStudentDescription", "mentorStudentRating"];
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

    var submitInternshipForm = function (event) {
        var newInternship = {};
        for (var i = 0; i < internshipItems.length ; i++) {
            newInternship[internshipItems[i]] = $('#' + internshipItems[i]).val();
        }

        CreateModule.Requests.saveInternshipRequest(newInternship);
    }
    var submitMentorForm = function (event) {
        var newMentor = {};
        for (var i = 0; i < mentorItems.length ; i++) {
            newMentor[mentorItems[i]] = $('#' + mentorItems[i]).val();
        }

        CreateModule.Requests.saveMentorRequest(newMentor);
    }

    return {
        setVisibility: setVisibility,
        manageFormVisibility: manageFormVisibility,
        submitContractForm: submitContractForm,
        submitInternshipForm: submitInternshipForm,
        submitMentorForm: submitMentorForm,
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

    var saveInternshipRequest = function (newInternship) {
        $.ajax({
            type: 'POST',
            url: '/Create/NewInternship/',
            data: newInternship,
            success: function (result) {
                window.location = "/Home/AllDocs"
            },
            error: function (result) {
                alert(result.status);
            }
        })
    }
    var saveMentorRequest = function (newMentor) {
        $.ajax({
            type: 'POST',
            url: '/Create/NewMentor/',
            data: newMentor,
            success: function (result) {
                window.location = "/Home/AllDocs"
            },
            error: function (result) {
                alert(result.status);
            }
        })
    }

    return {
        saveContractRequest: saveContractRequest,
        saveInternshipRequest: saveInternshipRequest,
        saveMentorRequest: saveMentorRequest
    }
}()