using System.Collections.Generic;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class EmployeeService
    {
        private CategoryRepo _employeeRepo;
        
        public EmployeeService()
        {
            _employeeRepo = new CategoryRepo();
        }

        
    }
}