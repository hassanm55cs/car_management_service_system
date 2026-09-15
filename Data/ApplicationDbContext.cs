using Car_services.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System;

namespace Car_services.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=Car_Services;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //customer
            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.Email)
                .IsUnique();
            modelBuilder.Entity<Customer>()
                .HasIndex(c => c.Phone)
                .IsUnique();
            modelBuilder.Entity<Customer>()
                .Property(c=>c.Email)
                .HasMaxLength(80);
            modelBuilder.Entity<Customer>()
                .Property(c => c.Phone)
                .HasMaxLength(20);
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Cars)
                .WithOne(c => c.customer)
                .HasForeignKey(cr => cr.Customer_Id)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Customer>()
                .Property(c => c.Full_name)
                .HasMaxLength(30);
            modelBuilder.Entity<Customer>()
                .Property(c => c.Address)
                .HasMaxLength(50);


            //Employee
            modelBuilder.Entity<Employee>()
                .HasOne(e=>e.Branch)
                .WithMany(b => b.Employees)
                .HasForeignKey(e => e.BranchId)
                .OnDelete(DeleteBehavior.Restrict) ;
            modelBuilder.Entity<service_branches>()
                .HasOne(b=>b.Manager)
                .WithOne(e=>e.Manager_Branch)
                .HasForeignKey<service_branches>(v=>v.ManagerId)
                .OnDelete(DeleteBehavior.Restrict) ;
            modelBuilder.Entity<Employee>()
                .Property(e => e.Full_name)
                .HasMaxLength(30);
            modelBuilder.Entity<Employee>()
                .Property(e => e.Years_of_experince)
                .HasMaxLength(2);
            modelBuilder.Entity<Employee>()
                .Property(e => e.Years_of_experince)
                .HasMaxLength(2);
            modelBuilder.Entity<Employee>()
                .Property(e => e.Facultly)
                .HasMaxLength(70);
            modelBuilder.Entity<Employee>()
                .HasIndex(c => c.Email)
                .IsUnique();
            modelBuilder.Entity<Employee>()
                .HasIndex(c => c.Phone_number)
                .IsUnique();
            modelBuilder.Entity<Employee>()
                .Property(c => c.Email)
                .HasMaxLength(80);
            modelBuilder.Entity<Employee>()
                .Property(c => c.Phone_number)
                .HasMaxLength(20);

            //car
            modelBuilder.Entity<Car>()
                .HasKey(c => c.Licences_Plate);
            modelBuilder.Entity<Car>()
                .Ignore(c => c.set_Fuel);
            modelBuilder.Entity<Car>()
                .Ignore(c => c.set_Engine_Type);
            modelBuilder.Entity<Car>()
                .Property(c => c.Licences_Plate)
                .HasMaxLength(6);
            modelBuilder.Entity<Car>()
                .Property(c => c.Engine_type)
                .HasConversion<string>();
            modelBuilder.Entity<Car>()
                .Property(c => c.Fuel_Type)
                .HasConversion<string>();
            modelBuilder.Entity<Car>()
                .Property(c => c.Fuel_Type)
                .HasMaxLength(15);
            modelBuilder.Entity<Car>()
                .Property(c => c.Engine_type)
                .HasMaxLength(50);
            modelBuilder.Entity<Car>()
                .Property(c => c.No_of_cylinders)
                .HasMaxLength(2);
            modelBuilder.Entity<Car>()
                .Property(c => c.Car_Company)
                .HasMaxLength(35);
            modelBuilder.Entity<Car>()
                .Property(c => c.Model)
                .HasMaxLength(20);
            modelBuilder.Entity<Car>()
                .Property(c => c.Color)
                .HasMaxLength(20);
            //service
            modelBuilder.Entity<service>()
                .HasOne(c=>c.LicensePlate)
                .WithMany(c=>c.Services)
                .HasForeignKey(s => s.CarId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<service>()
                .HasOne(e => e.Employeoe)
                .WithMany(e => e.Services)
                .HasForeignKey(s => s.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<service>()
                .HasOne(c => c.Branch_of_service)
                .WithMany(c => c.Services)
                .HasForeignKey(s => s.BranchId)
                .OnDelete(DeleteBehavior.Restrict);

            //Branch
           modelBuilder.Entity<service_branches>()
                .HasKey(b => b.BranchId);


            //Emergency truck
            modelBuilder.Entity<EmergencyTruck>()
                .HasKey(t => t.Licence_Plate);
            modelBuilder.Entity<EmergencyTruck>()
                .HasOne(e => e.Driver)
                .WithMany(D => D.TrucksDriven)
                .HasForeignKey(DriverId => DriverId.DriverId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<EmergencyTruck>()
                .HasOne(EmergencyTruck => EmergencyTruck.Branch)
                .WithMany(EmergencyTruck => EmergencyTruck.Trucks)
                .OnDelete(DeleteBehavior.Restrict);


            //Driver
            modelBuilder.Entity<Driver>()
            .HasKey(d => d.DriverId);
            modelBuilder.Entity<Driver>().Property(c => c.FullName)
           .HasMaxLength(35);
            modelBuilder.Entity<Driver>()
                .HasOne(d => d.WorkingBranch)
                .WithMany(d => d.Drivers)
                .HasForeignKey(B => B.BranchId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Driver>()
                .Property(d => d.FullName)
                .HasMaxLength(30);
            modelBuilder.Entity<Driver>()
                .HasIndex(c => c.PhoneNumber)
                .IsUnique();
            modelBuilder.Entity<Driver>()
                .Property(d=>d.PhoneNumber)
                .HasMaxLength(20);
            modelBuilder.Entity<Driver>()
               .HasIndex(c => c.Email)
               .IsUnique();
            modelBuilder.Entity<Driver>()
               .Property(d => d.Email)
               .HasMaxLength(80);


            //Emergency request
            modelBuilder.Entity<EmergencyRequest>()
            .HasKey(e => e.EmergencyRequestId);
           modelBuilder.Entity<EmergencyRequest>()
                .HasOne(e => e.Driver)
                .WithMany(d => d.EmergencyRequests)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.Restrict) ;
            modelBuilder.Entity<EmergencyRequest>()
                .HasOne(e => e.CarRequest)
                .WithMany(d => d.Requests)
                .HasForeignKey(d => d.Car_LicencePlate);
            //RentedCarCustomer
            modelBuilder.Entity<RentedCarCustomer>()
                .HasKey(r => r.RentedCarCustomerId);
            modelBuilder.Entity<RentedCarCustomer>()
                .HasOne(r => r.CutomeRent)
                .WithMany(c => c.CarsCustomers)
                .HasForeignKey(c => c.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<RentedCarCustomer>()
                .HasOne(r => r.CarRented)
                .WithMany(c => c.CarsCutomers)
                .HasForeignKey(c => c.LicencsePlateRented)
                .OnDelete(DeleteBehavior.Restrict);


            //carsforrent
            modelBuilder.Entity<CarsForRent>()
                .HasKey(c => c.LicencePlate);
            modelBuilder.Entity<CarsForRent>().Property(c => c.LicencePlate)
                .HasMaxLength(6);
            modelBuilder.Entity<CarsForRent>().Property(c => c.Model)
               .HasMaxLength(30);
            modelBuilder.Entity<CarsForRent>().Property(c => c.Engine_type)
               .HasConversion<string>();
            modelBuilder.Entity<CarsForRent>().Property(c => c.Fuel_Type)
               .HasConversion<string>();
            modelBuilder.Entity<CarsForRent>().Property(c => c.Fuel_Type)
               .HasMaxLength(15);
            modelBuilder.Entity<CarsForRent>().Property(c => c.Engine_type)
               .HasMaxLength(50);
            modelBuilder.Entity<CarsForRent>().Property(c => c.No_of_cylinders)
               .HasMaxLength(2);
            modelBuilder.Entity<CarsForRent>().Property(c => c.Car_Company)
               .HasMaxLength(35);
            modelBuilder.Entity<CarsForRent>().Property(c => c.Model)
               .HasMaxLength(20);
            modelBuilder.Entity<CarsForRent>()
                .Ignore(c => c.set_Fuel);
            modelBuilder.Entity<CarsForRent>()
                .Ignore(c => c.set_Engine_Type);
            modelBuilder.Entity<CarsForRent>()
                .Property(c => c.Color)
                .HasMaxLength(20);

            //ServiceByKm
            modelBuilder.Entity<ServiceByKm>()
                .HasKey(s => s.ServiceByKmId);


        }
        public DbSet<Car> Car { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<service> service { get; set; }
        public DbSet<RentedCarCustomer> RentedCarCustomers { get; set; }
        public DbSet<Driver> Drivers{ get; set; }
        public DbSet<CarsForRent> CarsForRents { get; set; }
        public DbSet<EmergencyRequest> EmergencyRequests { get; set; }
        public DbSet<EmergencyTruck> EmergencyTrucks { get; set; }
        public DbSet<service_branches> service_branches { get; set; }
        public DbSet<Employee> Employee { get; set; }





    }
}
