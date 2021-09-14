using System;
using System.Collections.Generic;

namespace MutableStringLibrary
{
    public class MutableStringList : List<MutableString>
    {
        public void RemoveIf(Func<MutableString, bool> d)
        {
            var again = true;
            while (again)
            {
                again = false;
                var index = 0;
                foreach (var x in this)
                {
                    if (d(x))
                    {
                        RemoveAt(index);
                        again = true;
                        break;
                    }
                    index++;
                }
            }
        }

        public void RemoveIfIsNullOrWhiteSpace() =>
            RemoveIf(s => s.IsNullOrWhiteSpace());

        public void RemoveIfIsNullOrEmpty() =>
            RemoveIf(s => s.IsNullOrEmpty());
    }
}