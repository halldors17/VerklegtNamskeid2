
$("#category-button").click( function() {
    $.get("/Category/GetCategories", function(data, status) {
        if(!$("#category-menu").hasClass("list-full")) {
            for(var i = 0; i < data.length; i++) {
                var markup = "<li><a href='http://localhost:5000/Category/Details/" + data[i].id + "'>" + data[i].name + "</a></li>";
                $("#category-menu").append(markup);
            }
            $("#category-menu").addClass("list-full");
        }
    });
});

function addToCart(id) {
    $.ajax({
        type: "POST",
        url: "/Account/AddToCart",
        data: {id: id},
        dataType: "json",
    });
};

//orderDetails(@order.Id)
function orderDetails(id) {
    $.ajax({
        type: "POST",
        url: "/Account/OrderDetails",
        data: {orderId: id},
        dataType: "json",
    });
}

//removeCart(@item.Id)
function removeCart(id) {
    $.ajax({
        type: "POST",
        url: "/Account/RemoveCart",
        data: {id: id},
        dataType: "json",
    });
}

//changeQuantity()
function changeQuantity() {
    var quantity = $("#quantity").val();
    var bookId = $("#book-id").text();
    console.log(quantity);
    console.log(bookId);
    $.ajax({
        type: "POST",
        url: "/Account/ChangeQuantity",
        data: {quantity: quantity, bookId: bookId},
        dataType: "json",
    });
}

$("#update-quantity-btn").on("click", changeQuantity);


/*
            //var markup = "<li><a asp-controller='Category' asp-action='Details' asp-route-id='" + data.Id + "'>" + data.Name + "</a></li>";
            //var markup = "<li>" + data.Name + "</li>";
            //$("#category-menu").append(markup);
*/