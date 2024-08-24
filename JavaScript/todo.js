//const inputEl = document.getElementById("work");
//const inputEl = document.querySelector("input");
const inputEl = document.querySelector("#work");
//const ulEl = document.getElementById("list");
const ulEl = document.querySelector("ul");
let index = 0;

//ctrl + alt + enterin solunda virgül işaretine 2 defa basın
//`` //bu düz tırnak değil, ters tırnaktır!!!
function save(){
    index++;
    const text = inputEl.value;
    ulEl.innerHTML += 
    `<li id='${index}'>
        ${text}
        <button onclick="deleteByIndex('${index}')">Delete</button>
    </li>`;
    inputEl.value = "";
}

function deleteByIndex(index){
    const el = document.getElementById(index);
    el.remove();
}