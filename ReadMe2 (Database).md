#ReadMe2 - Database.
Folosirea bazei de date/adaugare produse (din baza de date sau sursa).


Baza de date este formata din 3 tabele, creare in SQLite:
  I. brands
 II. types
III. products
(Baza de date se gaseste in: gadgetzz\src\Web\Catalog -> "CatalogDatabase.sqlite3")
Poate fi deschis/editat cu: DB Browser for SQLite.






#I. Brands (Bara de sortare):
Pentru a adauga brand-uri in site, putem folosi doua metode: (Din cod sau din baza de date)

    I.1. Din cod:
      in src\Infrastructure\Data\CatalogContextSeed.cs putem adauga/sterge brand-uri.
            "ProductsBrandFromCode.Add(new CatalogBrand("Asus"));" - brand-ul Asus
            
    I.2. Din baza de date:
      In baza de date (CatalogDatabase.sqlite3), avem tabelul brands, aici putem adauga brand-uri.
      
           
Programul va citi SIMULTAN brand-urile din cod si din baza de date, astfel incat:
in cod am scris urmatoarele brand-uri:    
Asus,MSI,Lenovo,Apple,....,Intel.
iar in baza de date avem un brand: Samsung. (putem adauga mai multe.)







#II. Product Type (Bara de sortare):

Pentru a adauga tipuri de produse in site, putem folosi doua metode: (Din cod sau din baza de date)

    II.1 - Din cod:
      in src\Infrastructure\Data\CatalogContextSeed.cs putem adauga/sterge tipuri de produse.
            "ProductsTypeFromCode.Add(new CatalogType("Laptop"));" - produsul "laptop"
            
    II.2 - Din baza de date:
      In baza de date (CatalogDatabase.sqlite3), avem tabelul types, aici putem adauga tipuri de produse.
      
           
Programul va citi SIMULTAN tipurile de produse din cod si din baza de date, astfel incat:
in cod am scris urmatoarele tipuri:    
Laptop,Desktop,Monitor,Placa Video,Procesor.
iar in baza de date avem un tip de produs: Telefon. (putem adauga mai multe.)
  








#III. Adaugarea unui nou produs pe site:
Pentru a adauga un produs in site, putem folosi baza de date, sau direct din cod.

   III.1 - Din cod: CatalogContextSeed.cs (linia 180)
   Putem adauga un nou produs in lista, respectand urmatoarele criterii:
    new CatalogItem(Type,Brand,Name1,Name2,Price,PhotoSource) 
   
 Type: Alegem o cifra de la 1 la 5 (sau mai mult, daca avem in baza de date tipuri de produse), in functie de ce produs vrem sa adaugam (pentru a face sortarea in site).
 Produsele au cifrele in ordinea in care apar in cod, iar apoi continua numarul in baza de date.
 1= Laptop
 2= Desktop
 3= Monitor
 4= Placa Video
 5= Procesor
 .... putem continua in baza de date cu produsele de acolo, codul le va citi si pe ele.
 de exemplu 6= Telefon, chiar daca nu apare in cod, el este in baza de date.
 Daca am mai adauga un tip de produs in baza de date, acesta va fi 7, si tot asa..
      
 Brand:  Alegem o cifra de la 1 la 14 (sau mai mult, daca avem in baza de date brand-uri), in functie de ce brand vrem sa adaugam (pentru a face sortarea in site).
 Brand-urile au cifrele in ordinea in care apar in cod, iar apoi continua numarul in baza de date.              
 1= Asus
 2= MSI
 3= Lenovo
 4= Apple
 5= Acer
 6= nJoy
 7= EVGA
 8= DELL
 9= AlienWare
 10= HP
 11= Razer
 12= Aorus
 13= AMD
 14= Intel
 .... putem continua in baza de date cu produsele de acolo, codul le va citi si pe ele.
 de exemplu 15= Samsung, chiar daca nu apare in cod, el este in baza de date.
 
 Name1 si Name2: Scriem numele produsului.
 Price: pretul in dolari.
 PhotoSource: Sursa fotografiei. Aceasta se afla in: gadgetzz\src\Web\wwwroot\images\products
 Exemplu de photo source: http://catalogbaseurltobereplaced/images/products/13.jpg (inlocuim "13.jpg" cu noua imagine dorita.)
 
 
    III.2 - Din baza de date: CatalogDatabase.sqlite3 (tabelul products)
    Valori tabel:
              id= va incepe de la 1 si se va incrementa automat.
            Type= tipul produsului (cifra respectiva pentru produsul dorit, fie ca este luat din cod, fie din baza de date.)
           Brand= brand-ul (cifra respectiva pentru brand-ul dorit, fie ca este luat din cod, fie din baza de date.)
    ProductName1= Numele produsului
    ProductName2= Numele produsului
           Price= pretul (in dolari)
       PhotoPath= sursa fotografiei,  aceasta se afla in: gadgetzz\src\Web\wwwroot\images\products, exemplu de photo source: http://catalogbaseurltobereplaced/images/products/13.jpg (inlocuim "13.jpg" cu noua imagine dorita.)     
 
 