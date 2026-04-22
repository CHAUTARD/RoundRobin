# Script de mise à jour GitHub pour RoundRobin
# Automatise le commit et le push des modifications

param(
    [Parameter(Mandatory=$false)]
    [string]$CommitMessage = "",
    
    [Parameter(Mandatory=$false)]
    [switch]$CreateTag = $false,
    
    [Parameter(Mandatory=$false)]
    [string]$TagVersion = ""
)

$ErrorActionPreference = "Stop"

# Configuration
$repoPath = "F:\Projet_C#\RoundRobin"
$remoteName = "origin"
$branchName = "main"

# Couleurs
function Write-Title { param($text) Write-Host "`n========================================" -ForegroundColor Cyan; Write-Host "  $text" -ForegroundColor Cyan; Write-Host "========================================`n" -ForegroundColor Cyan }
function Write-Success { param($text) Write-Host "✅ $text" -ForegroundColor Green }
function Write-Info { param($text) Write-Host "ℹ️  $text" -ForegroundColor Yellow }
function Write-Error2 { param($text) Write-Host "❌ $text" -ForegroundColor Red }
function Write-Step { param($text) Write-Host "📌 $text" -ForegroundColor White }

Write-Title "Mise à jour GitHub - RoundRobin"

# Vérifier si on est dans le bon dossier
Set-Location $repoPath

# Vérifier le statut Git
Write-Step "Vérification du statut Git..."
$gitStatus = git status --porcelain

if ([string]::IsNullOrEmpty($gitStatus)) {
    Write-Success "Aucune modification à commiter"
    exit 0
}

# Afficher les fichiers modifiés
Write-Host "`n📋 Fichiers modifiés/ajoutés :" -ForegroundColor White
git status --short
Write-Host ""

# Liste des fichiers à ignorer (binaires, temporaires, etc.)
Write-Step "Vérification du fichier .gitignore..."
$gitignorePath = "$repoPath\.gitignore"

if (-not (Test-Path $gitignorePath)) {
    Write-Info "Création du fichier .gitignore..."
    
    $gitignoreContent = @"
## Ignorer les fichiers de build et binaires
bin/
obj/
*.exe
*.dll
*.pdb
*.user
*.suo
*.cache

## Ignorer les dossiers Visual Studio
.vs/
.vscode/

## Ignorer les packages NuGet
packages/

## Ignorer les fichiers de distribution compilés
Distribution/MSI_Package/
Distribution/RoundRobin_v*/

## Ignorer les sauvegardes
*.bak
*~

## Ignorer les fichiers temporaires
*.tmp
*.log

## Ignorer les fichiers de Setup compilés
RoundRobinSetup/Release/
RoundRobinSetup/Debug/

## Garder les fichiers de documentation et scripts
!*.md
!*.ps1
!*.txt
!*.rtf
"@
    
    Set-Content -Path $gitignorePath -Value $gitignoreContent -Encoding UTF8
    Write-Success "Fichier .gitignore créé"
}

# Demander un message de commit si non fourni
if ([string]::IsNullOrEmpty($CommitMessage)) {
    Write-Host "📝 Entrez un message de commit :" -ForegroundColor Yellow
    Write-Host "   (Ex: Ajout interface drag & drop, Correction bug, etc.)" -ForegroundColor Gray
    $CommitMessage = Read-Host "Message"
    
    if ([string]::IsNullOrEmpty($CommitMessage)) {
        $CommitMessage = "Mise à jour du $(Get-Date -Format 'dd/MM/yyyy à HH:mm')"
    }
}

# Ajouter tous les fichiers
Write-Step "Ajout des fichiers au staging..."
git add .

$addedFiles = git diff --cached --name-only
if ($addedFiles) {
    Write-Success "Fichiers ajoutés au staging :"
    $addedFiles | ForEach-Object { Write-Host "   + $_" -ForegroundColor Gray }
} else {
    Write-Info "Aucun fichier ajouté (peut-être déjà stagé)"
}

# Créer le commit
Write-Step "Création du commit..."
try {
    git commit -m $CommitMessage
    Write-Success "Commit créé avec succès"
    
    # Afficher le dernier commit
    Write-Host "`n📄 Dernier commit :" -ForegroundColor White
    git log -1 --pretty=format:"%h - %an, %ar : %s" | Write-Host -ForegroundColor Gray
    Write-Host "`n"
} catch {
    Write-Error2 "Erreur lors du commit : $_"
    exit 1
}

# Vérifier la connexion au remote
Write-Step "Vérification de la connexion au dépôt distant..."
try {
    $remoteUrl = git remote get-url $remoteName
    Write-Success "Dépôt distant : $remoteUrl"
} catch {
    Write-Error2 "Impossible de trouver le remote '$remoteName'"
    exit 1
}

# Push vers GitHub
Write-Step "Push vers GitHub ($remoteName/$branchName)..."
try {
    git push $remoteName $branchName
    Write-Success "Modifications poussées vers GitHub avec succès !"
} catch {
    Write-Error2 "Erreur lors du push : $_"
    Write-Info "Vérifiez votre connexion internet et vos identifiants GitHub"
    exit 1
}

# Créer un tag si demandé
if ($CreateTag -and -not [string]::IsNullOrEmpty($TagVersion)) {
    Write-Step "Création du tag $TagVersion..."
    
    try {
        # Vérifier si le tag existe déjà
        $existingTag = git tag -l $TagVersion
        
        if ($existingTag) {
            Write-Info "Le tag $TagVersion existe déjà"
            $response = Read-Host "Voulez-vous le remplacer ? (O/N)"
            
            if ($response -eq 'O' -or $response -eq 'o') {
                git tag -d $TagVersion
                git push $remoteName :refs/tags/$TagVersion
                Write-Success "Tag distant supprimé"
            } else {
                Write-Info "Tag non modifié"
                exit 0
            }
        }
        
        # Créer le nouveau tag
        git tag -a $TagVersion -m "Version $TagVersion"
        Write-Success "Tag $TagVersion créé localement"
        
        # Pousser le tag
        git push $remoteName $TagVersion
        Write-Success "Tag $TagVersion poussé vers GitHub"
        
        Write-Host "`n🎉 Tag créé ! Vous pouvez maintenant créer une release sur GitHub :" -ForegroundColor Green
        Write-Host "   https://github.com/CHAUTARD/RoundRobin/releases/new?tag=$TagVersion" -ForegroundColor Cyan
        
    } catch {
        Write-Error2 "Erreur lors de la création du tag : $_"
    }
}

# Résumé
Write-Host "`n"
Write-Title "✅ Mise à jour GitHub terminée !"

Write-Host "📊 Résumé :" -ForegroundColor White
Write-Host "   • Commit : $CommitMessage" -ForegroundColor Gray
Write-Host "   • Branche : $branchName" -ForegroundColor Gray
Write-Host "   • Remote : $remoteName" -ForegroundColor Gray

if ($CreateTag -and -not [string]::IsNullOrEmpty($TagVersion)) {
    Write-Host "   • Tag : $TagVersion" -ForegroundColor Gray
}

Write-Host "`n🌐 Voir sur GitHub :" -ForegroundColor White
Write-Host "   https://github.com/CHAUTARD/RoundRobin" -ForegroundColor Cyan

Write-Host "`n💡 Prochaines étapes :" -ForegroundColor White
Write-Host "   • Vérifier les modifications sur GitHub" -ForegroundColor Gray
Write-Host "   • Créer une release si nécessaire" -ForegroundColor Gray
Write-Host "   • Mettre à jour la documentation si besoin" -ForegroundColor Gray

Write-Host ""
