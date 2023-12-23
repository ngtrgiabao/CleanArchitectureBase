 

namespace Core.Constant
{
    public class IntUtil
    {
        public static int ConvertToInt(int? value)
        {
            return value == null ? 0 : (int)value;
        }
    }
}
