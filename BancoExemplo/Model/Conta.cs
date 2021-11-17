using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoExemplo.Model
{
    public class Conta
    {
        private string CPF { get; set; }
        private decimal Saldo { get; set; }

        public Conta(string CPF, decimal valor) 
        {
            this.CPF = CPF;
            this.Saldo = valor;
        }

        public decimal GetSaldo(decimal Saldo) => Saldo;

        public void Depositar(decimal valor) => Saldo += valor;

        public bool Sacar(decimal valor)
        {
            if (Saldo <= valor)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.Saldo -= valor;
            return true;
        }
    }
}
