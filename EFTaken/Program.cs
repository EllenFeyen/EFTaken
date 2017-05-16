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
            using (var entities = new BankEntities())
            {
                var query = from rekening in entities.Rekeningen
                            where rekening is Zichtrekening
                            select rekening;
                foreach (var zichtrekening in query)
                {
                    Console.WriteLine("{0} : {1}", zichtrekening.RekeningNr, zichtrekening.Saldo);
                }
            }

            Console.WriteLine("Druk enter om af te sluiten");
            Console.Read();
        }

        static void AfbeeldenVolgensHierarchie(List<Personeelslid> personeel, int insprong)
        {
            foreach (var personeelslid in personeel)
            {
                Console.Write(new String('\t', insprong));
                Console.WriteLine(personeelslid.Voornaam);
                if(personeelslid.Ondergeschikten.Count!=0)
                {
                    AfbeeldenVolgensHierarchie(personeelslid.Ondergeschikten.ToList(), insprong + 1);
                }
            }

        }
    }
}
