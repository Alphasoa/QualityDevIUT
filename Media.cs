using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_d_une_bibliothèque_de_médias_Dev2
{
    internal class Media
    {
        public string titre;
        public int numRef, nombreExemplairesDisponibles;

        public Media(string titre, int numRef, int nombreExemplairesDisponibles)
        {
            this.titre = titre;
            this.numRef = numRef;
            this.nombreExemplairesDisponibles = nombreExemplairesDisponibles;
        }


        public void AfficherInfos()
        {
            Console.WriteLine($"Titre : {titre}, Numéro de référence : {numRef}, Nombre d'exemplaires disponibles : {nombreExemplairesDisponibles}");
        }

        public static Media operator +(Media m, int nbExemplaires)
        {
            m.nombreExemplairesDisponibles += nbExemplaires;
            return m;
        }

        public static Media operator -(Media m, int nbExemplaires)
        {
            if (m.nombreExemplairesDisponibles < nbExemplaires)
            {
                throw new InvalidOperationException("Nombre d'exemplaires insuffisant pour retirer.");
            }
            m.nombreExemplairesDisponibles -= nbExemplaires;
            return m;
        }

    }
}