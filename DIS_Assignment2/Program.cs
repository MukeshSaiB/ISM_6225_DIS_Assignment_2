/* 

YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System.Text;
using System;
using System.Collections.Generic;

namespace ISM6225_Fall_2023_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 3, 50, 75 };
            int upper = 99, lower = 0;
            IList<IList<int>> missingRanges = FindMissingRanges(nums1, lower, upper);
            string result = ConvertIListToNestedList(missingRanges);
            Console.WriteLine(result);
            Console.WriteLine();
            Console.WriteLine();

            //Question2:
            Console.WriteLine("Question 2");
            string parenthesis = "()[]{}";
            bool isValidParentheses = IsValid(parenthesis);
            Console.WriteLine(isValidParentheses);
            Console.WriteLine();
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] prices_array = { 7, 1, 5, 3, 6, 4 };
            int max_profit = MaxProfit(prices_array);
            Console.WriteLine(max_profit);
            Console.WriteLine();
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string s1 = "69";
            bool IsStrobogrammaticNumber = IsStrobogrammatic(s1);
            Console.WriteLine(IsStrobogrammaticNumber);
            Console.WriteLine();
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Question 5");
            int[] numbers = { 1, 2, 3, 1, 1, 3 };
            int noOfPairs = NumIdenticalPairs(numbers);
            Console.WriteLine(noOfPairs);
            Console.WriteLine();
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] maximum_numbers = { 3, 2, 1 };
            int third_maximum_number = ThirdMax(maximum_numbers);
            Console.WriteLine(third_maximum_number);
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string currentState = "++++";
            IList<string> combinations = GeneratePossibleNextMoves(currentState);
            string combinationsString = ConvertIListToArray(combinations);
            Console.WriteLine(combinationsString);
            Console.WriteLine();
            Console.WriteLine();

            //Question 8:
            Console.WriteLine("Question 8:");
            string longString = "leetcodeisacommunityforcoders";
            string longStringAfterVowels = RemoveVowels(longString);
            Console.WriteLine(longStringAfterVowels);
            Console.WriteLine();
            Console.WriteLine();
        }

        /*
        
        Question 1:
        You are given an inclusive range [lower, upper] and a sorted unique integer array nums, where all elements are within the inclusive range. A number x is considered missing if x is in the range [lower, upper] and x is not in nums. Return the shortest sorted list of ranges that exactly covers all the missing numbers. That is, no element of nums is included in any of the ranges, and each missing number is covered by one of the ranges.
        Example 1:
        Input: nums = [0,1,3,50,75], lower = 0, upper = 99
        Output: [[2,2],[4,49],[51,74],[76,99]]  
        Explanation: The ranges are:
        [2,2]
        [4,49]
        [51,74]
        [76,99]
        Example 2:
        Input: nums = [-1], lower = -1, upper = -1
        Output: []
        Explanation: There are no missing ranges since there are no missing numbers.

        Constraints:
        -109 <= lower <= upper <= 109
        0 <= nums.length <= 100
        lower <= nums[i] <= upper
        All the values of nums are unique.

        Time complexity: O(n), space complexity:O(1)
        */
        // FindMissingRanges method takes an array of numbers, a lower bound, and an upper bound.
        // to calculate the missing ranges within the specified range and returns them as a list.
        public static IList<IList<int>> FindMissingRanges(int[] nums, int lower, int upper)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                if (nums == null || nums.Length == 0)
                {
                    return new List<IList<int>> { GetRange(lower, upper) }; //return a single range covering the full range, if the input array is empty.
                }

                IList<IList<int>> missingRanges = new List<IList<int>>();
                long start = (long)lower;

                foreach (int num in nums)
                {
                    if (num > start)
                    {
                        missingRanges.Add(GetRange(start, num - 1)); //  adding it as a missing range,If there's a gap between 'start' and the current 'num'.
                    }
                    start = (long)num + 1;  // Updating the 'start' to the next potential starting point.
                }

                if (start <= upper)
                {
                    // Checking if there's a missing range from the last 'start' to 'upper'.
                    missingRanges.Add(GetRange(start, upper));
                }

                return missingRanges;
            }
            catch (Exception)
            {
                throw;
            }

        }

        // GetRange method takes a start and end value and returns a range as a list.
        private static IList<int> GetRange(long start, long end)
        {
            // Creating a list representing the range from 'start' to 'end'.
            // As list contains two elements: 'start' as the first element and 'end' as the second element.
            return new List<int> { (int)start, (int)end };
        }

        /*
         
        Question 2

        Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.An input string is valid if:
        Open brackets must be closed by the same type of brackets.
        Open brackets must be closed in the correct order.
        Every close bracket has a corresponding open bracket of the same type.
 
        Example 1:

        Input: s = "()"
        Output: true
        Example 2:

        Input: s = "()[]{}"
        Output: true
        Example 3:

        Input: s = "(]"
        Output: false

        Constraints:

        1 <= s.length <= 104
        s consists of parentheses only '()[]{}'.

        Time complexity:O(n^2), space complexity:O(1)
        */

        public static bool IsValid(string s)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements

                Stack<char> stack = new Stack<char>(); // Creating a stack to keep track of open brackets.

                // Iterating through each character in the input string.
                foreach (char c in s)
                {
                    if (c == '(' || c == '{' || c == '[')
                    {
                        // If an open bracket is encountered, then it pushes onto the stack.
                        stack.Push(c);
                    }
                    else if (c == ')' || c == '}' || c == ']')
                    {
                        // If a closing bracket is encountered, check if the stack is empty.
                        // If it's empty, there's no corresponding open bracket, so return false.
                        if (stack.Count == 0)
                        {
                            return false;
                        }

                        // Pop the top element from the stack and check if it matches the current closing bracket.
                        char top = stack.Pop();

                        if ((c == ')' && top != '(') ||
                           (c == '}' && top != '{') ||
                           (c == ']' && top != '['))
                        {
                            // If the brackets don't match, it return's false.
                            return false;
                        }
                    }
                    else
                    {
                        // return's false for invalid characters other than brackets
                        return false;
                    }
                }

                // After iterating through the string, if the stack is empty, all brackets are valid.
                // Otherwise, there are unmatched open brackets, so return false.
                return stack.Count == 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 3:
        You are given an array prices where prices[i] is the price of a given stock on the ith day.You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.
        Example 1:
        Input: prices = [7,1,5,3,6,4]
        Output: 5
        Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
        Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.

        Example 2:
        Input: prices = [7,6,4,3,1]
        Output: 0
        Explanation: In this case, no transactions are done and the max profit = 0.
 
        Constraints:
        1 <= prices.length <= 105
        0 <= prices[i] <= 104

        Time complexity: O(n), space complexity:O(1)
        */

        public static int MaxProfit(int[] prices)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                if (prices == null || prices.Length <= 1)
                {
                    // return 0 since if there are no prices or only one price, we cannot make a profit.
                    return 0;
                }

                int minPrice = prices[0];  // Initializing the minimum price to the first day's price.
                int maxProfit = 0;        // Initializing the maximum profit to 0.

                // Iterating through the prices array, starting from the second day.
                for (int i = 1; i < prices.Length; i++)
                {
                    // If the current price is lower than the minimum price, it is updating the minimum price.
                    if (prices[i] < minPrice)
                    {
                        minPrice = prices[i];
                    }
                    else
                    {
                        // Calculating the potential profit if we sell at the current price.
                        int potentialProfit = prices[i] - minPrice;

                        // If the potential profit is greater than the current max profit, it updates the max profit.
                        if (potentialProfit > maxProfit)
                        {
                            maxProfit = potentialProfit;
                        }
                    }
                }

                return maxProfit;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        
        Question 4:
        Given a string num which represents an integer, return true if num is a strobogrammatic number.A strobogrammatic number is a number that looks the same when rotated 180 degrees (looked at upside down).
        Example 1:

        Input: num = "69"
        Output: true
        Example 2:

        Input: num = "88"
        Output: true
        Example 3:

        Input: num = "962"
        Output: false

        Constraints:
        1 <= num.length <= 50
        num consists of only digits.
        num does not contain any leading zeros except for zero itself.

        Time complexity:O(n), space complexity:O(1)
        */

        public static bool IsStrobogrammatic(string s)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                // Creating a dictionary to map strobogrammatic pairs of digits.
                Dictionary<char, char> strobogrammaticPairs = new Dictionary<char, char>
                {
                   { '0', '0' },
                   { '1', '1' },
                   { '6', '9' },
                   { '8', '8' },
                   { '9', '6' }
               };

                int left = 0;
                int right = s.Length - 1;

                while (left <= right)
                {
                    // setting the characters at the left and right positions.
                    char leftChar = s[left];
                    char rightChar = s[right];

                    if (!strobogrammaticPairs.ContainsKey(leftChar) || !strobogrammaticPairs.ContainsKey(rightChar))
                    {
                        return false;        // return's false, if either character is not a strobogrammatic digit
                    }

                    if (strobogrammaticPairs[leftChar] != rightChar)    // checking if the pair of characters is strobogrammatic.
                    {
                        return false;
                    }

                    // adjusting the left and right pointers toward the center.
                    left++;
                    right--;
                }

                // the string is strobogrammatic, if the loop finishes without returning false
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 5:
        Given an array of integers nums, return the number of good pairs.A pair (i, j) is called good if nums[i] == nums[j] and i < j. 

        Example 1:

        Input: nums = [1,2,3,1,1,3]
        Output: 4
        Explanation: There are 4 good pairs (0,3), (0,4), (3,4), (2,5) 0-indexed.
        Example 2:

        Input: nums = [1,1,1,1]
        Output: 6
        Explanation: Each pair in the array are good.
        Example 3:

        Input: nums = [1,2,3]
        Output: 0

        Constraints:

        1 <= nums.length <= 100
        1 <= nums[i] <= 100

        Time complexity:O(n), space complexity:O(n)

        */

        public static int NumIdenticalPairs(int[] nums)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                // Creating a dictionary to store the count of each number in the array.
                Dictionary<int, int> numCount = new Dictionary<int, int>();

                int goodPairs = 0;

                foreach (int num in nums)
                {
                    // Checking if the number is already in the dictionary.
                    if (numCount.ContainsKey(num))
                    {
                        // If the number is in the dictionary, incrementing the count and adding it to goodPairs.
                        int count = numCount[num];
                        goodPairs += count;
                        numCount[num] = count + 1;
                    }
                    else
                    {
                        // If the number is not in the dictionary, adding it with a count of 1.
                        numCount[num] = 1;
                    }
                }

                return goodPairs;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        Question 6

        Given an integer array nums, return the third distinct maximum number in this array. If the third maximum does not exist, return the maximum number.

        Example 1:

        Input: nums = [3,2,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2.
        The third distinct maximum is 1.
        Example 2:

        Input: nums = [1,2]
        Output: 2
        Explanation:
        The first distinct maximum is 2.
        The second distinct maximum is 1.
        The third distinct maximum does not exist, so the maximum (2) is returned instead.
        Example 3:

        Input: nums = [2,2,3,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2 (both 2's are counted together since they have the same value).
        The third distinct maximum is 1.
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1

        Time complexity:O(nlogn), space complexity:O(n)
        */

        public static int ThirdMax(int[] nums)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                // Initializing three variables
                long firstMax = long.MinValue;
                long secondMax = long.MinValue;
                long thirdMax = long.MinValue;

                // Iterating through the array to find the three maximum numbers.
                foreach (int num in nums)
                {
                    if (num == firstMax || num == secondMax || num == thirdMax)
                    {
                        // To skip duplicates.
                        continue;
                    }

                    if (num > firstMax)
                    {
                        thirdMax = secondMax;
                        secondMax = firstMax;
                        firstMax = num;
                    }
                    else if (num > secondMax)
                    {
                        thirdMax = secondMax;
                        secondMax = num;
                    }
                    else if (num > thirdMax)
                    {
                        thirdMax = num;
                    }
                }

                // If the third maximum is still set to its initial value, it doesn't exist, so return the first maximum.
                return thirdMax == long.MinValue ? (int)firstMax : (int)thirdMax;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        
        Question 7:

        You are playing a Flip Game with your friend. You are given a string currentState that contains only '+' and '-'. You and your friend take turns to flip two consecutive "++" into "--". The game ends when a person can no longer make a move, and therefore the other person will be the winner.Return all possible states of the string currentState after one valid move. You may return the answer in any order. If there is no valid move, return an empty list [].
        Example 1:
        Input: currentState = "++++"
        Output: ["--++","+--+","++--"]
        Example 2:

        Input: currentState = "+"
        Output: []
 
        Constraints:
        1 <= currentState.length <= 500
        currentState[i] is either '+' or '-'.

        Timecomplexity:O(n), Space complexity:O(n)
        */

        public static IList<string> GeneratePossibleNextMoves(string currentState)
        {
            try
            {
                // Write your code here and you can modify the return value according to the requirements
                List<string> possibleMoves = new List<string>();

                // Iterating through the string to find valid moves.
                for (int i = 0; i < currentState.Length - 1; i++)
                {
                    if (currentState[i] == '+' && currentState[i + 1] == '+')
                    {
                        // Creating a new string with the two consecutive '+' flipped to '--'.
                        string nextState = currentState.Substring(0, i) + "--" + currentState.Substring(i + 2);
                        possibleMoves.Add(nextState);
                    }
                }

                return possibleMoves;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*

        Question 8:

        Given a string s, remove the vowels 'a', 'e', 'i', 'o', and 'u' from it, and return the new string.
        Example 1:

        Input: s = "leetcodeisacommunityforcoders"
        Output: "ltcdscmmntyfrcdrs"

        Example 2:

        Input: s = "aeiou"
        Output: ""

        Timecomplexity:O(n), Space complexity:O(n)
        */

        public static string RemoveVowels(string s)
        {
            // Write your code here and you can modify the return value according to the requirements
            // Creating a StringBuilder to build the result string.
            StringBuilder result = new StringBuilder();

            // Iterating through each character in the input string.
            foreach (char c in s)
            {
                // Check if the character is not a vowel ('a', 'e', 'i', 'o', 'u').
                if (c != 'a' && c != 'e' && c != 'i' && c != 'o' && c != 'u' &&
                c != 'A' && c != 'E' && c != 'I' && c != 'O' && c != 'U')
                {
                    // Appending the non-vowel character to the result.
                    result.Append(c);
                }
            }

            return result.ToString();
        }

        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<string> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "\"" + input[i] + "\""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}
