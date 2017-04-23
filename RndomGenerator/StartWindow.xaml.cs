using System.Windows;

namespace RndomGenerator
{
	/// <summary>
	/// Interaction logic for StartWindow.xaml
	/// </summary>
	public partial class StartWindow : Window
	{
		public StartWindow()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			MainWindow main = new MainWindow(txtExpectedNumbers.Text);
			main.Show();
			Close();
		}
	}
}
