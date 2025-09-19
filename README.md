# Sample Avalonia NUnit Setup / Einrichtung

## English

### 1. Verify Avalonia Templates
Run the following command to check whether the Avalonia templates are already available:
```bash
dotnet new --list | grep Avalonia
```
If the list is empty, install the templates:
```bash
dotnet new install Avalonia.Templates
```

### 2. Bootstrap the Solution Workspace
Create the working folder and solution:
```bash
mkdir SampleAvaloniaNUnit
cd SampleAvaloniaNUnit
dotnet new sln -n SampleAvaloniaNUnit
```

### 3. Scaffold the Avalonia Application
Generate the app project and add it to the solution:
```bash
dotnet new avalonia.app -o SampleAvaloniaNUnit
dotnet sln SampleAvaloniaNUnit.sln add SampleAvaloniaNUnit/SampleAvaloniaNUnit.csproj
```

### 4. Scaffold the NUnit Test Project
Create the test project and register it with the solution:
```bash
dotnet new nunit -o SampleAvaloniaNUnit.Tests
dotnet sln SampleAvaloniaNUnit.sln add SampleAvaloniaNUnit.Tests/SampleAvaloniaNUnit.Tests.csproj
```

### 5. Link the Projects and Install Test Dependencies
Reference the app from the tests and add the headless packages:
```bash
dotnet add SampleAvaloniaNUnit.Tests/SampleAvaloniaNUnit.Tests.csproj reference SampleAvaloniaNUnit
dotnet add SampleAvaloniaNUnit.Tests package Avalonia.Headless.NUnit
# Optional, only if the Fluent theme is required during tests
dotnet add SampleAvaloniaNUnit.Tests package Avalonia.Themes.Fluent
```

### 6. Create Supporting Test Files
Manually add the following files to the test project to enable headless UI coverage:
- `SampleAvaloniaNUnit.Tests/TestAppBuilder.cs`
- `SampleAvaloniaNUnit.Tests/HeadlessUiTests.cs`
- `SampleAvaloniaNUnit.Tests/UI/HeadlessUi_MainWindow_BindingTests.cs`
- `SampleAvaloniaNUnit.Tests/Unit/Vm_SampleVmTests.cs`
- `SampleAvaloniaNUnit.Tests/Unit/Domain_ParserServiceTests.cs`

Each file wires up either the headless AppBuilder bootstrapper or concrete UI/unit tests that exercise bindings and domain logic.

### 7. Run the Test Suite
Execute the tests to ensure everything is wired correctly:
```bash
dotnet test SampleAvaloniaNUnit.Tests
```

### 8. Collect Code Coverage (Optional)
Gather cross-platform coverage data during the test run:
```bash
dotnet test SampleAvaloniaNUnit.Tests --collect:"XPlat Code Coverage"
```
The resulting reports are written beneath `SampleAvaloniaNUnit.Tests/TestResults/`.

## Deutsch

### 1. Avalonia-Vorlagen prüfen
Prüfe zuerst, ob die Avalonia-Vorlagen bereits installiert sind:
```bash
dotnet new --list | grep Avalonia
```
Falls keine Treffer erscheinen, installiere die Vorlagen:
```bash
dotnet new install Avalonia.Templates
```

### 2. Solution Arbeitsbereich aufsetzen
Arbeitsordner und Solution erzeugen:
```bash
mkdir SampleAvaloniaNUnit
cd SampleAvaloniaNUnit
dotnet new sln -n SampleAvaloniaNUnit
```

### 3. Avalonia-Anwendung erzeugen
App-Projekt generieren und der Solution hinzufügen:
```bash
dotnet new avalonia.app -o SampleAvaloniaNUnit
dotnet sln SampleAvaloniaNUnit.sln add SampleAvaloniaNUnit/SampleAvaloniaNUnit.csproj
```

### 4. NUnit-Testprojekt erstellen
Testprojekt erstellen und in die Solution eintragen:
```bash
dotnet new nunit -o SampleAvaloniaNUnit.Tests
dotnet sln SampleAvaloniaNUnit.sln add SampleAvaloniaNUnit.Tests/SampleAvaloniaNUnit.Tests.csproj
```

### 5. Projekte verknüpfen und Test-Abhängigkeiten installieren
App-Referenz setzen und Headless-Pakete einbinden:
```bash
dotnet add SampleAvaloniaNUnit.Tests/SampleAvaloniaNUnit.Tests.csproj reference SampleAvaloniaNUnit
dotnet add SampleAvaloniaNUnit.Tests package Avalonia.Headless.NUnit
# Optional, nur falls das Fluent-Theme im Test benoetigt wird
dotnet add SampleAvaloniaNUnit.Tests package Avalonia.Themes.Fluent
```

### 6. Zusätzliche Testdateien anlegen
Füge die folgenden Dateien im Testprojekt hinzu, um Headless-UI und Unit-Tests abzudecken:
- `SampleAvaloniaNUnit.Tests/TestAppBuilder.cs`
- `SampleAvaloniaNUnit.Tests/HeadlessUiTests.cs`
- `SampleAvaloniaNUnit.Tests/UI/HeadlessUi_MainWindow_BindingTests.cs`
- `SampleAvaloniaNUnit.Tests/Unit/Vm_SampleVmTests.cs`
- `SampleAvaloniaNUnit.Tests/Unit/Domain_ParserServiceTests.cs`

Diese Dateien stellen den Headless-AppBuilder bereit und enthalten Beispieltests für Bindings sowie Domainlogik.

### 7. Testsuite ausfuehren
Prüfe den Aufbau durch einen Testlauf:
```bash
dotnet test SampleAvaloniaNUnit.Tests
```

### 8. Code-Coverage erfassen (optional)
Sammle plattformübergreifende Coverage-Daten:
```bash
dotnet test SampleAvaloniaNUnit.Tests --collect:"XPlat Code Coverage"
```
Die Reports liegen anschliessend unter `SampleAvaloniaNUnit.Tests/TestResults/`.
