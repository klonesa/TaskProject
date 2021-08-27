$(document).ready(function() {
    $("#tableMain").DataTable({
    aaSorting: [],
    responsive: true,

    columnDefs: [
      {
        responsivePriority: 1,
        targets: 0
      },
      {
        responsivePriority: 2,
        targets: -1
      }
    ]
  });

  $(".dataTables_filter input")
    .attr("placeholder", "Search here...")
    .css({
      width: "300px",
      display: "inline-block"
    });

    $('[data-toggle="tooltip"]').tooltip();

    //function studentList() {
    //    $.ajax({
    //        method: 'GET',
    //        url: '../Student/StudentList',
    //        content: "application/html;",
    //        dataType: 'html',
    //    }).done(function (data) {
    //        $("#StudentList").html(data);
    //    }).fail(function () {
    //        console.log("hata");
    //    });
    //}


});

