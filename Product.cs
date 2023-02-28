namespace ShopProjectFinal;

public class Product
{
    private string _name;
    private double _price;
    private double _dph;


    public Product(string name, double price, double dph)
    {
        this._name = name;
        this._price = price;
        this._dph = dph;
    }

    public void PrintOutThePriceLine(int amount) // For the check
    {
        double totalPrice;
        if (this._dph > 21)
        { 
            totalPrice = (this._price * amount) + (((this._price * amount) * this._dph) / 121);
        }
        else
        {
            totalPrice = (this._price * amount) + (((this._price * amount) * this._dph) / 115);
        }
        
        Console.WriteLine($"{this._name}.............{this._price}x{amount}.........{totalPrice}");
    }

    public void OfferTheProduct(int id)
    {
        Console.WriteLine($"{id}........{this._name}........{this._price}");
    }

    public string ReturnStringOfFullPrice(int amount) // For the check
    {
        double totalPrice;
        if (this._dph > 21)
        { 
            totalPrice = (this._price * amount) + (((this._price * amount) * this._dph) / 121);
        }
        else
        {
            totalPrice = (this._price * amount) + (((this._price * amount) * this._dph) / 115);
        }
        
       string line = $"{this._name}.............{this._price}x{amount}.........{totalPrice}";
       return line;
    }

}