namespace DatastructuresMemoryTests;

public class ProgramTests
{
	/// <summary>
	/// Tests a set of valid paranthesisis strings.
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
	/// Tests a set of invalid paranthesis strings.
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

}