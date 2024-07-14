using System.Collections.Generic;

namespace Source.Static.Extensions.Scripts
{
    public static class ListExtensions
    {
        public static Queue<string> ToQueue(this List<string> list)
        {
            return new Queue<string>(list);
        }
    }
}
