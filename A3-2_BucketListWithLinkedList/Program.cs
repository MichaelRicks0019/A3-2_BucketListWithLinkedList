using System;
using System.Collections.Generic;
using System.Linq;

namespace A3_2_BucketListWithLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intArray = new int[] { 2, 5, 39, 49, 187, 3874, 291, 34, 2, 5, 34, 6, 8, 12345, 62457, 1, 7 };
            List<int> list = new List<int>();
            list = BucketSort(intArray);
            Console.WriteLine(String.Join(", ", list));
            Console.ReadLine();
        }
        public static List<int> BucketSort(int[] intArray)
        {
            List<int> list = new List<int>();
            foreach (int x in intArray)
            {
                list.Add(x);
            }

            int maxLength = 0;
            foreach (int x in intArray)
            {
                if (x.ToString().Length > maxLength)
                {
                    maxLength = x.ToString().Length;
                }
            }
            int counter = maxLength;
            for (int x = 0; x < maxLength; x++)
            {
                LinkedList<int>[] buckets = new LinkedList<int>[10];
                foreach (int i in list)
                {

                    string str = i.ToString();
                    if (str.Length < counter)
                    {
                        if (buckets[0] == null)
                        {
                            buckets[0] = new LinkedList<int>();
                            buckets[0].AddLast(i);
                        }
                        else
                        {
                            buckets[0].AddLast(i);
                        }
                    }
                    else
                    {
                        string charPosition = str.Substring(counter - 1, 1);
                        int arrayPosition = int.Parse(charPosition);

                        if (buckets[arrayPosition] == null)
                        {
                            buckets[arrayPosition] = new LinkedList<int>();
                            buckets[arrayPosition].AddFirst(i);
                        }
                        else
                        {
                            buckets[arrayPosition].AddLast(i);
                        }
                    }
                }

                list.Clear();
                foreach (LinkedList<int> n in buckets)
                {
                    if (n == null)
                    {

                    }
                    else
                    {
                        list.AddRange(n);
                    }
                }
                counter--;

                if (counter == 0)
                {
                    buckets = new LinkedList<int>[10];
                    foreach (int y in list)
                    {
                        if (buckets[y.ToString().Length] == null)
                        {
                            buckets[y.ToString().Length] = new LinkedList<int>();
                            buckets[y.ToString().Length].AddLast(y);
                        }
                        else
                        {
                            buckets[y.ToString().Length].AddLast(y);
                        }

                    }
                    list.Clear();
                    foreach (LinkedList<int> n in buckets)
                    {
                        if (n == null)
                        {

                        }
                        else
                        {
                            list.AddRange(n);
                        }
                    }

                }
            }
            return list;
        }

    }


}

