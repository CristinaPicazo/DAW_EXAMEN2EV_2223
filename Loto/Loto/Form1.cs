using System;

namespace LotoClassNS
{
    // Clase que almacena una combinación de la lotería
    //
    public class loto
    {
        // definición de constantes
        /// <summary>
        /// Máximo de números a introducir
        /// </summary>
        public const int MAX_NUMEROS = 6;
        /// <summary>
        /// Número menor que puede salir
        /// </summary>
        public const int NUMERO_MENOR = 1;
        /// <summary>
        /// Número mayor que puede salir
        /// </summary>
        public const int NUMERO_MAYOR = 49;

        private int[] _listaNumeros = new int[MAX_NUMEROS];   // numeros de la combinación
        public bool esValida = false;      // combinación válida (si es aleatoria, siempre es válida, si no, no tiene porqué)
        /// <summary>
        /// Método público de la lista de números privada
        /// </summary>
        public int[] ListaNumeros
        {
            get => _listaNumeros;
            set => _listaNumeros = value;
        }

        // En el caso de que el constructor sea vacío, se genera una combinación aleatoria correcta
        //
        /// <summary>
        /// Constructor vacío para crear la lotería
        /// </summary>
        public loto()
        {
            Random r = new Random();    // clase generadora de números aleatorios

            int i = 0, j, numeroAleatorio;

            do             // generamos la combinación
            {
                numeroAleatorio = r.Next(NUMERO_MENOR, NUMERO_MAYOR + 1);     // generamos un número aleatorio del 1 al 49
                for(j = 0; j < i; j++)    // comprobamos que el número no está
                    if(ListaNumeros[j] == numeroAleatorio)
                        break;
                if(i == j)               // Si i==j, el número no se ha encontrado en la lista, lo añadimos
                {
                    ListaNumeros[i] = numeroAleatorio;
                    i++;
                }
            } while(i < MAX_NUMEROS);

            esValida = true;
        }

        // La segunda forma de crear una combinación es pasando el conjunto de números
        // misnums es un array de enteros con la combinación que quiero crear (no tiene porqué ser válida)
        /// <summary>
        /// Constructor con parametro para crear la lotería
        /// </summary>
        /// <param name="misNumeros"></param>
        public loto(int[] misNumeros)  // misnumeros: combinación con la que queremos inicializar la clase
        {
            for(int i = 0; i < MAX_NUMEROS; i++)
                if(misNumeros[i] >= NUMERO_MENOR && misNumeros[i] <= NUMERO_MAYOR)
                {
                    int j;
                    for(j = 0; j < i; j++)
                        if(misNumeros[i] == ListaNumeros[j])
                            break;
                    if(i == j)
                        ListaNumeros[i] = misNumeros[i]; // validamos la combinación
                    else
                    {
                        esValida = false;
                        return;
                    }
                }
                else
                {
                    esValida = false;     // La combinación no es válida, terminamos
                    return;
                }
            esValida = true;
        }

        // Método que comprueba el número de aciertos
        // premi es un array con la combinación ganadora
        // se devuelve el número de aciertos
        /// <summary>
        /// Método con parámetro para comprobar el número de aciertos
        /// </summary>
        /// <param name="listaNumerosPremiados"></param>
        /// <returns></returns>
        public int comprobar(int[] listaNumerosPremiados)
        {
            int numeroAciertos = 0;                    // número de aciertos
            for(int i = 0; i < MAX_NUMEROS; i++)
                for(int j = 0; j < MAX_NUMEROS; j++)
                    if(listaNumerosPremiados[i] == ListaNumeros[j]) numeroAciertos++;
            return numeroAciertos;
        }
    }

}
