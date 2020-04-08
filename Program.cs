using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace PROYECTO___FINAL
{
    [Serializable()]
    class Menus
    {
        public static List<Usuario_cliente> usuariocliente = new List<Usuario_cliente>();
        public static List<Menu_Admin> usuarioadmin = new List<Menu_Admin>();
        public static List<Transacciones> transacciones = new List<Transacciones>();
        public static Transacciones transaccion, balance;
        public static List<Banco> bankinfo = new List<Banco>();
        static Usuario_cliente saldo = new Usuario_cliente();
        static int bank_, bank_2, bank_3, bank_4;
        static string card, bank_name;
        static int c100 = 0, c200 = 0, c500 = 0, c1000 = 0;
        static double monto, saldo_;

        public static void Inicio()
        {
            Console.WriteLine("                    ________________________________________________________________");
            Console.WriteLine("                   |                                                                |");
            Console.WriteLine("                   |              Cajero Tecnológico de las Américas                |");
            Console.WriteLine("                   |                     " + DateTime.Now + "                     |");
            Console.WriteLine("                   |________________________________________________________________|\n");
        }
        public static void LoginAdmin()
        {
            try
            {

            iniciomenuadmin:
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Title = "ITLA BANK";
                Menu_Admin user = new Menu_Admin();
                Menu_Admin usuario = new Menu_Admin();
                Console.Clear();
                Inicio();
                Console.Write("\n                     > Número de tarjeta (####-####-####-####): ");
                card = Console.ReadLine();
                Console.Write("\n                     > Contraseña: ");
                string contrasena = Ocultar.password.Console.Read__Pass();
                user.Password = "ASDFGL-9632147"; user.cardnumber = "7412-7896-2587-3214";
                if (user.Password == contrasena && user.cardnumber == card || usuarioadmin.Exists(x => x.cardnumber == card) && usuarioadmin.Exists(j => j.Password == contrasena))
                {
                    MenuPrincipaladministrador();
                }
                if (usuariocliente.Exists(x => x.cardnumber == card) && usuariocliente.Exists(y => y.Password == contrasena))
                {
                    MenuPrincipalCliente();
                }
                if (usuariocliente.Exists(x => x.cardnumber == card) && (usuariocliente.Exists(y => y.Password != contrasena)))
                {
                    int i = 1, ingresos_maximos = 3;
                    foreach (Usuario_cliente t in usuariocliente)
                    {
                        do
                        {
                            Console.WriteLine("Datos incorrectos. Ingreselos de nuevo.");
                            Console.WriteLine("Toque una tecla para continuar...");
                            Console.ReadKey();
                            i++;
                            Console.Clear();
                            Inicio();
                            Console.Write("                                          \nNúmero de tarjeta (####-####-####-####): ");
                            card = Console.ReadLine();
                            Console.Write("                                                         \nContraseña: ");
                            contrasena = Ocultar.password.Console.Read__Pass();


                            if (i >= ingresos_maximos)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("                                     ---------Usuario Bloqueado---------");
                                Console.WriteLine("                                 \nComuniquese con el usuario administrador para desbloquear usuario.");
                                Console.WriteLine("                                         Toque una tecla para continuar...");
                                Console.ReadKey();
                                LoginAdmin();
                            }

                        } while (t.Password != contrasena);
                        MenuPrincipalCliente();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n\n\n\n\n");
                    Console.WriteLine("                                Número de tarjeta o Contraseña incorrecta/as");
                    Console.WriteLine("                          [Presione cualquier tecla para reiniciar el formulario]");
                    Console.ReadKey();
                    goto iniciomenuadmin;
                }


            }
            catch (Exception message)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("                           **** " + message.Message + " ***** ");
                Console.WriteLine("               [Toque cualquier letra para volver al menu de administrador]");
                Console.ReadKey();
                MenuPrincipaladministrador();
            }
        }
        public static void MenuPrincipaladministrador()
        {
            try
            {
            menúadministrador:
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("                   ________________________________________________________________ ");
                Console.WriteLine("                  |                                                                |");
                Console.WriteLine("                  |               Menu Principal de Administrador                  |");
                Console.WriteLine("                  |                           " + DateTime.Now + "                 |");
                Console.WriteLine("                  | ______________________________________________________________ |\n");
                Console.Write("                     Elija la opción deseada: \n");
                Console.WriteLine("\n                              |  [1] Agregar Cliente                 |");
                Console.WriteLine("                              |  [2] Editar Cliente                  |");
                Console.WriteLine("                              |  [3] Eliminar Cliente                |");
                Console.WriteLine("                              |  [4] Reiniciar contraseña            |");
                Console.WriteLine("                              |  [5] Agregar Saldo                   |");
                Console.WriteLine("                              |  [6] Log de transacciones            |");
                Console.WriteLine("                              |  [7] Configuracion del ATM           |");
                Console.WriteLine("                              |  [8] Administrar Usuarios            |");
                Console.WriteLine("                              |  [9] Reactivación de Usuario         |");
                Console.WriteLine("                              | [10] Cerrar Sesion                   |");
                Console.WriteLine("                              | ____________________________________ |");
                int resp = int.Parse(Console.ReadLine());
                switch (resp)
                {
                    case (int)adminmenu.adclient:
                        agregarcliente();
                        break;
                    case (int)adminmenu.editclient:
                        editarcliente();
                        break;
                    case (int)adminmenu.deleteclient:
                        eliminarcliente();
                        break;
                    case (int)adminmenu.changepassword:
                        cambiarcontraseña();
                        break;
                    case (int)adminmenu.saldo:
                        Agregarsaldo();
                        break;
                    case (int)adminmenu.showlog:
                        log();
                        break;
                    case (int)adminmenu.configuracionATM:
                        configATM();
                        break;
                    case (int)adminmenu.adminusers:
                        Administracionusuarios();
                        break;
                    case (int)adminmenu.reactiveusers:
                        reactivarusuario();
                        break;
                    case (int)adminmenu.closesection:
                        cerrarseccion();
                        break;
                    default:
                        Console.WriteLine("                                                Opción no válida.");
                        Console.WriteLine("                   [Toque cualquier letra para volver al menu principal de administrador]");
                        Console.ReadKey();
                        goto menúadministrador;
                }
            }
            catch (Exception error)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\n\n\n\n");
                Console.WriteLine("                              ***        " + error.Message + "        ***");
                Console.WriteLine("                            [Toque cualquier letra para reiniciar el formulario]");
                Console.ReadKey();
                MenuPrincipaladministrador();
            }
        }
        public static void agregarcliente()
        {
            try
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Usuario_cliente useradd = new Usuario_cliente();
                Console.Clear();
                Console.WriteLine("\n\n\n\n\n");
                Console.Write("                                 > Nombre del cliente: ");
                useradd.name = Console.ReadLine();
                Console.Write("\n                                 > Apellido del cliente: ");
                useradd.lastname = Console.ReadLine();
                Console.Write("\n                                 > Numero de tarjeta: ");
                useradd.cardnumber = Console.ReadLine();
                Console.Write("\n                                 > Contraseña: ");
                useradd.Password = Console.ReadLine();
                Console.Write("\n                                 > Saldo inicial: ");
                saldo_ = Convert.ToDouble(Console.ReadLine());
                useradd.balance = saldo_;
                useradd.Status = "Activo";
                usuariocliente.Add(useradd);

                transaccion = new Transacciones();
                transaccion.NumeroTarjeta = useradd.cardnumber;
                transaccion.monto_transaccion = saldo_;
                transacciones.Add(transaccion);

                MenuPrincipaladministrador();
            }
            catch (Exception error)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("                             ***        " + error.Message + "       ***");
                Console.WriteLine("                 [Toque cualquier letra para volver al menu de administrador]");
                Console.ReadKey();
                MenuPrincipaladministrador();
            }
        }
        public static void editarcliente()
        {
            try
            {
            inicioeditar:
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Usuario_cliente useredit = new Usuario_cliente();
                Console.WriteLine("\n\n\n\n\n");
                Console.Write("                                       > Introduzca el numero de tarjeta del cliente que desea editar: ");
                string cardnumber = Console.ReadLine();
                if (usuariocliente.Exists(y => y.cardnumber == cardnumber))
                {
                    Usuario_cliente edit = new Usuario_cliente();
                    foreach (Usuario_cliente cliente in usuariocliente)
                    {
                        if (cardnumber == cliente.cardnumber)
                        {
                            Console.WriteLine("\n\n\n");
                            Console.WriteLine("                                 > Nombre: " + cliente.name +
                            "\n                               > Apellido: " + cliente.lastname +
                            "\n                               > Número de tarjeta (####-####-####-####): " + cliente.cardnumber +
                            "\n                               > Estado: " + cliente.Status);
                        }
                    }
                    Console.WriteLine("\n                             ¿Esta es la cuenta que desea editar? ");
                    Console.WriteLine("                                       [1] Si        [2] No");
                    int opc = Convert.ToInt32(Console.ReadLine());
                    switch (opc)
                    {
                        case 1:
                            Console.Clear();
                            foreach (Usuario_cliente cliente in usuariocliente)
                            {
                                if (cardnumber == cliente.cardnumber)
                                {
                                    Console.WriteLine("\n\n\n\n\n");
                                    Console.Write("                > Nuevo nombre del cliente: ");
                                    edit.name = Console.ReadLine();
                                    Console.Write("\n                  > Nuevo apellido del cliente: ");
                                    edit.lastname = Console.ReadLine();
                                    edit.Password = cliente.Password;
                                    edit.Status = cliente.Status;
                                    edit.cardnumber = cliente.cardnumber;
                                    edit.balance = cliente.balance;

                                    usuariocliente.Add(edit);
                                }
                            }
                            break;
                        case 2:
                            Console.Write("\n      ¿Desea hacer otra búsqueda?");
                            Console.WriteLine("  [1] Si              [2] No ");
                            int opc1 = Convert.ToInt32(Console.ReadLine());
                            switch (opc1)
                            {
                                case 1:
                                    editarcliente();
                                    break;
                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("\n\n\n\n\n");
                                    Console.WriteLine("                               [Toque cualquier letra para volver al menu de administrador]");
                                    Console.ReadKey();
                                    MenuPrincipaladministrador();
                                    break;
                            }
                            break;


                    }
                    MenuPrincipaladministrador();
                }
                else
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n\n\n\n\n");
                    Console.WriteLine("                                  *** ESTE NUMERO DE TARJETA NO EXISTE *** ");
                    Console.WriteLine("                      [Para intentar con otro numero de tarjeta presione cualquier boton]");
                    Console.ReadKey();
                    editarcliente();
                }

            }

            catch (Exception error)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("                              ***        " + error.Message + "        ***");
                Console.WriteLine("                         [Toque cualquier letra para volver al menu de administrador]");
                Console.ReadKey();
                MenuPrincipaladministrador();
            }


        }
        public static void eliminarcliente()
        {
            try
            {
            eliminar_c:
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Usuario_cliente delete_client = new Usuario_cliente();
                Console.Write("Número de tarjeta del cliente: ");
                string delete_num_tarjeta = Console.ReadLine();
                if (usuariocliente.Exists(j => j.cardnumber == delete_num_tarjeta))
                {
                    Console.WriteLine("¿Seguro que desea borrar al cliente " + delete_client.name + " " + delete_client.lastname + " del sistema? \nRespuesta 1.Si 2.No");
                    int opcion = int.Parse(Console.ReadLine());
                    switch (opcion)
                    {
                        case 1:
                            usuariocliente.RemoveAll(j => j.cardnumber == delete_num_tarjeta);
                            Console.WriteLine("Toque una tecla para volver al menú principal");
                            Console.ReadKey();
                            MenuPrincipaladministrador();
                            break;
                        case 2:
                            Console.WriteLine("¿Desea eliminar ootro cliente? S/N");
                            char opc = Convert.ToChar(Console.ReadLine());
                            switch (opc)
                            {
                                case 'S':
                                    goto eliminar_c;
                                case 'N':
                                    MenuPrincipaladministrador();
                                    break;
                                default:
                                    Console.WriteLine("Opción no válida... Toque una tecla para continuar.");
                                    Console.ReadKey();
                                    MenuPrincipaladministrador();
                                    break;
                            }
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\n\n");
                    Console.WriteLine("Datos erróneos");
                    Console.WriteLine("Toque para continuar...");
                    Console.ReadKey();
                    goto eliminar_c;
                }

                Console.ReadKey();
            }
            catch (Exception mistake)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\n\n\n\n");
                Console.WriteLine(mistake.Message);
                Console.WriteLine("                      [Toque cualquier letra para volver al menu de administrador]");
                Console.ReadKey();
                MenuPrincipaladministrador();
            }
        }
        public static void cambiarcontraseña()
        {
            try
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Usuario_cliente clientecc = new Usuario_cliente();
                Console.WriteLine("                               > Ingresar el numero de tarjeta del cliente");
                string cardnumber = Console.ReadLine();
                if (usuariocliente.Exists(y => y.cardnumber == cardnumber))
                {
                    Console.Clear();
                    Console.Write("                                > Introduzca la contraseña del cliente");
                    string oldpassword = Console.ReadLine();
                    foreach (Usuario_cliente k in usuariocliente)
                    {
                        if (k.Password == oldpassword)
                        {
                            Console.WriteLine();
                            Console.Write("                        > Por ultimo, ingrese la nueva contraseña");
                            string newpassword = Console.ReadLine();
                            clientecc.Password = newpassword;
                            if (clientecc.Password != k.Password)
                            {
                                clientecc.Password = newpassword;
                                MenuPrincipaladministrador();
                            }
                            else
                            {
                                Console.WriteLine("Intente que su nueva contraseña no sea parecida a la anterior\n" +
                                "Pulse cualquier boton para reintentar");
                                Console.ReadKey();
                                cambiarcontraseña();
                            }
                        }
                    }

                }
            }
            catch (Exception error)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("                            ***         " + error.Message + "        ***");
                Console.WriteLine("                            [Toque para volver al inicio del formulario]");
                Console.ReadKey();
                MenuPrincipaladministrador();
            }
        }
        public static void Agregarsaldo()
        {
            try
            {
            agregando_saldo:
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Usuario_cliente saldo = new Usuario_cliente();
                Console.Write("                        > Número de tarjeta del cliente: ");
                string tarjeta = Console.ReadLine();
                if (usuariocliente.Exists(x => x.cardnumber == tarjeta))
                {
                    Console.Write("                    > Saldo a agregar: ");
                    double saldo_ = Convert.ToDouble(Console.ReadLine());
                    saldo.balance = saldo.balance + saldo_;
                    Console.WriteLine("\n                          [Toque una tecla para volver al menú de administrador]");
                    Console.ReadKey();
                    MenuPrincipaladministrador();
                }
                else
                {
                    Console.WriteLine("Número de tarjeta no existente.");
                    Console.Write("¿Desea introducir un nuevo número de tarjeta? S/N");
                    char opcion = Convert.ToChar(Console.ReadLine());
                    switch (opcion)
                    {
                        case 'S':
                            goto agregando_saldo;
                        case 'N':
                            MenuPrincipaladministrador();
                            break;
                        default:
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("opcion no valida. Toque una tecla para salir...");
                            Console.ReadKey();
                            MenuPrincipaladministrador();
                            break;
                    }
                }
            }
            catch (Exception mistake)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("                                            ***    " + mistake.Message + "   ***");
                Console.WriteLine("                                         [Toque para volver al menu de administrador]");
                Console.ReadKey();
                MenuPrincipaladministrador();
            }
        }
        public static void log()
        {
            try
            {
            transacciones:
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Número de tarjeta del cliente:");
                string tarjeta_transaccion = Console.ReadLine();
                if (usuariocliente.Exists(x => x.cardnumber == tarjeta_transaccion))
                {
                    foreach (Transacciones list in transacciones)
                    {
                        if (tarjeta_transaccion == list.NumeroTarjeta)
                        {
                            Console.WriteLine("\n | Numero de tarjeta:" + list.NumeroTarjeta + "         |");
                            Console.WriteLine("\n | Tipo de transaccion:" + list.TipoTransaccion + "     |");
                            Console.WriteLine("\n | Monto de transaccion:" + list.monto_transaccion + "  |");
                            Console.WriteLine("\n | Balance anterior:" + list.balance_anterior + "       |");
                            Console.WriteLine("\n | Nuevo balance:" + list.balance_nuevo + "             |");
                            Console.WriteLine("    | ___________________________________________________ |");
                        }
                    }
                    Console.ReadKey();
                    MenuPrincipaladministrador();
                }
            }
            catch (Exception error)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("                                                    ***    " + error.Message + "   ***");
                Console.WriteLine("                                                  [Toque para volver al menu de administrador]");
                Console.ReadKey();
                MenuPrincipaladministrador();
            }
        }
        public static void configATM()
        {
            try
            {
            config:
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("                  ________________________________________________________________________________");
                Console.WriteLine("                 |                                                                                 |");
                Console.WriteLine("                 |                              Configuración ATM                                  |");
                Console.WriteLine("                 | _______________________________________________________________________________ |");
                Console.WriteLine("                          \n Elija una opción");
                Console.WriteLine("                                     |  [1]Cambiar nombre del banco      |");
                Console.WriteLine("                                     | [2]Cambiar modo de dispensación   |");
                Console.WriteLine("                                     | [3]Volver Atrás                   |");
                Console.WriteLine("                                     | _________________________________ |");
                Console.Write("\n                   > ");
                int opciones_config = int.Parse(Console.ReadLine());
                switch (opciones_config)
                {
                    case 1:
                        Change_bank_name();
                        break;
                    case 2:
                        modo_dispensacion();
                        break;
                    case 3:
                        MenuPrincipaladministrador();
                        break;
                    default:
                        Console.WriteLine("Opción no válida, elija una opción válida.");
                        Console.WriteLine("Toque una tecla para continuar...");
                        Console.ReadKey();
                        goto config;
                }
            }
            catch (Exception mistake)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("                       ***        " + mistake.Message + "        ***");
                Console.WriteLine("                     [Toque cualquier letra para volver al menu de administrador]");
                Console.ReadKey();
                MenuPrincipaladministrador();
            }
        }
        public static void Administracionusuarios()
        {
            try
            {
            administrar_usuarios:
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("                      > Elija una opción\n");
                Console.WriteLine("                             |     [1]Agregar Usuario Administrador    |");
                Console.WriteLine("                             |     [2]Editar Usuario Administrador     |");
                Console.WriteLine("                             |     [3]Borrar Usuario Administrador     |");
                Console.WriteLine("                             |     [4]Listar Usuarios Administradores  |");
                Console.WriteLine("                             | _______________________________________ |");
                int opcionesadmin = int.Parse(Console.ReadLine());
                switch (opcionesadmin)
                {
                    case 1:
                        add_user_admin();
                        break;
                    case 2:
                        edit_user_admin();
                        break;
                    case 3:
                        delete_user_admin();
                        break;
                    case 4:
                        list_user_admin();
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Elija una opción válida.");
                        Console.WriteLine("Toque una tecla para continuar...");
                        Console.ReadKey();
                        goto administrar_usuarios;
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                Console.WriteLine("Toque para volver al menu de administrador");
                Console.ReadKey();
                MenuPrincipaladministrador();
            }
        }
        public static void reactivarusuario()
        {
            try
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.Write("Introduzca el numero de tarjeta de la cuenta: ");
                string card_ = Console.ReadLine();
                if (usuariocliente.Exists(x => x.cardnumber == card_))
                {
                    Usuario_cliente edit = new Usuario_cliente();
                    foreach (Usuario_cliente cliente in usuariocliente)
                    {
                        if (card_ == cliente.cardnumber)
                        {
                            Console.WriteLine("\n\n\n");
                            Console.WriteLine("                                 > Nombre: " + cliente.name +
                            "\n                               > Apellido: " + cliente.lastname +
                            "\n                               > Número de tarjeta (####-####-####-####): " + cliente.cardnumber);

                        }
                    }
                    Console.WriteLine("¿Esta es la cuenta que desea reactivar?");
                    Console.WriteLine("         [1] Si          [2] No");
                    int choose2 = Convert.ToInt32(Console.ReadLine());
                    switch (choose2)
                    {
                        case 1:
                            foreach (Usuario_cliente cliente in usuariocliente)
                            {

                                if (card_ == cliente.cardnumber)
                                {
                                    if (cliente.Status == "Activo")
                                    {
                                        Console.Clear();
                                        Console.WriteLine("             [ Lo sentimos, la cuenta que ha ingresado se encuentra actualmente activa ]");
                                        Console.WriteLine("\n\n                        ¿Desea ingresar otro numero de tarjeta?");
                                        Console.WriteLine("                                     [1] Si          [2] No ");
                                        int choose3 = Convert.ToInt32(Console.ReadLine());
                                        switch (choose3)
                                        {
                                            case 1:
                                                reactivarusuario();
                                                break;
                                            case 2:
                                                MenuPrincipaladministrador();
                                                break;
                                        }

                                    }
                                    if (cliente.Status == "Inactivo")
                                    {
                                        Usuario_cliente reactivar = new Usuario_cliente();
                                        Console.WriteLine("                             Escoja una opcion:");
                                        Console.WriteLine("\n       [1] Ingresar nueva contraseña   [2] Mantener contraseña anterior");
                                        int choose4 = Convert.ToInt32(Console.ReadLine());
                                        switch (choose4)
                                        {
                                            case 1:
                                                Console.Clear();
                                                Console.WriteLine("\n\n\n\n\n");
                                                Console.Write("                                    > Digite la nueva contraseña: ");
                                                string newpassword = Console.ReadLine();
                                                if (newpassword != cliente.Password)
                                                {
                                                    cliente.Password = newpassword;
                                                    cliente.Status = "Activo";
                                                    cliente.name = cliente.name;
                                                    cliente.lastname = cliente.lastname;
                                                    cliente.cardnumber = cliente.cardnumber;
                                                    cliente.balance = cliente.balance;

                                                    usuariocliente.Add(cliente);
                                                    Console.WriteLine("\n\n          Se ha reactivado el usuario y cambiado la contraseña exitosamente");
                                                    Console.WriteLine("                  [ Toque cualquier letra para ir al menu de clientes ]");
                                                    Console.ReadKey();
                                                    MenuPrincipalCliente();
                                                }
                                                else
                                                {
                                                    Console.WriteLine("            La nueva contraseña no puede ser la misma que la anterior...");
                                                    Console.WriteLine("         [ Presione cualquier letra para volver al inicio del formulario ]");
                                                    Console.ReadKey();
                                                    reactivarusuario();
                                                }
                                                break;
                                            case 2:
                                                cliente.Password = cliente.Password;
                                                cliente.Status = "Activo";
                                                cliente.name = cliente.name;
                                                cliente.lastname = cliente.lastname;
                                                cliente.cardnumber = cliente.cardnumber;
                                                cliente.balance = cliente.balance;
                                                break;
                                        }


                                    }


                                }

                            }
                            break;
                        case 2:
                            Console.WriteLine("¿Desea ingresar otro numero de tarjeta?");
                            Console.WriteLine("       [1] Si          [2] No         ");
                            int choose5 = Convert.ToInt32(Console.ReadLine());
                            switch (choose5)
                            {
                                case 1:
                                    reactivarusuario();
                                    break;
                                case 2:
                                    MenuPrincipaladministrador();
                                    break;
                            }
                            break;
                    }

                }
            }
            catch (Exception mistake)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("                                           ***    " + mistake.Message + "   ***");
                Console.WriteLine("                                       [Toque para volver al menu de administrador]");
                Console.ReadKey();
                MenuPrincipaladministrador();
            }
        }
        public static void cerrarseccion()
        {
            try
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\n\n\n\n");
                Console.Write("                                            ¿Esta seguro que desea cerrar sección?");
                Console.WriteLine("                                                                                            [1] Si      [2] No          ");
                Console.Write("\n                                          >");
                int respuesta = int.Parse(Console.ReadLine());
                switch (respuesta)
                {
                    case 1:
                        LoginAdmin();
                        break;
                    case 2:
                        MenuPrincipaladministrador();
                        break;
                    default:
                        Console.WriteLine("Opción no válida... Toque una tecla para continuar");
                        Console.ReadKey();
                        Console.Clear();
                        cerrarseccion();
                        break;
                }
                Console.ReadKey();
                MenuPrincipaladministrador();
            }
            catch (Exception error)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("                                   ***  " + error.Message + "  ***");
                Console.WriteLine("                             [toque para volver al menu de administrador]");
                Console.ReadKey();
                MenuPrincipaladministrador();
            }
        }
        public enum adminmenu
        {
            adclient = 1,
            editclient,
            deleteclient,
            changepassword,
            saldo,
            showlog,
            configuracionATM,
            adminusers,
            reactiveusers,
            closesection
        }
        public static void add_user_admin()
        {
            try
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Menu_Admin addadmin = new Menu_Admin();
                Console.WriteLine("\n\n\n\n\n");
                Console.Write("\n                                >  Número de tarjeta: ");
                addadmin.cardnumber = Console.ReadLine();
                Console.Write("\n                                >  Nombre:");
                addadmin.name = Console.ReadLine();
                Console.Write("\n                                >  Apellido: ");
                addadmin.lastname = Console.ReadLine();
                Console.Write("\n                                >  Contraseña: ");
                addadmin.Password = Console.ReadLine();
                usuarioadmin.Add(addadmin);

                Console.WriteLine("\n\n\n            [ Usuario agregado exitosamente, toque cualquier letra para volver al menu principal ]");
                Console.ReadKey();
                MenuPrincipaladministrador();

            }
            catch (Exception mistake)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("                                          ***   " + mistake.Message + "   ***");
                Console.WriteLine("                                [Toque una tecla para volver al menu de admiistrador]");
                Console.ReadKey();
                MenuPrincipaladministrador();
            }
        }
        public static void edit_user_admin()
        {
            try
            {
            editaradmin:
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\n\n\n\n");
                Console.Write("                                 >  Numero de tarjeta del usuario: ");
                string editadmin = Console.ReadLine();
                Menu_Admin edit_admin = new Menu_Admin();
                foreach (Menu_Admin k in usuarioadmin)
                {
                    if (usuarioadmin.Exists(x => x.cardnumber == editadmin))
                    {
                        usuarioadmin.Remove(k);

                        Console.Write("\n                        > Numero de tarjeta: ");
                        edit_admin.cardnumber = Console.ReadLine();
                        Console.Write("\n                        > Nombre: ");
                        edit_admin.name = Console.ReadLine();
                        Console.Write("\n                        > Apellido: ");
                        edit_admin.lastname = Console.ReadLine();
                        Console.Write("\n                        > Contraseña: ");
                        edit_admin.Password = Console.ReadLine();

                        usuarioadmin.Add(edit_admin);
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Usuario editado exitósamente. Toque una tecla para volver al menu principal");
                        Console.ReadKey();
                        MenuPrincipaladministrador();
                    }
                    else
                    {
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\n\n\n\n\n");
                        Console.WriteLine("                               [El número de Telefono es incorrecto. Toque Enter para volver a introducirla]");
                        Console.ReadKey();
                        goto editaradmin;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("                                                        ***  " + ex.Message + "  ***");
                Console.WriteLine("                                                    [Toque una tecla para volver al menu]");
                Console.ReadKey();
                MenuPrincipaladministrador();
            }
        }
        public static void delete_user_admin()
        {
            try
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\n\n\n\n");
                Console.Write("                                                       >  Número de tarjeta: ");
                string delete_admin = Console.ReadLine();
                foreach (Usuario_cliente cliente in usuariocliente)
                {
                    if (delete_admin == cliente.cardnumber)
                    {
                        Console.Clear();
                        Console.WriteLine("\n\n\n");
                        Console.WriteLine("                                 > Nombre: " + cliente.name +
                        "\n                               > Apellido: " + cliente.lastname +
                        "\n                               > Número de tarjeta (####-####-####-####): " + cliente.cardnumber +
                        "\n                               > Estado: " + cliente.Status);
                    }
                }

                Console.WriteLine("_________________________________________________________________________________________________________");
                Console.WriteLine("\n\n                                  ¿Este es el cliente que desea eliminar?");
                Console.WriteLine("                                                [1] Si        [2] No");
                int choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        usuarioadmin.RemoveAll(l => l.cardnumber == delete_admin);
                        Console.WriteLine("Usuario Removido exitosamente.");
                        Console.WriteLine("Toque una tecla para volver al menú principal...");
                        MenuPrincipaladministrador();
                        break;
                    case 2:
                        Console.WriteLine("\n\n                                   ¿Desea realizar otra busqueda?");
                        Console.WriteLine("                                          [1] Si        [2] No");
                        int choose1 = Convert.ToInt32(Console.ReadLine());
                        switch (choose1)
                        {
                            case 1:
                                delete_user_admin();
                                break;
                            case 2:
                                MenuPrincipaladministrador();
                                break;
                        }
                        break;
                }
            }
            catch (Exception error)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("                                     *** Error. " + error.Message + "   ***");
                Console.WriteLine("                                       [toque una tecla para continuar...]");
                Console.ReadKey();
                MenuPrincipaladministrador();
            }
        }
        public static void list_user_admin()
        {
            try
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                if (usuarioadmin.Count == 0)
                {
                    Console.WriteLine("No hay listado de administradores disponibles...");
                    Console.WriteLine("Toque una tecla para continuar...");
                    Console.ReadKey();
                    MenuPrincipaladministrador();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\t\t\tListado De Usuarios Administradores");
                    Console.WriteLine("\t\t\t____________________________________\n");
                    foreach (Menu_Admin x in usuarioadmin)
                    {
                        Console.WriteLine("\n\n\n");
                        Console.WriteLine("| Nombre: " + x.name + "                 |");
                        Console.WriteLine("|                                       |");
                        Console.WriteLine("| Apellido: " + x.lastname + "           |");
                        Console.WriteLine("|                                       |");
                        Console.WriteLine("| Contraseña: " + x.Password + "         |");
                        Console.WriteLine("|                                       |");
                        Console.WriteLine("| Numero de tarjeta: " + x.cardnumber + "|");
                        Console.WriteLine("| _____________________________________ |");
                    }
                    Console.ReadKey();
                    MenuPrincipaladministrador();
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("ERROR " + error.Message);
                Console.WriteLine("Toque una tecla para continuar...");
                Console.ReadKey();
                MenuPrincipaladministrador();
            }
        }
        public static void Change_bank_name()
        {
            try
            {
            changebank:
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\n\n\n\n");
                Console.Write("                                 > Introduzca el nuevo nombre del banco: ");
                bank_name = Console.ReadLine();
                Console.WriteLine("\n\n");
                Console.WriteLine("                            ¿Esta seguro de que desea modificar el nombre del banco?);");
                Console.WriteLine("                                                [1] Si          [2] No");
                int respuesta = Convert.ToInt32(Console.ReadLine());
                switch (respuesta)
                {
                    case 1:
                        Console.WriteLine("\n\n                              [ Nombre del banco asignado exitósamente ]");
                        Console.ReadKey();
                        MenuPrincipaladministrador();
                        break;
                    case 2:
                        Console.WriteLine("\n\n                              [ Toque una tecla para salir... ]");
                        Console.ReadKey();
                        MenuPrincipaladministrador();
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Toque una tecla para continuar...");
                        Console.ReadKey();
                        goto changebank;

                }
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("                                               ***  " + ex.Message + "  ***");
                Console.WriteLine("                                           [ Toque una tecla para continuar... ]");
                Console.ReadKey();
                MenuPrincipaladministrador();
            }
        }
        public static void modo_dispensacion()
        {
            try
            {
            mod_disp:
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("        __________________________________________________________________");
                Console.WriteLine("       |                                                                  |");
                Console.WriteLine("       |               Seleccione el modo de dispensación                 |");
                Console.WriteLine("       | ________________________________________________________________ |\n");
                Console.WriteLine("\n\n\n");
                Console.WriteLine("                            [1]    200 y 1,000");
                Console.WriteLine("\n                           [2]    100 y 500");
                Console.WriteLine("\n                           [3]    Menor cantidad de billetes posible (100, 200, 500, 1000)");
                int resp = int.Parse(Console.ReadLine());
                switch (resp)
                {
                    case 1:
                        bank_ = 200;
                        bank_2 = 1000;

                        Console.WriteLine("\n\n                       [ Toque una tecla para continuar... ]");
                        Console.ReadKey();
                        MenuPrincipaladministrador();

                        break;
                    case 2:
                        bank_ = 100;
                        bank_2 = 500;

                        Console.WriteLine("\n\n                       [ Toque una tecla para continuar... ]");
                        Console.ReadKey();
                        MenuPrincipaladministrador();
                        break;
                    case 3:
                        bank_ = 100;
                        bank_2 = 200;
                        bank_3 = 500;
                        bank_4 = 1000;

                        Console.WriteLine("\n\n                        [ Toque una tecla para continuar... ]");
                        Console.ReadKey();
                        MenuPrincipaladministrador();
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Elija una opción válida.");
                        Console.WriteLine("[ Toque una tecla para continuar... ]");
                        Console.ReadKey();
                        goto mod_disp;

                }
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("                              *** " + ex.Message + "  ***");
                Console.WriteLine("                          [ Toque una tecla para continuar... ]");
                Console.ReadKey();
                MenuPrincipaladministrador();
            }
        }
        public static void reactivar_contraseña()
        {
            try
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Introduzca el numero de tarjeta de la cuenta: ");
                string card_ = Console.ReadLine();
                if (usuariocliente.Exists(x => x.cardnumber == card_))
                {
                    Usuario_cliente edit = new Usuario_cliente();
                    foreach (Usuario_cliente cliente in usuariocliente)
                    {
                        if (card_ == cliente.cardnumber)
                        {
                            Console.WriteLine("\n\n\n");
                            Console.WriteLine("                                 > Nombre: " + cliente.name +
                            "\n                               > Apellido: " + cliente.lastname +
                            "\n                               > Número de tarjeta (####-####-####-####): " + cliente.cardnumber);

                        }
                    }
                    Console.WriteLine("¿Esta es la cuenta cuya contraseña desea reactivar?");
                    Console.WriteLine("         [1] Si          [2] No");
                    int opcion = Convert.ToInt32(Console.ReadLine());
                    switch (opcion)
                    {
                        case 1:
                            foreach (Usuario_cliente cliente in usuariocliente)
                            {

                                if (card_ == cliente.cardnumber)
                                {
                                    if (cliente.Status == "Activa")
                                    {
                                        Console.Clear();
                                        Console.WriteLine("\n\n\n\n\n");
                                        Console.Write("                                    > Digite la nueva contraseña: ");
                                        string new_password = Console.ReadLine();
                                        if (new_password != cliente.Password)
                                        {
                                            cliente.Password = new_password;

                                            cliente.Status = "Activo";
                                            cliente.name = cliente.name;
                                            cliente.lastname = cliente.lastname;
                                            cliente.cardnumber = cliente.cardnumber;
                                            cliente.balance = cliente.balance;

                                            usuariocliente.Add(cliente);
                                            Console.WriteLine("                     Se ha reactivado la contraseña de manera exitosa");
                                            Console.WriteLine("                  [ Toque cualquier letra para ir al menu de clientes ]");
                                            Console.ReadKey();
                                            MenuPrincipalCliente();
                                        }

                                    }
                                    if (cliente.Status == "Inactivo")
                                    {
                                        Usuario_cliente reactivar = new Usuario_cliente();
                                        Console.WriteLine("Esta cuenta se encuentra inactiva, desea reactivarla?");
                                        int choose4 = Convert.ToInt32(Console.ReadLine());
                                        switch (choose4)
                                        {
                                            case 1:
                                                Console.Clear();
                                                Console.WriteLine("\n\n\n\n\n");
                                                Console.Write("                                    > Digite la nueva contraseña: ");
                                                string newpassword = Console.ReadLine();
                                                if (newpassword != cliente.Password)
                                                {
                                                    cliente.Password = newpassword;
                                                    cliente.Status = "Activo";
                                                    cliente.name = cliente.name;
                                                    cliente.lastname = cliente.lastname;
                                                    cliente.cardnumber = cliente.cardnumber;
                                                    cliente.balance = cliente.balance;

                                                    usuariocliente.Add(cliente);
                                                    Console.WriteLine("\n\n          Se ha reactivado el usuario y la contraseña exitosamente");
                                                    Console.WriteLine("                  [ Toque cualquier letra para ir al menu de clientes ]");
                                                    Console.ReadKey();
                                                    MenuPrincipalCliente();
                                                }
                                                else
                                                {
                                                    Console.WriteLine("            La nueva contraseña no puede ser la misma que la anterior...");
                                                    Console.WriteLine("         [ Presione cualquier letra para volver al inicio del formulario ]");
                                                    Console.ReadKey();
                                                    reactivarusuario();
                                                }
                                                break;
                                            case 2:
                                                cliente.Password = cliente.Password;
                                                cliente.Status = "Activo";
                                                cliente.name = cliente.name;
                                                cliente.lastname = cliente.lastname;
                                                cliente.cardnumber = cliente.cardnumber;
                                                cliente.balance = cliente.balance;
                                                break;
                                        }
                                    }
                                }
                            }
                            break;
                        case 2:
                            Console.WriteLine("\n\n                        ¿Desea ingresar otro numero de tarjeta?");
                            Console.WriteLine("                                     [1] Si          [2] No ");
                            int choose3 = Convert.ToInt32(Console.ReadLine());
                            switch (choose3)
                            {
                                case 1:
                                    reactivarusuario();
                                    break;
                                case 2:
                                    MenuPrincipaladministrador();
                                    break;
                            }
                            break;
                    }

                }
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(ex.Message);
                Console.WriteLine("Toque una tecla para continuar...");
                Console.ReadKey();
                MenuPrincipaladministrador();
            }

        }
        /*Metodos para el menu principal del cliente*/
        public static void MenuPrincipalCliente()
        {
            try
            {
            Iniciomenucliente:
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("                    ________________________________________________________________");
                Console.WriteLine("                   |                                                                |");
                Console.WriteLine("                   |                      Banco " + bank_name + "                                 |");
                Console.WriteLine("                   |                  Menu  Principal de Cliente                    |");
                Console.WriteLine("                   |                       " + DateTime.Now + "                   |");
                Console.WriteLine("                   |________________________________________________________________|\n");
                Console.Write("> Elija la opción deseada: \n");
                Console.WriteLine("\n    |   1. Retirar Efectivo                    |");
                Console.WriteLine("      |  2. Depositar Efectivo                   |");
                Console.WriteLine("      |  3. Comprar tarjeta de llamada           |");
                Console.WriteLine("      |  4. Consultar Balance                    |");
                Console.WriteLine("      |  5. Salir                                |");
                Console.WriteLine("      | ________________________________________ |");
                int respuesta = int.Parse(Console.ReadLine());
                switch (respuesta)
                {
                    case (int)menuclient.retirar_efectivo:
                        Retirar_efectivo();
                        break;
                    case (int)menuclient.depositar_efectivo:
                        Depositar_Efectivo();
                        break;
                    case (int)menuclient.comprar_tarjeta:
                        Comprar_tarjeta_llamada();
                        break;
                    case (int)menuclient.consultar_balance:
                        Consultar_balance();
                        break;
                    case (int)menuclient.salir:
                        salir();
                        break;
                    default:
                        Console.WriteLine("                       Opción no válida. Elija una opción válida...");
                        Console.WriteLine("                          [ Toque una tecla para continuar... ]");
                        Console.ReadKey();
                        goto Iniciomenucliente;

                }
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("                          ***  " + ex.Message + "  ***");
                Console.WriteLine("                      [ Presione una tecla para continuar... ]");
                Console.ReadKey();
                MenuPrincipalCliente();
            }
        }
        public static void Retirar_efectivo()
        {
            try
            {
            dispensacion:
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Monto a retirar: ");
                monto = double.Parse(Console.ReadLine());

                if (bank_ == 200 && bank_2 == 1000)
                {
                    saldo.balance = saldo_;
                    if (saldo.balance >= monto)
                    {
                        if (monto % 1000 == 0 || monto % 200 == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("                                         {~~~~~~~Dispensacion de " + bank_ + " y " + bank_2 + "~~~~~~~~}\n");
                            if ((monto >= 1000))
                            {
                                c1000 = (int)monto / 1000;
                                monto = monto % 1000;
                                Console.WriteLine("Billetes de 1,000 retirados: " + c1000);
                            }

                            if ((monto >= 200))
                            {
                                c200 = (int)monto / 200;
                                monto = monto % 200;
                                Console.WriteLine("Billetes de 200 retirados: " + c200);
                            }
                            Console.WriteLine("\n\n                                     [ Toque una tecla salir... ]");
                            Console.ReadKey();
                            MenuPrincipalCliente();
                        }
                        else
                        {
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("\n\n El cajero no puede dispensar dinero en estas cantidades. Solo dispensa billetes de 200 y 1000 ");
                            Console.WriteLine("                               [ Toque una tecla para continuar... ]");
                            Console.ReadKey();
                            goto dispensacion;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Usted no cuenta con suficiente balance para hacer el retiro...");
                        Console.WriteLine("¿Desea Ingresar otro monto?  Si/No");
                        Console.Write("\n   > ");
                        string volver = Console.ReadLine();
                        switch (volver.ToLower())
                        {
                            case "Si":
                                goto dispensacion;
                            case "No":
                                MenuPrincipalCliente();
                                break;
                        }
                    }
                }

                if (bank_ == 100 && bank_2 == 500)
                {
                    if (saldo.balance >= monto)
                    {
                        if (monto % 500 == 0 || monto % 100 == 0)
                        {
                            Console.WriteLine("                                         {~~~~~~~Dispensacion de " + bank_ + " y " + bank_2 + "~~~~~~~~}\n");
                            if (monto >= 500)
                            {
                                c500 = (int)monto / 500;
                                monto = monto % 500;
                                Console.WriteLine("Billetes de 500 retirados: " + c500);
                            }
                            if ((monto >= 100))
                            {
                                c100 = (int)monto / 100;
                                monto = monto % 100;
                                Console.WriteLine("Billetes de 100 retirados: " + c100);
                            }
                        }
                        else
                        {
                            Console.WriteLine("El cajero no puede dispensar dinero en estas cantidades. Introduzca el monto adecuado");
                            Console.WriteLine("Toque una tecla para continuar...");
                            Console.ReadKey();
                            goto dispensacion;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Usted no cuenta con suficiente balance para hacer el retiro...");
                        Console.WriteLine("¿Desea Ingresar otro monto?  Si/No");
                        string volver = Console.ReadLine();
                        switch (volver.ToLower())
                        {
                            case "Si":
                                goto dispensacion;
                            case "No":
                                MenuPrincipalCliente();
                                break;
                        }
                    }
                }

                if (bank_ == 100 && bank_2 == 200 && bank_3 == 500 && bank_4 == 1000)
                {
                    if (saldo.balance >= monto)
                    {
                        if (monto % 1000 == 0 || monto % 500 == 0 || monto % 200 == 0 || monto % 100 == 0)
                        {
                            Console.WriteLine("                                         {~~~~~~~Dispensacion de " + bank_ + "," + bank_2 + "," + bank_3 + " y " + bank_4 + "~~~~~~~~}\n");
                            if (monto >= 1000)
                            {
                                c1000 = (int)monto / 1000;
                                monto = (monto % 1000);
                                Console.WriteLine("Billetes de 1,000 retirados: " + c1000);

                            }
                            if (monto >= 500)
                            {
                                c500 = (int)monto / 500;
                                monto = (monto % 500);
                                Console.WriteLine("Billetes de 500 retirados: " + c500);
                            }
                            if (monto >= 200)
                            {
                                c200 = (int)monto / 200;
                                monto = (monto % 200);
                                Console.WriteLine("Billetes de 200 retirados: " + c200);
                            }
                            if (monto >= 100)
                            {
                                c100 = (int)monto / 100;
                                monto = (monto % 100);
                                Console.WriteLine("Billetes de 100 retirados: " + c100);
                            }

                        }
                        else
                        {
                            Console.WriteLine("El cajero no puede dispensar dinero en estas cantidades. Introduzca el monto adecuado");
                            Console.WriteLine("                          [ Toque una tecla para continuar... ]");
                            Console.ReadKey();
                            goto dispensacion;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Usted no cuenta con suficiente balance para hacer el retiro...");
                        Console.WriteLine("             ¿Desea Ingresar otro monto?  Si/No");
                        string volver = Console.ReadLine();
                        switch (volver.ToLower())
                        {
                            case "Si":
                                goto dispensacion;
                            case "No":
                                MenuPrincipalCliente();
                                break;
                        }
                    }

                    Console.ReadKey();

                    Console.WriteLine("\n                     Procedimiento realizado exitósamente...");
                    Console.WriteLine("                         [ Toque una tecla para continuar... ]");
                    Console.ReadKey();
                    MenuPrincipalCliente();

                }
                else
                {
                    Console.WriteLine("                 No hay modo de dispensación asignado para hacer el retiro...");
                    Console.WriteLine("                             [ Toque una tecla para salir... ]");
                    Console.ReadKey();
                    MenuPrincipalCliente();
                }
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("                                      ***  " + ex.Message + "  ***");
                Console.WriteLine("                                  [ Toque una tecla para continuar... ]");
                Console.ReadKey();
                MenuPrincipalCliente();
            }
        }
        public static void Depositar_Efectivo()
        {
            try
            {
            deposito:
                Console.Clear();
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("                                      _______________________________________________________");
                Console.WriteLine("                                     |                                                       |");
                Console.WriteLine("                                     |                    Transacciones                      |");
                Console.WriteLine("                                     | _____________________________________________________ |\n");
                Console.Write("\n                     > Cantidad a depositar: ");
                double cantidad = Convert.ToDouble(Console.ReadLine());

                if (usuariocliente.Exists(t => t.cardnumber == card))
                {
                    if (cantidad >= 100)
                    {
                        if (cantidad % 100 == 0 || cantidad % 200 == 0 || cantidad % 500 == 0 || cantidad % 1000 == 0)
                        {
                            balance = new Transacciones();
                            if (balance.balance_anterior == 0)
                            {
                                balance.balance_anterior = 0;
                                balance.balance_nuevo = balance.balance_anterior + cantidad;
                                balance.balance_anterior = balance.balance_nuevo - cantidad;

                                Console.WriteLine("                                  ~~~~~~Banco " + bank_name + "~~~~~~\n");
                                Console.WriteLine();
                                Console.WriteLine("                                 Fecha del depósito: " + DateTime.Now);
                                Console.WriteLine("                                 Balance Anterior : " + balance.balance_anterior);
                                Console.WriteLine("                                 Balance Actual: " + balance.balance_nuevo);
                                transacciones.Add(balance);
                            }
                            else
                            {
                                balance = new Transacciones();
                                balance.balance_nuevo = balance.balance_anterior + cantidad;
                                balance.balance_anterior = balance.balance_nuevo - cantidad;
                                Console.WriteLine("                                  ~~~~~~Banco " + bank_name + "~~~~~~\n");

                                Console.WriteLine();
                                Console.WriteLine("                                  Balance Anterior : " + balance.balance_anterior);
                                Console.WriteLine("                                  Balance Actual: " + balance.balance_nuevo);
                                transacciones.Add(balance);
                            }
                        }
                        else
                        {
                            Console.WriteLine("                 No se puede agregar este monto. Ingrese otra cantidad...");
                            Console.WriteLine("                           [ Toque una tecla para continuar... ]");
                            Console.ReadKey();
                            goto deposito;
                        }
                    }
                    else
                    {
                        Console.WriteLine("                   No se puede agregar este monto. Ingrese otra cantidad...");
                        Console.WriteLine("                               [ Toque una tecla para continuar... ]");
                        Console.ReadKey();
                        goto deposito;
                    }
                }
            }
            catch (Exception mistake)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("                                        ***  " + mistake.Message + "  ***");
                Console.WriteLine("                                       [ Toque una tecla para continuar... ]");
                Console.ReadKey();
                MenuPrincipalCliente();
            }
        }
        public static void Comprar_tarjeta_llamada()
        {
            try
            {
            Comprar_tarjeta:
                Console.Clear();
                Console.WriteLine("                                      _____________________________________________");
                Console.WriteLine("                                     |                                             |");
                Console.WriteLine("                                     |                Comprar Tarjeta              |");
                Console.WriteLine("                                     | ___________________________________________ |\n");
                Console.WriteLine("\n > Elija la compañia de la tarjeta que desea comprar:");
                Console.WriteLine("\n                                            |        [1]Altice          |");
                Console.WriteLine("                                            |                           |");
                Console.WriteLine("                                            |        [2]Claro           |");
                Console.WriteLine("                                            |                           |");
                Console.WriteLine("                                            |        [3]Viva            |");
                Console.WriteLine("                                            | _________________________ |");
                int opcion_tarjeta = int.Parse(Console.ReadLine());
                switch (opcion_tarjeta)
                {
                    case 1:
                        comprar_tarjeta_altice();
                        break;
                    case 2:
                        comprar_tarjeta_claro();
                        break;
                    case 3:
                        comprar_tarjeta_Viva();
                        break;
                    default:
                        Console.WriteLine("                                Opción no válida... Elija 1, 2 o 3 ");
                        Console.WriteLine("                                 [ Toque una tecla para continuar... ]");
                        Console.ReadKey();
                        goto Comprar_tarjeta;

                }
            }
            catch (Exception error)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("                                              ***  " + error.Message + "  ***");
                Console.WriteLine("                                           [ Toque una tecla para continuar... ]");
                Console.ReadKey();
                MenuPrincipalCliente();
            }
        }
        public static void Consultar_balance()
        {
            try
            {
                if (transacciones.Exists(x => x.NumeroTarjeta == card))
                {
                    Console.WriteLine("                                        Banco " + bank_name);
                    foreach (Usuario_cliente j in usuariocliente)
                    {
                        Console.WriteLine("                               \nCliente: " + j.name + " " + j.lastname);
                        foreach (Transacciones t in transacciones)
                        {
                            Console.WriteLine("                                  Balance: " + t.balance_nuevo);
                        }
                    }
                }
                Console.WriteLine("                             [ Toque una tecla para continuar... ]");
                Console.ReadKey();
                MenuPrincipalCliente();
            }
            catch (Exception mistake)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("                                  ***  " + mistake.Message + "  ***");
                Console.WriteLine("                                   [ Toque una tecla para continuar... ]");
                Console.ReadKey();
                MenuPrincipalCliente();
            }
        }
        public static void comprar_tarjeta_altice()
        {
            try
            {
            altice:
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("                    ____________________________________________________________");
                Console.WriteLine("                   |                                                            |");
                Console.WriteLine("                   |                        Compañía ALTICE                     |");
                Console.WriteLine("                   |     Seleccione el monto de la tarjeta que desea comprar    |");
                Console.WriteLine("                   | __________________________________________________________ |\n");
                Console.WriteLine("\n[1]. 60           [2]. 100          [3]. 150          [4]. 200          [5]. 250");
                int opcion = int.Parse(Console.ReadLine());
                Transacciones trans_ = new Transacciones();
                if (saldo.balance < 60)
                {
                    Console.WriteLine("                    Usted no cuenta con suficiente balance para realizar la compra.");
                    Console.WriteLine("                                   [ Toque una tecla para continuar... ]");
                    Console.ReadKey();
                    MenuPrincipalCliente();
                }
                else
                {
                    switch (opcion)
                    {
                        case 1:
                            if (saldo.balance >= 60)
                            {
                                trans_.monto_transaccion = 60;
                                trans_.balance_nuevo = saldo.balance - trans_.monto_transaccion;

                                Console.WriteLine("Banco " + bank_name);
                                Console.WriteLine("\nCompañia Telefónica: " + "Altice");
                                Console.WriteLine("Monto de la tarjeta: " + trans_.monto_transaccion);
                                Console.WriteLine("Balance Anterior: " + saldo.balance);
                                Console.WriteLine("Balance Actual: " + trans_.balance_nuevo);

                                transacciones.Add(trans_);
                                Console.WriteLine("\n          [ Toque una tecla para continuar... ]");
                                Console.ReadKey();
                                MenuPrincipalCliente();
                            }

                            break;
                        case 2:
                            if (saldo.balance >= 100)
                            {
                                trans_.monto_transaccion = 100;
                                trans_.balance_nuevo = saldo.balance - trans_.monto_transaccion;

                                Console.WriteLine("Banco " + bank_name);
                                Console.WriteLine("\nCompañia Telefónica: " + "Altice");
                                Console.WriteLine("Monto de la tarjeta: " + "100");
                                Console.WriteLine("Balance Anterior: " + saldo.balance);
                                Console.WriteLine("Balance Actual: " + trans_.balance_nuevo);

                                transacciones.Add(trans_);
                                Console.WriteLine("\n            [ Toque una tecla para continuar... ]");
                                Console.ReadKey();
                                MenuPrincipalCliente();
                            }

                            break;
                        case 3:
                            if (saldo.balance >= 150)
                            {
                                trans_.monto_transaccion = 150;
                                trans_.balance_nuevo = saldo.balance - trans_.monto_transaccion;

                                Console.WriteLine("Banco " + bank_name);
                                Console.WriteLine("\nCompañia Telefónica: " + "Altice");
                                Console.WriteLine("Monto de la tarjeta: " + "150");
                                Console.WriteLine("Balance Anterior: " + saldo.balance);
                                Console.WriteLine("Balance Actual: " + trans_.balance_nuevo);

                                transacciones.Add(trans_);
                                Console.WriteLine("\n             [ Toque una tecla para continuar... ]");
                                Console.ReadKey();
                                MenuPrincipalCliente();
                            }
                            break;
                        case 4:
                            if (saldo.balance >= 200)
                            {
                                trans_.monto_transaccion = 200;
                                trans_.balance_nuevo = saldo.balance - trans_.monto_transaccion;

                                Console.WriteLine("Banco " + bank_name);
                                Console.WriteLine("\nCompañia Telefónica: " + "Altice");
                                Console.WriteLine("Monto de la tarjeta: " + "200");
                                Console.WriteLine("Balance Anterior: " + saldo.balance);
                                Console.WriteLine("Balance Actual: " + trans_.balance_nuevo);

                                transacciones.Add(trans_);
                                Console.WriteLine("\n             [ Toque una tecla para continuar... ]");
                                Console.ReadKey();
                                MenuPrincipalCliente();
                            }
                            break;
                        case 5:
                            if (saldo.balance >= 250)
                            {
                                trans_.monto_transaccion = 250;
                                trans_.balance_nuevo = saldo.balance - trans_.monto_transaccion;

                                Console.WriteLine("Banco " + bank_name);
                                Console.WriteLine("\nCompañia Telefónica: " + "Altice");
                                Console.WriteLine("Monto de la tarjeta: " + "250");
                                Console.WriteLine("Balance Anterior: " + saldo.balance);
                                Console.WriteLine("Balance Actual: " + trans_.balance_nuevo);

                                transacciones.Add(trans_);
                                Console.WriteLine("\n             [ Toque una tecla para continuar... ]");
                                Console.ReadKey();
                                MenuPrincipalCliente();
                            }
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Elija una una opción válida");
                            Console.WriteLine("\n             [ Toque una tecla para continuar... ]");
                            Console.ReadKey();
                            goto altice;

                    }
                }
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("                                             Error. " + ex);
                Console.WriteLine("\n                                [ Toque una tecla para continuar... ]");
                Console.ReadKey();
                MenuPrincipalCliente();
            }
        }
        public static void comprar_tarjeta_claro()
        {
            try
            {
            claro:
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("                    ____________________________________________________________");
                Console.WriteLine("                   |                                                            |");
                Console.WriteLine("                   |                        Compañía CLARO                      |");
                Console.WriteLine("                   |     Seleccione el monto de la tarjeta que desea comprar    |");
                Console.WriteLine("                   | __________________________________________________________ |\n");
                Console.WriteLine("\n[1]. 60           [2]. 100          [3]. 150          [4]. 200          [5]. 250");
                int opcion = int.Parse(Console.ReadLine());
                Transacciones trans_ = new Transacciones();
                if (saldo.balance < 60)
                {
                    Console.WriteLine("                    Usted no cuenta con suficiente balance para realizar la compra de la tarjeta.");
                    Console.WriteLine("\n                                        [ Toque una tecla para continuar... ]");
                    Console.ReadKey();
                    MenuPrincipalCliente();
                }
                else
                {
                    switch (opcion)
                    {
                        case 1:
                            if (saldo.balance >= 60)
                            {
                                trans_.monto_transaccion = 60;
                                trans_.balance_nuevo = saldo.balance - trans_.monto_transaccion;

                                Console.WriteLine("Banco " + bank_name);
                                Console.WriteLine("\nCompañia Telefónica: " + "Claro");
                                Console.WriteLine("Monto de la tarjeta: " + trans_.monto_transaccion);
                                Console.WriteLine("Balance Anterior: " + saldo.balance);
                                Console.WriteLine("Balance Actual: " + trans_.balance_nuevo);

                                transacciones.Add(trans_);
                                Console.WriteLine("\n             [ Toque una tecla para continuar... ]");
                                Console.ReadKey();
                                MenuPrincipalCliente();
                            }

                            break;
                        case 2:
                            if (saldo.balance >= 100)
                            {
                                trans_.monto_transaccion = 100;
                                trans_.balance_nuevo = saldo.balance - trans_.monto_transaccion;

                                Console.WriteLine("Banco " + bank_name);
                                Console.WriteLine("\nCompañia Telefónica: " + "Claro");
                                Console.WriteLine("Monto de la tarjeta: " + "100");
                                Console.WriteLine("Balance Anterior: " + saldo.balance);
                                Console.WriteLine("Balance Actual: " + trans_.balance_nuevo);

                                transacciones.Add(trans_);
                                Console.WriteLine("\n             [ Toque una tecla para continuar... ]");
                                Console.ReadKey();
                                MenuPrincipalCliente();
                            }

                            break;
                        case 3:
                            if (saldo.balance >= 150)
                            {
                                trans_.monto_transaccion = 150;
                                trans_.balance_nuevo = saldo.balance - trans_.monto_transaccion;

                                Console.WriteLine("Banco " + bank_name);
                                Console.WriteLine("\nCompañia Telefónica: " + "Claro");
                                Console.WriteLine("Monto de la tarjeta: " + "150");
                                Console.WriteLine("Balance Anterior: " + saldo.balance);
                                Console.WriteLine("Balance Actual: " + trans_.balance_nuevo);

                                transacciones.Add(trans_);
                                Console.WriteLine("\n             [ Toque una tecla para continuar... ]");
                                Console.ReadKey();
                                MenuPrincipalCliente();
                            }
                            break;
                        case 4:
                            if (saldo.balance >= 200)
                            {
                                trans_.monto_transaccion = 200;
                                trans_.balance_nuevo = saldo.balance - trans_.monto_transaccion;

                                Console.WriteLine("Banco " + bank_name);
                                Console.WriteLine("\nCompañia Telefónica: " + "Claro");
                                Console.WriteLine("Monto de la tarjeta: " + "200");
                                Console.WriteLine("Balance Anterior: " + saldo.balance);
                                Console.WriteLine("Balance Actual: " + trans_.balance_nuevo);
                            }
                            break;
                        case 5:
                            if (saldo.balance >= 250)
                            {
                                trans_.monto_transaccion = 250;
                                trans_.balance_nuevo = saldo.balance - trans_.monto_transaccion;

                                Console.WriteLine("Banco " + bank_name);
                                Console.WriteLine("\nCompañia Telefónica: " + "Claro");
                                Console.WriteLine("Monto de la tarjeta: " + "250");
                                Console.WriteLine("Balance Anterior: " + saldo.balance);
                                Console.WriteLine("Balance Actual: " + trans_.balance_nuevo);

                                transacciones.Add(trans_);
                                Console.WriteLine("\nToque una tecla para continuar...");
                                Console.ReadKey();
                                MenuPrincipalCliente();
                            }
                            break;
                        default:
                            Console.WriteLine("                   Opción no válida. Elija una una opción válida");
                            Console.WriteLine("\n                       [ Toque una tecla para continuar... ]");
                            Console.ReadKey();
                            goto claro;

                    }
                }
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("                                          Error. " + ex);
                Console.WriteLine("                                  [ Toque una tecla para continuar ]");
                Console.ReadKey();
                MenuPrincipalCliente();
            }
        }
        public static void comprar_tarjeta_Viva()
        {
            try
            {
            viva:
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("                    ____________________________________________________________");
                Console.WriteLine("                   |                                                            |");
                Console.WriteLine("                   |                        Compañía VIVA                       |");
                Console.WriteLine("                   |     Seleccione el monto de la tarjeta que desea comprar    |");
                Console.WriteLine("                   | __________________________________________________________ |\n");
                Console.WriteLine("\n[1]. 60           [2]. 100          [3]. 150          [4]. 200          [5]. 250 ");
                int opcion = int.Parse(Console.ReadLine());
                Transacciones trans_ = new Transacciones();
                if (saldo.balance < 60)
                {
                    Console.WriteLine("                    Usted no cuenta con suficiente balance para realizar la compra de la tarjeta.");
                    Console.WriteLine("\n                                        [ Toque una tecla para continuar... ]");
                    Console.ReadKey();
                    MenuPrincipalCliente();
                }
                else
                {
                    switch (opcion)
                    {
                        case 1:
                            if (saldo.balance >= 60)
                            {
                                trans_.monto_transaccion = 60;
                                trans_.balance_nuevo = saldo.balance - trans_.monto_transaccion;

                                Console.WriteLine("Banco " + bank_name);
                                Console.WriteLine("\nCompañia Telefónica: " + "Viva");
                                Console.WriteLine("Monto de la tarjeta: " + trans_.monto_transaccion);
                                Console.WriteLine("Balance Anterior: " + saldo.balance);
                                Console.WriteLine("Balance Actual: " + trans_.balance_nuevo);

                                transacciones.Add(trans_);
                                Console.WriteLine("\n             [ Toque una tecla para continuar... ]");
                                Console.ReadKey();
                                MenuPrincipalCliente();
                            }

                            break;
                        case 2:
                            if (saldo.balance >= 100)
                            {
                                trans_.monto_transaccion = 100;
                                trans_.balance_nuevo = saldo.balance - trans_.monto_transaccion;

                                Console.WriteLine("Banco " + bank_name);
                                Console.WriteLine("\nCompañia Telefónica: " + "Viva");
                                Console.WriteLine("Monto de la tarjeta: " + "100");
                                Console.WriteLine("Balance Anterior: " + saldo.balance);
                                Console.WriteLine("Balance Actual: " + trans_.balance_nuevo);

                                transacciones.Add(trans_);
                                Console.WriteLine("\n             [ Toque una tecla para continuar... ]");
                                Console.ReadKey();
                                MenuPrincipalCliente();
                            }

                            break;
                        case 3:
                            if (saldo.balance >= 150)
                            {
                                trans_.monto_transaccion = 150;
                                trans_.balance_nuevo = saldo.balance - trans_.monto_transaccion;

                                Console.WriteLine("Banco " + bank_name);
                                Console.WriteLine("\nCompañia Telefónica: " + "Viva");
                                Console.WriteLine("Monto de la tarjeta: " + "150");
                                Console.WriteLine("Balance Anterior: " + saldo.balance);
                                Console.WriteLine("Balance Actual: " + trans_.balance_nuevo);

                                transacciones.Add(trans_);
                                Console.WriteLine("\n             [ Toque una tecla para continuar... ]");
                                Console.ReadKey();
                                MenuPrincipalCliente();
                            }
                            break;
                        case 4:
                            if (saldo.balance >= 200)
                            {
                                trans_.monto_transaccion = 200;
                                trans_.balance_nuevo = saldo.balance - trans_.monto_transaccion;

                                Console.WriteLine("Banco " + bank_name);
                                Console.WriteLine("\nCompañia Telefónica: " + "Viva");
                                Console.WriteLine("Monto de la tarjeta: " + "200");
                                Console.WriteLine("Balance Anterior: " + saldo.balance);
                                Console.WriteLine("Balance Actual: " + trans_.balance_nuevo);
                            }
                            break;
                        case 5:
                            if (saldo.balance >= 250)
                            {
                                trans_.monto_transaccion = 250;
                                trans_.balance_nuevo = saldo.balance - trans_.monto_transaccion;

                                Console.WriteLine("Banco " + bank_name);
                                Console.WriteLine("\nCompañia Telefónica: " + "Viva");
                                Console.WriteLine("Monto de la tarjeta: " + "250");
                                Console.WriteLine("Balance Anterior: " + saldo.balance);
                                Console.WriteLine("Balance Actual: " + trans_.balance_nuevo);

                                transacciones.Add(trans_);
                                Console.WriteLine("\n             [ Toque una tecla para continuar... ]");
                                Console.ReadKey();
                                MenuPrincipalCliente();
                            }
                            break;
                        default:
                            Console.WriteLine("                         Opción no válida. Elija una una opción válida");
                            Console.WriteLine("\n                            [ Toque una tecla para continuar... ]");
                            Console.ReadKey();
                            goto viva;

                    }
                }
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Error. " + ex);
                Console.WriteLine("\n                             [ Toque una tecla para continuar... ]");
                Console.ReadKey();
                MenuPrincipalCliente();
            }
        }
        public static void salir()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("¿Está seguro que desea salir del sistema?");
                Console.WriteLine("              [1] Si   [2] No");
                int opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        LoginAdmin();
                        break;
                    case 2:
                        Console.WriteLine("\n             [ Toque una tecla para continuar... ]");
                        Console.ReadKey();
                        MenuPrincipalCliente();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception error)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("                                    ***  " + error.Message + "  ***");
                Console.WriteLine("\n                                [ Toque una tecla para continuar... ]");
                Console.ReadKey();
                LoginAdmin();
            }
        }
        public enum menuclient
        {
            retirar_efectivo = 1,
            depositar_efectivo,
            comprar_tarjeta,
            consultar_balance,
            salir
        }
    }
}
namespace Ocultar.password
{
    static public class Console
    {
        public static string leercontraseña(char m)
        {
            const int entrada = 13, espacios = 8, ctrlespacios = 127;
            int[] FTR = { 0, 27, 3, 10 };

            var password_ = new Stack<char>();
            char char_ = (char)0;

            while ((char_ = System.Console.ReadKey(true).KeyChar) != entrada)
            {
                if (char_ == espacios)
                {
                    if (password_.Count > 0)
                    {
                        System.Console.Write("\b \b");
                        password_.Pop();
                    }
                }
                else if (char_ == ctrlespacios)
                {
                    while (password_.Count > 0)
                    {

                    }
                }
                else if (FTR.Count(x => char_ == x) > 0) { }
                else
                {
                    password_.Push((char)char_);
                    System.Console.Write(m);
                }
            }

            System.Console.WriteLine();
            return new string(password_.Reverse().ToArray());

        }
        public static string Read__Pass()
        {
            return Ocultar.password.Console.leercontraseña('*');
        }
    }
}