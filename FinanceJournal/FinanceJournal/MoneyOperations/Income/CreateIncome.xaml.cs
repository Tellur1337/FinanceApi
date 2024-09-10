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
    public partial class CreateIncome : ContentPage
    {
        public CreateIncome()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            pickerOfCategories.ItemsSource = App.Database.GetCategories().ToList();
            base.OnAppearing();
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            Category category = (Category)pickerOfCategories.SelectedItem;
            Income income = new Income()
            {
                Name = enterName.Text,
                Amount = int.Parse(enterDesc.Text),
                Category = category.Name,
                DateTimeAdding = enterDate.Date
            };

            App.Database.SaveIncome(income);
            enterName.Text = "";
            enterDesc.Text = "";
        }
    }
}