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
        public void DeleteVisitor(string deleteSpectateur)
        {

            // Requête pour supprimer un spectateur de la table "spectateur" :
            using var command2 = connection.CreateCommand(); command2.Parameters.AddWithValue("@nom", deleteSpectateur);
            command2.CommandText = @"DELETE FROM `spectateurs` WHERE nom = @nom";

            command2.ExecuteNonQuery();
            Console.WriteLine("Vous avez bien supprimé votre spectateur de la base.");
        }
        // Insérer une séance dans la table "liste_seance" :
        public void AddSeanceToDb(int nom_cinema, string num_salle, string num_seance, string heure_debut, string acces_seance, int id_film)
        {
            // Requête pour insérer un spectateur VIP dans la table "spectateur" :
            using var command2 = connection.CreateCommand();
            command2.CommandText = @"INSERT INTO `liste_seance`(`nom_cinema`, `num_salle`, `num_seance`, `heure_debut`, `acces_seance`, `id_film`) VALUES (@nom_cinema, @num_salle, @num_seance, @heure_debut, @acces_seance, @id_film)";
            command2.Parameters.AddWithValue("@id_spectateur", nom_cinema);
            command2.Parameters.AddWithValue("@nom", num_salle);
            command2.Parameters.AddWithValue("@nom", num_seance);
            command2.Parameters.AddWithValue("@prenom", heure_debut);
            command2.Parameters.AddWithValue("@statut", acces_seance);
            command2.Parameters.AddWithValue("@statut", id_film);
            command2.ExecuteNonQuery();
            Console.WriteLine("Séance insérée dans la base !");
        }

        // Insérer un spectateur avec sa séance dans la table "seance" :
        public void AddSpectateurToSeanceDb(int nom_cinema, string num_salle, string num_seance, string heure_debut, string acces_seance, int id_film, int id_spectateur)
        {
            // Requête pour insérer un spectateur VIP dans la table "spectateur" :
            using var command2 = connection.CreateCommand();
            command2.CommandText = @"INSERT INTO `liste_seance`(`nom_cinema`, `num_salle`, `num_seance`, `heure_debut`, `acces_seance`, `id_film`, `id_spectateur`) VALUES (@nom_cinema, @num_salle, @num_seance, @heure_debut, @acces_seance, @id_film, @id_spectateur)";
            command2.Parameters.AddWithValue("@nom_cinema", nom_cinema);
            command2.Parameters.AddWithValue("@num_salle", num_salle);
            command2.Parameters.AddWithValue("@num_seance", num_seance);
            command2.Parameters.AddWithValue("@heure_debut", heure_debut);
            command2.Parameters.AddWithValue("@acces_seance", acces_seance);
            command2.Parameters.AddWithValue("@id_film", id_film);
            command2.Parameters.AddWithValue("@id_spectateur", id_spectateur);
            command2.ExecuteNonQuery();
            Console.WriteLine("Spectateur avec sa séance insérée dans la base !");
        }

        // Insérer un spectateur VIP dans la table "spectateur" :
        /*
        public void AddVIPToSeanceVIPToDb(int id_spectateurVIP, string nomVIP, string prenomVIP, string statutVIP)
        {
            // Requête pour insérer un spectateur VIP dans la table "spectateur" :
            using var command2 = connection.CreateCommand();
            command2.CommandText = @"INSERT INTO `seance_vip`(`id_spectateur`, `statut`, `acces_seance`, `num_seance`, `id_film`) VALUES (@id_spectateur, @statut, @acces_seance, @num_seance, @id_film)";
            command2.Parameters.AddWithValue("@id_spectateur", id_spectateurVIP);
            command2.Parameters.AddWithValue("@nom", nomVIP);
            command2.Parameters.AddWithValue("@prenom", prenomVIP);
            command2.Parameters.AddWithValue("@statut", statutVIP);
            command2.ExecuteNonQuery();
            Console.WriteLine("Spectateur inséré dans sa séance VIP insérée dans la base !");
        }
    */



    }
}
