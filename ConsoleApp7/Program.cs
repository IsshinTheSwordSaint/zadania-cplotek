namespace ConsoleApp7
{
    public interface IDokument
    {
        string Tytul { get; }
        DateTime DataUtworzenia { get; }


        public void Wyswietl()
        {
            Console.WriteLine($"Tytuł: {Tytul}");
            Console.WriteLine($"Data utworzenia: {DataUtworzenia}");
        }
    }
    public class Faktura : IDokument
    {
        public decimal Kwota { get; set; }
        public string Tytul => "Faktura";
        public DateTime DataUtworzenia => new DateTime(2023,4,10);
        public void Wyswietl() {
            Console.WriteLine($"Tytuł: {Tytul}");
            Console.WriteLine($"Data utworzenia: {DataUtworzenia}");
            Console.WriteLine($"Kwota: {Kwota}");
        }
    }
    public class Raport : IDokument
    {
        public string Autor { get; set; }
        public string Tytul => "Raport";
        public DateTime DataUtworzenia => new DateTime(2025, 4, 10);
        public void Wyswietl()
        {
            Console.WriteLine($"Tytuł: {Tytul}");
            Console.WriteLine($"Data utworzenia: {DataUtworzenia}");
            Console.WriteLine($"Autor: {Autor}");
        }
    }
    public class Email : IDokument
    {
        public string Nadawca { get; set; }
        public string Tytul => "Email";
        public DateTime DataUtworzenia => new DateTime(2024, 4, 10);
        public void Wyswietl()
        {
            Console.WriteLine($"Tytuł: {Tytul}");
            Console.WriteLine($"Data utworzenia: {DataUtworzenia}");
            Console.WriteLine($"Nadawca: {Nadawca}");
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            List<IDokument> dokumenty = new List<IDokument>
            {
                new Faktura { Kwota = 1000 },
                new Raport { Autor = "Jan Kowalski" },
                new Email { Nadawca = "j.kowalski@gmail.com"}
            };

            foreach (var dokument in dokumenty)
            {
                dokument.Wyswietl();
            }

            Console.WriteLine("\nPosortowane dokumenty według daty utworzenia:\n");

            var sortowanie = dokumenty.OrderBy(d => d.DataUtworzenia);
            foreach (var dokument in sortowanie)
            {
                dokument.Wyswietl();
            }
        }
    }
}
