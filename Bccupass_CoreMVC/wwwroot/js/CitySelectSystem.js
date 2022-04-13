const TaiwanUrl = 'https://raw.githubusercontent.com/LunAhEric/FileStorage/main/TaiwanAddress_Simple.json'
let cityArray = []
let districtArray = []

function checkUI() {
    if (citySelect.value == '') {
        districtSelect.setAttribute('disabled', 'true')
    } else {
        districtSelect.removeAttribute('disabled')
    }
}
function getFetchData() {
    fetch(TaiwanUrl)
        .then(res => res.json())
        .then(data => {
            cityArray = [{ CityName: '', AreaList: [] }].concat(data)
            districtArray = ['']
            setCitySelect()
            setDistrictSelect()
            checkUI()
        })
        .catch(ex => { console.log(ex) })
}
function setCitySelect() {
    citySelect.innerHTML = ''
    cityArray.forEach(city => {
        let option = document.createElement('option')
        option.innerText = city.CityName == '' ? '--請選擇城市--' : city.CityName
        option.value = city.CityName
        citySelect.appendChild(option)
    })
}
function setDistrictSelect() {
    districtSelect.innerHTML = ''
    districtArray.forEach(district => {
        let option = document.createElement('option')
        option.innerText = district == '' ? '--請選擇區域--' : district
        option.value = district
        districtSelect.appendChild(option)
    })
}

