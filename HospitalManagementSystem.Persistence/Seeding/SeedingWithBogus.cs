using Bogus;
using Hospital_Management_System_DAL.Entities;
using Hospital_Management_System_DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System_Persistence.Seeding
{
    public class SeedingWithBogus
    {
        #region Collections of all Entities for Seeding methods!

        public IReadOnlyCollection<Employees> Employees { get; set; } = new List<Employees>();

        public IReadOnlyCollection<Positions> Positions { get; set; } = new List<Positions>();

        public IReadOnlyCollection<HasRoles> HasRoles { get; set; } = new List<HasRoles>();

        public IReadOnlyCollection<Hospitals> Hospitals { get; set; } = new List<Hospitals>();

        public IReadOnlyCollection<Departments> Departments { get; set; } = new List<Departments>();

        public IReadOnlyCollection<InDepartments> InDepartments { get; set; } = new List<InDepartments>();

        public IReadOnlyCollection<Shedules> Shedules { get; set; } = new List<Shedules>();

        public IReadOnlyCollection<Patients> Patients { get; set; } = new List<Patients>();

        public IReadOnlyCollection<PatientsCases> PatientsCases { get; set; } = new List<PatientsCases>();

        public IReadOnlyCollection<AppointmentsStatuses> AppointmentsStatuses { get; set; } = new List<AppointmentsStatuses>();

        public IReadOnlyCollection<Appointments> Appointments { get; set; } = new List<Appointments>();

        public IReadOnlyCollection<StatusHistories> StatusHistories { get; set; } = new List<StatusHistories>();

        public IReadOnlyCollection<DocumentsTypes> DocumentsTypes { get; set; } = new List<DocumentsTypes>();

        public IReadOnlyCollection<Documents> Documents { get; set; } = new List<Documents>();

        #endregion

        #region Const values for the seeding methods as parameter for Generator(int amount);

        private const int EMPLOYEES = 100;

        private const int HAS_ROLES = 100;

        private const int ROLES = 5;

        private const int HOSPITALS = 25;

        private const int DEPARTMENTS = 75;

        private const int IN_DEPARTMENTS = 200;

        private const int SHEDULES = 150;

        private const int PATIENTS = 200;

        private const int PATIENTS_CASES = 200;

        private const int APPOINTMENTS_STATUS = 5;

        private const int APPOINTMENTS = 150;

        private const int STATUS_HISTORIES = 100;

        private const int DOCUMENTS_TYPES = 5;

        private const int DOCUMENTS = 50;

        private const int USER_MODELS = 10;

        #endregion

        public SeedingWithBogus()
        {
            Employees = SeedingEmployees();

            Positions = SeedingPositions();

            HasRoles = SeedingHasRoles(Employees, Positions);

            Hospitals = SeedingHospitals();

            Departments = SeedingDepartments(Hospitals);

            InDepartments = SeedingInDepartments(Employees, Departments);

            Shedules = SeedingShedules(InDepartments);

            Patients = SeedingPatients();

            PatientsCases = SeedingPatientsCases(Patients);

            AppointmentsStatuses = SeedingAppointmentsStatus();

            Appointments = SeedingAppointments(InDepartments, PatientsCases);

            StatusHistories = SeedingStatusHistories(AppointmentsStatuses, Appointments);

            DocumentsTypes = SeedingDocumentsTypes();

            Documents = SeedingDocuments(Patients, PatientsCases, InDepartments, DocumentsTypes);
        }

        private static IReadOnlyCollection<Employees> SeedingEmployees()
        {
            var employees = new Faker<Employees>()
                .RuleFor(x => x.FirstName, f => f.Person.FirstName)
                .RuleFor(x => x.LastName, f => f.Person.LastName)
                .RuleFor(x => x.Email, (f, o) => f.Internet.Email(o.FirstName, o.LastName))
                .RuleFor(x => x.Mobile, f => f.Phone.PhoneNumber())
                .RuleFor(x => x.Password, f => f.Internet.Password())
                .RuleFor(x => x.ActiveIs, f => f.Random.Bool())
                .Generate(EMPLOYEES);

            return employees;
        }

        private static IReadOnlyCollection<Positions> SeedingPositions()
        {
            var roles = new Faker<Positions>().Generate(ROLES);

            var rolesTypes = Enum.GetNames(typeof(RolesTypesEnum));

            for (int i = 0; i < roles.Count; i++) { roles.ToArray()[i].RolesTitle = rolesTypes[i]; }

            return roles;
        }

        private static IReadOnlyCollection<HasRoles> SeedingHasRoles(IEnumerable<Employees> employees, IEnumerable<Positions> roles)
        {
            var hasRoles = new Faker<HasRoles>()
                .RuleFor(x => x.RolesId, f => f.PickRandom(roles).ID)
                .RuleFor(x => x.EmployeesId, f => f.PickRandom(employees).ID)
                .Generate(HAS_ROLES);

            return hasRoles;
        }

        private static IReadOnlyCollection<Hospitals> SeedingHospitals()
        {
            var hospitals = new Faker<Hospitals>()
               .RuleFor(x => x.HospitalTitle, f => f.Company.CompanyName())
               .RuleFor(x => x.Details, f => f.Company.CatchPhrase())
               .RuleFor(x => x.Address, f => f.Address.FullAddress())
               .Generate(HOSPITALS);

            return hospitals;
        }

        private static IReadOnlyCollection<Departments> SeedingDepartments(IEnumerable<Hospitals> hospitals)
        {
            var departments = new Faker<Departments>()
                .RuleFor(x => x.DepartmentTitle, f => f.Commerce.Department())
                .RuleFor(x => x.HospitalId, f => f.PickRandom(hospitals).ID)
                .Generate(DEPARTMENTS);

            return departments;
        }

        private static IReadOnlyCollection<InDepartments> SeedingInDepartments(IEnumerable<Employees> employees, IEnumerable<Departments> departments)
        {
            var inDepartments = new Faker<InDepartments>()
               .RuleFor(x => x.TimeFrom, f => f.Date.Past())
               .RuleFor(x => x.TimeTo, f => f.Date.Future())
               .RuleFor(x => x.ActiveIs, f => f.Random.Bool())
               .RuleFor(x => x.EmployeesId, f => f.PickRandom(employees).ID)
               .RuleFor(x => x.DepartmentsId, f => f.PickRandom(departments).ID)
               .Generate(IN_DEPARTMENTS);

            return inDepartments;
        }

        private static IReadOnlyCollection<Shedules> SeedingShedules(IEnumerable<InDepartments> inDepartments)
        {
            var shedules = new Faker<Shedules>()
               .RuleFor(x => x.TimeStart, f => f.Date.Past())
               .RuleFor(x => x.TimeEnd, f => f.Date.Future())
               .RuleFor(x => x.InDepartmentsId, f => f.PickRandom(inDepartments).ID)
               .Generate(SHEDULES);

            return shedules;
        }

        private static IReadOnlyCollection<Patients> SeedingPatients()
        {
            var patients = new Faker<Patients>()
                .RuleFor(x => x.FirstName, f => f.Person.FirstName)
                .RuleFor(x => x.LastName, f => f.Person.LastName)
                .RuleFor(x => x.Email, (f, o) => f.Internet.Email(o.FirstName, o.LastName))
                .RuleFor(x => x.Mobile, f => f.Phone.Locale)
                .Generate(PATIENTS);

            return patients;
        }

        private static IReadOnlyCollection<PatientsCases> SeedingPatientsCases(IEnumerable<Patients> patients)
        {
            var patientsCases = new Faker<PatientsCases>()
               .RuleFor(x => x.StartTime, f => f.Date.Past())
               .RuleFor(x => x.EndTime, f => f.Date.Future())
               .RuleFor(x => x.TotalCost, f => f.Finance.Amount())
               .RuleFor(x => x.PatientsId, f => f.PickRandom(patients).ID)
               .Generate(PATIENTS_CASES);

            return patientsCases;
        }

        private static IReadOnlyCollection<AppointmentsStatuses> SeedingAppointmentsStatus()
        {
            var appointmentStatuses = new Faker<AppointmentsStatuses>().Generate(APPOINTMENTS_STATUS);

            var Statuses = Enum.GetNames(typeof(AppointmentsStatusTypesEnum));

            for (int i = 0; i < appointmentStatuses.Count; i++) { appointmentStatuses[i].StatusTitle = Statuses[i]; }

            return appointmentStatuses;
        }

        private static IReadOnlyCollection<Appointments> SeedingAppointments(IEnumerable<InDepartments> inDepartments, IEnumerable<PatientsCases> patientsCases)
        {
            var appointments = new Faker<Appointments>()
               .RuleFor(x => x.AppointmentStartTime, f => f.Date.Past())
               .RuleFor(x => x.AppointmentEndTtime, f => f.Date.Future())
               .RuleFor(x => x.InDepartmentsId, f => f.PickRandom(inDepartments).ID)
               .RuleFor(x => x.PatientCasesId, f => f.PickRandom(patientsCases).ID)
               .Generate(APPOINTMENTS);

            return appointments;
        }

        private static IReadOnlyCollection<StatusHistories> SeedingStatusHistories(IEnumerable<AppointmentsStatuses> appointmentsStatuses, IEnumerable<Appointments> appointments)
        {
            var statusHistories = new Faker<StatusHistories>()
                .RuleFor(x => x.Details, f => f.Commerce.Product())
                .RuleFor(x => x.AppointmentStatusId, f => f.PickRandom(appointmentsStatuses).ID)
                .RuleFor(x => x.AppointmentsId, f => f.PickRandom(appointments).ID)
                .Generate(STATUS_HISTORIES);

            return statusHistories;
        }

        private static IReadOnlyCollection<DocumentsTypes> SeedingDocumentsTypes()
        {
            var documentsTypes = new Faker<DocumentsTypes>().Generate(DOCUMENTS_TYPES);

            var Documents = Enum.GetNames(typeof(DocumentsTypesEnum));

            for (int i = 0; i < documentsTypes.Count; i++) { documentsTypes.ToArray()[i].TypesTitle = Documents[i]; }

            return documentsTypes;
        }

        private static IReadOnlyCollection<Documents> SeedingDocuments(IEnumerable<Patients> patients, IEnumerable<PatientsCases> patientsCases, IEnumerable<InDepartments> inDepartments, IEnumerable<DocumentsTypes> documentsTypes)
        {
            var documents = new Faker<Documents>()
                .RuleFor(x => x.DocumentsTitle, f => f.Commerce.Product())
                .RuleFor(x => x.DocumentsDetails, f => f.Commerce.Color())
                .RuleFor(x => x.DocumentsLink, f => f.Internet.Url())
                .RuleFor(x => x.PatientsId, f => f.PickRandom(patients).ID)
                .RuleFor(x => x.InDepartmentId, f => f.PickRandom(inDepartments).ID)
                .RuleFor(x => x.DocumentsTypesId, f => f.PickRandom(documentsTypes).ID)
                .RuleFor(x => x.PatientCaseId, f => f.PickRandom(patientsCases).ID)
                .Generate(DOCUMENTS);

            return documents;
        }
    }
}
