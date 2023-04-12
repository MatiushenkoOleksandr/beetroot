using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson14
{
    public class CustomStack<T>

    {
        public CustomStack()
        {
            Values = new T[0];
        }
        private T[] Values;

        public void Push(T value)
        {
            var valueList = Values.ToList();

            valueList.Insert(0, value);

            Values=valueList.ToArray();
        }
        public T Pop()
        {
            var newValueList = Values.ToList();
            var a = newValueList[newValueList.Count - 1];
            newValueList.Remove(a);
            Values=newValueList.ToArray();
            return a;
        }
        public void Clear()
        {
            Array.Resize(ref Values, 0);

        }
        public int Count { get => Values.Length; }

        public T Peek()
        {
            return Values[0];
        }

        public void CopyTo(ref T[] array)
        {

            Array.Copy(Values, array, Values.Length);
        }

    }
}
