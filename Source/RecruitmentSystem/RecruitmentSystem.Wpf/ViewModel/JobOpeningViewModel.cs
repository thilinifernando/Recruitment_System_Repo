using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecruitmentSystem.Wpf.ViewModel.Common;
using System.Windows.Input;
using System.Windows;

namespace RecruitmentSystem.Wpf.ViewModel
{
    public class JobOpeningViewModel : IPageViewModel
    {

       
      
    
        private ICommand clickCommand;
      

        public string Name { get; set; }

        public ICommand ClickCommand
        {
            get
            {
                return clickCommand;
            }
            set
            {
                clickCommand = value;
            }
        }
      
        public JobOpeningViewModel()
        {
            clickCommand = new RelayCommand(ShowMessage, param => true);


          //  CurrentViewModel = new JobListViewModel();
           
        }

        public IPageViewModel CurrentViewModel { get; set; }

        public void ShowMessage(object obj)
        {
            MessageBox.Show("Hello");
        }

       

        
    }
}
