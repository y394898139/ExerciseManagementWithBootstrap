
//Load Data function
$(document).ready(function () {
    $('#myTable').DataTable({
        "responsive":true,
        "ajax": {
            "url": "/Exercise/Exercise_Read",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "ExerciseName", "autoWidth": true },
            {
                "data": "ExerciseDate", "searchable": false, "render": function (value) {
                    if (value === null) return "";

                    var pattern = /Date\(([^)]+)\)/;
                    var results = pattern.exec(value);
                    var dt = new Date(parseFloat(results[1]));

                    return (dt.getMonth() + 1) + "/" + dt.getDate() + "/" + dt.getFullYear();
                },"autoWidth": true },
            {
                "data": "DurationTime", "searchable": false, "autoWidth": true
            },
            {
                data: null, render: function (data, type, row) {
                    return "<a href='#' class='btn btn-danger' onclick=DeleteData('" + row.CustomerID + "'); >Delete</a>";
                }
            }
        ]
    });
});
//Add Data Function
function Add() {
    var res = validate();
    if (res === false) {
        return false;
    }
    var exeObj = {
        Id: $('#Id').val(),
        ExerciseName: $('#ExerciseName').val(),
        ExerciseDate: $('#ExerciseDate').val(),
        DurationTime: $('#DurationTime').val()
    };
    $.ajax({
        url: "/Exercise/Create",
        data: JSON.stringify(exeObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            $('.modal.in').modal('hide');
            $(".modal-backdrop").remove();
            window.location.href = "Index";
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}


//Function for clearing the textboxes
function clearTextBox() {
    $('#Id').val("");
    $('#ExerciseName').val("");
    $('#ExerciseDate').val("");
    $('#DurationTime').val("");
    $('#btnAdd').show();
    $('#ExerciseName').css('border-color', 'lightgrey');
    $('#ExerciseDate').css('border-color', 'lightgrey');
    $('#DurationTime').css('border-color', 'lightgrey');
}
//Valdidation using jquery
function validate() {
    var isValid = true;
    if ($('#ExerciseName').val().trim() === "") {
        $('#ExerciseName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#ExerciseName').css('border-color', 'lightgrey');
    }
    if ($('#ExerciseDate').val().trim() === "") {
        $('#ExerciseDate').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#ExerciseDate').css('border-color', 'lightgrey');
    }
    if ($('#DurationTime').val().trim() === "") {
        $('#DurationTime').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#DurationTime').css('border-color', 'lightgrey');
    }
    return isValid;
}

function parseJsonDate(jsonDateString) {
    var exerciseDate = new Date(parseInt(jsonDateString.replace('/Date(', '')));
    var hours = exerciseDate.getHours();
    var minutes = exerciseDate.getMinutes();
    var ampm = hours >= 12 ? 'pm' : 'am';
    hours = hours % 12;
    hours = hours ? hours : 12; // the hour '0' should be '12'
    minutes = minutes < 10 ? '0' + minutes : minutes;
    var strTime = hours + ':' + minutes + ' ' + ampm;
    return exerciseDate.getDate() + "/" + (exerciseDate.getMonth()+1)  + "/" + exerciseDate.getFullYear() + "  " + strTime;
   
}

