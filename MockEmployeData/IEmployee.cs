using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RESTAPITestDemo.models;

namespace RESTAPITestDemo.MockEmployeData
{
    public interface IEmployee
    {
        IEnumerable<Employee> GetEmployees();

        Employee GetEmployeeby_Guid(Guid guid);

        void Delete_Employee(Employee employee);

       // Employee Delete_Employee(Employee employee);

        Employee Update_Employee(Employee emp);

        Employee Insert_Employe(Employee employee);

    }
}
