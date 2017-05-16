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
                var hoogstenInHierarchie = (from personeelslid in entities.Personeel
                            where personeelslid.ManagerNr == null
                            select personeelslid).ToList();
                Afbeelden(hoogstenInHierarchie, 0);
            }

            Console.WriteLine("Druk enter om af te sluiten");
            Console.Read();
        }

        static void Afbeelden(List<Personeelslid> personeel, int insprong)
        {
            foreach (var personeelslid in personeel)
            {
                Console.Write(new String('\t', insprong));
                Console.WriteLine(personeelslid.Voornaam);
                if(personeelslid.Ondergeschikten.Count!=0)
                {
                    Afbeelden(personeelslid.Ondergeschikten.ToList(), insprong + 1);
                }
            }

        }
    }
}
