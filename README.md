# aventia-oppgave
Strømmingsvennlig API-løsning med sanntidsfunksjonalitet



# Brukerhistorier:
- Innlogging:
    Funksjonelle Krav: 
        - Brukere skal kunne logge inn med mail/passord.
        Feilhåndtering:
        - ugyldig brukernavn/passord
    Tekniske krav: 
        - Brukere får JWT som kan brukes for api kall
        - JWT hentes ved POST /api/auth/login
        - "registrere" brukere i appsettings.json
    Test: 
        - fyll inn test@testesen.com / test123, trykk login. Verifiser at det står "hallo Test Testesen e.l"
        - fyll inn noe tullball og verifiser at du får feil


- Liste strømmesesjoner: landingsside med strømmessesjoner
    Funksjonelle Krav: 
        - bruker skal få listet opp alle eksisterende strømmesesjoner.
        - brukere skal lande på dette viewet ved innlogging
    Tekniske krav:
        - GET /api/stream.
    Test: log inn og se at sesjoner dukker opp.


- Opprett ny strømmesesjon: ny side der man fyller inn data som trengs
    Funksjonelle Krav: 
        Side man kan fylle inn:
            - Sesjonnavn
        Ok-knapp
        Angreknapp (tilbake til landingsside)
        Feilhåndtering:
            - ugyldig navn/verdier
            - navn opptatt
    Tekniske krav:
        - POST /api/stream
        - ny sesjon lagres i sql-db
    Test: fyll inn greier, OK, verifiser at du returneres og ny sesjon er i liste med riktig navn osv.


- Sanntidsoppdateringer:
    Funksjonelle Krav: 
        - Når en ny strømmesesjon opprettes, skal alle tilkoblede klienter få beskjed via SignalR.
    Test: Log inn med to forsjellige brukere i to forsjellige nett-sesjoner* og opprett ny sesjon i første nettsesjon og verifiser oppdatering i andre nettsesjon