namespace DatastructuresMemory;

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
		/// 6. One advantage could be that you could control the memory management yourself, for example when the array gets resized. (Although the capacity of a list cen be modified manually).


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

	/// <summary>
	/// An array of all opening paranthesis characters.
	/// </summary>
	public static char[] openingParanthesisCharacters =
	{
		'(',
		'{',
		'[',
	};

	/// <summary>
	/// An array of all closing paranthesis characters.
	/// </summary>
	public static char[] closingParanthesisCharacters =
	{
		')',
		'}',
		']'
	};

	/// <summary>
	/// A dictionary linking all closing paranthesis characters to their respective opening paranthesis characters.
	/// </summary>
	public static Dictionary<char, char> closingToOpeningParanthesisDictionary = new Dictionary<char, char>()
	{
		{ ')', '(' },
		{ ']', '[' },
		{ '}', '{' },
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
		return closingParanthesisCharacters.Contains(c);
	}

	/// <summary>
	/// Checks if a character is an opening paranthesis.
	/// </summary>
	/// <param name="c">The tested character.</param>
	/// <returns>If the character is an opening paranthesis.</returns>
	private static bool IsOpeningParanthesis(char c)
	{
		return openingParanthesisCharacters.Contains(c);
	}

	/// <summary>
	/// Returns whether or not the opening and closing paranthesis are matching.
	/// </summary>
	/// <param name="opening">The opening paranthesis character.</param>
	/// <param name="closing">The closing paranthesis character.</param>
	/// <returns>Whether or not the opening and closing paranthesis are matching./returns>
	private static bool ParanthesisMatching(char opening, char closing)
	{
		return closingToOpeningParanthesisDictionary[closing] == opening;
	}

	public static void DemoGetRecursiveEven()
	{
		for(int i = 0; i < 10; i++)
		{
			Console.WriteLine($"Even number {i}: {GetRecursiveEven(i)} ({i * 2})");
		}
	}

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
}
