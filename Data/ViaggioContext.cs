
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using WebApp_TravelAgency.Models;

namespace WebApp_TravelAgency.Data
{
    public class ViaggioContext : DbContext
    {
        public DbSet<Viaggio> Viaggi { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Database=Database_Viaggio;Integrated Security=True");
        }
    }
}
