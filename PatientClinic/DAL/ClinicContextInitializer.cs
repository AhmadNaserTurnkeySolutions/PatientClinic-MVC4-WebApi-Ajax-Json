using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PatientClinic.Models;
namespace PatientClinic.DAL
{
    public class ClinicContextInitializer:DropCreateDatabaseAlways<ClinicContext>
    {

        protected override void Seed(ClinicContext context)
        {

            Doctor d1 = new Doctor { Id=1,Name="Ali",Phone="059939393",Address="Ramallah"};
            Doctor d2 = new Doctor { Id = 2, Name = "Mahmoud", Phone = "059939393", Address = "Ramallah" };
            Doctor d3 = new Doctor { Id = 3, Name = "Sami", Phone = "059939393", Address = "Ramallah" };
            Doctor d4 = new Doctor { Id = 4, Name = "Tom", Phone = "059939393", Address = "Ramallah" };

            context.Doctors.Add(d1);
            context.Doctors.Add(d2);
            context.Doctors.Add(d3);
            context.Doctors.Add(d4);

            Appointment p1 = new Appointment { Id=1,Doctor=d1,DoctorId=d1.Id,Date=DateTime.Now,FileNumber="ax-112132",PatientPhone="054544545",PatientName="John",PatientEmail="john@em.com"};
            Appointment p2 = new Appointment { Id = 2, Doctor = d2, DoctorId = d2.Id, Date = DateTime.Now, FileNumber = "ax-112132", PatientPhone = "054544541", PatientName = "Criss", PatientEmail = "criss@em.com" };


            context.Appointments.Add(p1);
            context.Appointments.Add(p2);

            context.SaveChanges();
        }

    }
}