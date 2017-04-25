using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace RndomGenerator
{
	public partial class MainWindow : Window
	{
		Random random = new Random();

		private readonly DispatcherTimer counter = new DispatcherTimer();
		private readonly DispatcherTimer counter1 = new DispatcherTimer();
		private readonly DispatcherTimer counter2 = new DispatcherTimer();
		private readonly DispatcherTimer counter3 = new DispatcherTimer();

		List<List<string>> expectedNumberMatrix = new List<List<string>>();

		string[] startNum;
		string[] endNum;
		int interval = 10;

		//get the index of number is expectedNumberList
		int expectedNumbersIndex = 0;

		public MainWindow(string[] startNumber, string[] endNumber, List<List<string>> numberList)
		{
			InitializeComponent();
			counter.Interval = TimeSpan.FromMilliseconds(interval);
			counter.Tick += Counter_Tick; ;

			counter1.Interval = TimeSpan.FromMilliseconds(interval);
			counter1.Tick += Counter1_Tick; ;

			counter2.Interval = TimeSpan.FromMilliseconds(interval);
			counter2.Tick += Counter2_Tick; ;

			counter3.Interval = TimeSpan.FromMilliseconds(interval);
			counter3.Tick += Counter3_Tick; ;

			startNum = startNumber;
			endNum = endNumber;
			expectedNumberMatrix = numberList;
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

		private void Counter3_Tick(object sender, EventArgs e)
		{
			lblFourthNumber.Content = random.Next(0, 10).ToString();
		}

		private void OnKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
				stopCountersOneByOne();
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
				counter3.Start();
			}

			if (e.Key == Key.Escape)
			{
				Close();
			}
		}

		private void stopCountersOneByOne()
		{
			if (counter.IsEnabled)
			{
				counter.Stop();
				lblFirstNumber.Content = random.Next(0, Convert.ToInt32(endNum[0]) + 1);
				return;
			}

			if (!counter.IsEnabled && counter1.IsEnabled)
			{
				counter1.Stop();
				lblSecondNumber.Content = random.Next(0, Convert.ToInt32(endNum[1]) + 1);
				return;
			}

			if (!counter.IsEnabled && !counter.IsEnabled && counter2.IsEnabled)
			{
				counter2.Stop();
				return;
			}

			if (!counter.IsEnabled && !counter.IsEnabled && !counter2.IsEnabled && counter3.IsEnabled)
			{
				counter3.Stop();
			}
		}

		private void DisplayExpectedNumbers()
		{
			if (counter.IsEnabled)
			{
				counter.Stop();
				lblFirstNumber.Content = expectedNumberMatrix[expectedNumbersIndex][0];
				return;
			}

			if (!counter.IsEnabled && counter1.IsEnabled)
			{
				counter1.Stop();
				lblSecondNumber.Content = expectedNumberMatrix[expectedNumbersIndex][1];
				return;
			}

			if (!counter.IsEnabled && !counter.IsEnabled && counter2.IsEnabled)
			{
				counter2.Stop();
				lblThirdNumber.Content = expectedNumberMatrix[expectedNumbersIndex][2];
				return;
			}

			if (!counter.IsEnabled && !counter.IsEnabled && !counter2.IsEnabled && counter3.IsEnabled)
			{
				counter3.Stop();
				lblFourthNumber.Content = expectedNumberMatrix[expectedNumbersIndex][3];
			}

			expectedNumbersIndex++;

			if (expectedNumbersIndex >= expectedNumberMatrix.Count)
			{
				expectedNumbersIndex = 0;
			}
		}
	}
}
