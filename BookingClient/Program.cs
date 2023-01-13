using BookingVbNetApi;
using BookingVbNetApi.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Data;
using System.Diagnostics;
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
            //Calling API with container
            IBookingVbApi _bookingVbApi = new BookingVbApi(Configuration.GetConnectionString("HotelRealtaDS"));


            //User Breakfast
            //var listUserbreakfast = _bookingVbApi.RepositoryManager.Usbr.FindAllUsbr();
            //foreach (var item in listUserbreakfast)
            //{
            //    Console.Write(item);
            //}

            //findusbr
            //var foundedUsbr = _bookingVbApi.RepositoryManager.Usbr.FindUsbrByDate("2023-01-01", 2);
            //Console.WriteLine($" founded data : {foundedUsbr}");

            //create usbr
            //var createdUsbr = _bookingVbApi.RepositoryManager.Usbr.CreateNewUsbr(
            //    new BookingVbNetApi.Model.Usbr
            //    {
            //        Usbr_borde_id = 4,
            //        Usbr_modified_date = "2023-01-01",
            //        Usbr_total_vacant = 10
            //    });
            //Console.WriteLine($"New User Breakfast Data = {createdUsbr}");

            //delete usbr
            var rowDeleted = _bookingVbApi.RepositoryManager.Usbr.DeleteUsbr('')



            //Special Offers Coupons
            //FindAllSoco
            //var listSoco = _bookingVbApi.RepositoryManager.Soco.FindAllSoco();
            //foreach (var soco in listSoco)
            //{
            //    Console.WriteLine($"{soco}");

            //}

            ///.findsoco
            //var foundedSoco = _bookingVbApi.RepositoryManager.Soco.FindSocoById(10);
            //Console.WriteLine($"founded soco : {foundedSoco}");


            //BOOKING ORDER DETAIL TABLE
            //FindAllBorde
            //var listBorde = _bookingVbApi.RepositoryManager.Borde.FindAllBorde();
            //foreach (var item in listBorde)
            //{
            //    Console.WriteLine($"{item}");
            //}

            //FindAllBordeAsnyc
            //Console.WriteLine("============= ASYNC ============");
            //var listBordeAsync = await _bookingVbApi.RepositoryManager.Borde.FindAllBordeAsync();
            //foreach (var item in listBordeAsync)
            //{
            //    Console.WriteLine($"{item}");
            //}

            //FindBordeById
            //var findedbordebyid = _bookingVbApi.RepositoryManager.Borde.FindBordeById(29);
            //Console.WriteLine($"founded data {findedbordebyid}");

            //CreateBorde
            //var createdBorde = _bookingVbApi.RepositoryManager.Borde.CreateNewBorde(new BookingVbNetApi.Model.Borde
            //{
            //    Borde_boor_id = 10,
            //    Borde_checkin = "2023-02-21",
            //    Borde_checkout = "2023-03-23",
            //    Borde_adults = 2,
            //    Borde_kids = null,
            //    Borde_price = 500,
            //    Borde_extra = 50,
            //    Borde_discount = 0.25m,
            //    Borde_tax = 0.11m,
            //    Borde_subtotal = 500,
            //    Borde_faci_id = 1
            //});
            //Console.WriteLine($"Created new Borde : {createdBorde}");

            //UpdateBorde
            //var updatedBorde = _bookingVbApi.RepositoryManager.Borde.UpdateBordeBySp(
            //    borde_id: 44,
            //    borde_boor_id: 11,
            //    borde_checkin: "2023-02-10",
            //    borde_checkout: "2023-02-12",
            //    borde_adults: 20,
            //    borde_kids: 20,
            //    borde_price: 2000,
            //    borde_extra: 200,
            //    borde_discount: 0.50m,
            //    borde_tax: 0.10m,
            //    borde_subtotal: 9000,
            //    borde_faci_id: 1);
            ////var updatedBordeById = _bookingVbApi.RepositoryManager.Borde.UpdateBordeById(borde_id: 44, borde_price: 5000, borde_discount: 0.40m, borde_tax: 0.22m, true);
            //var findedbordebyid = _bookingVbApi.RepositoryManager.Borde.FindBordeById(44);
            //Console.WriteLine($"founded data {findedbordebyid}");


            //DeleteBordeById
            //Int32 rowAffected = _bookingVbApi.RepositoryManager.Borde.DeleteBorde(18);
            //if (rowAffected != 0)
            //{
            //    Console.WriteLine($"Delete success,{rowAffected.ToString()} row affected ");
            //}


            //BOOKING_ORDERS
            //findBookingOrders
            //var listOrder = _bookingVbApi.RepositoryManager.Booking.FindAllBookingOrders();
            //foreach (var item in listOrder)
            //{
            //    Console.WriteLine($"{item}");
            //}

            //updateBookingOrders
            //var updateBoorBySp = _bookingVbApi.RepositoryManager.Booking.UpdateBookingBySp(16, "", "", "");
            //Console.WriteLine($" updated data :{updateBoorBySp}");


            static void BuildConfig()
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);
                Configuration = builder.Build(); //Container bring configuration
            }

        }
    }
}
