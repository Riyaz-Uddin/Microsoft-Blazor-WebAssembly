using CrudWebAssemblyR51.Server.Data;
using CrudWebAssemblyR51.Shared;

namespace CrudWebAssemblyR51.Server.Interface
{
    public interface Idoctorpatient 
    {
        public string AddDoctorPatientVM(DoctorPatientVM md2);
        public string RemoveDoctorPatientVM(string id);
        public string UpdateDoctorPatientVM(DoctorPatientVM md);
        public List<Doctor> GetTwoTables();
        public DoctorPatientVM GetTwoTables2(string id);
        public string GenerateCode();
        public int Child_Exists(string id);

    }
}
