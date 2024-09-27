using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Gestion_d_une_bibliothèque_de_médias_Dev2.Media;

namespace Gestion_d_une_bibliothèque_de_médias_Dev2
{
    internal class Livre : Media
    {
        string auteur;
        DateTime dateSortie;


        public Livre(string titre, int numRef, int nombreExemplairesDisponibles, string auteur, DateTime dateSortie)
           : base(titre, numRef, nombreExemplairesDisponibles)
        {
            this.auteur = auteur;
            this.dateSortie = dateSortie;
        }

        public void AfficherInfosLivre()
        {
            AfficherInfos();
            Console.WriteLine($"auteur : {auteur},dateSortie : {dateSortie}");
        }

    }
}
