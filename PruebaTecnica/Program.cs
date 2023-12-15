namespace PruebaTecnica
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            //Solicitar al usuario que ingrese una cadena
            Console.WriteLine("Ingrese una cadena de texto:");
            string? cadena = Console.ReadLine();

            //Obtengo el número de pares de letras y el orden descendente
            var (numerosPares, letrasOrdenadas) = ObtenerParesOrdenar(cadena ?? string.Empty);

            //Mostrar resultados al usuario
            Console.WriteLine($"Pares encontrados: {numerosPares}");
            Console.WriteLine($"Orden de los elementos encontrados: {string.Join(", ", letrasOrdenadas)}" );
        }

        //Método para obtener el número de pares y el orden descendente de los elementos
        private static (int numerosPares, List<char> letrasOrdenadas) ObtenerParesOrdenar(string cadena)
        {

            //Contador de pares
            int paresCount = 0;

            //Almacenar la lista de letras encontradas
            List<char> letrasEncontradas = new();

            //Recorro la cadena de entrada
            foreach (var letraActual in cadena)
            {
                //Válido si ya se encuentra en mi lista de letras encontradas
                //El indexOf retorna el 'indice' donde lo encuentra o '-1' si no existe.
                //Descarto los espacios (' '= 32) como un elemento 
                if (letrasEncontradas.IndexOf(letraActual) == -1 && letraActual != 32)
                {
                    //Contador de coincidencias encontradas
                    int coincidencias = 0;

                    foreach (var item in cadena)
                    {
                        //Si coincide con la letra actual
                        if (item == letraActual)
                        {
                            //Registro la coincidencia
                            coincidencias++;
                        }
                    }

                    //Registro la letra recorrida
                    letrasEncontradas.Add(letraActual);

                    //Obtengo el número de pares encontrados dependiendo si las coincidencias son un número par o impar
                    int pares = coincidencias % 2 == 0 ? coincidencias / 2 : (coincidencias - 1) / 2;

                    //Lo agrego al contador de pares
                    paresCount += pares;
                }
            }

            //Ordeno con Linq la lista de manera descendente
            var ordenDescendente = letrasEncontradas.OrderByDescending(x => x).ToList(); 

            //Devuelvo en tupla los resultados
            return (paresCount, ordenDescendente);

        }


    }
}