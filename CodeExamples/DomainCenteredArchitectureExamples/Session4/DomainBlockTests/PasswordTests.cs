using DomainBlocks;
using OperationResult;

namespace DomainBlockTests;

public class PasswordsTest
{
    [Fact]
    public void Can_Create_Valid_Password()
    {
        // Arrange
        string input = "Troels12!";

        // Act
        Result<Password> created = Password.Create(input);

        // Assert
        Assert.True(created.IsSuccess);
        Assert.Equal(input, created.Value.Value);
    }

    [Theory]
    [InlineData("Troels12!")]
    [InlineData("Ek!0_fjke#5")]
    [InlineData("S0m3_wh3r3_!z_Gr43t")]
    public void Can_Create_Password_With_Valid_Number_of_Characters(string arg)
    {
        // arrange
        string input = arg;

        // act
        Result<Password> result = Password.Create(input);

        // assert
        Assert.True(result.IsSuccess);
        Assert.Equal(input, result.Value.Value);
    }

    [Theory]
    [InlineData("Troels1")]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("Troels!#91011hejfke1ekas1")]
    public void Cannot_Create_Password_With_Invalid_Number_of_Characters(string arg)
    {
        // arrange
        string input = arg;

        // act
        Result<Password> result = Password.Create(input);

        // assert
        Assert.False(result.IsSuccess);
        Assert.Null(result.Value);
        Assert.Equal("Password must be between 8 and 24 characters long", result.ErrorMessage);
    }

    [Theory]
    [MemberData(nameof(GetValidPasswordsWithSpecialCharacters))]
    public void Can_Create_Password_With_Valid_Special_Character(string arg)
    {
        // arrange
        string input = arg;

        // act
        Result<Password> result = Password.Create(input);

        // assert
        Assert.True(result.IsSuccess);
        Assert.Equal(input, result.Value.Value);
    }

    public static IEnumerable<object[]> GetValidPasswordsWithSpecialCharacters()
    {
        return new List<object[]>()
        {
            new[] { "Troels12!" },
            new[] { "Troels01#" },
            new[] { "Trels!#91011hejfke1ekas1" }
        };
    }

    [Fact]
    public void TestInternalAccess()
    {
        Result<Password> result = Password.Create("Troels12");
        Password password = result.Value;
        string passwordTestString = password.TestString;
    }
}