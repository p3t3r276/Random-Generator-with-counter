using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace RndomGenerator
{
    public partial class ChangeNumbers : Window
	{
		private string startNumber;
		private string endNumber;
		private List<string> expectedNumbersList;

		public ChangeNumbers(string startNumber, string endNumber, List<string> expectedNumbersList)
		{
            Mouse.OverrideCursor = Cursors.Arrow;
            InitializeComponent();
			this.startNumber = startNumber;
			this.endNumber = endNumber;
			this.expectedNumbersList = expectedNumbersList;


			txtStartNumber.Text = startNumber;
			txtEndNumber.Text = endNumber;

			txtExpectedNumbers.Text = "";
			for (int i = 0; i < expectedNumbersList.Count; i++)
			{
				txtExpectedNumbers.Text += string.Join("", expectedNumbersList[i]);
				if (i != expectedNumbersList.Count - 1)
				{
					txtExpectedNumbers.Text += ", ";
				}
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			startNumber = txtStartNumber.Text;
			endNumber = txtEndNumber.Text;
			expectedNumbersList = Helpers.StringToStringList(txtExpectedNumbers.Text, endNumber.Length);

			if (Helpers.CheckForValidInputNumbers(startNumber, endNumber, expectedNumbersList))
			{
				DialogResult = true;
			}

		}

		public string StartNumber
		{
			get { return startNumber; }
		}

		public string EndNumber
		{
			get { return endNumber; }
		}

		public List<string> ExpectedNumbersList
		{
			get { return expectedNumbersList; }
		}

		private void OnKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Escape)
			{
				DialogResult = true;
			}
		}
	}
}
