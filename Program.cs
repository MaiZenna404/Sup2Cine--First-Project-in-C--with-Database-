// Connexion à la BDD

using DbManager;

DatabaseManager dbPath = new DatabaseManager();
await dbPath.Connect();

Console.WriteLine("Bienvenue sur la plateforme Sup2Cine, tout d'abord, qui êtes-vous ? \n - Manager \n - Staff \n - Spectateur");
string userChoice = Console.ReadLine();

switch (userChoice)
{
    case "Manager":
        Console.WriteLine("Bonjour, que souhaitez-vous faire ? \n");
        Console.WriteLine("- Ajouter un nouveau spectateur à une séance\n - Supprimer un spectateur d'une séance\n - Ajouter une séance \n - Ajouter une séance VIP");
        string managerChoice = Console.ReadLine();

        if (managerChoice == "Ajouter un nouveau spectateur à une séance")
        {
            Console.WriteLine("Quel est l'id du spectateur : ");
            int id_spectateur = int.Parse(Console.ReadLine());
            Console.WriteLine("Son nom : ");
            string nom = Console.ReadLine();
            Console.WriteLine("Son prénom : ");
            string prenom = Console.ReadLine();
            Console.WriteLine("Est-il VIP ou non ? ");
            string statut = Console.ReadLine();

            // Appel de la méthode AddSpectateurToDb
            dbPath.AddSpectateurToDb(id_spectateur, nom, prenom, statut);

        }
        else if (managerChoice == "Supprimer un spectateur d'une séance")
        {
            Console.WriteLine("Veuillez saisir le nom du spectateur que vous souhaitez supprimer : ");
            string deleteSpectateur = Console.ReadLine();
            dbPath.DeleteVisitor(deleteSpectateur);
        }

        else if (managerChoice == "Ajouter une séance VIP")
        {
        
        }

        else if (managerChoice == "Ajouter une séance" ){

        }

        else if (managerChoice == "Voir les infos d'une séance"){
            // Ajouter une condition afin de vérifier si le spectateur est VIP ou non 
        }

    break;
}