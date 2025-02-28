# aventia-oppgave
Strømmingsvennlig API-løsning med sanntidsfunksjonalitet


Prosess:
1. gruppering av krav og funksjoner 
2. ui-design
3. definere brukerhistorier med krav, feilhåndtering/edgecases og (left shift) tester
4. teknisk løsningforslag
5. implementering
6. doc


# Brukerhistorier:
- Innlogging: Jeg må kunne logge inn
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
        - login, vent til token expirer, refresh på hovedsiden - verifiser redirect til login-side, du får session-utløpt-feilmelding, token er clearet fra session store


- Liste strømmesesjoner: Jeg trenger en liste over alle aktive strømmesesjoner
    Funksjonelle Krav: 
        - bruker skal få listet opp alle eksisterende aktive (!) strømmesesjoner.
    Tekniske krav:
        - GET /api/stream.
    Test: log inn og se at sesjoner dukker opp.


- Opprett ny strømmesesjon: Side der jeg kan fylle inn info som trengs og opprette ny strømmesesjon
    Funksjonelle Krav: 
        - Knapp for å opprette en ny sesjon på hovedside
    Tekniske krav:
        - POST /api/stream
        - ny sesjon lagres i sql-db
    Feilhåndtering:
        - ugyldig navn/verdier
        - navn opptatt
    Test: fyll inn greier, trykk OK, verifiser at du returneres og ny sesjon er i liste med riktig navn osv.


- Sanntidsoppdateringer:
    Funksjonelle Krav: 
        - Når en ny strømmesesjon opprettes, skal alle tilkoblede klienter få beskjed via SignalR.
    Tekniske krav:
        - SignalR for sanntidsoppdateringer
    Test: Log inn med to forsjellige brukere i to forsjellige nett-sesjoner og opprett ny sesjon i første nettsesjon og verifiser oppdatering i andre nettsesjon


Generelle tekniske krav:
- backend (.NET 8 WebAPI) + frontend (Angular, nyeste versjon) løsning
- Bootstrap e.l for layout
- data persisteres i database (MySQL eller SQL Server)
- entity framework core mot database


NOTES:
- aktive strømmesesjoner?