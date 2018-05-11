
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

$(".category-list").click( function() {
    $.get("/Category/GetCategories", function(data, status) {
        if(!$(".category-list").hasClass("list-full")) {
            for(var i = 0; i < data.length; i++) {
                var markup = "<option value='" + data[i].id + "'>" + data[i].name + "</option>";
                $(".category-list").append(markup);
            }
            $(".category-list").addClass("list-full");
        }
    });
});

$(".author-list").click( function() {
    $.get("/Author/GetAuthors", function(data, status) {
        if(!$(".author-list").hasClass("list-full")) {
            for(var i = 0; i < data.length; i++) {
                var markup = "<option value='" + data[i].id + "'>" + data[i].name + "</option>";
                $(".author-list").append(markup);
            }
            $(".author-list").addClass("list-full");
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


$(".update-quantity-btn").on("click", function () {
    var quantity = $(this).prev().val();
    var bookId = $(this).data('bookid');
    console.log(quantity);
    console.log(bookId);
    $.ajax({
        type: "POST",
        url: "/Account/ChangeQuantity",
        data: {quantity: quantity, bookId: bookId},
        dataType: "json",
    });
});
