using CompWithBoo.Models;
using CompWithBoo.Repositories;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace CompWithBoo
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            //Register the Repository in the Unity Container
            container.RegisterType<IExerciseRepository<Exercise, string>, ExerciseRepository>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}