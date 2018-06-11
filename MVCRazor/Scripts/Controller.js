app.controller("mvcCRUDCtrl", function ($scope, crudAJService) {
    GetAllEmployees();

    //To Get all employees records
    function GetAllEmployees() {

        $("#LoadingStatus").html("Loading....");
        var getEmployeeData = crudAJService.getEmployees();
        
        getEmployeeData.then(function (employee) {
            $("#LoadingStatus").html(" ");
            $scope.employees = employee.data;
        }, function () {
            $("#LoadingStatus").html(" ");
            alert('Error in getting employees records');
        });
    }

    $scope.editEmployee = function (employee) {
        var getEmployeeData = crudAJService.getEmployee(employee.ID);
        getEmployeeData.then(function (_employee) {
            $scope.employee = _employee.data;
            $scope.ID = employee.ID;
            $scope.FirstName = employee.FirstName;
            $scope.LastName = employee.LastName;
            $scope.Gender = employee.Gender;
            $scope.Salary = employee.Salary;
            $scope.Action = "Update";
            $("#ModalTitle").html("Update Employee");
            $("#MyModal").modal();
        }, function () {
            alert('Error in getting employees records');
        });
    }

    $scope.AddUpdateEmployee = function () {
        var Employee = {
            ID : $scope.ID,
            FirstName: $scope.FirstName,
            LastName: $scope.LastName,
            Gender: $scope.Gender,
            Salary: $scope.Salary
        };
        var getEmployeeAction = $scope.Action;

        if (getEmployeeAction == "Update") {
            Employee.Id = $scope.employeeId;
            var getEmployeeData = crudAJService.updateEmployee(Employee);
            getEmployeeData.then(function (msg) {
                window.location.href = "/Angular/EmployeeList.html";
                $("#MyModal").hide();
                if (msg.data) {
                    alert("Record Updated Successfully");
                }            
            }, function () {
                alert('Error in updating employee record');
            });
        } else {
            var getEmployeeData = crudAJService.AddEmployee(Employee);
            getEmployeeData.then(function (msg) {
                window.location.href = "/Angular/EmployeeList.html";
                $("#MyModal").hide();
                if (msg.data) {
                    alert("Record Added Successfully");
                }
            }, function () {
                alert('Error in adding employee record');
            });
        }
    }

    $scope.AddEmployee = function () {
        ClearFields();
        $scope.Action = "Add";
        $("#ModalTitle").html("Add New Employee");
        $("#MyModal").modal();
    }

    $scope.deleteEmployee = function (employee) {
        $('#EmpId').val(employee.ID);
        $("#DeleteConfirmation").modal();
    }
    $scope.DeleteConfirm = function()
    {
        var EmpId = $('#EmpId').val();
        var getEmployeeData = crudAJService.DeleteEmployee(EmpId);
        getEmployeeData.then(function (msg) {
            $("#DeleteConfirmation").hide();
            if (msg.data) {
                alert("Record Deleted Successfully");
            }
            window.location.href = "/Angular/EmployeeList.html";
        }, function () {
            $("#DeleteConfirmation").hide();
            alert('Error in deleting employee record');
        });
    }

    function ClearFields() {
        $scope.ID = "";
        $scope.FirstName = "";
        $scope.LastName = "";
        $scope.Gender = "";
        $scope.Salary = "";
    }

    $scope.Cancel = function () {
        $scope.divEmployee = false;
    };
});