
public class GremlinEntity
{
    public int Id { get; set; }
    public string Name { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}\nName: {Name}\n------------------------------------\n";
    }

}
