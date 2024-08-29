getCategories();

function getCategories(){
    const tbodyEl = document.querySelector("tbody");
    tbodyEl.innerHTML = "";
    fetch("https://localhost:7233/api/Categories/GetAll").then(res => res.json()).then(data => {
        for(const index in data){
            const content = `<tr>
                                <td>${+index + 1}</td>
                                <td>${data[index].name}</td>
                                <td>
                                    <button class="btn btn-primary me-1">Edit</button>
                                    <button class="btn btn-danger">Delete</button>
                                </td>
                            </tr>`
            tbodyEl.innerHTML += content;
        }
    });
}

function save(){
    const nameEl = document.getElementById("name");
    const closeBtn = document.getElementById("addModalCloseBtn");

    const enpoint = `https://localhost:7233/api/Categories/Create?name=${nameEl.value}`;
    fetch(enpoint).then(()=> {
        closeBtn.click();
        nameEl.value = "";
        getCategories();
    });
}//10:20 görüşelim