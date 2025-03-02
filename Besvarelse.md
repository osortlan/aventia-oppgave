
## Besvarelse

# Prosess

I løsingen av oppgaven har jeg brukt en enkel stegvis prosess:
1. Identifisere funksjoner og tilhørende funksjonelle krav
2. Designforslag
3. Utforming brukerhistorier
4. Arkitekturvalg
5. Implementering
6. Doc (README.md)

Jeg begyynte med å skille funksjonelle krav som kan oppleves av brukere fra tekniske krav.
Dette er viktig, fordi det er førstnevnte som leverer verdi. Tekniske krav tenker jeg på som
rammer og forutsetninger, men de kommer først inn når løsning skal implementeres.

Jeg identifiserte disse fire funksjonene:
- Innlogging
- Liste strømmesesjoner
- Opprette strømmesesjoner
- Sanntidsoppdatering

Videre tegnet jeg et design som er starten på et løsningsforslag (vedlagt design.png)
Her ville det være naturlig å drøfte designet med intressenter/domeneeksperter. Noen spørsmål man kunne addressert:
- hvilke egenskaper har en strømmesesjon? hva må man kunne fyll ut
- er det egentlig nødvendig å fylle ut noe - kan f.eks navn autogenereres, og hele 'new streamsession' dialogen sløyfes?
- 'aktiv' nevnes om stømmesesjoner en gang i oppgaven. kan strømmer være ikke aktive?

PS: Oppgaven sier "Bruk statiske brukere i første omgang". Jeg la derfor inn brukere med brukernavn og passord i klartekst -
dette er selvsagt helt latterlig og jeg vurderte å legge til hashing med salts osv, men tenkte dette var et sidespor og ikke det oppgaven ber om.

Jeg definerte så noen brukerhistorier ut fra funksjonelle krav og designet. De er orientert rundt hva er bruker trenger og opplever i
sin interakjson med applikasjonen (en brukers historie). Altså ikke en teknisk beskrivelse

Jeg legger så til tekniske krav, noen edgecases man må tenke på (håndtering brukerfeil), og utkast til noen (akseptanse)tester (left shift testing)
Er brukerhistoriende dekkende burde alle setninger i oppgave dukke opp på et vis, da en bør regne med at all informasjonen der er viktig og betyr noe.

Jeg ender opp med disse 4 brukerhistoriene:

# Brukerhistorier:
US-1: Innlogging: Jeg må kunne logge inn
    Funksjonelle Krav: 
        - Brukere skal kunne logge inn med mail/passord.
    Tekniske krav: 
        - Brukere får JWT som kan brukes for api kall
        - JWT hentes ved POST /api/auth/login
        - "registrere" brukere i appsettings.json
        - alle endepunkter (utenom innlogging) beskyttes med JWT auth
    Feilhåndtering:
        - ugyldig brukernavn/passord
        - sesjon utløpt
    Test: 
        - fyll inn test@testesen.com / test123, trykk login - verifiser at det står "hallo Test Testesen e.l"
        - fyll inn noe tullball - verifiser at du får feil
        - login, vent til token expirer (eller leg inn gammelt accessToken i local storage), refresh på hovedsiden - verifiser redirect til login-side, du får session-utløpt-feilmelding, token er clearet fra session store


US-2: Liste strømmesesjoner: Jeg trenger en liste over alle aktive strømmesesjoner
    Funksjonelle Krav: 
        - bruker skal få listet opp alle eksisterende aktive (?) strømmesesjoner.
    Tekniske krav:
        - GET /api/stream.
    Test: log inn og se at sesjoner dukker opp.


US-3: Opprett ny strømmesesjon: Side der jeg kan fylle inn info som trengs og opprette ny strømmesesjon
    Funksjonelle Krav: 
        - Knapp for å opprette en ny sesjon på hovedside
    Tekniske krav:
        - POST /api/stream
        - ny sesjon lagres i sql-db
    Feilhåndtering:
        - ugyldig navn/verdier
        - navn opptatt
    Test: fyll inn greier, trykk OK, verifiser at du returneres og ny sesjon er i liste med riktig navn osv.


US-4: Sanntidsoppdateringer:
    Funksjonelle Krav: 
        - Når en ny strømmesesjon opprettes, skal alle tilkoblede klienter få beskjed via SignalR.
    Tekniske krav:
        - SignalR for sanntidsoppdateringer
    Test: Log inn, opprett ny sessjon i insomnia (collection vedlagt) - verifiser at ny sesjon dukker opp i viewet


I tillegg noterer jeg meg følgende generelle tekniske krav:
- backend (.NET 8 WebAPI) + frontend (Angular, nyeste versjon) løsning
- Bootstrap e.l for layout
- data persisteres i database (MySQL eller SQL Server)
- entity framework core mot database


# Arkitektur
Som definert blir det en:
- frontend med Angular (siste versjon 19), med standalone components
- dotnet 8 webapi med enitiy framework, signalr og mysql database.

For frontend følger jeg en ganske enkel mappestruktur:
/Pages for alle komponenter som routes til
/Shared for gjenbrukbare komponenter
/Services for diverse service klasser
/Auth smaler alt med autentisering
/Model entiteter e.l fra domenet

For backend er det fristende å kaste seg ut i et DDD clean architecture opplegg - men det virker helt overkill her.
Jeg valgte heller et CQRS pattern der jeg grupperer commands og queries på funksjonsområder. Dette gir meg en enkel
mappestruktur preget av navn og beskrivelser fra domenet, noe jeg liker (istedet for Entities, ValueObjects osv)

(forenklet fremstiling)
/Login
    - GetAccessTokenQuery
/StreamSessions
    - GetStreamSessionsQuery
    - CreateStreamSessionCommand
/Common <- divere delte ting

# Mulige forbedringer
Det er også mange artige ting man kunne legge til den tekniske løsningen (med eksempel på teknologivalg):
- hosting i Azure (frontend, backend, db, keyvault)
- IaC med terraform
- CI/CD med github actions
- EF Migrations og Code first for databaseendringer
- generert api spec i TypeScript for frontend
- statistikk & log med application insights
- Autentisering brukere med Entra
- Autentisering tjenester med Entra og DefaultAzureCredential for SSO
- Alerts for uventede systemfeil og proaktiv kartlegging av feil