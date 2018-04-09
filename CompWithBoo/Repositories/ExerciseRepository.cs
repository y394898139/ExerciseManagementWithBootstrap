using CompWithBoo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity.Attributes;

namespace CompWithBoo.Repositories
{
    public class ExerciseRepository : IExerciseRepository<Exercise, string>
    {
        [Dependency]
        public ExerciseContext context { get; set; }

        public ExerciseRepository(ExerciseContext context)
        {
            this.context = context;
        }

        public void Add(Exercise entity)
        {
                context.Exercises.Add(entity);
                context.SaveChanges();
  
        }

        public IQueryable<Exercise> Get()
        {
            return context.Exercises.OrderByDescending(e=>e.ExerciseDate).AsQueryable();
        }




        public void Remove(Exercise entity)
        {
            var obj = context.Exercises.Find(entity.Id);
            context.Exercises.Remove(obj);
            context.SaveChanges();
        }
    }
}