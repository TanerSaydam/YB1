let mark = "X";

gameStart();

function gameStart() {
    const parts = [1, 2, 3, 4, 5, 6, 7, 8, 9];
    const part2El = document.querySelector(".part2");
    part2El.innerHTML = "";
    
    for (const val in parts) {
        part2El.innerHTML += `<div onclick="setMark(event)"></div>`
    }
}

function setMark(event) {
    if(!event.target.innerHTML){
        event.target.innerHTML = mark;
        if (mark === "X") mark = "O"
        else mark = "X"
    }
}

function newGame() {
    gameStart();
}