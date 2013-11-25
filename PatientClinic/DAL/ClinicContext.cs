using PatientClinic.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PatientClinic.DAL
{
    public class ClinicContext:DbContext
    {

        public ClinicContext() : base("DefaultConnection") { }

        public DbSet<Doctor> Doctors { set; get; }
        public DbSet<Appointment> Appointments { set; get; }

    }
}