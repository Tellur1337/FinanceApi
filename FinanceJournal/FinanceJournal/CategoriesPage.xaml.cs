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
    public partial class CategoriesPage : ContentPage
    {
        public CategoriesPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            categoriesList.ItemsSource = App.Database.GetCategories().ToList();
            base.OnAppearing();
        }
        private async void categoriesList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Category selectedCategory = (Category)e.SelectedItem;
            DeleteCategory deleteCategory = new DeleteCategory();
            deleteCategory.BindingContext = selectedCategory;
            if(selectedCategory.Name != "All")
                await Navigation.PushAsync(deleteCategory);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateCategory());
        }
    }
}