using BusTicket.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Data.Concreate.EfCore
{
    public class Context_BusTicket : DbContext
    {
        public Context_BusTicket(DbContextOptions<Context_BusTicket> options) : base(options)
        {

        }

        public DbSet<Trip> Trips { get; set; } = null!;
        public DbSet<TripDetail> TripDetails { get; set; } = null!;
        public DbSet<Ticket> Tickets { get; set; } = null!;
        public DbSet<MidLine> MidLines { get; set; } = null!;
        public DbSet<Payment> Payments { get; set; } = null!;
        public DbSet<Line> Lines { get; set; } = null!;
        public DbSet<Driver> Drivers { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Company> Companies { get; set; } = null!;
        public DbSet<Bus> Buses { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Bus>().HasData(
                new Bus() { Id = 1, Capacity = 10, HasWifi = true },

                 new Bus() { Id = 2, Capacity = 15, HasUSB = true },

                 new Bus() { Id = 3, Capacity = 20, HasWifi = true, HasSeatScreen = true, HasUSB = true }
            );

            modelBuilder.Entity<Company>().HasData(
                new Company() { Id = 1, Name = "Metro Turizm" },
                new Company() { Id = 2, Name = "Kamil Koç" },
                new Company() { Id = 3, Name = "Lüks Artvin" }
                );

            modelBuilder.Entity<Customer>().HasData(
                new Customer() { Id = 1, FName = "Mert", LName = "Simsek", Gender = "Male", Age = "26", Contact = "05556667770", Email = "mertsimsek@gmail.com" },

                  new Customer() { Id = 2, FName = "Cansu Nur", LName = "Ürek", Gender = "Female", Age = "27", Contact = "05556667771", Email = "cansunur@gmail.com" },

                   new Customer() { Id = 3, FName = "Ali", LName = "Cesur", Gender = "Male", Age = "35", Contact = "05556667772", Email = "ali@gmail.com" },

                     new Customer() { Id = 4, FName = "Ayşe", LName = "Yavaş", Gender = "Female", Age = "40", Contact = "05556667773", Email = "ayse@gmail.com" }
                );

            modelBuilder.Entity<Driver>().HasData(
                new Driver() { Id = 1, Name = "Niyazi Hızlı", Contact = "+905556668880" },
                new Driver() { Id = 2, Name = "Murat Seyrek", Contact = "+905556668881" },
                new Driver() { Id = 3, Name = "Berk Entel", Contact = "+905556668882" }
                );


            modelBuilder.Entity<Line>().HasData(
               new Line() { Id = 1, StartingPoint = "İstanbul", Destination = "Adana" },
               new Line() { Id = 2, StartingPoint = "Rize", Destination = "Hatay" },
               new Line() { Id = 3, StartingPoint = "Sinop", Destination = "Antalya" }
               );

            modelBuilder.Entity<MidLine>().HasData(
               new MidLine() { Id = 1, LineId = 1, MidLineOrder = 1, StartingPoint = "İstanbul", Destination = "Gebze" },
               new MidLine() { Id = 2, LineId = 1, MidLineOrder = 2, StartingPoint = "Gebze", Destination = "Sakarya" },
                   new MidLine() { Id = 3, LineId = 1, MidLineOrder = 3, StartingPoint = "Sakarya", Destination = "Ankara" },
               new MidLine() { Id = 4, LineId = 1, MidLineOrder = 4, StartingPoint = "Ankara", Destination = "Adana" },


                new MidLine() { Id = 5, LineId = 2, MidLineOrder = 1, StartingPoint = "Rize", Destination = "Trabzon" },
               new MidLine() { Id = 6, LineId = 2, MidLineOrder = 2, StartingPoint = "Trabzon", Destination = "Erzincan" },
                   new MidLine() { Id = 7, LineId = 2, MidLineOrder = 3, StartingPoint = "Erzincan", Destination = "Sivas" },
               new MidLine() { Id = 8, LineId = 2, MidLineOrder = 4, StartingPoint = "Sivas", Destination = "Gaziantep" },
                  new MidLine() { Id = 9, LineId = 2, MidLineOrder = 5, StartingPoint = "Gaziantep", Destination = "Hatay" },

                      new MidLine() { Id = 10, LineId = 3, MidLineOrder = 1, StartingPoint = "Sinop", Destination = "Kastamonu" },
               new MidLine() { Id = 11, LineId = 3, MidLineOrder = 2, StartingPoint = "Kastamonu", Destination = "Karabük" },
                   new MidLine() { Id = 12, LineId = 3, MidLineOrder = 3, StartingPoint = "Karabük", Destination = "Afyon" },
               new MidLine() { Id = 13, LineId = 3, MidLineOrder = 4, StartingPoint = "Afyon", Destination = "Burdur" },
                  new MidLine() { Id = 14, LineId = 3, MidLineOrder = 5, StartingPoint = "Burdur", Destination = "Antalya" }
               );

            modelBuilder.Entity<Trip>().HasData(
                new Trip() { Id = 1, MidLineId = 1, TripDetailId = 1, FareAmount = 50, ScheduleDate = "01.11.2022", DepartureTime = "11:30", ArrivalTime = "14:00" },
                new Trip() { Id = 2, MidLineId = 2, TripDetailId = 1, ScheduleDate = "01.11.2022", DepartureTime = "14:00", ArrivalTime = "15:20" },
                new Trip() { Id = 3, MidLineId = 3, TripDetailId = 1, FareAmount = 120, ScheduleDate = "01.11.2022", DepartureTime = "15:20", ArrivalTime = "21:30" },
                new Trip() { Id = 4, MidLineId = 4, TripDetailId = 1, FareAmount = 150, ScheduleDate = "01.11.2022", DepartureTime = "15:20", ArrivalTime = "21:30" },

                 new Trip()
                 {
                     Id = 5,
                     MidLineId = 5,
                     TripDetailId = 1,
                     FareAmount = 70,
                     ScheduleDate = "01.11.2022",
                     DepartureTime = "15:20",
                     ArrivalTime = "21:30"
                 },
                new Trip() { Id = 6, MidLineId = 6, TripDetailId = 2, FareAmount = 150, ScheduleDate = "01.11.2022", DepartureTime = "15:20", ArrivalTime = "21:30" },
                new Trip() { Id = 7, MidLineId = 7, TripDetailId = 2, FareAmount = 110, ScheduleDate = "01.11.2022", DepartureTime = "15:20", ArrivalTime = "21:30" },
                new Trip() { Id = 8, MidLineId = 8, TripDetailId = 2, FareAmount = 60, ScheduleDate = "01.11.2022", DepartureTime = "15:20", ArrivalTime = "21:30" },
                new Trip() { Id = 9, MidLineId = 9, TripDetailId = 2, FareAmount = 90, ScheduleDate = "01.11.2022", DepartureTime = "15:20", ArrivalTime = "21:30" },

                  new Trip() { Id = 10, MidLineId = 10, TripDetailId = 3, FareAmount = 40, ScheduleDate = "01.11.2022", DepartureTime = "15:20", ArrivalTime = "21:30" },
                new Trip() { Id = 11, MidLineId = 11, TripDetailId = 3, FareAmount = 75, ScheduleDate = "01.11.2022", DepartureTime = "15:20", ArrivalTime = "21:30" },
                new Trip() { Id = 12, MidLineId = 12, TripDetailId = 3, FareAmount = 115, ScheduleDate = "01.11.2022", DepartureTime = "15:20", ArrivalTime = "21:30" },
                new Trip() { Id = 13, MidLineId = 13, TripDetailId = 3, FareAmount = 120, ScheduleDate = "01.11.2022", DepartureTime = "15:20", ArrivalTime = "21:30" },
                new Trip() { Id = 14, MidLineId = 14, TripDetailId = 3, FareAmount = 60, ScheduleDate = "01.11.2022", DepartureTime = "15:20", ArrivalTime = "21:30" }
                );

            modelBuilder.Entity<TripDetail>().HasData(
              new TripDetail() { Id = 1, BusId = 1, DriverId = 1 },
              new TripDetail() { Id = 2, BusId = 1, DriverId = 1 },
              new TripDetail() { Id = 3, BusId = 1, DriverId = 1 }
              );
        }
    }
}
