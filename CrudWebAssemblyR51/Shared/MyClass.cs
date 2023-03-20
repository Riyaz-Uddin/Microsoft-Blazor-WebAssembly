using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWebAssemblyR51.Shared
{
    public class Doctor
    {
        [Key]
        public string Doctor_Code { get; set; }
        public string DoctorName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public int Tel { get; set; }
        public string Designation { get; set; }
        public virtual ICollection<Patient>? patients { get; set; }
    }

    public class Patient
    {
        [Key]
        public string Patient_Id { get; set; }
        public string PatientName { get; set; }
        [ForeignKey("doctors")]
        public string Doctor_Code { get; set; }
        public string Gender { get; set; }
        public string Number { get; set; }
        public DateTime Date        { get; set; }
        public bool Active { get; set; }
        public string Image { get; set; }
        public virtual Doctor? doctors { get; set; }
    }
    public class DoctorPatientVM
    {
        public DoctorPatientVM()
        {
            this.Doctors = new Doctor();
            this.Patients = new List<Patient>();
            /* do nothing */
        }
        public Doctor Doctors { get; set; }
        public List<Patient> Patients { get; set; }
    }
    public class ImageFile
    {
        public string base64data { get; set; }
        public string contentType { get; set; }
        public string fileName { get; set; }
    }

}
