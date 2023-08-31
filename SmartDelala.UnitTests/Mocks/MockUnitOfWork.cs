using Moq;
using SmartDelala.Application.Contracts.Persistence;

namespace SmartDelala.UnitTests.Mocks;

public class MockUnitOfWork
{
	public static Mock<IUnitOfWork> GetUnitOfWork()
	{
                var mockUow = new Mock<IUnitOfWork>();

                mockUow.Setup(r => r.Save()).ReturnsAsync(1);
                
                return mockUow;
        }
}
