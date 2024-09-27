using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_d_une_bibliothèque_de_médias_Dev2
{
    internal class DVD : Media
    {

        float mins;

        public DVD(string titre, int numRef, int nombreExemplairesDisponibles, float mins)
           : base(titre, numRef, nombreExemplairesDisponibles)
        {
            this.mins = mins;
        }




        public void AfficherInfosDVD()
        {
            AfficherInfos();
            Console.WriteLine($"nombre de minutes : {mins}");
        }



    }
}
