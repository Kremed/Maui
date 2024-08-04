using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;


namespace Maui.Features;

public partial class CommunityToolkitPage : ContentPage
{
    public CommunityToolkitPage()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var options = new SnackbarOptions
        {
            BackgroundColor = Colors.Blue,
            TextColor = Colors.White,
            ActionButtonTextColor = Colors.Azure,
            CornerRadius = new CornerRadius(10),
            Font = Microsoft.Maui.Font.SystemFontOfSize(14)
        };
       
        await Snackbar.Make(
             message: "شكرا لك لقد تم اظهار الرسالة بنجاح, الرجاء اعادة المحاولة مرة اخرئ",
             action: null,
             actionButtonText: "موفق",
             duration: new TimeSpan(0, 0, 5),
             options).Show();

        //await Snackbar.Make(
        //       message: "message",
        //       action: async () =>
        //       {
        //           await DisplayAlert("حدث السناك بار", "من هنا الحدث المبني علي السناك بار", "OK");
        //       },
        //       actionButtonText: "موفق",
        //       duration: new TimeSpan(0, 0, 5),
        //       options).Show();

        
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await Toast.Make("اهلا وسهلا جميعا", ToastDuration.Short, 12).Show();
    }
}