namespace Nordek.Models;

public class Noun
{
    /* Entall - singular, Flertall - plural
     Ubestemt - unspecified, Bestemt - specified */
    public int ID { get; set; }
    public int ArtikkelID { get; set; }
    public string EntallU { get; set; }
    public string EntallB { get; set; }
    public string FlertallU { get; set; }
    public string FlertallB { get; set; }
    public bool Active { get; set; }
    public bool Regular { get; set; }

    public Noun(int ID, int ArtikkelID, string EntallU, string EntallB, string FlertallU, string FlertallB, bool Active, bool Regular)
    {
        this.ID = ID;
        this.ArtikkelID = ArtikkelID;
        this.EntallU = EntallU;
        this.EntallB = EntallB;
        this.FlertallU = FlertallU;
        this.FlertallB = FlertallB;
        this.Active = Active;
        this.Regular = Regular;
    }
}