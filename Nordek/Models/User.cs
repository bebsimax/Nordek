namespace Nordek.Models;

public class User
{
    public int id { get; set; }
    public string login { get; set; }


    public User(int id, string login)
    {
        this.id = id;
        this.login = login;
    }
    public override string ToString()
    {
        return login;
    }
}