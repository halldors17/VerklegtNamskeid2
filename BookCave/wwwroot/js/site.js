// Write your JavaScript code.
$(document).ready(function () {
    $( function() {
        $.get("Category/GetCategories", function(data, status) {
            for(var i = 0; i < data.length; i++) {
                var markup = "<li>" + data[i].Name + "</li>";
                $("#category-menu").append(markup);
            }
        });
    });
    $("#hello-world-button").click(function() {
        $.post("Account/AddToCart", {
        });
    });
  });
function addToCart(id) {
    var bookId = id
    $.post("Account/AddToCart", bookId).fail(function(err) {
        alert("something went wrong!!!");
    });
}

addStudentButton.click(function() { 
    var newStudent = { name: nameInput.val(), age: ageInput.val() };
    console.log(newStudent);
    $.post("Home/Add", newStudent, function(data, status) {
            var markup = "<tr><td>" + newStudent.name + "</td> <td>" + newStudent.age + "</td> </tr>";
            $("#student-table2").append(markup);    
    }).fail(function(err) {
        alert("something went wrong!!!");
    }) ;
});
/*
$("#hello-world-button").click(function() { 
    $.get("Home/GetText", function(data, status) {
        $("#hello-world").text(data);
    });
});
            //var markup = "<li><a asp-controller='Category' asp-action='Details' asp-route-id='" + data.Id + "'>" + data.Name + "</a></li>";
            //var markup = "<li>" + data.Name + "</li>";
            //$("#category-menu").append(markup);
*/