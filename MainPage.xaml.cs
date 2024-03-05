using CommunityToolkit.Maui.Alerts;

namespace Proyecto1Udemy
{
    public partial class MainPage : ContentPage
    {
        bool isRandom = true;
        string hexVal;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if(!isRandom)
            {
                var red = sldRed.Value;
                var green = sldVerde.Value;
                var blue = sldBlue.Value;

                Color color = Color.FromRgb(red, green, blue);
                SetColor(color);
                isRandom=false;
            }

        }

        private void SetColor(Color color)
        {
            btnRandom.BackgroundColor = color;
            Container.BackgroundColor = color;  
            lblHex.Text = color.ToHex();
            hexVal=color.ToHex();
        }

        private void btnRandom_Clicked(object sender, EventArgs e)
        {
            var random = new Random();
            var color = Color.FromRgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
            sldRed.Value = color.Red;
            sldVerde.Value = color.Green;
            sldBlue.Value = color.Blue;
            SetColor(color);
            isRandom = true;
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(hexVal);
            var toast = Toast.Make("Color Copied", CommunityToolkit.Maui.Core.ToastDuration.Short, 12);
            await toast.Show();
        }
    }

}
