const setPassword = document.getElementById("set-Password");
const checkPassword = document.getElementById("check-Password");


setPassword.onblur = function () {
    let setAnswer = setPassword.value;
    let tip = document.getElementById("tip-setPassword");

    tip.innerHTML = "";
    if (!setAnswer) {
        tip.innerHTML = "必填欄位";
        return;
    }

    if (setAnswer.search(/^(?=.{8,})(?=.*[a-z])(?=.*[0-9])/)) {
        tip.innerHTML = "密碼需至少八字元且含英文及數字";
        return;
    }
};

checkPassword.onblur = function () {
    let setAnswer = setPassword.value;
    let checkAnswer = checkPassword.value;
    let tip = document.getElementById("tip-checkPassword");

    tip.innerHTML = "";
    if (!checkAnswer) {
        tip.innerHTML = "必填欄位";
        return;
    }

    if (checkAnswer != setAnswer) {
        tip.innerHTML = "密碼與第一次輸入不相符";
        return;
    }
};




//const saveBtn = document.getElementById("Save-Btn");

//saveBtn.onclick = function () {
//    save();
//}



//function save() {

//    const request = {
//        set: setPassword.value,
//        check: checkPassword.value
//    };

//    if (!request.set || !request.check) {
//        alert("請填寫完畢");
//        return;
//    }
//};