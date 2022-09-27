using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using my_books.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace my_books.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                if (!context.Books.Any())
                {
                    context.Books.AddRange(
                        new Book
                        {
                            Title = "Digital Systems",
                            Description = "Talks about digital systems",
                            IsRead = true,
                            DateRead = DateTime.Now.AddDays(-10),
                            Rate = 5,
                            Genre = "Science",
                            Author = "Fadi",
                            CoverURL = "https://th.bing.com/th/id/OIP.DiACthTfH1jYPM_5w-fHBAHaLF?w=194&h=290&c=7&r=0&o=5&pid=1.7",
                            DateAdded = DateTime.Now
                        },
                        new Book
                        {
                            Title = "Network Systems",
                            Description = "Talks about networking",
                            IsRead = false,
                            Genre = "Science",
                            Author = "Taha",
                            CoverURL = "https://th.bing.com/th/id/OIP.DiACthTfH1jYPM_5w-fHBAHaLF?w=194&h=290&c=7&r=0&o=5&pid=1.7",
                            DateAdded = DateTime.Now
                        }
                    );

                    context.SaveChanges();
                }
            }

        }
    }
}

