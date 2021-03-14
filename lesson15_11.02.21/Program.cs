using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace lesson15_11._02._21
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                await Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Create()
        {
            try
            {
                var client = new Client();

                Console.Write("FirstName: ");
                client.FirstName = Console.ReadLine();

                Console.Write("SecondName: ");
                client.LastName = Console.ReadLine();

                Console.Write("PhoneNumb: ");
                client.PhoneNum = Console.ReadLine();

                using (var ctx = new TestContext())
                {
                    ctx.Clients.Add(client);

                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            
        }
        static async Task Read()
        {
            using (var ctx = new TestContext())
            {
                var clients = ctx.Clients;

                await clients.ForEachAsync(clients => Console.WriteLine($"Id:{clients.Id}\tFirstName:{clients.FirstName}"));
            }
        }
        static void Update()
        {
            Console.Write("Id: ");
            var id = int.Parse(Console.ReadLine());
            using (var ctx = new TestContext())
            {
                try
                {
                    string tempinput;
                    var customers = ctx.Clients.Find(id);

                    Console.Write("FirstName: ");
                    tempinput = Console.ReadLine();
                    if (string.IsNullOrEmpty(tempinput))
                        customers.FirstName = tempinput;

                    Console.Write("SecondName: ");
                    tempinput = Console.ReadLine();
                    if (string.IsNullOrEmpty(tempinput))
                        customers.LastName = tempinput;

                    Console.Write("PhoneNumb: ");
                    tempinput = Console.ReadLine();
                    if (string.IsNullOrEmpty(tempinput))
                        customers.PhoneNum = tempinput;

                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
        static void Delete()
        {
            Console.Write("Id: ");
            var id = int.Parse(Console.ReadLine());

            using (var ctx = new TestContext())
            {
                try
                {
                    var customers = ctx.Clients.Find(id);
                    ctx.Remove(customers);
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

    }
}
