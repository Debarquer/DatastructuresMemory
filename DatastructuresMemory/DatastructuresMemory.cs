﻿namespace DatastructuresMemory;

public class DatastructuresMemory
{
	/// <summary>
	/// Examines the datastructure List
	/// </summary>
	public static void ExamineList()
	{
		/*
		 * Loop this method untill the user inputs something to exit to main menue.
		 * Create a switch statement with cases '+' and '-'
		 * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
		 * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
		 * In both cases, look at the count and capacity of the list
		 * As a default case, tell them to use only + or -
		 * Below you can see some inspirational code to begin working.
		*/

		/// Questions:
		/// 2. The lists capacity is increased when an element is added, and there is not enough space to add it.
		/// 3. The capacity is doubled.
		/// 4. Every time the capacity is increased, a new array is created and the values are copied over.
		/// It would be inefficient to do it every time an element is added.
		/// 5. It appears the capacity does not decrease.
		/// 6. There are occasions to use an array over a list, for example:
		/// When you know that the number of elements is not going to change.
		/// When you want the data to be immutable. Since List is a reference type, it could be changed
		/// from places where it shouldn't. You can stop this by instead passing it as an array.


		Console.WriteLine("Enter a line to continue. Start the line with + to add or - to remove. Exit to leave ExamineList.");

		string input = "";
		List<string> theList = new List<string>();

		while (input != "exit")
		{
			Console.Write("Please enter a command. +, - or exit: ");

			input = Console.ReadLine();
			if (input == null || input.Length == 0) continue;

			char nav = input[0];
			string value = input.Substring(1);

			switch (nav)
			{
				case '+':
					theList.Add(value);

					Console.WriteLine($"Capacity:{theList.Capacity} Size:{theList.Count}");

					break;
				case '-':
					if (theList.Contains(value))
						theList.Remove(value);
					else
						Console.WriteLine($"The list did not contain {value}");

					Console.WriteLine($"Capacity:{theList.Capacity} Size:{theList.Count}");

					break;
				default:
					if (nav + value == "exit") break;
					else
					{
						Console.WriteLine("Please enter a string starting with +, - or is exit");
						break;
					}
			}
		}
	}

	/// <summary>
	/// Examines the datastructure Queue
	/// </summary>
	public static void ExamineQueue()
	{
		/*
		 * Loop this method untill the user inputs something to exit to main menue.
		 * Create a switch with cases to enqueue items or dequeue items
		 * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
		*/

		Console.WriteLine("Enter a line to continue. Start the line with + to add or - to remove. Exit to leave ExamineList.");

		string input = "";
		Queue<string> theQueue = new Queue<string>();

		while (input != "exit")
		{
			Console.Write("Please enter a command. +, - or exit: ");

			input = Console.ReadLine();
			if (input == null || input.Length == 0) continue;

			char nav = input[0];
			string value = input.Substring(1);

			switch (nav)
			{
				case '+':
					theQueue.Enqueue(value);

					Console.WriteLine($"Size:{theQueue.Count}");

					foreach (string item in theQueue)
					{
						Console.WriteLine(item);
					}

					break;
				case '-':
					theQueue.Dequeue();

					Console.WriteLine($"Size:{theQueue.Count}");

					foreach (string item in theQueue)
					{
						Console.WriteLine(item);
					}

					break;
				default:
					if (nav + value == "exit") break;
					else
					{
						Console.WriteLine("Please enter a string starting with +, - or is exit");
						break;
					}
			}
		}
	}

	/// <summary>
	/// Examines the datastructure Stack
	/// </summary>
	public static void ExamineStack()
	{
		/*
		 * Loop this method until the user inputs something to exit to main menue.
		 * Create a switch with cases to push or pop items
		 * Make sure to look at the stack after pushing and and poping to see how it behaves
		*/


		/// Questions
		/// 1. It would be unfair to the early customers, and could lead to them getting stuck in the stack until the store closes.

		string input = "";
		string output = "";

		Console.Write("Please enter a string to be reversed: ");
		input = Console.ReadLine();

		Stack<char> stack = new Stack<char>(input.ToCharArray());

		while (stack.Count > 0)
		{
			output += stack.Pop();
		}

		Console.WriteLine(output);
	}

    private static readonly Paranthesis[] paranthesisCharacters =
	{
		new Paranthesis(){OpeningCharacter='(', ClosingCharacter=')'},
		new Paranthesis(){OpeningCharacter='{', ClosingCharacter='}'},
		new Paranthesis(){OpeningCharacter='[', ClosingCharacter =']'},
	};

	/// <summary>
	/// Asks the user for an input string.
	/// Validates the input string using paranthesis rules.
	/// Prints the validation status to the console.
	/// </summary>
	public static void CheckParanthesis()
	{
		/*
		 * Use this method to check if the paranthesis in a string is Correct or incorrect.
		 * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
		 * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
		 */

		Console.Write("Please enter a string to be validated: ");
		string input = Console.ReadLine()!;

		if(input == null ||  input.Length == 0){
			Console.WriteLine("Invalid input");
			return;
		}

		if (ValidateParanthesisString(input))
		{
			Console.WriteLine("Valid string");
		}
		else
		{
			Console.WriteLine("Invalid string");
		}
	}

	/// <summary>
	/// Validates the given string using paranthesis rules.
	/// </summary>
	/// <param name="input">The string containing paranthesis.</param>
	/// <returns>The validation status.</returns>
	public static bool ValidateParanthesisString(string input)
	{
		Stack<char> openingParenthesisStack = [];

		foreach (char c in input.ToCharArray())
		{
			if (IsOpeningParanthesis(c))
			{
				openingParenthesisStack.Push(c);
			}
			else if (IsClosingParanthesis(c))
			{
				if (openingParenthesisStack.Count <= 0)
				{
					return false;
				}

				char openingParanthesis = openingParenthesisStack.Pop();
				if (!ParanthesisMatching(openingParanthesis, c))
				{
					return false;
				}
			}
		}

		if (openingParenthesisStack.Count > 0)
		{
			return false;
		}

		return true;
	}

	/// <summary>
	/// Checks if a character is a closing paranthesis.
	/// </summary>
	/// <param name="c">The tested character.</param>
	/// <returns>If the character is a closing paranthesis.</returns>
	private static bool IsClosingParanthesis(char c)
	{
		return paranthesisCharacters.Any(p => p.ClosingCharacter == c);
	}

	/// <summary>
	/// Checks if a character is an opening paranthesis.
	/// </summary>
	/// <param name="c">The tested character.</param>
	/// <returns>If the character is an opening paranthesis.</returns>
	private static bool IsOpeningParanthesis(char c)
	{
        return paranthesisCharacters.Any(p => p.OpeningCharacter == c);
    }

    /// <summary>
    /// Returns whether or not the opening and closing paranthesis are matching.
	/// The goal is to check if the selected closing paranthesis matches the opening
	/// paranthesis by doing the following:
	/// 1. Find all paranthesis objects where the ClosingCharacter matches closing.
	/// 2. Check if any of those objects have an OpeningCharacter matching opening.
	/// 3. Return the result.
    /// </summary>
    /// <param name="opening">The opening paranthesis character.</param>
    /// <param name="closing">The closing paranthesis character.</param>
    /// <returns>Whether or not the opening and closing paranthesis are matching./returns>
    private static bool ParanthesisMatching(char opening, char closing)
	{
		return paranthesisCharacters
            .Where(p => p.ClosingCharacter == closing)
			.Any(p => p.OpeningCharacter == opening);
	}

	/// <summary>
	/// Prints the results of GetRecursiveEven to the console.
	/// </summary>
	public static void DemoGetRecursiveEven()
	{
		for(int i = 0; i < 10; i++)
		{
			Console.WriteLine($"Even number {i}: {GetRecursiveEven(i)} ({i * 2})");
		}
	}

	/// <summary>
	/// Recursively calculates the n:th even number.
	/// </summary>
	/// <param name="n"></param>
	/// <returns>The n:th even number.</returns>
	public static int GetRecursiveEven(int n)
	{
		if(n == 0)
		{
			return 0;
		}
		else
		{
			return GetRecursiveEven(n - 1) + 2;
		}
	}

	/// <summary>
	/// Prints the results of GetFibonacciNumberRecursive to the console.
	/// </summary>
	public static void DemoGetFibonacciNumberRecursive()
	{
		for(int i = 1; i < 20; i++)
		{
			Console.Write($"{GetFibonacciNumberRecursive(i)}, ");
		}
		Console.WriteLine();
	}

	/// <summary>
	/// Returns the n:th Fibonacci number.
	/// </summary>
	/// <param name="n"></param>
	/// <returns>The n:th Fibonacci number.</returns>
	public static int GetFibonacciNumberRecursive(int n)
	{
		if (n == 0) return 0;

		return GetFibonacciNumberRecursive(1, n, 0, 1);
	}

	/// <summary>
	/// Recursively calculates the n:th Fibonacci number.
	/// </summary>
	/// <param name="i">The current index.</param>
	/// <param name="n">The target index.</param>
	/// <param name="a"></param>
	/// <param name="b"></param>
	/// <returns>The n:th Fibonacci number.</returns>
	public static int GetFibonacciNumberRecursive(int i, int n, int a, int b)
	{
		if (i == n) return a;
		else return GetFibonacciNumberRecursive(++i, n, b, a + b);
	}

	/// <summary>
	/// Prints the results of GetIterativeEven to the console.
	/// </summary>
	public static void DemoGetInterativeEven()
	{
		Console.WriteLine("Even numbers: ");
		for(int i = 1; i < 10; i++)
		{
			Console.WriteLine($"Even number {i}: {GetIterativeEven(i)} ({i * 2})");
		}
	}

	/// <summary>
	/// Calculates the n:th even number.
	/// </summary>
	/// <param name="n"></param>
	/// <returns>The n:th even number.</returns>
	public static int GetIterativeEven(int n)
	{
		int result = 2;

		for(int i = 0; i < n - 1; i++)
		{
			result += 2;
		}

		return result;
	}

	/// <summary>
	/// Prints the results of GetFibonacciNumberIterative to the console.
	/// </summary>
	public static void DemoGetFibonacciNumberIterative()
	{
		for (int i = 1; i < 20; i++)
		{
			Console.Write($"{GetFibonacciNumberIterative(i)}, ");
		}
		Console.WriteLine();
	}

	/// <summary>
	/// Calculates the n:th Fibonacci number.
	/// </summary>
	/// <param name="n">The target index.</param>
	/// <returns>The n:th Fibonacci number.</returns>
	public static int GetFibonacciNumberIterative(int n)
	{
		if(n == 0) return 0;

		int a = 0;
		int b = 1;
		for (int i = 1; i < n; i++)
		{
			int tmp = b;
			b = a + b;
			a = tmp;
		}

		return a;
	}

	/// Question: Which is more optimized for memory, recursion or iteration?
	/// Answer: iteration, because each call to the recursive function results in memory added to the stack.
	/// This memory won't be cleared until we have entered the deepest function calls, since the
	/// earlier functions won't complete until the deeper function calls are completed.
	/// 
	/// There will also be more values stored on the stack.
	/// Compare the Fibonacci functions:
	/// The iterative one has 5 values to keep track of (and some of them are only scoped to the for loop).
	/// Meanwhile the resursive version stores 4 values per function call.
}
