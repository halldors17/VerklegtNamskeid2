// Write your JavaScript code.

$("#hello-world-button").click(function() { 
    $.get("Home/GetText", function(data, status) {
        $("#hello-world").text(data);
    });
});

var getCategories = $("#category-menu");

getCategories.click(function() {
    $.get("Category/GetAllCategories", function(data, status) {
        var markup = "<li><a asp-controller=&quotCategory&quot asp-action=&quotDetails&quot asp-route-id=&quot" + data.Id + "&quot>" + data.Name + "</a></li>";
        $("#category-menu").append(markup);
    });
});