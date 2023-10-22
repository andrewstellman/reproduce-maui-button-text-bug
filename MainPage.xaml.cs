namespace MauiApp1;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

		PrintButtonTexts();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
	
        if (sender is Button buttonClicked)
			buttonClicked.Text = String.Empty; // Changing this to any other string doesn't reproduce the problem

		PrintButtonTexts();
    }

	private void PrintButtonTexts() {
		ButtonText.Text = $"Button1.Text = '{Button1.Text}'{Environment.NewLine}"
			+ $"Button2.Text = '{Button2.Text}'{Environment.NewLine}"
			+ $"Button3.Text = '{Button3.Text}'{Environment.NewLine}"
			+ $"Button4.Text = '{Button4.Text}'{Environment.NewLine}";
	}
}

