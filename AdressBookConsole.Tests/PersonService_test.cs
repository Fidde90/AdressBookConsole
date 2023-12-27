using AdressBook_Library.Interfaces;
using AdressBook_Library.Models;
using AdressBook_Library.Services;
using Xunit;

namespace AdressBook_Library.Tests
{
    public class PersonService_test
    {
        [Fact]

        public void AddPersonToList_ShouldAddAPersonToTheList_AndThenReturnTrue()
        {
            //Arrange
            FileService f = new FileService();
            PersonService PersonService = new PersonService(f);

            IPerson c = new Person
            {
                FirstName = "Fredrik",
                LastName = "Bengtsson",
                PhoneNumber = "0709999999",
                Email = "MazeOfTorment@MorbidAngel.com",
                Street = "Somewhere in time 2c",
                ZipCode = "1000000000",
                City = "The Abyss",
                Country = "Antarctia"
            };

            //Act
            bool res = PersonService.AddPersonToList(c);

            //Assert
            Assert.True(res);
        }

        [Fact]

        public void AddPersonToList_ShoulNotPersonToList_IfEmailAlredyExcitsReturnFalse()
        {
            //Arrange
            FileService f = new FileService();
            PersonService PersonService = new PersonService(f);

            IPerson c = new Person
            {
                Email="hej@hotmail.com"            
            };

            IPerson x = new Person
            {
                Email = "hej@hotmail.com"
            };

            PersonService.AddPersonToList(c);

            //Act

            bool res2 = PersonService.AddPersonToList(x);
            //Assert
            Assert.False(res2);
        }
    }
}





