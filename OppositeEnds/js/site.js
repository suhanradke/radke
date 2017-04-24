
var $sidebarAndWrapper = $("#adminNav,#swap2");

$("#sidebarToggle").on("click", function () {
    $sidebarAndWrapper.toggleClass("hide-sidebar");
   

    if ($sidebarAndWrapper.hasClass("hide-sidebar")) {
        $(this).text("Show Sidebar");

    } else {
        $(this).text("Hide Sidebar");
    }

});


//$("#sidebarToggle").click(function () {
//    $("#adminNav").toggle();
//    //debugger;
//});

  