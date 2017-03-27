using RecruitmentSystem.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace createvacuncy.createjob
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {

            var url = "http://localhost:58917/api/Jobs/CreateJob";

            var data = new CreateJobRequestDto()

            {
                JobID = 3,
                JobTitle = "QA",
                Create_User_ID = 2,
                CreateDate = DateTime.Now



            };

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);



            var httpClient = new HttpClient();

            var response = await httpClient.PostAsync(url, new StringContent(json,Encoding.UTF8, "application/json"));

            // response.EnsureSuccessStatusCode();
             if (response.IsSuccessStatusCode)
            {
                // Handle success
            }
            else
            {
                // Handle failure
            }
        }

    }

            //var url = "http://localhost:58917/api/Jobs/CreateJob";
            //var data = new CreateJobRequestDto()
            //{
            //    JobID = 3,
            //    JobTitle = "QA",
            //    Create_User_ID = 2,
            //    CreateDate = DateTime.Now


            //};

            //string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            //var httpClient = new HttpClient();
            //httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
            //var response = await httpClient.PostAsync(url, new StringContent(json, Encoding.UTF32, "application/json"));
            //response.EnsureSuccessStatusCode();


            ////////////////////////////////////////
            //var url = "http://localhost:58917/api/Jobs/getalljobs";

            //var httpClient = new HttpClient();
            //var response =  await httpClient.GetAsync(url);

            ////will throw an exception if not successful
            //response.EnsureSuccessStatusCode();

            //string content = await response.Content.ReadAsStringAsync();

            //MessageBox.Show(content);


             // private async Task SendData()
             //  {
        
          

             //}

    } 
    

    
       

 
