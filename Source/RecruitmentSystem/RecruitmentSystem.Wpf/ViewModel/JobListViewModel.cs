using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecruitmentSystem.Wpf.ViewModel.Common;
using System.Windows.Input;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using RecruitmentSystem.Dto;
using System.Windows;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Data;
using System.Collections;
//using System.Windows.Controls;
//using System.Windows.Forms;
using System.Web.UI.WebControls;
using System.Web;
using System.ComponentModel;
//using System.Windows.Forms;

namespace RecruitmentSystem.Wpf.ViewModel
{
    public class JobListViewModel : ObservableObject, IPageViewModel
    {

        private ICommand clickCommandShowJobs;
        private ICommand commandAddSkills;

        public string Name { get; set; }

       




        public JobListViewModel(JobOpeningViewModel jobOpeningViewModel)
        {
            clickCommandShowJobs = new RelayCommand(ShowMessageViewJobs, param => true);
            commandAddSkills = new RelayCommand(AddSkills, param => true);
            this.jobOpeningViewModel = jobOpeningViewModel;
            ////////////////////////////////////////////////////////////////////////////////

            

        }
      

        public ICommand ClickCommandShowJobs
        {
            get
            {
                return clickCommandShowJobs;
            }
            set
            {
                clickCommandShowJobs = value;
            }
        }
        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////
        /// </summary>

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
/// <summary>
/// //////////////////////////////////////////////////////////////////////////////
/// </summary>

        private ObservableCollection<CreateJobResponseDto> jobList;
        private JobOpeningViewModel jobOpeningViewModel;
       // private object dataGrid;

        public ObservableCollection<CreateJobResponseDto> JobList
        {
            get
            {
                return jobList;
            }
            set
            {
                jobList = value;
                RaisePropertyChangedEvent("JobList");
               
            }

           
        }

       

        public void AddSkills(object obj)
        {

            //jobOpeningViewModel.CurrentViewModel = new AddSkillsViewModel() { JobTitle = SelectedJob.JobTitle, JobID = SelectedJob.JobID};

            jobOpeningViewModel.CurrentViewModel = new AddSkillsForJobViewModel(obj) { JobTitle = SelectedJob.JobTitle, JobID = SelectedJob.JobID };


        }

       
         

        public CreateJobResponseDto SelectedJob { get; set; }

       
        /// <summary>
        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="obj"></param>
        private async void ShowMessageViewJobs(object obj)
        {
            //JobList = new ObservableCollection<CreateJobResponseDto>(new List<CreateJobResponseDto> {new CreateJobResponseDto {
            //CreateDate = DateTime.Now, JobID = 1, JobTitle="tesst"} });


            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:58917");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                HttpResponseMessage response = await client.GetAsync("/api/Jobs");

                response.EnsureSuccessStatusCode();

                var responseAsString = await response.Content.ReadAsStringAsync();


                JobList = new ObservableCollection<CreateJobResponseDto>(
                    JsonConvert.DeserializeObject<List<CreateJobResponseDto>>(responseAsString));

                //   this.dataGrid.ItemsSource = model;

                // // dataGrid.DataSource = result;


            }
            catch (Exception e)
            {
                MessageBox.Show("Error");
            }
        }
          
    }

       
    }

   

