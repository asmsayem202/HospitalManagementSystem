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
	public class HMSdb : IdentityDbContext<ApplicationUser>
	{
		public DbSet<Admission> Admissions { get; set; }
		public DbSet<Appointment> Appointments { get; set; }
		public DbSet<Billing> Billings { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<Discharge> Discharges { get; set; }
		public DbSet<Doctor> Doctors { get; set; }
		public DbSet<Emergency> Emergencies { get; set; }
		public DbSet<InventoryItem> InventoryItems { get; set; }
		public DbSet<Nurse> Nurses { get; set; }
		public DbSet<Patient> Patients { get; set; }
		public DbSet<AppointmentPrescribe> AppointmentPrescribes { get; set; }
		public DbSet<AppointmentPrescribeDetails> AppointmentPrescribeDetails { get; set; }
		public DbSet<EmergencyPrescribe> EmergencyPrescribes { get; set; }
		public DbSet<EmergencyPrescribeDetails> EmergencyPrescribeDetails { get; set; }
		public DbSet<Report> Reports { get; set; }
		public DbSet<Room> Rooms { get; set; }
		public DbSet<Staff> Staffs { get; set; }
		public DbSet<Supplier> Suppliers { get; set; }
		public DbSet<Transaction> Transactions { get; set; }
		public DbSet<Ward> Wards { get; set; }
		public DbSet<ReportType> ReportTypes { get; set; }
		public DbSet<BloodType> BloodTypes { get; set; }
		public DbSet<AppointmentType> AppointmentTypes { get; set; }
		public object Doctor { get; set; }

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


			modelBuilder.Entity<Department>().HasData(new Department[]
			{
				new Department
				{
					DepartmentId = 1,
					Name = "Medicine"
				},
				new Department
				{
					DepartmentId = 2,
					Name = "ENT"
				},
				new Department
				{
					DepartmentId = 3,
					Name = "Child"
				},
				new Department
				{
					DepartmentId = 4,
					Name = "Gynecology"
				},
				new Department
				{
					DepartmentId = 5,
					Name = "BurnUnit"
				},
				new Department
				{
					DepartmentId = 6,
					Name = "Cardiology"
				},
				new Department
				{
					DepartmentId = 7,
					Name = "Orthopedic"
				},
				new Department
				{
					DepartmentId = 8,
					Name = "Surgical"
				},
				new Department
				{
					DepartmentId = 9,
					Name = "Neurology"
				},
				new Department
				{
					DepartmentId = 10,
					Name = "Dental"
				}
			});



			modelBuilder.Entity<Doctor>().HasData(new Doctor[]
			{
				new Doctor
				{
					DoctorId = 1,
					Name = "Dr. Farhana Rahman",
					Specialization = "Gynecologist",
					ContactNo = "+880-181-2225587",
					Email = "farhana@example.com",
					Schedule = "Sat-Thu 10-1",
					Shift = ShiftType.Morning_6am_To_2pm,
					//Image = "doctor_farhana.jpg",
					DepartmentID = 1
				},
				new Doctor
				{
					DoctorId = 2,
					Name = "Dr. Mohammad Rahman",
					Specialization = "Cardiologist",
					ContactNo = "+880-171-1234567",
					Email = "mohammad.rahman@example.com",
					Schedule = "Sun-Thu 9-1",
					Shift = ShiftType.Afternoon_2pm_To_10pm,
					//Image = "doctor_mohammad.jpg",
					DepartmentID = 1
				},

				new Doctor
				{
					DoctorId = 3,
					Name = "Dr. Fatima Ahmed",
					Specialization = "Dermatologist",
					ContactNo = "+880-191-9876543",
					Email = "fatima.ahmed@example.com",
					Schedule = "Sun-Thu 10-2",
					Shift = ShiftType.Night_10pm_To_6am,
					//Image = "doctor_fatima.jpg",
					DepartmentID = 2
				},

				 new Doctor
				 {
					DoctorId = 4,
					Name = "Dr. Ayesha Khan",
					Specialization = "Neurologist",
					ContactNo = "+880-181-8765432",
					Email = "ayesha.khan@example.com",
					Schedule = "Sun-Thu 8-12",
					Shift = ShiftType.Morning_6am_To_2pm,
					//Image = "doctor_ayesha.jpg",
					DepartmentID = 2
				},

				new Doctor
				{
					DoctorId = 5,
					Name = "Dr. Nazia Islam",
					Specialization = "Obstetrician",
					ContactNo = "+880-171-2345678",
					Email = "nazia.islam@example.com",
					Schedule = "Sat-Thu 9-1",
					Shift = ShiftType.Afternoon_2pm_To_10pm,
					//Image = "doctor_nazia.jpg",
					DepartmentID = 3
				},

			   new Doctor
				{
					DoctorId = 6,
					Name = "Dr. Kamal Hossain",
					Specialization = "Endocrinologist",
					ContactNo = "+880-191-3456789",
					Email = "kamal.hossain@example.com",
					Schedule = "Sat-Thu 10-2",
					Shift = ShiftType.Night_10pm_To_6am,
					//Image = "doctor_kamal.jpg",
					DepartmentID = 3
				},

				 new Doctor
				{
					DoctorId = 7,
					Name = "Dr. Sabrina Yasmin",
					Specialization = "Ophthalmologist",
					ContactNo = "+880-181-4567890",
					Email = "sabrina.yasmin@example.com",
					Schedule = "Sat-Thu 8-12",
					Shift = ShiftType.Morning_6am_To_2pm,
					//Image = "doctor_sabrina.jpg",
					DepartmentID = 4
				},

			new Doctor
			{
				DoctorId = 8,
				Name = "Dr. Rahman Chowdhury",
				Specialization = "Orthodontist",
				ContactNo = "+880-171-5678901",
				Email = "rahman.chowdhury@example.com",
				Schedule = "Sat-Thu 9-1",
				Shift = ShiftType.Afternoon_2pm_To_10pm,
                //Image = "doctor_rahman.jpg",
                DepartmentID = 4
			}
			});

			modelBuilder.Entity<Patient>().HasData(new Patient[]

			{
				new Patient
				{
					PatientId = 1,
					Name = "Ayesha Rahman",
					Gender = Genders.Female,
					Age = 28,
					ContactNo = "+880-171-1234567",
					Email = "ayesha.rahman@example.com",
					Address = "123 ABC Street, Dhaka",
					BloodTypeID = 1,
					InsuranceInformation = "Policy #123456",
					Status = "Active"
				},
				new Patient
				{
					PatientId = 2,
					Name = "Mohammad Ali",
					Gender = Genders.Male,
					Age = 30,
					ContactNo = "+880-191-2345678",
					Email = "mohammad.ali@example.com",
					Address = "456 XYZ Road, Chittagong",
					BloodTypeID = 2,
					InsuranceInformation = "Policy #789012",
					Status = "Active"
				},
				new Patient
				{
					PatientId = 3,
					Name = "Fatima Khan",
					Gender = Genders.Female,
					Age = 32,
					ContactNo = "+880-181-3456789",
					Email = "fatima.khan@example.com",
					Address = "789 LMN Avenue, Sylhet",
					BloodTypeID = 3,
					InsuranceInformation = "Policy #345678",
					Status = "Active"
				},

				new Patient
				{
					PatientId = 4,
					Name = "Rahim Khan",
					Gender = Genders.Male,
					Age = 26,
					ContactNo = "+880-171-4567890",
					Email = "rahim.khan@example.com",
					Address = "321 PQR Lane, Rajshahi",
					BloodTypeID = 1,
					InsuranceInformation = "Policy #234567",
					Status = "Active"
				},

				new Patient
				{
					PatientId = 5,
					Name = "Nusrat Jahan",
					Gender = Genders.Female,
					Age = 33,
					ContactNo = "+880-191-5678901",
					Email = "nusrat.jahan@example.com",
					Address = "789 XYZ Street, Khulna",
					BloodTypeID = 2,
					InsuranceInformation = "Policy #890123",
					Status = "Active"
				},

					new Patient
				{
					PatientId = 6,
					Name = "Kamal Hossain",
					Gender = Genders.Male,
					Age = 29,
					ContactNo = "+880-181-6789012",
					Email = "kamal.hossain@example.com",
					Address = "147 LMN Road, Barishal",
					BloodTypeID = 3,
					InsuranceInformation = "Policy #456789",
					Status = "Active"
				}

						 // Add more patients as needed...

			});

			modelBuilder.Entity<Supplier>().HasData(new Supplier[]
			{
			  new Supplier
			  {
			   SupplierId = 1,
			   Name="Timely Product Ltd.",
			   Email="timelyproductltd.@gmail.com",
			   ContactNo="01823456612",
			   Address="ctg"

			   },

			 new Supplier
			 {
			   SupplierId = 2,
			   Name=" Crifoo Intertrade Ltd.",
			   Email=" crifooIntertradeltd.@gmail.com",
			   ContactNo="01823456622",
			   Address="ctg"

			  },

			 new Supplier
			 {
			  SupplierId = 3,
			  Name=" 71 Care",
			  Email=" Care71@gmail.com",
			  ContactNo="01523457712",
			  Address="ctg"

			 },

			 new Supplier
			 {
			  SupplierId = 4,
			  Name="Continental Surgical House",
			  Email="continentalsurgicalhouse@gmail.com",
			  ContactNo="01823456999",
			  Address="Dhaka"

			  },

			 new Supplier
			 {
			 SupplierId = 5,
			  Name="Anifco Healthcare",
			  Email="anifcohealthcare@gmail.com",
			  ContactNo="01823459999",
			  Address="Dhaka"

			  },

			 new Supplier
			 {
			  SupplierId = 6,
			  Name="BMA Bazar",
			  Email="bmabazar777@gmail.com",
			  ContactNo="01823456777",
			  Address="ctg"

			  },
			});

			modelBuilder.Entity<InventoryItem>().HasData(new InventoryItem[]
			{
			 new InventoryItem
			 {
			   InventoryItemId = 1,
				Name = "Bandages",
				Price=100,
				Quantity=50,
				Category="latex",
				SupplierID = 2,
			  },
			 new InventoryItem
			 {
			   InventoryItemId = 3,
				Name = "Gauze pads",
				Price=10000,
				Quantity=500,
				Category="Normal",
				SupplierID = 1,
			  },
			 new InventoryItem
			 {
			   InventoryItemId = 4,
				Name = "Syringes",
				Price=1000,
				Quantity=50,
				Category="10ml",
				SupplierID = 1,
			  },
			 new InventoryItem
			 {
			   InventoryItemId = 5,
				Name = "Needles",
				Price=100,
				Quantity=50,
				Category="40mm",
				SupplierID = 3,
			  },
			 new InventoryItem
			 {
			   InventoryItemId = 6,
				Name = "IV catheters",
				Price=100,
				Quantity=50,
				Category="Peripheral IV",
				SupplierID = 4,
			  },
			 new InventoryItem
			 {
			   InventoryItemId = 7,
				Name = "Surgical masks",
				Price=100,
				Quantity=50,
				Category="Normal",
				SupplierID = 2,
			  },
			 new InventoryItem
			 {
			   InventoryItemId = 8,
				Name = "Alcohol swabs",
				Price=100,
				Quantity=50,
				Category="Antiseptics & Disinfectants",
				SupplierID = 5,
			  },
			 new InventoryItem
			 {
			   InventoryItemId = 9,
				Name = "Bandages",
				Price=100,
				Quantity=50,
				Category="Normal",
				SupplierID = 6,
			  },
			 new InventoryItem
			 {
			   InventoryItemId = 10,
				Name = "Bandages",
				Price=10000,
				Quantity=50,
				Category="general",
				SupplierID = 6,
			  },
			 });
			modelBuilder.Entity<Staff>().HasData(new Staff[]
			 {
			   new Staff
			  {
				StaffId = 1,
				StaffName="Md.Karim",
				Designation="Hospital Administrator",
				ContactNo="01823459999",
				Address="Dhaka",
				Email="karim@gmail.com",

			  },
			  new Staff
			  {
				StaffId = 2,
				StaffName="Md.Rahim",
				Designation="Chief Medical Officer (CMO)",
				ContactNo="01823459977",
				Address="ctg",
				Email="rahim@gmail.com",

			  },
			  new Staff
			  {
				StaffId = 3,
				StaffName="Mss.Jannat",
				Designation="Chief Nursing Officer (CNO)",
				ContactNo="01623459978",
				Address="Dhaka",
				Email="jannat@gmail.com",

			  },
			  new Staff
			  {
				StaffId = 4,
				StaffName="Md.Maruf",
				Designation="Director of Operations",
				ContactNo="01523459977",
				Address="ctg",
				Email="maruf@gmail.com",

			  },
			  new Staff
			  {
				StaffId = 5,
				StaffName="Md.Krim",
				Designation="Finance Manager",
				ContactNo="01823456645",
				Address="ctg",
				Email="krim45@gmail.com",

			  },
			  new Staff
			  {
				StaffId = 6,
				StaffName="Md.Hasib",
				Designation="Human Resources Manager:",
				ContactNo="01823459977",
				Address="Dhaka",
				Email="hasib@gmail.com",

			  },
			  new Staff
			  {
				StaffId = 7,
				StaffName="Md.Aziz",
				Designation="Information Technology (IT) Manager:",
				ContactNo="01523459990",
				Address="ctg",
				Email="aziz90@gmail.com",

			  },
			  new Staff
			  {
				StaffId = 8,
				StaffName="Md.Rashed",
				Designation="Quality Improvement Manager",
				ContactNo="01823459778",
				Address="ctg",
				Email="rashed78@gmail.com",

			  },
			  new Staff
			  {
				StaffId = 9,
				StaffName="Md.Habib",
				Designation="Medical Records Manager",
				ContactNo="01823459989",
				Address="Dhaka",
				Email="habib@gmail.com",

			  },
			  new Staff
			  {
				StaffId = 10,
				StaffName="Md.Adil",
				Designation="Supply Chain Manager",
				ContactNo="01823459999",
				Address="ctg",
				Email="adil@gmail.com",

			  },
			 });


			modelBuilder.Entity<Ward>().HasData(new Ward[]
			{
				new Ward
				{
					WardId = 1,
					Name = "Medicine ward "
				},
				new Ward
				{
					WardId = 2,
					Name = "ENT ward "
				},
				new Ward
				{
					WardId = 3,
					Name = "Child ward "
				},
				new Ward
				{
					WardId = 4,
					Name = "Gynecology Ward "
				},
				new Ward
				{
					WardId = 5,
					Name = "Burn Unit Ward"
				},
				new Ward
				{
					WardId = 6,
					Name = "Cardiology Ward"
				},
				new Ward
				{
					WardId = 7,
					Name = "Orthopedic Ward "
				},
				new Ward
				{
					WardId = 8,
					Name = "Surgical Ward "
				},
				new Ward
				{
					WardId = 9,
					Name = "Neurology Ward"
				},
				new Ward
				{
					WardId = 10,
					Name = "Dental Ward"
				},

			});


			modelBuilder.Entity<Nurse>().HasData(new Nurse[]
			{

				new Nurse
				{
				   NurseId = 1,
				   Name = "Lutfarnahar",
				   ContactNo = "0123456789",
				   Shift = ShiftType.Morning_6am_To_2pm,
				   WardID = 1,

				},
				new Nurse
				{
				   NurseId = 2,
				   Name = "Nahar",
				   ContactNo = "0123222789",
				   Shift = ShiftType.Afternoon_2pm_To_10pm,
				   WardID = 1,

				},

				new Nurse
				{
				   NurseId = 3,
				   Name = "Ayesha",
				   ContactNo = "0123336789",
				   Shift = ShiftType.Night_10pm_To_6am,
				   WardID = 1,

				},
				new Nurse
				{
				   NurseId = 4,
				   Name = "Jamila",
				   ContactNo = "0123456744",
				   Shift = ShiftType.Morning_6am_To_2pm,
				   WardID = 2,

				},
				new Nurse
				{
				   NurseId = 5,
				   Name = "Runa khatun",
				   ContactNo = "0123456775",
				   Shift = ShiftType.Afternoon_2pm_To_10pm,
				   WardID = 2,

				},
				new Nurse
				{
				   NurseId = 6,
				   Name = "Nasrin",
				   ContactNo = "0123456766",
				   Shift = ShiftType.Night_10pm_To_6am,
				   WardID = 2,

				},
				new Nurse
				{
				   NurseId = 7,
				   Name = "Arifa",
				   ContactNo = "0123456663",
				   Shift = ShiftType.Morning_6am_To_2pm,
				   WardID = 7,

				},
				new Nurse
				{
				   NurseId = 8,
				   Name = "Maria ",
				   ContactNo = "0123458879",
				   Shift = ShiftType.Afternoon_2pm_To_10pm,
				   WardID = 8,

				},

				new Nurse
				{
				   NurseId = 9,
				   Name = "Sanjida",
				   ContactNo = "0123452299",
				   Shift = ShiftType.Night_10pm_To_6am,
				   WardID = 9,

				},
				new Nurse
				{
				   NurseId = 10,
				   Name = "Riya ",
				   ContactNo = "0123412389",
				   Shift = ShiftType.Morning_6am_To_2pm,
				   WardID = 10,

				},
				new Nurse
				{
				   NurseId = 11,
				   Name = "Priya",
				   ContactNo = "0123789789",
				   Shift = ShiftType.Afternoon_2pm_To_10pm,
				   WardID = 1,

				},
				new Nurse
				{
				   NurseId = 12,
				   Name = "Puja Shill",
				   ContactNo = "0123455669",
				   Shift = ShiftType.Night_10pm_To_6am,
				   WardID = 2,

				},
				new Nurse
				{
				   NurseId = 13,
				   Name = "Ratna khatun",
				   ContactNo = "0188456789",
				   Shift = ShiftType.Morning_6am_To_2pm,
				   WardID = 3,

				},
				new Nurse
				{
				   NurseId = 14,
				   Name = "Tuli ",
				   ContactNo = "01643456789",
				   Shift = ShiftType.Afternoon_2pm_To_10pm,
				   WardID = 4,

				},
				new Nurse
				{
				   NurseId = 15,
				   Name = "Tasnia",
				   ContactNo = "0198456789",
				   Shift = ShiftType.Night_10pm_To_6am,
				   WardID = 5,

				},
				new Nurse
				{
				   NurseId = 16,
				   Name = "Urmi",
				   ContactNo = "0155456789",
				   Shift = ShiftType.Morning_6am_To_2pm,
				   WardID = 6,

				},
				new Nurse
				{
				   NurseId = 17,
				   Name = "Rahima",
				   ContactNo = "0155456689",
				   Shift = ShiftType.Afternoon_2pm_To_10pm,
				   WardID = 7,

				},
				new Nurse
				{
				   NurseId = 18,
				   Name = "Amena",
				   ContactNo = "0177756789",
				   Shift = ShiftType.Night_10pm_To_6am,
				   WardID = 8,

				},

				new Nurse
				{
				   NurseId = 19,
				   Name = "Latifa Akter",
				   ContactNo = "018976789",
				   Shift = ShiftType.Morning_6am_To_2pm,
				   WardID = 9,

				},
				new Nurse
				{
				   NurseId = 20,
				   Name = "Farin akter",
				   ContactNo = "012655569",
				   Shift = ShiftType.Afternoon_2pm_To_10pm,
				   WardID = 10,

				},
			});

			modelBuilder.Entity<Room>().HasData(new Room[]
			{
				new Room
				{
					RoomId = 1,
					RoomNumber = "A-101",
					Status = "Standard Room",
					WardID = 1
				},
				new Room
				{
					RoomId = 2,
					RoomNumber = "B-102",
					Status = "General Room ",
					WardID = 1
				},
				new Room
				{
					RoomId = 3,
					RoomNumber = "C-103",
					Status = "VIP Room ",
					WardID = 1
				},
				new Room
				{
					RoomId = 4,
					RoomNumber = "A-104",
					Status = " Standard Room",
					WardID = 2
				},
				new Room
				{
					RoomId = 5,
					RoomNumber = "B-105",
					Status = "General Room  ",
					WardID = 2
				},
				new Room
				{
					RoomId = 6,
					RoomNumber = "C-106",
					Status = " VIP Room",
					WardID = 2
				},

				new Room
				{
					RoomId = 7,
					RoomNumber = "A-107",
					Status = "Standard Room",
					WardID = 3
				},
				new Room
				{
					RoomId = 8,
					RoomNumber = "B-108",
					Status = " General Room ",
					WardID = 3
				},
				new Room
				{
					RoomId = 9,
					RoomNumber = "C-109",
					Status = "VIP Room",
					WardID = 3
				},
				new Room
				{
					RoomId = 10,
					RoomNumber = "A-110",
					Status = " Standard Room",
					WardID = 4
				},
				new Room
				{
					RoomId = 11,
					RoomNumber = "B-111",
					Status = "General Room ",
					WardID = 4
				},
				new Room
				{
					RoomId = 12,
					RoomNumber = "C-112",
					Status = " VIP Room",
					WardID = 4
				},

				new Room
				{
					RoomId = 13,
					RoomNumber = "A-201",
					Status = "Standard Room",
					WardID = 5
				},
				new Room
				{
					RoomId = 14,
					RoomNumber = "B-202",
					Status = " General Room",
					WardID = 5
				},
				new Room
				{
					RoomId = 15,
					RoomNumber = "C-203",
					Status = "VIP Room ",
					WardID = 5
				},
				new Room
				{
					RoomId = 16,
					RoomNumber = "A-204",
					Status = " Standard Room",
					WardID = 6
				},

				new Room
				{
					RoomId = 17,
					RoomNumber = "B-205",
					Status = "General Room",
					WardID = 6
				},
				new Room
				{
					RoomId = 18,
					RoomNumber = "C-206",
					Status = " VIP Room ",
					WardID = 6
				},
				new Room
				{
					RoomId = 19,
					RoomNumber = "A-207",
					Status = "Standard Room",
					WardID = 7
				},
				new Room
				{
					RoomId = 20,
					RoomNumber = "B-208",
					Status = " General Room",
					WardID = 7
				},
				new Room
				{
					RoomId = 21,
					RoomNumber = "A-209",
					Status = "Standard Room",
					WardID = 8
				},
				new Room
				{
					RoomId = 22,
					RoomNumber = "B-210",
					Status = " General Room",
					WardID = 8
				},new Room
				{
					RoomId = 23,
					RoomNumber = "A-211",
					Status = "Standard Room",
					WardID = 9
				},
				new Room
				{
					RoomId = 24,
					RoomNumber = "B-212",
					Status = " General Room",
					WardID = 10
				},

			});



		}

	}

}
