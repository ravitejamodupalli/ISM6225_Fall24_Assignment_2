using System;
using System.Collections.Generic;
using System.Security.AccessControl;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                // Initialize a list to store missing numbers
                IList<int> missingNumbers = new List<int>();
                // Iterate through numbers from 1 to the length of the array
                for (int i = 1; i <= nums.Length; i++)
                {
                    // If the current number is not in the array, add it to the missing numbers list
                    if (nums.Contains(i) == false)
                    {
                        missingNumbers.Add(i);
                    }
                }
                // Return the list of missing numbers
                return missingNumbers;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                // Find all even numbers in the array
                int[] evenNumbers = Array.FindAll(nums, n => n % 2 == 0);
                // Find all odd numbers in the array
                int[] oddNumbers = Array.FindAll(nums, n => n % 2 != 0);
                // Initialize a new array to store the sorted numbers
                int[] sortedArray = new int[nums.Length];
                // Copy even numbers to the beginning of the sorted array
                for (int i = 0; i < evenNumbers.Length; i++)
                {
                    sortedArray[i] = evenNumbers[i];
                }
                // Copy odd numbers to the end of the sorted array
                for (int i = 0; i < oddNumbers.Length; i++)
                {
                    sortedArray[evenNumbers.Length + i] = oddNumbers[i];
                }
                // Return the sorted array
                return sortedArray;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                // Initialize a dictionary to store numbers and their indices
                Dictionary<int, int> numDict = new Dictionary<int, int>();
                // Iterate through the array
                for (int i = 0; i < nums.Length; i++)
                {
                    // Calculate the complement of the current number
                    int complement = target - nums[i];
                    // If the complement is in the dictionary, return the indices
                    if (numDict.ContainsKey(complement))
                    {
                        return new int[] { numDict[complement], i };
                    }
                    // If the current number is not in the dictionary, add it
                    if (!numDict.ContainsKey(nums[i]))
                    {
                        numDict[nums[i]] = i;
                    }
                }
                // Throw an exception if no solution is found
                throw new Exception("No two sum solution");
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                // Check if the array has at least three elements
                if (nums.Length < 3)
                {
                    throw new ArgumentException("Array must contain at least three elements.");
                }

                // Sort the array
                Array.Sort(nums);
                int n = nums.Length;

                // Calculate the maximum product of the last three elements
                int maxProduct1 = nums[n - 1] * nums[n - 2] * nums[n - 3];

                // Calculate the maximum product of the first two elements (most negative) and the last element (most positive)
                int maxProduct2 = nums[0] * nums[1] * nums[n - 1];

                // Return the maximum of the two products
                return Math.Max(maxProduct1, maxProduct2);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                // Initialize a string to store the binary representation
                string binary = string.Empty;
                // If the decimal number is 0, return "0"
                if (decimalNumber == 0)
                {
                    return "0";
                }
                // Convert the decimal number to binary
                while (decimalNumber > 0)
                {
                    binary = (decimalNumber % 2) + binary;
                    decimalNumber /= 2;
                }
                // Return the binary representation
                return binary;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                // Initialize pointers for binary search
                int left = 0, right = nums.Length - 1;
                // Perform binary search to find the minimum element
                while (left < right)
                {
                    int mid = left + (right - left) / 2;
                    if (nums[mid] > nums[right])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid;
                    }
                }
                // Return the minimum element
                return nums[left];
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                // If the number is negative, it is not a palindrome
                if (x < 0)
                {
                    return false;
                }

                // Convert the number to a string
                string s = x.ToString();
                // Initialize pointers for comparison
                int left = 0;
                int right = s.Length - 1;
                // Compare characters from both ends
                while (left < right)
                {
                    if (char.ToLower(s[left]) != char.ToLower(s[right]))
                    {
                        return false;
                    }
                    left++;
                    right--;
                }
                // Return true if the number is a palindrome
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                // Initialize variables for Fibonacci calculation
                int a = 0, b = 1, c = 0;
                // If n is 0, return 0
                if (n == 0)
                {
                    return a;
                }
                // If n is 1, return 1
                else if (n == 1)
                {
                    return b;
                }
                // Calculate Fibonacci number iteratively
                for (int i = 2; i <= n; i++)
                {
                    c = a + b;
                    a = b;
                    b = c;
                }
                // Return the nth Fibonacci number
                return c;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
