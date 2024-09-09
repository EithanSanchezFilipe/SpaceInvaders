-- Explication de chaque requête

/*Requête numero 1: La première requête que l’on vous demande de réaliser est de sélectionner les 5 joueurs 
qui ont le meilleur score c’est-à-dire qui ont le nombre de points le plus élevé. Les joueurs 
doivent être classés dans l’ordre décroissant*/

SELECT * --Sélectionne tout
FROM `t_joueur` --De la table joueur
ORDER BY jouNombrePoints DESC --Le trie par ordre décroissant (Le meilleur en premier)
LIMIT 5; --Limite la reponse a 5

/*Trouver le prix maximum, minimum et moyen des armes.
Les colonnes doivent avoir pour nom « PrixMaximum », « PrixMinimum » et « PrixMoyen*/

SELECT MAX(armPrix) AS PrixMaximal, -- Sélectionne le prix max et le renomme
MIN(armPrix) AS PrixMinimum, -- Sélectionne le prix min et le renomme
AVG(armPrix) AS PrixMoyen -- Sélectionne le prix moyen et le renomme
FROM `t_arme`; -- De la table arme

/*Trouver le nombre total de commandes par joueur et trier du plus grand nombre au plus petit.
La 1ère colonne aura pour nom "IdJoueur", la 2ème colonne aura pour nom "NombreCommandes"*/

SELECT jo.idJoueur AS IdJoueur, -- Sélctionne l'id du joueur et le renomme
COUNT(co.fkJoueur) AS NombreCommandes -- Sélctionne le nombre de commandes et le renomme
FROM t_joueur jo, t_commande co -- De la table joueur et commande
GROUP BY co.fkJoueur --grouper les elements par joueur
ORDER BY IdJoueur DESC --Le trie par ordre décroissant (Le meilleur en premier)

/*Trouver les joueurs qui ont passé plus de 2 commandes.
La 1ère colonne aura pour nom "IdJoueur", la 2ème colonne aura pour nom 
"NombreCommandes"*/

SELECT fkJoueur AS IdJoueur, -- Sélctionne l'id du joueur et le renomme
COUNT(fkJoueur) AS NombreCommandes -- Sélctionne le nombre de commandes et le renomme
FROM t_commande -- De la table commande
GROUP BY fkJoueur --grouper les elements par joueur
HAVING NombreCommandes > 2 -- Condition qui sélectionne que les joueurs ayant passé plus de 2 commandes

--Trouver le pseudo du joueur et le nom de l'arme pour chaque commande.

SELECT jouPseudo, arm.armNom -- sélectionne le pseudo des joueurs et le nom d'armes
FROM t_joueur jo, t_commande co, t_detail_commande dc, t_arme arm -- De la table joueur, commande, detail_commande
WHERE idJoueur = co.fkJoueur AND dc.fkCommande = co.idCommande AND dc.fkArme = arm.idArme; -- Utilisé comme un join (combine des lignes de deux ou plusieurs tables en utilisant une condition commune)

/*Trouver le total dépensé par chaque joueur en ordonnant par le montant le plus élevé en 
premier, et limiter aux 10 premiers joueurs. La 1ère colonne doit avoir pour nom "IdJoueur" 
et la 2ème colonne "TotalDepense"*/

SELECT idJoueur AS IdJoueur, SUM(arm.armPrix * dc.detQuantiteCommande) AS TotalDepense -- sélectionne l'id du joueur et fait la somme de l'argent depensé
FROM t_joueur jo, t_commande co, t_detail_commande dc, t_arme arm -- de la table joueur, commande, detail commande et arme
WHERE idJoueur = co.fkJoueur AND 
dc.fkCommande = co.idCommande AND 
dc.fkArme = arm.idArme -- Utilisé comme un join (combine des lignes de deux ou plusieurs tables en utilisant une condition commune)
GROUP BY idJoueur -- group par joueur
ORDER BY TotalDepense DESC -- ordonne par Totaldepense
LIMIT 10; -- Limite la reponse au 10 premières

/*Récupérez tous les joueurs et leurs commandes, même s'ils n'ont pas passé de commande.
Dans cet exemple, même si un joueur n'a jamais passé de commande, il sera quand 
même listé, avec des valeurs `NULL` pour les champs de la table `t_commande`.*/

SELECT jo.*, co.* --Sélectionne tout
FROM t_joueur jo -- De la table joueur
LEFT JOIN t_commande co ON jo.idJoueur = co.fkJoueur --combine des lignes de deux ou plusieurs tables en utilisant une condition commune
LEFT JOIN t_detail_commande dc ON co.idCommande = dc.fkCommande; --combine des lignes de deux ou plusieurs tables en utilisant une condition commune

/*Récupérer toutes les commandes et afficher le pseudo du joueur s’il existe, sinon afficher
`NULL` pour le pseudo.*/

SELECT jo.jouPseudo, co.* -- Sélectionne le pseudo et tout des commande
FROM t_commande co -- de la table commande
LEFT JOIN t_joueur jo ON co.fkJoueur = jo.idJoueur -- combine des lignes de deux ou plusieurs tables en utilisant une condition commune

/*Trouver le nombre total d'armes achetées par chaque joueur (même si ce joueur n'a 
acheté aucune Arme).*/

SELECT jo.idJoueur, COUNT(arm.idArme) -- Sélectionne Idjoueur et compte le nombre d'armes
FROM t_joueur jo -- de la table joueur
LEFT JOIN t_commande co ON jo.idJoueur = co.fkJoueur --combine des lignes de deux ou plusieurs tables en utilisant une condition commune
LEFT JOIN t_detail_commande dc ON co.idCommande = dc.fkCommande --combine des lignes de deux ou plusieurs tables en utilisant une condition commune
LEFT JOIN t_arme arm ON arm.idArme = dc.fkArme -- combine des lignes de deux ou plusieurs tables en utilisant une condition commune
GROUP BY jo.idJoueur -- Groupe la réponse par joueur

--Trouver les joueurs qui ont acheté plus de 3 types d'armes différentes

SELECT jo.idJoueur, COUNT(DISTINCT dc.fkArme) AS nmbrTypedArmes -- Sélectionne Idjoueur et compte le nombre d'armes differentes
FROM t_joueur jo -- de la tabale joueur
LEFT JOIN t_commande co ON jo.idJoueur = co.fkJoueur --combine des lignes de deux ou plusieurs tables en utilisant une condition commune
LEFT JOIN t_detail_commande dc ON co.idCommande = dc.fkCommande --combine des lignes de deux ou plusieurs tables en utilisant une condition commune
GROUP BY jo.idJoueur -- Groupe la réponse par joueur
having nmbrtypedArmes > 3 --Condition qui verifie que les joueurs qui ont plus de 3 types d'armes differents