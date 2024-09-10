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
    public partial class EncreasePage : ContentPage
    {
        public EncreasePage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            pickerOfCategories.ItemsSource = App.Database.GetCategories().ToList();
            encreaseList.ItemsSource = App.Database.GetEncreases();
            base.OnAppearing();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateEncrease());
        }

        private async void encreaseList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Encrease selectedEncrease = (Encrease)e.SelectedItem;
            MoneyPage deleteEncrease = new MoneyPage();
            deleteEncrease.BindingContext = selectedEncrease;
            await Navigation.PushAsync(deleteEncrease);
        }
        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Category category = (Category)pickerOfCategories.SelectedItem;
            encreaseList.ItemsSource = App.Database.GetIncomes().Where(item => item.Category == category.Name);
        }
    }
}