using System.Net;

namespace Utilitarios
{
    public class Util
    {
        private static int cantidadAsteriscosMaxima = 60;
        public static int indiceMesa, indiceEmpleado, indiceProducto, indicePedidoMesa;

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
            indiceMesa = Util.IngresarNumero() - 1;
            string estado;
            bool conforme = false;
            for (int i = 0; i < listaMesas.GetLength(0); i++)
            {
                if(i == indiceMesa)
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

        public static bool VerificarMesaOcupada(int[,] listaMesas) {
            if (BuscarMesa(listaMesas))
            {
                for(int i = 0; i < listaMesas.GetLength(0); i++)
                {
                    if(i == indiceMesa)
                    {
                        for(int j = 0; j < listaMesas.GetLength(1); j++)
                        {
                            if (listaMesas[i,j] == 1)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            Console.WriteLine("Debe seleccionar una mesa reservada para continuar.");
            return false;
        }      

        public static int[,] ReservarMesa(int[,] listaMesas)
        {            
            bool mesaEncontrada = Util.BuscarMesa(listaMesas);
            if (mesaEncontrada)
            {
                for(int i = 0; i < listaMesas.GetLength(0); i++)
                {
                    if(indiceMesa == i)
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
                    if (fila != indiceEmpleado)
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
                    if (fila == indiceEmpleado)
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
            indiceEmpleado = IngresarNumero() - 1;
            for(int i = 0; i < listaPersonal.GetLength(0); i++)
            {
                if (indiceEmpleado == i)
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

        public static string[,] CargaDataInicialProductos()
        {
            string[,] array = new string[10, 2];
            array[0, 0] = "Maki Acevichado";
            array[0, 1] = "10.00";
            array[1, 0] = "Maki Pollo a la Brasa";
            array[1, 1] = "10.00";
            array[2, 0] = "Alitas x6";
            array[2, 1] = "18.00";
            array[3, 0] = "Yakimeshi";
            array[3, 1] = "10.00";
            array[4, 0] = "Maki volcán";
            array[4, 1] = "10.00";
            array[5, 0] = "Maki Majestuoso";
            array[5, 1] = "10.00";
            array[6, 0] = "Maki Salmón tartar";
            array[6, 1] = "10.00";
            array[7, 0] = "Maki Crispy";
            array[7, 1] = "10.00";
            array[8, 0] = "Maki gaucho";
            array[8, 1] = "10.00";
            array[9, 0] = "Alitas x12";
            array[9, 1] = "30.00";
            return array;
        }

        public static string[,] CrearProducto(string[,] listaProductos)
        {
            string nombre = ValidarCaracteres("Ingrese el nombre del producto : ");
            string precio = ValidarCaracteres("Ingrese el precio del producto : ");

            int nuevaFila = listaProductos.GetLength(0) + 1;

            string[,] nuevoArray = new string[nuevaFila, listaProductos.GetLength(1)];

            for (int fila = 0; fila < listaProductos.GetLength(0); fila++)
            {
                for (int columna = 0; columna < listaProductos.GetLength(1); columna++)
                {
                    nuevoArray[fila, columna] = listaProductos[fila, columna];
                }
            }
            nuevoArray[nuevaFila - 1, 0] = nombre;
            nuevoArray[nuevaFila - 1, 1] = precio;
            return nuevoArray;
        }

        public static string[,] EliminarProducto(string[,] listaProductos)
        {
            int filaActual = listaProductos.GetLength(0) - 1;
            int nuevaFila = 0;
            if (BuscarProducto(listaProductos))
            {
                string[,] nuevoArray = new string[filaActual, listaProductos.GetLength(1)];
                for (int fila = 0; fila < listaProductos.GetLength(0); fila++)
                {
                    if (fila != indiceProducto)
                    {
                        for (int columna = 0; columna < listaProductos.GetLength(1); columna++)
                        {
                            nuevoArray[nuevaFila, columna] = listaProductos[fila, columna];
                        }
                        nuevaFila++;
                    }
                }
                return nuevoArray;
            }
            return listaProductos;
        }

        public static string[,] EditarProducto(string[,] listaProductos)
        {
            if (BuscarProducto(listaProductos))
            {
                for (int fila = 0; fila < listaProductos.GetLength(0); fila++)
                {
                    if (fila == indiceProducto)
                    {
                        listaProductos[fila, 0] = ValidarCaracteres("Ingrese el nombre del producto : ");
                        listaProductos[fila, 1] = ValidarCaracteres("Ingrese el precio del producto : ");
                        Console.WriteLine("El producto ha sido editado correctamente");
                    }
                }
            }
            return listaProductos;
        }

        private static bool BuscarProducto(string[,] listaProductos)
        {
            Console.Write("Ingrese el ID del producto: ");
            indiceProducto = IngresarNumero() - 1;
            for (int i = 0; i < listaProductos.GetLength(0); i++)
            {
                if (indiceProducto == i)
                {
                    return true;
                }
            }
            Console.WriteLine("No se encontro el ID del empleado");
            return false;
        }

        public static void ListarProductos(string[,] listaProductos)
        {
            Console.WriteLine("ID     |   NOMBRE      |      PRECIO     ");
            for (int i = 0; i < listaProductos.GetLength(0); i++)
            {
                Console.Write($"{i + 1}      ");
                for (int j = 0; j < listaProductos.GetLength(1); j++)
                {
                    Console.Write($"{listaProductos[i, j]}      ");
                }
                Console.WriteLine();
            }
        }

        public static void ListarPedidosPorMesa(string[,] listaPedidosMesa)
        {
            if (!VerificarListaPedidosVacia(listaPedidosMesa))
            {
                int contador = 0;
                Console.WriteLine("ID MESA   |    ID PEDIDO    |    PEDIDO    |    PRECIO");
                for (int i = 0; i < listaPedidosMesa.GetLength(0); i++)
                {
                    if(indiceMesa == int.Parse(listaPedidosMesa[i, 0]))
                    {
                        contador++;
                        Console.Write($"{i+1}    {int.Parse(listaPedidosMesa[i, 0])+1} {listaPedidosMesa[i, 2]}   {listaPedidosMesa[i, 3]}");
                        Console.WriteLine();
                    }                    
                }
                if(contador <= 0)
                {
                    Console.WriteLine("La mesa no tiene pedidos ingresados.");
                }
            }
            else
            {
                Console.WriteLine("La mesa no tiene pedidos ingresados.");
            }            
        }

        public static string[,] AsignarProductoMesa(string[,] listaPedidosMesa, string[,] listaProductos)
        {
            if (BuscarProducto(listaProductos))
            {
                if (VerificarListaPedidosVacia(listaPedidosMesa))
                {
                    string[,] nuevaLista = new string[1, 4];
                    nuevaLista[0,0] = $"{indiceMesa}";
                    nuevaLista[0,1] = $"{indiceProducto}";
                    nuevaLista[0,2] = $"{GetNombreProducto(listaProductos)}";
                    nuevaLista[0,3] = $"{GetPrecioProducto(listaProductos)}";
                    return nuevaLista;
                }
                else
                {
                    int nuevaFila = listaPedidosMesa.GetLength(0) + 1;

                    string[,] nuevaLista = new string[nuevaFila, listaPedidosMesa.GetLength(1)];

                    for (int fila = 0; fila < listaPedidosMesa.GetLength(0); fila++)
                    {
                        for (int columna = 0; columna < listaPedidosMesa.GetLength(1); columna++)
                        {
                            nuevaLista[fila, columna] = listaPedidosMesa[fila, columna];
                        }
                    }
                    nuevaLista[nuevaFila - 1, 0] = $"{indiceMesa}";
                    nuevaLista[nuevaFila - 1, 1] = $"{indiceProducto}";
                    nuevaLista[nuevaFila - 1, 2] = $"{GetNombreProducto(listaProductos)}";
                    nuevaLista[nuevaFila - 1, 3] = $"{GetPrecioProducto(listaProductos)}";
                    return nuevaLista;
                }
            }
            return listaPedidosMesa;
        }

        public static string GetNombreProducto(string[,] listaProductos)
        {
            for(int i = 0;i < listaProductos.GetLength(0); i++)
            {
                if(i == indiceProducto)
                {
                    for(int j = 0; j < listaProductos.GetLength(1); j++)
                    {
                        if(j == 0)
                        {
                            return listaProductos[i,j];
                        }
                    }
                }
            }
            return "";
        }

        public static string GetPrecioProducto(string[,] listaProductos)
        {
            for (int i = 0; i < listaProductos.GetLength(0); i++)
            {
                if (i == indiceProducto)
                {
                    for (int j = 0; j < listaProductos.GetLength(1); j++)
                    {
                        if (j == 1)
                        {
                            return listaProductos[i, j];
                        }
                    }
                }
            }
            return "";
        }

        public static string[,] EliminarPedidoMesa(string[,] listaPedidosMesa)
        {
            if (!VerificarListaPedidosVacia(listaPedidosMesa))
            {
                if (BuscarPedidoMesa(listaPedidosMesa))
                {
                    int filaActual = listaPedidosMesa.GetLength(0) - 1;
                    int nuevaFila = 0;
                    string[,] nuevoArray = new string[filaActual, listaPedidosMesa.GetLength(1)];
                    for (int fila = 0; fila < listaPedidosMesa.GetLength(0); fila++)
                    {
                        if (fila != indicePedidoMesa)
                        {
                            for (int columna = 0; columna < listaPedidosMesa.GetLength(1); columna++)
                            {
                                nuevoArray[nuevaFila, columna] = listaPedidosMesa[fila, columna];
                            }
                            nuevaFila++;
                        }
                    }
                    return nuevoArray;
                }
            }
            return listaPedidosMesa;
        }

        public static bool BuscarPedidoMesa(string[,] listaPedidosMesa)
        {
            Console.Write("Ingrese el ID del pedido en mesa: ");
            indicePedidoMesa = IngresarNumero() - 1;
            for (int i = 0; i < listaPedidosMesa.GetLength(0); i++)
            {
                if (indicePedidoMesa == i)
                {
                    return true;
                }
            }
            Console.WriteLine("No se encontro el ID del pedido en mesa");
            return false;
        }

        public static bool VerificarListaPedidosVacia(string[,] listaPedidosMesa)
        {
            if(listaPedidosMesa.Length == 0)
            {
                return true;
            }
            return false;
        }

        public static void EfectuarPagoMesa(string[,] listaPedidosMesa, int[,] listaMesa)
        {
            if (VerificarListaPedidosVacia(listaPedidosMesa))
            {
                if (VerificarMesaOcupada(listaMesa))
                {

                }
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