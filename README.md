# DDEUnitTestDataProject

![Coverage](./AppUnitTests/CoverageReport/badge_combined.svg)
![Coverage](./AppUnitTests/CoverageReport/badge_linecoverage.svg)
![Coverage](./AppUnitTests/CoverageReport/badge_branchcoverage.svg)
![Coverage](./AppUnitTests/CoverageReport/badge_fullmethodcoverage.svg)
![Coverage](./AppUnitTests/CoverageReport/badge_methodcoverage.svg)





## 📜 Description
Projet de Testing scolaire.
Ce projet .NET 8 avec C# 12 inclut des tests unitaires pour les méthodes reçues dans le cadre du Cours D'INFB de Mr Poulet 
ajout d'une couverture de code automatisée grâce à Coverlet et ReportGenerator.

## 🚀 Fonctionnalités
- Tests unitaires avec xUnit et Fluent Assertions.
- Couverture de code avec rapport HTML.
- Badge de couverture (à venir , petite touche artistique en bonus 🎨).

## 🛠 Installation de coverlet si vous clonez le dépôt
1. Clonez le dépôt :
```bash
git clone <URL-de-votre-repo>
cd DDEUnitTestDataProject
```

2. Installez les outils nécessaires :
```bash
dotnet tool install --global coverlet.console
dotnet tool install --global dotnet-reportgenerator-globaltool
```

## 📊 Génération du rapport de couverture
Pour exécuter les tests et générer un rapport :
```bash
dotnet test
start CoverageReport/index.html
```

## Automatisation des tests et nettoyages anciens rapports 🧹
Dans le cs.proj de ce projet de test vous retrouvez la balise suivante 
	<Target Name="Coverage" AfterTargets="Test">
		<!-- Nettoyage des anciens rapports -->
		<Exec Command="dotnet clean" />

		<!-- Exécution des tests avec collecte de la couverture -->
		<Exec Command="dotnet test --collect:'XPlat Code Coverage'" />

		<!-- Génération du rapport HTML + Badge -->
		<Exec Command="reportgenerator -reports:TestResults/*/coverage.cobertura.xml -targetdir:CoverageReport -reporttypes:Html;Badges" />
	</Target>


## 🟢 Badge de couverture (à venir)
Le badge de couverture apparaîtra ici après sa génération.

---

## 🤝 Contribution
N'hésitez pas à proposer des améliorations via des pull requests !

## 📄 Licence
Projet sous licence MIT.
