$(document).ready(function () {
    $.ajaxSetup({ cache: false });
});

function RenderActions(RenderActionstring) {
    $("#OpenDialog").load(RenderActionstring);
};


function CreateNewCompany() {
    $.ajax({
        url: '/Company/Create/',
        type: 'POST',
        data: $('form').serialize(),
        success: function (response) {
            Clean();
            $('#btnCloseModal').click();
            var raw = '';
            raw += "<tr id=" + response.Id + '>';
            raw += "<td>" + response.Id + "</td>";
            raw += "<td>" + response.CompanyDetail + "</td>";
            raw += "<td>" + "<button class = \"btn btn-sm btn-primary\" data-toggle=\"modal\" data-target=\"#modalCreate\" onclick=\"RenderActions('/Company/Edit/' + " + response.Id + ")\">Edit</button> | " +
                "<button class = \"btn btn-sm btn-danger\" data-toggle=\"modal\" data-target=\"#modalCreate\" onclick=\"RenderActions('/Company/Delete/' + " + response.Id + ")\">Delete</button></td>";
            raw += "</tr>";
            $('#indexTbody').append(raw);
        },
        error: function (err) { alert("Error: " + err.responseText); }
    })
};

function CreateNewUser() {
    $.ajax({
        url: '/User/Create/',
        type: 'POST',
        data: $('form').serialize(),
        success: function (response) {
            Clean();
            $('#btnCloseModal').click();
            var raw = '';
            raw += "<tr id=" + response.Id + '>';
            raw += "<td>" + response.Id + "</td>";
            raw += "<td>" + response.UserDetail + "</td>";
            raw += "<td>" + "<button class = \"btn btn-sm btn-primary\" data-toggle=\"modal\" data-target=\"#modalCreate\" onclick=\"RenderActions('/User/Edit/' + " + response.Id + ")\">Edit</button> | " +
                "<button class = \"btn btn-sm btn-danger\" data-toggle=\"modal\" data-target=\"#modalCreate\" onclick=\"RenderActions('/User/Delete/' + " + response.Id + ")\">Delete</button></td>";
            raw += "</tr>";
            $('#indexTbody').append(raw);
        },
        error: function (err) { alert("Error: " + err.responseText); }
    })
};



function EditCompany(id) {
    $.ajax({
        url: '/Company/Edit/' + id,
        type: 'POST',
        data: $('form').serialize(),
        success: function (res) {
            var keys = ["Id", "CompanyDetail"];
            $('#' + res.Id + ' td').each(function (i) {
                $(this).text(res[keys[i]]);
            });
            $('#btnCloseModal').click();
        },
        error: function (err) { alert("Error: " + err.responseText); }
    })
};
function DeleteCompany(id) {
    document.getElementById(id).remove();
    $.ajax({
        url: '/Company/Delete/' + id,
        data: $('form').serialize(),
        type: 'POST',
        success: function () { $('#btnCloseModal').click(); },
        error: function (err) { alert("Error: " + err.responseText); }
    });
};

function EditUser(id) {
    $.ajax({
        url: '/User/Edit/' + id,
        type: 'POST',
        data: $('form').serialize(),
        success: function (res) {
            var keys = ["Id", "RoleId","CompanyId","UserDetail"];
            $('#' + res.Id + ' td').each(function (i) {
                $(this).text(res[keys[i]]);
            });
            $('#btnCloseModal').click();
        },
        error: function (err) { alert("Error: " + err.responseText); }
    })
};
function DeleteCompany(id) {
    document.getElementById(id).remove();
    $.ajax({
        url: '/User/Delete/' + id,
        data: $('form').serialize(),
        type: 'POST',
        success: function () { $('#btnCloseModal').click(); },
        error: function (err) { alert("Error: " + err.responseText); }
    });
};

function Clean() {
    $('#modalCreate').find('textarea,input').val('');
};
