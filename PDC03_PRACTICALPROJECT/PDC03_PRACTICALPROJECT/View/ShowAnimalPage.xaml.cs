using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PDC03_PRACTICALPROJECT.Model;
using PDC03_PRACTICALPROJECT.ViewModel;

namespace PDC03_PRACTICALPROJECT.View
{
    public partial class ShowAnimalPage : ContentPage
    {
        AnimalViewModel viewModel;
        public ShowAnimalPage()
        {
            InitializeComponent();
            viewModel = new AnimalViewModel();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            showAnimalPage();
        }
        private void showAnimalPage()
        {
            var res = viewModel.GetAllAnimal().Result;
            lstData.ItemsSource = res;
        }

        private void btnAddRecord_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new AddAnimal());
        }

        private async void lstData_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                AnimalModel obj = (AnimalModel)e.SelectedItem;
                string res = await DisplayActionSheet("Operation", "Cancel", null, "Update", "Delete");

                switch (res)
                {
                    case "Update":
                        await this.Navigation.PushAsync(new AddAnimal(obj));
                        break;

                    case "Delete":
                        viewModel.DeleteAnimal(obj);
                        showAnimalPage();
                        break;
                }
                lstData.SelectedItem = null;
            }
        }
    }
}