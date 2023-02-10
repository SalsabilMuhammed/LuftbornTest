using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class DataSeeding
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DataBaseContext
            (serviceProvider.GetRequiredService<DbContextOptions<DataBaseContext>>()))
            {
                if (context.Departments.Any() || context.Employees.Any())
                    return;
                context.Departments.AddRange(
                new Department
                {
                    Name = "Developing",

                },
                 new Department
                 {
                     Name = "IT",

                 },
                  new Department
                  {
                      Name = "Finance",

                  },
                   new Department
                   {
                       Name = "HR",
                   }
                   );

                context.SaveChanges();

                context.Employees.AddRange(
                    new Employee
                    {
                        Name = "Mohamed",
                        Address = "Egypt",
                        DepartmentId = context.Departments.Any() ? context.Departments.FirstOrDefault().Id : -1,
                    },
                    new Employee
                    {
                        Name = "Ahmed",
                        Address = "Egypt",
                        DepartmentId = context.Departments.Any() ? context.Departments.FirstOrDefault().Id : -1,
                    },
                    new Employee
                    {
                        Name = "Rafiq",
                        Address = "Egypt",
                        DepartmentId = context.Departments.Any() ? context.Departments.FirstOrDefault().Id : -1,
                    },
                    new Employee
                    {
                        Name = "Salsabil",
                        Address = "Egypt",
                        DepartmentId = context.Departments.Any() ? context.Departments.FirstOrDefault().Id : -1,
                    },  new Employee
                    {
                        Name = "Mahmoud",
                        Address = "Egypt",
                        DepartmentId = context.Departments.Any() ? context.Departments.FirstOrDefault().Id : -1,
                    },  new Employee
                    {
                        Name = "Hossam",
                        Address = "Egypt",
                        DepartmentId = context.Departments.Any() ? context.Departments.FirstOrDefault().Id : -1,
                    },  new Employee
                    {
                        Name = "Mina",
                        Address = "Egypt",
                        DepartmentId = context.Departments.Any() ? context.Departments.FirstOrDefault().Id : -1,
                    },  new Employee
                    {
                        Name = "Magdy",
                        Address = "Egypt",
                        DepartmentId = context.Departments.Any() ? context.Departments.FirstOrDefault().Id : -1,
                    },  new Employee
                    {
                        Name = "Mohamed",
                        Address = "Egypt",
                        DepartmentId = context.Departments.Any() ? context.Departments.FirstOrDefault().Id : -1,
                    },  new Employee
                    {
                        Name = "Salsabil",
                        Address = "Egypt",
                        DepartmentId = context.Departments.Any() ? context.Departments.FirstOrDefault().Id : -1,
                    }
                 
                );

                context.SaveChanges();
            }
        }
    }
}
