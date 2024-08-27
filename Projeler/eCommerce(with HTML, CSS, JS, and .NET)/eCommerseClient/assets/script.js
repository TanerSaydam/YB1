getCategories();

function getCategories(){
    fetch("https://localhost:7233/api/Categories/GetAll").then(res => res.json()).then(data => {
        console.log(data);        
    });
}