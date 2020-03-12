function myFunction(x) {
    x.style.background = "yellow";
   
}

function myFunctions() {
    var x = document.getElementById("fname");
    x.value = x.value.toUpperCase();
}
function onchangeevent() {
    $('#txtid').val('sam');
}


function CallWebService() {
    debugger;
    $("#txtid").blur(function () {
        $.ajax({
            url: "/T_SALES_DTL/Create",
            type: "POST",
            data: document.getElementById('txtA').value;
            dataType: "json"
        }).done(function (model) {

            $("#PBarcode").val(model.Products.PBarcode);
        });
    });
};