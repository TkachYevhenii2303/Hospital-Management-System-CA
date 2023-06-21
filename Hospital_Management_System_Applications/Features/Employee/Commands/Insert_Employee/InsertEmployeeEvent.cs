using Hospital_Management_System_DAL.Entities;
using Hospital_Management_System_Domains.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System_Applications.Features.Employee.Commands.Insert_Employee
{
    public class InsertEmployeeEvent : BaseEvent
    {
        public Employees Employees { get; }

        public InsertEmployeeEvent(Employees employees) => this.Employees = employees;
    }
}
