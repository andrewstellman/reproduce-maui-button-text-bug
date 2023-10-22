# Setting .NET MAUI Button.Text to String.Empty inside a Clicked event handler causes previously set buttons to revert to previous values
This repositrory has code to reproduce a .NET MAUI bug in the Button control where it displays text after its Text property has been set to an empty string. When a Button control's text is cleared by setting its Text property equal to "" or String.Empty, buttons that were previously also cleared the same way will display their previous values.

This only seems to happen on maccatalyst.

# Steps to reproduce

Add multple Button controls to a .NET MAUI page. For example:

```
            <Button Clicked="Button_Clicked" x:Name="Button1" Text="A" />
            <Button Clicked="Button_Clicked" x:Name="Button2" Text="B" />
            <Button Clicked="Button_Clicked" x:Name="Button3" Text="C" />
            <Button Clicked="Button_Clicked" x:Name="Button4" Text="D" />
```

Add a Clicked event handler that sets its text to an empty string. For example:

```
    private void Button_Clicked(object sender, EventArgs e)
    {
        if (sender is Button buttonClicked)
            buttonClicked.Text = String.Empty;
    }
```

Run the app:

```
dotnet build -t:Run -f net7.0-maccatalyst
```

1. Click the A button. The A disappears from the button.
2. click the B button. The B disappears from the button.
  * Expected: The 'A' button stays blank.
  * Actual: The 'A' reappears on the A button.
3. click the C button. The C disappears from the button.
  * Expected: The 'B' button stays blank.
  * Actual: The 'B' reappears on the B button.
4. click the D button. The D disappears from the button.
  * Expected: The 'C' button stays blank.
  * Actual: The 'C' reappears on the A button.


# Screenshot that shows the problem

The code in this repo does everything explained above, with an extra method that shows that the Text value is still empty:

```
	private void PrintButtonTexts() {
		ButtonText.Text = $"Button1.Text = '{Button1.Text}'{Environment.NewLine}"
			+ $"Button2.Text = '{Button2.Text}'{Environment.NewLine}"
			+ $"Button3.Text = '{Button3.Text}'{Environment.NewLine}"
			+ $"Button4.Text = '{Button4.Text}'{Environment.NewLine}";
	}
```

This screenshot shows what happens after running the app like this:

```
dotnet build -t:Run -f net7.0-maccatalyst
```

then clicking buttons A, B, C, and D.

* Expected: All the buttons will be blank
* Actual: Buttons A, B, and C show text.

<img width="1136" alt="image" src="https://github.com/andrewstellman/reproduce-maui-button-text-bug/assets/7516297/e71ca8c1-1b84-47fd-b167-9f0411d2f9ee">


## Running on Windows does not reproduce the problem

This screenshot shows the same code running on Windows from Visual Studio 2022 Preview. It does not exhibit the same problems.

<img width="1282" alt="image" src="https://github.com/andrewstellman/reproduce-maui-button-text-bug/assets/7516297/a7697408-7cd3-4b8f-9ad4-b0bef2b1d9f2">


