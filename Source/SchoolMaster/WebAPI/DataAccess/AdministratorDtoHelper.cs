namespace SchoolMaster.WebAPI.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using SchoolMaster.WebAPI.DataTransferObjects;

    /// <summary>
    /// Static helper methods related to AdministratorDto.
    /// </summary>
    public static class AdministratorDtoHelper
    {
        /// <summary>
        /// Reads an administrator dto from the provided data reader.
        /// </summary>
        /// <param name="dataReader">Data reader.</param>
        /// <param name="phoneDtos">Collection of phone dtos.</param>
        /// <param name="addressDtos">Collection of address dtos.</param>
        /// <returns>An administrator dto.</returns>
        public static AdministratorDto GetAdministratorDto(IDataReader dataReader, IEnumerable<PhoneDto> phoneDtos, IEnumerable<AddressDto> addressDtos)
        {
            AdministratorDto results = null;

            if (dataReader != null)
            {
                int idIndex = dataReader.GetOrdinal("Id");
                int departmentIndex = dataReader.GetOrdinal("Department");
                int positionIndex = dataReader.GetOrdinal("Position");
                int prefixIndex = dataReader.GetOrdinal("Prefix");
                int firstNameIndex = dataReader.GetOrdinal("FirstName");
                int middleNameIndex = dataReader.GetOrdinal("MiddleName");
                int lastNameIndex = dataReader.GetOrdinal("LastName");
                int suffixIndex = dataReader.GetOrdinal("Suffix");
                int loginIndex = dataReader.GetOrdinal("Login");
                int lastLoginDateIndex = dataReader.GetOrdinal("LastLoginDate");
                int lastPasswordChangedDateIndex = dataReader.GetOrdinal("LastPasswordChangedDate");
                int createdDateIndex = dataReader.GetOrdinal("CreatedDate");
                int emailIndex = dataReader.GetOrdinal("Email");

                IDataRecord currentRow = dataReader;

                int id = DataAccessHelper.GetInt32FromCurrentRow(currentRow, idIndex, -1);
                string department = DataAccessHelper.GetStringFromCurrentRow(currentRow, departmentIndex);
                string position = DataAccessHelper.GetStringFromCurrentRow(currentRow, positionIndex);
                string prefix = DataAccessHelper.GetStringFromCurrentRow(currentRow, prefixIndex);
                string firstName = DataAccessHelper.GetStringFromCurrentRow(currentRow, firstNameIndex);
                string middleName = DataAccessHelper.GetStringFromCurrentRow(currentRow, middleNameIndex);
                string lastName = DataAccessHelper.GetStringFromCurrentRow(currentRow, lastNameIndex);
                string suffix = DataAccessHelper.GetStringFromCurrentRow(currentRow, suffixIndex);
                string login = DataAccessHelper.GetStringFromCurrentRow(currentRow, loginIndex);
                DateTime lastLoginDate = DataAccessHelper.GetDateTimeFromCurrentRow(currentRow, lastLoginDateIndex, DateTime.MinValue);
                DateTime lastPasswordChangedDate = DataAccessHelper.GetDateTimeFromCurrentRow(currentRow, lastPasswordChangedDateIndex, DateTime.MinValue);
                DateTime createdDate = DataAccessHelper.GetDateTimeFromCurrentRow(currentRow, createdDateIndex, DateTime.MinValue);
                string email = DataAccessHelper.GetStringFromCurrentRow(currentRow, emailIndex);

                results = new AdministratorDto(id, department, position, lastLoginDate, lastPasswordChangedDate, createdDate, prefix, firstName, middleName, lastName, suffix, login, email, addressDtos, phoneDtos);
            }

            return results;
        }
    }
}
