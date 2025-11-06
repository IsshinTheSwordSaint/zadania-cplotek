public class KontoBankowe
{
    decimal Saldo;
    string NumerKonta;
    List <string> Historia;

    bool Wplata(decimal kwota)
    {
        if (kwota <= 0) return false;
        Saldo += kwota;
        Historia.Add($"Wplata: {kwota}");
        return true;
    }
    bool Wyplata(decimal kwota)
    {
        if (kwota <= 0 || kwota > Saldo) return false;
        Saldo -= kwota;
        Historia.Add($"Wyplata: {kwota}");
        return true;
    }
    List<string> PobierzOstatnieOperacje(int liczba)
    {
        if (liczba <= 0 || liczba > Historia.Count)
            return new List<string>();
        return Historia.GetRange(Historia.Count - liczba, liczba);
    }

    void Operacje()
    {
        Console.WriteLine("Wybierz operacje: Wplata(1), Wyplata(2), Historia(3), Zakoncz(4)");
        int w = Convert.ToInt32(Console.ReadLine());
        
        while (w < 1 || w > 4)
        {
            Console.WriteLine("Podana liczba jest nieprawidlowa. Sprobuj ponownie: ");
            w = Convert.ToInt32(Console.ReadLine());
        }
        
        switch (w)
        {

        }
    }
}


internal class Program
{
    private static void Main(string[] args)
    {
        System.Console.WriteLine("Hello, World!");
    }
}