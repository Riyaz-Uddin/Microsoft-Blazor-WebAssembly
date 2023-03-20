using CrudWebAssemblyR51.Server.Data;
using CrudWebAssemblyR51.Server.Interface;
using CrudWebAssemblyR51.Shared;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.Arm;

namespace CrudWebAssemblyR51.Server.Services
{
    public class DoctorPatientService : Idoctorpatient
    {
        ApplicationDbContext RR;
        public DoctorPatientService(ApplicationDbContext _RR)
        {
            RR = _RR;
        }

        public string AddDoctorPatientVM(DoctorPatientVM dp2)
        {
            Doctor m = new Doctor() {
                Doctor_Code = dp2.Doctors.Doctor_Code,
                DoctorName = dp2.Doctors.DoctorName,
                Gender = dp2.Doctors.Gender,
                Address = dp2.Doctors.Address,
                Tel = dp2.Doctors.Tel,
                Designation = dp2.Doctors.Designation
            };
            RR.Doctors.Add(m);
            RR.SaveChanges();
            RR.Entry(m).State = EntityState.Detached;
            foreach (var c in dp2.Patients)
            {
                Patient d = new Patient() {
                    Patient_Id = c.Patient_Id,
                    PatientName = c.PatientName,
                    Doctor_Code = c.Doctor_Code,
                    Gender = c.Gender,
                    Number = c.Number,
                    Date = c.Date,
                    Active = c.Active,
                    Image = c.Image
                };
                RR.Patients.Add(d);
            }
            RR.SaveChanges();

            return "1";
        }
        public string RemoveDoctorPatientVM(string id)
        {
            List<Patient> p2 = RR.Patients.Where(xx => xx.Doctor_Code == id).ToList();
            RR.Patients.RemoveRange(p2);
            RR.SaveChanges();
            Doctor d2 = RR.Doctors.Find(id);
            if (d2 != null)
            {
                RR.Doctors.Remove(d2);
            }
            RR.SaveChanges();

            return "1";
        }
        public string UpdateDoctorPatientVM(DoctorPatientVM dp)
        {
            RemoveDoctorPatientVM(dp.Doctors.Doctor_Code);
            AddDoctorPatientVM(dp);
            return "1";
        }
        public List<Doctor> GetTwoTables()
        {
            List<Doctor> md = new List<Doctor>();

            md = (from d in RR.Doctors select d).ToList();
            //var jo = JsonSerializer.Deserialize<Master>(a);
            return md;
        }

        public DoctorPatientVM GetTwoTables2(string id)
        {
            DoctorPatientVM md = new DoctorPatientVM();
            Doctor a = new Doctor();
            a = (from d in RR.Doctors where d.Doctor_Code == id select d).FirstOrDefault();
            md.Doctors = a;
            List<Patient> b = new List<Patient>();
            b = (from d in RR.Patients where d.Doctor_Code == id select d).ToList();
            md.Patients = b;
            if (a != null) RR.Entry(a).State = EntityState.Detached;
            return md;

        }

        public string GenerateCode()
        {
            string a1 = "";
            string b1 = "";

            try
            {
                var a = (from det in RR.Doctors select det.Doctor_Code.Substring(3)).Max();
                if (a == null)
                    a = "0";
                int b = int.Parse(a.ToString()) + 1;
                if (b < 10)
                {
                    b1 = "000" + b.ToString();
                }
                else if (b < 100)
                {
                    b1 = "00" + b.ToString();
                }
                else if (b < 1000)
                {
                    b1 = "0" + b.ToString();
                }
                else
                {
                    b1 = b.ToString();
                }
                a1 = "AC-" + b1.ToString();
            }
            catch (Exception ex)
            {
                a1 = "AC-0001";
            }
            return a1;
        }

        public int Child_Exists(string id)
        {
            var a = (from p in RR.Patients where p.Patient_Id == id select new { p.Patient_Id, }).FirstOrDefault();
            if (a != null)
                return 1;
            else
                return 0;
        }


    }
}
