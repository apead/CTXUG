using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FormsMapsSample.Core.Dto
{
    public class BindableLocation
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public ICommand ActionCommand { get; set; }
        public string LocationTitle { get; set; }

        public string LocationDescription { get; set; }

    }
}
