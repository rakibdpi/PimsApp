$(document).ready(function () {

    //Get university
    $.get("/api/University", function (data) {
        var $el = $("#UniversityId");
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
        vm.examName = $("#ExamName").val();
       vm.universityId = $("#UniversityId").val();
        vm.generalInformationId = $("#GeneralInformationId").val();
        vm.subject = $("#Subject").val();
        vm.year = $("#Year").val();
        vm.result = $("#Result").val();
        vm.schoolOrCallege = $("#SchoolOrCallege").val();


        if (id == "" || id == 0 || id == null) {
            $.ajax({
                url: "/api/EducationInformations",
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
                url: "/api/EducationInformations/" + id,
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
    $("#ExamName").val("");
    $("#Subject").val("");
    $("#Year").val("");
    $("#Result").val("");
    $("#SchoolOrCallege").val("");
    $("#UniversityId").val("");
   
    
}


function getData(id) {
    $.get("/api/EducationInformations/" + id)
        .done(function (data) {


            $("#Id").val(data.id);
            $("#ExamName").val(data.examName);
            $("#UniversityId").val(data.universityId);
            $("#GeneralInformationId").val(data.generalInformationId);
            $("#Subject").val(data.subject);
            $("#Result").val(data.result);
            $("#Year").val(data.year);
            $("#SchoolOrCallege").val(data.schoolOrCallege);
          
         

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
                    url: "/api/EducationInformations/" + id,
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


    $("#eduList").DataTable().destroy();

    $("#eduList").DataTable({
        retrieve: true,
        paging: true,
        ajax: {
            url: "/api/EducationInformations/GetInfoById?id=" + id,
            dataSrc: ""
        },
        columns: [
            {
                data: "examName"
            },
            {
                data: "schoolOrCallege"
            },
            {
                data: "subject"
            },
            {
                data: "result"
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
