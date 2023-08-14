using Hospital_Management_System_DAL.Entities;
using Hospital_Management_System_Domains.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System_Applications.Features.Employee.Commands.Delete_Employee
{
    public class DeleteEmployeeEvent : BaseEvent
    {
        public Employees Employees { get; }

        public DeleteEmployeeEvent(Employees employees)
        {
            Employees = employees;
        }
    }
}
