using Domain.Contracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Persistence
{
    public class DbInitializer : IDbInitializer
    {
        private readonly StoreDbContext _context;

        public DbInitializer(StoreDbContext context)
        {
            _context = context;
        }
        public async Task InitializeAsync()
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Any())
                {
                    await _context.Database.MigrateAsync();
                }


                if (!_context.ProductTypes.Any())
                {
                    // 1. Read All Data From types Json File as String
                    var typesData = await File.ReadAllTextAsync(@"..\Infrasructure\Persistence\Data\Seeding\types.json");

                    // 2. Transform String To C# Objects [List<ProductType>]
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    // 3. Add List<ProductType> To Database
                    if (types is not null && types.Any())
                    {
                        await _context.ProductTypes.AddRangeAsync(types);
                        await _context.SaveChangesAsync();
                    }

                }

                if (!_context.ProductBrands.Any())
                {
                    // 1. Read All Data From brands Json File as String
                    var brandsData = await File.ReadAllTextAsync(@"..\Infrasructure\Persistence\Data\Seeding\brands.json");

                    // 2. Transform String To C# Objects [List<ProductBrands>]
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    // 3. Add List<ProductBrands> To Database
                    if (brands is not null && brands.Any())
                    {
                        await _context.ProductBrands.AddRangeAsync(brands);
                        await _context.SaveChangesAsync();
                    }

                }



                if (!_context.Products.Any())
                {
                    // 1. Read All Data From brands Json File as String
                    var productsData = await File.ReadAllTextAsync(@"..\Infrasructure\Persistence\Data\Seeding\products.json");

                    // 2. Transform String To C# Objects [List<ProductBrands>]
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    // 3. Add List<ProductBrands> To Database
                    if (products is not null && products.Any())
                    {
                        await _context.Products.AddRangeAsync(products);
                        await _context.SaveChangesAsync();
                    }

                }


            }
            catch (Exception)
            {

                throw;
            }

        }
    }
    }
// ..\Infrasructure\Persistence\Data\Seeding\types.json
// ..\Infrasructure\Persistence\Data\Seeding\brands.json