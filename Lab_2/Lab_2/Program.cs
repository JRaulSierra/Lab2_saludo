using System;

namespace Lab_2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido al programa");

            string nombreCompleto = GetNombre();
            string sexo = GetSexo();
            string nombreCurso = GetCurso();
            int año = GetAño();
            ShowWelcomeMessage(nombreCompleto, sexo, nombreCurso, año);

        }

        static string GetNombre()
        {
            string nombreCompleto;
            bool esValido;

            do
            {
                Console.Write("Ingresa tu nombre y apellido: ");
                nombreCompleto = Console.ReadLine();

                // Verificar si solo contieneletras
                esValido = EsValido(nombreCompleto, "^[a-zA-Z ]+$");

                if (!esValido)
                {
                    Console.WriteLine("El nombre y apellido deben contener únicamente letras. Por favor, inténtalo nuevamente.");
                }

            } while (!esValido);

            return nombreCompleto;
        }

        static string GetSexo()
        {
            string sexo;
            bool esValido;

            do
            {
                Console.Write("Ingresa tu sexo (Hombre o Mujer): ");
                sexo = Console.ReadLine();

                // Verificar si cumple con el regex 
                esValido = EsValido(sexo, "^(Hombre|hombre|H|Mujer|mujer|M)$");

                if (!esValido)
                {
                    Console.WriteLine("Sexo inválido. Por favor, ingresa Hombre o Mujer. ( M o H)");
                }

            } while (!esValido);

            return sexo;
        }

        static string GetCurso()
        {
            string nombreCurso;
            bool esValido;

            do
            {
                Console.Write("Ingresa el nombre del curso: ");
                nombreCurso = Console.ReadLine();

                // Verificar si cumple con el formato requerido
                esValido = EsValido(nombreCurso, regex: "^[a-zA-Z]+\\d*$");

                if (!esValido)
                {
                    Console.WriteLine("El nombre del curso debe contener texto y opcionalmente un número al final. Por favor, inténtalo nuevamente.");
                }

            } while (!esValido);

            return nombreCurso;
        }

        static int GetAño()
        {
            int año;
            bool esValido;

            do
            {
                Console.Write("Ingresa el año concurrente (desde el año 2000 en adelante): ");
                string input = Console.ReadLine();

                // Verificar si es un número válido y cumple con el rango requerido
                esValido = int.TryParse(input, out año) && año >= 2000;

                if (!esValido)
                {
                    Console.WriteLine("Año inválido. Por favor, ingresa un año desde el 2000 en adelante.");
                }

            } while (!esValido);

            return año;
        }

        static void ShowWelcomeMessage(string nombreCompleto, string sexo, string nombreCurso, int año)
        {
            string saludo;

            if (sexo.Equals("Hombre", StringComparison.OrdinalIgnoreCase) || sexo.Equals("H", StringComparison.OrdinalIgnoreCase))
            {
                saludo = "Sr.";
            }
            else
            {
                saludo = "Sra.";
            }

            string apellido = GetApellido(nombreCompleto);
            Console.WriteLine($"Bienvenido {nombreCompleto} al segundo laboratorio del curso {nombreCurso} del año {año}, de aquí en adelante te diremos {saludo} {apellido}.");
        }

        static string GetApellido(string nombreCompleto)
        {
            // Obtener el apellido a partir del nombre completo ingresado
            string[] nombres = nombreCompleto.Split(' ');

            if (nombres.Length > 1)
            {
                return nombres[nombres.Length - 1];
            }

            return string.Empty;
        }


        private static bool EsValido(string texto, string regex = null)
        {
            if (!string.IsNullOrEmpty(texto))
            {
                if (!string.IsNullOrEmpty(regex))
                {
                    return System.Text.RegularExpressions.Regex.IsMatch(texto, regex);
                }

                return true;
            }

            return false;
        }
    }

}
