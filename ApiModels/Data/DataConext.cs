using Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models
{
    public class DataConext : DbContext
    {
        public DataConext(DbContextOptions<DataConext> options):base(options){}

        public DbSet<SalonModelDemo> Salones { get; set; }
        public DbSet<MesaModelDemo> Mesa { get; set; }
    }
}
