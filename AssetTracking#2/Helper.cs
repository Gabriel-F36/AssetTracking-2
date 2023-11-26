using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking_2
{
    internal class Helper
    {
        // Checking a products age
        // If a product is older then 2.5 years (30 months) it will change the text to yellow
        // If a product is older then 2.75 years (33 months) it will change the text to darkred
        public void ProductEndOfLife(string date)
        {
            DateTime currentDate = DateTime.Now;
            DateTime Date = Convert.ToDateTime(date);
            TimeSpan timeSpan = currentDate - Date;
            int daysBetween = timeSpan.Days;
            if ((365 * 3) - daysBetween < 180)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            if ((365 * 3) - daysBetween < 90)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }
        }
        //
        public void PrintTableHeader(int a, int b, int c, int d, int e, int f)
        {
            Console.WriteLine(
                "ID".PadRight(a) +
                "Appliance Name".PadRight(b) +
                "Brand".PadRight(c) +
                "Model Name".PadRight(d) +
                "Purchase Date".PadRight(e) +
                "Inches".PadRight(f) +
                "Price"
                );
            Console.WriteLine(
                "--".PadRight(a) +
                "--------------".PadRight(b) +
                "-----".PadRight(c) +
                "----------".PadRight(d) +
                "-------------".PadRight(e) +
                "------".PadRight(f) +
                "-----"
                );
        }
        public void PrintLaptopTableContent(int a, int b, int c, int d, int e, int f, LaptopComputers item)
        {
            Console.WriteLine(
                item.id.ToString().PadRight(a) +
                item.applianceName.PadRight(b) +
                item.brand.PadRight(c) +
                item.modelName.PadRight(d) +
                item.purchaseDate.PadRight(e) +
                item.screenSizeInches.ToString().PadRight(f) +
                item.price.ToString()
                );
        }
        public void PrintPhoneTableContent(int a, int b, int c, int d, int e, int f, MobilePhones item)
        {
            Console.WriteLine(
                item.id.ToString().PadRight(a) +
                item.applianceName.PadRight(b) +
                item.brand.PadRight(c) +
                item.modelName.PadRight(d) +
                item.purchaseDate.PadRight(e) +
                item.screenSizeInches.ToString().PadRight(f) +
                item.price.ToString()
                );
        }
    }
}
