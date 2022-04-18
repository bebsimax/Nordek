namespace Nordek.Models;

public class User
{
    public int ID { get; set; }
    public string login { get; set; }


    public override string ToString()
    {
        return login;
    }
}