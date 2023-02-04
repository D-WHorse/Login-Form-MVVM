using Password_Form.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password_Form.Stores
{
    public class NavigationStore
    {
        public ViewModelBase CurrentViewModel { get; set; }
    }
}
