
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintFieldsLocationSetting.Models
{
    public class PictureGroupLocationModel
    {
        public Guid ID { get; set; }
        public Guid GroupID { get; set; }
        public Guid LocationID { get; set; }
        public string PictureName { get; set; }
        public string Description { get; set; }

        public static PictureGroupLocationModel CreateNewInstance()
        {
            return new PictureGroupLocationModel()
            {
                ID = Guid.NewGuid()
            };
        }

    }
}
