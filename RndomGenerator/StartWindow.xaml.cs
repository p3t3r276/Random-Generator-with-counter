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

			startNumberAsStringArray = Helpers.MakeSureStringHasLengthOfFour(txtStartNumber.Text).ToCharArray().Select(c => c.ToString()).ToArray();
			endNumberAsStringArray = Helpers.MakeSureStringHasLengthOfFour(txtEndNumber.Text).ToCharArray().Select(c => c.ToString()).ToArray();
			expectedNumbersAsStringArray = Helpers.StringToMatrixOfStringList(txtExpectedNumbers.Text);



			if (Helpers.CheckForValidInputNumbers(startNumberAsStringArray, endNumberAsStringArray, expectedNumbersAsStringArray))
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
	}
}
