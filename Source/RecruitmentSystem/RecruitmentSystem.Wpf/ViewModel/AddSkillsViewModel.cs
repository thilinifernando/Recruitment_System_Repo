using RecruitmentSystem.Wpf.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecruitmentSystem.Dto;
using System.Windows;
using RecruitmentSystem.Dto;
using System.Net.Http;
using System.Windows.Input;







namespace RecruitmentSystem.Wpf.ViewModel
{
    public class AddSkillsViewModel : ObservableObject, IPageViewModel
    {

        private ICommand clickCommandAddSkills;
        public string Name { get; set; }

        public string JobTitle { get; set; }

        public int JobID { get; set; }

        public AddSkillsViewModel()
        {

            clickCommandAddSkills = new RelayCommand(AddSkillsForm, param => true);
           
    }


   
    public ICommand ClickCommandAddSkills
        {
            get
            {
                return clickCommandAddSkills;
            }
            set
            {
                clickCommandAddSkills = value;
            }
        }
        public string skilltype { get; set; }
       // public int jobid { get; set; }


        public async void AddSkillsForm(object obj)
        {




            var url = "http://localhost:58917/api/Skills";

            var data = new AddSkillRequest()

            {
                SkillType = skilltype,
              



            };

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);

            var httpClient = new HttpClient();

            var response = await httpClient.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));

        



            // response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                // Handle success
            }
            else
            {
                // Handle failure
            }

            MessageBox.Show("Saved");
        }
    }

}