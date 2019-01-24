using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using Newtonsoft.Json;


namespace BatBets
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            // Initialise
            InitializeComponent();

            // Default the picker to our saved name
            pick1.SelectedItem = Settings.UserName;

            // Update the Users Position and Winnings Total on App Screen
            // We want to do this asynchronously so the page will display befofe all the data is retrieved
            Show_Stats();
            
        }

        private async void Show_Stats()
        {
            // Update the Users Position and Winnings Total on App Screen
            spinner2.IsRunning = true;
            Google google = new Google();
            var tempResult = await google.GetStats(pick1.SelectedItem.ToString());
            var result = JsonConvert.DeserializeObject<List<string>>(tempResult);
            stats.Text = $"Position:  {result[0].ToString()}/17  Winnings:  £{result[1].ToString()} \r\n Total Wins:  {result[2].ToString()}  Last Win:  {result[3].ToString()}";
            spinner2.IsRunning = false;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            // Assign the chosen name to the app ready for next time
            Settings.UserName = pick1.SelectedItem.ToString();

            // Make sure both a name and and some text has been entered. 
            if (String.IsNullOrEmpty(pick1.SelectedItem.ToString()) || String.IsNullOrEmpty(selection.Text))
            {
                await DisplayAlert("You numbskull!", "You haven't entered all the information needed to put your bets on!", "OK");
            }
            else
            {
                // Try and disable the button at this point to prevent it being pressed twice 
                buttonActivate.IsEnabled = false;
                spinner.IsRunning = true;

                // Update the spreadsheet with the teams entered
                Google google = new Google();
                var result = await google.UpdateCount(pick1.SelectedItem.ToString(), selection.Text);

                spinner.IsRunning = false;

                await DisplayAlert(Settings.UserName + "! Result!", "The teams '" + selection.Text + "' have been uploaded to BATBets successfully.", "OK");

                buttonActivate.IsEnabled = true;

            }
        }

            private void OnSearchTap(object sender, EventArgs args)
        {
            selection.Text = "";
        }

        private async void Pick1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Assign the chosen name to the app ready for next time
            //Settings.UserName = pick1.SelectedItem.ToString();
            // Update the Users Position and Winnings Total on App Screen
            spinner2.IsRunning = true;
            Google google = new Google();
            var tempResult = await google.GetStats(pick1.SelectedItem.ToString());
            var result = JsonConvert.DeserializeObject<List<string>>(tempResult);
            stats.Text = $"Position:  {result[0].ToString()}/17  Winnings:  £{result[1].ToString()} \r\n Total Wins:  {result[2].ToString()}  Last Win:  {result[3].ToString()}";
            spinner2.IsRunning = false;
        }
    }
}
