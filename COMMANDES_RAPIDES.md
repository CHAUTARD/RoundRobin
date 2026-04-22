# ⚡ Commandes Rapides - Setup Project MSI

## 🎯 Scripts PowerShell Disponibles

### SetupHelper.ps1
Script principal pour gérer le Setup Project

```powershell
# Vérifier l'environnement et les prérequis
.\SetupHelper.ps1 -Action Check

# Afficher les instructions pour compiler
.\SetupHelper.ps1 -Action Build

# Nettoyer les fichiers temporaires
.\SetupHelper.ps1 -Action Clean

# Tester l'installateur
.\SetupHelper.ps1 -Action Test

# Créer le package de distribution
.\SetupHelper.ps1 -Action Package
```

### CreateDistribution.ps1
Script pour créer un package portable

```powershell
# Créer un package portable (sans installateur)
.\CreateDistribution.ps1
```

---

## 📝 Workflow Complet

### 1️⃣ Première Création

```powershell
# Étape 1 : Vérifier l'environnement
.\SetupHelper.ps1 -Action Check

# Étape 2 : Créer le Setup Project dans Visual Studio
# (Suivre GUIDE_SETUP_PROJECT.md)

# Étape 3 : Compiler dans Visual Studio
# Release → Clic droit RoundRobinSetup → Build

# Étape 4 : Créer le package
.\SetupHelper.ps1 -Action Package
```

### 2️⃣ Mise à Jour de Version

```powershell
# Étape 1 : Nettoyer les anciens builds
.\SetupHelper.ps1 -Action Clean

# Étape 2 : Compiler dans Visual Studio
# (Après avoir incrémenté la version)

# Étape 3 : Créer le package
.\SetupHelper.ps1 -Action Package
```

### 3️⃣ Test Rapide

```powershell
# Tester l'installateur
.\SetupHelper.ps1 -Action Test
```

---

## 🏗️ Compilation dans Visual Studio

### Compiler le projet principal
```
1. Sélectionner "Release" dans la barre d'outils
2. Build → Build RoundRobin (ou Ctrl+Shift+B)
```

### Compiler le Setup Project
```
1. Sélectionner "Release" dans la barre d'outils
2. Clic droit sur RoundRobinSetup
3. Build
```

---

## 📦 Fichiers Générés

### Après compilation du Setup
```
F:\Projet_C#\RoundRobin\RoundRobinSetup\Release\
├── RoundRobinSetup.msi          # Installateur principal
└── Setup.exe                     # Bootstrapper (si configuré)
```

### Après création du package
```
F:\Projet_C#\RoundRobin\Distribution\
├── MSI_Package/
│   ├── RoundRobinSetup.msi
│   ├── Setup.exe
│   └── LISEZMOI.txt
└── RoundRobinSetup_Package.zip  # Archive prête à distribuer
```

---

## 🔍 Commandes de Diagnostic

### Vérifier la version du projet
```powershell
Get-Content "F:\Projet_C#\RoundRobin\Properties\AssemblyInfo.cs" | Select-String "AssemblyVersion"
```

### Lister les fichiers Release
```powershell
Get-ChildItem "F:\Projet_C#\RoundRobin\bin\Release" | Select-Object Name, Length, LastWriteTime
```

### Vérifier si .NET 4.8 est installé
```powershell
Get-ChildItem "HKLM:\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\" | Get-ItemProperty | Select-Object Version, Release
```

### Taille du MSI généré
```powershell
Get-Item "F:\Projet_C#\RoundRobin\RoundRobinSetup\Release\RoundRobinSetup.msi" | Select-Object Name, @{N='Size (MB)';E={[math]::Round($_.Length/1MB,2)}}, LastWriteTime
```

---

## 🧹 Nettoyage

### Nettoyer tous les builds
```powershell
# Via script
.\SetupHelper.ps1 -Action Clean

# Manuellement
Remove-Item "F:\Projet_C#\RoundRobin\bin" -Recurse -Force
Remove-Item "F:\Projet_C#\RoundRobin\obj" -Recurse -Force
Remove-Item "F:\Projet_C#\RoundRobin\RoundRobinSetup\Release" -Recurse -Force
Remove-Item "F:\Projet_C#\RoundRobin\RoundRobinSetup\Debug" -Recurse -Force
```

### Nettoyer les packages de distribution
```powershell
Remove-Item "F:\Projet_C#\RoundRobin\Distribution" -Recurse -Force
```

---

## 🚀 Déploiement Git

### Créer une release

```powershell
# 1. Commit et push des modifications
git add .
git commit -m "Version 1.0.0"
git push origin main

# 2. Créer et push le tag
git tag -a v1.0.0 -m "Version 1.0.0 - Première release"
git push origin v1.0.0

# 3. Créer la release sur GitHub (via interface web)
# Uploader : Distribution/RoundRobinSetup_Package.zip
```

### Mettre à jour une release

```powershell
# Supprimer le tag local
git tag -d v1.0.0

# Supprimer le tag distant
git push origin :refs/tags/v1.0.0

# Créer un nouveau tag
git tag -a v1.0.0 -m "Version 1.0.0 - Release mise à jour"
git push origin v1.0.0
```

---

## 📊 Statistiques du Projet

### Compter les lignes de code
```powershell
Get-ChildItem -Path "F:\Projet_C#\RoundRobin" -Include *.cs -Recurse | 
    Get-Content | 
    Measure-Object -Line | 
    Select-Object @{N='Total Lines';E={$_.Lines}}
```

### Taille du projet
```powershell
$size = (Get-ChildItem -Path "F:\Projet_C#\RoundRobin" -Recurse | 
         Measure-Object -Property Length -Sum).Sum / 1MB
Write-Host "Taille totale du projet : $([math]::Round($size,2)) MB"
```

---

## 🔧 Outils Utiles

### Ouvrir le projet dans Visual Studio
```powershell
Start-Process "F:\Projet_C#\RoundRobin\RoundRobin.sln"
```

### Ouvrir le dossier Release
```powershell
explorer.exe "F:\Projet_C#\RoundRobin\bin\Release"
```

### Ouvrir le dossier Distribution
```powershell
explorer.exe "F:\Projet_C#\RoundRobin\Distribution"
```

### Ouvrir le dépôt GitHub
```powershell
Start-Process "https://github.com/CHAUTARD/RoundRobin"
```

---

## 🎨 Personnalisation

### Changer l'icône du Setup
```
1. Dans Visual Studio, ouvrir RoundRobinSetup
2. Propriétés (F4)
3. AddRemoveProgramsIcon → Sélectionner une icône .ico
```

### Changer le nom du fabricant
```
1. Propriétés du Setup
2. Manufacturer → "Nouveau Nom"
```

### Changer le dossier d'installation par défaut
```
1. File System Editor
2. Application Folder → Propriétés
3. DefaultLocation → [ProgramFilesFolder][Manufacturer]\[ProductName]
```

---

## 📱 Tests sur d'autres machines

### Test en VM (Recommandé)

```powershell
# Créer une VM Windows 10/11
# Sans .NET 4.8 installé

# Copier le package
Copy-Item "F:\Projet_C#\RoundRobin\Distribution\RoundRobinSetup_Package.zip" -Destination "\\VM\Shared\"

# Tester l'installation dans la VM
```

### Test sur une vraie machine

```powershell
# Copier sur une clé USB
$usbDrive = "E:"  # Adapter selon votre clé
Copy-Item "F:\Projet_C#\RoundRobin\Distribution\RoundRobinSetup_Package.zip" -Destination "$usbDrive\"

# Tester sur un autre PC
```

---

## 🆘 Dépannage Express

### Le Setup ne compile pas
```powershell
# 1. Vérifier que le projet principal compile
dotnet build "F:\Projet_C#\RoundRobin\RoundRobin.csproj" --configuration Release

# 2. Nettoyer et recompiler
.\SetupHelper.ps1 -Action Clean
# Puis recompiler dans VS
```

### Le MSI ne s'installe pas
```powershell
# Vérifier les logs Windows Installer
Get-EventLog -LogName Application -Source MsiInstaller -Newest 10 | Select-Object TimeGenerated, Message
```

### Visual Studio plante lors de l'ouverture du Setup
```powershell
# Réinitialiser Visual Studio
devenv.exe /ResetSettings
```

---

## 📚 Aide et Documentation

### Afficher l'aide d'un script
```powershell
Get-Help .\SetupHelper.ps1 -Detailed
Get-Help .\CreateDistribution.ps1 -Full
```

### Lister tous les scripts disponibles
```powershell
Get-ChildItem -Path "F:\Projet_C#\RoundRobin" -Filter "*.ps1" | Select-Object Name, Length, LastWriteTime
```

---

## ⚙️ Configuration PowerShell

### Autoriser l'exécution de scripts (si nécessaire)
```powershell
# En tant qu'administrateur
Set-ExecutionPolicy RemoteSigned -Scope CurrentUser
```

### Créer un alias pour SetupHelper
```powershell
Set-Alias setup "F:\Projet_C#\RoundRobin\SetupHelper.ps1"

# Utilisation
setup -Action Check
```

---

**✅ Référence rapide prête à l'emploi !**

Copiez-collez ces commandes selon vos besoins. 🚀
