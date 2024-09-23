using System.Diagnostics;

namespace DatastructuresMemory
{
	public class Program
	{
		/// Questions:
		/// 1. Stack vs heap
		/// They use different data structures, store different types of values and have different lifetimes.
		/// The stack is smaller and uses a stack structure (First In Last Out). The stack stores value types (for example int, bool).  The stack clears automatically when it exits scope.
		/// Static variables are stored on the stack.
		/// 
		/// The heap is larger and uses a tree structure. The heap stores reference types and can store value types depending on where they are stored.
		/// The heap requires garbade collection to be cleared.
		/// 
		/// 2. Value types vs reference types
		/// Value types are usually stored on the stack. 
		/// When value types are passed to functions, they get copied.
		/// 
		/// Reference types are stored on the heap.
		/// When reference types are passed to functions, the reference is copied but they values are not.
		/// Passing values by reference can therefore be more efficient.
		/// 
		/// 3. See image
		/// ReturnValue:
		/// x is set to 3. Since x is a value type, it gets copied to y, giving it a vlue of 3. y then gets the value of 4. Then it returns the value of x, 3.
		/// ReturnValue2:
		/// x.myVlaue is set to 3. Since x and y are reference types, the reference is copied. the value of x.MyValue (and thus y.MyValue) is set to 4. Then the value of x.MyValue, 4 is returned.


		/// <summary>
		/// The main method, vill handle the menues for the program
		/// </summary>
		/// <param name="args"></param>
		static void Main()
		{

			while (true)
			{
				Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 5, 6, 7, 0) of your choice"
					+ "\n1. Examine a List"
					+ "\n2. Examine a Queue"
					+ "\n3. Examine a Stack"
					+ "\n4. CheckParenthesis"
					+ "\n5. Demo EvenRecursive"
					+ "\n6. Demo Fibonacci"
					+ "\n7. Demo IterativeEven"
					+ "\n0. Exit the application");
				char input = ' '; //Creates the character input to be used with the switch-case below.
				try
				{
					input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
				}
				catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
				{
					Console.Clear();
					Console.WriteLine("Please enter some input!");
				}
				switch (input)
				{
					case '1':
						DatastructuresMemory.ExamineList();
						break;
					case '2':
						DatastructuresMemory.ExamineQueue();
						break;
					case '3':
						DatastructuresMemory.ExamineStack();
						break;
					case '4':
						DatastructuresMemory.CheckParanthesis();
						break;
					case '5':
						DatastructuresMemory.DemoGetRecursiveEven();
						break;
					case '6':
						DatastructuresMemory.DemoGetFibonacciNumber();
						break;
					case '7':
						DatastructuresMemory.DemoGetInterativeEven();
						break;
					/*
					 * Extend the menu to include the recursive 
					 * and iterative exercises.
					 */
					case '0':
						Environment.Exit(0);
						break;
					default:
						Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
						break;
				}
			}
		}

		
	}
}