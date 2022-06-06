namespace Nordek.Models;

public class User
{
    public System.Int64 id { get; set; }
    public string login { get; set; }


    public User(System.Int64 id, string login)
    {
        this.id = id;
        this.login = login;
    }

    public User(string login)
    {
        this.login = login;
    }
    public override string ToString()
    {
        return login;
    }
}