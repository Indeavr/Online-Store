using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Online_Store.Core.Providers;
using Online_Store.Core.Services;
using Online_Store.Core.Services.User;
using Online_Store.Data;

namespace Online_Store_Tests.Core.Services.User.UserServiceTests
{
    [TestClass]
    public class GeneratePasswordHash_Should
    {
        [TestMethod]
        public void CallHashMethod_WhenCalled()
        {
            //Arange
            var hasherMock = new Mock<IPasswordSecurityHasher>();
            var contextMock = new Mock<IStoreContext>();
            var loggedUserMock = new Mock<ILoggedUserProvider>();
            string password = "test";

<<<<<<< HEAD
            //var userService = new UserService(hasherMock.Object, contextMock.Object);
=======
            var userService = new UserService(hasherMock.Object, contextMock.Object, loggedUserMock.Object);
>>>>>>> 96e58c3ec079339cb2d2aa6d10f5d87410324c77

            ////Act
            //userService.GeneratePasswordHash(password);

            //Assert
            hasherMock.Verify(x => x.Hash(password), Times.Once);
        }
    }
}
