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
    public partial class IncomesPage : ContentPage
    {
        public IncomesPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            incomesList.ItemsSource = App.Database.GetIncomes();
            pickerOfCategories.ItemsSource = App.Database.GetCategories().ToList();
            base.OnAppearing();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateIncome());
        }

        private async void incomesList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Income selectedIncome = (Income)e.SelectedItem;
            MoneyPage deleteIncome = new MoneyPage();
            deleteIncome.BindingContext = selectedIncome;
            await Navigation.PushAsync(deleteIncome);
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Category category = (Category)pickerOfCategories.SelectedItem;
            incomesList.ItemsSource = App.Database.GetIncomes().Where(item => item.Category == category.Name);
        }
    }
}