// See https://aka.ms/new-console-template for more information
using Laboratorio1;

CuentaBancaria cuentabancaria = new CuentaBancaria();
cuentabancaria.Titular = "Arturo Manrique";
cuentabancaria.NumeroCuenta = "111123333";
cuentabancaria.Saldo = 999999;

cuentabancaria.PinSeguridad = 9999;


int intentosFallidos = 0;

while (intentosFallidos < 3)
{
    Console.WriteLine("Bienvenido al Cajero Automático de Tecsup");
    Console.Write("Ingrese su PIN: ");
    int pinIngresado = int.Parse(Console.ReadLine());

    if (cuentabancaria.IniciarSesion(pinIngresado))
    {
        break;
    }

    Console.WriteLine("PIN incorrecto. Intente denuevo.");
    intentosFallidos++;
}

if (intentosFallidos == 3)
{
    Console.WriteLine("Ha alcanzado el límite de intentos. Cuenta bloqueada.");
    return;
}


while (true) // Bucle infinito
{
    Console.WriteLine("Bienvenido al Cajero Automático de Tecsup");
    Console.WriteLine("Seleccione una opción:");
    Console.WriteLine("1. Consultar Saldo");
    Console.WriteLine("2. Depositar Fondos");
    Console.WriteLine("3. Retirar Efectivo");
    Console.WriteLine("4. Cambiar PIN");
    Console.WriteLine("5. Salir");

    int opcion = int.Parse(Console.ReadLine());



    switch (opcion)
    {
        case 1:
            Console.WriteLine($"Saldo actual: {cuentabancaria.ConsultarSaldo():C}");
            break;
        case 2:
            Console.Write("Ingrese la cantidad a depositar: ");
            decimal cantidadDeposito = decimal.Parse(Console.ReadLine());
            cuentabancaria.DepositarFondos(cantidadDeposito);
            Console.WriteLine($"Depósito exitoso. Saldo actual: {cuentabancaria.ConsultarSaldo():C}");
            break;
        case 3:
            Console.Write("Ingrese la cantidad a retirar: ");
            decimal cantidadRetiro = decimal.Parse(Console.ReadLine());
            if (cuentabancaria.RetirarEfectivo(cantidadRetiro))
            {
                Console.WriteLine($"Retiro exitoso. Saldo restante: " +
                    $"{cuentabancaria.ConsultarSaldo():C}");
            }
            else
            {
                Console.WriteLine("No se pudo realizar el retiro.");
            }
            break;
        case 4:
            Console.Write("Ingrese el nuevo PIN: ");
            int nuevoPin = int.Parse(Console.ReadLine());
            if (cuentabancaria.CambiarPin(nuevoPin))
            {
                Console.WriteLine("PIN cambiado exitosamente.");
            }
            else
            {
                Console.WriteLine("No se pudo cambiar el PIN.");
            }
            break;
        case 5:
            Console.WriteLine("Gracias por usar el Cajero Automático.");
            return;
        default:
            Console.WriteLine("Opción no válida.");
            break;
    }
}