using RecruitmentSystem.Wpf.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecruitmentSystem.Dto;
using System.Windows;
using System.Net.Http;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Net.Http.Headers;
using Newtonsoft.Json;

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

            clickCommandAddSkills = new RelayCommand(Sample,  param => true);
            //clickCommandAddSkillsNew = new RelayCommand(ShowMessageViewSkills, param => true);

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
        public string description { get; set; }
        // public int jobid { get; set; }


        public void Sample(object obj)
        {

            AddSkillsForm(obj);
            ShowMessageViewSkills(obj);


        }


        public async void AddSkillsForm(object obj)
        {




            var url = "http://localhost:58917/api/Skills";

            var data = new AddSkillRequest()

            {
                SkillType = skilltype,
                Description = description,
                Job_JobID = JobID




            };

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);

            var httpClient = new HttpClient();

            var response = await httpClient.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));






            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
               
            }
            else
            {
            
            }

            MessageBox.Show("Saved");


        }

        private ObservableCollection<AddSkillResponse> skillList;
      
        public ObservableCollection<AddSkillResponse> SkillList
        {
            get
            {
                return skillList;
            }
            set
            {
                skillList = value;
                RaisePropertyChangedEvent("skillList");

            }


        }

        //////////////////////////////////////////////////////


        private async void ShowMessageViewSkills(object obj)
        {
            //   JobList = new ObservableCollection<CreateJobResponseDto>(new List<CreateJobResponseDto> {new CreateJobResponseDto {
            //   CreateDate = DateTime.Now, JobID = 1, JobTitle="tesst"} });


            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:58917");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                HttpResponseMessage response = await client.GetAsync("/api/Skills");

                response.EnsureSuccessStatusCode();

                var responseAsString = await response.Content.ReadAsStringAsync();


                SkillList = new ObservableCollection<AddSkillResponse>(
                    JsonConvert.DeserializeObject<List<AddSkillResponse>>(responseAsString));




            }
            catch (Exception e)
            {
                MessageBox.Show("Error");
            }
        }


    }


}









