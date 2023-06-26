
using System.Text.Json.Serialization;

namespace Hospital_Management_System_DAL.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RolesTypesEnum
    {
        Dermatologist = 0,

        Pediatrics = 1,

        Neurologist  = 2,

        Ophthalmology = 3,

        Dermatology = 4,
    }
}
