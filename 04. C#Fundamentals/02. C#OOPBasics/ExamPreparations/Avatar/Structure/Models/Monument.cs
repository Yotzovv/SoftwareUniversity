public abstract class Monument
{
    private string name;

    public Monument(string name)
    {
        this.Name = name;
    }

    public string Name { get { return this.name; }
        private set
        {
            this.name = value;
        }
    }

    public abstract int GetAffinity();

    public override string ToString()
    {
        string monumentType = GetType().Name;
        int typeEnd = monumentType.IndexOf("Monument");
        monumentType = monumentType.Insert(typeEnd, " ");

        return $"{monumentType}: {Name}";
    }
}