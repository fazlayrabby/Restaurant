// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(document).on("click", "#createNew", function () {


    $.ajax({
        url: "Order/Order/CreateForm",
        dataType: "html",
        type: "GET",
        async: false,
        cache: false,
        success: function (data) {


            $('#createEditForm').empty();
            $('#createEditForm').append(data);


        },
        error: function (xhr) {

            alert(xhr.responseText);
        }
    });


});


$(document).on("click", "#newOrderSubmit", function () {


    alert("hi");
    var firstName = $("#firstName").val();
    var lastName = $("#lastName").val();
    var state = $("#state").val();
    var date = $("#orderDate").val();

    //var productId = $('#productDw').find(":selected").val();
    //var productName = $('#productDw').find(":selected").text();
    var productList= $('#productDw').val()

    $.ajax({
        url: "Order/Order/CreateOrder",
        dataType: "json",
        type: "post",
        async: false,
        cache: false,
        data: {
            FirstName: firstName, LastName: lastName, State: state, Date: date, ProductList: productList
            
        },
        success: function (data) {



            alert("Successfull!");
            $('#createEditForm').empty();
            updateOrderList();
            //$('#createEditForm').append(data);


        },
        error: function (xhr) {

            alert(xhr.responseText);
        }
    });


});


function updateOrderList() {

    $.ajax({
        url: "Order/Order/AddedList",
        dataType: "html",
        type: "POST",
        cache: false,
        success: function (data) {

            $('#orderlistTableId').empty();
            $('#orderlistTableId').append(data);


        },
        error: function (xhr) {

            alert(xhr.responseText);
        }
    });


}


$(document).on("click", ".editOrder", function () {

    var orderId = $(this).closest("tr").find(".orderId").text();


    $.ajax({
        url: "Order/Order/EditForm",
        dataType: "html",
        type: "POST",
        cache: false,
        data: { OrderId: orderId },
        success: function (data) {

            $('#createEditForm').empty();
            $('#createEditForm').append(data);


        },
        error: function (xhr) {

            alert(xhr.responseText);
        }
    });


});

$(document).on("click", "#editOrderSubmit", function () {



    var orderId = $("#orderEditId").val();
    var firstName = $("#firstName").val();
    var lastName = $("#lastName").val();
    var state = $("#state").val();
    var date = $("#orderDate").val();

    var productList = $('#ProductList').val()


    $.ajax({
        url: "Order/Order/EditOrderComplete",
        dataType: "json",
        type: "post",
        async: false,
        cache: false,
        data: {
            OrderId: orderId, FirstName: firstName, LastName: lastName, State: state, Date: date, ProductList: productList
        },
        success: function (data) {



            alert("Successfull!");
            $('#createEditForm').empty();
            updateOrderList();
           


        },
        error: function (xhr) {

            alert(xhr.responseText);

            console.log(xhr.responseText);

           
        }
    });



});

$(document).on("click", ".deleteOrder", function () {

    var orderId = $(this).closest("tr").find(".orderId").text();


    $.ajax({
        url: "Order/Order/Delete",
        dataType: "json",
        type: "Delete",
        cache: false,
        data: { id: orderId },
        success: function (data) {

            updateOrderList();
            alert("Successfull!");


        },
        error: function (xhr) {

            alert(xhr.responseText);
        }
    });


});

