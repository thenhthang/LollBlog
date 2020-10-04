using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using LollBlog.Shared;
using System.Net.Http;
using System.Net.Http.Json;

namespace LollBlog.Client.Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly HttpClient httpClient;
        public EmployeeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            var result =  await httpClient.PostAsJsonAsync<Employee>("api/employees", employee);
            return await result.Content.ReadFromJsonAsync<Employee>();
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await httpClient.GetFromJsonAsync<Employee>($"api/employees/{id}");
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await httpClient.GetFromJsonAsync<Employee[]>("api/employees");
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result =  await httpClient.PutAsJsonAsync<Employee>("api/employees",employee);
            return await result.Content.ReadFromJsonAsync<Employee>();
        }
        public async Task DeleteEmployee(int employeeId)
        {
             await httpClient.DeleteAsync($"api/employees/{employeeId}");
        }

    }
}
