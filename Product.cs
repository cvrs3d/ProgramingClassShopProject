namespace ShopProjectFinal;

public class Product // Class that represent products in store
{
    private readonly string _name;  // Fields
    private readonly double _price;
    private readonly double _dph;
    private const double Dph15 = 15.0 / 115.0;
    private const double Dph21 = 21.0 / 121.0;


    public Product(string name, double price, double dph) // Constructor
    {
        this._name = name;
        this._price = price;
        this._dph = dph;
    }

    public void PrintOutThePriceLine(int amount) // This method prints out all product info (used in Shop.OpenTheCart())
    {
        double totalPrice;
        if (this._dph > 21)
        { 
            totalPrice = (this._price * amount) + (((this._price * amount) * Dph21));
        }
        else
        {
            totalPrice = (this._price * amount) + (((this._price * amount) * Dph15));
        }
        
        Console.WriteLine($"{this._name}.............{this._price}x{amount}.........{totalPrice}");
    }

    public void OfferTheProduct(int id) // Using this method to offer a product to a customer
    {
        Console.WriteLine($"{id}........{this._name}........{this._price}");
    }

    public string ReturnStringOfFullPrice(int amount) // Using this method to write data into the .txt file (Output of the program)
    {
        double totalPrice;
        if (this._dph > 20)
        { 
            totalPrice = (this._price * amount) + ((this._price * amount) * Dph21);
        }
        else
        {
            totalPrice = (this._price * amount) + ((this._price * amount) * Dph15);
        }
        
        string line = $"{this._name}.............{this._price}x{amount}.........{totalPrice}";
        return line;
    }

    public double GetPrice(int amount)
    {
        double priceToReturn;
        if (this._dph > 20)
        { 
            priceToReturn = (this._price * amount) + ((this._price * amount) * Dph21);
        }
        else
        {
            priceToReturn = (this._price * amount) + ((this._price * amount) * Dph15);
        }

        return priceToReturn;
    }

    public string PrintDphString(int amount)
    {
        string strToPrint;
        if (this._dph > 20)
        {
            strToPrint =
                $"{this._dph}......{this._price}.....{this._price * Dph21}....{(this._price * amount) + ((this._price * amount) * Dph21)}";
        }
        else
        {
            strToPrint =
                $"{this._dph}......{this._price}.....{this._price * Dph15}....{(this._price * amount) + ((this._price * amount) * Dph15)}";
        }

        return strToPrint;
    }
}