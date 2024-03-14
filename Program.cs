using Parcial1.Models;
using System.Timers;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Client> client = new List<Client>();
        List<Admin> admin = new List<Admin>();
        List<ClientEnterprice> clientEnterprice = new List<ClientEnterprice>();

        string nameUser;
        string password;
        int opt = 1;
        int optReg = 0;
        int optLog = 0;
        string msg = "Bienvenido al banco \n1 para iniciar sesión, \n2 para registrarse, \n0 para salir";
        string msgAdmin = "Seleccione \n1 para ver los depositos diarios 2 \npara ver los retiros diarios \n3 para ver los clientes creados \n0 para salir";
        string msgClient = "Seleccione \n1 para depositar \n2 para retirar \n0 para salir";
        string msgClientE = "Seleccione \n1 para solicitar un préstamo \n0 para salir";

        while (opt == 1 || opt == 2)
        {
            Console.Clear();
            Console.WriteLine(msg);
            opt = int.Parse(Console.ReadLine());

            switch (opt)
            {

                case 1:
                {
                    Console.WriteLine("Ingrese nombre de usuario:");
                    nameUser = Console.ReadLine();

                    Console.WriteLine("Ingrese contraseña:");
                    password = Console.ReadLine();

                    bool auth = false;
                    User authUser = null;
                    Client authClient = null;
                    Admin authAdmin = null;
                    ClientEnterprice authClientEnterprice = null;

                    // Verificar credenciales
                    while (!auth)
                    {
                        foreach (var usuario in client)
                        {
                            if (usuario.name == nameUser && usuario.password == password)
                            {
                                auth = true;
                                authUser = usuario;
                                authClient = usuario;
                                break;
                            }
                        }

                        foreach (var usuario in admin)
                        {
                            if (usuario.name == nameUser && usuario.password == password)
                            {
                                auth = true;
                                authUser = usuario;
                                authAdmin = usuario;
                                break;
                            }
                        }

                        foreach (var usuario in clientEnterprice)
                        {
                            if (usuario.name == nameUser && usuario.password == password)
                            {
                                auth = true;
                                authUser = usuario;
                                authClientEnterprice = usuario;
                                break;
                            }
                        }
                    }

                    // Mostrar mensaje de autenticación
                    if (auth)
                    {
                        Console.WriteLine($"Bienvenido, {authUser.name}!");
                        if (authUser is Client)
                        {
                            Console.WriteLine("¡Eres un cliente del banco!");
                            
                            while (optLog != 0)
                            {
                                Console.Clear();
                                Console.WriteLine(msgClient);
                                optLog = int.Parse(Console.ReadLine());
                                switch (optLog) 
                                {
                                    //Depositar
                                    case 1:
                                    {
                                        Console.WriteLine("Ingrese la cantidad que desea depositar");
                                        authClient.balance = authClient.balance + double.Parse(Console.ReadLine());
                                        Console.WriteLine($"Su saldo total es de {authClient.balance} pesos");


                                        Console.WriteLine("Presione cualquier tecla para continuar...");
                                        Console.ReadKey();
                                        break;
                                    }
                                    //Retirar
                                    case 2:
                                    {
                                        Console.WriteLine("Ingrese la cantidad que desea retirar");
                                        double total = double.Parse(Console.ReadLine());
                                        if (total > authClient.balance)
                                        {
                                            Console.WriteLine("No tiene el dinero suficiente para retirar del banco");
                                        }
                                        else
                                        {
                                            Console.WriteLine($"Se ha retirado con éxito su saldo es de {authClient.balance} pesos");
                                        }

                                        Console.WriteLine("Presione cualquier tecla para continuar...");
                                        Console.ReadKey();
                                        break;
                                    }
                                }
                            }

                        }
                        else if (authUser is ClientEnterprice)
                        {
                            Console.WriteLine("¡Eres un cliente de empresa!");
                            double Interest = 0.12;
                            double totalInterest;
                            double totalPayment;

                            while(optLog != 0)
                            {
                                Console.Clear();
                                Console.WriteLine(msgClientE);
                                optLog = int.Parse(Console.ReadLine());

                                Console.WriteLine("Ingrese la cantidad del préstamo a solicitar");
                                authClientEnterprice.amount = double.Parse(Console.ReadLine());

                                Console.WriteLine("Indique cuales son los ingresos del cliente");
                                authClientEnterprice.revenue = double.Parse(Console.ReadLine());

                                Console.WriteLine("Escriba a cuantos años desea pagar");
                                authClientEnterprice.time = double.Parse(Console.ReadLine());

                                totalInterest = authClientEnterprice.amount * Interest * authClientEnterprice.time;
                                authClientEnterprice.credit = authClientEnterprice.amount * totalInterest;

                                Console.WriteLine($"El susuario debe pagar un total de {authClientEnterprice.credit} a {authClientEnterprice.time} años");

                                Console.WriteLine("Presione cualquier tecla para continuar...");
                                Console.ReadKey();
                            }
                        }
                        else if (authUser is Admin)
                        {
                            Console.WriteLine("¡Eres un administrador del sistema!");

                            while (optLog != 0)
                            {
                                Console.Clear();
                                Console.WriteLine(msgAdmin);
                                optLog = int.Parse(Console.ReadLine());
                                switch (optLog)
                                {
                                    //Dep diarios
                                    case 1:
                                    {
                                        foreach (var usuario in client)
                                        {
                                            Console.WriteLine($"El usuario {usuario.name} ha depositado {usuario.dep}");
                                        }

                                        Console.WriteLine("Presione cualquier tecla para continuar...");
                                        Console.ReadKey();
                                        break;
                                    }
                                
                                    //Retiros diarios
                                    case 2:
                                    {
                                        foreach (var usuario in client)
                                        {
                                            Console.WriteLine($"El usuario {usuario.name} ha depositado {usuario.ret}");
                                        }

                                        Console.WriteLine("Presione cualquier tecla para continuar...");
                                        Console.ReadKey();
                                        break;
                                    }

                                    // Creación de clientes
                                    case 3:
                                    {
                                        var newClient = new Client();

                                        Console.WriteLine("Ingrese el nombre");
                                        newClient.name = Console.ReadLine();

                                        Console.WriteLine("Ingrese el número de documeto de identidad");
                                        newClient.document = Console.ReadLine();

                                        Console.WriteLine("Ingrese la contraseña");
                                        newClient.password = Console.ReadLine();

                                        client.Add(newClient);

                                        Console.WriteLine("Cliente creado con éxito");
                                        Console.WriteLine("Presione cualquier tecla para continuar...");
                                        Console.ReadKey();
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Credenciales incorrectas. No se pudo iniciar sesión.");
                    }

                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();

                    break;
                }

                //Registrar el usuario
                case 2:
                {
                    Console.WriteLine("Presione: \n1 para registrarse como Administrador \n2 para registrarse como Cliente de empresa, \n3 para registrarse como Cliente");
                    optReg = int.Parse( Console.ReadLine());

                    if (optReg == 1)
                    {
                        var newClient = new Admin();

                        Console.WriteLine("Ingrese el nombre");
                        newClient.name = Console.ReadLine();

                        Console.WriteLine("Ingrese el número de documeto de identidad");
                        newClient.document = Console.ReadLine();

                        Console.WriteLine("Ingrese la contraseña");
                        newClient.password = Console.ReadLine();

                        admin.Add(newClient);
                    }
                    else if (optReg == 2)
                    {
                        var newClient = new ClientEnterprice();

                        Console.WriteLine("Ingrese el nombre");
                        newClient.name = Console.ReadLine();

                        Console.WriteLine("Ingrese el número de documeto de identidad");
                        newClient.document = Console.ReadLine();

                        Console.WriteLine("Ingrese la contraseña");
                        newClient.password = Console.ReadLine();

                        clientEnterprice.Add(newClient);

                    }
                    else if (optReg == 3)
                    {
                        var newClient = new Client();

                        Console.WriteLine("Ingrese el nombre");
                        newClient.name = Console.ReadLine();

                        Console.WriteLine("Ingrese el número de documeto de identidad");
                        newClient.document = Console.ReadLine();

                        Console.WriteLine("Ingrese la contraseña");
                        newClient.password = Console.ReadLine();

                        client.Add(newClient);
                    }

                    Console.WriteLine("El usuario ha sido creado con éxito. Presione cualquier tecla para contunuar");
                    Console.ReadKey();

                    break;
                }
            }
        }  
    }
}    
