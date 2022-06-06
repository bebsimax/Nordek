namespace Nordek.Models;

public class ObjectInDB
{
    public string Name { get; set; }
    public ObjectInDB(string type)
    {
        Name = type;
    }


}