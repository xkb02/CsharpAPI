using csharpa1;
//using MetalPerformanceShadersGraph;
//using SoundAnalysis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static csharpa1.Person;

namespace MAUI.guiLMS.ViewModels
{
    public class PersonDetailViewModel
    {
        //public PersonDetailViewModel()
        //{
        //}

        public PersonDetailViewModel(int id = 0)
        {
            if (id > 0)
            {
                LoadById(id);
            }
        }

        private void LoadById(int id)
        {
            if (id == 0) { return; }
            var person = PersonManager.Current.GetById(id) as Person;
            if (person != null)
            {
                Name = person.Name;
                ClassificationString = ClassToString(person.Classification);
                Id = person.Id;
            }

            NotifyPropertyChanged(nameof(Name));
            NotifyPropertyChanged(nameof(ClassificationString));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        //public PersonDetailViewModel(object personId)
        //{

        //}

        public string Name { get; set; }

        public int Id { get; set; }// = 0;
        public string? ClassificationString { get; set; }

        
        public void AddPerson()
        {

            if (Id <= 0)
            {
                PersonManager.Current.AddPerson(new Person { Name = Name, Classification = StringToClass(ClassificationString),});
                Shell.Current.GoToAsync("//Instructor");

            }
            else
            {
                var refToUpdate = PersonManager.Current.GetById(Id) as Person;
                refToUpdate.Name = Name;
                refToUpdate.Classification = StringToClass(ClassificationString);
            }
            Shell.Current.GoToAsync("//Instructor");

        }

        private PersonClassification StringToClass(string s)
        {
            PersonClassification classification;
            switch (s)
            {
                case "S":
                    classification = PersonClassification.Senior;
                    break;
                case "O":
                    classification = PersonClassification.Sophomore;
                    break;
                case "J":
                    classification = PersonClassification.Junior;
                    break;
                case "F":
                default:
                    classification = PersonClassification.Freshman;
                    break;
            }
            return classification;
        }

        private string? ClassToString(PersonClassification? pc)
        {
            var classificationString = string.Empty;
            switch (pc)
            {
                case PersonClassification.Senior:
                    classificationString = "S";
                    break;
                case PersonClassification.Sophomore:
                    classificationString = "O";
                    break;
                case PersonClassification.Junior:
                    classificationString = "J";
                    break;
                case PersonClassification.Freshman:
                default:
                    classificationString = "F";
                    break;
            }
            return classificationString;



        }
    }


}
