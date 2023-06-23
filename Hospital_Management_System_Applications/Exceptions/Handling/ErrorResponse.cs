using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Hospital_Management_System_Applications.Exceptions.Handling
{
    public class ErrorResponse
    {
        public string Message { get; set; } = string.Empty;

        public bool Success { get; set; }

        public override string ToString() => JsonSerializer.Serialize(this);
    }
}
