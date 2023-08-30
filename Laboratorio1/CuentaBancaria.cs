using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio1
{
    public class CuentaBancaria
    {
        public string Titular { get; set; }
        public string NumeroCuenta { get; set; }
        public decimal Saldo { get; set; }
        public int PinSeguridad { get; set; }

        private decimal LimiteDiarioRetiro = 10000.00m;
        public decimal ConsultarSaldo()
        {
            return Saldo;
        }
        public bool RetirarEfectivo(decimal cantidad)
        {
            if (cantidad > 0 && cantidad <= LimiteDiarioRetiro && cantidad <= Saldo)
            {
                Saldo -= cantidad;
                return true;
            }
            else
            {
                return false;
            }
        }
        public void DepositarFondos(decimal cantidad)
        {
            if (cantidad > 0)
            {
                Saldo += cantidad;
            }
        }
        public bool CambiarPin(int nuevoPin)
        {
            PinSeguridad = nuevoPin;
            return true;
        }
        public bool IniciarSesion(int pinIngresado)
        {
            return pinIngresado == PinSeguridad;
        }
    }
}
