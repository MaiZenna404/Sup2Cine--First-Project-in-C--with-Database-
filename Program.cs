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
        Console.WriteLine("- 1. Ajouter un nouveau spectateur dans la base\n - 2. Supprimer un spectateur de la base\n - 3. Ajouter une séance normale dans la liste \n - 4. Ajouter une séance VIP dans la liste \n 5. Ajouter un nouveau film \n - 6. Savoir si un film existe et ses infos");
        int managerChoice = int.Parse(Console.ReadLine());

        if (managerChoice == 1)
        {
            Console.WriteLine("Quel est l'id du spectateur : ");
            int id_spectateur = int.Parse(Console.ReadLine());
            Console.WriteLine("Son nom : ");
            string nom = Console.ReadLine();
            Console.WriteLine("Son prénom : ");
            string prenom = Console.ReadLine();
            Console.WriteLine("Est-il VIP ou non ? (Saisir 'VIP ou 'NonVIP')");
            string statut = Console.ReadLine();

            // Appel de la méthode AddSpectateurToDb
            dbPath.AddSpectateurToDb(id_spectateur, nom, prenom, statut);

        }
        // Test : OK
        else if (managerChoice == 2)
        {
            Console.WriteLine("Veuillez saisir le nom du spectateur que vous souhaitez supprimer : ");
            string deleteSpectateur = Console.ReadLine();
            dbPath.DeleteSpectatorFromDB(deleteSpectateur);
        }
        // Test : Ok

        else if (managerChoice == 3)
        {
            Console.WriteLine("Veuillez saisir le nom du cinéma où se déroule la séance : ");
            string nom_cinema = Console.ReadLine();
            Console.WriteLine("Veuillez saisir le numéro de la salle où se déroule la séance : ");
            int num_salle = int.Parse(Console.ReadLine());
            Console.WriteLine("Veuillez saisir le numéro de la séance : ");
            int num_seance = int.Parse(Console.ReadLine());
            Console.WriteLine("Veuillez saisir l'heure de début de la séance : ");
            string heure_debut = Console.ReadLine();
            Console.WriteLine("Veuillez saisir qui a accès à la séance : ");
            string acces_seance = Console.ReadLine();
            Console.WriteLine("Veuillez saisir l'id du film qui sera projeté' : ");
            int id_film = int.Parse(Console.ReadLine());
            // Appel de la fonction AddSeanceToDb
            dbPath.AddSeanceToDb(nom_cinema, num_salle, num_seance, heure_debut, acces_seance, id_film);
        }
        // Test : Ok

         else if (managerChoice == 4)
        {
            Console.WriteLine("Quel est le nom du cinéma où est proposé la séance VIP ?");
            string nom_cinema = Console.ReadLine();
            Console.WriteLine("Quel est le numéro de la salle VIP ?");
            int num_salle = int.Parse(Console.ReadLine());
            Console.WriteLine("Quel est le matricule de la séance VIP ?");
            int num_seance = int.Parse(Console.ReadLine());
            Console.WriteLine("L'heure de début de la séance ?");
            string heure_debut = Console.ReadLine();
            Console.WriteLine("L'ID du Film projeté ?");
            int id_film = int.Parse(Console.ReadLine());
            // Appel de la méthode AddSeanceVIPToDb()
            dbPath.AddSeanceVIPToDb(nom_cinema, num_salle, num_seance, heure_debut, id_film);
        }
        // Test : Ok
        else if (managerChoice == 5){
             Console.WriteLine("Saisissez l'Id du film ");
            int idFilm = int.Parse(Console.ReadLine());
             Console.WriteLine("Saisissez le titre du film : ");
            string titreDuFilm = Console.ReadLine();
             Console.WriteLine("Saississez le synopsis du film : ");
            string description = Console.ReadLine();
             Console.WriteLine("Veuillez saisir le réalisateur : ");
            string realisateur = Console.ReadLine();
             Console.WriteLine("Quelle est la durée du Film ? ");
            string dureeDuFilm = Console.ReadLine();
            // Appel de la méthode AddFilmToDb()
            dbPath.AddFilmToDb(idFilm, titreDuFilm, description, realisateur, dureeDuFilm);
            
        }
        //Test : Ok
        else if (managerChoice == 6)
        {
            Console.WriteLine("Veuillez saisir le nom du film que vous cherchez : ");
            string titre = Console.ReadLine();
            dbPath.VoirFilm(titre);
        }
        // Test : à moitié OK => if(reader.HasRows) fonctionne mais la description ne s'affiche pas...
        break;

    case "Staff":
        Console.WriteLine("Bonjour, que souhaitez-vous faire ? \n");
        Console.WriteLine("1.Ajouter un nouveau spectateur à une séance normale\n 2. Ajouter un nouveau spectateur à une séance VIP\n 3. Supprimer un spectateur d'une séance normale\n 4. Supprimer un spectateur d'une séance VIP\n 5. Voir les infos d'une seance");
        int staffChoice = int.Parse(Console.ReadLine());

        if (staffChoice == 1)
        {

            Console.WriteLine("Veuillez saisir le nom du cinéma où se déroule la séance : ");
            string nomCinemaSeance = Console.ReadLine();
            Console.WriteLine("Veuillez saisir le numéro de la salle de la séance : ");
            int numSalleSeance = int.Parse(Console.ReadLine());
            Console.WriteLine("Veuillez saisir le matricule de la séance : ");
            int numDeSeance = int.Parse(Console.ReadLine());
    Console.WriteLine("Quelle est l'heure de début de la séance ?");
            string heureDebutSeance = Console.ReadLine();
            Console.WriteLine("Qui a accès à cette séance ? (public ou VIP ?)");
            string accesSeance = Console.ReadLine();
            Console.WriteLine("Quel est l'ID du film projeté ?");
            int idFilmSeance = int.Parse(Console.ReadLine());
            Console.WriteLine("Quel spectateur voulez-vous affecter à cette séance ?");
            int id_spectateurSeance = int.Parse(Console.ReadLine());

            dbPath.AddSpectateurToSeanceDb(nomCinemaSeance, numSalleSeance, numDeSeance, heureDebutSeance, accesSeance, idFilmSeance, id_spectateurSeance);
        }
        // Test : Ok (mais à conditions d'enlever les conditions foreign keys)

        else if (staffChoice == 2){
            Console.WriteLine("A quel cinéma se déroule la séance VIP ?");
            string nomCinemaSeance = Console.ReadLine();
             Console.WriteLine("Quel est l'ID du spectateur que vous voulez affecter à cette séance ?");
            int id_spectateurSeance = int.Parse(Console.ReadLine());
            Console.WriteLine("Quelle est la matricule de la séance ?");
            int numDeSeance = int.Parse(Console.ReadLine());
            Console.WriteLine("Quelle est l'heure de début de séance ?");
            string heureDebutSeance = Console.ReadLine();
            Console.WriteLine("Qui a accès à la séance ?");
            string accesSeance = Console.ReadLine();
            Console.WriteLine("Quel est l'ID du film de la séance ?");
            int idFilmSeance = int.Parse(Console.ReadLine());
            Console.WriteLine("Quel est le numéro de la salle ?");
            int numSalleSeance = int.Parse(Console.ReadLine());

            dbPath.AddSpectateurToSeanceVIPDb(nomCinemaSeance, numSalleSeance, numDeSeance, heureDebutSeance, accesSeance, idFilmSeance, id_spectateurSeance);
        }
        // Test : OK

        else if (staffChoice == 3)
        {
            Console.WriteLine("Veuillez saisir l'id du spectateur que vous voulez supprimer : ");
            string deleteSpectateurFromSeanceDb = Console.ReadLine();

            // Appel de la méthode DeleteSpectatorToSeanceFromDb
            dbPath.DeleteSpectatorToSeanceFromDb(deleteSpectateurFromSeanceDb);
        }
        // Test : Ok

        else if(staffChoice == 4){
            Console.WriteLine("Quel est l'ID du spectateur VIP que vous voulez supprimer ?");
            string idSpectateurVip = Console.ReadLine();
            dbPath.DeleteVIPToSeanceVIPFromDb(idSpectateurVip);
        }
        // Test : Ok

        else if (staffChoice == 5)
        {
            Console.WriteLine("Veuillez saisir le numéro de la séance que vous voulez regarder : ");
            int numeroSeance = int.Parse(Console.ReadLine());

            // Appel de la méthode VoirInfosSeance()
            dbPath.VoirInfosSeance(numeroSeance);
        }
        // Test : à faire
        break;

    case "Spectateur":
        Console.WriteLine("Bienvenue sur notre plateforme cher spectateur ! Que souhaitez-vous faire ?");
        Console.WriteLine("1. Vérifier ma réservation \n 2. Voir le synopsis d'un film \n ");
        int viewerChoice = int.Parse(Console.ReadLine());

        if (viewerChoice == 1)
        {
            Console.WriteLine("A quel nom avez-vous effectué la réservation ? : ");
            string nomSpectateur = Console.ReadLine();
            // Appel de la méthode VerifierReservationSeance()
            dbPath.VerifierReservationSeance(nomSpectateur);
        }
        // Test : Ok

        else if (viewerChoice == 2)
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