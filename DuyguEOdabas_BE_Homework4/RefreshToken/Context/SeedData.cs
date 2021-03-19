using Microsoft.Extensions.DependencyInjection;
using RefreshToken.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RefreshToken.Context
{
    public static class SeedData
    {

        public static async Task InitializeAsync(IServiceProvider service)
        {
            await AddSampleData(service.GetRequiredService<HotelApiDbContext>());
        }

        public static async Task AddSampleData(HotelApiDbContext dbContext)
        {
            if (!dbContext.Rooms.Any())
            {
                dbContext.Rooms.Add(new RoomEntity
                {
                    Id = Guid.Parse("47103bcb-753a-48a3-ac74-2263977c85df"),
                    Name = "Standart Oda",
                    Rate = 34524,
                    IsMigrate = false
                });

                dbContext.Rooms.Add(new RoomEntity
                {
                    Id = Guid.Parse("a88cdd16-f627-4f95-95c3-783b7c0554aa"),
                    Name = "Suid Oda",
                    Rate = 34524,
                    IsMigrate = false
                });
            }

            if (!dbContext.Users.Any())
            {
                dbContext.Users.Add(new UserEntity
                {
                    Id = 1,
                    Name = "Duygu Evrim",
                    SurName = "Odabaş",
                    LoginName = "dddeee00",
                    Password = "dddeee00dddeee00",
                    Phone = "05555555555"
                });
            }

            await dbContext.SaveChangesAsync();

        }

    }
}
