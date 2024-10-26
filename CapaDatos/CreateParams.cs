using System;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public static class CreateParams
    {
        public static SqlParameter Int(string paramName, int? value)
        {
            var param = new SqlParameter($"@{paramName}", SqlDbType.Int);
            param.Value = value;
            if (value == null) param.Value = DBNull.Value;
            return param;
        }
        public static SqlParameter SmallInt(string paramName, short? value)
        {
            var param = new SqlParameter($"@{paramName}", SqlDbType.SmallInt);
            param.Value = value;
            if (value == null) param.Value = DBNull.Value;
            return param;
        }
        public static SqlParameter TinyInt(string paramName, short? value)
        {
            var param = new SqlParameter($"@{paramName}", SqlDbType.TinyInt);
            param.Value = value;
            if (value == null) param.Value = DBNull.Value;
            return param;
        }
        public static SqlParameter Decimal(string paramName, decimal? value, byte precision, byte scale)
        {
            var param = new SqlParameter($"@{paramName}", SqlDbType.Decimal);
            param.Precision = precision;
            param.Scale = scale;
            param.Value = value;
            if (value == null) param.Value = DBNull.Value;
            return param;
        }

        public static SqlParameter Bit(string paramName, bool? value)
        {
            var param = new SqlParameter($"@{paramName}", SqlDbType.Bit);
            param.Value = value;
            if (value == null) param.Value = DBNull.Value;
            return param;
        }

        public static SqlParameter NVarchar(string paramName, string value, int size)
        {
            var param = new SqlParameter($"@{paramName}", SqlDbType.NVarChar, size);
            param.Value = value;
            if (string.IsNullOrEmpty(value)) param.Value = DBNull.Value;
            return param;
        }

        public static SqlParameter Time(string paramName, DateTime value)
        {
            if (value.Minute > 0) value = value.AddMinutes(value.Minute * -1);
            if (value.Second > 0) value = value.AddSeconds(value.Second * -1);
            if (value.Millisecond > 0) value = value.AddMilliseconds(value.Millisecond * -1);

            var param = new SqlParameter($"@{paramName}", SqlDbType.Time);
            if (value == null) param.Value = DBNull.Value;
            else param.Value = value.TimeOfDay;
            
            return param;
        }

        public static SqlParameter Date(string paramName, DateTime value)
        {
            var param = new SqlParameter($"@{paramName}", SqlDbType.Date);
            param.Value = value;
            if (value == null) param.Value = DBNull.Value;
            return param;
        }

        public static SqlParameter DateTime(string paramName, DateTime? value)
        {
            var param = new SqlParameter($"@{paramName}", SqlDbType.DateTime);
            param.Value = value;
            if (value == null) param.Value = DBNull.Value;
            return param;
        }
    }
}
