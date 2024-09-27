namespace Gestion_d_une_bibliothèque_de_médias_Dev2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Livre livre = new Livre("Les Misérables", 1001, 63, "Victor Hugo", new DateTime(1862, 1, 1));
            Console.WriteLine("Informations sur le livre :");
            livre.AfficherInfosLivre();
            Console.WriteLine();


            Media Mlivre = new Media ("Harry Potter",1265,7);
            Console.WriteLine(Mlivre.nombreExemplairesDisponibles);
            //Mlivre = Mlivre - 2;
            Mlivre = Mlivre + 2;
            Console.WriteLine(Mlivre.nombreExemplairesDisponibles);
            Console.WriteLine();

            DVD dvd = new DVD("Inception", 3409, 26, 148f);
            Console.WriteLine("Informations sur le DVD :");
            dvd.AfficherInfosDVD();
            Console.WriteLine();

            CD cd = new CD("Thriller", 7897, 100, "Michael Jackson");
            Console.WriteLine("Informations sur le CD :");
            cd.AfficherInfosCD();
            Console.WriteLine();

            Console.WriteLine("Nombre d'exemplaires disponibles pour chaque média :");
            Console.WriteLine($"Livre - {livre.titre} : {livre.nombreExemplairesDisponibles} exemplaires disponibles");
            Console.WriteLine($"DVD - {dvd.titre} : {dvd.nombreExemplairesDisponibles} exemplaires disponibles");
            Console.WriteLine($"CD - {cd.titre} : {cd.nombreExemplairesDisponibles} exemplaires disponibles");

        }
    }
}
