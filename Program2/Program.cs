public class KontoBankowe
{
    private decimal _saldo;
    private string _numerKonta;
    public decimal Saldo
    {
        get { return _saldo; }
        private set { _saldo = value; }
    }
    public string NumerKonta
    {
        get { return _numerKonta; }
        private set { _numerKonta = value; }
    }

    public KontoBankowe()
    {
        Saldo = 0;
        NumerKonta = "01010101010101010101010101";
    }

    bool Wplata(decimal kwota)
    {
        if (kwota <= 0) return false;
        Saldo += kwota;
        return true;
    }
    bool Wyplata(decimal kwota)
    {
        if (kwota <= 0 || kwota > Saldo) return false;
        Saldo -= kwota;
        return true;
    }
    public void Operacje()
    { 
        bool zakoncz = false;
        while(!zakoncz)
        {
            Console.WriteLine("Wybierz operacje: Wplata(1), Wyplata(2), Wyswietl stan konta(3) , Zakoncz(4)");
            int w = Convert.ToInt32(Console.ReadLine());

            while (w < 1 || w > 4)
            {
                Console.Clear();
                Console.WriteLine("Podana liczba jest nieprawidlowa. Sprobuj ponownie(1-4): ");
                w = Convert.ToInt32(Console.ReadLine());
            }

            switch (w)
            {
                case 1:
                    Console.WriteLine("Podaj kwote wplaty: ");
                    decimal kwotaWplaty = Convert.ToDecimal(Console.ReadLine());
                    if (Wplata(kwotaWplaty))
                    {
                        Console.Clear();
                        Console.WriteLine("Wplata udana. Aktualne saldo: " + Saldo);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Nieprawidlowa kwota wplaty.");
                    }

                    break;

                case 2:
                    Console.WriteLine("Podaj kwote wyplaty: ");
                    decimal kwotaWyplaty = Convert.ToDecimal(Console.ReadLine());
                    if (Wyplata(kwotaWyplaty))
                    {
                        Console.Clear();
                        Console.WriteLine("Wyplata udana. Aktualne saldo: " + Saldo);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Nieprawidlowa kwota wyplaty lub brak srodkow na koncie.");
                    }

                    break;

                case 3:
                    Console.Clear();
                    Console.WriteLine("Aktualne saldo konta: " + Saldo);

                    break;

                case 4:
                    zakoncz = true;
                    Console.Clear();
                    Console.WriteLine("Dziękujemy za skorzystanie z usług. MIłego dnia!");
                    break;

            }
        }
    }
}


internal class Program
{
    private static void Main(string[] args)
    {
        KontoBankowe konto = new KontoBankowe();
        konto.Operacje();
    }
}