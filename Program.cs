using System.Text;

namespace ConsoleApp8
{
    public abstract class KontoBankowe
    {
        public string NumerKonta;
        public string Wlasciciel;
        protected decimal Saldo;

        public decimal saldo
        {
            get { return Saldo; }
            protected set { Saldo = value; }
        }
        public KontoBankowe(string nrKonta, string wlasciciel)
        {
            NumerKonta = nrKonta;
            Wlasciciel = wlasciciel;
        }

        public abstract decimal ObliczOprocentowanie();

        public void Wplac(decimal kwota)
        {
            saldo = kwota;
        }
        public void Wyplac(decimal kwota)
        {
        }
        public virtual void WyswietlInformacje()
        {
        }
    }

    public class KontoOszczednosciowe : KontoBankowe
    {
        public string NazwaKonta = "Konto Oszczednosciowe";
        private float oprocentowanie = 0.05f;
        public KontoOszczednosciowe(string nrKonta, string wlasciciel)
            : base(nrKonta, wlasciciel)
        {
        }
        public override decimal ObliczOprocentowanie()
        {
            return saldo * (decimal)oprocentowanie;
        }
        public override void WyswietlInformacje()
        {
            base.WyswietlInformacje();
            System.Console.WriteLine($"Numer: {NumerKonta}");
            System.Console.WriteLine($"Wlasciciel: {Wlasciciel}");
            System.Console.WriteLine($"Konto: {NazwaKonta}");
            System.Console.WriteLine($"Saldo: {saldo} zł");
        }
    }
    public class KontoStudenckie : KontoBankowe
    {
        public string NazwaKonta = "Konto Studenckie";
        private float oprocentowanie = 0.02f;
        public KontoStudenckie(string nrKonta, string wlasciciel)
            : base(nrKonta, wlasciciel)
        {
        }
        public override decimal ObliczOprocentowanie()
        {
            return saldo * (decimal)oprocentowanie;
        }
        public override void WyswietlInformacje()
        {
            base.WyswietlInformacje();
            System.Console.WriteLine($"Numer: {NumerKonta}");
            System.Console.WriteLine($"Wlasciciel: {Wlasciciel}");
            System.Console.WriteLine($"Konto: {NazwaKonta}");
            System.Console.WriteLine($"Saldo: {saldo} zł");
        }
    }
    public class KontoFirmowe : KontoBankowe
    {
        public string NazwaKonta = "Konto Firmowe";
        private float oprocentowanie = 0;
        private int prowizja = 2;
        public KontoFirmowe(string nrKonta, string wlasciciel)
            : base(nrKonta, wlasciciel)
        {
        }
        public override decimal ObliczOprocentowanie()
        {
            return saldo * (decimal)oprocentowanie;
        }
        public override void WyswietlInformacje()
        {
            base.WyswietlInformacje();
            System.Console.WriteLine($"Numer: {NumerKonta}");
            System.Console.WriteLine($"Wlasciciel: {Wlasciciel}");
            System.Console.WriteLine($"Konto: {NazwaKonta}");
            System.Console.WriteLine($"Saldo: {saldo} zł");
        }

        new public void Wyplac(decimal kwota)
        {
            saldo -= kwota + prowizja;
            Console.WriteLine($"Wyplacono {kwota} zł, prowizja wyniosła {prowizja} " +
                $",a stan konta wynosi {saldo} zł");
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
         List<KontoBankowe> konta = new List<KontoBankowe>();
            KontoOszczednosciowe konto1 = new KontoOszczednosciowe("1234567890", "Jan Kowalski");
            KontoStudenckie konto2 = new KontoStudenckie("0987654321", "Anna Nowak");
            KontoFirmowe konto3 = new KontoFirmowe("1122334455", "XYZ Sp. z o.o.");
            konta.Add(konto1);
            konta.Add(konto2);
            konta.Add(konto3);
            konto1.Wplac(1000);
            konto2.Wplac(1000);
            konto3.Wplac(1000);
            foreach (var konto in konta)
            {
                konto.WyswietlInformacje();
                Console.WriteLine($"Obliczone oprocentowanie: {konto.ObliczOprocentowanie()} zł");
                Console.WriteLine();
            }
            Console.WriteLine("Wyplata z konta firmowego:");
            konto3.Wyplac(300);



        }
    }
}
