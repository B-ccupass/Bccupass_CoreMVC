let ThemeCategory = {}
let selectArray = []
let GetActivityDraftId = 1
let sumBtn = document.querySelector('#sumBtn')
let themeShow = document.querySelector('.themeShow')
let typeShow = document.querySelector('.typeShow')
let themeInput = document.querySelectorAll('.themeInput')
let typeInput = document.querySelectorAll('.typeInput')
let typeid

window.onload = function () {
    sumBtn.disabled = true
    GetUserData()
    ThemeCategory = GatObject()
    checkOK()
}
var forEach = function (array, callback, scope) {
    for (var i = 0; i < array.length; i++) {
        callback.call(scope, i, array[i]);
    }
}
forEach(themeInput, function (index, value) {
    value.addEventListener("click", function () {
        if (this.checked) {
            if (selectArray.length < 2) {
                selectArray.push(parseInt(this.id))
            }
            else { this.checked = false }
        } else { selectArray.splice(this.value, 1) }
        ThemeCategory = GatObject()
        checkOK()
    })
})
forEach(typeInput, function (index, value) {
    value.addEventListener("click", function () {
        typeid = parseInt(this.value)
        ThemeCategory = GatObject()
        checkOK()
    })
})
sumBtn.addEventListener('click', function () {
    ThemeCategory = GatObject()
    try {
        fetch('/CreateActivity/Category', {
            headers: {
                'Accept': 'application/json, text/plain',
                'Content-Type': 'application/json;charset=UTF-8'
            },
            method: 'POST',
            body: JSON.stringify(ThemeCategory)
        })
        fetch(`/CreateActivity/Info/${ThemeCategory.ActivityDraftId}`, { method: 'GET' })
            .then(res => location.assign(res.url))
    }
    catch (e) {
        console.warn(e)
    }
})
function GetUserData() {
    var UserPK = parseInt(document.querySelector('#UserPK').innerText)
    var UserSK = parseInt(document.querySelector('#UserSK').innerText)
    var UserTP = parseInt(document.querySelector('#UserTP').innerText)
    var themeInput = document.querySelectorAll('.themeInput')
    var typeInput = document.querySelectorAll('.typeInput')
    if (UserPK != 0 && UserSK != 0) {
        selectArray.push(UserPK)
        selectArray.push(UserPK)
        themeInput[UserPK - 1].checked = true
        themeInput[UserSK - 1].checked = true
    } else if (UserPK != 0) {
        selectArray.push(UserPK)
        themeInput[UserPK - 1].checked = true
    }
    if (UserTP != 0) {
        typeid = UserTP
        typeInput[typeid - 1].checked = true
    }
}
function GatObject() {
    let PrimaryThemeId = selectArray[0]
    let SecondThemeId = selectArray[1]
    return {
        "ActivityDraftId": GetActivityDraftId,
        'ActivityPrimaryThemeId': PrimaryThemeId,
        'ActivitySecondThemeId': SecondThemeId,
        'ActivityTypeId': typeid,
        'ActivityArray': selectArray,
    }
}


function checkOK() {
    if (!isNaN(ThemeCategory.ActivityPrimaryThemeId) && ThemeCategory.ActivityTypeId !== -1 && !!ThemeCategory.ActivityTypeId) {
        sumBtn.disabled = false
        return true
    }
    else {
        sumBtn.disabled = true
        return false
    }
}
document.getElementById("backPageBtn").addEventListener("click", function () {
    history.go(-1)
})