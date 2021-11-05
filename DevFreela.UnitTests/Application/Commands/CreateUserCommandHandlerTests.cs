using DevFreela.Application.Commands.CreateUser;
using DevFreela.Core.Entities;
using DevFreela.Core.Interfaces.Repositories;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateUserCommandHandlerTests
    {
        [Fact]
        public async Task DataIsValid_Executed_ReturnaValidViewModel()
        {
            // Arrange
            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(ur => ur.Add(It.IsAny<User>())).Verifiable();

            var createUserCommand = new CreateUserCommand("Paulo Silas", "paulo.silas@email.com", new DateTime(1995, 1, 1),"123456","Administrador");
            var createUserCommandHandler = new CreateUserCommandHandler(userRepository.Object);

            // Act
            var result = await createUserCommandHandler.Handle(createUserCommand, new CancellationToken());

            // Assert
            Assert.NotNull(result);
            Assert.Equal(createUserCommand.Name, result.Name);
            Assert.Equal(createUserCommand.Email, result.Email);
            Assert.Equal(createUserCommand.BirthDate, result.BirthDate);
            userRepository.Verify(ur => ur.Add(It.IsAny<User>()), Times.Once);
        }
    }
}
