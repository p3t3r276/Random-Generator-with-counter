using System;
using System.Collections.Generic;
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
					tb.GotFocus += ClearContent;
					tb.LostFocus += AddPlaceHolder;
				}
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{

			List<int> expectedNumbers = new List<int>();
			int startNumber = 0;
			int endNumber = 0;

			try
			{
				startNumber = Convert.ToInt32(txtStartNumber.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}

			try
			{
				endNumber = Convert.ToInt32(txtEndNumber.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}

			try
			{
				expectedNumbers = StringToIntList(txtExpectedNumbers.Text);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}

			bool isValid = true;

			foreach (int i in expectedNumbers)
			{
				if (i <= startNumber || i >= endNumber)
				{
					isValid = false;
				}
			}

			if (startNumber >= endNumber)
			{
				isValid = false;
			}

			if (isValid)
			{
				MainWindow main = new MainWindow(startNumber, endNumber, expectedNumbers);
				main.Show();
				Close();
			}
			else
			{
				MessageBox.Show("Ăn gì ngu vậy?", "Lỗi nhập số liệu", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private List<int> StringToIntList(string str)
		{
			List<int> output = new List<int>();

			string[] tokens = Array.ConvertAll(str.Split(','), p => p.Trim());
			foreach (string token in tokens)
			{
				output.Add(Convert.ToInt32(token));
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

		private void ClearContent(object sender, RoutedEventArgs e)
		{
			TextBox tb = sender as TextBox;
			tb.Text = string.Empty;
		}
	}
}
