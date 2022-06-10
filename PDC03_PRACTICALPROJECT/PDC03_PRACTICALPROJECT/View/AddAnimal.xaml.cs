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
    public partial class AddAnimal : ContentPage
    {
        //Set Variable
        AnimalViewModel _viewModel;
        bool _isUpdate;
        int animalID;

        public AddAnimal()
        {
            InitializeComponent();

            _viewModel = new AnimalViewModel();
            _isUpdate = false;

        }
        
        public AddAnimal(AnimalModel obj)
        {
            InitializeComponent();
            _viewModel = new AnimalViewModel();
            if (obj != null)
            {
                if (obj != null)
                {
                    animalID = obj.Id;
                    txtAnimalCode.Text = obj.AnimalCode;
                    txtIntialIdentification.Text = obj.IntialIdentification;
                    txtKingdom.Text = obj.Kingdom;
                    txtClass.Text = obj.Class;
                    txtFamily.Text = obj.Family;
                    txtGenus.Text = obj.Genus;
                    txtScientificName.Text = obj.ScientificName;
                    txtTaxonomy.Text = obj.Taxonomy;
                    txtCharacteristics.Text = obj.Characteristics;
                    txtHabitat.Text = obj.Habitat;
                    txtThreats.Text = obj.Threats;
                    txtConservation.Text = obj.Conservation;
                    _isUpdate = true;
                }
            }
        }

        private async void btnSaveUpdate_Clicked(object sender, EventArgs e)
        {
            AnimalModel obj = new AnimalModel();
            obj.AnimalCode = txtAnimalCode.Text;
            obj.IntialIdentification = txtIntialIdentification.Text;
            obj.Kingdom = txtKingdom.Text;
            obj.Class = txtClass.Text;
            obj.Family = txtFamily.Text;
            obj.Genus = txtGenus.Text;
            obj.ScientificName = txtScientificName.Text;
            obj.Taxonomy = txtTaxonomy.Text;
            obj.Characteristics = txtCharacteristics.Text;
            obj.Habitat = txtHabitat.Text;
            obj.Threats = txtThreats.Text;
            obj.Conservation = txtConservation.Text;


            if (_isUpdate)
            {
                obj.Id = animalID;
                await _viewModel.UpdateAnimal(obj);
            }
            else
            {
                _viewModel.InsertAnimal(obj);
            }

            await this.Navigation.PopAsync();
        }
    }
}