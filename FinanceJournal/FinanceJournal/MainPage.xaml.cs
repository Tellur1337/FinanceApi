using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceJournal.Models;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using static System.Net.Mime.MediaTypeNames;

namespace FinanceJournal
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            pickerOfCategories.ItemsSource = App.Database.GetCategories().ToList();
            int sum = 0;
            List<Money> moneys = new List<Money>();
            try 
            {
                var incomes = App.Database.GetIncomes();
                string dohody = incomes.Sum(inc => inc.Amount).ToString();
                var encreases = App.database.GetEncreases().ToList();
                string rashody = encreases.Sum(enc => enc.Amount).ToString();
                moneys = incomes.ToList();
                moneys = moneys.Concat(encreases).ToList();
                sum = int.Parse(dohody) + int.Parse(rashody);
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); };
            
            
            if(moneys.Count != 0)
                MyText.Text = "Ваши операции за все время";
            else
                MyText.Text = "У вас еще нет никаких операций";
            
            
            summa.Text = "Всего: " + sum + " рублей.";
            MoneyList.ItemsSource = moneys;

            base.OnAppearing();
        }

        private void Sort_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            string classId = button.ClassId;
            Category category = (Category)pickerOfCategories.SelectedItem;

            List<Money> moneys = new List<Money>();
            moneys = App.Database.GetIncomes().Concat(App.database.GetEncreases()).ToList();


            //if (category.Name == "All")
            //    category = null;

            string text = "";
            switch(classId)
            {
                case "Today":
                    if (category != null)
                        moneys = moneys.Where(money => money.DateTimeAdding.Value.Date == DateTime.Now.Date && money.Category == category.Name).ToList();
                    else
                        moneys = moneys.Where(money => money.DateTimeAdding.Value.Date == DateTime.Now.Date).ToList();
                    MoneyList.ItemsSource = moneys;
                    text = "за сегодня";
                    break;
                case "Week":
                    if (category != null)
                        moneys = moneys.Where(money => money.DateTimeAdding.Value.Date >= DateTime.Now.Date.AddDays(-7) && money.Category == category.Name).ToList();
                    else
                        moneys = moneys.Where(money => money.DateTimeAdding.Value.Date >= DateTime.Now.Date.AddDays(-7)).ToList();
                    MoneyList.ItemsSource = moneys;
                    text = "за последнюю неделю";
                    break;
                case "Month":
                    if (category != null) 
                        moneys = moneys.Where(money => money.DateTimeAdding.Value.Date >= DateTime.Now.Date.AddDays(-30) && money.Category == category.Name).ToList();
                    else
                        moneys = moneys.Where(money => money.DateTimeAdding.Value.Date >= DateTime.Now.Date.AddDays(-30)).ToList();
                    MoneyList.ItemsSource = moneys;
                    text = "за последний месяц";
                    break;
                default:
                    if (category != null)
                        MoneyList.ItemsSource = moneys.Where(money => money.Category == category.Name).ToList();
                    else
                        MoneyList.ItemsSource = moneys;
                    text = "";
                    break;
            };

            /*if (classId == "Today")
            //{
            //    MoneyList.ItemsSource = moneys.Where(money => money.DateTimeAdding.Value.Date == DateTime.Now.Date);
            //}
            //if (classId == "Week")
            //{
            //    MoneyList.ItemsSource = moneys.Where(money => money.DateTimeAdding.Value.Date >= DateTime.Now.Date.AddDays(-7));
            //}
            //if (classId == "Month")
            //{
            //    MoneyList.ItemsSource = moneys.Where(money => money.DateTimeAdding.Value.Date >= DateTime.Now.Date.AddDays(-30));
            //}
            //if (classId == "All")
            //{
            //    MoneyList.ItemsSource = moneys;
            //}*/

            /*try
            //{
            //    //string dohody = incomes.Sum(inc => inc.Amount).ToString();
            //    //string rashody = encreases.Sum(enc => enc.Amount).ToString();
            //}
            //catch (Exception ex) { Console.WriteLine(ex.Message); };*/


            if (moneys.Count != 0)
                MyText.Text = "Все операции " + text;
            else
                MyText.Text = "У вас нет операций " + text;
        }

        private async void MoneyList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Money selectedmoney = (Money)e.SelectedItem;
            MoneyPage deleteMoney= new MoneyPage();
            deleteMoney.BindingContext = selectedmoney;
            await Navigation.PushAsync(deleteMoney);
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            var button = (Button)sender;
            string classId = button.ClassId;

            if (classId == "Incomes")
            {
                await Navigation.PushAsync(new IncomesPage());
            }
            if (classId == "Expenses")
            {
                await Navigation.PushAsync(new EncreasePage());
            }
            if (classId == "Categories")
            {
                await Navigation.PushAsync(new CategoriesPage());
            }
        }
    }
}
