console.log("Pazartesi");
setTimeout((res) => {
    console.log("Salı");
    console.log("Çarşamba");
},2000);


method();


function method(){
    const promise  = new Promise((res, rej)=> {
        res(console.log("I am working..."));
    });

    promise.then(()=> {
        console.log("I know!");        
    })
    
}
