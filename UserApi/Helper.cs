using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserApi
{
    public static class Helper
    {
        public static int RemoveFromList(List<int> list)
        {
            if (list.Any())
            {
                var first = list.First();
                list.RemoveAt(0);
                return first;
            }

            return 0;
        }
    }
}
