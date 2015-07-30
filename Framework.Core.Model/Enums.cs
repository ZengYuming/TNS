using System;
using System.ComponentModel;
using System.Reflection;
namespace Framework.Core.Model
{
    public class Enums
    {
        public static string GetEnumDesc(Enum e)
        {
            FieldInfo EnumInfo = e.GetType().GetField(e.ToString());
            DescriptionAttribute[] EnumAttributes = (DescriptionAttribute[])EnumInfo.
                GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (EnumAttributes.Length > 0)
            {
                return EnumAttributes[0].Description;
            }
            return e.ToString();
        }
    }

    public enum OrderType
    {
        asc = 0,
        desc = 1,
    }

    public enum RolesType
    {
        [Description("管理员")]
        Administration = 0,
        [Description("财务")]
        Accountant = 1,
        [Description("业务员")]
        Salesman = 2
    }
}
