/*Requête numéro 1 : La première requête que l’on vous demande de réaliser est de sélectionner les 5 joueurs 
qui ont le meilleur score, c’est-à-dire qui ont le nombre de points le plus élevé. Les joueurs 
doivent être classés dans l’ordre décroissant.*/

SELECT * -- Sélectionne tout
FROM `t_joueur` -- De la table joueur
ORDER BY jouNombrePoints DESC -- Tri par ordre décroissant (Le meilleur en premier)
LIMIT 5; -- Limite la réponse à 5

/*Requête numéro 2 : Trouver le prix maximum, minimum et moyen des armes.
Les colonnes doivent avoir pour nom « PrixMaximum », « PrixMinimum » et « PrixMoyen ».*/

SELECT 
    MAX(armPrix) AS PrixMaximal, -- Sélectionne le prix max et le renomme
    MIN(armPrix) AS PrixMinimum, -- Sélectionne le prix min et le renomme
    AVG(armPrix) AS PrixMoyen -- Sélectionne le prix moyen et le renomme
FROM 
    `t_arme`; -- De la table arme

/*Requête numéro 3 : Trouver le nombre total de commandes par joueur et trier du plus grand nombre au plus petit.
La 1ère colonne aura pour nom "IdJoueur", la 2ème colonne aura pour nom "NombreCommandes".*/

SELECT 
    jo.idJoueur AS IdJoueur, -- Sélectionne l'id du joueur et le renomme
    COUNT(co.fkJoueur) AS NombreCommandes -- Sélectionne le nombre de commandes et le renomme
FROM 
    t_joueur jo, 
    t_commande co -- De la table joueur et commande
GROUP BY 
    co.fkJoueur -- Grouper les éléments par joueur
ORDER BY 
    NombreCommandes DESC; -- Tri par ordre décroissant (Le plus grand nombre de commandes en premier)

/*Requête numéro 4 : Trouver les joueurs qui ont passé plus de 2 commandes.
La 1ère colonne aura pour nom "IdJoueur", la 2ème colonne aura pour nom 
"NombreCommandes".*/

SELECT 
    fkJoueur AS IdJoueur, -- Sélectionne l'id du joueur et le renomme
    COUNT(fkJoueur) AS NombreCommandes -- Sélectionne le nombre de commandes et le renomme
FROM 
    t_commande -- De la table commande
GROUP BY 
    fkJoueur -- Grouper les éléments par joueur
HAVING 
    NombreCommandes > 2; -- Condition qui sélectionne les joueurs ayant passé plus de 2 commandes

/*Requête numéro 5 : Trouver le pseudo du joueur et le nom de l'arme pour chaque commande.*/

SELECT 
    jouPseudo, 
    arm.armNom -- Sélectionne le pseudo des joueurs et le nom des armes
FROM 
    t_joueur jo, 
    t_commande co, 
    t_detail_commande dc, 
    t_arme arm -- De la table joueur, commande, detail_commande et arme
WHERE 
    idJoueur = co.fkJoueur 
    AND dc.fkCommande = co.idCommande 
    AND dc.fkArme = arm.idArme; -- Utilisé comme un join (combine des lignes de deux ou plusieurs tables en utilisant une condition commune)

/*Requête numéro 6 : Trouver le total dépensé par chaque joueur en ordonnant par le montant le plus élevé en 
premier, et limiter aux 10 premiers joueurs. La 1ère colonne doit avoir pour nom "IdJoueur" 
et la 2ème colonne "TotalDepense".*/

SELECT 
    idJoueur AS IdJoueur, 
    SUM(arm.armPrix * dc.detQuantiteCommande) AS TotalDepense -- Sélectionne l'id du joueur et fait la somme de l'argent dépensé
FROM 
    t_joueur jo, 
    t_commande co, 
    t_detail_commande dc, 
    t_arme arm -- De la table joueur, commande, detail_commande et arme
WHERE 
    idJoueur = co.fkJoueur 
    AND dc.fkCommande = co.idCommande 
    AND dc.fkArme = arm.idArme -- Utilisé comme un join (combine des lignes de deux ou plusieurs tables en utilisant une condition commune)
GROUP BY 
    idJoueur -- Groupe par joueur
ORDER BY 
    TotalDepense DESC -- Ordre décroissant par TotalDepense
LIMIT 
    10; -- Limite la réponse aux 10 premiers

/*Requête numéro 7 : Récupérez tous les joueurs et leurs commandes, même s'ils n'ont pas passé de commande.
Dans cet exemple, même si un joueur n'a jamais passé de commande, il sera quand 
même listé, avec des valeurs `NULL` pour les champs de la table `t_commande`.*/

SELECT 
    jo.*, 
    co.* -- Sélectionne tout
FROM 
    t_joueur jo -- De la table joueur
LEFT JOIN 
    t_commande co ON jo.idJoueur = co.fkJoueur -- Combine des lignes de deux ou plusieurs tables en utilisant une condition commune (Il prends les valeurs de A et de A + B)
LEFT JOIN 
    t_detail_commande dc ON co.idCommande = dc.fkCommande; -- Combine des lignes de deux ou plusieurs tables en utilisant une condition commune (Il prends les valeurs de A et de A + B)

/*Requête numéro 8 : Récupérer toutes les commandes et afficher le pseudo du joueur s’il existe, sinon afficher
`NULL` pour le pseudo.*/

SELECT 
    jo.jouPseudo, 
    co.* -- Sélectionne le pseudo et tout des commandes
FROM 
    t_commande co -- De la table commande
LEFT JOIN 
    t_joueur jo ON co.fkJoueur = jo.idJoueur -- Combine des lignes de deux ou plusieurs tables en utilisant une condition commune (Il prends les valeurs de A et de A + B)

/*Requête numéro 9 : Trouver le nombre total d'armes achetées par chaque joueur (même si ce joueur n'a 
acheté aucune arme).*/

SELECT 
    jo.idJoueur, 
    COUNT(arm.idArme) -- Sélectionne IdJoueur et compte le nombre d'armes
FROM 
    t_joueur jo -- De la table joueur
LEFT JOIN 
    t_commande co ON jo.idJoueur = co.fkJoueur -- Combine des lignes de deux ou plusieurs tables en utilisant une condition commune (Il prends les valeurs de A et de A + B)
LEFT JOIN 
    t_detail_commande dc ON co.idCommande = dc.fkCommande -- Combine des lignes de deux ou plusieurs tables en utilisant une condition commune (Il prends les valeurs de A et de A + B)
LEFT JOIN 
    t_arme arm ON arm.idArme = dc.fkArme -- Combine des lignes de deux ou plusieurs tables en utilisant une condition commune (Il prends les valeurs de A et de A + B)
GROUP BY 
    jo.idJoueur -- Groupe la réponse par joueur

/*Requête numéro 10 : Trouver les joueurs qui ont acheté plus de 3 types d'armes différentes.*/

SELECT 
    jo.idJoueur, 
    COUNT(DISTINCT dc.fkArme) AS nmbrTypedArmes -- Sélectionne IdJoueur et compte le nombre d'armes différentes
FROM 
    t_joueur jo -- De la table joueur
LEFT JOIN 
    t_commande co ON jo.idJoueur = co.fkJoueur -- Combine des lignes de deux ou plusieurs tables en utilisant une condition commune (Il prends les valeurs de A et de A + B)
LEFT JOIN 
    t_detail_commande dc ON co.idCommande = dc.fkCommande -- Combine des lignes de deux ou plusieurs tables en utilisant une condition commune (Il prends les valeurs de A et de A + B)
GROUP BY 
    jo.idJoueur -- Groupe la réponse par joueur
HAVING 
    nmbrTypedArmes > 3; -- Condition qui vérifie les joueurs ayant plus de 3 types d'armes différent