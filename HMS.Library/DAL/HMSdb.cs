using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Library.Models;
using HMS.Library.Types;
using Microsoft.AspNetCore.Identity;
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
		public DbSet<BillingDetails> BillingDetails { get; set; }
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
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<IdentityUserLogin<string>>()
			.HasKey(u => new { u.UserId, u.LoginProvider, u.ProviderKey });

			modelBuilder.Entity<IdentityUserRole<string>>()
			.HasKey(r => new { r.UserId, r.RoleId });


			modelBuilder.Entity<BloodType>().HasData(new BloodType[]
			{
				new BloodType
				{
					BloodTypeId = 1,
					Name = "A+"
				},
				new BloodType
				{
					BloodTypeId = 2,
					Name = "A-"
				},
				new BloodType
				{
					BloodTypeId = 3,
					Name = "AB+"
				},
				new BloodType
				{
					BloodTypeId = 4,
					Name = "AB-"
				},
				new BloodType
				{
					BloodTypeId = 5,
					Name = "B+"
				},
				new BloodType
				{
					BloodTypeId = 6,
					Name = "B-"
				},
				new BloodType
				{
					BloodTypeId = 7,
					Name = "O+"
				},
				new BloodType
				{
					BloodTypeId = 8,
					Name = "O-"
				}
			});

			modelBuilder.Entity<ReportType>().HasData(new ReportType[]
			{
				new ReportType
				{
					ReportTypeId = 1,
					Name = "Discharge Summary"
				},
				new ReportType
				{
					ReportTypeId = 2,
					Name = "Pathology Report"
				},
				new ReportType
				{
					ReportTypeId = 3,
					Name = "Laboratory Report"
				},
				new ReportType
				{
					ReportTypeId = 4,
					Name = "Consultation Report"
				},
				new ReportType
				{
					ReportTypeId = 5,
					Name = "Anesthesia Report"
				}

			});


			modelBuilder.Entity<AppointmentType>().HasData(new AppointmentType[]
			{
				new AppointmentType
				{
					AppointmentTypeId = 1,
					Name = "General Consultation"
				},
				new AppointmentType
				{
					AppointmentTypeId = 2,
					Name = "Specialist Consultation"
				},
				new AppointmentType
				{
					AppointmentTypeId = 3,
					Name = "Follow-up Appointment"
				},
				new AppointmentType
				{
					AppointmentTypeId = 4,
					Name = "Maternity Appointment"
				},
				new AppointmentType
				{
					AppointmentTypeId = 5,
					Name = "Vaccination/Immunization"
				},
				new AppointmentType
				{
					AppointmentTypeId = 6,
					Name = "Surgical Consultation"
				},
				new AppointmentType
				{
					AppointmentTypeId = 7,
					Name = "Emergency Consultation"
				},
				new AppointmentType
				{
					AppointmentTypeId = 8,
					Name = "Nutritional Counseling"
				},
				new AppointmentType
				{
					AppointmentTypeId = 9,
					Name = "Lab Work or Blood Tests"
				}

			});
		}

	}
}
