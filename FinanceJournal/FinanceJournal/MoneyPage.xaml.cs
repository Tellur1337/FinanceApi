using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceJournal.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinanceJournal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoneyPage : ContentPage
    {
        public MoneyPage()
        {
            InitializeComponent();
        }
        private void Delete(object sender, EventArgs e)
        {
            try
            {
                var income = (Income)BindingContext;
                App.Database.DeleteIncome(income.Id);
            }
            catch
            {
                var encrease = (Encrease)BindingContext;
                App.Database.DeleteEncrease(encrease.Id);
            }
            finally
            {
                Navigation.PopAsync();
            }
            
        }

        private async void Back(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}