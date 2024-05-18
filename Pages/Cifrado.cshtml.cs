using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Practica1.Pages
{
    public class CifradoModel : PageModel
    {
        [BindProperty]
        public string MensajeOriginalCifrar { get; set; } = "";
        [BindProperty]
        public string MensajeOriginalDescifrar { get; set; } = "";
        [BindProperty]
        public int NCifrar { get; set; } = 0;
        [BindProperty]
        public int NDescifrar { get; set; } = 0;
        public string MensajeCifrado { get; set; } = "";
        public string MensajeDescifrado { get; set; } = "";

        char[] charAlfabeto = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        public void OnGet(){
        }
        public void OnPostCifrar(){
            MensajeCifrado = CifrarMensaje(MensajeOriginalCifrar.ToUpper(), NCifrar);
        }
        public void OnPostDescifrar(){
            MensajeDescifrado = DescifrarMensaje(MensajeOriginalDescifrar.ToUpper(), NDescifrar);
        }

        private string CifrarMensaje(string mensaje, int n){
            char[] charMensaje = mensaje.ToCharArray();
            string mensajeCifrado = "";

            foreach (char c in charMensaje){
                if (char.IsLetter(c)){
                    int indice = Array.IndexOf(charAlfabeto, char.ToUpper(c));
                    int nuevoIndice = (indice + n) % charAlfabeto.Length;
                    mensajeCifrado += char.IsUpper(c) ? charAlfabeto[nuevoIndice] : char.ToLower(charAlfabeto[nuevoIndice]);
                }else{
                    mensajeCifrado += c;
                }
            }
            return mensajeCifrado;
        }

        private string DescifrarMensaje(string mensaje, int n){
            char[] charMensaje = mensaje.ToCharArray();
            string mensajeDescifrado = "";

            foreach (char c in charMensaje){
                if (char.IsLetter(c)){
                    int indice = Array.IndexOf(charAlfabeto, char.ToUpper(c));
                    int nuevoIndice = (indice - n + charAlfabeto.Length) % charAlfabeto.Length;
                    mensajeDescifrado += char.IsUpper(c) ? charAlfabeto[nuevoIndice] : char.ToLower(charAlfabeto[nuevoIndice]);
                }else{
                    mensajeDescifrado += c; // Conservar los caracteres que no son letras
                }
            }
            return mensajeDescifrado;
        }
    }
}