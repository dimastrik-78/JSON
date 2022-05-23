
public class SomeData
{
    public string Name;
    public string Description;

    public SomeData(string name, string description)
    {
        Name = name;
        Description = description;
    }
}
public class SomeDataBase
{
    public SomeData[] SomeDB;

    public SomeDataBase(SomeData[] db)
    {
        SomeDB = db;
    }
}