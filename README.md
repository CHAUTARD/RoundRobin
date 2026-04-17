# 🏓 Gestionnaire de Tournoi Round-Robin

Application Windows Forms pour la gestion de tournois de tennis de table en système Round-Robin (toutes rondes).

## 📋 Description

Cette application permet d'organiser et de gérer facilement des tournois de tennis de table où chaque joueur rencontre tous les autres joueurs une fois. Elle offre une interface intuitive pour :

- Gérer la liste des participants
- Générer automatiquement les matchs selon l'algorithme Round-Robin
- Enregistrer les résultats en temps réel
- Suivre le classement avec départage automatique
- Calculer la durée estimée du tournoi
- Sauvegarder et restaurer les tournois en cours

## ✨ Fonctionnalités principales

### Gestion des joueurs
- ✅ Ajout manuel de joueurs
- ✅ Import depuis un fichier texte (joueurs.txt)
- ✅ Import depuis l'API FFTT (Fédération Française de Tennis de Table)
- ✅ Sélection des joueurs présents par système de cases à cocher
- ✅ Boutons "Tout cocher" / "Tout décocher"

### Génération du tournoi
- ✅ Algorithme Round-Robin optimisé avec rotation
- ✅ Gestion automatique du joueur au repos (nombre impair)
- ✅ Calcul du nombre de tours et de matchs
- ✅ Estimation de la durée totale (3 ou 5 manches)
- ✅ Organisation des matchs par tours

### Enregistrement des résultats
- ✅ Double-clic sur le joueur gagnant pour enregistrer la victoire
- ✅ Clic droit pour déclarer un abandon
- ✅ Propagation automatique de l'abandon sur les matchs suivants
- ✅ Modification possible des résultats déjà enregistrés

### Classement
- ✅ Calcul automatique des points (2 pts victoire, 1 pt défaite)
- ✅ Départage par confrontation directe en cas d'égalité
- ✅ Indicateur visuel (⚖) pour les joueurs départagés
- ✅ Mise en évidence des joueurs ayant abandonné
- ✅ Statistiques détaillées : victoires, défaites, matchs joués

### Sauvegarde
- ✅ Sauvegarde automatique à la fermeture
- ✅ Restauration au démarrage
- ✅ Format XML pour portabilité

### Interface utilisateur
- ✅ Onglets masquables selon l'état du tournoi
- ✅ Aide contextuelle pour l'enregistrement des résultats
- ✅ Navigation entre les tours avec boutons Précédent/Suivant
- ✅ Formatage couleur des grilles (gagnants, abandons, départage)
- ✅ Info-bulles explicatives
- ✅ Barre d'état avec copyright

## 🎯 Règles du système de points

- **Victoire** : 2 points pour le gagnant, 1 point pour le perdant
- **Abandon** : 2 points pour l'adversaire, 0 point pour le joueur ayant abandonné
- **Départage** : En cas d'égalité de points, le classement est déterminé par le résultat de la confrontation directe entre les joueurs à égalité

## 🔧 Technologies utilisées

- **Framework** : .NET Framework 4.8
- **Langage** : C# 
- **Interface** : Windows Forms
- **Serialization** : XML
- **API externe** : FFTT (Fédération Française de Tennis de Table)

## 📂 Structure du projet
