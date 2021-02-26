namespace SchoolMaster.WebAPI.DataAccess
{
    using System.Collections.Generic;
    using System.Data;
    using SchoolMaster.WebAPI.DataTransferObjects;

    /// <summary>
    /// Static helper methods related to PhoneDto.
    /// </summary>
    public static class PhoneDtoHelper
    {
        /// <summary>
        /// Reads phone dtos from the provided data reader.
        /// </summary>
        /// <param name="dataReader">Data reader.</param>
        /// <returns>Collection of phone dtos.</returns>
        public static IList<PhoneDto> GetPhoneDtos(IDataReader dataReader)
        {
            List<PhoneDto> results = new List<PhoneDto>();

            if (dataReader != null)
            {
                int areaCodeIndex = dataReader.GetOrdinal("AreaCode");
                int exchangeCodeIndex = dataReader.GetOrdinal("ExchangeCode");
                int subscriberNumberIndex = dataReader.GetOrdinal("SubscriberNumber");
                int contactOrderIndex = dataReader.GetOrdinal("ContactOrder");

                while (dataReader.Read())
                {
                    IDataRecord currentRow = dataReader;

                    string areaCode = DataAccessHelper.GetStringFromCurrentRow(currentRow, areaCodeIndex);
                    string exchangeCode = DataAccessHelper.GetStringFromCurrentRow(currentRow, exchangeCodeIndex);
                    string subscriberNumber = DataAccessHelper.GetStringFromCurrentRow(currentRow, subscriberNumberIndex);
                    int contactOrder = DataAccessHelper.GetInt32FromCurrentRow(currentRow, contactOrderIndex, -1);

                    PhoneDto phoneDto = new PhoneDto(areaCode, exchangeCode, subscriberNumber, contactOrder);
                    results.Add(phoneDto);
                }
            }

            return results;
        }
    }
}
