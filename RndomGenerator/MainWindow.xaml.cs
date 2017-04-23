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

			if (e.Key == Key.K)
			{
				counter.Start();
			}
		}
	}
}
