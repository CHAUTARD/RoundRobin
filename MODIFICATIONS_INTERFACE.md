# Modifications de l'interface - Gestion des joueurs

## Changements apportés

### Ancienne interface
- Une seule liste `ListBoxPlayers` (CheckedListBox)
- Cocher/décocher les joueurs pour indiquer leur présence
- Boutons "Tout cocher" et "Tout décocher"

### Nouvelle interface
- **Deux listes distinctes** :
  1. **ListBoxAllPlayers** : Tous les joueurs enregistrés (avec filtre de recherche)
  2. **ListBoxPresentPlayers** : Joueurs présents au tournoi

- **Filtre de recherche** : 
  - TextBox `TxtFilterPlayers` pour filtrer les joueurs dans la liste complète
  - Le filtre s'applique en temps réel lors de la saisie

- **Drag & Drop** :
  - Glisser-déposer des joueurs de la liste complète vers la liste des présents
  - Glisser-déposer des joueurs de la liste des présents vers la liste complète
  - Support de la sélection multiple (Ctrl+Click ou Shift+Click)

- **Nouveaux boutons** :
  - "Tout ajouter" : Ajoute tous les joueurs dans la liste des présents
  - "Tout retirer" : Retire tous les joueurs de la liste des présents

## Fonctionnalités

### Ajout d'un joueur
1. Saisir le nom dans la zone de texte
2. Cliquer sur "Ajouter"
3. Le joueur est ajouté dans la liste complète ET dans la liste des présents

### Gestion de la présence
- **Par drag & drop** : Glisser un ou plusieurs joueurs entre les deux listes
- **Par boutons** : 
  - "Tout ajouter" : Tous les joueurs deviennent présents
  - "Tout retirer" : Retirer tous les joueurs de la liste des présents

### Recherche de joueurs
- Taper un texte dans la zone de filtre
- La liste complète affiche uniquement les joueurs correspondants
- Le filtre ne s'applique pas à la liste des présents

### Chargement depuis un fichier
- Le bouton "Charger la liste depuis un fichier" charge tous les joueurs
- Tous les joueurs sont ajoutés dans les deux listes
- Utiliser ensuite le drag & drop pour gérer la présence

## Avantages

1. **Interface plus claire** : Séparation visuelle entre tous les joueurs et les joueurs présents
2. **Filtre de recherche** : Trouve rapidement un joueur dans une longue liste
3. **Drag & drop intuitif** : Gestion visuelle et rapide de la présence
4. **Sélection multiple** : Déplacer plusieurs joueurs en une seule opération
5. **Conservation de la liste complète** : Les joueurs absents restent dans la base

## Notes techniques

- La liste complète (`_allPlayersList`) est conservée en mémoire
- La liste des présents détermine qui participe au tournoi
- Le filtre masque temporairement les joueurs non correspondants
- Le drag & drop utilise `DragDropEffects.Move`
- Les informations du tournoi se mettent à jour automatiquement selon les joueurs présents
