// Corrected by Eric Johnston

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //make some sets
            Set A = new Set();
            Set B = new Set();

            //put some stuff in the sets
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                A.addElement(r.Next(4));
                B.addElement(r.Next(12));
            }

            //display each set and the union
            Console.WriteLine("A: " + A);
            Console.WriteLine("B: " + B);
            Console.WriteLine("A union B: " + A.union(B)); // Issue - Returning only set B

            //display original sets (should be unchanged)
            Console.WriteLine("After union operation");
            Console.WriteLine("A: " + A); // Issue - set A has been altered
            Console.WriteLine("B: " + B);

            // Added - Await key press before closing app
            Console.ReadKey();

        }

        class Set
        {
            private List<int> elements;


            public Set()
            {
                elements = new List<int>();
            }

            // addElement() does not need to return any value. Changed to void
            public void addElement(int val)
            {
                // Since we are no longer returning a value, we can make this an if-not statement, it looks cleaner
                if (!containsElement(val))
                {
                    elements.Add(val);
                }

                /*
                else
                //{
                    //elements.Add(val);
                }
                */
            }



            private bool containsElement(int val)
            {
                for (int i = 0; i < elements.Count; i++)
                {
                    if (val == elements[i])
                        return true;
                    // Redundant else statement, method is already returning false on line 81
                    //else
                        //return false;
                }
                return false;
            }

            public override string ToString()
            {
                string str = "";
                foreach (int i in elements)
                {
                    str += i + " ";
                }
                return str;
            }

            // This method is never called
            /*
            public void clearSet()
            {
                elements.Clear();
            }
            */

            public Set union(Set rhs)
            {
                // Create a temporary set so that set A is left unaltered
                Set tempSet = new Set();

                for (int i = 0; i < elements.Count; i++)
                {
                    tempSet.addElement(elements[i]);
                }

                for (int i = 0; i < rhs.elements.Count; i++)
                {
                    tempSet.addElement(rhs.elements[i]);

                    // Change from this to tempSet
                    //this.addElement( rhs.elements[ i ] );
                }

                // Sort the tempSet, which is our union set.
                tempSet.elements.Sort();
                // return tempSet instead of rhs
                return tempSet;
                // return rhs;
            }
        }

    }
}
