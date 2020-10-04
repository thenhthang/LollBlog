﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LollBlog.Shared;

namespace LollBlog.Client.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int id);
        Task<Employee> UpdateEmployee(Employee employee);
        Task<Employee> CreateEmployee(Employee employee);
        Task DeleteEmployee(int employeeId);
    }
}
