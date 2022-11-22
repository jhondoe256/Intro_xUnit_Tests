using Xunit;

namespace CustomerRepository.Tests;

public class UserProfileRepositoryTests
{
    //*AAA 
    //Arrange  -> overall setup for testing
    //Act -> the implementation (action)
    //Assert -> Checking to see if the "action" works

    //todo:Arrange
    //private backing field
    private readonly UserRepository _uRepo;

    public UserProfileRepositoryTests()
    {
        //todo: other stuff...(seeding data could happen here)
        _uRepo = new UserRepository();
    }
    //todo: ----------------------------------------
    [Fact]
    public void AddUser_IsNull_ShouldReturnFalse()
    {
        //we want to test a "null" customer
        //todo: Arrange
        var nullUser = new UserProfile();
        nullUser = null;
        //todo: Arrange---------------------

        //todo: Action -> things actually happen here...
        bool actual = _uRepo.AddUser(nullUser);
        bool expected = false;
        //todo: Action ---------------------------

        //todo: Assert -> This is the "Test"
        Assert.Equal(expected, actual);

        //todo: Assert ---------------------
    }
    //helper method to run tests...optional
    public void Helper()
    {

    }
    [Fact]
    public void AddUser_IsNotNull_ShouldReturnTrue_AndAddedToDb()
    {
        //todo: Arrange: Make a user:
        var user = new UserProfile("Goku", 99);
        //todo: Arrange:---------------

        //todo: Action: Add user to db
        bool actual = _uRepo.AddUser(user);
        bool expected = true;

        //*Check the databaseCount
        int expectedDBCount = 4;
        int actualDBCount = _uRepo.GetUserProfiles().Count;
        //todo: Action:---------------


        //todo: Assert
        Assert.Equal(actual, expected);
        Assert.Equal(expectedDBCount, actualDBCount);
        //todo: Assert--------------
    }

    [Fact]
    public void GetUserProfiles_ShouldReturnExpectedCount()
    {
        //todo: Action
        //*Check the databaseCount
        int expectedDBCount = 3;
        int actualDBCount = _uRepo.GetUserProfiles().Count;
        //todo: ----------------------------

        //todo: Assert
        Assert.Equal(expectedDBCount, actualDBCount);
        //todo: Assert--------------
    }

    [Fact]
    public void GetUserProfile_ShouldHaveSameName()
    {
        //todo: Action
        int userProfileId = 1;
        var userInDb = _uRepo.GetUserProfile(userProfileId);

        var expectedName = "Bill";
        var actualName = userInDb.Name;

        var expectedAge = 22;
        var actualAge = userInDb.Age;

        //todo: ----------------------------

        //todo: Assert
        Assert.Equal(expectedName, actualName);
        Assert.Equal(expectedAge, actualAge);
        //todo: Assert--------------
    }

    [Fact]
    public void UpdateUserProfile_ShouldReturnTrue()
    {
        //todo: Action
        int userProfileId = 1;
        var userInDb = _uRepo.GetUserProfile(userProfileId);

        //*Updated user data
        var newUserData = new UserProfile();
        newUserData.Name = "UPDATED NAME";
        newUserData.Age = 100;

        //*Assign the values
        var actual = _uRepo.Update(userInDb.Id, newUserData);
        var expected = true;

        var actualName = userInDb.Name;
        var expectedName = "UPDATED NAME";
        //todo: ----------------------------

        //todo: Assert
        Assert.Equal(expected, actual);
        Assert.Equal(expectedName, actualName);
        //todo: Assert--------------
    }

    [Fact]
    public void DeleteUserProfile_ShouldReturnTrue()
    {
         //todo: Action
        int userProfileId = 1;
        var actual = _uRepo.Delete(userProfileId);
        var expected= true;
        //todo: ----------------------------

        //todo: Assert
        Assert.Equal(expected,actual);
        //todo: Assert--------------
    }
}