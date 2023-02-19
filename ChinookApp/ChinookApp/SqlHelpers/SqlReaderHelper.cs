using Microsoft.Data.SqlClient;

namespace ChinookApp.SqlHelpers
{
    public static class SqlReaderHelper
    {
        /// <summary>
        /// Checks if <see cref="string"/> value from reader is null before calling "Get" method.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="colIndex">The column index of the value read by the reader.</param>
        /// <returns>Either the read value or an empty string if null.</returns>
        public static string GetSafeString(this SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex);
            return string.Empty;
        }

        /// <summary>
        /// Checks if <see cref="decimal"/> value from reader is null before calling "Get" method.
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="colIndex">The column index of the value read by the reader.</param>
        /// <returns>Either the read value or an 0.0 if null.</returns>
        public static decimal GetSafeDecimal(this SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetDecimal(colIndex);
            return 0.0M;
        }
    }
}
