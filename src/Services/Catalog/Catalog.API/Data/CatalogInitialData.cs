using Marten.Schema;

namespace Catalog.API.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();
            if (await session.Query<Product>().AnyAsync())
                return;
            session.Store<Product>(GetPreconfiguredProducts());
            await session.SaveChangesAsync();
        }


        //Marten UPSERT will cater for existing records
        private static IEnumerable<Product> GetPreconfiguredProducts() => new List<Product>()
        {
            new Product()
                { 
                    Id = Guid.NewGuid(),
                    Name = "Iphone X",
                    Description = "This phone is very good flagship phon of the company",
                    ImageFile = "product-1.png",
                    Price = 950.00M,
                    Category = new List<string> { "Smart Phone"}
                },
                            new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Samsung Galaxy S21",
                    Description = "A powerful flagship phone with stunning display and performance.",
                    ImageFile = "product-2.png",
                    Price = 899.99M,
                    Category = new List<string> { "Smart Phone" }
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Google Pixel 7",
                    Description = "A clean Android experience with an exceptional camera.",
                    ImageFile = "product-3.png",
                    Price = 799.99M,
                    Category = new List<string> { "Smart Phone" }
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "OnePlus 10 Pro",
                    Description = "Flagship killer with top-notch performance and fast charging.",
                    ImageFile = "product-4.png",
                    Price = 749.99M,
                    Category = new List<string> { "Smart Phone" }
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Sony Xperia 1 III",
                    Description = "A phone for multimedia lovers with a 4K HDR OLED display.",
                    ImageFile = "product-5.png",
                    Price = 999.99M,
                    Category = new List<string> { "Smart Phone" }
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Xiaomi Mi 12",
                    Description = "A premium device with high-end specs at an affordable price.",
                    ImageFile = "product-6.png",
                    Price = 699.99M,
                    Category = new List<string> { "Smart Phone" }
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Asus ROG Phone 6",
                    Description = "The ultimate gaming smartphone with a high-refresh-rate display.",
                    ImageFile = "product-7.png",
                    Price = 1099.99M,
                    Category = new List<string> { "Gaming Phone" }
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Apple iPhone 14 Pro",
                    Description = "A premium Apple flagship with the latest A-series chip.",
                    ImageFile = "product-8.png",
                    Price = 1099.99M,
                    Category = new List<string> { "Smart Phone" }
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Realme GT 2 Pro",
                    Description = "A powerful budget flagship with excellent value for money.",
                    ImageFile = "product-9.png",
                    Price = 649.99M,
                    Category = new List<string> { "Smart Phone" }
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Nokia XR20",
                    Description = "A rugged smartphone designed for extreme durability.",
                    ImageFile = "product-10.png",
                    Price = 599.99M,
                    Category = new List<string> { "Rugged Phone" }
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Motorola Edge Plus",
                    Description = "A sleek flagship with a powerful camera and fast performance.",
                    ImageFile = "product-11.png",
                    Price = 899.99M,
                    Category = new List<string> { "Smart Phone" }
                },




            };
    }
}
