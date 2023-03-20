using CrudWebAssemblyR51.Server.Interface;
using CrudWebAssemblyR51.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudWebAssemblyR51.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DPController : ControllerBase
    {
        private readonly Idoctorpatient _Idoctorpatient;
        public DPController(Idoctorpatient doctorpatient)
        {
            _Idoctorpatient = doctorpatient;
        }
        [HttpGet]
        public async Task<List<Doctor>> Get()
        {
            return await Task.FromResult(_Idoctorpatient.GetTwoTables());
        }
        [HttpGet("{id}")]
        public DoctorPatientVM Get(string id)
        {

            DoctorPatientVM DP = _Idoctorpatient.GetTwoTables2(id);
            return DP;

        }
        [HttpPost]
        public string AddDoctorPatientVM(DoctorPatientVM md2)
        {
            _Idoctorpatient.AddDoctorPatientVM(md2);
            return "1";

        }
        [HttpPut]
        public string UpdateDoctorPatientVM(DoctorPatientVM md)
        {
            _Idoctorpatient.UpdateDoctorPatientVM(md);
            return "2";
        }
        [HttpDelete("{id}")]
        public string RemoveDoctorPatientVM(string id)
        {
            _Idoctorpatient.RemoveDoctorPatientVM(id);
            return "1";
        }

    }
}
