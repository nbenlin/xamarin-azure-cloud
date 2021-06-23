using projectCdv.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace projectCdv
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : TabbedPage
    {
        HomeViewModel viewModel;
        public HomePage()
        {
            InitializeComponent();
            viewModel = new HomeViewModel();
            BindingContext = viewModel;
        }
    }
}