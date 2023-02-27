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

    public void PrintOutThePriceLine(int amount)
    {
        // выведет строку цены продукта по всем стандартам чека
    }
    
    
}