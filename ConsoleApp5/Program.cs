using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }

        static int[] BubbleSort(OrderBy sort, int[] arr)
        {
            var n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (sort == OrderBy.Ascending && arr[j] > arr[j + 1])
                    {
                        var arr1 = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = arr1;
                    }
                    if (sort == OrderBy.Descending && arr[j] < arr[j + 1])
                    {
                        var arr1 = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = arr1;
                    }
                }
            }
            return arr;

        }

        static int[] SelectionSort(OrderBy sort, int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (sort == OrderBy.Descending)
                {
                    var maxIndex = IndexMax(arr, i);
                    var temp1 = arr[i];
                    arr[i] = arr[maxIndex];
                    arr[maxIndex] = temp1;
                }
                else
                {
                    var minIndex = IndexMin(arr, i);
                    var temp = arr[i];
                    arr[i] = arr[minIndex];
                    arr[minIndex] = temp;
                }

            }

            return arr;
        }


        static int[] SelectionSort1(OrderBy sort, int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                var indexToSwap = i;
                if (sort == OrderBy.Descending)
                {
                    indexToSwap = IndexMax(arr, i);
                }
                else
                {
                    indexToSwap = IndexMin(arr, i);
                }
                var temp = arr[i];
                arr[i] = arr[indexToSwap];
                arr[indexToSwap] = temp;

            }

            return arr;
        }

        static int[] InsertionSort(OrderBy sort, List<int> arr)
        {
          for (int i = 1; i<arr.Count; i++)
            {
                int j = i - 1;
                while (arr[i] < arr[j] && j>0)
                {
                    j--;
                }
                arr.Insert(j, arr[i]);
                arr.RemoveAt(i+1);
            }
            return arr.ToArray();
        }

        static int IndexMin(int[] arr, int startFromIndex)
        {
            var n = arr[startFromIndex];
            var index = startFromIndex;

            for (int i = startFromIndex; i < arr.Length; i++)
            {
                if (n > arr[i])
                {
                    n = arr[i];
                    index = i;
                }
            } return index;
        }
        static int IndexMax(int[] arr, int startFromIndex)
        {
            var n = arr[startFromIndex];
            var index = startFromIndex;

            for (int i = startFromIndex; i < arr.Length; i++)
            {
                if (n < arr[i])
                {
                    n = arr[i];
                    index = i;
                }
            }
            return index;
        }


        //static int[] BubbleSort1(OrderBy sort, int[] arr)
        //{
        //    var n = arr.Length;
        //    for (int i = 0; i < n-1; i++)
        //    {
        //        for (int j = 0; j < n - i; j++)
        //        {
        //            if (sort == OrderBy.Ascending)
        //            {
        //                if (arr[j] > arr[j + 1])
        //                {
        //                    var arr1 = arr[j];
        //                    arr[j] = arr[j + 1];
        //                    arr[j + 1] = arr1;
        //                }
        //            }
        //            if (sort == OrderBy.Descending)
        //            {
        //                if (arr[j] < arr[j + 1])
        //                {
        //                    var arr1 = arr[j];
        //                    arr[j] = arr[j + 1];
        //                    arr[j + 1] = arr1;
        //                }
        //            }
        //        }
        //    }
        //    return arr;

        //}



        enum OrderBy
        {
            Ascending,
            Descending,
        }
    }
}
