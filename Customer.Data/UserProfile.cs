
public class UserProfile
{
    public UserProfile()
    {

    }
    public UserProfile(string name, int age)
    {
        Name = name;
        Age = age;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public List<Hobby> Hobbies { get; set; } = new List<Hobby>();
}
