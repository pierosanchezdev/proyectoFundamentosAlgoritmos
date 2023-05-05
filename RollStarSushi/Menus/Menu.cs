using Utilitarios;

namespace Menus
{
    public class Menu
    {
        private static string versionActual = "v1.0.0";
        private static string grupo = "Grupo 4 S.A.C.";
        public static void MenuPrincipal()
        {
            
            Util.GenerarAsteriscosIzquierda(grupo);
            Util.GenerarAsteriscosCompletos();
            Util.GenerarAsteriscosCentral("Sistema de atención a clientes");
            Util.GenerarAsteriscosCentral("Roll Star Sushi Bar E.I.R.L");
            Util.GenerarAsteriscosCompletos();
            Util.GenerarAsteriscosDerecha(versionActual);
            Thread.Sleep(2000);
            Console.Clear();
        }
        public static void MenuOpciones()
        {
            Console.Clear();
            Util.GenerarAsteriscosCompletos();
            Util.GenerarAsteriscosCentral("Menu de opciones");
            Util.GenerarAsteriscosCompletos();
            Console.WriteLine("1. Mesas");
            Console.WriteLine("2. Pagos");
            Console.WriteLine("3. Mantenimiento");
            Console.WriteLine("4. Libro de reclamaciones");
            Console.WriteLine("0. Salir");
        }

        public static void MenuMesas()
        {
            Console.Clear();
            Util.GenerarAsteriscosCompletos();
            Util.GenerarAsteriscosCentral("Menu de Mesas");
            Util.GenerarAsteriscosCompletos();
            Console.WriteLine("1. Reservas");
            Console.WriteLine("2. Listar Mesas");
            Console.WriteLine("3. Buscar Mesa");
            Console.WriteLine("0. Regresar");
        }

        public static void MenuDetalleMesa()
        {
            Console.Clear();
            Util.GenerarAsteriscosCompletos();
            Util.GenerarAsteriscosCentral("Detalle de Pedido de Mesa");
            Util.GenerarAsteriscosCompletos();
            Console.WriteLine("1. Listar pedidos");
            Console.WriteLine("2. Asignar pedido");
            Console.WriteLine("3. Eliminar pedido");
            Console.WriteLine("0. Regresar");
        }

        public static void MenuPagos()
        {
            Console.Clear();
            Util.GenerarAsteriscosCompletos();
            Util.GenerarAsteriscosCentral("Menu de Pagos");
            Util.GenerarAsteriscosCompletos();
            Console.WriteLine("1. Seleccione la mesa para su resumen");
            Console.WriteLine("0. Regresar");
        }

        public static void MenuMantenimiento()
        {
            Console.Clear();
            Util.GenerarAsteriscosCompletos();
            Util.GenerarAsteriscosCentral("Menu de Mantenimiento");
            Util.GenerarAsteriscosCompletos();
            Console.WriteLine("1. Mantenimiento de Mesas");
            Console.WriteLine("2. Mantenimiento de Personal");
            Console.WriteLine("3. Mantenimiento de platillos");
            Console.WriteLine("0. Regresar");
        }

        //Editar acá
        public static void MenuMantenimientoMesas()
        {
            Console.Clear();
            Util.GenerarAsteriscosCompletos();
            Util.GenerarAsteriscosCentral("Menu de Mantenimiento de Mesas");
            Util.GenerarAsteriscosCompletos();
            Console.WriteLine("1. Agregar Mesa");
            Console.WriteLine("2. Listar Mesas Habilitadas");
            Console.WriteLine("3. Editar Mesas");
            Console.WriteLine("4. Eliminar Mesa");
            Console.WriteLine("0. Regresar");
        }

        public static void MenuMantenimientoPersonal()
        {
            Console.Clear();
            Util.GenerarAsteriscosCompletos();
            Util.GenerarAsteriscosCentral("Menu de Mantenimiento de Personal");
            Util.GenerarAsteriscosCompletos();
            Console.WriteLine("1. Crear Personal");
            Console.WriteLine("2. Listar Personal");
            Console.WriteLine("3. Editar Personal");
            Console.WriteLine("4. Eliminar Personal");
            Console.WriteLine("0. Regresar");
        }

        public static void MenuMantenimientoPlatillos()
        {
            Console.Clear();
            Util.GenerarAsteriscosCompletos();
            Util.GenerarAsteriscosCentral("Menu de Mantenimiento de Platillos");
            Util.GenerarAsteriscosCompletos();
            Console.WriteLine("1. Crear Platillo");
            Console.WriteLine("2. Listar Platillo");
            Console.WriteLine("3. Editar Platillo");
            Console.WriteLine("4. Eliminar Platillo");
            Console.WriteLine("0. Regresar");
        }

        public static void MenuLibroReclamaciones()
        {
            Console.Clear();
            Util.GenerarAsteriscosCompletos();
            Util.GenerarAsteriscosCentral("Menu de Libro de Reclamaciones");
            Util.GenerarAsteriscosCompletos();
            Console.WriteLine("1. Registrar reclamo");
            Console.WriteLine("0. Regresar");
        }

        public static void MenuSalida()
        {
            Console.Clear();
            Console.WriteLine("Usted salio del sistema...");
            Util.DetenerPrograma();
        }

    }
}