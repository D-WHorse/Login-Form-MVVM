﻿using Password_Form.Stores;
using Password_Form.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Form.Commands
{
    public class NavigateDashboardCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        public NavigateDashboardCommand(NavigationStore navigationStore) 
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new DashboardViewModel();
        }
    }
}
