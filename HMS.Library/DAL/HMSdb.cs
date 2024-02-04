using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Library.Models;
using HMS.Library.Types;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace HMS.Library.DAL
{
	public class HMSdb : IdentityDbContext
	{
        public DbSet<Admission> Admissions { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Billing> Billings { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Discharge> Discharges { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Emergency> Emergencies { get; set; }
        public DbSet<Followup> Followups { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescribe> Prescribes { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Ward> Wards { get; set; }
        public DbSet<ReportType> ReportTypes { get; set; }
        public DbSet<BloodType> BloodTypes { get; set; }
        public DbSet<AppointmentType> AppointmentTypes { get; set; }


        public HMSdb(DbContextOptions opt) : base(opt)
        {
            
        }
    }
}
