--Effacez les utilisateurs si ils sont déjà crées


-- Crée un rôle d'administrateur du jeu
CREATE ROLE 'Administrateur du jeu';

-- Accorde des permissions au rôle : lire, mettre à jour, créer et supprimer dans db_space_invaders
GRANT SELECT, UPDATE, CREATE, DELETE ON db_space_invaders.* TO 'Administrateur du jeu' WITH GRANT OPTION;

-- Crée un utilisateur administrateur avec un mot de passe
CREATE USER 'Administrateur' IDENTIFIED BY 'Admin_Pass';

-- Assigne le rôle d'administrateur du jeu à l'utilisateur
GRANT 'Administrateur du jeu' TO 'Administrateur';

-- definie le role admin par defaut
SET DEFAULT ROLE 'Administrateur du jeu' TO 'Administrateur'

-- Crée un rôle de joueur
CREATE ROLE 'Joueur';

-- Accorde des permissions au rôle joueur : lire les armes, créer et lire les commandes
GRANT SELECT ON t_arme TO 'Joueur';
GRANT CREATE ON t_commande TO 'Joueur';
GRANT SELECT ON t_commande TO 'Joueur';

-- Crée un utilisateur joueur avec un mot de passe
CREATE USER 'Joueur1' IDENTIFIED BY 'Joueur_Pass';

-- Assigne le rôle de joueur à l'utilisateur
GRANT 'Joueur' TO 'Joueur1';

-- definie le role Joueur par defaut
SET DEFAULT ROLE 'Joueur1' TO 'Joueur'

-- Crée un rôle de gestionnaire de boutique
CREATE ROLE 'Gestionnaire de boutique';

-- Accorde des permissions au gestionnaire : lire les joueurs, mettre à jour, lire et supprimer des armes, lire les commandes
GRANT SELECT ON t_joueur TO 'Gestionnaire de boutique';
GRANT UPDATE, SELECT, DELETE ON t_arme TO 'Gestionnaire de boutique';
GRANT SELECT ON t_commande TO 'Gestionnaire de boutique';

-- Crée un utilisateur gestionnaire avec un mot de passe
CREATE USER 'Gestionnaire' IDENTIFIED BY 'Gestionnaire_Pass';

-- Assigne le rôle de gestionnaire de boutique à l'utilisateur
GRANT 'Gestionnaire de boutique' TO 'Gestionnaire';

-- definie le role Joueur par defaut
SET DEFAULT ROLE 'Gestionnaire de boutique' TO 'Gestionnaire'

-- Vérifie les privilèges de chaque rôle
SHOW GRANTS FOR 'Administrateur du jeu';
SHOW GRANTS FOR 'Joueur';
SHOW GRANTS FOR 'Gestionnaire de boutique';

-- Vérifie les rôles attribués aux utilisateurs
SELECT TO_USER AS 'User', TO_HOST AS 'Host', FROM_USER AS 'Role'
FROM mysql.role_edges
WHERE TO_USER IS NOT NULL AND FROM_USER IS NOT NULL;
