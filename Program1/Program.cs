public class Kalkulator
{
    public double wagaKg;
    public double wzrostCm;
    private double _wynikBMI;
    public double WynikBMI
    {
        get { return _wynikBMI; }
        set { _wynikBMI = value; }
    }
    public double ObliczBMI()
    {
        return Math.Round(wagaKg / ((wzrostCm / 100) * (wzrostCm / 100)), 2);
    }
    public string PodajKategorie(double bmi)
    {
        if (bmi < 18.5)
            return $"Wynik to {bmi} - Niedowaga";
        else if (bmi < 24.9)
            return $"Wynik to {bmi} - Waga prawidłowa";
        else if (bmi < 29.9)
            return $"Wynik to {bmi} - Nadwaga";
        else
            return $"Wynik to {bmi} - Otyłość";
    }
    public Kalkulator (double wagaKg, double wzrostCm)
    {
        this.wagaKg = wagaKg;
        this.wzrostCm = wzrostCm;
    }

}


internal class Program
{
    static void Main(string[] args)
    {
        var k1 = new Kalkulator(0, 0);

        Console.WriteLine("Podaj wage(kg): ");
        string waga = Console.ReadLine();
        Console.WriteLine("Podaj wzrost(cm): ");
        string wzrost = Console.ReadLine();

        k1.wagaKg = Convert.ToDouble(waga);
        k1.wzrostCm = Convert.ToDouble(wzrost);

        Console.WriteLine(k1.PodajKategorie(k1.ObliczBMI()));

        k1.WynikBMI = k1.ObliczBMI();
        double w = k1.WynikBMI;
    }
}