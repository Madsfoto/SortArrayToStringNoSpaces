using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortArrayToStringNoSpaces
{
    // https://msdn.microsoft.com/en-us/library/system.object.tostring.aspx
    public class CList<T> : List<T>
    {
        public CList(IEnumerable<T> collection) : base(collection)
        { }

        public CList() : base()
        { }

        public override String ToString()
        {
            String retVal = String.Empty;
            foreach (T item in this)
            {
                if (String.IsNullOrEmpty(retVal))
                    retVal += item.ToString();
                else
                    retVal += String.Format(", {0}", item);
            }
            return retVal;
        }
    }

    class Program
    {
        int prevInt = 0;
        int numOfIterationsCurrentInt = 1;
        int counter = 1;

        public void SetPrevint(int i)
        {
            prevInt = i;
        }

        public int GetPrevInt()
        {
            return prevInt;
        }

        public void AddNumOfIterationsCurrentInt()
        {
            numOfIterationsCurrentInt += 1;
        }

        public int GetNumOfInterationsCurrentInt()
        {
            return numOfIterationsCurrentInt;
        }
        public void ResetNumOfInteractionsCurrentInt()
        {
            numOfIterationsCurrentInt = 1;
        }
        public void AddToCounter()
        {
            counter += 1;
        }
        public int GetCounter()
        {
            return counter;

        }


        static void Main(string[] args)
        {
            Program p = new Program();

            int[] imagedata = { 10, 0, 0, 0, 0, 20, 0, 0, 0, 0, 0, 0, 0, 0, 0, 30, 0, 0, 0, 0, 0, 0, 0, 30, 0, 0, 0, 270, 0, 0, 0, 0, 0, 0, 0, 0, 50, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 1, 1, 1, 1, 1, 1, 3, 0, 2, 0, 0, 1, 1, 1, 1, 1, 0, 2, 2, 0, 2, 2, 0, 2, 5, 3, 3, 3, 1, 0, 2, 4, 6, 3, 3, 6, 5, 3, 2, 7, 5, 0, 3, 3, 3 };




            int numberOfUniqueNumbers = imagedata.Distinct().Count(); // How many different numbers are there?


            // Counting how many times each number is present in the array
            List<int> histogramList = new CList<int>();



            Array.Sort(imagedata);


            // The idea is to test each number with it's previous in the sorted array, if it's the same add 1 to a counter, if different write the counter to the list.
            int countOfImagedata = imagedata.Length;

            foreach (int i in imagedata)
            {
                //Console.WriteLine(i);
                if (i == p.GetPrevInt())
                {
                    p.AddNumOfIterationsCurrentInt();

                    //Console.WriteLine(p.GetNumOfInterationsCurrentInt());
                }

                else
                {
                    //Console.WriteLine("ELSE!");
                    histogramList.Add(p.GetNumOfInterationsCurrentInt());
                    p.ResetNumOfInteractionsCurrentInt();
                    p.SetPrevint(i);
                }



            }




            String histogramStr = "";
            histogramStr = histogramList.ToString();
            // remove the ", " from the string
            String histogram = histogramStr.Replace(", ", "");
            Console.WriteLine(histogram);

        }
    }


}
