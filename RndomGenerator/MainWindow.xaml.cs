using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace RndomGenerator
{
	public partial class MainWindow : Window
	{
		Random random = new Random();
        private Brush brush;

		private readonly DispatcherTimer counter = new DispatcherTimer();
		private readonly DispatcherTimer counter1 = new DispatcherTimer();
		private readonly DispatcherTimer counter2 = new DispatcherTimer();

		List<string> endNumbersList;

		string startNumber;
		string endNumber;
		int interval = 10;

		//get the index of number is expectedNumberList
		int expectedNumbersIndex = 0;

		public MainWindow(string startNumber, string endNumber, List<string> endNumbers)
		{
			InitializeComponent();
			Mouse.OverrideCursor = Cursors.None;
            brush = Brushes.White;
            lblFirstNumber.Foreground = brush;
            lblSecondNumber.Foreground = brush;
            lblThirdNumber.Foreground = brush;

            counter.Interval = TimeSpan.FromMilliseconds(interval);
			counter.Tick += Counter_Tick; ;

			counter1.Interval = TimeSpan.FromMilliseconds(interval);
			counter1.Tick += Counter1_Tick; ;

			counter2.Interval = TimeSpan.FromMilliseconds(interval);
			counter2.Tick += Counter2_Tick;

			this.startNumber = startNumber;
			this.endNumber = endNumber;
			endNumbersList = endNumbers;
		}

		private void Counter_Tick(object sender, EventArgs e)
		{
			lblFirstNumber.Content = random.Next(0, 10).ToString();
		}

		private void Counter1_Tick(object sender, EventArgs e)
		{
			lblSecondNumber.Content = random.Next(0, 10).ToString();
		}

		private void Counter2_Tick(object sender, EventArgs e)
		{
			lblThirdNumber.Content = random.Next(0, 10).ToString();
		}

		private void OnKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
				StopCountersOneByOne();
			}

			if (e.Key == Key.C)
			{
				DisplayExpectedNumbers();
			}

			if (e.Key == Key.Space)
			{
				counter.Start();
				counter1.Start();
				counter2.Start();
			}

			if (e.Key == Key.Escape)
			{
				ChangeNumbers changeNumberWindow = new ChangeNumbers(startNumber, endNumber, endNumbersList);
				if (changeNumberWindow.ShowDialog() == true)
				{
					startNumber = changeNumberWindow.StartNumber;
					endNumber = changeNumberWindow.EndNumber;
					endNumbersList = changeNumberWindow.ExpectedNumbersList;
				}
			}
		}

		private void StopCountersOneByOne()
		{
			if (counter.IsEnabled)
			{
				counter.Stop();
				lblFirstNumber.Content = random.Next(0, (int)Char.GetNumericValue(endNumber[0]) + 1).ToString();
				return;
			}

			if (!counter.IsEnabled && counter1.IsEnabled)
			{
				counter1.Stop();
				if (lblFirstNumber.Content.ToString() == endNumber[0].ToString())
				{
					lblSecondNumber.Content = random.Next(0, (int)Char.GetNumericValue(endNumber[1]) + 1).ToString();
				}
				return;
			}

			if (!counter.IsEnabled && !counter.IsEnabled && counter2.IsEnabled)
			{
				counter2.Stop();
				if (lblFirstNumber.Content.ToString() == endNumber[0].ToString() && lblSecondNumber.Content.ToString() == endNumber[1].ToString())
				{
					lblThirdNumber.Content = random.Next(0, (int)Char.GetNumericValue(endNumber[2]) + 1).ToString();
				}
				return;
			}
		}

		private void DisplayExpectedNumbers()
		{
			if (counter.IsEnabled)
			{
				counter.Stop();
				lblFirstNumber.Content = Char.GetNumericValue(endNumbersList[expectedNumbersIndex][0]).ToString();
				return;
			}

			if (!counter.IsEnabled && counter1.IsEnabled)
			{
				counter1.Stop();
				lblSecondNumber.Content = endNumbersList[expectedNumbersIndex][1].ToString();
				return;
			}

			if (!counter.IsEnabled && !counter.IsEnabled && counter2.IsEnabled)
			{
				counter2.Stop();
				lblThirdNumber.Content = endNumbersList[expectedNumbersIndex][2].ToString();
				return;
			}

			expectedNumbersIndex++;

			if (expectedNumbersIndex >= endNumbersList.Count)
			{
				expectedNumbersIndex = 0;
			}
		}
    }
}
