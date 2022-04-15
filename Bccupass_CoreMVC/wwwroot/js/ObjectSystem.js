const activityName = document.querySelector('#activityName'),
    activityStartDate = document.querySelector('#activityStartDate'),
    activityStartTime = document.querySelector('#activityStartTime'),
    activityEndDate = document.querySelector('#activityEndDate'),
    activityEndTime = document.querySelector('#activityEndTime'),
    activityTag = document.querySelector('#activityTag'),
    activityShortURL = document.querySelector('#activityShortURL'),
    ActivityRefWebUrl = document.querySelector('#ActivityRefWebUrl'),
    RefWebDescription = document.querySelector('#RefWebDescription'),
    citySelect = document.querySelector('#citySelect'),
    districtSelect = document.querySelector('#districtSelect'),
    offline = document.querySelector('#offline'),
    online = document.querySelector('#online'),
    StreamingWeb = document.querySelector('#StreamingWeb'),
    Address = document.querySelector('#Address'),
    AddressDetail = document.querySelector('#AddressDetail'),
    onlineCard = document.querySelector('.onlineCard'),
    offlineCard = document.querySelector('.offlineCard'),
    onlineLab = document.querySelector('.onlineLab'),
    offlineLab = document.querySelector('.offlineLab');
const submitBtn = document.querySelector('#sumBtn')
let GetActivityDraftId = 1
offline.classList.add('show')
offline.disabled = true
offlineLab.disabled = true
offlineCard.classList.add('show')
citySelect.required = true
districtSelect.required = true
Address.required = true

let tagInput = document.querySelector('#tagInput')
let TagArray = []
let ActivityInfo = {}

activityTag.addEventListener("keyup", function (event) {
    if (event.keyCode === 13) {
        let inputString = activityTag.value.trim()
        if (inputString != '') {
            CreateSpan(inputString)
        }
        activityTag.value = ''
        inputString = ''
    }
})

function CreateSpan(string) {
    let span = document.createElement('span')
    span.innerText = string
    span.classList.add('btn', 'col-2', 'bg-light', 'border', 'border-secondary', 'text-break')
    span.setAttribute('id', 'spanInput')
    tagInput.insertBefore(span, activityTag)
    span.addEventListener('click', function () {
        TagArray.splice(TagArray.indexOf(this.innerText), 1)
        span = tagInput.removeChild(this)
        CheckTagArray()
    })
    TagArray.push(`${string.toString()}`)
    CheckTagArray()
}

function CheckTagArray() {
    if (TagArray.length == 5) {
        activityTag.disabled = true
    } else {
        activityTag.disabled = false
    }
}

function GatObject() {
    return {
        "ActivityDraftId": GetActivityDraftId,
        "ActivityName": activityName.value,
        "Image": "https://i.imgur.com/JmwfFko.png",
        "StartDate": activityStartDate.value,
        "StartTime": activityStartTime.value,
        "EndDate": activityEndDate.value,
        "EndTime": activityEndTime.value,
        "Tag": TagArray,
        "ActivityRefWebUrl": ActivityRefWebUrl.value,
        "RefWebDescription": RefWebDescription.value,
        "City": citySelect.value,
        "CitySelectIndex": citySelect.selectedIndex,
        "District": districtSelect.value,
        "DistrictSelectIndex": districtSelect.selectedIndex,
        "Address": Address.value,
        "AddressDetail": AddressDetail.value,
        "StreamingWeb": StreamingWeb.value,
    }
}

online.addEventListener('click', function () {
    citySelect.selectedIndex = 0
    districtSelect.selectedIndex = 0
    Address.value = ''
    AddressDetail.value = ''
    onlineLab.classList.add('disabled')
    offlineLab.classList.remove('disabled')
    offlineCard.classList.remove('show')
    offline.disabled = false
    StreamingWeb.disabled = false
    StreamingWeb.required = true
    citySelect.required = false
    districtSelect.required = false
    Address.required = false
})

offline.addEventListener('click', function () {
    StreamingWeb.value = ''
    offlineLab.classList.add('disabled')
    onlineLab.classList.remove('disabled')
    onlineCard.classList.remove('show')
    StreamingWeb.disabled = true
    StreamingWeb.required = false
    citySelect.required = true
    Address.required = true
    districtSelect.required = true
})

let hiddenSpan = document.querySelectorAll('#hiddenSpan')
if (hiddenSpan.length > 0) {
    hiddenSpan.forEach(string => {
        CreateSpan(string.innerText)
    })
}