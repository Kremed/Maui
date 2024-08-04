namespace Maui.Features;

public partial class GesturesPage : ContentPage
{
    public GesturesPage()
    {
        InitializeComponent();
    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        DisplayAlert("Tapped", "Image was tapped.", "OK");
    }

    private void SwipeGestureRecognizer_Swiped(object sender, SwipedEventArgs e)
    {

        if (e.Direction == SwipeDirection.Left)
        {
            SwapStackLayout.BackgroundColor = Colors.Green;
        }
        else if (e.Direction == SwipeDirection.Right)
        {
            SwapStackLayout.BackgroundColor = Colors.Red;
        }
        else if (e.Direction == SwipeDirection.Up)
        {
            SwapStackLayout.BackgroundColor = Colors.Orange;
        }
        else if (e.Direction == SwipeDirection.Down)
        {
            SwapStackLayout.BackgroundColor = Colors.Blue;
        }
        DisplayAlert("Swiped", $"StackLayout was swaped {e.Direction}.", "OK");

    }

    private void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
    {

    }
}