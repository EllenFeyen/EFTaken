using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Data.Entity.Infrastructure;

namespace EFTaken
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Klantnr.:");
                var klantNr = int.Parse(Console.ReadLine());

                using (var entities = new BankEntities())
                {
                    var klant = entities.Klanten.Find(klantNr);
                    if (klant == null)
                    { Console.WriteLine("Klant niet gevonden"); }
                    else
                    {
                        Console.Write("Geef de juiste voornaam:");
                        var voornaam = Console.ReadLine();
                        klant.Voornaam = voornaam;
                        entities.SaveChanges();
                    }
                }
            }
            catch (DbUpdateConcurrencyException)
            { Console.WriteLine("Een andere gebruiker wijzigde deze klant"); }
            catch (FormatException)
            { Console.WriteLine("Tik een getal"); }

            Console.WriteLine("Druk enter om af te sluiten");
            Console.Read();
        }
    }
}
