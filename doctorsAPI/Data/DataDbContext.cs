using doctorsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace doctorsAPI.Data
{
    public class DataDbContext: DbContext
    {
        public  DataDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Doctor> Doctors { get; set; }
    }
}
