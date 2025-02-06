# 🐝 HappyBee - .NET 8 Version

**Webová aplikácia pre včelárov a ich úle.**

## 📋 Popis projektu

**HappyBee** je webová aplikácia navrhnutá na pomoc včelárom pri správe ich úľov a súvisiacich úloh. Umožňuje:

- **Monitorovanie úľov:** Sledovanie stavu a histórie každého úľa.
- **Plánovanie úloh:** Vytváranie a správa úloh súvisiacich s údržbou a kontrolou úľov.
- **Analýza údajov:** Poskytovanie prehľadov a štatistík o výkonnosti včelstiev.

## 🛠️ Použité technológie

- **Backend:** ASP.NET Core (.NET 8)
- **Frontend:** Blazor
- **Databáza:** Entity Framework Core s podporou SQL Servera
- **Štýly:** CSS

## 🚀 Inštalačný návod

Postupujte podľa nasledujúcich krokov na nastavenie projektu na vašom lokálnom počítači.

### 1. Klonovanie repozitára

```bash
git clone https://github.com/lIThium66/HappyBeeBakalarka.git
cd HappyBeeBakalarka
```

### 2. Inštalácia závislostí

Uistite sa, že máte nainštalovaný .NET SDK 8.0 alebo novší. Ak nie, môžete si ho stiahnuť z [oficiálnej stránky .NET](https://dotnet.microsoft.com/download/dotnet).

V koreňovom adresári projektu spustite:

```bash
dotnet restore
```

### 3. Nastavenie databázy

Projekt používa Entity Framework Core pre prácu s databázou. Pred prvým spustením je potrebné nastaviť SQL Server a nakonfigurovať databázové pripojenie v `appsettings.json`.

#### Nastavenie SQL Servera

Ak ešte nemáte SQL Server nainštalovaný, môžete ho stiahnuť a nainštalovať zo stránky:
[SQL Server Download](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

Po inštalácii SQL Servera môžete vytvoriť databázu spustením nasledujúceho príkazu v SQL Server Management Studio (SSMS):

```sql
CREATE DATABASE HappyBeeDB;
```

#### Konfigurácia `appsettings.json`

Otvorte súbor `appsettings.json` a upravte časť `ConnectionStrings` tak, aby obsahovala správne údaje pre pripojenie k vašej databáze:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=HappyBeeDB;Trusted_Connection=True;"
  },
  "BaseUri": "https://localhost:7295",
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

**Poznámka:** Nahraďte `YOUR_SERVER_NAME` názvom vášho SQL Servera.

1. **Vytvorenie migrácií:**

   ```bash
   dotnet ef migrations add InitialCreate
   ```

2. **Aplikovanie migrácií:**

   ```bash
   dotnet ef database update
   ```

### 4. Spustenie aplikácie

Po úspešnom nastavení databázy môžete spustiť aplikáciu:

```bash
dotnet run
```

Aplikácia beží na vašom lokálnom počítači a môžete ju otvoriť v prehliadači na adrese `https://localhost:7295`.
