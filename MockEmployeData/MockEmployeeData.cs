using RESTAPITestDemo.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTAPITestDemo.MockEmployeData
{
    public class MockEmployeeData : IEmployee
    {
        private List<Employee> employees = new List<Employee>()
        {
            new Employee()
            {
                Name="Surendra",
                Address="Mumbai",
                Employee_Id=Guid.NewGuid()
            },
            new Employee()
            {
                Name="Dhanashree",
                Address="Kolhapur",
                Employee_Id=Guid.NewGuid()
            },
            new Employee()
            {
                Name="Omkar",
                Address="Pune",
                Employee_Id=Guid.NewGuid()
            }

          };

        public void Delete_Employee(Employee employee)
        {
            employees.Remove(employee);

        }

        //public void Delete_Employee(Employee employee)
        //{
        //    employees.Remove(employee);
        //}

        public Employee GetEmployeeby_Guid(Guid guid)
        {
            // throw new NotImplementedException();
            return  employees.SingleOrDefault(x=>x.Employee_Id==guid);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            // throw new NotImplementedException();
            return employees;

        }

        public Employee Insert_Employe(Employee employee)
        {
            employee.Employee_Id = Guid.NewGuid();
            employees.Add(employee);
            return employee;

           
        }

        public Employee Update_Employee(Employee emp)
        {
            var exstingemp = GetEmployeeby_Guid(emp.Employee_Id);
            
                exstingemp.Name = emp.Name;
                exstingemp.Address = emp.Address;

            return exstingemp;


        }
    }
}
