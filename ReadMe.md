## Projet Exam C# ##

### Solution proposé : ## 
 
 => Système de gestion des séances, avec les spectateurs, VIP ou non. 
=> Dans cette solution, il y a 3 utilisateurs possibles : Manager - Staff (employé lambda) - Spectateur; chacun d'entre eux a un rayon d'action différents : 

#### Manager :
=> Peut ajouter de nouvelles séances dans la BDD (VIP ou normales)
=> Peut enlever des séances dans la BDD (VIP ou Normales)
=> Est le seul à pouvoir ajouter (et supprimer) des nouveaux spectateurs dans la liste regroupant TOUS les spectateurs. 
=> Peut ajouter de nouveaux films dans la BDD et voir le synopsis de ces films.

#### Staff :
=> Peut ajouter des spectateurs à des séances VIP ou non 
=> Peut supprimer aussi supprimer des spectateurs à des séances VIP ou non 
=> Voir les infos d'une séances (nb : Test non réalisé sur cette fonctionnalité)

#### Spectateur : 
=> Vérifier s'il existe dans la base (= donc s'il a réservé ou non).
=> Voir le synopsis d'un film (et savoir s'il existe ou non).

### Axes d'amléioration si j'avais eu plus de temps : 
=> Faire 3 classes (Manager, Staff, Spectateur) et regrouper les champs d'actions de chacun pour optimiser le code dans Program.cs
=> Mieux réfléchir à la BDD, les clés primaires, les clés étrangères afin de faire des requêtes les plus optimisés possible (ex : éviter les doublons dans les champs qui ne doivent pas en avoir, trouver facilement les infos grâce à des jointures, etc. )

