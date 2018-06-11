app.service("crudAJService", function ($http) {

    //get All Employees
    this.getEmployees = function () {
        return $http.get("/Person/GetAllPersons");
    };

    // get Employee by EmployeeId
    this.getEmployee = function (employeeId) {
        return $http.get("/Person/GetEmployeeById?EmployeeId=" + employeeId);
    }

    // Update Employee 
    this.updateEmployee = function (employee) {
        var response = $http({
            method: "post",
            url: "/Person/UpdateEmployee",
            data: JSON.stringify(employee),
            dataType: "json"
        });
        return response;
    }

    // Add Employee
    this.AddEmployee = function (employee) {
        var response = $http({
            method: "post",
            url: "/Person/AddEmployee",
            data: JSON.stringify(employee),
            dataType: "json"
        });
        return response;
    }

    //Delete Employee
    this.DeleteEmployee = function (employeeId) {
        return $http.get("/Person/DeleteEmployee?EmployeeId=" + employeeId);
    }
});