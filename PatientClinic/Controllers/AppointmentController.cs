using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using PatientClinic.Models;
using PatientClinic.DAL;

namespace PatientClinic.Controllers
{
    public class AppointmentController : ApiController
    {
        private ClinicContext db = new ClinicContext();

        // GET api/Appointment
        public IEnumerable<Appointment> GetAppointments()
        {
            var appointments = db.Appointments.Include(a => a.Doctor);
            return appointments.AsEnumerable();
        }

        // GET api/Appointment/5
        public Appointment GetAppointment(int id)
        {
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return appointment;
        }

        // PUT api/Appointment/5
        public HttpResponseMessage PutAppointment(int id, Appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != appointment.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(appointment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Appointment
        public HttpResponseMessage PostAppointment(Appointment appointment)
        {
            if (ModelState.IsValid)
            {

                //if doctor founded make the current appointment to current doctor 
                var doc = new Doctor();
                doc = appointment.Doctor;//(Doctor)db.Appointments.Where(x => x.Doctor.Name == appointment.Doctor.Name).Select(x => x.Doctor);
                var docs = db.Doctors.Where(x => x.Id == doc.Id).Select(x=>x).First();
                if(docs!=null)
                appointment.Doctor = docs;
                //else make new doctor
             

                db.Appointments.Add(appointment);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, appointment);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = appointment.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Appointment/5
        public HttpResponseMessage DeleteAppointment(int id)
        {
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Appointments.Remove(appointment);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, appointment);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}