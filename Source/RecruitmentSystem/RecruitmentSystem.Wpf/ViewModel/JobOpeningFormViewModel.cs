using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecruitmentSystem.Wpf.ViewModel.Common;
using System.Windows;
using System.Windows.Input;

using Newtonsoft.Json;
using RecruitmentSystem.Dto;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RecruitmentSystem.Wpf.ViewModel
{
    public class JobOpeningFormViewModel : ObservableObject, IPageViewModel
    {

        // public string Name { get; set; }
        private ICommand clickCommand2;



        public JobOpeningFormViewModel(JobOpeningViewModel jobOpeningViewModel)
        {
            clickCommand2 = new RelayCommand(ShowMessage, param => true);
            IsFrameVisible = false;
            this.jobOpeningViewModel = jobOpeningViewModel;
        }

        public IPageViewModel CurrentViewModel1 { get; set; }


        
        public string Name { get; set; }
        
        /// <summary>
        /// ////////////////////////////////////////////////
        /// </summary>

        public ICommand ClickCommand2
        {
            get
            {
                return clickCommand2;
            }
            set
            {
                clickCommand2 = value;
            }
        }

        private bool _isFrameVisible;
        private JobOpeningViewModel jobOpeningViewModel;

        public bool IsFrameVisible
        {
            get
            {
                return _isFrameVisible;
            }
            set
            {
                _isFrameVisible = value;
                RaisePropertyChangedEvent("IsFrameVisible");
            }
        }
        //public bool MyProperty { get; set; }

       
        public IPageViewModel CurrentViewModel { get ; set; }

        public string UserName { get; set; }



        public async void ShowMessage(object obj)
        {

         var url = "http://localhost:58917/api/Jobs";

            var data = new CreateJobRequestDto()

            {
                JobTitle = UserName,
               


            };

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);

            var httpClient = new HttpClient();

            var response = await httpClient.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));

            // txt_JobId.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response);



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

            IsFrameVisible = true;

           



        }


    }
}
