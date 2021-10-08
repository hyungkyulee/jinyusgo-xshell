using System;

namespace JinyusGo.Helpers
{
    public class Helper
    {
        public static string GetRandomGuid()
        {
            var guidResult = Guid.NewGuid().ToString();
            guidResult = guidResult.Replace("-", string.Empty).ToUpper();

            return guidResult;
        }
    }
}