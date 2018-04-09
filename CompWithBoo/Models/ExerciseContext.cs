using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CompWithBoo.Models
{
    public partial class ExerciseContext : DbContext
    {
        public ExerciseContext() : base("name = MyConnection")
        {

        }

        public virtual DbSet<Exercise> Exercises { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}