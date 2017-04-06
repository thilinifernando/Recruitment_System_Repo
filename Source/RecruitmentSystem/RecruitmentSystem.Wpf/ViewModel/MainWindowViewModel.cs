using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecruitmentSystem.Wpf.ViewModel.Common;

namespace RecruitmentSystem.Wpf.ViewModel
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
             CurrentViewModel = new JobOpeningViewModel();
            //CurrentViewModel = new JobListViewModel();
            CurrentViewModel1 = new JobOpeningFormViewModel();
        }

        public string Name
        {
            get { return "Test"; }
        }

        public IPageViewModel CurrentViewModel { get; set; }
        public IPageViewModel CurrentViewModel1 { get; set; }
    }
}


