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


   // loadHistoryTable();



    $("#txtFindTrainee").autocomplete({
       source: function (request, response) {
           $.ajax({
               url: "/api/GeneralInformations/Search",
               data: { query: request.term },
               type: "GET"
           }).done(function (data) {
               response($.map(data, function (item) {
                   return { label: item.employeId + " " + item.nameEnglish, value: item.employeId }
               }));
           });
       },
       minLength: 2,
       select: function (e, ui) {

           $.get("/api/GeneralInformations/SearchAutoComplete", { pNumber: ui.item.value })
               .done(function (data) {
                   //console.log(pData);
                  // window.pId = data.id;
                   $("#Id").val(data.id);
                   $("#SearchName").val(data.nameEnglish);
                   $("#SearchPhoneNo").val(data.phoneNo);

                   loadHistoryTable(data.id);

               });

       }
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
                        loadHistoryTable(e);
                        GenaratePersonalNumber();
                        refreshForm();

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
                        refreshForm();
                        loadHistoryTable(e);
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

function refreshForm() {
    $("#NameBangla").val("");
    $("#NameEnglish").val("");
    $("#FatherName").val("");
    $("#MotherName").val("");
    $("#BithDate").val("");
    $("#BirthPlace").val("");
    $("#Nationality").val("");
    $("#PresentAddress").val("");
    $("#PermanentAddress").val("");
    $("#BloodGroup").val("");
    $("#Religion").val("");
    $("#MeritialStatus").val("");
    $("#PhoneNo").val("");
    $("#Email").val("");
    $("#NationalId").val("");
    $("#DesignationId").val("");
    $("#DepartmentId").val("");
    $("#Position").val("");
    $("#JobJoiningDate").val("");
}
function getData(id) {
    $.get("/api/GeneralInformations/" + id)
        .done(function (data) {
            $("#Id").val(data.id);
            $("#NameBangla").val(data.nameBangla);
            $("#NameEnglish").val(data.nameEnglish);
            $("#FatherName").val(data.fatherName);
            $("#MotherName").val(data.motherName);
            $("#BirthDate").val(data.birthDate);
            $("#BirthPlace").val(data.birthPlace);
            $("#Nationality").val(data.nationality);
            $("#PresentAddress").val(data.presentAddress);
            $("#PermanentAddress").val(data.permanentAddress);
            $("#BloodGroup").val(data.bloodGroup);
            $("#Religion").val(data.religion);
            $("#Gender").val(data.gender);
            $("#MeritialStatus").val(data.meritialStatus);
            $("#PhoneNo").val(data.phoneNo);
            $("#Email").val(data.email);
            $("#NationalId").val(data.nationalId);
            $("#DepartmentId").val(data.departmentId);
            $("#DesignationId").val(data.designationId);
            $("#Position").val(data.position);
            $("#JobJoiningDate").val(data.jobJoiningDate);

            if (data.isActive == 1) {
                $("#IsActive").prop('checked', true);
                $(".icheckbox_minimal-blue").addClass('checked').attr('aria-checked', 'true');
            }
            else {
                $("#IsActive").prop('checked', false);
                $(".icheckbox_minimal-blue").removeClass('checked').attr('aria-checked', 'false');
            }
        });
}



$(document.body).on("click",
    ".js-edit",
    function () {
        refreshForm();
        var button = $(this);
        var id = button.attr("data-id");
        getData(id);
    });



$(document.body).on("click", ".js-delete", function () {
    var button = $(this);
    var id = button.attr("data-id");
    bootbox.confirm("Are You Delete This Data?",
        function (result) {
            if (result) {
                $.ajax({
                    url: "/api/GeneralInformations/" + id,
                    method: "DELETE",
                    success: function () {
                        button.parents("tr").remove();
                        toastr.success("Delete Success");
                    },
                    error: function (request, status, error) {
                        var response = jQuery.parseJSON(request.responseText);
                        toastr.error(response.message, "Error");
                    }
                });
            }
        });
});

function loadHistoryTable(id) {


    $("#employeList").DataTable().destroy();

    $("#employeList").DataTable({
        retrieve: true,
        paging: true,
        ajax: {
            url: "/api/GeneralInformations/GetInfoById?id=" + id,
            dataSrc: ""
        },
        columns: [
            {
                data: "employeId"
            },
            {
                data: "nameEnglish"
            },
            {
                data: "phoneNo"
            },
            {
                data: "email"
            },
            {
                data: "nationalId"
            },
            {
                data: "id",
                render: function (data) {
                    return "<a class='btn btn-info btn-sm js-edit' data-id=" + data + " ><i class='fa fa-pencil-square fa-2x ' aria-hidden='false'></i></a>";
                }
            },
            {
                data: "id",
                render: function (data) {
                    return "<a class='btn-link js-delete'  data-id=" + data + "><i class='fa fa-trash fa-2x' aria-hidden='true' style='color: #d9534f;'></i></a>";
                }
            }
        ]
    });


}