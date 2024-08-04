namespace Maui.Features;

public partial class FilesPage : ContentPage
{
    public FilesPage()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var options = new PickOptions
        {
            PickerTitle = "اختر الصورة من الاستديو",
            FileTypes = FilePickerFileType.Images,
            //FileTypes = FilePickerFileType.Jpeg,
            //FileTypes = FilePickerFileType.Png,
            //FileTypes = FilePickerFileType.Videos,
            //FileTypes = FilePickerFileType.Pdf,
        };

        var result = await FilePicker.PickAsync(options);
       
        if (result == null)
            return;
        
        PickedImage.Source = ImageSource.FromFile(result.FullPath);



        //Stream? stream = await result.OpenReadAsync();

        //PickedImage.Source = ImageSource.FromStream(() => stream);
    }


    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        var result = await FilePicker.PickAsync();

        if (result == null)
            return;
       
        if (File.Exists(result.FullPath))
        {
            //File.ReadAllText للبساطة عندما تحتاج فقط إلى المحتوى الكامل كنص واحد.
            string content = File.ReadAllText(result.FullPath);
           

            //File.ReadAllLines إذا كنت تحتاج إلى معالجة الملف سطرًا بسطر.
            string[] lines = File.ReadAllLines(result.FullPath);
        }








        //StreamReader 
        //عبارة عن كلاس مصممة خصيصًا لقراءة الأحرف  من مكان الملف
        //using (StreamReader reader = new StreamReader(result.FullPath))
        //{
        //    // File.ReadAllText طريقة بسيطة لقراءة كل النص الموجود في ملف وإعادته كسلسلة واحدة.
        //    string content = reader.ReadToEnd();
        //}











        //string newContent = "";

        //foreach (var line in lines)
        //{
        //    newContent = line + " New File " + Environment.NewLine;
        //}

        //string[] newPathArray = result.FullPath.Split("/");

        //string newPath = "";

        //for (int i = 0; i < (newPathArray.Length - 1); i++)
        //{
        //    newPath += newPathArray[i] + "/";
        //}

        //File.WriteAllText(newPath, newContent);



        //using (FileStream fs = new FileStream(newPath, FileMode.Create, FileAccess.Write))
        //{
        //    using (StreamWriter writer = new StreamWriter(fs))
        //    {
        //        writer.Write(newContent);
        //    }
        //}
    }

    //public async Task<bool> CheckAndRequestStoragePermission()
    //{
    //    var status = await Permissions.CheckStatusAsync<Permissions.StorageRead>();
    //    if (status != PermissionStatus.Granted)
    //    {
    //        status = await Permissions.RequestAsync<Permissions.StorageRead>();
    //        status = await Permissions.RequestAsync<Permissions.StorageWrite>();
    //    }

    //    return status == PermissionStatus.Granted;
    //}
}