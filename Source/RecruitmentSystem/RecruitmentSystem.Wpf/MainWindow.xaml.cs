using Newtonsoft.Json;
using RecruitmentSystem.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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

            var url = "http://localhost:58917/api/Jobs";

            var data = new CreateJobRequestDto()

            {
                JobID = Convert.ToInt32(txt_JobId.Text),
                JobTitle = txt_JobTitle.Text,
                Create_User_ID = Convert.ToInt32(txt_Uid.Text),
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

        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("http://localhost:58917/api/Jobs");
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //try
            //{
            //    HttpResponseMessage response = await client.GetAsync("/api/Jobs");
            //    response.EnsureSuccessStatusCode();


            //    var responseAsString = await response.Content.ReadAsStringAsync();


            //    var model = JsonConvert.DeserializeObject<List<CreateJobResponseDto>>(responseAsString);

            //    this.dataGrid.ItemsSource = model;
            //    // dataGrid.DataSource = result;


            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Student not Found");
            //}





            //  var url = "http://localhost:58917/api/Jobs/getalljobs";

            //  var httpClient = new HttpClient();
            //  var response =  httpClient.GetAsync(url);

            //  //will throw an exception if not successful
            //  //rponse.EnsureSuccessStatusCode();


            // //tring content =  response.Content.ReadAsStringAsync();

            ////MessageBox.Show(content);

        }


        private async Task SendData()
        {



        }


    }
}
    

          
            //var url = "http://localhost:58917/api/Jobs/getalljobs";

           

    
    

    
       

 
