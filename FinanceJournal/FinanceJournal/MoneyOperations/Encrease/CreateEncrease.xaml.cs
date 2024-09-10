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
    public partial class CreateEncrease : ContentPage
    {
        public CreateEncrease()
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
            Encrease encrease = new Encrease()
            {
                Name = enterName.Text,
                Amount = -Math.Abs(int.Parse(enterDesc.Text)),
                Category = category.Name,
                DateTimeAdding = enterDate.Date
            };

            App.Database.SaveEncrease(encrease);
            enterName.Text = "";
            enterDesc.Text = "";
        }
    }
}