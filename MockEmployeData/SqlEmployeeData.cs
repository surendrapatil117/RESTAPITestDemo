using RESTAPITestDemo.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTAPITestDemo.MockEmployeData
{
    public class SqlEmployeeData : IEmployee
    {
        
        private EmployeeDBContext _employeeDBContext;

        public SqlEmployeeData(EmployeeDBContext employeeDBContext)
        {
            _employeeDBContext = employeeDBContext;
        }
        /// <summary>
        /// this function will delete the Employee by id
        /// </summary>
        /// <param name="employee"></param>
        public void Delete_Employee(Employee employee)
        {
            _employeeDBContext.Employees.Remove(employee);
            _employeeDBContext.SaveChanges();
        }

        public Employee GetEmployeeby_Guid(Guid guid)
        {
           // _employeeDBContext.Employees.SingleOrDefault(x => x.Employee_Id == guid);

            return _employeeDBContext.Employees.Find(guid);
        }
        /// <summary>
        /// this function will retun all employeee 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Employee> GetEmployees()
        {
            return _employeeDBContext.Employees.ToList();


        }
        /// <summary>
        /// this function is usd to insert new Employee 
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public Employee Insert_Employe(Employee employee)
        {
            employee.Employee_Id = Guid.NewGuid();
           _employeeDBContext.Employees.Add(employee);
           _employeeDBContext.SaveChanges();
            return employee;
        }
        /// <summary>
        /// This function is usd to update the employee
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        public Employee Update_Employee(Employee emp)
        {
            var exstingdata = GetEmployeeby_Guid(emp.Employee_Id);
            if (exstingdata!=null)
            {
                exstingdata.Name = emp.Name;
                exstingdata.Address = emp.Address;
                _employeeDBContext.Employees.Update(exstingdata);
                _employeeDBContext.SaveChanges();
                
            }
            return exstingdata;

        }
    }
}
