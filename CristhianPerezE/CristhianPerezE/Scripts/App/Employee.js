
/**
 * Obtener todos los empleados.
 * */
function getEmployees() {
    const url = '/Employee/GetEmployees';

    $.ajax({
        url: url,
        data: {
        },
        success: function (result) {
            $.each(result.EmployeesResult, function (idx, data) {
                //$("ol").append("<li>Appended item</li>");
                $("ol").append(`<li> ${data.id} - ${data.employee_name} - ${data.employee_salary} - ${data.employee_age} - ${data.employee_anual_salary} </li>`);

                //$("#EmployeeInfo").text(`${data.id} - ${data.employee_name} - ${data.employee_salary} - ${data.employee_age} - ${data.employee_anual_salary}`);
            });
        },
        error: function (request, status, error) {
            alert(status + ", " + error);
        }
    });
}

/**
 * Obtener empleados especifico.
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
            //$("#EmployeeInfo").text(`${result.id} - ${result.employee_name} - ${result.employee_salary} - ${result.employee_age} - ${result.employee_anual_salary}`);
            $("ol").append(`<li> ${result.id} - ${result.employee_name} - ${result.employee_salary} - ${result.employee_age} - ${result.employee_anual_salary} </li>`);
        },
        error: function (request, status, error) {
            alert(status + ", " + error);
        }
    });
}