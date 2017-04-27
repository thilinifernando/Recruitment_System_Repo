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
    public class JobOpeningViewModel : ObservableObject, IPageViewModel
    {
        private ICommand createJobCommand;
        private ICommand jobListviewCommand;

        //page viewmodels
        private JobOpeningFormViewModel jobOpeningFormViewModel;
        private JobListViewModel jobListViewModel;

        public JobOpeningViewModel()
        {
            createJobCommand = new RelayCommand(ShowJobOpeningForm, param => true);
            jobListviewCommand = new RelayCommand(ShowJobListView, param => true);

            jobOpeningFormViewModel = new JobOpeningFormViewModel(this);
            jobListViewModel = new JobListViewModel(this);

            CurrentViewModel = jobOpeningFormViewModel;

        }

        public string Name { get; set; }

        public ICommand CreateJobCommand
        {
            get
            {
                return createJobCommand;
            }
            set
            {
                createJobCommand = value;
            }
        }

        public ICommand ClickCommandview
        {
            get
            {
                return jobListviewCommand;
            }
            set
            {
                jobListviewCommand = value;
            }
        }

       private IPageViewModel currentPageViewModel;
      
        public IPageViewModel CurrentViewModel
        {
            get
            {
                return currentPageViewModel;
            }
            set
            {
                currentPageViewModel = value;
                RaisePropertyChangedEvent("CurrentViewModel");
            }
        }

        public void ShowJobOpeningForm(object obj)
        {
          //  MessageBox.Show("ShowJobOpeningForm");
            CurrentViewModel = jobOpeningFormViewModel;
        }

        public void ShowJobListView(object obj)
        {
           // MessageBox.Show("ShowJobListView");
            CurrentViewModel= jobListViewModel;
        }



    }
}
