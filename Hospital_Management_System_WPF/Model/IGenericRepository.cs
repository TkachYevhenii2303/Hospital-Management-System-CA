using Hospital_Management_System_Domains.Entities.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System_WPF.Model
{
    public interface IGenericRepository
    {
        bool AuthenticateUser(NetworkCredential credential);

        UserModel ReturnEntityByUsername(string username);
    }
}
