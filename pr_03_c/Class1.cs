namespace pr_03_c
{
    public class Zamestnanec : Osoba
    {
        public decimal plat;
        public void PridejPlat(decimal plat)
        {
            this.plat += plat;
        }   
    }
    public class Osoba
    {
        public string name;
        public DateTime birthDate = new DateTime(2000, 1, 1);
        /*private Osoba()
        {
        }
        public static Osoba Create(string name, DateTime birthDate)
        {
            return new Osoba();
        }*/
        //public Osoba(){ this.name = "John Doe";}
        public Osoba() : this("John Doe")
        {
            //...
        }
        public Osoba(string name) : this(name, new DateTime(2000, 1, 1))
        {
            //...
        }   
        public Osoba(string name, DateTime birthDate)
        {
            this.name = name;
            this.birthDate = birthDate;
        }

        public void VytvorJmeno(Osoba o, Osoba n)
        {
            this.name = o.name + " " + n.name;
        }
    }
}
