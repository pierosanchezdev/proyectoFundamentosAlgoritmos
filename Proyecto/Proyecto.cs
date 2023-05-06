using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;
using Menus;

namespace Proyecto
{
    public class Proyecto
    {
        public static void Main(string[] args)
        {
            bool continuar = true;
            int opcion;
            int[,] listaMesas = Util.CargaListaMesas();
            string[,] listaPersonal = Util.CargaDataInicialPersonal();
            string[,] listaProductos = Util.CargaDataInicialProductos();
            string[,] listaPedidosMesa = new string[0,0];
            Menu.MenuPrincipal();
            do
            {                
                Menu.MenuOpciones();
                opcion = Util.SeleccioneUnaOpcion();
                switch (opcion)
                {
                    case 1:                        
                        do
                        {
                            Menu.MenuMesas();
                            opcion = Util.SeleccioneUnaOpcion();
                            switch (opcion)
                            {
                                case 1:
                                    //Reserva de mesas
                                    Util.LimpiarPantalla();
                                    listaMesas = Util.ReservarMesa(listaMesas);
                                    Util.DetenerPrograma();
                                    break;
                                case 2:
                                    //Listar todas las mesas
                                    Util.LimpiarPantalla();
                                    Util.ListarMesas(listaMesas);
                                    Util.DetenerPrograma();
                                    break;
                                case 3:
                                    //Buscar mesa y su detalle
                                    Util.LimpiarPantalla();
                                    if (Util.VerificarMesaOcupada(listaMesas))
                                    {
                                        do
                                        {
                                            Menu.MenuDetalleMesa();
                                            opcion = Util.SeleccioneUnaOpcion();
                                            switch (opcion)
                                            {
                                                case 1:
                                                    Util.LimpiarPantalla();
                                                    Util.ListarPedidosPorMesa(listaPedidosMesa);
                                                    Util.DetenerPrograma();
                                                    break;
                                                case 2:
                                                    Util.LimpiarPantalla();
                                                    Util.ListarProductos(listaProductos);
                                                    Menu.AsignarProductoMesa();
                                                    listaPedidosMesa = Util.AsignarProductoMesa(listaPedidosMesa, listaProductos);
                                                    Util.DetenerPrograma();
                                                    break;
                                                case 3:
                                                    Util.LimpiarPantalla();
                                                    Util.ListarPedidosPorMesa(listaPedidosMesa);
                                                    listaPedidosMesa = Util.EliminarPedidoMesa(listaPedidosMesa);
                                                    Util.DetenerPrograma();
                                                    break;
                                                case 0:
                                                    Menu.MenuOpciones();
                                                    continuar = false;
                                                    break;
                                                default:
                                                    Util.MensajeOpcionErrada();
                                                    Menu.MenuDetalleMesa();
                                                    break;
                                            }
                                        } while (continuar);
                                        continuar = true;
                                    }                                    
                                    Util.DetenerPrograma();
                                    break;
                                case 0:
                                    //Regresar al Menú anterior
                                    Menu.MenuOpciones();
                                    continuar = false;
                                    break;
                                default:
                                    //Mensaje por defecto al seleccionar opcion errada.
                                    Util.MensajeOpcionErrada();
                                    Menu.MenuMesas();
                                    break;
                            }
                        } while (continuar);
                        continuar = true;
                        break;
                    case 2:
                        do
                        {
                            Menu.MenuPagos();
                            opcion = Util.SeleccioneUnaOpcion();
                            switch (opcion)
                            {
                                case 1:
                                    Util.LimpiarPantalla();
                                    Util.ListarPedidosPorMesa(listaPedidosMesa);
                                    Util.DetenerPrograma();
                                    break;
                                case 2:
                                    Util.LimpiarPantalla();
                                    break;
                                case 0:
                                    Menu.MenuOpciones();
                                    continuar = false;
                                    break;
                                default:
                                    Util.MensajeOpcionErrada();
                                    Menu.MenuPagos();
                                    break;
                            }
                        } while (continuar);
                        continuar = true;
                        break;
                    case 3:
                        do
                        {
                            Menu.MenuMantenimiento();
                            opcion = Util.SeleccioneUnaOpcion();
                            switch (opcion)
                            {
                                case 1:
                                    do
                                    {
                                        Menu.MenuMantenimientoMesas();
                                        opcion = Util.SeleccioneUnaOpcion();
                                        switch (opcion)
                                        {
                                            case 1:
                                                break;
                                            case 2:
                                                break;
                                            case 3:
                                                break;
                                            case 4:
                                                break;
                                            case 0:
                                                Menu.MenuMantenimiento();
                                                continuar = false;
                                                break;
                                            default:
                                                Util.MensajeOpcionErrada();
                                                Menu.MenuMantenimientoMesas();
                                                break;
                                        }
                                    } while (continuar);
                                    continuar = true;
                                    break;
                                case 2:
                                    do
                                    {
                                        Menu.MenuMantenimientoPersonal();
                                        opcion = Util.SeleccioneUnaOpcion();
                                        switch (opcion)
                                        {
                                            case 1:
                                                Util.LimpiarPantalla();
                                                listaPersonal = Util.CrearPersonal(listaPersonal);
                                                Util.DetenerPrograma();
                                                break;
                                            case 2:
                                                Util.LimpiarPantalla();
                                                Util.ListarPersonal(listaPersonal);
                                                Util.DetenerPrograma();
                                                break;
                                            case 3:
                                                Util.LimpiarPantalla();
                                                Util.ListarPersonal(listaPersonal);
                                                listaPersonal = Util.EditarPersonal(listaPersonal);
                                                Util.DetenerPrograma();
                                                break;
                                            case 4:
                                                Util.LimpiarPantalla();
                                                Util.ListarPersonal(listaPersonal);
                                                listaPersonal = Util.EliminarPersonal(listaPersonal);
                                                Util.DetenerPrograma();
                                                break;
                                            case 0:
                                                Menu.MenuMantenimiento();
                                                continuar = false;
                                                break;
                                            default:
                                                Util.MensajeOpcionErrada();
                                                Menu.MenuMantenimientoPersonal();
                                                break;
                                        }
                                    } while (continuar);
                                    continuar = true;
                                    break;
                                case 3:
                                    do
                                    {
                                        Menu.MenuMantenimientoPlatillos();
                                        opcion = Util.SeleccioneUnaOpcion();
                                        switch (opcion)
                                        {
                                            case 1:
                                                Util.LimpiarPantalla();
                                                listaProductos = Util.CrearProducto(listaProductos);
                                                Util.DetenerPrograma();
                                                break;
                                            case 2:
                                                Util.LimpiarPantalla();
                                                Util.ListarProductos(listaProductos);
                                                Util.DetenerPrograma();
                                                break;
                                            case 3:
                                                Util.LimpiarPantalla();
                                                Util.ListarProductos(listaProductos);
                                                listaProductos = Util.EditarProducto(listaProductos);
                                                Util.DetenerPrograma();
                                                break;
                                            case 4:
                                                Util.LimpiarPantalla();
                                                Util.ListarProductos(listaProductos);
                                                listaProductos = Util.EliminarProducto(listaProductos);
                                                Util.DetenerPrograma();
                                                break;
                                            case 0:
                                                Menu.MenuMantenimiento();
                                                continuar = false;
                                                break;
                                            default:
                                                Util.MensajeOpcionErrada();
                                                Menu.MenuMantenimientoPlatillos();
                                                break;
                                        }
                                    } while (continuar);
                                    continuar = true;
                                    break;
                                case 0:
                                    Menu.MenuOpciones();
                                    continuar = false;
                                    break;
                                default:
                                    Util.MensajeOpcionErrada();
                                    Menu.MenuMantenimiento();
                                    break;
                            }
                        } while (continuar);
                        continuar = true;
                        break;
                    case 4:
                        do
                        {
                            Menu.MenuLibroReclamaciones();
                            opcion = Util.SeleccioneUnaOpcion();
                            switch (opcion)
                            {
                                case 1:
                                    break;
                                case 0:
                                    Menu.MenuOpciones();
                                    continuar = false;
                                    break;
                                default:
                                    Util.MensajeOpcionErrada();
                                    Menu.MenuLibroReclamaciones();
                                    break;
                            }
                        } while (continuar);
                        continuar = true;
                        break;
                    case 0:
                        Menu.MenuSalida();
                        continuar = false;
                        break;
                    default:
                        Util.MensajeOpcionErrada();
                        Menu.MenuOpciones();
                        break;
                }
            } while (continuar);
        }

    }
}