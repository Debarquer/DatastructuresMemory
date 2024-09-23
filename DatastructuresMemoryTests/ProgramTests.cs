using DatastructuresMemory;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace DatastructuresMemoryTests
{
	public class ProgramTests
	{
		[Fact]
		public void TestValidStrings()
		{
			string[] validTestStrings =
			{
				"(())",
				"{}",
				"[({})]",
				"List<int> list = new List<int>() { 1, 2, 3, 4 };"
			};

			bool isValid = true;
			foreach (string s in validTestStrings)
			{
				if (!DatastructuresMemory.DatastructuresMemory.ValidateParanthesisString(s))
				{
					isValid = false;
					break;
				}
			}

			Assert.True(isValid);
		}

		[Fact]
		public void TestInvalidStrings()
		{
			string[] invalidTestStrings =
			{
				"(()])",
				"[)",
				"{[()}]",
				"List<int> list = new List<int>() { 1, 2, 3, 4 );"
			};

			bool isValid = false;
			foreach (string s in invalidTestStrings)
			{
				if (DatastructuresMemory.DatastructuresMemory.ValidateParanthesisString(s))
				{
					isValid = true;
					break;
				}
			}

			Assert.False(isValid);
		}
	}
}