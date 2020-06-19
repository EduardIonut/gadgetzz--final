using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Microsoft.eShopWeb.Infrastructure.Data
{
    public class CatalogContextSeed
    {
        public static async Task SeedAsync(CatalogContext catalogContext,
            ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                if (!catalogContext.CatalogBrands.Any())
                {
                    catalogContext.CatalogBrands.AddRange(
                        GetPreconfiguredCatalogBrands());

                    await catalogContext.SaveChangesAsync();
                }

                if (!catalogContext.CatalogTypes.Any())
                {
                    catalogContext.CatalogTypes.AddRange(
                        GetPreconfiguredCatalogTypes());

                    await catalogContext.SaveChangesAsync();
                }

                if (!catalogContext.CatalogItems.Any())
                {
                    catalogContext.CatalogItems.AddRange(
                        GetPreconfiguredItems());

                    await catalogContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<CatalogContextSeed>();
                    log.LogError(ex.Message);
                    await SeedAsync(catalogContext, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }

        static IEnumerable<CatalogBrand> GetPreconfiguredCatalogBrands()
        {
            List<CatalogBrand> ProductsBrandFromCode = new List<CatalogBrand>();
            List<CatalogBrand> ProductsBrandFromDB = GetBazaDeDateBrand();

                ProductsBrandFromCode.Add(new CatalogBrand("Asus"));
                ProductsBrandFromCode.Add(new CatalogBrand("MSI"));
                ProductsBrandFromCode.Add(new CatalogBrand("Lenovo"));
                ProductsBrandFromCode.Add(new CatalogBrand("Apple"));
                ProductsBrandFromCode.Add(new CatalogBrand("Acer"));
                ProductsBrandFromCode.Add(new CatalogBrand("nJoy"));
                ProductsBrandFromCode.Add(new CatalogBrand("EVGA"));
                ProductsBrandFromCode.Add(new CatalogBrand("DELL"));
                ProductsBrandFromCode.Add(new CatalogBrand("AlienWare"));
                ProductsBrandFromCode.Add(new CatalogBrand("HP"));
                ProductsBrandFromCode.Add(new CatalogBrand("Razer"));
                ProductsBrandFromCode.Add(new CatalogBrand("Aorus"));
                ProductsBrandFromCode.Add(new CatalogBrand("AMD"));
                ProductsBrandFromCode.Add(new CatalogBrand("Intel"));

            if (ProductsBrandFromDB.Count != 0)

                foreach (CatalogBrand individ in ProductsBrandFromDB)
                {
                    ProductsBrandFromCode.Add(individ);
                }



            return new List<CatalogBrand>(ProductsBrandFromCode);

        }

        static List<CatalogBrand> GetBazaDeDateBrand()
        {
            List<CatalogBrand> FinalListForBrand = new List<CatalogBrand>();
            string queryBrand = "SELECT * FROM brands";

            try
            {
                System.Data.SQLite.SQLiteConnection connectionBrand = null;
                using (connectionBrand = new System.Data.SQLite.SQLiteConnection("Data source=Catalog/CatalogDatabase.sqlite3"))
                {
                    connectionBrand.Open();
                    using (var cmdBrand= new SQLiteCommand(queryBrand, connectionBrand))
                    {
                        SQLiteDataReader rdrBrand= cmdBrand.ExecuteReader();

                        while (rdrBrand.Read())
                        {
                            Console.WriteLine($"{rdrBrand.GetString(1)}");

                            FinalListForBrand.Add(new CatalogBrand(rdrBrand.GetString(1)));
                        };
                    }
                    connectionBrand.Close();
                    return FinalListForBrand;
                }
            }
            catch (Exception ex)
            { Console.WriteLine(ex); return new List<CatalogBrand>(); }
        }


        static IEnumerable<CatalogType> GetPreconfiguredCatalogTypes()
        {
            List<CatalogType> ProductsTypeFromCode = new List<CatalogType>();
            List<CatalogType> ProductsTypeFromDB = GetBazaDeDateType();

            
                ProductsTypeFromCode.Add(new CatalogType("Laptop"));
                ProductsTypeFromCode.Add(new CatalogType("Desktop"));
                ProductsTypeFromCode.Add(new CatalogType("Monitor"));
                ProductsTypeFromCode.Add(new CatalogType("Placa Video"));
                ProductsTypeFromCode.Add(new CatalogType("Procesor"));

            if (ProductsTypeFromDB.Count != 0)

                foreach (CatalogType individ in ProductsTypeFromDB)
                {
                    ProductsTypeFromCode.Add(individ);
                }



            return new List<CatalogType>(ProductsTypeFromCode);

        }

        static List<CatalogType> GetBazaDeDateType()
        {
            List<CatalogType> FinalListForTypes = new List<CatalogType>();
            string queryType = "SELECT * FROM types";

            try
            {
                System.Data.SQLite.SQLiteConnection connectionType = null;
                using (connectionType = new System.Data.SQLite.SQLiteConnection("Data source=Catalog/CatalogDatabase.sqlite3"))
                {
                    connectionType.Open();
                    using (var cmdType = new SQLiteCommand(queryType, connectionType))
                    {
                        SQLiteDataReader rdrType = cmdType.ExecuteReader();

                        while (rdrType.Read())
                        {
                            Console.WriteLine($"{rdrType.GetString(1)}");

                            FinalListForTypes.Add(new CatalogType(rdrType.GetString(1)));
                        };
                    }
                    connectionType.Close();
                    return FinalListForTypes;
                }
            }
            catch (Exception ex)
            { Console.WriteLine(ex); return new List<CatalogType>(); }
        }

        static IEnumerable<CatalogItem> GetPreconfiguredItems()
        {
            List<CatalogItem> ProductsFromCode = new List<CatalogItem>();
            List<CatalogItem> ProductsFromDB = GetBazaDeDate();

            ProductsFromCode.Add(new CatalogItem(1, 3, "Laptop Lenovo", "Laptop Lenovo", 749, "http://catalogbaseurltobereplaced/images/products/1.jpg"));
            ProductsFromCode.Add(new CatalogItem(1, 3, "Laptop Lenovo", "Laptop Lenovo", 999, "http://catalogbaseurltobereplaced/images/products/2.jpg"));
            ProductsFromCode.Add(new CatalogItem(1, 1, "Laptop ASUS", "Laptop ASUS", 1499, "http://catalogbaseurltobereplaced/images/products/3.jpg"));
            ProductsFromCode.Add(new CatalogItem(1, 2, "Laptop MSI", "Laptop MSI", 699, "http://catalogbaseurltobereplaced/images/products/4.jpg"));
            ProductsFromCode.Add(new CatalogItem(1, 5, "Laptop ACER", "Laptop ACER", 499.9M, "http://catalogbaseurltobereplaced/images/products/5.jpg"));
            ProductsFromCode.Add(new CatalogItem(1, 11, "Laptop Razer", "Laptop Razer", 2999, "http://catalogbaseurltobereplaced/images/products/6.jpg"));
            ProductsFromCode.Add(new CatalogItem(3, 8, "Monitor DELL", "Monitor DELL", 1499, "http://catalogbaseurltobereplaced/images/products/7.jpg"));
            ProductsFromCode.Add(new CatalogItem(4, 12, "Placa video AORUS", "Placa video AORUS", 999.9M, "http://catalogbaseurltobereplaced/images/products/8.jpg"));
            ProductsFromCode.Add(new CatalogItem(4, 2, "Placa Video MSI", "Placa Video MSI", 959, "http://catalogbaseurltobereplaced/images/products/9.jpg"));
            ProductsFromCode.Add(new CatalogItem(5, 13, "Procesor AMD Threadripper", "Procesor AMD Threadripper", 1999, "http://catalogbaseurltobereplaced/images/products/10.jpg"));
            ProductsFromCode.Add(new CatalogItem(5, 14, "Procesor Intel i9", "Procesor Intel i9", 559, "http://catalogbaseurltobereplaced/images/products/11.jpg"));
            ProductsFromCode.Add(new CatalogItem(5, 14, "Procesor Intel i3", "Procesor Intel i3", 129, "http://catalogbaseurltobereplaced/images/products/12.png"));
            ProductsFromCode.Add(new CatalogItem(5, 14, "Procesor Intel i9", "Procesor Intel i9", 599, "http://catalogbaseurltobereplaced/images/products/13.jpg"));
            ProductsFromCode.Add(new CatalogItem(6, 15, "telefoane", "Procesor Intel i9", 599, "http://catalogbaseurltobereplaced/images/products/17.jpg"));

            if (ProductsFromDB.Count != 0)

                foreach (CatalogItem individ in ProductsFromDB)
                {
                    ProductsFromCode.Add(individ);
                }



            return new List<CatalogItem>(ProductsFromCode);
        }


        static List<CatalogItem> GetBazaDeDate()
        {
            List<CatalogItem> FinalList = new List<CatalogItem>();
            string query = "SELECT * FROM products";

            try
            {
                System.Data.SQLite.SQLiteConnection connection = null;
                using (connection = new System.Data.SQLite.SQLiteConnection("Data source=Catalog/CatalogDatabase.sqlite3"))
                {
                    connection.Open();
                    using (var cmd = new SQLiteCommand(query, connection))
                    {
                        SQLiteDataReader rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            Console.WriteLine($"{rdr.GetInt32(1)} {rdr.GetInt32(2)} {rdr.GetString(3)} {rdr.GetString(4)} {rdr.GetInt32(5)} {rdr.GetString(6)}");

                            FinalList.Add(new CatalogItem(rdr.GetInt32(1), rdr.GetInt32(2), rdr.GetString(3), rdr.GetString(4), rdr.GetInt32(5), rdr.GetString(6)));
                        };
                    }
                    connection.Close();
                    return FinalList;
                }
            }
            catch (Exception ex)
            { Console.WriteLine(ex); return new List<CatalogItem>(); }
        }



    }
}

