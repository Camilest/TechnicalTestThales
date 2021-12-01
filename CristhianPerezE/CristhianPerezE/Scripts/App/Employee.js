
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
                $('#tbody').append(`<tr id="R${++idx}">
                  <td class="row-index text-center">
                        <p>${data.id}</p></td>
                  <td class="row-index text-center">
                        <p>${data.employee_name}</p></td>
                  <td class="row-index text-center">
                        <p>${data.employee_age}</p></td>
                   <td class="row-index text-center">
                        <p>${data.employee_salary}</p></td>
                   <td class="row-index text-center">
                        <p>${data.employee_anual_salary}</p></td>
                   </tr>`);
                //$("ol").append(`<li> ${data.id} - ${data.employee_name} - ${data.employee_salary} - ${data.employee_age} - ${data.employee_anual_salary} </li>`);
            });
        },
        error: function (request, status, error) {
            $("#error").append(`<div class="alert alert-warning" role="alert">
                  Se ha generado un error.
                </div>`);
            //alert(status + ", " + error);
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
            $('#tbody').append(`<tr>
                  <td class="row-index text-center">
                        <p>${result.id}</p></td>
                  <td class="row-index text-center">
                        <p>${result.employee_name}</p></td>
                  <td class="row-index text-center">
                        <p>${result.employee_age}</p></td>
                   <td class="row-index text-center">
                        <p>${result.employee_salary}</p></td>
                   <td class="row-index text-center">
                        <p>${result.employee_anual_salary}</p></td>
                   </tr>`);
            //console.log(result);
            //$("ol").append(`<li> ${result.id} - ${result.employee_name} - ${result.employee_salary} - ${result.employee_age} - ${result.employee_anual_salary} </li>`);
        },
        error: function (request, status, error) {
            $("#error").append(`<div class="alert alert-warning" role="alert">
                  Se ha generado un error.
                </div>`);
            //alert(status + ", " + error);
        }
    });
}