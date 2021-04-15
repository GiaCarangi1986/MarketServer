//import { observable, action, makeObservable } from 'mobx';

class Product extends React.Component {

    constructor(props) {
        super(props);
        this.state = { data: props.product, edOpened: false }; //передавать будем продукт и bool: редактируем ли поле
        //makeObservable(this.state);
        this.onClick = this.onClick.bind(this); //нажали на удалить продукт
        this.onEditSubmit = this.onEditSubmit.bind(this); //нажали на изменить продукт (применяем редактирование)
        this.onEditAdd = this.onEditAdd.bind(this); //нажали на измениить продукт (передаем данные в форму для редактирования)
    }

    onClick() {
        this.props.onRemove(this.state.data); //вызываем функцию удаления
    }
    onEditSubmit() {
        this.props.onEdit(this.state.data); //вызываем функцию применения редактирования
    }
    onEditAdd() {
        var status = !this.state.edOpened; //вроде как статус edOpened true устанавливает
        this.setState({ edOpened: status }); //отправим обновленный статус
        this.props.onEdit(this.state.data); //передадим сюда данные об объекте
    }

    render() {
        return (
            <div>

                <div className="card bg-warning mb-3">
                    <div className="card-header">
                        Продукт  <b>{this.state.data.idProduct}</b>
                    </div>

                    <ul className="list-group list-group-flush">
                        <li className="list-group-item">Название: <b> {this.state.data.title}</b> </li>
                        <li className="list-group-item">Цена: <b> {this.state.data.nowCost} </b> </li>
                        <li className="list-group-item">Срок годности: <b> {this.state.data.scorGodnostiO} </b></li>
                        <li className="list-group-item">id категории: <b> {this.state.data.idCategoryFk} </b></li>
                        <li className="list-group-item">
                            <div className="row justify-content-between">
                                <div className="col-4" >
                                    <div align="left"> 
                                        {/*вызову onEditAdd, где укажу, что вызываю форму для редактивания*/}
                                        <button type="button" className="btn btn-outline-info" onClick={this.onEditAdd} > Изменить</button> 
                                    </div>
                                </div>
                                <div className="col-4">
                                    <div align="right">
                                        {/*вызову удаление продукта*/}
                                        <button type="button" className="btn btn-outline-danger" onClick={this.onClick}>Удалить</button>
                                    </div>
                                </div>
                            </div>

                        </li>
                    </ul>
                </div>
                {/*если вызвала форму для редактирования (edOpened=true), то создам форму для продукта, которой пока null присвою;
                 туда передаем onEditSubmit*/}
                {this.state.edOpened ? <ProductForm onProductSubmit={this.onEditSubmit} state={this.state} /> : null}
            </div>);
    }
}

class change extends React.Component {
    constructor(props) {
        super(props);

    }
}

class ProductForm extends React.Component {

    constructor(props) {
        super(props);
        this.state = props.state;
        if (this.state === undefined) {
            this.state = {
                data: {
                    nowCost: "", title: "", scorGodnostiO: "", idCategoryFk: "" //свойства продукта, которые доступны для редактирования
                }
            };
        }
        //поля, доступные для редактирования:
        this.onSubmit = this.onSubmit.bind(this);
        this.onNowCostChange = this.onNowCostChange.bind(this); //цена
        this.onTitleChange = this.onTitleChange.bind(this); //название
        this.onScorGodnostiChange = this.onScorGodnostiChange.bind(this); //срок годности
        this.onIDCategoryChange = this.onIDCategoryChange.bind(this); //ID категории
    }
    //в состояние записываем значения из полей
    onNowCostChange(e) {
        this.setState({ nowCost: e.target.value }); //отправим в state в nowCost значение соответствующего поля
        this.state.data.nowCost = e.target.value;
    }
    onTitleChange(e) {
        this.setState({ title: e.target.value }); //отправим в state в title значение соответствующего поля
        this.state.data.title = e.target.value;
    }
    onScorGodnostiChange(e) {
        this.setState({ scorGodnostiO: e.target.value }); //отправим в state в scorGodnostiO значение соответствующего поля
        this.state.data.scorGodnostiO = e.target.value;
    }
    onIDCategoryChange(e) {
        this.setState({ idCategoryFk: e.target.value }); //отправим в state в idCategoryFK значение соответствующего поля
        this.state.data.idCategoryFk = e.target.value;
    }
    
    onSubmit(e) { //это поля формы
        e.preventDefault();
        var productNowCost = parseInt(this.state.data.nowCost);
        var productTitle = this.state.data.title;
        var productScorGodnosti = parseInt(this.state.data.scorGodnostiO);
        var productIdCategoryFk = parseInt(this.state.data.idCategoryFk);

        if (productNowCost <= 0 || productScorGodnosti <= 0 || !productTitle || productIdCategoryFk <=0) { //если что то пустое, то не выполняем редактирование
            return;
        }
        //отправляем в продукт 3 этих свойства
        //тут не работает
        this.props.onProductSubmit({ nowCost: productNowCost, title: productTitle, scorGodnostiO: productScorGodnosti, idCategoryFk:productIdCategoryFk});
        //обнуляем состояние
        this.setState({ nowCost: 0, title: "", scorGodnostiO: 0, idCategoryFk: 0});
    }

    render() {
        return (
            <div className="card text-dark bg-warning mb-3">
                <ul className="list-group list-group-flush">
                    <form onSubmit={this.onSubmit}>
                        <li className="list-group-item">
                            <label htmlFor="title" className="htmlForm-label">Название: </label>
                            <input type="text"
                                className="htmlForm-control" id="title"
                                placeholder="Название"
                                value={this.state.data.title}
                                onChange={this.onTitleChange} />
                        </li>
                        <li className="list-group-item">
                            <label htmlFor="nowCost" className="htmlForm-label">Цена: </label>
                            <input type="number"
                                className="htmlForm-control" id="nowCost"
                                placeholder="Цена"
                                value={this.state.data.nowCost}
                                onChange={this.onNowCostChange} />
                        </li>
                        <li className="list-group-item">
                            <label htmlFor="scorG" className="htmlForm-label">Срок годности: </label>
                            <input type="number"
                                className="htmlForm-control" id="scorG"
                                placeholder="Срок годности"
                                value={this.state.data.scorGodnostiO}
                                onChange={this.onScorGodnostiChange} />
                        </li>
                        <li className="list-group-item">
                            <label htmlFor="cat" className="htmlForm-label">ID категории: </label>
                            <input type="number"
                                className="htmlForm-control" id="cat"
                                placeholder="ID категории"
                                value={this.state.data.idCategoryFk}
                                onChange={this.onIDCategoryChange} />
                        </li>
                        <li className="list-group-item">
                            <input type="submit" className="btn btn-outline-primary" value="Сохранить" />
                        </li>
                    </form>
                </ul>
            </div>
        );
    }
}

class ProductList extends React.Component {

    constructor(props) {
        super(props);
        this.state = { products: [], crOpened: false };
        //makeObservable(this.state);
        this.onAddProduct = this.onAddProduct.bind(this); //вызываем на добавление продукта
        this.onRemoveProduct = this.onRemoveProduct.bind(this); //вызываем на удаление продукта
        this.onEditProduct = this.onEditProduct.bind(this); //вызываем на редактирование продукта
        this.onCreateAdd = this.onCreateAdd.bind(this); //вызывается форма добавление продукта
    }
    // загрузка данных
    loadData() {
        var xhr = new XMLHttpRequest(); //запрос на сервер
        xhr.open("get", this.props.apiUrl, true); //get запрос - загрузка всех продуктов
        xhr.onload = function () {
            var data = JSON.parse(xhr.responseText); //в json объекты добавляем инфу с запроса
            this.setState({ products: data }); //отправляем в данные -> список продуктов
        }.bind(this);
        xhr.send();
    }
    componentDidMount() {
        this.loadData(); //чет жизенный цикл (наверное начинается с загрузки продуктов)
    }
    // добавление объекта
    async onAddProduct(product) {
        if (product) {
            var ordJSN = {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    nowCost: product.nowCost,
                    title: product.title,
                    scorGodnostiO: product.scorGodnostiO,
                    idCategoryFk: product.idCategoryFk,
                })
            }
            const result = await fetch(this.props.apiUrl, ordJSN);
            console.log(result);
            //location.href = location.href;
        }
    }
    // удаление объекта
    onRemoveProduct(product) {
        if (product) {
            var url = this.props.apiUrl + "/" + product.idProduct;

            var xhr = new XMLHttpRequest();
            xhr.open("delete", url, true);
            xhr.setRequestHeader("Content-Type", "application/json");
            xhr.onload = function () {
                if (xhr.status === 200) {
                    this.loadData();
                }
            }.bind(this);
            xhr.send();
            //location.href = location.href;
        }
    }
    //редактирование объекта
    onEditProduct(product, newProduct) {
        if (product && newProduct) {
            fetch(this.props.apiUrl + "/" + product.idProduct, {
                method: 'PUT',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({
                    idProduct: product.idProduct,
                    nowCost: newProduct.nowCost,
                    title: newProduct.title,
                    scorGodnostiO: newProduct.scorGodnostiO,
                    idCategoryFk: newProduct.idCategoryFk,
                })
            }).then((data) => {
                console.log(`answer ${data}`);
            });
            //location.href = location.href;
        }
    }
    //будет форма для создания объекта
    onCreateAdd() {
        var status = !this.state.crOpened; //присваиваем true для начала скорее всего
        this.setState({ crOpened: status });
    }

    render() {
        var remove = this.onRemoveProduct;
        var edit = this.onEditProduct;
        return <div>
            <nav className="navbar navbar-light bg-light">
                <div className="container-fluid">
                    <a className="navbar-brand  h2">Список продуктов</a>
                    <div className="d-flex">
                        <button className="btn btn-outline-danger" type="button" onClick={this.onCreateAdd}>
                            +
                        </button>
                    </div>
                </div>
            </nav>
            {this.state.crOpened ? <ProductForm onProductSubmit={this.onAddProduct} /> : null}
            {/*для компонента ProductForm на событие onProductSubmit (передаем туда поля), вызовется метод onAddProduct (put запрос)*/}
            <div id="productList">
                {
                    this.state.products.map(function (product) {
                        return <Product key={product.idProduct} product={product} onRemove={remove} onEdit={edit} />
                    })
                    //ну сначала вызовем Product, где укажем вот что на какие события key, product, onRemove, onEdit что будет вызываться
                    //это типа из чего состоит поле списка: id продукта, сам продукт, кнопка удалить и редактировать
                }
            </div>
        </div>;
    }
}

ReactDOM.render(
    <ProductList apiUrl="/api/products" />,
    document.getElementById("productContent")
);