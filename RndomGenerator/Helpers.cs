using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace RndomGenerator
{
	public static class Helpers
	{
		public static List<string> StringToStringList(string str, int maxLength)
		{
			List<string> output = new List<string>();

			string[] tokens = Array.ConvertAll(str.Split(','), p => p.Trim());

			for (int i = 0; i < tokens.Length; i++)
			{
                while(tokens[i].Length < maxLength)
                {
                    tokens[i] = "0" + tokens[i];
                }
                output.Add(tokens[i]);
			}
			return output;
		}

		public static bool CheckForValidInputNumbers(string startNumber, string endNumber, List<string> expectedNumbers)
		{
			bool output = true;
			for (int i = 0; i < expectedNumbers.Count; i++)
			{
				if (Convert.ToInt32(expectedNumbers[i]) < Convert.ToInt32(startNumber) || Convert.ToInt32(expectedNumbers[i]) > Convert.ToInt32(endNumber))
				{
					output = false;
					MessageBox.Show("Số muốn hiển thị nằm ngoài khoảng.", "Lỗi nhập số", MessageBoxButton.OK, MessageBoxImage.Warning);
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

		public static string[] ConvertStringToStringArray(string str)
		{
			return MakeSureStringHasLengthOfFour(str).ToCharArray().Select(c => c.ToString()).ToArray();
		}
	}
}
