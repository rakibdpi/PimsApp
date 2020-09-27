$(document).ready(function () {

        // AutoComplete function

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
                    $("#GeneralInformationId").val(data.id);
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
        vm.generalInformationId = $("#GeneralInformationId").val();
        vm.name = $("#Name").val();
        vm.relation = $("#Relation").val();
        vm.phoneNo = $("#PhoneNo").val();
        vm.address = $("#Address").val();
        vm.email = $("#Email").val();
        

        if (id == "" || id == 0 || id == null) {
            $.ajax({
                url: "/api/EmergencyContact",
                data: vm,
                type: "POST",
                success: function (e) {
                    if (e > 0) {
                        toastr.success("Save Success", "Success!!!");
                        loadHistoryTable(e);

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
                url: "/api/EmergencyContact/" + id,
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

function refreshForm() {
    $("#Id").val("");;
    $("#GeneralInformationId").val("");;
    $("#Name").val("");
    $("#Relation").val("");
    $("#PhoneNo").val("");
    $("#Address").val("");
    $("#Email").val("");
}


function loadHistoryTable(id) {


    $("#EmergencyContactHistory").DataTable().destroy();

    $("#EmergencyContactHistory").DataTable({
        retrieve: true,
        paging: true,
        ajax: {
            url: "/api/EmergencyContact/GetInfoById?id=" + id,
            dataSrc: ""
        },
        columns: [
            {
                data: "name"
            },
            {
                data: "relation"
            },
            {
                data: "phoneNo"
            },
            {
                data: "address"
            },
            {
                data: "email"
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


function getData(id) {
    $.get("/api/EmergencyContact/" + id)
        .done(function (data) {
            $("#Id").val(data.id);
            $("#GeneralInformationId").val(data.generalInformationId);
            $("#Name").val(data.name);
            $("#Relation").val(data.relation);
            $("#PhoneNo").val(data.phoneNo);
            $("#Email").val(data.email);
            $("#Address").val(data.address);


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
    "#btnRefresh",
    function () {
        refreshForm();
    });

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
                    url: "/api/EmergencyContact/" + id,
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
