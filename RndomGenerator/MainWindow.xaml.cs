using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace RndomGenerator
{
	public partial class MainWindow : Window
	{
		int interval = 10;

		Random random = new Random();
		private readonly DispatcherTimer counter = new DispatcherTimer();
		List<int> expectedNumberArray = new List<int>();
		int TrickCounter = 0;

		public MainWindow(string stringOfExpectedNumber)
		{
			InitializeComponent();
			counter.Interval = TimeSpan.FromMilliseconds(interval);
			counter.Tick += CounterTick;
			expectedNumberArray = StringToIntArray(stringOfExpectedNumber);
		}

		private void CounterTick(object sender, EventArgs e)
		{
			lblView.Content = random.Next(0, 1501);
		}

		private void OnKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
				counter.Stop();
			}

			if (e.Key == Key.C)
			{
				counter.Stop();
				if (TrickCounter >= expectedNumberArray.Count)
				{
					TrickCounter = 0;
				}
				lblView.Content = expectedNumberArray[TrickCounter];
				TrickCounter++;
			}

			if (e.Key == Key.Space)
			{
				counter.Start();
			}

			if (e.Key == Key.Escape)
			{
				Close();
			}
		}

		private List<int> StringToIntArray(string str)
		{
			List<int> output = new List<int>();

			string[] tokens = Array.ConvertAll(str.Split(','), p => p.Trim());
			foreach (string token in tokens)
			{
				output.Add(Convert.ToInt32(token));
			}

			return output;
		}
	}
}
