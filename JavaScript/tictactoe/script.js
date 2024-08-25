let mark = "X";
let isFinishGame = false;
const resultEl = document.getElementById("result");

gameStart();

function gameStart() {
    const parts = [1, 2, 3, 4, 5, 6, 7, 8, 9];
    const part2El = document.querySelector(".part2");
    part2El.innerHTML = "";

    for (const val in parts) {
        part2El.innerHTML += `<div id="${val}" onclick="setMark(event)"></div>`
    }
}

function setMark(event) {
    if (isFinishGame) return;

    if (!event.target.innerHTML) {
        event.target.innerHTML = mark;
        if (mark === "X") mark = "O"
        else mark = "X"

        isFinish();
    }
}

function newGame() {
    gameStart();
    mark = "X";
    isFinishGame = false;
    resultEl.style.display = "none";
}

function isFinish() {
    const el0 = document.getElementById("0");
    const el1 = document.getElementById("1");
    const el2 = document.getElementById("2");
    const el3 = document.getElementById("3");
    const el4 = document.getElementById("4");
    const el5 = document.getElementById("5");
    const el6 = document.getElementById("6");
    const el7 = document.getElementById("7");
    const el8 = document.getElementById("8");

    if (el0.innerHTML !== "" && el0.innerHTML === el1.innerHTML && el1.innerHTML === el2.innerHTML) {
        resultEl.style.display = "block";
        resultEl.innerHTML = `Congratulations ${el0.innerHTML} win!`
        isFinishGame = true;

        el0.style.backgroundColor = "green";
        el0.style.color = "white";
        el1.style.backgroundColor = "green";
        el1.style.color = "white";
        el2.style.backgroundColor = "green";
        el2.style.color = "white";
    } else if (el3.innerHTML !== "" && el3.innerHTML === el4.innerHTML && el4.innerHTML === el5.innerHTML) {
        resultEl.style.display = "block";
        resultEl.innerHTML = `Congratulations ${el3.innerHTML} win!`
        isFinishGame = true;

        el3.style.backgroundColor = "green";
        el3.style.color = "white";
        el4.style.backgroundColor = "green";
        el4.style.color = "white";
        el5.style.backgroundColor = "green";
        el5.style.color = "white";
    } else if (el6.innerHTML !== "" && el6.innerHTML === el7.innerHTML && el7.innerHTML === el8.innerHTML) {
        resultEl.style.display = "block";
        resultEl.innerHTML = `Congratulations ${el6.innerHTML} win!`
        isFinishGame = true;

        el6.style.backgroundColor = "green";
        el6.style.color = "white";
        el7.style.backgroundColor = "green";
        el7.style.color = "white";
        el8.style.backgroundColor = "green";
        el8.style.color = "white";
    } else if (el0.innerHTML !== "" && el0.innerHTML === el3.innerHTML && el3.innerHTML === el6.innerHTML) {
        resultEl.style.display = "block";
        resultEl.innerHTML = `Congratulations ${el0.innerHTML} win!`
        isFinishGame = true;

        el0.style.backgroundColor = "green";
        el0.style.color = "white";
        el3.style.backgroundColor = "green";
        el3.style.color = "white";
        el6.style.backgroundColor = "green";
        el6.style.color = "white";
    } else if (el1.innerHTML !== "" && el1.innerHTML === el4.innerHTML && el4.innerHTML === el7.innerHTML) {
        resultEl.style.display = "block";
        resultEl.innerHTML = `Congratulations ${el1.innerHTML} win!`
        isFinishGame = true;

        el1.style.backgroundColor = "green";
        el1.style.color = "white";
        el4.style.backgroundColor = "green";
        el4.style.color = "white";
        el7.style.backgroundColor = "green";
        el7.style.color = "white";
    } else if (el2.innerHTML !== "" && el2.innerHTML === el5.innerHTML && el5.innerHTML === el8.innerHTML) {
        resultEl.style.display = "block";
        resultEl.innerHTML = `Congratulations ${el2.innerHTML} win!`
        isFinishGame = true;

        el2.style.backgroundColor = "green";
        el2.style.color = "white";
        el5.style.backgroundColor = "green";
        el5.style.color = "white";
        el8.style.backgroundColor = "green";
        el8.style.color = "white";
    } else if (el0.innerHTML !== "" && el0.innerHTML === el4.innerHTML && el4.innerHTML === el8.innerHTML) {
        resultEl.style.display = "block";
        resultEl.innerHTML = `Congratulations ${el0.innerHTML} win!`
        isFinishGame = true;

        el0.style.backgroundColor = "green";
        el0.style.color = "white";
        el4.style.backgroundColor = "green";
        el4.style.color = "white";
        el8.style.backgroundColor = "green";
        el8.style.color = "white";
    } else if (el2.innerHTML !== "" && el2.innerHTML === el4.innerHTML && el4.innerHTML === el6.innerHTML) {
        resultEl.style.display = "block";
        resultEl.innerHTML = `Congratulations ${el2.innerHTML} win!`
        isFinishGame = true;

        el2.style.backgroundColor = "green";
        el2.style.color = "white";
        el4.style.backgroundColor = "green";
        el4.style.color = "white";
        el6.style.backgroundColor = "green";
        el6.style.color = "white";
    } else if (
        el0.innerHTML != "" &&
        el1.innerHTML != "" &&
        el2.innerHTML != "" &&
        el3.innerHTML != "" &&
        el4.innerHTML != "" &&
        el5.innerHTML != "" &&
        el6.innerHTML != "" &&
        el7.innerHTML != "" &&
        el8.innerHTML != ""
    ) {
        resultEl.style.display = "block";
        resultEl.innerHTML = `It is a Draw!`
        isFinishGame = true;
    }
}