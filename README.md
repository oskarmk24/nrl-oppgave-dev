# FirstWebApplication1

# Obstacle Reporting (ASP.NET Core MVC + MariaDB + Leaflet)

En MVC-app som lar brukere registrere hinder med posisjon fra kart (Leaflet) og lagrer til en Reports database i en MariaDB-container.


# Arkitektur

UI: Razor Views (Tailwind)

Controller: ObstacleController (Håndterer GET/POST av skjema)

Data: ReportsRepository (Sender data til obstacledb.Reports i mariaDB)

Kart: Leaflet (markerer lat/lng ved museklikk på kartet, kan bruke clik&drag funksjon på markøren etter plassering)

Database: MariaDB container (Lagrer innsendt data til en tabell kalt Reports)


# Reports table oppsett

ReportID: int (PK) (AI) (NN)

ObstacleName: varchar (NULL) 

ObstacleHeight: decimal (NULL)

ObstacleDescription: varchar (NULL)

ObstacleLocation: longtext (NULL)


# Drift med docker compose.

(Work-In-Progress)

Docker compose filen skal opprette to containere, en for web app serveren og en container med mariaDB med obstacledb database og ferdig Reports tabell. (Ikke tatt i bruk enda)

(Nåværende løsning)

Prosjektet bruker compose filen som ble opprettet under lab øvelsene i denne omgang.

1. Kjør docker compose up --build
2. Åpne http://localhost:5173




# Testing

Scenario 1

- Bruker fyller ut skjema og trykker "Submit", data vises på "Overview" siden.

Scenario 2

- Bruker markerer punkt på kartet og kan sende inn lokasjon i rapporten. Kartposisjon lagres og vises på nytt i "Overview".

Scenario 3

- Applikasjonen tilpasses skjermstørrelse på enhet som er i bruk.


# Resultater
