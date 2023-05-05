using System.Net;

namespace Utilitarios
{
    public class Util
    {
        private static int cantidadAsteriscosMaxima = 60;
        private static int indice;

        public static void GenerarAsteriscos(int cantidad)
        {            
            for (int i = 1; i <= cantidad; i++)
            {
                Console.Write("*");
            }
        }

        public static void GenerarAsteriscosCompletos()
        {
            GenerarAsteriscos(cantidadAsteriscosMaxima);
            Console.WriteLine();
        }

        public static void GenerarAsteriscosCentral(string mensaje)
        {
            int cantidadLetras = mensaje.Length;
            int espacios = (cantidadAsteriscosMaxima - cantidadLetras) / 2;
            GenerarAsteriscos(espacios);
            if (espacios % 2 == 0)
            {                
                Console.Write(mensaje + "*");
            }
            else
            {
                Console.Write(mensaje);
            }           
            GenerarAsteriscos(espacios);
            Console.WriteLine();
        }

        public static void GenerarAsteriscosDerecha(string mensaje)
        {
            int cantidadLetras = mensaje.Length;
            int espacios = cantidadAsteriscosMaxima - cantidadLetras;
            Console.Write(mensaje);
            GenerarAsteriscos(espacios);
            Console.WriteLine();
        }

        public static void GenerarAsteriscosIzquierda(string mensaje)
        {
            int cantidadLetras = mensaje.Length;
            int espacios = cantidadAsteriscosMaxima - cantidadLetras;            
            GenerarAsteriscos(espacios);
            Console.Write(mensaje);
            Console.WriteLine();
        }

        public static int SeleccioneUnaOpcion()
        {
            Console.Write("Digite una opción del Menú : ");
            return IngresarNumero();
        }

        public static int IngresarNumero()
        {
            int numero, contador = 1;
            string valor;
            do
            {
                if(contador != 1)
                {   
                    valor = "-1";
                }
                else
                {
                    valor = Console.ReadLine();
                }
                contador++;
            } while (!int.TryParse(valor, out numero));
            return numero;
        }

        public static void MensajeOpcionErrada()
        {
            Console.Clear();
            Console.WriteLine("Debe seleccionar una opción válida");
            DetenerPrograma();
        }

        public static void DetenerPrograma()
        {
            Console.WriteLine();
            Console.WriteLine("Presione una tecla para continuar ...");
            Console.ReadKey();
        }

        public static void LimpiarPantalla()
        {
            Console.Clear();
        }

        public static int[,] CargaListaMesas()
        {
            int[,] array = new int[10,1];
            for(int i = 0; i < array.GetLength(0); i++)
            {
                for(int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = 0;
                }
            }
            return array;
        }

        public static void ListarMesas(int[,] listaMesas)
        {
            string estado;
            Console.WriteLine("   MESA   |   ESTADO   ");
            for (int i = 0;i < listaMesas.GetLength(0); i++)
            {
                for(int j = 0; j < listaMesas.GetLength(1); j++)
                {
                    if (listaMesas[i,j] == 0)
                    {
                        estado = "Libre";
                    }
                    else
                    {
                        estado = "Ocupada";
                    }
                    Console.WriteLine($"     {i+1}        {estado} ");
                }
            }
        }

        public static bool BuscarMesa(int[,] listaMesas)
        {
            Console.Write("Ingrese el N° de Mesa : ");
            indice = Util.IngresarNumero() - 1;
            string estado;
            bool conforme = false;
            for (int i = 0; i < listaMesas.GetLength(0); i++)
            {
                if(i == indice)
                {
                    conforme = true;
                    for (int j = 0; j < listaMesas.GetLength(1); j++)
                    {
                        if (listaMesas[i, j] == 0)
                        {
                            estado = "Libre";
                        }
                        else
                        {
                            estado = "Ocupada";
                        }
                        Console.WriteLine($"La mesa N° {i+1} esta {estado}");
                    }
                }            
            }
            if (!conforme)
            {
                Console.WriteLine("No se encontro el N° de Mesa");
            }
            return conforme;
        }

        public static int[,] ReservarMesa(int[,] listaMesas)
        {            
            bool mesaEncontrada = Util.BuscarMesa(listaMesas);
            if (mesaEncontrada)
            {
                for(int i = 0; i < listaMesas.GetLength(0); i++)
                {
                    if(indice == i)
                    {
                        for (int j = 0; j < listaMesas.GetLength(1); j++)
                        {
                            if (listaMesas[i, j] == 0)
                            {
                                Console.WriteLine("Se reservo la mesa correctamente");
                                listaMesas[i, j] = 1;
                            }
                            else
                            {
                                Console.WriteLine("La mesa se encuentra ocupada, por favor seleccione otra mesa");
                            }
                        }
                    }
                }
            }            
            return listaMesas;
        }

        public static string[,] CargaDataInicialPersonal()
        {
            string[,] array = new string[4, 5];
            array[0, 0] = "45607025";
            array[0, 1] = "Piero";
            array[0, 2] = "Sánchez";
            array[0, 3] = "Mesero";
            array[0, 4] = "1200.00";
            array[1, 0] = "12345678";
            array[1, 1] = "Oscar";
            array[1, 2] = "Roman";
            array[1, 3] = "Mesero";
            array[1, 4] = "1200.00";
            array[2, 0] = "98765434";
            array[2, 1] = "Diana";
            array[2, 2] = "Salvador";
            array[2, 3] = "Mesero";
            array[2, 4] = "1200.00";
            array[3, 0] = "12348776";
            array[3, 1] = "Sania";
            array[3, 2] = "Muñoz";
            array[3, 3] = "Mesero";
            array[3, 4] = "1200.00";
            return array;
        }

        public static string[,] CrearPersonal(string[,] listaPersonal)
        {
            string dni = ValidarCaracteres("Ingrese el DNI : ");
            string nombre = ValidarCaracteres("Ingrese los nombres del empleado : ");
            string apellido = ValidarCaracteres("Ingrese los apellidos del empleado : ");
            string cargo = ValidarCaracteres("Ingrese el cargo del empleado : ");
            string sueldo = ValidarCaracteres("Ingrese el sueldo del empleado : ");
            int nuevaFila = listaPersonal.GetLength(0) + 1;
            string[,] nuevoArray = new string[nuevaFila, listaPersonal.GetLength(1)];
            for (int fila = 0; fila < listaPersonal.GetLength(0); fila++)
            {
                for (int columna = 0; columna < listaPersonal.GetLength(1); columna++)
                {
                    nuevoArray[fila, columna] = listaPersonal[fila, columna];
                }
            }
            nuevoArray[nuevaFila - 1, 0] = dni;
            nuevoArray[nuevaFila - 1, 1] = nombre;
            nuevoArray[nuevaFila - 1, 2] = apellido;
            nuevoArray[nuevaFila - 1, 3] = cargo;
            nuevoArray[nuevaFila - 1, 4] = sueldo;
            return nuevoArray;
        }

        public static string[,] EliminarPersonal(string[,] listaPersonal)
        {
            int filaActual = listaPersonal.GetLength(0) - 1;
            int nuevaFila = 0;
            if (BuscarPersonal(listaPersonal))
            {
                string[,] nuevoArray = new string[filaActual, listaPersonal.GetLength(1)];
                for (int fila = 0; fila < listaPersonal.GetLength(0); fila++)
                {
                    if (fila != indice)
                    {
                        for (int columna = 0; columna < listaPersonal.GetLength(1); columna++)
                        {
                            nuevoArray[nuevaFila, columna] = listaPersonal[fila, columna];
                        }
                        nuevaFila++;
                    }
                }
                return nuevoArray;
            }            
            return listaPersonal;
        }

        public static string[,] EditarPersonal(string[,] listaPersonal)
        {
            if (BuscarPersonal(listaPersonal))
            {
                for (int fila = 0; fila < listaPersonal.GetLength(0); fila++)
                {
                    if (fila == indice)
                    {
                        listaPersonal[fila, 0] = ValidarCaracteres("Ingrese el DNI : ");
                        listaPersonal[fila, 1] = ValidarCaracteres("Ingrese los nombres del empleado : ");
                        listaPersonal[fila, 2] = ValidarCaracteres("Ingrese los apellidos del empleado : ");
                        listaPersonal[fila, 3] = ValidarCaracteres("Ingrese el cargo del empleado : ");
                        listaPersonal[fila, 4] = ValidarCaracteres("Ingrese el sueldo del empleado : ");
                        Console.WriteLine("El empleado ha sido editado correctamente");
                    }
                }
            }
            return listaPersonal;
        }

        private static bool BuscarPersonal(string[,] listaPersonal)
        {
            Console.Write("Ingrese el ID del personal: ");
            indice = IngresarNumero() - 1;
            for(int i = 0; i < listaPersonal.GetLength(0); i++)
            {
                if (indice == i)
                {
                    return true;
                }
            }
            Console.WriteLine("No se encontro el ID del empleado");
            return false;
        }

        public static void ListarPersonal(string[,] listaPersonal)
        {
            Console.WriteLine("ID     |   DNI      |      NOMBRES   |      APELLIDOS      |      CARGO      |      SUELDO   ");
            for (int i = 0; i < listaPersonal.GetLength(0); i++)
            {
                Console.Write($"{i+1}      ");
                for (int j = 0; j < listaPersonal.GetLength(1); j++)
                {
                    Console.Write($"{listaPersonal[i, j]}      ");
                }
                Console.WriteLine();
            }
        }


        public static string[,] CargaDataInicialPlatillos()
        {
            string[,] array = new string[4, 4];
            array[0, 0] = "Maki Inca";
            array[0, 1] = "Hechos de quinua, palta, cebiche y camote.";
            array[0, 2] = "20.00";
            array[0, 3] = "Makis";
            array[1, 0] = "Maki Andino";
            array[1, 1] = "Hecho de trucha ahumada, queso andino, aji amarillo.";
            array[1, 2] = "25.00";
            array[1, 3] = "Makis";
            array[2, 0] = "Maki Nikkei";
            array[2, 1] = "Hecho de delicioso atún, mango, rocoto, mayonesa japonesa.";
            array[2, 2] = "27.00";
            array[2, 3] = "Maki";
            array[3, 0] = "Chilcano de Maracuya";
            array[3, 1] = "Rico refresco para la bariga";
            array[3, 2] = "12.00";
            array[3, 3] = "Refresco";
            return array;
        }

        public static string[,] CrearPlatillo(string[,] listaPlatillo)
        {
            string nombre = ValidarCaracteres("Ingrese el nuevo platillo: ");
            string descripción = ValidarCaracteres("Ingrese los ingredientes: ");
            string precio = ValidarCaracteres("Ingrese el precio: S/");
            string categoria = ValidarCaracteres("Ingrese la categoría: ");
            int nuevaFila = listaPlatillo.GetLength(0) + 1;
            string[,] nuevoArray = new string[nuevaFila, listaPlatillo.GetLength(1)];
            for (int fila = 0; fila < listaPlatillo.GetLength(0); fila++)
            {
                for (int columna = 0; columna < listaPlatillo.GetLength(1); columna++)
                {
                    nuevoArray[fila, columna] = listaPlatillo[fila, columna];
                }
            }
            nuevoArray[nuevaFila - 1, 0] = nombre;
            nuevoArray[nuevaFila - 1, 1] = descripción;
            nuevoArray[nuevaFila - 1, 2] = precio;
            nuevoArray[nuevaFila - 1, 3] = categoria;
            return nuevoArray;
        }

        public static string[,] EliminarPlatillo(string[,] listaPlatillo)
        {
            int filaActual = listaPlatillo.GetLength(0) - 1;
            int nuevaFila = 0;
            if (BuscarPlatillo(listaPlatillo))
            {
                string[,] nuevoArray = new string[filaActual, listaPlatillo.GetLength(1)];
                for (int fila = 0; fila < listaPlatillo.GetLength(0); fila++)
                {
                    if (fila != indice)
                    {
                        for (int columna = 0; columna < listaPlatillo.GetLength(1); columna++)
                        {
                            nuevoArray[nuevaFila, columna] = listaPlatillo[fila, columna];
                        }
                        nuevaFila++;
                    }
                }
                return nuevoArray;
            }
            return listaPlatillo;
        }

        public static string[,] EditarPlatillo(string[,] listaPlatillo)
        {
            if (BuscarPlatillo(listaPlatillo))
            {
                for (int fila = 0; fila < listaPlatillo.GetLength(0); fila++)
                {
                    if (fila == indice)
                    {
                        listaPlatillo[fila, 0] = ValidarCaracteres("Ingrese el nombre : ");
                        listaPlatillo[fila, 1] = ValidarCaracteres("Ingrese los ingredientes: ");
                        listaPlatillo[fila, 2] = ValidarCaracteres("Ingrese el precio: S/ ");
                        listaPlatillo[fila, 3] = ValidarCaracteres("Ingrese la categoría: ");
                        Console.WriteLine("El platillo ha sido editado correctamente");
                    }
                }
            }
            return listaPlatillo;
        }

        private static bool BuscarPlatillo(string[,] listaPlatillo)
        {
            Console.Write("Ingrese el ID del platillo: ");
            indice = IngresarNumero() - 1;
            for (int i = 0; i < listaPlatillo.GetLength(0); i++)
            {
                if (indice == i)
                {
                    return true;
                }
            }
            Console.WriteLine("No se encontro el ID del empleado");
            return false;
        }

        public static void ListarPlatillo(string[,] listaPlatillo)
        {
            Console.WriteLine("ID     |   NOMBRE      |      INGREDIENTES       |      PRECIO       |      CATEGORÍA    ");
            for (int i = 0; i < listaPlatillo.GetLength(0); i++)
            {
                Console.Write($"{i + 1}      ");
                for (int j = 0; j < listaPlatillo.GetLength(1); j++)
                {
                    Console.Write($"{listaPlatillo[i, j]}      ");
                }
                Console.WriteLine();
            }
        }
        public static string ValidarCaracteres(string mensaje)
        {
            string texto = string.Empty;
            while (string.IsNullOrWhiteSpace(texto))
            {
                Console.WriteLine(mensaje);
                texto = Console.ReadLine();
            }
            return texto;
        }




    }

}
 

