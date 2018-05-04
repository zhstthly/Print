using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintFieldsLocationSetting.Models
{
    public class PictureLocationModel
    {
        public Guid ID { get; set; }
        public string LocationName { get; set; }

        public static PictureLocationModel CreateNewInstance()
        {
            return new PictureLocationModel()
            {
                ID = Guid.NewGuid()
            };
        }
    }
}
