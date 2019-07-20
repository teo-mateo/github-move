using Clover.Common.Configuration;
using Clover.Identity.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Clover.Identity.Data.Tests
{
    public class UserRepositoryTests
    {
        [Fact]
        public void Test1()
        {
            var config = MockConfig();
            UserRepository repo = new UserRepository(config);
        }

        private ICloverConfig MockConfig()
        {
            var configMock = new Mock<ICloverConfig>();
            configMock.Setup(m => m.Get(CloverConfigEnum.CLOVER_STORAGE_ACCOUNT)).Returns("cloverstoragetst");
            configMock.Setup(m => m.Get(CloverConfigEnum.CLOVER_STORAGE_KEY)).Returns("0upkiwVVofBqxUtivL6wW4eBa2ICh2sUHO9juwnvVPSLlOifBscNx4UO7S1t7xQclfaRyXfbcOHbziN9ES4wSQ==");
            return configMock.Object;
        }

        [Fact]
        public async Task UserRepository_Save_Should_Save()
        {
            var config = MockConfig();
            var repo = new UserRepository(config);

            UserFactory uf = new UserFactory(repo);
            var u = await uf.Create("teomati44@gmail.com", "1234");

            u.Block();
        }

        [Fact]
        public async Task UserRepository_Get_Should_Find_User()
        {
            var config = MockConfig();
            var repo = new UserRepository(config);
            UserFactory uf = new UserFactory(repo);
            var u = await uf.Load("teomati@gmail.com");

        }
    }
}
