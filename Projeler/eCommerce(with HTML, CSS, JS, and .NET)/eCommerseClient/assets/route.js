const rootEl = document.querySelector("app-root");
let home = "";
let contact = "";
let category = "";


gotoHome();
const homeEl = document.getElementById("home");
const categoriesEl = document.getElementById("categories");
const contactEl = document.getElementById("contact");

function gotoHome(){    
    if(home === ""){
        fetch("../pages/home.html").then(res=> res.text()).then(data => {
            home = data;
            rootEl.innerHTML = home;
            homeEl.className = "nav-link active";
            categoriesEl.className = "nav-link";
            contactEl.className = "nav-link";
        });
    }else{
        rootEl.innerHTML = home;
        homeEl.className = "nav-link active";
        categoriesEl.className = "nav-link";
        contactEl.className = "nav-link";
    }
    
}

function gotoCategory(){
    if(category === ""){
        fetch("../pages/categories.html").then(res=> res.text()).then(data => {
            category = data;
            rootEl.innerHTML = category;
            getCategories();
            homeEl.className = "nav-link";
            categoriesEl.className = "nav-link active";
            contactEl.className = "nav-link";
        });
    }else{
        rootEl.innerHTML = category;
        getCategories();
        homeEl.className = "nav-link";
        categoriesEl.className = "nav-link active";
        contactEl.className = "nav-link";
    }
}

function gotoContact(){
    if(contact === ""){
        fetch("../pages/contact.html").then(res=> res.text()).then(data => {
            contact = data;
            rootEl.innerHTML = contact;
            homeEl.className = "nav-link";
            categoriesEl.className = "nav-link";
            contactEl.className = "nav-link active";
        });
    }else{
        rootEl.innerHTML = contact;
        homeEl.className = "nav-link";
        categoriesEl.className = "nav-link";
        contactEl.className = "nav-link active";
    }
}