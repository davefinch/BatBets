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
        private void Button_Clicked(object sender, EventArgs e)
        {
            Google google = new Google();
            google.UploadTeams("ihugjhhj", "gviutfuygiygiyu");
        }
    }
}
