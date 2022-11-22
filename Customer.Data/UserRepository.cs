
public class UserRepository
{
    private readonly List<UserProfile> _userDb = new List<UserProfile>();
    private int _count;

    public UserRepository()
    {
        Seed();
    }
    //create
    public bool AddUser(UserProfile customer)
    {
        if (customer is null)
        {
            return false;
        }
        else
        {
            _count++;
            customer.Id = _count;
            _userDb.Add(customer);
            return true;
        }
    }

    //read (all from db)
    public List<UserProfile> GetUserProfiles()
    {
        return _userDb;
    }

    //read by id (one)
    public UserProfile GetUserProfile(int userId)
    {
        //look in the entire database
        foreach (UserProfile user in _userDb)
        {
            if (user.Id == userId)
            {
                return user;
            }
        }
        return null;
    }

    //update
    public bool Update(int userId, UserProfile updatedData)
    {
        UserProfile profileInDb = GetUserProfile(userId);

        if (profileInDb != null)
        {
            profileInDb.Name = updatedData.Name;
            profileInDb.Age = updatedData.Age;
            profileInDb.Hobbies = updatedData.Hobbies;
            return true;
        }
        return false;
    }
    //delete
    public bool Delete(int userId)
    {
        UserProfile profileInDb = GetUserProfile(userId);
        return _userDb.Remove(profileInDb);

    }

    public void Seed()
    {
        UserProfile profileA = new UserProfile("Bill", 22);
        UserProfile profileB = new UserProfile("Ted", 21);
        UserProfile profileC = new UserProfile("Ruffus", 50);

        AddUser(profileA);
        AddUser(profileB);
        AddUser(profileC);
    }


    //can make your own if needed...
    // public List<UserProfile> GetUserProfiles(Hobby hobby)
    // {
    //     var usersWithHobby = new List<UserProfile>();

    //     foreach (UserProfile user in _userDb)
    //     {
    //         foreach (Hobby h in user.Hobbies)
    //         {
    //             if (h == hobby)
    //             {
    //                 usersWithHobby.Add(user);
    //             }
    //         }
    //     }

    //     return usersWithHobby;
    // }
}
