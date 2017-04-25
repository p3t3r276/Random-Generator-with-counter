using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RndomGenerator
{
	public partial class StartWindow : Window
	{

		public StartWindow()
		{
			InitializeComponent();

			foreach (Control tb in stackpanel.Children)
			{
				if (tb is TextBox)
				{
					TextBox textbox = (TextBox)tb;
					tb.GotFocus += RemovePlaceholder;
					tb.LostFocus += AddPlaceHolder;
				}
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{

			List<List<string>> expectedNumbersAsStringArray = new List<List<string>>();
			string[] startNumberAsStringArray;
			string[] endNumberAsStringArray;

			startNumberAsStringArray = MakeSureStringHasLengthOfFour(txtStartNumber.Text).ToCharArray().Select(c => c.ToString()).ToArray();
			endNumberAsStringArray = MakeSureStringHasLengthOfFour(txtEndNumber.Text).ToCharArray().Select(c => c.ToString()).ToArray();
			expectedNumbersAsStringArray = StringToMatrixOfStringList(txtExpectedNumbers.Text);



			if (CheckForValidInputNumbers(startNumberAsStringArray, endNumberAsStringArray, expectedNumbersAsStringArray))
			{
				MainWindow main = new MainWindow(startNumberAsStringArray, endNumberAsStringArray, expectedNumbersAsStringArray);
				main.Show();
				Close();
			}
			else
			{
				MessageBox.Show("Ăn gì ngu vậy?", "Lỗi nhập số liệu", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private List<List<string>> StringToMatrixOfStringList(string str)
		{
			List<List<string>> output = new List<List<string>>();

			string[] tokens = Array.ConvertAll(str.Split(','), p => p.Trim());

			for (int i = 0; i < tokens.Length; i++)
			{
				tokens[i] = MakeSureStringHasLengthOfFour(tokens[i]);
			}

			foreach (string token in tokens)
			{
				output.Add(token.ToCharArray().Select(c => c.ToString()).ToList());
			}

			return output;
		}

		private void AddPlaceHolder(object sender, RoutedEventArgs e)
		{
			TextBox tb = sender as TextBox;
			if (tb.Name == "txtStartNumber" && tb.Text == string.Empty)
			{
				tb.Text = "Nhập số nhỏ nhất";
			}
			else if (tb.Name == "txtEndNumber" && tb.Text == string.Empty)
			{
				tb.Text = "Nhập số đầu tiên";
			}
			else if (tb.Name == "txtExpectedNumbers" && tb.Text == string.Empty)
			{
				tb.Text = "Nhập các số bạn muốn xuất hiện";
			}
		}

		private void RemovePlaceholder(object sender, RoutedEventArgs e)
		{
			TextBox tb = sender as TextBox;
			tb.Text = string.Empty;
		}

		private string MakeSureStringHasLengthOfFour(string numberAsString)
		{
			while (numberAsString.Length < 4)
			{
				numberAsString = "0" + numberAsString;
			}
			return numberAsString;
		}

		private bool CheckForValidInputNumbers(string[] startNumberAsStringArray, string[] endNumberAsStringArray, List<List<string>> expectedNumbersAsStringArray)
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

		private int ConvertStringArrayToAnInt(string[] stringArray)
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
	}
}
