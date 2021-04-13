namespace SchoolMaster.WebAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using SchoolMaster.WebAPI.DataTransferObjects;

    /// <summary>
    /// Class for shared controller helper methods.
    /// </summary>
    internal static class ControllerHelpers
    {
        /// <summary>
        /// Method for adding the Person attributes to the SQL parameter collection.
        /// </summary>
        /// <param name="parameters">Collection to be updated with additional SQL parameters.</param>
        /// <param name="prefix">Prefix.</param>
        /// <param name="firstName">First name.</param>
        /// <param name="middleName">Middle name.</param>
        /// <param name="lastName">Last name.</param>
        /// <param name="suffix">Suffix.</param>
        /// <param name="login">Login.</param>
        /// <param name="email">Email.</param>
        /// <param name="addresses">Collection of addresses.</param>
        /// <param name="phoneNumbers">Collection of phone numbers.</param>
        internal static void SetPersonSqlParameters(List<SqlParameter> parameters,
                                                    string prefix,
                                                    string firstName,
                                                    string middleName,
                                                    string lastName,
                                                    string suffix,
                                                    string login,
                                                    string email,
                                                    IEnumerable<AddressDto> addresses,
                                                    IEnumerable<PhoneDto> phoneNumbers)
        {
            SqlParameter parameter = new SqlParameter("Prefix", SqlDbType.NVarChar, 6)
            {
                Direction = ParameterDirection.Input,
                Value = (prefix == null) ? DBNull.Value : prefix,
            };
            parameters.Add(parameter);

            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("FirstName cannot be null, empty, or whitespace.");
            }

            parameter = new SqlParameter("FirstName", SqlDbType.NVarChar, 50)
            {
                Direction = ParameterDirection.Input,
                Value = firstName,
            };
            parameters.Add(parameter);

            parameter = new SqlParameter("MiddleName", SqlDbType.NVarChar, 50)
            {
                Direction = ParameterDirection.Input,
                Value = (middleName == null) ? DBNull.Value : middleName,
            };
            parameters.Add(parameter);

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("LastName cannot be null, empty, or whitespace.");
            }

            parameter = new SqlParameter("LastName", SqlDbType.NVarChar, 50)
            {
                Direction = ParameterDirection.Input,
                Value = lastName,
            };
            parameters.Add(parameter);

            parameter = new SqlParameter("Suffix", SqlDbType.NVarChar, 6)
            {
                Direction = ParameterDirection.Input,
                Value = (suffix == null) ? DBNull.Value : suffix,
            };
            parameters.Add(parameter);

            if (string.IsNullOrWhiteSpace(login))
            {
                throw new ArgumentException("Login cannot be null, empty, or whitespace.");
            }

            parameter = new SqlParameter("Login", SqlDbType.NVarChar, 64)
            {
                Direction = ParameterDirection.Input,
                Value = login,
            };
            parameters.Add(parameter);

            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email cannot be null, empty, or whitespace.");
            }

            parameter = new SqlParameter("Email", SqlDbType.NVarChar, 256)
            {
                Direction = ParameterDirection.Input,
                Value = email,
            };
            parameters.Add(parameter);

            if (addresses != null && addresses.Any())
            {
                using DataTable addressTable = new DataTable("AddressTable");
                addressTable.Columns.Add("Address1", typeof(string));
                addressTable.Columns.Add("Address2", typeof(string));
                addressTable.Columns.Add("City", typeof(string));
                addressTable.Columns.Add("State", typeof(string));
                addressTable.Columns.Add("Zip", typeof(string));

                foreach (AddressDto address in addresses)
                {
                    if (string.IsNullOrWhiteSpace(address.Address1))
                    {
                        throw new ArgumentException("Address1 cannot be null, empty, or whitespace.");
                    }

                    if (string.IsNullOrWhiteSpace(address.City))
                    {
                        throw new ArgumentException("City cannot be null, empty, or whitespace.");
                    }

                    if (string.IsNullOrWhiteSpace(address.State))
                    {
                        throw new ArgumentException("State cannot be null, empty, or whitespace.");
                    }

                    if (string.IsNullOrWhiteSpace(address.Zip))
                    {
                        throw new ArgumentException("Zip cannot be null, empty, or whitespace.");
                    }

                    object address2 = (address.Address2 == null) ? DBNull.Value : address.Address2;

                    addressTable.Rows.Add(address.Address1, address2, address.City, address.State, address.Zip);
                }

                parameter = new SqlParameter("Addresses", SqlDbType.Structured)
                {
                    Value = addressTable,
                };
                parameters.Add(parameter);
            }

            if (phoneNumbers != null && phoneNumbers.Any())
            {
                using DataTable phoneTable = new DataTable("PhoneTable");
                phoneTable.Columns.Add("AreaCode", typeof(string));
                phoneTable.Columns.Add("ExchangeCode", typeof(string));
                phoneTable.Columns.Add("SubscriberNumber", typeof(string));
                phoneTable.Columns.Add("ContactOrder", typeof(int));

                foreach (PhoneDto phoneNumber in phoneNumbers)
                {
                    if (string.IsNullOrWhiteSpace(phoneNumber.AreaCode))
                    {
                        throw new ArgumentException("AreaCode cannot be null, empty, or whitespace.");
                    }

                    if (string.IsNullOrWhiteSpace(phoneNumber.ExchangeCode))
                    {
                        throw new ArgumentException("ExchangeCode cannot be null, empty, or whitespace.");
                    }

                    if (string.IsNullOrWhiteSpace(phoneNumber.SubscriberNumber))
                    {
                        throw new ArgumentException("SubscriberNumber cannot be null, empty, or whitespace.");
                    }

                    if (phoneNumber.ContactOrder < 0)
                    {
                        throw new ArgumentException("ContactOrder must be greater than or equal to zero.");
                    }

                    phoneTable.Rows.Add(phoneNumber.AreaCode, phoneNumber.ExchangeCode, phoneNumber.SubscriberNumber, phoneNumber.ContactOrder);
                }

                parameter = new SqlParameter("PhoneNumbers", SqlDbType.Structured)
                {
                    Value = phoneTable,
                };
                parameters.Add(parameter);
            }
        }
    }
}
