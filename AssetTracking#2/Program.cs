
using AssetTracking_2;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Windows;

// padding for printing tables
int a = 5; // Padding id
int b = 17; // Padding applianceName
int c = 16; // Padding brand
int d = 23; // Padding modelName
int e = 16; // Padding purchase date
int f = 9; // Padding screenSizeinches



MyDbContext context = new MyDbContext();
Helper helper = new Helper();
List<LaptopComputers> laptopList = context.Laptops.OrderByDescending(x => x.purchaseDate).ToList();
List<MobilePhones> phoneList = context.Phones.OrderByDescending(x => x.purchaseDate).ToList();

Console.ForegroundColor = ConsoleColor.DarkYellow;
Console.WriteLine("Welcome to Asset Tracking 2.0");
Console.WriteLine();


while (true)
{
Start:
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.WriteLine("(1) Create new listing");
    Console.WriteLine("(2) Show database");
    Console.WriteLine("(3) Update/Delete listing");
    Console.WriteLine();
    Console.ResetColor();

    string data = Console.ReadLine().Trim();

    // Option 1: Add listing
    if (data == "1")
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Need to add appliance name, id, brand, modelName, purchaseDate, screenSizeInches, price");
        Console.ResetColor();
        Console.WriteLine();

        // APPLIANCE NAME
    AppNameAgain:
        Console.WriteLine("Write 'LC' for laptopComputers or 'MP' for MobilePhones");
        string appIdName = Console.ReadLine().ToLower().Trim();
        if (!(appIdName == "lc" || appIdName == "mp"))
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Please input a valid option");
            Console.ResetColor();
            goto AppNameAgain;
        }
        // ID
    tryIdAgain:
        Console.WriteLine("Give a product id");
        string idStr = Console.ReadLine().Trim();
        int id = 0;
        try
        {
            id = int.Parse(idStr);
        }
        catch (FormatException)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Not a valid number, try again");
            Console.ResetColor();
            goto tryIdAgain;
        }
        // BRAND
        Console.WriteLine("Write brand name");
        string brand = Console.ReadLine().Trim();
        // MODEL NAME
        Console.WriteLine("Write model name");
        string modelName = Console.ReadLine().Trim();
        // PURCHASE DATE
    tryDate:
        Console.WriteLine("Purchase date (yyyy-mm-dd)");
        string purchaseDate = Console.ReadLine().Trim();

        if (!DateTime.TryParse(purchaseDate, out DateTime dateValue))
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Please enter in the correct format (yyyy-mm-dd)");
            Console.ResetColor();
            goto tryDate;
        }
        // SCREEN SIZE
    tryScreenSizeAgain:
        Console.WriteLine("Screen size in inches, for example: 17");
        string screenSizeStr = Console.ReadLine().Trim();
        int screenSize = 0;
        try
        {
            screenSize = int.Parse(screenSizeStr);
        }
        catch (FormatException)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Not a valid number, try again");
            Console.ResetColor();
            goto tryScreenSizeAgain;
        }
        // PRICE
    tryPriceAgain:
        Console.WriteLine("Price of product as a whole number");
        string priceStr = Console.ReadLine().Trim();
        int price = 0;
        try
        {
            price = int.Parse(priceStr);
        }
        catch (FormatException)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Not a valid number, try again");
            Console.ResetColor();
            goto tryPriceAgain;
        }
        // CONFIRM
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Press 'Enter' to confirm, or 'q' to cancel");
        Console.ResetColor();

        data = Console.ReadLine().ToLower().Trim();
        if (data == "q")
        {
            goto Start;
        }
        // Checking which table to put the listing in
        if (appIdName == "lc")
        {
            LaptopComputers newLaptop = new LaptopComputers();
            newLaptop.applianceName = "Laptop Computer";
            newLaptop.brand = brand;
            newLaptop.modelName = modelName;
            newLaptop.purchaseDate = purchaseDate;
            newLaptop.screenSizeInches = screenSize;
            newLaptop.price = price;
            context.Laptops.Add(newLaptop);
            context.SaveChanges();
        }
        else if (appIdName == "mp")
        {
            MobilePhones newPhone = new MobilePhones();
            newPhone.applianceName = "Mobile Phone";
            newPhone.brand = brand;
            newPhone.modelName = modelName;
            newPhone.purchaseDate = purchaseDate;
            newPhone.screenSizeInches = screenSize;
            newPhone.price = price;
            context.Phones.Add(newPhone);
            context.SaveChanges();
        }
        continue;

    }

    // Option 2: Read data from Database
    if (data == "2")
    {
        helper.PrintTableHeader(a, b, c, d, e, f);

        laptopList = context.Laptops.OrderByDescending(x => x.purchaseDate).ToList();
        phoneList = context.Phones.OrderByDescending(x => x.purchaseDate).ToList();

        foreach (LaptopComputers item in laptopList)
        {
            helper.ProductEndOfLife(item.purchaseDate);
            helper.PrintLaptopTableContent(a, b, c, d, e, f, item);
            Console.ResetColor();
        }
        foreach (MobilePhones item in phoneList)
        {
            helper.ProductEndOfLife(item.purchaseDate);
            helper.PrintPhoneTableContent(a, b, c, d, e, f, item);
            Console.ResetColor();
        }
        continue;
        

    }
    // Option 3: Edit/Update listing
    if (data == "3")
    {
    DeleteOrUpdate:
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Delete 'D' or update 'U' Listing?");
        Console.ResetColor();
        string deleteOrUpdate = Console.ReadLine().ToLower().Trim();
        if (!(deleteOrUpdate == "d" || deleteOrUpdate == "u"))
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Please input a valid option");
            Console.ResetColor();
            goto DeleteOrUpdate;
        }

    AppNameAgain:
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Write 'LC' for laptopComputers or 'MP' for MobilePhones");
        Console.ResetColor();
        string appIdName = Console.ReadLine().ToLower().Trim();
        if (!(appIdName == "lc" || appIdName == "mp"))
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Please input a valid option");
            Console.ResetColor();
            goto AppNameAgain;
        }

        int i = 0;
        helper.PrintTableHeader(a, b, c, d, e, f);
        if (appIdName == "lc")
        {
            foreach (LaptopComputers item in laptopList)
            {
                if (i % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                }
                else
                {
                    Console.ResetColor();
                }
                helper.PrintLaptopTableContent(a, b, c, d, e, f, item);
                i ++;
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Please select an id to update/delete corresponding listing");
            Console.ResetColor(); 
        tryNumberAgain:
            string currentIdStr = Console.ReadLine().Trim();
            int currentId;
            LaptopComputers laptop;
            try
            {
                currentId = Int32.Parse(currentIdStr);
                laptop = context.Laptops.FirstOrDefault(x => x.id == currentId);
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("not a valid number, try again");
                Console.ResetColor();
                goto tryNumberAgain;
            }
            if (deleteOrUpdate == "d")
            {
                try
                {
                    context.Laptops.Remove(laptop);
                    context.SaveChanges();
                }
                catch (ArgumentNullException)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("id out of range or a null value exists");
                    Console.WriteLine("changes were not saved");
                    Console.ResetColor();
                    goto Start;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Removed successfully");
                Console.ResetColor();
                continue;
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Pleas update desired fields, if left empty/blank it will retain it's current value");
            Console.ResetColor();
            // BRAND
            Console.WriteLine("Write brand name");
            string brand = Console.ReadLine().Trim();
            // MODEL NAME
            Console.WriteLine("Write model name");
            string modelName = Console.ReadLine().Trim();
        // PURCHASE DATE
        tryDate:
            Console.WriteLine("Purchase date (yyyy-mm-dd)");
            string purchaseDate = Console.ReadLine().Trim();
            if (purchaseDate == "") { }
            else if (!DateTime.TryParse(purchaseDate, out DateTime dateValue))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Please enter in the correct format (yyyy-mm-dd)");
                Console.ResetColor();
                goto tryDate;
            }
        // SCREEN SIZE
        tryScreenSizeAgain:
            Console.WriteLine("Screen size in inches, for example: 17");
            string screenSizeStr = Console.ReadLine().Trim();
            int screenSize = 0;
            if (screenSizeStr == "") { }
            else
            {
                try
                {
                    screenSize = int.Parse(screenSizeStr);
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Not a valid number, try again");
                    Console.ResetColor();
                    goto tryScreenSizeAgain;
                }
            }

        // PRICE
        tryPriceAgain:
            Console.WriteLine("Price of product as a whole number");
            string priceStr = Console.ReadLine().Trim();
            int price = 0;
            if (priceStr == "") { }
            else
            {
                try
                {
                    price = int.Parse(priceStr);
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Not a valid number, try again");
                    Console.ResetColor();
                    goto tryPriceAgain;
                }
            }

            if (!(brand == ""))
            {
                laptop.brand = brand;
            }
            if (!(modelName == ""))
            {
                laptop.modelName = modelName;
            }
            if (!(purchaseDate == ""))
            {
                laptop.purchaseDate = purchaseDate;
            }
            if (!(screenSizeStr == ""))
            {
                Console.WriteLine(screenSize + "printed if null");
                laptop.screenSizeInches = screenSize;
            }
            if (!(priceStr == ""))
            {
                laptop.price = price;
            }
            // CONFIRM
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Press 'Enter' to confirm, or 'q' to cancel");
            Console.ResetColor();

            data = Console.ReadLine().ToLower().Trim();
            if (data == "q")
            {
                goto Start;
            }
            try
            {
                context.Laptops.Update(laptop);
                context.SaveChanges();
            }
            catch (ArgumentNullException)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("id out of range or a null value exists");
                Console.WriteLine("changes were not saved");
                Console.ResetColor();
                goto Start;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------
        else if (appIdName == "mp")
        {
            foreach (MobilePhones item in phoneList)
            {
                if (i % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                }
                else
                {
                    Console.ResetColor();
                }
                helper.PrintPhoneTableContent(a, b, c, d, e, f, item);
                i ++;
            }
            
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Please select an id to update/delete corresponding listing");
            Console.ResetColor();
        tryNumberAgain:
            string currentIdStr = Console.ReadLine().Trim();
            int currentId;
            MobilePhones phone;
            try
            {
                currentId = Int32.Parse(currentIdStr);
                phone = context.Phones.FirstOrDefault(x => x.id == currentId);
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("not a valid number, try again");
                Console.ResetColor();
                goto tryNumberAgain;
            }

            if (deleteOrUpdate == "d")
            {
                try
                {
                    context.Phones.Remove(phone);
                    context.SaveChanges();
                }
                catch (ArgumentNullException)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("id out of range or a null value exists");
                    Console.WriteLine("changes were not saved");
                    Console.ResetColor();
                    goto Start;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Removed successfully");
                Console.ResetColor ();  
                continue;
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Pleas update desired fields, if left empty/blank it will retain it's current value");
            Console.ResetColor();
            // BRAND
            Console.WriteLine("Write brand name");
            string brand = Console.ReadLine().Trim();
            // MODEL NAME
            Console.WriteLine("Write model name");
            string modelName = Console.ReadLine().Trim();
        // PURCHASE DATE
        tryDate:
            Console.WriteLine("Purchase date (yyyy-mm-dd)");
            string purchaseDate = Console.ReadLine().Trim();
            if (purchaseDate == ""){ }
            else if (!DateTime.TryParse(purchaseDate, out DateTime dateValue))
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Please enter in the correct format (yyyy-mm-dd)");
                Console.ResetColor();
                goto tryDate;
            }
        // SCREEN SIZE
        tryScreenSizeAgain:
            Console.WriteLine("Screen size in inches, for example: 17");
            string screenSizeStr = Console.ReadLine().Trim();
            int screenSize = 0;
            if (screenSizeStr == ""){ }
            else
            {
                try
                {
                    screenSize = int.Parse(screenSizeStr);
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Not a valid number, try again");
                    Console.ResetColor();
                    goto tryScreenSizeAgain;
                }
            }

        // PRICE
        tryPriceAgain:
            Console.WriteLine("Price of product as a whole number");
            string priceStr = Console.ReadLine().Trim();
            int price = 0;
            if (priceStr == ""){ }
            else
            {
                try
                {
                    price = int.Parse(priceStr);
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Not a valid number, try again");
                    Console.ResetColor();
                    goto tryPriceAgain;
                }
            }

            if (!(brand == ""))
            {
                phone.brand = brand;
            }
            if (!(modelName == ""))
            {
                phone.modelName = modelName;
            }
            if (!(purchaseDate == ""))
            {
                phone.purchaseDate = purchaseDate;
            }
            if (!(screenSizeStr == ""))
            {
                Console.WriteLine(screenSize + "printed if null");
                phone.screenSizeInches = screenSize;
            }
            if (!(priceStr == ""))
            {
                phone.price = price;
            }
            // CONFIRM
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Press 'Enter' to confirm, or 'q' to cancel");
            Console.ResetColor();

            data = Console.ReadLine().ToLower().Trim();
            if (data == "q")
            {
                goto Start;
            }
            try
            {
                context.Phones.Update(phone);
                context.SaveChanges();
            }
            catch (ArgumentNullException)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("id out of range or a null value exists");
                Console.WriteLine("changes were not saved");
                Console.ResetColor();
                goto Start;
            }
        }
        
        
    }

    // Option 4: Delete listing
    if (data == "4")
    {
        
    }
}