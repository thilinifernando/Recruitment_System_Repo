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
  public  class AddSkillsForJobViewModel : ObservableObject, IPageViewModel
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public string NewSkillType { get; set; }

        public string JobTitle { get; set; }

        public int JobID { get; set; }


        private ObservableCollection<AddNewSkillResponse> skillListNew;

        public ObservableCollection<AddNewSkillResponse> SkillListNew
        {
            get
            {
                return skillListNew;
            }
            set
            {
                skillListNew = value;
                RaisePropertyChangedEvent("skillListNew");

            }


        }


        public AddSkillsForJobViewModel()
        {
            commandAddSkills = new RelayCommand(AddSkills, param => true);
           
            ////////////////////////////////////////////////////////////////////////////////



        }



        private ICommand commandAddSkills;

        public ICommand CommandAddSkills
        {
            get
            {
                return commandAddSkills;
            }
            set
            {
                commandAddSkills = value;
            }
        }

        public AddSkillsForJobViewModel(object ob)
        {
            // ShowSkills = ShowMessageViewSkills();

            commandShowSkills = new RelayCommand(ShowMessageViewSkills, param => true);

        }

        public void AddSkills(object obj)
        {

            //jobOpeningViewModel.CurrentViewModel = new AddSkillsViewModel() { JobTitle = SelectedJob.JobTitle, JobID = SelectedJob.JobID};

            NewSkillType = SelectedSkills.NewSkillType;
            Description = SelectedSkills.Description ;


        }



        public AddNewSkillResponse SelectedSkills { get; set; }


    //
    //public Task ShowSkills { get; private set; }
    private ICommand commandShowSkills;
        public ICommand CommandShowSkills
        {
            get
            {
                return commandShowSkills;
            }
            set
            {
                commandShowSkills = value;
            }
        }



        private async void ShowMessageViewSkills(object obj)
        {
            //   JobList = new ObservableCollection<CreateJobResponseDto>(new List<CreateJobResponseDto> {new CreateJobResponseDto {
            //   CreateDate = DateTime.Now, JobID = 1, JobTitle="tesst"} });


            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:58917");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                HttpResponseMessage response = await client.GetAsync("/api/NewSkills");

                response.EnsureSuccessStatusCode();

                var responseAsString = await response.Content.ReadAsStringAsync();


                SkillListNew = new ObservableCollection<AddNewSkillResponse>(
                    JsonConvert.DeserializeObject<List<AddNewSkillResponse>>(responseAsString));




            }
            catch (Exception e)
            {
                MessageBox.Show("Error");
            }
        }
    }

    //public AddSkillsForJobViewModel()
    //{
    //    ShowMessageViewSkills();

    //}

 
   

}
