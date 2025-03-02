
## Strømmingsvennlig API-løsning med sanntidsfunksjonalitet

# dev setup prerequisites
- dotnet
- node & npm
- angular
- docker
- docker compose (optional)
- wsl

# dev setup
- set env var Auth__SignatureSecret (eller fake i launchSettings.json)
  like 'hoihgihoisrhgoioiuaoarghirgpahguhagoiphrguhgapohgpohagphgpiahgrsg' (must be a bit long)
- kjør `/scripts/run-local-db.sh` for å starte database lokalt
- kjør `dotnet run` under /backen
- Kjør `ng serve` under /frontend
- naviger til http://localhost:4200/
- logg inn med 'test@testesen.no' og 'test123'
- lag noen strømmesesjoner og ha det gøy :)


# NOTES/TODOs:
- subscribe() deprecated, 
- husk insomnia export
- unittests
- backend dao vs models
- vulnerabilities


# vedlegg:
Gammelt access token (for testing):
eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJiIiwianRpIjoiMmQ2NzY0ZmUtNjU5MC00ODAyLTgwNDYtOGI0ODE3YjFiNjc4IiwiZXhwIjoxNzQwOTMwNTk5LCJpc3MiOiJhdmVudGlhLm5vIiwiYXVkIjoiYXZlbnRpYS5ubyJ9.RQ43iBr7RhXx831OyeVpwguvap7IzeCOg9JJpuBPv8A