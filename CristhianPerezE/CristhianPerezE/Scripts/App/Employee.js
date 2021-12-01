
/**
 * 
 * */
function getEmployees() {
    const url = '/Employee/GetEmployees';

    $.ajax({
        url: url,
        data: {

        },
        success: function (result) {

            $.each(result.EmployeesResult, function (idx, data) {
                $("#EmployeeInfo").val(data.id);
                //console.log(data.id);
                //console.log(data);
            });

        },
        error: function (request, status, error) {
            alert(status + ", " + error);
        }
    });
}

/**
 * 
 * */
function getEmployeeById() {
    const url = '/Employee/GetEmployeById';
    let idEmployee = $("#EmployeeId").val();

    $.ajax({
        url: url,
        data: {
            id: idEmployee
        },
        success: function (result) {
            console.log(result);
            $("#EmployeeInfo").val(result.employee_name);
            
        },
        error: function (request, status, error) {
            alert(status + ", " + error);
        }
    });
}