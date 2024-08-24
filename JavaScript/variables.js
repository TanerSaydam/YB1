//const

const name = "Taner";
//name = "Ahmet"; //buna kızar çünkü const bir defa atanıp başka değiştirelemez

//let 
let age = 35;
age = 10; //buna kızmaz

//var ecmascript 6 dan önce kullanılan tek javascript tipiydi
var firstName = "Taner";
firstName = "Ahmet"; //buna da kızmaz
//firstName = true;
//firstName = new Date();

/*
Javascript de değişken oluşturmanın best practicesi
const tipiyle değişkeni oluştur
eğer değişkene yeni bir değer ataman gerekirse
o zaman tipi let yap
*/

method();

console.log("Method dışı name:" + name);
console.log("Method dışı age:" + age);
console.log("Method dışı firstName:" +firstName);


function method(){
    //console.log(name);
    //console.log(age);
    //console.log("Method içi:" +firstName);
    //console.log("------------------------");
    
    const name = "Taner Saydam"
    console.log("Method içi name:" + name);

    let age = "Cem Tanır";
    console.log("Method içi age:" + age);

    var firstName = "Betül";
    console.log("Method içi firstName:" + firstName);

    console.log("------------------------");
}

