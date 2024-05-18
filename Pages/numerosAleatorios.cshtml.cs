using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Practica1.Pages
{
    public class numerosAleatoriosModel : PageModel
    {
        public int[] numerosAleatorios;
        public int[] numerosAleatoriosOriginal;
        public int suma;
        public double promedio;
        public string moda;
        public double mediana;

        public void OnGet()
        {
            // Generar arreglo con 20 números enteros aleatorios entre 0 y 100
            Random rnd = new Random();
            numerosAleatorios = new int[20];
            numerosAleatoriosOriginal = new int[20];
            for (int i = 0; i < numerosAleatorios.Length; i++){
                int num = rnd.Next(0, 101);
                numerosAleatorios[i] = num;
                numerosAleatoriosOriginal[i] = num;
            }

            // Calcular suma de los números del arreglo
            suma = numerosAleatorios.Sum();

            // Calcular promedio
            promedio = (double)suma / numerosAleatorios.Length;

            // Calcular moda
            int[] frecuencia = new int[101];
            foreach (int numero in numerosAleatorios){
                frecuencia[numero]++;
            }
            int maxFrecuencia = frecuencia.Max();
            if (maxFrecuencia == 1){
                moda = "No existe la moda porque no se repite ningún número";
            }else{
                var modaList = new List<int>();
                for (int i = 0; i < frecuencia.Length; i++){
                    if (frecuencia[i] == maxFrecuencia){
                        modaList.Add(i);
                    }
                }
                moda = string.Join(", ", modaList);
            }

            // Calcular mediana
            Array.Sort(numerosAleatorios);
            if (numerosAleatorios.Length % 2 == 0){
                mediana = (numerosAleatorios[numerosAleatorios.Length / 2 - 1] + numerosAleatorios[numerosAleatorios.Length / 2]) / 2.0;
            }else{
                mediana = numerosAleatorios[numerosAleatorios.Length / 2];
            }
        }
    }
}