using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompWithBoo.Repositories
{
    public interface IExerciseRepository <TEnt, in TPk> where TEnt : class
    {

        IQueryable<TEnt> Get();
        void Add(TEnt entity);
        void Remove(TEnt entity);
    }
}
