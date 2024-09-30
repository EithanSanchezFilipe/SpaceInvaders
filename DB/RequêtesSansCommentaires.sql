SELECT * 
FROM `t_joueur` 
ORDER BY jouNombrePoints DESC 
LIMIT 5;

SELECT 
    MAX(armPrix) AS PrixMaximum, 
    MIN(armPrix) AS PrixMinimum, 
    AVG(armPrix) AS PrixMoyen 
FROM 
    `t_arme`; 

SELECT 
    jo.idJoueur AS IdJoueur, 
    COUNT(co.fkJoueur) AS NombreCommandes 
FROM 
    t_joueur jo, 
    t_commande co 
GROUP BY 
    jo.idJoueur 
ORDER BY 
    NombreCommandes DESC;

SELECT 
    fkJoueur AS IdJoueur, 
    COUNT(fkJoueur) AS NombreCommandes 
FROM 
    t_commande 
GROUP BY 
    fkJoueur 
HAVING 
    NombreCommandes > 2;

SELECT 
    jouPseudo, 
    arm.armNom 
FROM 
    t_joueur jo, 
    t_commande co, 
    t_detail_commande dc, 
    t_arme arm 
WHERE 
    idJoueur = co.fkJoueur 
    AND dc.fkCommande = co.idCommande 
    AND dc.fkArme = arm.idArme; 

SELECT 
    idJoueur AS IdJoueur, 
    SUM(arm.armPrix * dc.detQuantiteCommande) AS TotalDepense 
FROM 
    t_joueur jo, 
    t_commande co, 
    t_detail_commande dc, 
    t_arme arm 
WHERE 
    idJoueur = co.fkJoueur 
    AND dc.fkCommande = co.idCommande 
    AND dc.fkArme = arm.idArme 
GROUP BY 
    idJoueur 
ORDER BY 
    TotalDepense DESC 
LIMIT 
    10; 

SELECT 
    jo.*, 
    co.* 
FROM 
    t_joueur jo 
LEFT JOIN 
    t_commande co ON jo.idJoueur = co.fkJoueur 
LEFT JOIN 
    t_detail_commande dc ON co.idCommande = dc.fkCommande; 

SELECT 
    jo.jouPseudo, 
    co.* 
FROM 
    t_commande co 
LEFT JOIN 
    t_joueur jo ON co.fkJoueur = jo.idJoueur; 

SELECT 
    jo.idJoueur, 
    COUNT(arm.idArme) 
FROM 
    t_joueur jo 
LEFT JOIN 
    t_commande co ON jo.idJoueur = co.fkJoueur 
LEFT JOIN 
    t_detail_commande dc ON co.idCommande = dc.fkCommande 
LEFT JOIN 
    t_arme arm ON arm.idArme = dc.fkArme 
GROUP BY 
    jo.idJoueur; 

SELECT 
    jo.idJoueur, 
    COUNT(DISTINCT dc.fkArme) AS nmbrTypedArmes 
FROM 
    t_joueur jo 
LEFT JOIN 
    t_commande co ON jo.idJoueur = co.fkJoueur 
LEFT JOIN 
    t_detail_commande dc ON co.idCommande = dc.fkCommande 
GROUP BY 
    jo.idJoueur 
HAVING 
    nmbrTypedArmes > 3; 
