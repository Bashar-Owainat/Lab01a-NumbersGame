using System;

namespace NumbesGame
{
    class Program
    {
        static void Main(string[] args)
        {
        
            try
            {
            StartSequence(); //call this function
            }
            catch(Exception e) //if an error happened print it to the user
            {
                Console.WriteLine("Something went wrong! "+ e.Message);
            }
            finally // print this message anyway 
            {
                Console.WriteLine("The Program is completed successfully!");
            }
        }

        static void StartSequence()
        {
            Console.WriteLine("Enter a number greater than zero");
            
            try{ 
            int userInput = Convert.ToInt32(Console.ReadLine()); // take an input fomr the user
            int[] arr = new int[userInput]; //put as a length for this array
            int[] result= Populate(arr); // call populate function and save the return value in an array of integers called result
            int sum = GetSum(arr); 
            int product = GetProduct(arr, sum); 
            decimal quotient = GetQuotient(product);
            
            Console.WriteLine("Your array size is: " + userInput);
            Console.Write("The numbers in the array are: ");
            PrintArr(result);
            Console.WriteLine();
            Console.WriteLine("The sum of the array is: "+sum);
            Console.WriteLine(sum +" * "+product/sum +" = "+product);
            int number = (int)quotient;
            Console.WriteLine(product + " / " + (product/number) + " = " + quotient);

            }
            catch (FormatException e) // if the user enterd invalid format print this error to them
            {
                Console.WriteLine("Something went wrong! " + e.Message);
            }
            catch(OverflowException e) //if the operations above caused an overflow print this error
            {
                Console.WriteLine("Something went wrong! " + e.Message);
            }
        }

        static  void PrintArr (int[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                if(i != arr.Length - 1)
                {
                Console.Write(arr[i]+",");
                }
                else
                {
                    Console.Write(arr[i]);
                }
            }
        }

        //ask the user to input numbers
        //store it in an array
        //then return it
        static int[] Populate(int[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("Please enter a number: " + (i+1) + " of " + arr.Length);
                int userInput = Convert.ToInt32(Console.ReadLine());
                arr[i] = userInput;
            }
            return arr;
            
        }

        // it calculates the sum of the array's numbers
        static int GetSum(int[] arr)
        {
            int sum = 0;
        for(int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
        if(sum < 20) // if the sum is less than 20 print this error
            {
                throw new ArgumentException("Value of "+sum+" is too low!");
            }
            return sum;
        }

        //it asks the user to pick a random number in a given range
        //then multiply it by sum
        static int GetProduct(int[] arr, int sum)
        {
            int product = 1;
            try
            {
                Console.WriteLine("Please enter a random number between 1 and " + arr.Length);
                int userInput = Convert.ToInt32(Console.ReadLine());
                product = sum * userInput;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Something went wrong! " + e.Message);
            }
            
                return product;
            
        }

        //it asks the user to pick a number to divide the product by
        //if the user chose 0 it will print an error
        static decimal GetQuotient(int product)
        {
            Console.WriteLine("Please enter a number to divide the product by. The product is "+product);
            try
            {
            int userInput = Convert.ToInt32(Console.ReadLine());
            decimal quotient = decimal.Divide(product, userInput);
            return quotient;
            }
            catch(DivideByZeroException)
            {
                return 0;
            }
        }
    }
}
