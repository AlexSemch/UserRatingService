using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserRatingService.UnitTests
{
    using NUnit.Framework;

    [TestFixture]
    public class ServiceMethodTest
    {
        private UserRateService _service;
        [SetUp]
        public void InitServiceInstance()
        {
            _service = new UserRateService();
        }
        [Test]
        public void AddUser()
        {
            _service.RegisteredUser("Sasha",100);
        }

        [Test]
        public void AddSameUser()
        {
            _service.RegisteredUser("Sasha", 100);
            _service.RegisteredUser("Sasha", 100);
            Assert.Fail("Должна быть ошибка");
            
        }
    }
}