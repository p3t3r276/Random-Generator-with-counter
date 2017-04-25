using System.Collections.Generic;
using System.Windows;

namespace RndomGenerator
{
	public partial class ChangeNumbers : Window
	{
		private string[] startNumberAsStringArray;
		private string[] endNumberAsStringArray;
		private List<List<string>> expectedNumbersAsMatrixList;

		public ChangeNumbers(string[] startNumberAsStringArray, string[] endNumberAsStringArray, List<List<string>> expectedNumbersAsMatrixList)
		{
			InitializeComponent();
			this.startNumberAsStringArray = startNumberAsStringArray;
			this.endNumberAsStringArray = endNumberAsStringArray;
			this.expectedNumbersAsMatrixList = expectedNumbersAsMatrixList;


			txtStartNumber.Text = Helpers.ConvertStringArrayToAnInt(startNumberAsStringArray).ToString();
			txtEndNumber.Text = Helpers.ConvertStringArrayToAnInt(endNumberAsStringArray).ToString();

			txtExpectedNumbers.Text = "";
			foreach (List<string> stringList in expectedNumbersAsMatrixList)
			{
				txtExpectedNumbers.Text += string.Join("", stringList);
				if (expectedNumbersAsMatrixList.IndexOf(stringList) != expectedNumbersAsMatrixList.Count - 1)
				{
					txtExpectedNumbers.Text += ", ";
				}
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			startNumberAsStringArray = Helpers.ConvertStringToStringArray(txtStartNumber.Text);
			endNumberAsStringArray = Helpers.ConvertStringToStringArray(txtEndNumber.Text);
			expectedNumbersAsMatrixList = Helpers.StringToMatrixOfStringList(txtExpectedNumbers.Text);

			if (Helpers.CheckForValidInputNumbers(startNumberAsStringArray, endNumberAsStringArray, expectedNumbersAsMatrixList))
			{
				DialogResult = true;
			}
			else
			{
				MessageBox.Show("Nói thiệt chứ ăn gì ngu vậy?", "Lỗi nhập số", MessageBoxButton.OKCancel, MessageBoxImage.Error);
			}

		}

		public string[] StartNumberAsStringArray
		{
			get { return startNumberAsStringArray; }
		}

		public string[] EndNumberAsStringArray
		{
			get { return endNumberAsStringArray; }
		}

		public List<List<string>> ExpectedNumbersAsMatrixList
		{
			get { return expectedNumbersAsMatrixList; }
		}
	}
}
