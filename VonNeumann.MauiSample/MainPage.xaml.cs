namespace VonNeumann.MauiSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            var customFileType = new FilePickerFileType(
               new Dictionary<DevicePlatform, IEnumerable<string>>
               {
                    { DevicePlatform.WinUI, new[] { ".txt" } }, // file extension
               });

            PickOptions options = new()
            {
                PickerTitle = "Please select the instructions file",
                FileTypes = customFileType,
            };

            var result = await FilePicker.Default.PickAsync(options);
            if (result != null)
            {
                EntryInstructionsFilePath.Text = string.Empty;
                EntryInstructionsFilePath.Text = result.FullPath;
            }
        }
    }
}