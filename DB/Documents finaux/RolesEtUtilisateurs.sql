-- Effacez les utilisateurs si ils sont déjà crées


-- Crée un rôle d'administrateur du jeu
CREATE ROLE 'AdminJeu';

-- Accorde des permissions au rôle : lire, mettre à jour, créer et supprimer dans db_space_invaders
GRANT SELECT, UPDATE, CREATE, DELETE ON db_space_invaders.* TO 'AdminJeu' WITH GRANT OPTION;

-- Crée un utilisateur administrateur avec un mot de passe
CREATE USER 'Administrateur' IDENTIFIED BY 'Admin_Pass';

-- Assigne le rôle d'administrateur du jeu à l'utilisateur
GRANT 'AdminJeu' TO 'Administrateur';

-- definie le role admin par defaut
SET DEFAULT ROLE 'AdminJeu' TO 'Administrateur';

-- Crée un rôle de joueur
CREATE ROLE 'Joueur';

-- Accorde des permissions au rôle joueur : lire les armes, créer et lire les commandes
GRANT SELECT ON db_space_invaders.t_arme TO 'Joueur';
GRANT CREATE ON db_space_invaders.t_commande TO 'Joueur';
GRANT SELECT ON db_space_invaders.t_commande TO 'Joueur';

-- Crée un utilisateur joueur avec un mot de passe
CREATE USER 'Joueur1' IDENTIFIED BY 'Joueur_Pass';

-- Assigne le rôle de joueur à l'utilisateur
GRANT 'Joueur' TO 'Joueur1';

-- definie le role Joueur par defaut
SET DEFAULT ROLE 'Joueur' TO 'Joueur1';

-- Crée un rôle de gestionnaire de boutique
CREATE ROLE 'Gestionnaire de boutique';

-- Accorde des permissions au gestionnaire : lire les joueurs, mettre à jour, lire et supprimer des armes, lire les commandes
GRANT SELECT ON db_space_invaders.t_joueur TO 'Gestionnaire de boutique';
GRANT UPDATE, SELECT, DELETE ON db_space_invaders.t_arme TO 'Gestionnaire de boutique';
GRANT SELECT ON db_space_invaders.t_commande TO 'Gestionnaire de boutique';

-- Crée un utilisateur gestionnaire avec un mot de passe
CREATE USER 'Gestionnaire' IDENTIFIED BY 'Gestionnaire_Pass';

-- Assigne le rôle de gestionnaire de boutique à l'utilisateur
GRANT 'Gestionnaire de boutique' TO 'Gestionnaire';

-- definie le role Joueur par defaut
SET DEFAULT ROLE 'Gestionnaire de boutique' TO 'Gestionnaire';
