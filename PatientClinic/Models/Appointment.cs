using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientClinic.Models
{
    public class Appointment
    {

        public int Id { set; get; }
        public string FileNumber { set; get; }
        public DateTime? Date { set; get; }

        public string PatientName { set; get; }
        public string PatientEmail { set; get; }
        public string PatientPhone { set; get; }

        public virtual Doctor Doctor { set; get; }
        public  int DoctorId { set; get; }
    }
}