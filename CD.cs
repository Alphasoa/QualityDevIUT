using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_d_une_bibliothèque_de_médias_Dev2
{
    internal class CD : Media
    {
        string artiste;

        public CD(string titre, int numRef, int nombreExemplairesDisponibles, string artiste)
           : base(titre, numRef, nombreExemplairesDisponibles)
        {
            this.artiste = artiste;
        }
        
        public void AfficherInfosCD()
        {
            AfficherInfos();
            Console.WriteLine($"Nom de l'artiste : {artiste}");
        }
    }
}
