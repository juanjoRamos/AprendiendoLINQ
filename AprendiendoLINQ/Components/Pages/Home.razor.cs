using AprendiendoLINQ.Dto;
using AprendiendoLINQ.Models;
using Microsoft.EntityFrameworkCore;

namespace AprendiendoLINQ.Components.Pages
{
    public partial class Home
    {
        private Dictionary<string, string> ExercisesList = new Dictionary<string, string>();

        protected override void OnInitialized()
        {
            ExercisesList.Add("Ejercicio 1", "/exercise1");
            ExercisesList.Add("Ejercicio 2", "/exercise2");
            base.OnInitialized();
        }
    }
}
