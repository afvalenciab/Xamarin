using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ToDoForms
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async private void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(userEntry.Text) || string.IsNullOrEmpty(PassEntry.Text))
            {
                resultLabel.Text = "User Name and password is required";
            }
            else
            {
                resultLabel.Text = "Login Success";
                await Navigation.PushAsync(new NewItem());
            }
        }
    }
}
