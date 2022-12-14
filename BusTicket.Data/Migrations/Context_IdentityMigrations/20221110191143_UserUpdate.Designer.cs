// <auto-generated />
using System;
using BusTicket.Data.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BusTicket.Data.Migrations.Context_IdentityMigrations
{
    [DbContext(typeof(Context_Identity))]
    [Migration("20221110191143_UserUpdate")]
    partial class UserUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.11");

            modelBuilder.Entity("BusTicket.Data.Identity.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("BusTicket.Entity.Bus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Capacity")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("HasSeatScreen")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("HasUSB")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("HasWifi")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Bus");
                });

            modelBuilder.Entity("BusTicket.Entity.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("BusTicket.Entity.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Age")
                        .HasColumnType("TEXT");

                    b.Property<string>("Contact")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("FName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .HasColumnType("TEXT");

                    b.Property<string>("LName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("BusTicket.Entity.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Contact")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Driver");
                });

            modelBuilder.Entity("BusTicket.Entity.Line", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Destination")
                        .HasColumnType("TEXT");

                    b.Property<string>("StartingPoint")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Line");
                });

            modelBuilder.Entity("BusTicket.Entity.MidLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Destination")
                        .HasColumnType("TEXT");

                    b.Property<int>("LineId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MidLineOrder")
                        .HasColumnType("INTEGER");

                    b.Property<string>("StartingPoint")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LineId");

                    b.ToTable("MidLine");
                });

            modelBuilder.Entity("BusTicket.Entity.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsBooked")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PnrNo")
                        .HasColumnType("TEXT");

                    b.Property<int>("SeatNo")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TripId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("TripId");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("BusTicket.Entity.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ArrivalTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("DepartureTime")
                        .HasColumnType("TEXT");

                    b.Property<decimal?>("FareAmount")
                        .HasColumnType("TEXT");

                    b.Property<int>("MidLineId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Remarks")
                        .HasColumnType("TEXT");

                    b.Property<string>("ScheduleDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("TripDetailId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MidLineId");

                    b.HasIndex("TripDetailId");

                    b.ToTable("Trip");
                });

            modelBuilder.Entity("BusTicket.Entity.TripDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BusId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DriverId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BusId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("DriverId");

                    b.ToTable("TripDetail");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("BusTicket.Data.Identity.User", b =>
                {
                    b.HasOne("BusTicket.Entity.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("BusTicket.Entity.MidLine", b =>
                {
                    b.HasOne("BusTicket.Entity.Line", "Line")
                        .WithMany("MidLines")
                        .HasForeignKey("LineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Line");
                });

            modelBuilder.Entity("BusTicket.Entity.Ticket", b =>
                {
                    b.HasOne("BusTicket.Entity.Customer", "Customer")
                        .WithMany("Tickets")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusTicket.Entity.Trip", "Trip")
                        .WithMany("Tickets")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("BusTicket.Entity.Trip", b =>
                {
                    b.HasOne("BusTicket.Entity.MidLine", "MidLine")
                        .WithMany("Trips")
                        .HasForeignKey("MidLineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusTicket.Entity.TripDetail", "TripDetail")
                        .WithMany("Trips")
                        .HasForeignKey("TripDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MidLine");

                    b.Navigation("TripDetail");
                });

            modelBuilder.Entity("BusTicket.Entity.TripDetail", b =>
                {
                    b.HasOne("BusTicket.Entity.Bus", "Bus")
                        .WithMany("TripDetails")
                        .HasForeignKey("BusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusTicket.Entity.Company", "Company")
                        .WithMany("TripDetails")
                        .HasForeignKey("CompanyId");

                    b.HasOne("BusTicket.Entity.Driver", "Driver")
                        .WithMany("TripDetails")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bus");

                    b.Navigation("Company");

                    b.Navigation("Driver");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BusTicket.Data.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BusTicket.Data.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusTicket.Data.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BusTicket.Data.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BusTicket.Entity.Bus", b =>
                {
                    b.Navigation("TripDetails");
                });

            modelBuilder.Entity("BusTicket.Entity.Company", b =>
                {
                    b.Navigation("TripDetails");
                });

            modelBuilder.Entity("BusTicket.Entity.Customer", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("BusTicket.Entity.Driver", b =>
                {
                    b.Navigation("TripDetails");
                });

            modelBuilder.Entity("BusTicket.Entity.Line", b =>
                {
                    b.Navigation("MidLines");
                });

            modelBuilder.Entity("BusTicket.Entity.MidLine", b =>
                {
                    b.Navigation("Trips");
                });

            modelBuilder.Entity("BusTicket.Entity.Trip", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("BusTicket.Entity.TripDetail", b =>
                {
                    b.Navigation("Trips");
                });
#pragma warning restore 612, 618
        }
    }
}
