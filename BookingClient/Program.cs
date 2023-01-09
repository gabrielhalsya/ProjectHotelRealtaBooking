using BookingVbNetApi;
using Microsoft.Extensions.Configuration;
using System;
using System.Globalization;
using System.Reflection;

namespace BookingClient
{
    internal class Program
    {
        private static IConfiguration Configuration;
        static void Main(string[] args)
        {
            BuildConfig();
            //_bookingVbApi.SayHello();

            IBookingVbApi _bookingVbApi = new BookingVbApi(Configuration.GetConnectionString("HotelRealtaDS"));

            ////FIND ALL BOOKING
            var listOrder = _bookingVbApi.RepositoryManager.Booking.FindAllBookingOrders();
            foreach (var item in listOrder)
            {
                Console.WriteLine($"{item}");
            }
            Console.WriteLine();

            //var updateBoorBySp = _bookingVbApi.RepositoryManager.Booking.UpdateBookingBySp(16,"","","");
            //Console.WriteLine($" updated data :{updateBoorBySp}");

            //}
            static void BuildConfig()
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);
                Configuration = builder.Build(); //Container menyimpan Configuration
                //Console.WriteLine(Configuration.GetConnectionString("HotelRealtaDS"));
            }

        }
    }
}
