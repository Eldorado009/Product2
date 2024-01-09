string Welcome = "  _      _________________  __  _________\r\n | | /| / / __/ / ___/ __ \\/  |/  / __/ /\r\n | |/ |/ / _// / /__/ /_/ / /|_/ / _//_/ \r\n |__/|__/___/_/\\___/\\____/_/  /_/___(_)  \r\n                                         ";
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine(Welcome);
string Option = "Option download:)";
Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine(Option);
Console.ResetColor();


Directory.CreateDirectory(@".\Product");
if (!File.Exists(@".\Product\product.txt"))
{
    File.Create(@".\Product\product.txt");
}
bool run = true;
while (run)
{
    Console.ForegroundColor = ConsoleColor.DarkBlue;
    Console.WriteLine("1 - Create Product \n" +
                      "2 - Show All\n" +
                      "0 - Close");
    Console.ResetColor();


    string? option = Console.ReadLine();
    int optionNumber;
    bool isInt = int.TryParse(option, out optionNumber);
    if (isInt)
    {
        if (optionNumber >= 0 && optionNumber <= 2)
        {
            switch (optionNumber)
            {
                case (int)Menu.CreateProduct:
                    try
                    {
                        Console.Write("Enter products ID: ");
                        int Id;
                        while (!int.TryParse(Console.ReadLine(), out Id) || (Id < 0))
                        {
                            throw new Exception("incorrect format ID! Please try again");
                        }
                        Console.Write("Enter products Name: ");
                        string Name = Console.ReadLine();
                        while (String.IsNullOrEmpty(Name))
                        {
                            throw new ArgumentException();
                        }
                        Console.Write("Enter products Price: ");
                        decimal Price;
                        while (!decimal.TryParse(Console.ReadLine(), out Price) || (Price < 0))
                        {
                            throw new Exception("Incorrect format Price! Please try again");
                        }
                        Product product = new(Id, Name, Price);
                        StreamWriter sw = new(@".\Product\product.txt", true);
                        sw.WriteLine($"ID: {product.Id}\n" +
                                     $"Name: {product.Name}\n" +
                                     $"Price: {product.Price}");
                        sw.Close();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("was created");
                        Console.ResetColor();
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        Console.ResetColor();
                        goto case (int)Menu.CreateProduct;
                    }
                    break;
                case (int)Menu.ShowAll:
                    try
                    {
                        if (File.Exists(@".\Product\product.txt"))
                        {
                            string[] products = File.ReadAllLines(@".\Product\product.txt");
                            if (products.Length > 0)
                            {
                                Console.WriteLine("All products : ");
                                foreach (var product in products)
                                {
                                    Console.WriteLine(product);
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("There are no created products!");
                                Console.ResetColor();
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("The files where the products are stored were not found!");
                            Console.ResetColor();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        goto case (int)Menu.ShowAll;
                    }
                    break;
                case 0:
                    run = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Application closed!");
                    Console.ResetColor();
                    break;
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please enter correct number!");
            Console.ResetColor();
        }
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Please enter correct format!");
        Console.ResetColor();
    }
}

