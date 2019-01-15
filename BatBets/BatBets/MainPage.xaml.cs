using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace BatBets
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }

        int count = 0;
        private async void Button_Clicked(object sender, EventArgs e)
        {
            Google google = new Google();
            
            //google.UpdateCount("ihugjhhj", "gviutfuygiygiyu");
            var result = await google.UpdateCount(pick1.SelectedItem.ToString(), selection.Text);
            await DisplayAlert("Result", result, "OK");
        }


    }
}
