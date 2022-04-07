window.onload = function () {
    selectArray = []
    checkInput()
}
let categoryInput = document.querySelectorAll('.categoryInput'),
    themeInput = document.querySelectorAll('.themeInput');
let sumBtn = document.querySelector('#sumBtn')
let selectArray = []
let ThemeCategory = {
    "ActivityDraftId": 1,
    "ActivityPrimaryThemeId": 0,
    "ActivitySecondThemeId": 0,
    "ActivityTypeId": 0
}


document.getElementById("sumBtn").addEventListener("click", function () {
    let data = ThemeCategory
    try {
        fetch('/CreateActivity/Category', {
            headers: {
                'Accept': 'application/json, text/plain',
                'Content-Type': 'application/json;charset=UTF-8'
            },
            method: 'POST',
            body: JSON.stringify(data)
        }).then(response => response.json())
            .then(jsonData => {
                console.log(jsonData)
                //成功
                alert('下一步')
            })
    } catch (e) {
        console.log(e)
    }

})

document.getElementById("backPageBtn").addEventListener("click", function () {
    history.go(-1)
})

// forEach method, could be shipped as part of an Object Literal/Module
var forEach = function (array, callback, scope) {
    for (var i = 0; i < array.length; i++) {
        callback.call(scope, i, array[i]); // passes back stuff we need
    }
};



forEach(categoryInput, function (index, value) {
    value.addEventListener("click", function () {
        ThemeCategory.ActivityTypeId = parseInt(value.id)
        checkInput()
    })
});

forEach(themeInput, function (index, value) {
    value.addEventListener("click", function () {
        if (value.checked) {
            if (selectArray.length < 2) {
                selectArray.push(parseInt(value.name))
                getArray()
                checkInput()
            } else {
                value.checked = false
            }
        } else {
            selectArray.splice(selectArray.indexOf(value.name), 1)
            checkInput()
        }
    })
})

function getArray() {
    ThemeCategory.ActivityPrimaryThemeId = selectArray[0]
    ThemeCategory.ActivitySecondThemeId = selectArray[1]
}
function checkInput() {
    if (ThemeCategory.ActivityPrimaryThemeId !== 0 && ThemeCategory.ActivitySecondThemeId !== 0 && ThemeCategory.ActivityTypeId !== 0) {
        sumBtn.disabled = false
    } else {
        sumBtn.disabled = true
    }
}