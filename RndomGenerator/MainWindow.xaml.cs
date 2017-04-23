using System;
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
		int[] intArray = { 120, 1321, 2311 };
		int TrickCounter = 0;

		public MainWindow()
		{
			InitializeComponent();
			counter.Interval = TimeSpan.FromMilliseconds(interval);
			counter.Tick += CounterTick;
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
				if (TrickCounter >= intArray.Length)
				{
					TrickCounter = 0;
				}
				lblView.Content = intArray[TrickCounter];
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
