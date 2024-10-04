-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1
-- Généré le : ven. 04 oct. 2024 à 16:03
-- Version du serveur : 10.4.32-MariaDB
-- Version de PHP : 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `sup2cine`
--

-- --------------------------------------------------------

--
-- Structure de la table `cinema`
--

CREATE TABLE `cinema` (
  `nom_cinema` varchar(50) NOT NULL,
  `localisation` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `cinema`
--

INSERT INTO `cinema` (`nom_cinema`, `localisation`) VALUES
('Grand Rex', 'Paris'),
('Pathé Nice', 'Nice'),
('UGC Bordeaux', 'Bordeaux');

-- --------------------------------------------------------

--
-- Structure de la table `film`
--

CREATE TABLE `film` (
  `id_film` int(10) NOT NULL,
  `titre` varchar(100) NOT NULL,
  `description` text NOT NULL,
  `realisateur` varchar(100) NOT NULL,
  `duree_du_film` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `film`
--

INSERT INTO `film` (`id_film`, `titre`, `description`, `realisateur`, `duree_du_film`) VALUES
(1, 'E.T', 'Un extraterrestre atterit sur Terre et fait du v\0lo devant la pleine lune en pleine nuit. ', 'Steven Spielberg', ''),
(2, 'Il faut sauver le soldat Ryan', 'En plein Seconde Guerre Mondiale, un groupe de soldats tentent de trouver un soldat nomm\0 Ryan...', 'Steven Spielberg', '');

-- --------------------------------------------------------

--
-- Structure de la table `liste_seance`
--

CREATE TABLE `liste_seance` (
  `nom_cinema` varchar(50) NOT NULL,
  `num_salle` int(3) NOT NULL,
  `num_seance` int(3) NOT NULL,
  `heure_debut` varchar(25) NOT NULL,
  `acces_seance` varchar(50) NOT NULL,
  `id_film` int(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `liste_seance`
--

INSERT INTO `liste_seance` (`nom_cinema`, `num_salle`, `num_seance`, `heure_debut`, `acces_seance`, `id_film`) VALUES
('Grand Rex', 12, 15468, '15h05', 'public', 1);

-- --------------------------------------------------------

--
-- Structure de la table `liste_seancevip`
--

CREATE TABLE `liste_seancevip` (
  `id_film` int(15) NOT NULL,
  `num_seance` int(3) NOT NULL,
  `num_salle` int(10) NOT NULL,
  `nom_cinema` varchar(50) NOT NULL,
  `heure_debut` varchar(25) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `liste_seancevip`
--

INSERT INTO `liste_seancevip` (`id_film`, `num_seance`, `num_salle`, `nom_cinema`, `heure_debut`) VALUES
(1, 159875, 25, 'UGC Bordeaux', '19h45'),
(2, 15879, 15, 'UGC Bordeaux', '21h00');

-- --------------------------------------------------------

--
-- Structure de la table `seance`
--

CREATE TABLE `seance` (
  `nom_cinema` varchar(50) NOT NULL,
  `num_salle` int(3) NOT NULL,
  `num_seance` int(3) NOT NULL,
  `heure_debut` varchar(25) NOT NULL,
  `acces_seance` varchar(50) NOT NULL DEFAULT 'public',
  `id_film` int(15) NOT NULL,
  `id_spectateur` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `seance`
--

INSERT INTO `seance` (`nom_cinema`, `num_salle`, `num_seance`, `heure_debut`, `acces_seance`, `id_film`, `id_spectateur`) VALUES
('Grand Rex', 5, 56985, '19h45', 'public', 2, 3),
('Grand Rex', 5, 56985, '19h45', 'public', 2, 1);

-- --------------------------------------------------------

--
-- Structure de la table `seance_vip`
--

CREATE TABLE `seance_vip` (
  `id_spectateur` int(11) NOT NULL,
  `acces_seance` varchar(50) NOT NULL,
  `num_seance` int(3) NOT NULL,
  `id_film` int(15) NOT NULL,
  `nom_cinema` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `seance_vip`
--

INSERT INTO `seance_vip` (`id_spectateur`, `acces_seance`, `num_seance`, `id_film`, `nom_cinema`) VALUES
(1, 'VIP', 15879, 2, 'UGC Bordeaux');

-- --------------------------------------------------------

--
-- Structure de la table `spectateurs`
--

CREATE TABLE `spectateurs` (
  `id_spectateur` int(11) NOT NULL,
  `nom` varchar(50) NOT NULL,
  `prenom` varchar(50) NOT NULL,
  `statut` varchar(25) NOT NULL DEFAULT 'nonVIP'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `spectateurs`
--

INSERT INTO `spectateurs` (`id_spectateur`, `nom`, `prenom`, `statut`) VALUES
(1, 'Dadi', 'Yusr', 'VIP'),
(3, 'Paul', 'Jean', 'NonVIP'),
(4, 'Maitre', 'An\0mone', 'VIP');

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `cinema`
--
ALTER TABLE `cinema`
  ADD PRIMARY KEY (`nom_cinema`);

--
-- Index pour la table `film`
--
ALTER TABLE `film`
  ADD PRIMARY KEY (`id_film`);

--
-- Index pour la table `liste_seance`
--
ALTER TABLE `liste_seance`
  ADD PRIMARY KEY (`nom_cinema`,`num_salle`),
  ADD UNIQUE KEY `num_seance` (`num_seance`),
  ADD UNIQUE KEY `id_film` (`id_film`);

--
-- Index pour la table `liste_seancevip`
--
ALTER TABLE `liste_seancevip`
  ADD UNIQUE KEY `id_film` (`id_film`),
  ADD UNIQUE KEY `num_seance` (`num_seance`);

--
-- Index pour la table `spectateurs`
--
ALTER TABLE `spectateurs`
  ADD PRIMARY KEY (`id_spectateur`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `film`
--
ALTER TABLE `film`
  MODIFY `id_film` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT pour la table `spectateurs`
--
ALTER TABLE `spectateurs`
  MODIFY `id_spectateur` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
