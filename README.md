# Projet Oracle

# Application Web de Gestion des Bases de Données avec ASP.NET C# avec un SGBD ORACLE
Ce projet vise à gérer une base de données relationnelle en assurant la synchronisation des données entre une machine locale et une machine virtuelle. Les modifications (ajout, suppression, mise à jour) sont synchronisées en temps réel, avec une flexibilité permettant d'inverser les rôles de client et serveur.

### Réalisé par :
**AABARI Ismail**

### Formation Oracle

Ce projet a été réalisé dans le cadre d'une formation approfondie sur l'administration des bases de données Oracle, supervisée par un professeur exceptionnel. L'objectif principal était de mettre en pratique les concepts appris en connectant une base de données Oracle avec une application réelle, démontrant ainsi notre capacité à gérer des bases de données complexes dans des environnements professionnels.

---

## But du Projet

Le projet visait à évaluer notre aptitude à :

1. **Configurer une communication fluide** entre une machine locale et une machine virtuelle, où chaque machine peut agir comme serveur ou client en fonction du scénario.
2. **Gérer une base de données virtuelle** comprenant des tables comme EMP et DEPT, en assurant la synchronisation des modifications (ajouts, suppressions, mises à jour) entre les deux machines.
3. **Développer une application réelle**, ici réalisée en **ASP.NET (C#)**, pour interagir avec la base de données. Cette application gère les opérations CRUD tout en maintenant une connectivité réseau stable (via une adresse IP ou un pont réseau configuré sous VMware).

---

## Formation Oracle : Concepts Appliqués

### 1. Gestion des Instances Oracle
- Compréhension des étapes de démarrage d’une base de données : **Shutdown → Nomount → Mount → Open**.
- Différences entre les fichiers **Pfile** (modifiable manuellement) et **SPfile** (modifiable dynamiquement).
- Création et gestion des fichiers **SPfile** pour automatiser la configuration des bases de données.

### 2. Journalisation et Redolog Files
- Rôle des fichiers **Redolog** dans la gestion des transactions (Commit, LogSwitch).
- Création, modification et suppression de groupes de journaux.
- Activation des modes **ARCHIVE** et **NOARCHIVE LOG** pour la gestion des sauvegardes.

### 3. Gestion des Tablespaces et des Fichiers de Données
- Création et gestion des **tablespaces** (System, Sysaux et non-systèmes).
- Redimensionnement et déplacement des **fichiers de données** (Datafiles).

### 4. Pratiques DBA (Database Administrator)
- Gestion des **utilisateurs DBA** et des **permissions** en fonction de l’état de la base.
- Mise en ligne et hors ligne des **tablespaces**, avec archivage et synchronisation manuels.

### 5. Journalisation Manuelle et Points de Contrôle
- Commandes SQL pour forcer les basculements (**LogSwitch**) et les points de contrôle (**Checkpoint**).
- Configuration de l’archivage manuel pour garantir la sécurité des données.

### 6. Exercices Pratiques
- Mise en œuvre des commandes SQL pour gérer les composants de la base.
- Utilisation des vues système (V$log, V$logfile, **DBA_tablespaces**) pour analyser les métadonnées.

---

## Fonctionnalités Clés du Projet

### 1. Connexion entre la base de données Oracle et l'application réelle :
- Synchronisation bidirectionnelle des modifications entre une machine locale et une machine virtuelle.

### 2. Application ASP.NET :
- Interface utilisateur pour gérer les données (ajout, suppression, mise à jour).
- Connexion réseau stable configurée via VMware.

### 3. Gestion de données dynamiques :
- Intégration des tables **Oracle** dans l'application en temps réel.
- Analyse et gestion des données critiques pour des scénarios professionnels.

---

## Conclusion

Cette formation et ce projet ont représenté une étape clé dans notre parcours, nous permettant de développer des compétences techniques solides en administration Oracle. Nous remercions notre professeur pour son expertise et sa pédagogie, qui ont rendu cette expérience à la fois enrichissante et formatrice.

---

© 2024 - **Application_webOracle**  
© 2024 **Ismail Aabari**. Tous droits réservés.

