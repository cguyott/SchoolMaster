namespace SchoolMaster.WebAPI.DataAccess
{
    using System.Collections.Generic;
    using System.Data;
    using SchoolMaster.WebAPI.DataTransferObjects;

    /// <summary>
    /// Static helper methods related to PhoneDto.
    /// </summary>
    public static class AddressDtoHelper
    {
        /// <summary>
        /// Reads address dtos from the provided data reader.
        /// </summary>
        /// <param name="dataReader">Data reader.</param>
        /// <returns>Collection of address dtos.</returns>
        public static IEnumerable<AddressDto> GetAddressDtos(IDataReader dataReader)
        {
            List<AddressDto> results = new List<AddressDto>();

            if (dataReader != null)
            {
                int address1Index = dataReader.GetOrdinal("Address1");
                int address2Index = dataReader.GetOrdinal("Address2");
                int cityIndex = dataReader.GetOrdinal("City");
                int stateIndex = dataReader.GetOrdinal("State");
                int zipIndex = dataReader.GetOrdinal("Zip");

                while (dataReader.Read())
                {
                    IDataRecord currentRow = dataReader;

                    string address1 = DataAccessHelper.GetStringFromCurrentRow(currentRow, address1Index);
                    string address2 = DataAccessHelper.GetStringFromCurrentRow(currentRow, address2Index);
                    string city = DataAccessHelper.GetStringFromCurrentRow(currentRow, cityIndex);
                    string state = DataAccessHelper.GetStringFromCurrentRow(currentRow, stateIndex);
                    string zip = DataAccessHelper.GetStringFromCurrentRow(currentRow, zipIndex);

                    AddressDto addressDto = new AddressDto(address1, address2, city, state, zip);
                    results.Add(addressDto);
                }
            }

            return results;
        }
    }
}
