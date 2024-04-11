using Crud.Data;
using Crud.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Crud
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = ConfigureServices();
            using (var scope = serviceProvider.CreateScope())
            {
                var productRepository = scope.ServiceProvider.GetRequiredService<IProductRepository>();

                // Example usage
                var product = new Product { Name = "Example Product", Price = 10.99m };
                productRepository.Add(product);

                var retrievedProduct = productRepository.GetById(product.Id);
                Console.WriteLine($"Retrieved product: {retrievedProduct.Name}, Price: {retrievedProduct.Price}");

                // Update example
                retrievedProduct.Price = 15.99m;
                productRepository.Update(retrievedProduct);

                retrievedProduct = productRepository.GetById(product.Id);
                Console.WriteLine($"Retrieved product: {retrievedProduct.Name}, Price: {retrievedProduct.Price}");

                // Delete example
                productRepository.Delete(retrievedProduct);
            }
        }

        static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddDbContext<ProductDbContext>(options => options.UseSqlServer($"Data Source=LAPTOP-CMODSAPH\\SQLEXPRESS;Initial Catalog=infinnium2;Integrated Security=True;TrustServerCertificate=True;"));
            services.AddScoped<IProductRepository, ProductRepository>();
            return services.BuildServiceProvider();
        }
    }
}
