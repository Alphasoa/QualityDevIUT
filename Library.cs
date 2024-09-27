using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_d_une_bibliothèque_de_médias_Dev2
{
    internal class Emprunt
    {
        public Media Media { get; set; }
        public string Emprunteur { get; set; }
        public DateTime DateEmprunt { get; set; }

        public Emprunt(Media media, string emprunteur, DateTime dateEmprunt)
        {
            Media = media;
            Emprunteur = emprunteur;
            DateEmprunt = dateEmprunt;
        }

        public void AfficherDetailsEmprunt()
        {
            Console.WriteLine($"Média : {Media.titre}, Emprunteur : {Emprunteur}, Date d'emprunt : {DateEmprunt}");
        }
    }
    
    internal class Library
    {
        List<Media> CollectionMedia;
        List<Emprunt> emprunts;


        public Library()
        {
            CollectionMedia = new List<Media>();
            emprunts = new List<Emprunt>();
        }


        public Media RechercherParNumRef(int numRef)
        {
            foreach (var media in CollectionMedia)
            {
                if (media.numRef == numRef)
                {
                    return media;
                }
            }
            return null; 
        }


        public bool RetirerMedia(int numRef)
        {
            Media mediaARetirer = RechercherParNumRef(numRef);
            if (mediaARetirer != null)
            {
                CollectionMedia.Remove(mediaARetirer);
                Console.WriteLine($"Média avec le numéro de référence {numRef} retiré de la bibliothèque.");
                return true;
            }
            else
            {
                Console.WriteLine($"Média avec le numéro de référence {numRef} non trouvé.");
                return false;
            }
        }



        public bool EmprunterMedia(int numRef, string emprunteur)
        {
            Media media = RechercherParNumRef(numRef);
            if (media != null && media.nombreExemplairesDisponibles > 0)
            {
                media.nombreExemplairesDisponibles--;
                emprunts.Add(new Emprunt(media, emprunteur, DateTime.Now));
                Console.WriteLine($"Média {media.titre} emprunté par {emprunteur}. Il reste {media.nombreExemplairesDisponibles} exemplaire(s).");
                return true;
            }
            Console.WriteLine($"Média {media?.titre ?? "inconnu"} indisponible ou non trouvé.");
            return false;
        }

        public bool RetournerMedia(int numRef, string emprunteur)
        {
            var emprunt = emprunts.FirstOrDefault(e => e.Media.numRef == numRef && e.Emprunteur == emprunteur);
            if (emprunt != null)
            {
                emprunt.Media.nombreExemplairesDisponibles++;
                emprunts.Remove(emprunt);
                Console.WriteLine($"Média {emprunt.Media.titre} retourné par {emprunteur}. Il y a maintenant {emprunt.Media.nombreExemplairesDisponibles} exemplaire(s) disponible(s).");
                return true;
            }
            Console.WriteLine($"Emprunt non trouvé pour {emprunteur} avec le numéro de référence {numRef}.");
            return false;
        }

        public void RechercherParTitreOuAuteur(string critere)
        {
            var resultats = CollectionMedia.Where(media =>
                media.titre.Contains(critere, StringComparison.OrdinalIgnoreCase) ||
                (media is Livre livre && livre.auteur.Contains(critere, StringComparison.OrdinalIgnoreCase))
            ).ToList();

            if (resultats.Count > 0)
            {
                Console.WriteLine("Résultats de la recherche :");
                foreach (var media in resultats)
                {
                    media.AfficherInfos();
                }
            }
            else
            {
                Console.WriteLine("Aucun média trouvé pour ce critère.");
            }
        }

        // Méthode pour lister les médias empruntés par un utilisateur
        public void ListerMediasEmpruntesParUtilisateur(string emprunteur)
        {
            var mediasEmpruntes = emprunts.Where(e => e.Emprunteur == emprunteur).ToList();
            if (mediasEmpruntes.Count > 0)
            {
                Console.WriteLine($"Médias empruntés par {emprunteur} :");
                foreach (var emprunt in mediasEmpruntes)
                {
                    emprunt.AfficherDetailsEmprunt();
                }
            }
            else
            {
                Console.WriteLine($"{emprunteur} n'a emprunté aucun média.");
            }
        }

        // Méthode pour afficher les statistiques de la bibliothèque
        public void AfficherStatistiques()
        {
            int totalExemplaires = mediaCollection.Sum(media => media.nombreExemplairesDisponibles);
            int empruntsActifs = emprunts.Count;
            int totalMedias = mediaCollection.Count;

            Console.WriteLine("Statistiques de la bibliothèque :");
            Console.WriteLine($"Nombre total de médias : {totalMedias}");
            Console.WriteLine($"Nombre total d'exemplaires disponibles : {totalExemplaires}");
            Console.WriteLine($"Nombre d'emprunts actifs : {empruntsActifs}");
        }






        public void AfficherCollection()
        {
            foreach (var media in CollectionMedia)
            {
                media.AfficherInfos(); // Appelle la méthode AfficherInfos() de chaque type de média
                Console.WriteLine(); // Ligne vide pour la lisibilité
            }
        }

        

    }
}
