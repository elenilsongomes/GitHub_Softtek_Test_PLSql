using System.Globalization;

namespace Questao1
{
    public class ContaBancaria {

        private static int numero = 0;
        private string titular = string.Empty;
        private double saldo = 0;
        private readonly double taxaSaque = 3.50;

        public static int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public string Titular
        {
            get { return titular; }
            set { titular = value; }
        }

        public ContaBancaria(int numero, string titular, double depositoInicial)
        {
            Numero = numero;
            Titular = titular;

            Deposito(depositoInicial);
        }

        public ContaBancaria(int numero, string titular)
        {
            Numero = numero;
            Titular = titular;
        }

        public void Deposito(double quantia)
        {
            saldo += quantia;
        }

        public void Saque(double quantia)
        {
            saldo -= quantia + taxaSaque;
        }

        public override string ToString()
        {
            return "Conta " + Numero.ToString() +
                   ", Titular: " + Titular +
                   ", Saldo: " + saldo.ToString("C2", CultureInfo.GetCultureInfo("en-us"));
        }
    }
}
