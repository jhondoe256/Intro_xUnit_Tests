
public class GremlinRepository
{
    //WE NEED 1ST COME 1ST SERVED BEHAVIOUR....
    //THERE IS A COLLECTION THAT WILL DO THAT FOR US....
    //F.I.F.O (First in First Out)  => Queue<T>
    private readonly Queue<GremlinEntity> _gDatabase = new Queue<GremlinEntity>();
    private int _count;
    //Create
    public bool AddGremlinToDatabase(GremlinEntity gremlin)
    {
        if (gremlin is null)
        {
            return false;
        }
        else
        {
            _count++;
            gremlin.Id = _count;
            _gDatabase.Enqueue(gremlin); //how we add with a queue...
            return true;
        }
    }
    //Read (All)
    public Queue<GremlinEntity> GetGremlins()
    {
        return _gDatabase;
    }

    //Read (one)
    public GremlinEntity GetGremlin()
    {
        //this allows us to "see" whos next in line (doesn't remove it)
        GremlinEntity gEntity = _gDatabase.Peek();
        return gEntity;
    }

    //Delete -> Processing the Grimlin 
    public bool ProcessGremlin()
    {
        if (_gDatabase.Count > 0)
        {
            _gDatabase.Dequeue();
            return true;
        }
        return false;
    }

}
