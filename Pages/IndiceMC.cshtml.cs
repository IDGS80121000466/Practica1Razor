using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Practica1.Pages
{
    public class IndiceMCModel : PageModel
    {
        [BindProperty]
        public string peso { get; set; } = "";
        [BindProperty]
        public string altura { get; set; } = "";
        public double division = 0;
        public double alturaCuadrada;

        public void OnPost()
        {
            double pesoD = double.Parse(peso);
            double alturaD = double.Parse(altura);
            alturaD = alturaD / 100;
            alturaCuadrada = alturaD * alturaD;
            division = pesoD / alturaCuadrada;
            division = Math.Round(division, 2);
            ModelState.Clear();
        }
    }
}

