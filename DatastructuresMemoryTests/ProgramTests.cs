namespace DatastructuresMemoryTests;

public class ProgramTests
{
	/// <summary>
	/// Tests DatastructuresMemory.ValidateParanthesisString with a set of valid paranthesisis strings and validates the return value.
	/// </summary>
	[Fact]
	public void ValidateParanthesisString_PassValidString_ValidateReturnValue()
	{
		// Arrange
		string[] validTestStrings =
		{
			"(())",
			"{}",
			"[({})]",
			"List<int> list = new List<int>() { 1, 2, 3, 4 };"
		};

		// Act
		bool isValid = true;
		foreach (string s in validTestStrings)
		{
			if (!DatastructuresMemory.DatastructuresMemory.ValidateParanthesisString(s))
			{
				isValid = false;
				break;
			}
		}

		// Assert
		Assert.True(isValid);
	}

	/// <summary>
	/// Tests DatastructuresMemory.ValidateParanthesisString with a set of invalid paranthesis strings and validates the return value.
	/// </summary>
	[Fact]
	public void ValidateParanthesisString_PassInvalidStrings_ValidateReturnValue()
	{
		// Arrange
		string[] invalidTestStrings =
		{
			"(()])",
			"[)",
			"{[()}]",
			"List<int> list = new List<int>() { 1, 2, 3, 4 );"
		};

		// Act
		bool isValid = false;
		foreach (string s in invalidTestStrings)
		{
			if (DatastructuresMemory.DatastructuresMemory.ValidateParanthesisString(s))
			{
				isValid = true;
				break;
			}
		}

		// Assert
		Assert.False(isValid);
	}

	/// <summary>
	/// Tests DatastructuresMemory.GetRecursiveEven with a set of integers and validates the return value.
	/// </summary>
	[Fact]
	public void GetRecursiveEven_PassIntegers_ValidateReturnValue()
	{
		// Arrange
		int n = 5;

		int[] answers = new int[n];

		// Act
		for(int i = 0; i <  n; i++)
		{
			answers[i] = DatastructuresMemory.DatastructuresMemory.GetRecursiveEven(i);
		}

		// Assert
		for (int i = 0; i < answers.Length; i++)
		{
			Assert.Equal(answers[i], i * 2);
		}
	}

	/// <summary>
	/// Tests DatastructuresMemory.GetFibonacciNumber with a set of integers and validates the return value.
	/// </summary>
	[Fact]
	public void GetFibonacci_PassIntegers_ValidateReturnValue()
	{
		const int n = 10;

		int[] correctAnswers =
		{
			0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610
		};

		int[] returnedAnswers = new int[n];

		// Act
		for(int i = 0; i < n; i++)
		{
			returnedAnswers[i] = DatastructuresMemory.DatastructuresMemory.GetFibonacciNumber(i + 1);
		}

		// Assert
		for(int i = 0; i < n; i++)
		{
			Assert.Equal(returnedAnswers[i], correctAnswers[i]);
		}
	}

	/// <summary>
	/// Tests DatastructuresMemory.GetRecursiveEven with a set of integers and validates the return value.
	/// </summary>
	[Fact]
	public void GetIterativeEven_PassIntegers_ValidateReturnValue()
	{
		// Arrange
		int n = 5;

		int[] answers = new int[n];

		// Act
		for (int i = 1; i < n; i++)
		{
			answers[i] = DatastructuresMemory.DatastructuresMemory.GetIterativeEven(i);
		}

		// Assert
		for (int i = 0; i < answers.Length; i++)
		{
			Assert.Equal(answers[i], i * 2);
		}
	}
}