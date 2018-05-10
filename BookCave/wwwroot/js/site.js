/*
$( function() {
    $.get("Category/GetCategories", function(data, status) {
        for(var i = 0; i < data.length; i++) {
            var markup = "<li>" + data[i].Name + "</li>";
            $("#category-menu").append(markup);
        }
    });
});
*/
function addToCart(id) {
    $.ajax({
        type: "POST",
        url: "/Account/AddToCart",
        data: {bookId: id},
        dataType: "json",
    });
};

/*orderDetails(@order.Id)*/
function orderDetails(id) {
    $.ajax({
        type: "POST",
        url: "/Account/OrderDetails",
        data: {orderId: id},
        dataType: "json",
    });
}

/*
            //var markup = "<li><a asp-controller='Category' asp-action='Details' asp-route-id='" + data.Id + "'>" + data.Name + "</a></li>";
            //var markup = "<li>" + data.Name + "</li>";
            //$("#category-menu").append(markup);
*/