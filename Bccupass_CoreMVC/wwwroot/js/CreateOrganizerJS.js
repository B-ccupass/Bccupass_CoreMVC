let fontLange = document.querySelector("#fontLange"),
    introduction = document.querySelector("#introduction")
const maxLength = 501;
introduction.addEventListener("input", function () {
    if (introduction.textLength < maxLength) {
        fontLange.innerText = introduction.textLength;
    }
})
window.onload = function () {
    fontLange.innerText = introduction.textLength;
    let img = document.querySelector('.showImg')
    img.setAttribute('src', 'https://i.imgur.com/DOP54Ju.png')
}
let orgImg = document.getElementById('orgImg')
orgImg.addEventListener("change", function (e) {
    const file = this.files[0]
    const filereader = new FileReader();
    filereader.onload = function (e) {
        let img = document.querySelector('.showImg')
        img.setAttribute('src', e.target.result)
    }
    filereader.readAsDataURL(file);
})




