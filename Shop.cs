

namespace ShopProjectFinal;

public class Shop
{
    private Dictionary<int, Product> _products = new Dictionary<int, Product>(); // ID : Product
    private Dictionary<int, int> _customersCart = new Dictionary<int, int>(); // ID : Amount
    private string _filePath = "";

    public void GetFilePath()// reads users file with data
    {
        bool state = false;
        do
        {
            Console.Clear();
            Console.WriteLine("Please, enter your file path.");
            _filePath = Console.ReadLine()!;
            if (String.IsNullOrEmpty(_filePath))
            {
                Console.WriteLine("Cannot go to that pass");
            }
            else
            {
                state = FileIsRight(_filePath);
            }
        } while (state == false);
    }

    private bool FileIsRight(string filePath)
    {
        if (File.Exists(filePath))
        {
            string line;
            using (StreamReader sr = new StreamReader(filePath))
            {
                line = sr.ReadLine()!;
            }

            if (!(String.IsNullOrEmpty(line)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public void PrintOutTheContextMenu() // do/while cycle here
    {
        FillTheProducts();
        string state;
        do
        {
          Console.Clear();
          Console.WriteLine("ID.........NAME........PRICE");
          OfferProductsToTheCustomer();
          ShowTheStartMenu();
          state = Console.ReadLine()!.ToLower();
          if (String.IsNullOrEmpty(state))
          {
              Console.WriteLine("No such command");
              state = "n";
          }
          else
          {
             state = ValidateTheAnswer(state);
          }
        } while (state != "e");
        
    }

    private void OfferProductsToTheCustomer()
    {
        foreach (var keyValuePair in this._products)
        {
            keyValuePair.Value.OfferTheProduct(keyValuePair.Key);
        }
    }

    public void FillTheProducts() // Filling the hashmap from the specific file
    {
        string lineOfFile;
        using (StreamReader sr = new StreamReader(_filePath))
        {
            while ((lineOfFile = sr.ReadLine()!) != null)
            {
                var values = lineOfFile.Split(";");
                this._products.Add(Convert.ToInt32(values[0]), new Product(values[1], Convert.ToDouble(values[2]),Convert.ToDouble(values[3])));
            }
        }
    }

    private string ValidateTheAnswer(string answer)
    {
        switch (answer)
        {
            case "p":
                PutProductInCart();
                return "p";
            case "c":
                OpenTheCart();
                return "c";
            case "b" :
                CheckCustomerOut();
                return "e";
            case "e":
                return "e";
            default:
                return "n";
        }
        
    }

    private void CheckCustomerOut()
    {
        using (StreamWriter sw = new StreamWriter("Check.txt"))
        {
            sw.WriteLine("Name............Amount.........Price");
            foreach (var kvpair in this._customersCart)
            {
                sw.WriteLine(this._products[kvpair.Key].ReturnStringOfFullPrice(kvpair.Value));
            }
        }
    }

    private void OpenTheCart()
    {
        Console.Clear();
        foreach (var kvpair in this._customersCart)
        {
            this._products[kvpair.Key].PrintOutThePriceLine(kvpair.Value);
        }

        Console.ReadLine();
    }

    private void PutProductInCart()
    {
        int id;
        int amount;
        Console.WriteLine("Please enter your product ID:");
        id = Convert.ToInt32(Console.ReadLine());
        if (id > 0 && id < 21)
        {
            Console.WriteLine("Please enter the amount:");
            amount = Convert.ToInt32(Console.ReadLine());
            if (InTheCart(id))
            {
                this._customersCart[id] += amount;
            }
            else
            {
                this._customersCart.Add(id, amount);
            }
        }
        else
        {
            Console.WriteLine("Sorry, we don't have that");
        }
        
    }

    private bool InTheCart(int id)
    {
        if (this._customersCart.ContainsKey(id))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void ShowTheStartMenu() // Shows menu on the screen
    {
        Console.WriteLine("[p]Pick a product");
        Console.WriteLine("-----------------");
        Console.WriteLine("[c]Open a cart");
        Console.WriteLine("-----------------");
        Console.WriteLine("[b]Make a purchase");
        Console.WriteLine("------------------");
        Console.WriteLine("[e]Exit");
    }
    
}
