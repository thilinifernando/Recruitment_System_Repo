using System;
using System.Collections.Generic;
using System.Linq;
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
using Newtonsoft.Json;
using RecruitmentSystem.Dto;
using System.Net.Http;
using System.Net.Http.Headers;

namespace RecruitmentSystem.Wpf.View
{
    /// <summary>
    /// Interaction logic for JobListView.xaml
    /// </summary>
    public partial class JobListView : UserControl
    {
        public JobListView()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, RoutedEventArgs e)
        {


            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:58917/api/Jobs");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                HttpResponseMessage response = await client.GetAsync("/api/Jobs");

                response.EnsureSuccessStatusCode();

                var responseAsString = await response.Content.ReadAsStringAsync();


                var model = JsonConvert.DeserializeObject<List<CreateJobResponseDto>>(responseAsString);

                this.dataGrid.ItemsSource = model;

                // dataGrid.DataSource = result;


            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
        }
    }
}
