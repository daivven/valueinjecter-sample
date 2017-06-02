using System.Windows.Controls;
using Omu.ValueInjecter.Silverlight;

namespace SilverlightSample
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            var p = new Product
                        {
                            ModelName = "das name",
                            Description = "bla blaster",
                            ModelNumber = "über",
                            UnitCost = 1231
                        };
            var vm = new ProductViewModel();
            gridProductDetails.DataContext = vm;

            vm.InjectFrom(p, new Foo{ModelName = "indigo"});
        }
    }

    public class Foo
    {
        public string ModelName { get; set; }
    }


}
