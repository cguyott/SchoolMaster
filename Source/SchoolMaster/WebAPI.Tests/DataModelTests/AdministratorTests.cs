namespace SchoolMaster.WebAPI.Tests.DataModelTests
{
    using System;
    using SchoolMaster.WebAPI.DataModel;
    using Xunit;

    /// <summary>
    /// Administrator unit tests.
    /// </summary>
    public class AdministratorTests
    {
        // 129 characters long.
        private const string c_veryLongString = "012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678";

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
            Administrator admin = new Administrator();

            // Assert.

            Assert.NotNull(admin);

            Assert.True(admin.AdminId == -1);
            Assert.True(admin.AdminModified == false);

            Assert.True(((IAdministrator)admin).Department == null);
            Assert.True(((IAdministrator)admin).Position == null);
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
            string department = "Department";
            string position = "Position";

            // Act.
            Administrator admin = new Administrator(id, department, position);

            // Assert.

            Assert.NotNull(admin);

            Assert.True(admin.AdminId == id);
            Assert.True(admin.AdminModified == false);

            Assert.True(((IAdministrator)admin).Department == department);
            Assert.True(((IAdministrator)admin).Position == position);
        }

        /// <summary>
        /// Set_Department_Works tests.
        /// </summary>
        [Fact]
        public void Set_Department_Works()
        {
            // Arrange.
            string department = "Department";

            // Act and assert.

            Administrator admin = new Administrator();
            Assert.NotNull(admin);

            Assert.True(admin.AdminModified == false);
            Assert.True(((IAdministrator)admin).Department == null);

            ((IAdministrator)admin).Department = department;

            Assert.True(admin.AdminModified == true);
            Assert.True(((IAdministrator)admin).Department == department);
        }

        /// <summary>
        /// Set_Department_Fails_DepartmentNull tests.
        /// </summary>
        [Fact]
        public void Set_Department_Fails_DepartmentNull()
        {
            // Arrange.

            // Act and assert.

            Administrator admin = new Administrator();
            Assert.NotNull(admin);

            Assert.True(admin.AdminModified == false);
            Assert.True(((IAdministrator)admin).Department == null);

            Assert.Throws<ArgumentException>("Department", () => (((IAdministrator)admin).Department = null));

            Assert.True(admin.AdminModified == false);
            Assert.True(((IAdministrator)admin).Department == null);
        }

        /// <summary>
        /// Set_Department_Fails_DepartmentEmpty tests.
        /// </summary>
        [Fact]
        public void Set_Department_Fails_DepartmentEmpty()
        {
            // Arrange.

            // Act and assert.

            Administrator admin = new Administrator();
            Assert.NotNull(admin);

            Assert.True(admin.AdminModified == false);
            Assert.True(((IAdministrator)admin).Department == null);

            Assert.Throws<ArgumentException>("Department", () => (((IAdministrator)admin).Department = string.Empty));

            Assert.True(admin.AdminModified == false);
            Assert.True(((IAdministrator)admin).Department == null);
        }

        /// <summary>
        /// Set_Department_Fails_DepartmentWhitespace tests.
        /// </summary>
        [Fact]
        public void Set_Department_Fails_DepartmentWhitespace()
        {
            // Arrange.

            // Act and assert.

            Administrator admin = new Administrator();
            Assert.NotNull(admin);

            Assert.True(admin.AdminModified == false);
            Assert.True(((IAdministrator)admin).Department == null);

            Assert.Throws<ArgumentException>("Department", () => (((IAdministrator)admin).Department = "       "));

            Assert.True(admin.AdminModified == false);
            Assert.True(((IAdministrator)admin).Department == null);
        }

        /// <summary>
        /// Set_Department_Fails_DepartmentLong tests.
        /// </summary>
        [Fact]
        public void Set_Department_Fails_DepartmentLong()
        {
            // Arrange.

            // Act and assert.

            Administrator admin = new Administrator();
            Assert.NotNull(admin);

            Assert.True(admin.AdminModified == false);
            Assert.True(((IAdministrator)admin).Department == null);

            Assert.Throws<ArgumentException>("Department", () => (((IAdministrator)admin).Department = c_veryLongString));

            Assert.True(admin.AdminModified == false);
            Assert.True(((IAdministrator)admin).Department == null);
        }

        /// <summary>
        /// Set_Position_Works tests.
        /// </summary>
        [Fact]
        public void Set_Position_Works()
        {
            // Arrange.
            string position = "Position";

            // Act and assert.

            Administrator admin = new Administrator();
            Assert.NotNull(admin);

            Assert.True(admin.AdminModified == false);
            Assert.True(((IAdministrator)admin).Position == null);

            ((IAdministrator)admin).Position = position;

            Assert.True(admin.AdminModified == true);
            Assert.True(((IAdministrator)admin).Position == position);
        }

        /// <summary>
        /// Set_Position_Fails_PositionNull tests.
        /// </summary>
        [Fact]
        public void Set_Position_Fails_PositionNull()
        {
            // Arrange.

            // Act and assert.

            Administrator admin = new Administrator();
            Assert.NotNull(admin);

            Assert.True(admin.AdminModified == false);
            Assert.True(((IAdministrator)admin).Position == null);

            Assert.Throws<ArgumentException>("Position", () => (((IAdministrator)admin).Position = null));

            Assert.True(admin.AdminModified == false);
            Assert.True(((IAdministrator)admin).Position == null);
        }

        /// <summary>
        /// Set_Position_Fails_PositionEmpty tests.
        /// </summary>
        [Fact]
        public void Set_Position_Fails_PositionEmpty()
        {
            // Arrange.

            // Act and assert.

            Administrator admin = new Administrator();
            Assert.NotNull(admin);

            Assert.True(admin.AdminModified == false);
            Assert.True(((IAdministrator)admin).Position == null);

            Assert.Throws<ArgumentException>("Position", () => (((IAdministrator)admin).Position = string.Empty));

            Assert.True(admin.AdminModified == false);
            Assert.True(((IAdministrator)admin).Position == null);
        }

        /// <summary>
        /// Set_Department_Fails_PositionWhitespace tests.
        /// </summary>
        [Fact]
        public void Set_Position_Fails_PositionWhitespace()
        {
            // Arrange.

            // Act and assert.

            Administrator admin = new Administrator();
            Assert.NotNull(admin);

            Assert.True(admin.AdminModified == false);
            Assert.True(((IAdministrator)admin).Position == null);

            Assert.Throws<ArgumentException>("Position", () => (((IAdministrator)admin).Position = "       "));

            Assert.True(admin.AdminModified == false);
            Assert.True(((IAdministrator)admin).Position == null);
        }

        /// <summary>
        /// Set_Position_Fails_PositionLong tests.
        /// </summary>
        [Fact]
        public void Set_Position_Fails_PositionLong()
        {
            // Arrange.

            // Act and assert.

            Administrator admin = new Administrator();
            Assert.NotNull(admin);

            Assert.True(admin.AdminModified == false);
            Assert.True(((IAdministrator)admin).Position == null);

            Assert.Throws<ArgumentException>("Position", () => (((IAdministrator)admin).Position = c_veryLongString));

            Assert.True(admin.AdminModified == false);
            Assert.True(((IAdministrator)admin).Position == null);
        }

        /// <summary>
        /// Set_LastName_Works tests.
        ///
        /// I am testing one of the getters and setters for the IPerson wrapper here to validate that the concept works.
        /// There is no need to test all the getters and setters on the IPerson interface as that is being done in the Person unit tests.
        /// </summary>
        [Fact]
        public void Set_LastName_Works()
        {
            // Arrange.
            string lastName = "Doe";

            // Act and assert.

            Administrator admin = new Administrator();
            Assert.NotNull(admin);

            Assert.True(admin.AdminModified == false);
            Assert.True(((IAdministrator)admin).LastName == null);

            ((IAdministrator)admin).LastName = lastName;

            Assert.True(admin.AdminModified == true);
            Assert.True(((IAdministrator)admin).LastName == lastName);
        }
    }
}
