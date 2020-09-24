$(document).ready(function () {
    //var urlVar = getUrlVars();

    //var id = urlVar["id"];

    //if (id > 0) {
    //    getData(id);
    //}
    //Get Organization

    //$.get("/api/SocialMedias", function (data) {
    //    var $el = $("#MediaName");
    //    $el.empty(); // remove old options
    //    $el.append($("<option></option>")
    //        .attr("value", '').text(''));
    //    $.each(data, function (value, key) {
    //        $el.append($('<option>',
    //            {
    //                value: key.id,
    //                text: key.name
    //            }));
    //    });
    //});


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
        vm.mediaName = $("#MediaName").val();
        vm.mediaLink = $("#MediaLink").val();
        vm.userName = $("#UserName").val();
        vm.email = $("#Email").val();
      



        if (id == "" || id == 0 || id == null) {
            $.ajax({
                url: "/api/SocialMedias",
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
                url: "/api/SocialMedias/" + id,
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
    $("#MediaName").val("");
    $("#MediaLink").val("");
    $("#UserName").val("");
    $("#Email").val("");
  

}

function getData(id) {
    $.get("/api/SocialMedias/" + id)
        .done(function (data) {
            $("#Id").val(data.id);
            //  $("#GeneralInformationId").val(data.generalInformationId);
            $("#MediaName").val(data.mediaName);
            $("#MediaLink").val(data.mediaLink);
            $("#UserName").val(data.userName);
            $("#Email").val(data.email);

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
                    url: "/api/SocialMedias/" + id,
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


    $("#SocialMediaList").DataTable().destroy();

    $("#SocialMediaList").DataTable({
        retrieve: true,
        paging: true,
        ajax: {
            url: "/api/SocialMedias/GetInfoById?id=" + id,
            dataSrc: ""
        },
        columns: [
            {
                data: "userName"
            },

            {
                data: "email"
            },
            {
                data: "mediaName"
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