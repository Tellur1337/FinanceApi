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
    public partial class CreateCategory : ContentPage
    {
        public CreateCategory()
        {
            InitializeComponent();
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(enterName.Text))
            {
                Category category = new Category()
                {
                    Name = enterName.Text,
                };

                App.Database.SaveCategory(category);
                enterName.Text = "";
            }            
        }
    }
}