using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace RndomGenerator
{
	public static class Helpers
	{
		public static List<List<string>> StringToMatrixOfStringList(string str)
		{
			List<List<string>> output = new List<List<string>>();

			string[] tokens = Array.ConvertAll(str.Split(','), p => p.Trim());

			for (int i = 0; i < tokens.Length; i++)
			{
				tokens[i] = Helpers.MakeSureStringHasLengthOfFour(tokens[i]);
			}

			foreach (string token in tokens)
			{
				output.Add(token.ToCharArray().Select(c => c.ToString()).ToList());
			}

			return output;
		}

		public static bool CheckForValidInputNumbers(string[] startNumberAsStringArray, string[] endNumberAsStringArray, List<List<string>> expectedNumbersAsStringArray)
		{
			bool output = true;

			foreach (List<string> token in expectedNumbersAsStringArray)
			{
				string[] temp = token.ToArray();
				if (ConvertStringArrayToAnInt(temp) <= ConvertStringArrayToAnInt(startNumberAsStringArray) || ConvertStringArrayToAnInt(temp) >= ConvertStringArrayToAnInt(endNumberAsStringArray))
				{
					output = false;
				}
			}

			return output;
		}

		public static int ConvertStringArrayToAnInt(string[] stringArray)
		{
			int output = 0;
			string temp = string.Empty;

			foreach (string str in stringArray)
			{
				temp += str;
			}

			try
			{
				output = Convert.ToInt32(temp);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			return output;
		}

		public static string MakeSureStringHasLengthOfFour(string numberAsString)
		{
			while (numberAsString.Length < 4)
			{
				numberAsString = "0" + numberAsString;
			}
			return numberAsString;
		}
	}
}
