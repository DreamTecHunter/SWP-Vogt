using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ_Grundlagen.Models
{
    class LinQ
    {
        static void Main(String[] args)
        {
            List<Article> articles = CreateArticleList();

            // 1.Abfrage: alle Artikel sortiert nach dem "Price"
            //	- Abfrage Syntax (SQL ähnlich)
            // der Compiler ersetzt var durch den (return-Vwert/) richtigen Datentyp
            var allArticlesOrderedByPrice_1 = from a in articles
                                              orderby a.Price
                                              select a;
            Console.WriteLine("-All articles ordered by price.");

            foreach (var a in allArticlesOrderedByPrice_1)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine();

            // 	- Erwiterungsmethoden-Syntax (mit MEthoden und Lamda-Ausdrücke)
            // Die e-methode OrderBy benötigt aös Parameter eine Methode - wir verwenden als kurze Schreibweise einen Lambda-Ausdruck
            // Labda-Ausdruck : 
            //	links von '=>' steht die ParameterListe der MEthode
            //	rechts von '=>' steht der Code der MEthode

            // a => a.Price ist die kurze schreibweise für (Article a) => {return a.Price;}
            var allArticlesOrderedByPrice_2 = articles
                            .OrderBy(a => a.Price);
            Console.WriteLine("-All articles ordered by price.");
            foreach (var a in allArticlesOrderedByPrice_2)
            {
                Console.WriteLine(a);
            }
            Console.WriteLine();
            // es gibt func, Action und PRedicate - als Parameter der Erweiterungsmethode
            // --
            // Func<T1, TResult> ... gibt eine Instanz von Typ TResult zurück und besitzt den Parameter von T1
            // Func< T1, T2, TResult> .... Parameter von Typ von T1 und T2, und Rückgabedatentyp ist TResult
            // Func<T1, ..., T15, TResult> .... maxuímal 16 oder 16 Parameter
            // --
            // Action<T1> ... bestitz als parameter den DatenTyp T1 - RückgabedatenTyp ist void
            // Axtion<T1, T2> ... besitzt die Parameter von Datentyp T1 und T2 - RückgabeDatenType ist void 
            // Action<T1, ..., T15> ... max. 15 PArametertypen - Rückgabedatentyp ist void.
            // --
            // Predicate<T> .. gibt imemr den Datentyp bool zurück und besotz als parameter den Typ T
            // --

            // labda : eine anonyme Methode

            // 2.Abfrage alle Artikel der Kategorie Book im Preis-Bereich zwischen 30€ und 50 €
            //	- Abfragesyntac
            var bookBetween30And50_1 = from b in articles
                                       where b.Category == Category.Book && b.Price >= 30 && b.Price <= 50
                                       select b;
            Console.WriteLine("-Articles which are Books between 30 and 50 Euro.");
            foreach (var b in bookBetween30And50_1)
            {
                Console.WriteLine(b);
            }
            Console.WriteLine();

            // 	- E-MEthode- Syntac

            var bookBetween30And50_2 = articles
                            .Where(b => b.Category == Category.Book)
                            .Where(b => b.Price >= 30 && b.Price <= 50);
            Console.WriteLine("-Articles which are Books between 30 and 50 Euro.");
            foreach (var b in bookBetween30And50_2)
            {
                Console.WriteLine(b);
            }
            Console.WriteLine();

            // Abfrage 3: all Artikel, welche mit AX in der Artikelnumer beginnen + 
            //	ersten 2 Artikel überspringen und dann 3 Artikel verwenden

            //	 - Abfragesyntax
            var axSkipTake_1 = (from ax in articles
                                where ax.ArticleNumber.Substring(0, 2).Equals("AX") // take works too, but is some more
                                select ax)
                    .Skip(2)
                    .Take(3);

            Console.WriteLine("-Articles starting with AX");

            foreach (var b in axSkipTake_1)
            {
                Console.WriteLine(b);
            }
            Console.WriteLine();

            //	 - Erwiterungsmethiodesyntax
            var axSkipTake_2 = articles
                    .Where(ax => ax.ArticleNumber.Substring(0, 2).Equals("AX"))
                    .Skip(2)
                    .Take(3);
            Console.WriteLine("-Articles starting with AX");
            foreach (var b in axSkipTake_1)
            {
                Console.WriteLine(b);
            }
            Console.WriteLine();



            // Abfrage 4: Artikel groupieren nach der Kategory, Kategorie-Name anzeigen, die Anzahl pro Kategorei anzeigen
            // abrgafesyntax

            var groupByKategory_1 = (from a in articles
                                     group a by a.Category); // select geht mnicht

            Console.WriteLine("Gruppierung nach Kategorie");
            foreach (var group in groupByKategory_1)
            {
                Console.WriteLine("\nKategorie: " + group.Key + " Anzahl: " + group.Count());
                foreach (var a in group)
                {
                    Console.WriteLine(a);
                }
            }


            // Abfrage 4: Erweiterungsmethodensyntax

            var groupByKategory_2 = articles
                .GroupBy(a => a.Category);

            foreach (var group in groupByKategory_2)
            {
                Console.WriteLine("\nKategorie: " + group.Key + " Anzahl: " + group.Count());
                foreach (var a in group)
                {
                    Console.WriteLine(a);
                }
            }

            //Projektion

            // 5.Abfrage: alle Artikel sortiert nach dem "Price"
            //	- Abfrage Syntax (SQL ähnlich)
            //  Projection (nur die Felder IOd, Name, Preis)
            // der Compiler ersetzt var durch den (return-Vwert/) richtigen Datentyp
            var allArticlesOrderedByPrice_Projection_1 = from a in articles
                                                         orderby a.Price
                                                         select new
                                                         {
                                                             ArticleID = a.ArticleNumber,
                                                             ArticleName = a.Name,
                                                             ArticlePrice = a.Price
                                                         };
            Console.WriteLine("-Projection - All articles ordered by price.");

            foreach (var a in allArticlesOrderedByPrice_Projection_1)
            {
                Console.WriteLine(a)
            }
            Console.WriteLine();

        }

        static List<Article> CreateArticleList()
        {
            return new List<Article>(){
                new Article("AX1234", "iPhone 13", "Apple", 1899.90m, Category.Hardware, new DateTime(2021,8,2)),
                new Article("AX1235", "iPhone 12", "Apple", 1199.90m, Category.Hardware, new DateTime(2020,5,23)),
                new Article("AX1236", "Maus", "Microsoft", 19.90m, Category.NotSpecified, new DateTime(2019,1,20)),
                new Article("AX1237", "XT 566", "Acer", 599.90m, Category.Laptop, new DateTime(2020,10,10)),
                new Article("AX1238", "C# LINQ", "Microsoft", 29.90m, Category.Book, new DateTime(2020, 12,4)),
                new Article("AX1211", "Java ist auch eine Insel", "OpenBook", 59.90m, Category.Book, new DateTime(2020,10,10)),
                new Article("AX1210", "C# ASP.NET Core", "Mircosoft", 49.90m, Category.Book, new DateTime(2019, 1, 14)),
                new Article("BQ1211", "Java Grundlafen", "Openbook", 39.90m, Category.NotSpecified, new DateTime(2021,1,23)),
                new Article("BQ1211", "ZQ 342334", "Samsung", 1399.90m, Category.Hardware, new DateTime(2020,10,3)),
                new Article("BQ1213", "PR 242342", "Samsung", 3199.90m, Category.Hardware, new DateTime(2021,9,1))
            };
        }
    }
}
