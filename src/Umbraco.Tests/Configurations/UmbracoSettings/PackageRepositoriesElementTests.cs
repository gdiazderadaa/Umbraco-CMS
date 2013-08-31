﻿using System;
using System.Linq;
using NUnit.Framework;

namespace Umbraco.Tests.Configurations.UmbracoSettings
{
    [TestFixture]
    public class PackageRepositoriesElementTests : UmbracoSettingsTests
    {
        [Test]
        public void Repositories()
        {
            Assert.IsTrue(Section.PackageRepositories.Repositories.Count == 2);
            Assert.IsTrue(Section.PackageRepositories.Repositories.ElementAt(0).Id == Guid.Parse("65194810-1f85-11dd-bd0b-0800200c9a66"));
            Assert.IsTrue(Section.PackageRepositories.Repositories.ElementAt(0).Name == "Umbraco package Repository");
            Assert.IsTrue(Section.PackageRepositories.Repositories.ElementAt(1).Id == Guid.Parse("163245E0-CD22-44B6-841A-1B9B9D2E955F"));
            Assert.IsTrue(Section.PackageRepositories.Repositories.ElementAt(1).Name == "Test Repo");
        }
    }
}