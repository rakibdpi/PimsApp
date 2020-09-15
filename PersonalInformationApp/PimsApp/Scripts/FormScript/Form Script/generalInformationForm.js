$(document).ready(function () {

    //personal Number Load
    GenaratePersonalNumber();


    //Get Department
    $.get("/api/Departments", function (data) {
        var $el = $("#DepartmentId");
        $el.empty(); // remove old options
        $el.append($("<option></option>")
            .attr("value", '').text(''));
        $.each(data, function (value, key) {
            $el.append($('<option>',
                {
                    value: key.id,
                    text: key.name
                }));
        });
    });


    //Get Designation
    $.get("/api/Designations", function (data) {
        var $el = $("#DesignationId");
        $el.empty(); // remove old options
        $el.append($("<option></option>")
            .attr("value", '').text(''));
        $.each(data, function (value, key) {
            $el.append($('<option>',
                {
                    value: key.id,
                    text: key.name
                }));
        });
    });


});



$(document.body).on("click",
    "#btnSubmit",
    function () {
        var vm = {};
        var id = $("#Id").val();
        vm.employeId = $("#EmployeId").val();
        vm.nameBangla = $("#NameBangla").val();
        vm.nameEnglish = $("#NameEnglish").val();
        vm.fatherName = $("#FatherName").val();
        vm.motherName = $("#MotherName").val();
        vm.bithDate = $("#BithDate").val();
        vm.birthPlace = $("#BirthPlace").val();
        vm.nationality = $("#Nationality").val();
        vm.presentAddress = $("#PresentAddress").val();
        vm.permanentAddress = $("#PermanentAddress").val();
        vm.bloodGroup = $("#BloodGroup").val();
        vm.religion = $("#Religion").val();
        vm.meritialStatus = $("#MeritialStatus").val();
        vm.phoneNo = $("#PhoneNo").val();
        vm.email = $("#Email").val();
        vm.nationalId = $("#NationalId").val();
        vm.designationId = $("#DesignationId").val();
        vm.departmentId = $("#DepartmentId").val();
        vm.position = $("#Position").val();
        vm.jobJoiningDate = $("#JobJoiningDate").val();


        if (id == "" || id == 0 || id == null) {
            $.ajax({
                url: "/api/GeneralInformations",
                data: vm,
                type: "POST",
                success: function (e) {
                    if (e > 0) {
                        toastr.success("Save Success", "Success!!!");
                        //refressForm();
                        //loadHistoryTable();
                        GenaratePersonalNumber();

                    } else {
                        toastr.warning("Save Fail", "Warning!!!");
                    }
                },
                error: function (request, status, error) {
                    var response = jQuery.parseJSON(request.responseText);
                    toastr.error(response.message, "Error");
                }
            });
        } else {
            vm.id = id;

            $.ajax({
                url: "/api/GeneralInformations/" + id,
                data: vm,
                type: "PUT",
                success: function (e) {
                    if (e > 0) {
                        toastr.success("Update Success", "Success!!!");
                        refressForm();
                        loadHistoryTable();
                    } else {
                        toastr.warning("Update Fail.", "Warning!!!");
                    }
                },
                error: function (request, status, error) {
                    var response = jQuery.parseJSON(request.responseText);
                    toastr.error(response.message, "Error");
                }
            });

        }
    });









function GenaratePersonalNumber() {

    $.get("/api/GeneralInformations/GenerateEmployeId",
        function (data) {
            if (data !== null) {
                $("#EmployeId").val(data);
            }

        });
}