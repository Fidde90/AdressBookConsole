using AdressBookConsole.Interfaces;
using AdressBookConsole.Models;
using AdressBookConsole.Services;

namespace AdressBookConsole.Tests
{
    public class ContactService_test
    {
        [Fact]

        public void AddContactToList_ShouldAddAContactToTheList_AndThenReturnTrue()
        {
            //Arrange
            IFileService f = new FileService();
            ContactService contactService = new ContactService(f);

            IContact c = new Contact
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
            bool res = contactService.AddContactToList(c);

            //Assert
            Assert.True(res);
        }

        [Fact]

        public void AddContactToList_ShoulNotContactToList_IfEmailAlredyExcitsReturnFalse()
        {
            //Arrange
            IFileService f = new FileService();
            ContactService contactService = new ContactService(f);

            IContact c = new Contact
            {
                Email="hej@hotmail.com"            
            };

            IContact x = new Contact
            {
                Email = "hej@hotmail.com"
            };

            //Act
            bool res = contactService.AddContactToList(c);
            bool res2 = contactService.AddContactToList(x);
            //Assert
            Assert.False(res2);
        }
    }
}





