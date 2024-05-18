using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace Practica1.Pages
{
    public class IgualdadModel : PageModel
    {
        [BindProperty]
        public string a { get; set; } = "";
        [BindProperty]
        public string b { get; set; } = "";
        [BindProperty]
        public string x { get; set; } = "";
        [BindProperty]
        public string y { get; set; } = "";
        [BindProperty]
        public string n { get; set; } = "";
        public double multAX = 0;
        public double multBY = 0;
        public double suma = 0;
        public double elevadoN = 0;
        public string mensaje = "";
        public List<double> resultadosSumatoria = new List<double>();

        public void OnPost(){
            if (string.IsNullOrWhiteSpace(a) || string.IsNullOrWhiteSpace(b) || string.IsNullOrWhiteSpace(x) || string.IsNullOrWhiteSpace(y) || string.IsNullOrWhiteSpace(n)){
                mensaje = "Introduzca números";
                return;
            }

            double aD = double.Parse(a);
            double bD = double.Parse(b);
            double xD = double.Parse(x);
            double yD = double.Parse(y);
            double nD = double.Parse(n);
            multAX = aD * xD;
            multBY = bD * yD;
            suma = multAX + multBY;

            elevadoN = 1.0;
            for (int i = 0; i < nD; i++){
                elevadoN *= suma;
            }

            resultadosSumatoria.Clear();

            // Calcular la fórmula sumatoria
            for (int k = 0; k <= nD; k++){
                // Calcular el coeficiente binomial: n! / (k!(n-k)!)
                double coeficienteBinomial = 1;
                for (int i = 1; i <= nD; i++){
                    coeficienteBinomial *= i;
                }
                for (int i = 1; i <= k; i++){
                    coeficienteBinomial /= i;
                }
                for (int i = 1; i <= nD - k; i++){
                    coeficienteBinomial /= i;
                }

                // Calcular el término de la sumatoria
                double termino = coeficienteBinomial;
                for (int i = 0; i < nD - k; i++){
                    termino *= aD * xD;
                }
                for (int i = 0; i < k; i++){
                    termino *= bD * yD;
                }
                resultadosSumatoria.Add(termino);
            }

            ModelState.Clear();
        }      
    }
}
