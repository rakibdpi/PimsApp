
$(document.body).on("click",
    "#btnPimsReport",
    function () {

        var radioValue = $("input[name='PimsReport']:checked").val();


        //All Employee
        if (radioValue === "AllEmployee") {
          
            $.ajax({
                url: "/Report/GetAllEmployee",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    if (data != "" && data != null) {
                        setTimeout(function () {
                            $("#pdf").attr("href", data);
                            var reportBox = $("#pdf").fancybox({
                                'frameWidth': 85,
                                'frameHeight': 495,
                                'overlayShow': true,
                                'hideOnContentClick': false,
                                'type': 'iframe',
                                helpers: {
                                    // prevents closing when clicking OUTSIDE fancybox
                                    overlay: { closeClick: false }
                                }
                            }).trigger('click');
                        }, 1000);
                    }
                }
            });
        }

        //Individual 








    });
