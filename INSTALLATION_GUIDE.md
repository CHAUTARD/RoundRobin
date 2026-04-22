# 📦 Guide d'Installation - RoundRobin

## Description

**RoundRobin** est une application de gestion de tournois de tennis de table en mode Round Robin (tous contre tous) par tours.

---

## ⚙️ Configuration Requise

### Système d'exploitation
- Windows 7 ou supérieur
- Windows 10 (recommandé)
- Windows 11

### Logiciels requis
- **.NET Framework 4.8**
  - Généralement déjà installé sur Windows 10/11
  - Téléchargement : [Microsoft .NET Framework 4.8](https://dotnet.microsoft.com/download/dotnet-framework/net48)

### Espace disque
- Installation : ~20 MB
- Données utilisateur : ~1 MB

---

## 📥 Installation

### Méthode 1 : Avec Setup.exe (Recommandée)

1. **Téléchargez le package** contenant :
   - `Setup.exe`
   - `RoundRobinSetup.msi`

2. **Double-cliquez sur `Setup.exe`**

3. **Suivez l'assistant d'installation** :
   - Acceptez la licence
   - Choisissez le dossier d'installation (ou laissez par défaut)
   - Cliquez sur "Installer"

4. **Terminé !** Un raccourci est créé sur le Bureau et dans le Menu Démarrer

> ℹ️ **Note** : Setup.exe vérifie et installe automatiquement .NET Framework 4.8 si nécessaire

---

### Méthode 2 : Avec le MSI uniquement

1. **Vérifiez que .NET Framework 4.8 est installé**
   - Panneau de configuration → Programmes et fonctionnalités
   - Recherchez ".NET Framework 4.8"

2. **Double-cliquez sur `RoundRobinSetup.msi`**

3. **Suivez l'assistant d'installation**

---

## 🚀 Premier Lancement

1. **Lancez l'application** :
   - Double-clic sur le raccourci Bureau
   - Ou Menu Démarrer → RoundRobin

2. **Ajoutez des joueurs** :
   - Tapez un nom et cliquez "Ajouter"
   - Ou chargez un fichier texte avec la liste des joueurs

3. **Gérez les présences** :
   - Utilisez le drag & drop entre les deux listes
   - Ou double-cliquez sur un nom pour le déplacer

4. **Générez le tournoi** :
   - Cliquez sur "Générer les matchs par tour"

5. **Enregistrez les résultats** :
   - Dans l'onglet "Matchs"
   - Double-cliquez sur le nom du gagnant

---

## 📂 Emplacement des Fichiers

### Installation
```
C:\Program Files (x86)\Patrick CH\RoundRobin\
├── RoundRobin.exe          # Application principale
├── joueurs.txt             # Liste des joueurs par défaut
└── *.dll                   # Bibliothèques nécessaires
```

### Données utilisateur
```
C:\Users\[VotreNom]\AppData\Local\RoundRobin\
└── tournament_save.json    # Sauvegarde automatique du tournoi
```

---

## 🔄 Mise à Jour

### Installation d'une nouvelle version

1. **Téléchargez la nouvelle version**

2. **Lancez l'installateur** :
   - L'ancienne version sera automatiquement désinstallée
   - Les données du tournoi en cours sont conservées

3. **Restauration** :
   - Au premier lancement, l'application propose de restaurer le tournoi sauvegardé

---

## ❌ Désinstallation

### Méthode 1 : Menu Démarrer
1. Menu Démarrer → RoundRobin
2. Cliquez sur "Désinstaller RoundRobin"

### Méthode 2 : Panneau de configuration
1. Panneau de configuration → Programmes et fonctionnalités
2. Trouvez "RoundRobin"
3. Clic droit → Désinstaller

### Suppression complète des données
Après désinstallation, supprimez manuellement (optionnel) :
```
C:\Users\[VotreNom]\AppData\Local\RoundRobin\
```

---

## 🆘 Dépannage

### L'application ne se lance pas

**Erreur : ".NET Framework requis"**
- **Solution** : Installez .NET Framework 4.8
- Lien : https://dotnet.microsoft.com/download/dotnet-framework/net48

**Erreur : "Fichier manquant"**
- **Solution** : Réinstallez l'application

**L'application se lance puis se ferme**
- **Solution** : 
  1. Supprimez le fichier de sauvegarde corrompu
  2. Chemin : `C:\Users\[Vous]\AppData\Local\RoundRobin\tournament_save.json`

---

### Impossible d'installer

**Erreur : "Privilèges administrateur requis"**
- **Solution** : Clic droit sur le MSI → "Exécuter en tant qu'administrateur"

**Erreur : "Une version est déjà installée"**
- **Solution** : Désinstallez d'abord l'ancienne version

**Erreur : "Windows Installer non disponible"**
- **Solution** : Redémarrez Windows et réessayez

---

### Problèmes de fonctionnement

**La liste des joueurs est vide**
- **Cause** : Fichier joueurs.txt manquant ou vide
- **Solution** : Ajoutez les joueurs manuellement ou via "Charger depuis un fichier"

**Le drag & drop ne fonctionne pas**
- **Solution** : Utilisez le double-clic comme alternative

**Les résultats ne se sauvegardent pas**
- **Solution** : Vérifiez les permissions du dossier AppData

---

## 📞 Support

### Signaler un bug
1. GitHub Issues : https://github.com/CHAUTARD/RoundRobin/issues
2. Fournir :
   - Version de RoundRobin (visible en bas de l'onglet Configuration)
   - Version de Windows
   - Description du problème
   - Étapes pour reproduire

### Demander une fonctionnalité
- GitHub Discussions : https://github.com/CHAUTARD/RoundRobin/discussions

### Code source
- GitHub Repository : https://github.com/CHAUTARD/RoundRobin

---

## 📄 Licence

Ce logiciel est distribué gratuitement (Freeware).

Copyright © 2026 Patrick CH. Tous droits réservés.

Voir `License.rtf` pour les termes complets de la licence.

---

## 🎯 Fonctionnalités Principales

- ✅ Gestion de tournois Round Robin par tours
- ✅ Drag & drop pour gérer les présences
- ✅ Filtre de recherche de joueurs
- ✅ Génération automatique des matchs
- ✅ Enregistrement des résultats
- ✅ Classement automatique avec départage
- ✅ Gestion des abandons
- ✅ Sauvegarde automatique
- ✅ Calcul de la durée estimée du tournoi
- ✅ Export/Import de listes de joueurs

---

## 📝 Notes de Version

### Version 1.0.0 (2026)
- 🎉 Version initiale
- Interface avec deux listes et drag & drop
- Filtre de recherche de joueurs
- Génération automatique des tours
- Classement avec départage par confrontation directe

---

**✅ Installation terminée ! Bon tournoi !** 🏓
