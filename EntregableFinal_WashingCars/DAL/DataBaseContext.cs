using EntregableFinal_WashingCars.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Reflection.Emit;

namespace EntregableFinal_WashingCars.DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        public DbSet<Services> Services { get; set; }

        public DbSet<Vehicles> Vehicles { get; set; }

        public DbSet<VehicleDetails> VehicleDetails { get; set; }

    }

}

