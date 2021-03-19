using Microsoft.EntityFrameworkCore;
using RefreshToken.Entities;
using RefreshToken.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RefreshToken.Context
{
    public class HotelApiDbContext : DbContext
    {
        public HotelApiDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<RoomEntity> Rooms { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }

        internal Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
