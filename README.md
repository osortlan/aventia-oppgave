


# aventia-oppgave
Strømmingsvennlig API-løsning med sanntidsfunksjonalitet


# Om besvarelsen


# Prosess:
1. gruppering av krav og funksjoner 
2. ui-design
3. definere brukerhistorier med krav, feilhåndtering/edgecases og (left shift) tester
4. arkitektur & teknisk løsningforslag
5. implementering
6. doc


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
    Test: Log inn med to forsjellige brukere i to forsjellige nett-sesjoner og opprett ny sesjon i første nettsesjon og verifiser oppdatering i andre nettsesjon


Generelle tekniske krav:
- backend (.NET 8 WebAPI) + frontend (Angular, nyeste versjon) løsning
- Bootstrap e.l for layout
- data persisteres i database (MySQL eller SQL Server)
- entity framework core mot database


# Arkitektur


# NOTES/TODOs:
- aktive strømmesesjoner?
- hardcoded urls in frontend
- cors urls
- subscribe() deprecated, 
- husk insomnia export
- backend namespaces
- unittests
- backend dao vs models
- vulnerabilities
- message-box timeout to config
- clean OnInit inheritence, not needed


# andre ideer
- hosting i Azure (frontend, backend, db, keyvault)
- IaC med terraform
- CI/CD med github actions
- generert api spec for frontend
- statistikk & log med application insights


# dev setup prerequisites
- dotnet
- node & npm
- angular
- docker
- docker compose (optional)
- set env var Auth__SignatureSecret (eller fake i launchSettings.json)

# vedlegg:

vd-1. Gammelt access token (for testing):
eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhIiwianRpIjoiY2E0NzhmM2YtNmMwNC00MjU1LWIxNDUtNDllMzkwMTA2OTI0IiwiZXhwIjoxNzQwODM0ODU0LCJpc3MiOiJ5b3VyZG9tYWluLmNvbSIsImF1ZCI6InlvdXJkb21haW4uY29tIn0.BK1xEnv0ERjr2gBdorGxV0maqgrKKJK9CWXtRm9sjXs