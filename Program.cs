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
        Console.WriteLine("- Ajouter un nouveau spectateur dans la base\n - Supprimer un spectateur de la base\n - Ajouter une séance normale dans la liste \n - Ajouter une séance VIP dans la liste \n - Voir les infos d'un film");
        string managerChoice = Console.ReadLine();

        if (managerChoice == "Ajouter un nouveau spectateur à la base")
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
        else if (managerChoice == "Supprimer un spectateur de la base")
        {
            Console.WriteLine("Veuillez saisir le nom du spectateur que vous souhaitez supprimer : ");
            string deleteSpectateur = Console.ReadLine();
            dbPath.DeleteSpectatorFromDB(deleteSpectateur);
        }

        /* else if (managerChoice == "Ajouter une séance VIP dans la liste")
        {
        
        }
        */

        else if (managerChoice == "Ajouter une séance normale dans la liste")
        {
            Console.WriteLine("Veuillez saisir le nom du cinéma où se déroule la séance : ");
            string nom_cinema = Console.ReadLine();
            Console.WriteLine("Veuillez saisir le nom du cinéma où se déroule la séance : ");
            int num_salle = int.Parse(Console.ReadLine());
            Console.WriteLine("Veuillez saisir le nom du cinéma où se déroule la séance : ");
            int num_seance = int.Parse(Console.ReadLine());
            Console.WriteLine("Veuillez saisir le nom du cinéma où se déroule la séance : ");
            string heure_debut = Console.ReadLine();
            Console.WriteLine("Veuillez saisir le nom du cinéma où se déroule la séance : ");
            string acces_seance = Console.ReadLine();
            Console.WriteLine("Veuillez saisir le nom du cinéma où se déroule la séance : ");
            int id_film = int.Parse(Console.ReadLine());
            // Appel de la fonction 
            dbPath.AddSeanceToDb(nom_cinema, num_salle, num_seance, heure_debut, acces_seance, id_film);
        }

        else if (managerChoice == "Voir les infos d'un film")
        {
            Console.WriteLine("Veuillez saisir le nom du film que vous chezchez : ");
            string titre = Console.ReadLine();
            dbPath.VoirFilm(titre);
        }

        break;

    case "Staff":
        Console.WriteLine("Bonjour, que souhaitez-vous faire ? \n");
        Console.WriteLine("- Ajouter un nouveau spectateur à une séance\n - Supprimer un spectateur d'une séance\n - Voir les infos d'une seance");
        string staffChoice = Console.ReadLine();

        if (staffChoice == "Ajouter un nouveau spectateur à une séance")
        {

            Console.WriteLine("Veuillez saisir le nom du cinéma où se déroule la séance : ");
            string nomCinemaSeance = Console.ReadLine();
            Console.WriteLine("Veuillez saisir le numéro de la salle de la séance : ");
            int numSalleSeance = int.Parse(Console.ReadLine());
            Console.WriteLine("Veuillez saisir le nom du cinéma où se déroule la séance : ");
            int numDeSeance = int.Parse(Console.ReadLine());

            string heureDebutSeance = Console.ReadLine();
            string accesSeance = Console.ReadLine();
            int idFilmSeance = int.Parse(Console.ReadLine());
            int id_spectateurSeance = int.Parse(Console.ReadLine());

            dbPath.AddSpectateurToSeanceDb(nomCinemaSeance, numSalleSeance, numDeSeance, heureDebutSeance, accesSeance, idFilmSeance, id_spectateurSeance);
        }
        else if (staffChoice == "Supprimer un spectateur d'une séance")
        {
            Console.WriteLine("Veuillez saisir l'id du spectateur que vous voulez supprimer : ");
            string deleteSpectateurFromSeanceDb = Console.ReadLine();

            // Appel de la méthode DeleteSpectatorToSeanceFromDb
            dbPath.DeleteSpectatorToSeanceFromDb(deleteSpectateurFromSeanceDb);
        }

        else if (staffChoice == "Voir les infos d'une seance")
        {
            Console.WriteLine("Veuillez saisir le numéro de la séance que vous voulez regarder : ");
            int numeroSeance = int.Parse(Console.ReadLine());

            // Appel de la méthode VoirInfosSeance()
            dbPath.VoirInfosSeance(numeroSeance);
        }
        break;

    case "Spectateur":
        Console.WriteLine("Bienvenue sur notre plateforme cher spectateur ! Que souhaitez-vous faire ?");
        Console.WriteLine("- Vérifier ma réservation \n Voir le synopsis d'un film \n ");
        string viewerChoice = Console.ReadLine();

        if (viewerChoice == "Vérifier ma réservation")
        {
            Console.WriteLine("A quel nom avez-vous effectué la réservation ? : ");
            string nomSpectateur = Console.ReadLine();
            // Appel de la méthode VerifierReservationSeance()
            dbPath.VerifierReservationSeance(nomSpectateur);
        }

        else if (viewerChoice == "Voir le synopsis d'un film")
        {
            Console.WriteLine("Quel est le titre du film que vous recherchez ?");
            string rechercheFilm = Console.ReadLine();
            // Appel de la méthode VoirSynopsis()
            dbPath.VoirSynopsis(rechercheFilm);
        }

        break;

    default:

        Console.WriteLine("Désolé, vous devez saisir un des 3 choix au-dessus...");

        break;

}