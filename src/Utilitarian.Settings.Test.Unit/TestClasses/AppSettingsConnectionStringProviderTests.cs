﻿using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Utilitarian.Settings.Test.Unit.TestClasses
{
    [TestClass]
    public class AppSettingsConnectionStringProviderTests
    {
        [TestMethod]
        public void ShouldReturnCorrectConnectionString()
        {
            new AppSettingsConnectionStringProvider().Get("TestConnectionString").ShouldBeEquivalentTo("TestConnectionString");
        }

        [TestMethod]
        public void ShouldThrowExceptionIfConnectionStringIsMissing()
        {
            Action action = () => new AppSettingsConnectionStringProvider().Get("BadTestConnectionString");

            action.ShouldThrow<Exception>();
        }
    }
}
