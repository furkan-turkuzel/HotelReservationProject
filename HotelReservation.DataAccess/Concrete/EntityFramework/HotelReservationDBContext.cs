using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelReservation.Model.Entities;
using HotelReservation.Model.Mapping.EFMapping;

namespace HotelReservation.DataAccess.Concreate.EntityFramework
{
     public class HotelReservationDBContext : DbContext
     {
          public HotelReservationDBContext()
               : base("Server=.;Database=IndiaHotelReservation;Integrated Security=True")
          {
              Database.SetInitializer(new VeriTabaniOluşturucu());
          }

          public DbSet<Users> User { get; set; }
          public DbSet<RoomTypes> RoomType { get; set; }
          public DbSet<Rooms> Room { get; set; }
          public DbSet<RoomImages> RoomImage { get; set; }
          public DbSet<ReservationTypes> ReservationType { get; set; }
          public DbSet<Reservations> Reservation { get; set; }
          public DbSet<ResCusRooms> ResCusRoom { get; set; }
          public DbSet<PriceRatios> PriceRatio { get; set; }
          public DbSet<PaymentTypes> PaymentType { get; set; }
          public DbSet<Payments> Payment { get; set; }
          public DbSet<Passwords> Password { get; set; }
          public DbSet<Customers> Customer { get; set; }

          protected override void OnModelCreating(DbModelBuilder modelBuilder)
          {
               modelBuilder.Configurations.Add(new UsersMap());
               modelBuilder.Configurations.Add(new RoomTypesMap());
               modelBuilder.Configurations.Add(new RoomsMap());
               modelBuilder.Configurations.Add(new RoomImagesMap());
               modelBuilder.Configurations.Add(new ReservationsTypesMap());
               modelBuilder.Configurations.Add(new ReservationsMap());
               modelBuilder.Configurations.Add(new ResCusRoomsMap());
               modelBuilder.Configurations.Add(new PriceRatiosMap());
               modelBuilder.Configurations.Add(new PaymentTypesMap());
               modelBuilder.Configurations.Add(new PaymentsMap());
               modelBuilder.Configurations.Add(new PasswordsMap());
               modelBuilder.Configurations.Add(new CustomersMap());
          }
     }

     public class VeriTabaniOluşturucu : CreateDatabaseIfNotExists<HotelReservationDBContext>
     {
         protected override void Seed(HotelReservationDBContext context)
         {

             RoomTypes roomType = new RoomTypes();

             roomType.RoomTypeID = Guid.NewGuid();
             roomType.RoomTypeName = "Standart";
             roomType.RoomTypePrice = 100;
             roomType.Description = "Standart odadır";
             context.RoomType.Add(roomType);

             RoomTypes roomType1 = new RoomTypes();

             roomType1.RoomTypeID = Guid.NewGuid();
             roomType1.RoomTypeName = "Suit";
             roomType1.RoomTypePrice = 200;
             roomType1.Description = "Suit odadır";
             context.RoomType.Add(roomType1);

             RoomTypes roomType2 = new RoomTypes();

             roomType2.RoomTypeID = Guid.NewGuid();
             roomType2.RoomTypeName = "Lux";
             roomType2.RoomTypePrice = 300;
             roomType2.Description = "Lux odadır";
             context.RoomType.Add(roomType2);


             ReservationTypes resType = new ReservationTypes();

             resType.ReservationTypeID = Guid.NewGuid();
             resType.ReservationTypeName = "Standart";
             resType.ServicePrice = 0;
             resType.Description = "Oda ve kahvaltı dahildir.";
             context.ReservationType.Add(resType);

             ReservationTypes resType1 = new ReservationTypes();

             resType1.ReservationTypeID = Guid.NewGuid();
             resType1.ReservationTypeName = "Full";
             resType1.ServicePrice = 100;
             resType1.Description = "Oda ve yemekler dahildir.";
             context.ReservationType.Add(resType1);

             ReservationTypes resType2 = new ReservationTypes();

             resType2.ReservationTypeID = Guid.NewGuid();
             resType2.ReservationTypeName = "Full+Full";
             resType2.ServicePrice = 200;
             resType2.Description = "Oda ve yemekler ve içkiler dahildir.";
             context.ReservationType.Add(resType2);

             for (int i = 0; i < 10; i++)
             {
                 Rooms room = new Rooms();

                 room.RoomTypeID = roomType.RoomTypeID;
                 room.IsActive = true;
                 context.Room.Add(room);
             }

             for (int i = 0; i < 6; i++)
             {
                 Rooms room1 = new Rooms();

                 room1.RoomTypeID = roomType1.RoomTypeID;
                 room1.IsActive = true;
                 context.Room.Add(room1);
             }

             for (int i = 0; i < 4; i++)
             {
                 Rooms room2 = new Rooms();

                 room2.RoomTypeID = roomType2.RoomTypeID;
                 room2.IsActive = true;
                 context.Room.Add(room2);
             }



             context.SaveChanges();

         }
     }
}
