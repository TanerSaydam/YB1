
const names = ["Taner","Ahmet","Cem","Betül","Mutlu"];

const users = [
    {
        firstName: "Taner",
        lastName: "Saydam"
    },
    {
        firstName: "Betül",
        lastName: "Aktoprak"
    },
    {
        fullName: "İsa Yasin Kuru",
        age: 25
    }
]


names[0] = "Berkan"; //bı yapılabilir
 
names = ["Berkan"] //bu yapılamaz


// for(const val of users){
//     console.log(val);    
// }

// const user = {
//     firstName: "Taner",
//     lastName: "Saydam",
//     age: 35
// };

// for(const val in user){//obect döndermek için bu kullanılabiliyor
//     console.log(user[val]);
// }

// for(let i = 0; i < names.length; i++){
//     console.log(names[i]);
    
//     console.log(i);
// }

// for(const val in names){//of değerler | in de index numaraları basılır
//     console.log(val);
// }

// for(const val of names){//of değerler | in de index numaraları basılır
//     console.log(val);
// }

// names.forEach(val => {
//     console.log(val);    
// });