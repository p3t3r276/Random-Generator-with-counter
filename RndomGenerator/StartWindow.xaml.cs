using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace RndomGenerator
{
    public partial class StartWindow : Window
	{
		private const string defaultTxtStartNumber = "Nhập số nhỏ nhất";
		private const string defaultTxtEndNumber = "Nhập số lớn nhất";
		private const string defaultTxtExpectedNumbers = "Nhập các số bạn muốn xuất hiện";

		public StartWindow()
		{
			InitializeComponent();

			foreach (Control tb in stackpanel.Children)
			{
				if (tb is TextBox)
				{
					TextBox textbox = (TextBox)tb;
					tb.GotFocus += TextBoxGotFocus;
					tb.LostFocus += TextBoxLostFocus;
				}
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{

			List<string> expectedNumbers = new List<string>();
			string startNumber;
			string endNumber;

            endNumber = txtEndNumber.Text;
            startNumber = txtStartNumber.Text;
            while(startNumber.Length < endNumber.Length)
            {
                startNumber = "0" + startNumber;
            }
            expectedNumbers = Helpers.StringToStringList(txtExpectedNumbers.Text, endNumber.Length);


			if (Helpers.CheckForValidInputNumbers(startNumber, endNumber, expectedNumbers))
			{
                MainWindow main = new MainWindow(startNumber, endNumber, expectedNumbers);
                main.Show();
				Close();
			}
		}

		private void TextBoxLostFocus(object sender, RoutedEventArgs e)
		{
			TextBox tb = sender as TextBox;
			if (tb.Name == "txtStartNumber")
			{
				tb.Text = tb.Text == string.Empty ? defaultTxtStartNumber : tb.Text;
			}
			else if (tb.Name == "txtEndNumber")
			{
				tb.Text = tb.Text == string.Empty ? defaultTxtEndNumber : tb.Text;
			}
			else if (tb.Name == "txtExpectedNumbers")
			{
				tb.Text = tb.Text == string.Empty ? defaultTxtExpectedNumbers : tb.Text;
			}
		}

		private void TextBoxGotFocus(object sender, RoutedEventArgs e)
		{
			TextBox tb = sender as TextBox;
			if (tb.Name == "txtStartNumber")
			{
				tb.Text = tb.Text == defaultTxtStartNumber ? string.Empty : tb.Text;
			}
			else if (tb.Name == "txtEndNumber")
			{
				tb.Text = tb.Text == defaultTxtEndNumber ? string.Empty : tb.Text;
			}
			else if (tb.Name == "txtExpectedNumbers")
			{
				tb.Text = tb.Text == defaultTxtExpectedNumbers ? string.Empty : tb.Text;
			}
		}
	}
}
