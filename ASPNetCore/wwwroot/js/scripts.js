const uri = "api/products/";
let items = null;

function loadProducts() {
    var i, x = "";
    var request = new XMLHttpRequest();
    request.open("GET", uri);
    request.onload = function () {
        items = JSON.parse(request.responseText);
        for (i in items) {
                        console.log(items[i]);
                        x += "<tr>";
                        x += "<td>";
                        x += items[i].idProduct;
                        x += "</td>";
                        x += "<td>";
                        x += items[i].nowCost;
                        x += "</td>";
                        x += "<td>";
                        x += items[i].scorGodnostiO;
                        x += "</td>";
                        x += "<td>";
                        x += items[i].title;
                        x += "</td>";
                        x += "<td>";
            x += '<button onClick={showEditForm(' + i + ')} class="btn btn-outline-secondary" >Изменить</button>';
            x += '<button onClick={deleteProduct(' + items[i].idProduct + ')} class="btn btn-outline-danger">Удалить</button>';
                        x += "</td>";
                        x += "</tr>";
                    
    }
    document.getElementById("product").innerHTML = x;
};
request.send();
}

function deleteProduct(id) {
    var request = new XMLHttpRequest();
    var url = uri + id;
    request.open("DELETE", url,false);
    request.onload = function () {
        loadProducts();
    };
    request.send();
}

function showEditForm(i) {
    var product = items[i];
    document.getElementById("editProductId").innerHTML = product.idProduct;
    document.getElementById("editprice").value = product.nowCost;
    document.getElementById("editscorgodnosti").value = product.scorGodnostiO;
    document.getElementById("edittitle").value = product.title;

    console.log(JSON.stringify(product));
    document.getElementById("editForm").style.display = "block";
}

function editProduct() {
    var idProduct = document.getElementById("editProductId").innerHTML;
    var nowCost = document.getElementById("editprice").value;
    var scorGodnostiO = document.getElementById("editscorgodnosti").value;
    var title = document.getElementById("edittitle").value;

    var request = new XMLHttpRequest();
    var url = uri + idProduct;
    request.open("PUT", url,false);
    request.onload = function () {
        loadProducts();
    };

    request.setRequestHeader('Content-type', 'application/json; charset=utf-8');
    request.send(JSON.stringify({
        idProduct: idProduct / 1,
        nowCost: nowCost,
        scorGodnostiO: scorGodnostiO,
        title: title

    }));
}

function CreateProduct() {
    var nowCost = document.getElementById("createPrice").value;
    var scorGodnostiO = document.getElementById("createScorGodnosti").value;
    var title = document.getElementById("createTitle").value;
    var idCategoryFk = document.getElementById("createCategory").value;

    var request = new XMLHttpRequest();
    request.open("POST", uri, false);
    request.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
    request.onload = function () {
        loadProducts();
    };
    request.send(JSON.stringify({
        nowCost: nowCost,
        scorGodnostiO: scorGodnostiO,
        title: title,
        idCategoryFk: idCategoryFk

    }));
}

