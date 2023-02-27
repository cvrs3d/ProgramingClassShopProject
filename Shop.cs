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
        string state = " ";
        do
        {
          Console.Clear();
          Console.WriteLine("ID.........NAME........PRICE");
          OfferProductsToTheCustomer();
          ShowTheStartMenu();
          // поставить тут валидацию
        } while (state != "e");
        
    }

    private void OfferProductsToTheCustomer()
    {
        // доделать выписку всех элементов хеша
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

    private void ValidateTheAnswer(string answer)
    {
        // здесь сделать свитч кейс
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
