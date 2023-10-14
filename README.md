# Követelményspecifikáció

## Hírportál készítése Szoftverarchitektúrák tárgy házi feladat

Feladatkiírás
Az elkészítendő szoftver egy hírportál webalkalmazás lesz, amelyen különféle híreket lehet megtekinteni. A portálon bizonyos felhasználók új híreket vehetnek fel, míg mások csak olvasgatni tudják azokat.

A fejlesztői csapat
A csapat tagjai: 
- Gyömbér Péter	(PIM313)	gyomberpeti@gmail.com
- Dau Quang Phong	(QQ6ASM)	jancsid15@gmai.com
- Sági Benedek	(ECSGGY)	0322sagibenedek@gmail.com
- Pásztori Péter Benjámin	(L87LWY)	pasztoripeti@gmail.com

Részletes feladatleírás 
Egy olyan webalkalmazás megvalósítása a célunk, amelyen a felhasználók egységes környezetben a hírek megtekintését, kezelését, csoportosítását tudják elvégezni. A hírek kezelése szerint a felhasználók az adminisztrációs jogkörrel, illetve a normál felhasználói jogkörrel rendelkezhetnek.
A hírek kezelése a következő jogkör szerint történhet:
-	Admin:
    - Másnéven maga a szerkesztő
    - Hírcikk létrehozása, szerkesztése (frissítése), törlése
    - Hírcikk kategóriába való besorolása
    - Hírek összeállítása
    -	Hírkategóriák menedzselése, azaz
        - Egy új kategória létrehozása
-	Normál felhasználó:
    -	Nyitólap, illetve hírkategóriák megtekintése (nutshell)
    -	Hírcikk részleteinek megtekintése
    -	Hírcikk keresése kulcsszavakkal





Funkciók
Manage News: Az Admin felhasználók képesek a hírek kezelésére, azaz új híreket hozhatnak létre, meglévőket szerkeszthetnek vagy törölhetnek.
-	Create News: Az Admin felhasználónak a főoldalon látható egy “hír hozzáadása” gomb, amivel aztán egy külön nézeten hozhat létre új hírt.
-	Update News: A hír részletes nézetén az Admin felhasználónak lehetősége van az adott hír szerkesztésére.
-	Delete News: A hír részletes nézetén az Admin felhasználónak lehetősége van az adott hír törlésére is.
Register and Login: Minden felhasználónak lehetősége van regisztrálni a hírportálra. Az alapvető funkciók bár regisztrálás nélkül is elérhetőek, a kritikus funkciókhoz csak az Admin felhasználóknak van joga.
-	Register: A felhasználó új fiókot regisztrál a portálon (felhasználónév, jelszó).
-	Login: A már regisztrált felhasználók, felhasználónevük és jelszavuk helyes megadásával beléphetnek az oldalra.
View Portal: A felhasználók megtekinthetik a hírportált.
-	View Main Page: Az összes hír a főoldalon jelenik meg, amit a felhasználók itt tudnak elsőkörben megtekinteni.
  -	Search News: A főoldal hírei között lehetőség van mind kategória, mind kulcsszó alapján keresni.
-	View Detail Page: Egy hír teljes tartalmát a részletes nézeten lehet megtekinteni.
View Registered Users: Az Admin felhasználók megtekinthetik az összes regisztrált felhasználót.
Add Normal User as Admin: Az Admin felhasználók más felhasználókat adminná nevezhetnek ki, ami után már ők is elérhetik a kritikus funkciókat.

  
Technikai paraméterek
Az alkalmazás backend-jéhez .NET 7-t használunk, amely egy modern és erőteljes keretrendszer a szerveroldali fejlesztéshez. A .NET platformmal hatékonyan kezelhetjük az üzleti logikát és az adatkezelést a háttérben, biztosítva ezzel a webalkalmazás megbízhatóságát és teljesítményét.
A felhasználók által látható webes felületet Angular keretrendszer alkalmazásával valósítjuk meg. Az Angular egy modern webes keretrendszer, amely segít a reszponzív és felhasználóbarát weboldalak létrehozásában. 
A frontend és a backend között REST API segítségével történik a kommunikáció. A frontend különböző kéréseket küld a REST API-n keresztül a backend felé, és a backend válaszokat küld vissza a kliensnek. Ez lehetővé teszi, hogy a frontend és a backend egyszerűen megosszák az adatokat a webalkalmazás működése során.
Az alkalmazásban használt adatokat egy Microsoft SQL Server (MSSQL) adatbázisban tároljuk. Az MSSQL szolgáltatás lehetővé teszi az adatok hatékony kezelését és szervezését, valamint kiváló támogatást nyújt a tranzakciókezeléshez és az adatbázisból való lekérdezéshez.
A bejelentkezés után a kliens egy JSON Web Token-t (JWT) kap, amit a böngészőben el is tárol magának. A hívások során a kliens elküldi ezt a token-t, amit a backend validál és ennek megfelelően engedélyezi, vagy elutasítja az adott kérést.
