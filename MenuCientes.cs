using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO_FINAL___PROGRAMACION
{
    class MenuCientes
    {
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
                Console.WriteLine("                   |                      Banco" + bank_name + "                     |");
                Console.WriteLine("                   |                  Menu  Principal de Cliente                    |");
                Console.WriteLine("                   |                       " + DateTime.Now + "                     |");
                Console.WriteLine("                   |________________________________________________________________|\n");
                Console.Write("> Elija la opción deseada: \n");
                Console.WriteLine("\n      |  1. Retirar Efectivo                    |");
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
