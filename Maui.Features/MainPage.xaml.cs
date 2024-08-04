namespace Maui.Features
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            Navigation.PushModalAsync(new GesturesPage(), false);
        }

        private void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
        {
            Navigation.PushModalAsync(new StyleResourcesPage(), false);
        }

        private void TapGestureRecognizer_Tapped_2(object sender, TappedEventArgs e)
        {
            Navigation.PushModalAsync(new CommunityToolkitPage(), false);
        }

        private void TapGestureRecognizer_Tapped_3(object sender, TappedEventArgs e)
        {
            Navigation.PushModalAsync(new FilesPage(), false);
        }
    }

}
