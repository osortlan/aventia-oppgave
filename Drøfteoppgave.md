
# Læring i hverdagen
Personlig er jeg tillhenger av sammarbeid i små grupper på større oppgaver -
her kan vi prate oss gjennom problemstillingen, forstå bildet sammen, og lære å skille oppgave og løsning.
Sitter man tett, kanskje t.o.m i åpent landskap er dette lettere.

# Kodegjennomgang
For kodegjennomgang liker jeg å følge en DoD (definition of done) og kode-guidelines om vi har.
Jeg underkjenner PR som feiler på noen av disse. Har jeg et innspill/tips, f.eks "I siste versjon av X kan du enkelre gjøre Y med Z",
men det trenger ikke alltid underkjennes. Ser jeg en bug underkjenner jeg selvsagt, men: det er som regel vanskelig å gjennomgå koden
like grundig som en maskin ville gjort det. Jeg ser derfor ikke etter bugs overalt, men verifiserer heller at det er testdekning
og at den er god nok. Tester i pipeline som del av PR hjelper ytterligere.

# prinsipper for læringsmiljø
For læring i hverdagen mener jeg det er viktig for oss alle at vi arbeider godt sammen og har en lav terskel for å spørre.
I dette gamet lærer man hele tiden, og det er hele tiden noe man vet "altfor lite om" - dette må være lov.
En kultur der det "ikke finnes dumme spørsmål" skal dyrkes frem i praksis.

# Teknisk gjeld
Teknisk gjeld ville jeg beskrevet som en snarvei vi tar i teknisk løsning, men som vi i tillegg til å måtte betale den 
(reparere den dårlige løningen/hacket) må betale "renter" på underveis, f.eks i form av mer tungvingt og dermed dyrer utvikling, 
og/eller mer bug-prone kodebase.
I prinippet kan man ta opp teknisk gjeld for å tjene et hensiktsmessig mål på kort sikt (f.eks release en feature innenfor et
absolutt tidsvindu), men i min erfaring er det desverre sjelden at dette er bakgrunnen. Ofte gjøres det pga:
1. tidspress som i sin tur kan være forrårsaket av urealistiske forventinger eller manglende tillit til at det man gjør er riktig/nødvendig fra stakeholders.
Dette er vanskelig å håndtere, men man kan forbedre situasjonen noe med god komunikasjon og rutiner med nevnte stakholders. 
(Dette er nok litt big-coorp fenomen) 
2. En annen årsak er simpelthen slapphet hos utviklerteamet selv, dette er mye enklere å rette.
Klare PR rutiner, en definition of done og andre retningslinjer skrevet *av oss selv, med vårt eget språk, og på vårt eget nivå* 
har jeg tro på her. Det må dog holdes på et edruelig nivå, for dette tar i seg selv tid. Fatt vedtak om forbedring på retro e.l,
ikke for mange forbedringspunkter om gangen, men vær til gjenngjeld nøye med at tiltakene skal følges!

# Tiltak kompetanseheving
Uten om godt løringsmiljø osv:
1. kompensasjonordninger for kurs/sertifiseringe. Disse har selvsagt begrenset verdi kontra praktisk erfaring, men de er et OK startpunkt.
   det gir også et tydelig signal om at man verdsetter utvikling og faglig interesse
2. Mitt eget hotte tips er hjemmeprosjekter, her kan man teste ut ny/spennende tech. 
   Helst et som gjør noe "på ekte". Min egen visjon her er webtjeneste for å kunne sette opp spillservere av ulike slag (dette er mitt ansvar å gjøre manuelt i vennegjengen i dag) - ingenting er som ekte brukere, selv på et fritidsprosjekt :)