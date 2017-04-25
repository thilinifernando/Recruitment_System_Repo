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

namespace RecruitmentSystem.Wpf.ViewModel
{
    public class JobListViewModel : ObservableObject, IPageViewModel
    {

        private ICommand clickCommandShowJobs;
        public string Name { get; set; }

        public JobListViewModel()
        {
            clickCommandShowJobs = new RelayCommand(ShowMessageViewJobs, param => true);
            //IsFrameVisible = false;
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

                RaisePropertyChangedEvent("ClickCommandShowJobs");
            }
        }

        private ObservableCollection<CreateJobResponseDto> jobList;

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
            //throw new NotImplementedException();
    }

       
    }

   

