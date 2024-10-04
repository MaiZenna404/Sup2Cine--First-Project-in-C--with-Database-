using System.Data;
using MySqlConnector;

namespace DbManager
{

    public class DatabaseManager
    {

        private MySqlConnection connection;

        public async Task Connect()
        {
            // Connect to the database
            var builder = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                UserID = "root",
                Password = "",
                Database = "sup2cine",
            };

            // open a connection asynchronously
            connection = new MySqlConnection(builder.ConnectionString);
            await connection.OpenAsync();
            Console.WriteLine("Connexion avec la database OK !");
        }

        // Ajouter un film dans la table film : 
        public void AddFilmToDb(int idFilm, string titreDuFilm, string description, string realisateur, string dureeDuFilm)
        {
            // Requête pour ajouter un spectateur de la table "spectateur" :
            using var command2 = connection.CreateCommand();
            command2.CommandText = @"INSERT INTO `film`(`id_film`, `titre`, `description`, `realisateur`, `duree_du_film`) VALUES (@id_film, @titre, @description, @realisateur, duree_du_film)";
            command2.Parameters.AddWithValue("@id_film", idFilm);
            command2.Parameters.AddWithValue("@titre", titreDuFilm);
            command2.Parameters.AddWithValue("@description", description);
            command2.Parameters.AddWithValue("@realisateur", realisateur);
            command2.Parameters.AddWithValue("@duree_du_film", dureeDuFilm);
            command2.ExecuteNonQuery();
            Console.WriteLine("Film inséré dans la base !");
        }



        // Insérer un spectateur dans la table "spectateur" :
        public void AddSpectateurToDb(int id_spectateur, string nom, string prenom, string statut)
        {
            // Requête pour ajouter un spectateur de la table "spectateur" :
            using var command2 = connection.CreateCommand();
            command2.CommandText = @"INSERT INTO `spectateurs`(`id_spectateur`, `nom`, `prenom`, `statut`) VALUES (@id_spectateur, @nom, @prenom, @statut)";
            command2.Parameters.AddWithValue("@id_spectateur", id_spectateur);
            command2.Parameters.AddWithValue("@nom", nom);
            command2.Parameters.AddWithValue("@prenom", prenom);
            command2.Parameters.AddWithValue("@statut", statut);
            command2.ExecuteNonQuery();
            Console.WriteLine("Spectateur inséré dans la base !");
        }

        // Supprimer un spectateur de la table spectateur :
        public void DeleteSpectatorFromDB(string deleteSpectateur)
        {

            // Requête pour supprimer un spectateur de la table "spectateur" :
            using var command2 = connection.CreateCommand(); command2.Parameters.AddWithValue("@nom", deleteSpectateur);
            command2.CommandText = @"DELETE FROM `spectateurs` WHERE nom = @nom";

            command2.ExecuteNonQuery();
            Console.WriteLine("Vous avez bien supprimé votre spectateur de la base.");
        }

        // Insérer une séance dans la table "liste_seance" :
        public void AddSeanceToDb(string nom_cinema, int num_salle, int num_seance, string heure_debut, string acces_seance, int id_film)

        {
            // Requête pour insérer une seance dans la table "liste_seance" :
            using var command2 = connection.CreateCommand();
            command2.CommandText = @"INSERT INTO `liste_seance`(`nom_cinema`, `num_salle`, `num_seance`, `heure_debut`, `acces_seance`, `id_film`) VALUES (@nom_cinema, @num_salle, @num_seance, @heure_debut, @acces_seance, @id_film)";
            command2.Parameters.AddWithValue("@nom_cinema", nom_cinema);
            command2.Parameters.AddWithValue("@num_salle", num_salle);
            command2.Parameters.AddWithValue("@num_seance", num_seance);
            command2.Parameters.AddWithValue("@heure_debut", heure_debut);
            command2.Parameters.AddWithValue("@acces_seance", acces_seance);
            command2.Parameters.AddWithValue("@id_film", id_film);
            command2.ExecuteNonQuery();
            Console.WriteLine("Séance insérée dans la base !");
        }

        // Insérer une VIP dans la table "liste_seanceVIP":

        public void AddSeanceVIPToDb(string nom_cinema, int num_salle, int num_seance, string heure_debut, int id_film)

        {
            // Requête pour insérer une seance dans la table "liste_seance" :
            using var command2 = connection.CreateCommand();
            command2.CommandText = @"INSERT INTO `liste_seancevip`(`id_film`, `num_seance`, `num_salle`, `nom_cinema`, `heure_debut`) VALUES (@id_film, @num_seance,@num_salle, @nom_cinema, @heure_debut)";
            command2.Parameters.AddWithValue("@nom_cinema", nom_cinema);
            command2.Parameters.AddWithValue("@num_salle", num_salle);
            command2.Parameters.AddWithValue("@num_seance", num_seance);
            command2.Parameters.AddWithValue("@heure_debut", heure_debut);
            command2.Parameters.AddWithValue("@id_film", id_film);
            command2.ExecuteNonQuery();
            Console.WriteLine("Séance VIP insérée dans la base !");
        }

        // Insérer un spectateur avec sa séance dans la table "seance" :
        public void AddSpectateurToSeanceDb(string nomCinemaSeance, int numSalleSeance, int numDeSeance, string heureDebutSeance, string accesSeance, int idFilmSeance, int id_spectateurSeance)
        {
            // Requête pour insérer un spectateur VIP dans la table "spectateur" :
            using var command2 = connection.CreateCommand();
            command2.CommandText = @"INSERT INTO `seance`(`nom_cinema`, `num_salle`, `num_seance`, `heure_debut`, `acces_seance`, `id_film`, `id_spectateur`) VALUES (@nom_cinema, @num_salle, @num_seance, @heure_debut, @acces_seance, @id_film, @id_spectateur)";

            command2.Parameters.AddWithValue("@nom_cinema", nomCinemaSeance);
            command2.Parameters.AddWithValue("@num_salle", numSalleSeance);
            command2.Parameters.AddWithValue("@num_seance", numDeSeance);
            command2.Parameters.AddWithValue("@heure_debut", heureDebutSeance);
            command2.Parameters.AddWithValue("@acces_seance", accesSeance);
            command2.Parameters.AddWithValue("@id_film", idFilmSeance);
            command2.Parameters.AddWithValue("@id_spectateur", id_spectateurSeance);

            command2.ExecuteNonQuery();
            Console.WriteLine("Spectateur avec sa séance insérée dans la base !");
        }

        public void AddSpectateurToSeanceVIPDb(string nomCinemaSeance, int numSalleSeance, int numDeSeance, string heureDebutSeance, string accesSeance, int idFilmSeance, int id_spectateurSeance)
        {
            // Requête pour insérer un spectateur VIP dans la table "spectateur" :
            using var command2 = connection.CreateCommand();
            command2.CommandText = @"INSERT INTO `seance_vip`(`id_spectateur`, `acces_seance`, `num_seance`, `id_film`, `nom_cinema`) VALUES (@id_spectateur, @acces_seance, @num_seance, @id_film, @nom_cinema)";

            command2.Parameters.AddWithValue("@nom_cinema", nomCinemaSeance);
            command2.Parameters.AddWithValue("@num_salle", numSalleSeance);
            command2.Parameters.AddWithValue("@num_seance", numDeSeance);
            command2.Parameters.AddWithValue("@heure_debut", heureDebutSeance);
            command2.Parameters.AddWithValue("@acces_seance", accesSeance);
            command2.Parameters.AddWithValue("@id_film", idFilmSeance);
            command2.Parameters.AddWithValue("@id_spectateur", id_spectateurSeance);

            command2.ExecuteNonQuery();
            Console.WriteLine("Spectateur avec sa séance VIP insérée dans la base !");
        }

        public void DeleteSpectatorToSeanceFromDb(string deleteSpectateurFromSeanceDb)
        {

            // Insérer un spectateur avec sa séance dans la table "seance" :
            using var command2 = connection.CreateCommand(); command2.Parameters.AddWithValue("@deleteSpectateurFromSeanceDb", deleteSpectateurFromSeanceDb);
            command2.CommandText = @"DELETE FROM `seance` WHERE id_spectateur = @deleteSpectateurFromSeanceDb";

            command2.ExecuteNonQuery();
            Console.WriteLine("\nVous avez bien supprimé votre spectateur et sa séance de la base.");
        }

        // Insérer un spectateur VIP dans sa séance VIP dans la table "seance_vip" :
        
        public void DeleteVIPToSeanceVIPFromDb(string idSpectateurVip)
        {
            // Requête pour insérer un spectateur VIP dans sa séance VIP dans la table "seance_VIP" :
            using var command2 = connection.CreateCommand();
            command2.CommandText = @"DELETE FROM `seance_vip` WHERE id_spectateur = @deleteVipName";
            command2.Parameters.AddWithValue("@deleteVipName", idSpectateurVip);
            
            command2.ExecuteNonQuery();
            Console.WriteLine("Spectateur et sa séance VIP correspondante ont bien été supprimé de la base !");
        }
    
        // Voir les infos d'un film :
        public List<string> VoirFilm(string titre)
        {
            List<string> detailsFilm = new List<string>();


            using var command = connection.CreateCommand();
            command.Parameters.AddWithValue("@titre", titre);
            command.CommandText = @"SELECT * FROM `film` WHERE titre = @titre";

            using var reader = command.ExecuteReader();

            if (reader.HasRows) // Vérfie si la Db retourne bien un ou plusieurs résultats
            {
                Console.WriteLine("Le film existe bien"); // Message qui apparaît si y'a des résultats
                while (reader.Read())
                {
                    string details = reader.GetString(2); // Prendre la string de la colonne 2 (= description) qui est de type VarChar
                    Console.WriteLine($"Voici le synopsis du film que vous cherchez : {details}");
                }
            }
            else
            {
                Console.WriteLine("Le film n'existe pas");
            }

            reader.Close();
            return detailsFilm;
        }

        // Voir les infos d'une seance :
        public List<string> VoirInfosSeance(int numeroSeance)
        {
            List<string> detailsSeance = new List<string>();


            using var command = connection.CreateCommand();
            command.Parameters.AddWithValue("@numeroSeance", numeroSeance);
            command.CommandText = @"SELECT * FROM `film` WHERE num_seance = @numeroSeance";

            using var reader = command.ExecuteReader();

            if (reader.HasRows) // Vérfie si la Db retourne bien un ou plusieurs résultats
            {
                Console.WriteLine("Le film existe bien"); // Debug statement to verify rows are found
                while (reader.Read())
                {
                    string details = reader.GetString(0);
                    detailsSeance.Add(details);
                }
            }
            else
            {
                Console.WriteLine("La séance que vous cherchez n'est pas encore programmée");
            }

            reader.Close();
            return detailsSeance;
        }

        // Voir si une réservation a bien été faite

        public void VerifierReservationSeance(string nomSpectateur)
        {

            using var command = connection.CreateCommand();
            command.Parameters.AddWithValue("@nomSpectateur", nomSpectateur);
            // Requête avec jointure pour que le client puisse retrouver dans quelle séance il a réservé en tapant son nom
            command.CommandText = "SELECT * FROM seance INNER JOIN spectateurs ON seance.id_spectateur = spectateurs.id_spectateur WHERE spectateurs.nom = @nomSpectateur";

            using var reader = command.ExecuteReader();

            if (reader.HasRows) // Vérfie si la Db retourne bien un ou plusieurs résultats
            {
                Console.WriteLine("Requête dans la database réussie !"); // Debug statement to verify rows are found
                while (reader.Read())
                {
                    string details = reader.GetString(0);
                    Console.WriteLine("Vous avez bien réservé !");
                }
            }
            else
            {
                Console.WriteLine("Il n'y a aucune réservation à votre nom.");
            }

            reader.Close();
        }
        public List<string> VoirSynopsis(string rechercheFilm)
        {
            List<string> synopsis = new List<string>();


            using var command = connection.CreateCommand();
            command.Parameters.AddWithValue("@rechercheFilm", rechercheFilm);
            command.CommandText = @"SELECT  `description` FROM `film` WHERE titre = @rechercheFilm";

            using var reader = command.ExecuteReader();

            if (reader.HasRows) // Vérfie si la Db retourne bien un ou plusieurs résultats
            {
                Console.WriteLine("Voici le synopsis du film recherché :\n"); // Debug statement to verify rows are found
                while (reader.Read())
                {
                    string descriptionFilm = reader.GetString(0);
                    Console.WriteLine(descriptionFilm);
                }
            }
            else
            {
                Console.WriteLine("Infos indisponible ou bien le film n'est pas encore programmé.");
            }

            reader.Close();
            return synopsis;
        }
    }




}
