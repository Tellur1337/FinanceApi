using FinanceJournal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinanceJournal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeleteCategory : ContentPage
    {
        public DeleteCategory()
        {
            InitializeComponent();
        }
        private void Delete(object sender, EventArgs e)
        {
            var category = (Category)BindingContext;
            App.Database.DeleteCategory(category.Id);
            Navigation.PopAsync();
        }

        private async void Back(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}