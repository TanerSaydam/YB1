//console.log("Hello, world!");
        //const let var
        const msgs = [
            "Welcome to JavaScript",
            "Добро пожаловать в JavaScript",
            "ຍິນດີຕ້ອນຮັບສູ່ JavaScript",
            "Willkommen bei JavaScript",
            "JavaScript'e hoş geldiniz"
        ]

        const el = document.querySelector("h1");

        let min = 35;
        let sec = 0;
        setInterval(()=> {
            sec--;
            if(sec < 0){
                sec = 59;
                min--;
            }
            el.innerText = `${min}:${sec}`
        },1000)

        // setInterval(() => {
        //     const random = Math.ceil(Math.random() * 4);            
        //     const msg = msgs[random];
        //     el.innerHTML = msg;
        // }, 3000);

        function method() {
            console.log("Method clicked");
        }