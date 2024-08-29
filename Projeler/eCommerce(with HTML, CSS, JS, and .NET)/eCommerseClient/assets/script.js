let updateId = "";
let data = [];
let orjData = [];

function search(){
    const el = document.getElementById("search");
    const val = el.value;

    data = orjData.filter(p=> p.name.toLocaleLowerCase("tr").includes(val.toLocaleLowerCase("tr")));

    createTbody();
}

function getCategories() {   
    fetch("https://localhost:7233/api/Categories/GetAll").then(res => res.json())
    .then(res => {       
        orjData = res;
        search();
    });
}

function createTbody(){
    const tbodyEl = document.querySelector("tbody");
    tbodyEl.innerHTML = "";

    for (const index in data) {
        const content = `<tr>
                            <td>${+index + 1}</td>
                            <td>${data[index].name}</td>
                            <td>
                                <button 
                                    class="btn btn-primary me-1" 
                                    data-bs-toggle="modal" 
                                    data-bs-target="#updateModal"
                                    onclick="get('${data[index].id}', '${data[index].name}')">
                                    Edit
                                </button>
                                <button class="btn btn-danger" onclick="deleteById('${data[index].id}')">
                                    Delete
                                </button>
                            </td>
                        </tr>`
        tbodyEl.innerHTML += content;
    }
}

function save() {
    const nameEl = document.getElementById("name");
    const closeBtn = document.getElementById("addModalCloseBtn");

    const enpoint = `https://localhost:7233/api/Categories/Create?name=${nameEl.value}`;
    fetch(enpoint).then(() => {
        closeBtn.click();
        nameEl.value = "";
        getCategories();
    });
}

function deleteById(id) {
    const result = confirm("You want to delete this record?");

    if (result) {
        const enpoint = `https://localhost:7233/api/Categories/DeleteById/${id}`;
        fetch(enpoint, {
            method: "DELETE"
        }).then(() => {
            getCategories();
        });
    }
}

function get(id, name) {
    updateId = id;
    const nameEl = document.getElementById("updateName");
    nameEl.value = name;
}

function update() {
    const nameEl = document.getElementById("updateName");
    const closeBtn = document.getElementById("updateModalCloseBtn");
    const enpoint = `https://localhost:7233/api/Categories/Update/${updateId}?name=${nameEl.value}`;
    fetch(enpoint, {
        method: "PUT"
    }).then(() => {
        getCategories();
        closeBtn.click();
    });
}