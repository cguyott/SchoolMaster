﻿namespace SchoolMaster.WebAPI.Tests.DataModelTests
{
    using System;
    using SchoolMaster.WebAPI.DataModel;
    using Xunit;

    /// <summary>
    /// Email unit tests.
    /// </summary>
    public class EmailTests
    {
        // c_veryLongEmail is assigned a string of 257 characters.
        private const string c_veryLongEmail = "e5af105b73924c3590e99d2820e3ae7a3086d0e3e03542e1b0a44138a49965b1ee434e3efe8d063dc182cecb5f5b4b85a255a397de1c8615a6d6eef5676548dc532a4c96acbe01292f260a52abdc470343d6735ef36841cd9085e56f496ece7c87c8beb9f537d7702b22418d8ee6476dcd5f4ff3b3547f1193749400bd494bfab";

        /// <summary>
        /// Default_Constructor_Works test.
        ///
        /// This unit test also tests all of the property getters.
        /// </summary>
        [Fact]
        public void Default_Constructor_Works()
        {
            // Arrange.

            // Act.
            Email email = new Email();

            // Assert.
            Assert.NotNull(email);
            Assert.True(email.Id == -1);
            Assert.True(email.Modified == false);
            Assert.True(((IEmail)email).Email == null);
        }

        /// <summary>
        /// Constructor_Works test.
        ///
        /// This unit test also tests all of the property getters.
        /// </summary>
        [Fact]
        public void Constructor_Works()
        {
            // Arrange.
            int id = 1;
            string email_address = "address@email.com";

            // Act.
            Email email = new Email(id, email_address);

            // Assert.
            Assert.NotNull(email);
            Assert.True(id == email.Id);
            Assert.True(email.Modified == false);
            Assert.True(email_address == ((IEmail)email).Email);
        }

        /// <summary>
        /// Constructor_Fails_IdLessThanOne tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_IdLessThanOne()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("id", () => new Email(0, "address@email.com"));
        }

        /// <summary>
        /// Constructor_Fails_EmailNull tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_EmailNull()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("email", () => new Email(1, null));
        }

        /// <summary>
        /// Constructor_Fails_EmailEmpty tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_EmailEmpty()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("email", () => new Email(1, string.Empty));
        }

        /// <summary>
        /// Constructor_Fails_EmailWhitespace tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_EmailWhitespace()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("email", () => new Email(1, "       "));
        }

        /// <summary>
        /// Constructor_Fails_EmailLong tests.
        /// </summary>
        [Fact]
        public void Constructor_Fails_EmailLong()
        {
            // Arrange.

            // Act and Assert.
            Assert.Throws<ArgumentException>("email", () => new Email(1, c_veryLongEmail));
        }

        /// <summary>
        /// Set_Email_Works tests.
        /// </summary>
        [Fact]
        public void Set_Email_Works()
        {
            // Arrange.
            string email_address = "address@email.com";

            // Act and assert.
            Email email = new Email();
            Assert.NotNull(email);

            Assert.True(email.Modified == false);
            Assert.True(((IEmail)email).Email == null);

            ((IEmail)email).Email = email_address;

            Assert.True(email.Modified == true);
            Assert.True(((IEmail)email).Email == email_address);
        }

        /// <summary>
        /// Set_Email_Fails_EmailNull tests.
        /// </summary>
        [Fact]
        public void Set_Email_Fails_EmailNull()
        {
            // Arrange.

            // Act and assert.
            Email email = new Email();
            Assert.NotNull(email);

            Assert.True(email.Modified == false);
            Assert.True(((IEmail)email).Email == null);

            Assert.Throws<ArgumentException>("email", () => (((IEmail)email).Email = null));

            Assert.True(email.Modified == false);
            Assert.True(((IEmail)email).Email == null);
        }

        /// <summary>
        /// Set_Email_Fails_EmailEmpty tests.
        /// </summary>
        [Fact]
        public void Set_Email_Fails_EmailEmpty()
        {
            // Arrange.

            // Act and assert.
            Email email = new Email();
            Assert.NotNull(email);

            Assert.True(email.Modified == false);
            Assert.True(((IEmail)email).Email == null);

            Assert.Throws<ArgumentException>("email", () => (((IEmail)email).Email = string.Empty));

            Assert.True(email.Modified == false);
            Assert.True(((IEmail)email).Email == null);
        }

        /// <summary>
        /// Set_Email_Fails_EmailWhitespace tests.
        /// </summary>
        [Fact]
        public void Set_Email_Fails_EmailWhitespace()
        {
            // Arrange.

            // Act and assert.
            Email email = new Email();
            Assert.NotNull(email);

            Assert.True(email.Modified == false);
            Assert.True(((IEmail)email).Email == null);

            Assert.Throws<ArgumentException>("email", () => (((IEmail)email).Email = "     "));

            Assert.True(email.Modified == false);
            Assert.True(((IEmail)email).Email == null);
        }

        /// <summary>
        /// Set_Email_Fails_EmailLong tests.
        /// </summary>
        [Fact]
        public void Set_Email_Fails_EmailLong()
        {
            // Arrange.

            // Act and assert.
            Email email = new Email();
            Assert.NotNull(email);

            Assert.True(email.Modified == false);
            Assert.True(((IEmail)email).Email == null);

            Assert.Throws<ArgumentException>("email", () => (((IEmail)email).Email = c_veryLongEmail));

            Assert.True(email.Modified == false);
            Assert.True(((IEmail)email).Email == null);
        }
    }
}