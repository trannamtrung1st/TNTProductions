using Microsoft.EntityFrameworkCore;
using System;
using TestCodeFirst.Models;

namespace TestCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new TemplateContext())
            {
                var where = "WHERE 1=1";

                var list = context.Products
                    .FromSqlRaw($"SELECT * FROM Products {where}")
                    .AsNoTracking()
                    .ToListAsync().Result;
                Console.WriteLine(list.Count);
            }
        }
    }
}
