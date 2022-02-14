using System;

static class BinaryCalculator
{
	public static int BinaryToDecimalNumber(string currentByte)
	{
		string[] array = new string[currentByte.Length];

		int number = 0;

		for (int j= 0, i = currentByte.Length - 1; i >= 0 && j < currentByte.Length; i--,j++)
		{
			array[j] = currentByte[i].ToString();
		}

		for (int i = 0; i < currentByte.Length; i++)
		{
			if (array[i] == "1")
			{
				number += (int)Math.Pow(2, i);
			}
		}
		return number;
	}
	public static string DecimalToBinaryNumber(int number)
	{
		string result = "";

		while (number > 0)
		{
			if (number % 2 == 0)
			{
				result += "0";
			}
			else
			{
				result += "1";
			}
			number /= 2;
		}

		char[] arrayResult = result.ToCharArray();
		Array.Reverse(arrayResult);

		result = string.Empty;
		foreach (var item in arrayResult)
		{
			result += item;
		}

		return result;
	}
}
