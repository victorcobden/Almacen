using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;
using Entity;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductBL productBL = new ProductBL();

                var product = new Product
                {
                    Nombre = "Producto H",
                    Descripcion = "Ni idea",
                    Cantidad = 56,
                    CategoryID = "3190c0c5-3f88-4120-a406-14a1c47a63af",
                    SupplierID = "d46a9c4a-3242-4538-acb1-b75b7a4421df"
                };
                productBL.Create(product);

            Console.WriteLine("Agregado!");
            Console.Read();

        }
    }
}
