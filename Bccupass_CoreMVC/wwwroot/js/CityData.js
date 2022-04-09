const TaiwanUrl = 'https://raw.githubusercontent.com/LunAhEric/FileStorage/main/TaiwanAddress_Simple.json'
let cityArray = []
let districtArray = []

//DOM
const citySelect = document.querySelector('#city')
const districtSelect = document.querySelector('#district')
const submitBtn = document.querySelector('input')

window.onload = function () {
    getFetchData()
    citySelect.onchange = function () {
        const slectedCity = citySelect.value		// console.log(slectedCity)
        districtArray = [''].concat(cityArray.find(x => x.CityName == slectedCity).AreaList.map(x => `${x.ZipCode}-${x.AreaName}`))
        setDistrictSelect()
        checkUI()
    }
    districtSelect.onchange = function () {
        checkUI()
    }
}
function getFetchData() {
    fetch(TaiwanUrl)
        .then(res => res.json())
        .then(data => {
            cityArray = [{ CityName: '', AreaList: [] }].concat(data)
            districtArray = ['']
            //citySelect
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
        //districtSelect
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

function checkUI() {
    if (citySelect.value == '') {
        districtSelect.setAttribute('disabled', 'true')
        submitBtn.setAttribute('disabled', 'true')

    } else {
        districtSelect.removeAttribute('disabled')
    }

    if (districtSelect.value == '') {
        submitBtn.setAttribute('disabled', 'true')
    } else {
        submitBtn.removeAttribute('disabled')
    }
}