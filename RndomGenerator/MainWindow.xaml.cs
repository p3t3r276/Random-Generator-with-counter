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
		List<int> expectedNumberList = new List<int>();

		int startNum = 0;
		int endNum = 0;
		int interval = 10;
		int TrickCounter = 0;

		public MainWindow(int startNumber, int endNumber, List<int> numberList)
		{
			InitializeComponent();
			counter.Interval = TimeSpan.FromMilliseconds(interval);
			counter.Tick += CounterTick;

			startNum = startNumber;
			endNum = endNumber;
			expectedNumberList = numberList;
		}

		private void CounterTick(object sender, EventArgs e)
		{
			lblView.Content = random.Next(startNum, endNum + 1);
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
				if (TrickCounter >= expectedNumberList.Count)
				{
					TrickCounter = 0;
				}
				lblView.Content = expectedNumberList[TrickCounter];
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
	}
}
