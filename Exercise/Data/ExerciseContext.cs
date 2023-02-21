using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Exercise.Models;

namespace Exercise.Data
{
    public class ExerciseContext : DbContext
    {
        public ExerciseContext (DbContextOptions<ExerciseContext> options)
            : base(options)
        {
        }

        public DbSet<Exercise.Models.Persona> Persona { get; set; }

        public DbSet<Exercise.Models.Clientes> Clientes { get; set; }

        public DbSet<Exercise.Models.Cuenta> Cuenta { get; set; }

        public DbSet<Exercise.Models.Movimientos> Movimientos { get; set; }
        public DbSet<Exercise.Models.Mensajes> Mensajes { get; set; }
    }
}
