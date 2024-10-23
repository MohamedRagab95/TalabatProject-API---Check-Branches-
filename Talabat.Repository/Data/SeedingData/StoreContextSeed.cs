using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Entities.Order_Aggregate;

namespace Talabat.Repository.Data.SeedingData
{
    public static class StoreContextSeed
    {

       public async static Task SeedBrandsAsync (StoreContext _storeContext)
       {

            var seedbrands = File.ReadAllText("../Talabat.Repository/Data/SeedingData/brands.json");

            var brands = JsonSerializer.Deserialize<List<ProductBrand>>(seedbrands);

            if (brands?.Count > 0)
            {
                if (_storeContext.ProductBrands.Count() == 0)
                {

                    foreach (var brand in brands)
                    {
                        _storeContext.Set<ProductBrand>().Add(brand);
                    }

                    await _storeContext.SaveChangesAsync();
                }

            }


            #region CategorySeeding
            var seedcategories = File.ReadAllText("../Talabat.Repository/Data/SeedingData/categories.json");

            var categories = JsonSerializer.Deserialize<List<ProductCategory>>(seedcategories);

            if (categories?.Count > 0)
            {
                if (_storeContext.productCategories.Count() == 0)
                {

                    foreach (var category in categories)
                    {
                         _storeContext.Set<ProductCategory>().Add(category);
                    }

                    await _storeContext.SaveChangesAsync();

                }

            }

            #endregion

            var seedproducts = File.ReadAllText("..//Talabat.Repository/Data/SeedingData/products.json");

            var products = JsonSerializer.Deserialize<List<Product>>(seedproducts);
            if (products?.Count > 0)
            {
                if (_storeContext.products.Count() == 0)
                {
                    foreach (var product in products)
                    {
                        _storeContext.Set<Product>().Add(product);
                    }

                    await _storeContext.SaveChangesAsync();
                }
            }





            var seeddeliverymethods = File.ReadAllText("../Talabat.Repository/Data/SeedingData/delivery.json");

            var methods = JsonSerializer.Deserialize<List<DeliveryMethod>>(seeddeliverymethods);

            if (methods?.Count > 0)
            {
                if (_storeContext.DeliveryMethods.Count() == 0)
                {

                    foreach (var method in methods)
                    {
                        _storeContext.Set<DeliveryMethod>().Add(method);
                    }

                    await _storeContext.SaveChangesAsync();
                }

            }



       }




    }
}
