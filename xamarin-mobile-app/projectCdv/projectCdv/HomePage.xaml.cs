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
            new ToolbarItem() { Icon = "ic_action_add.png" };

            IconImageSource = "ic_action_person.png";
            IconImageSource = "ic_action_place.png";
            IconImageSource = "ic_action_home.png";
            IconImageSource = "ic_action_settings_input_hdmi.png";
        }
        
        
    }
}