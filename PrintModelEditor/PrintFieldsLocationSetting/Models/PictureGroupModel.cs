using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintFieldsLocationSetting.Models
{
    public class PictureGroupModel
    {
        public Guid ID { get; set; }
        public string GroupName { get; set; }
        public static PictureGroupModel CreateNewInstance()
        {
            return new PictureGroupModel()
            {
                ID = Guid.NewGuid()
            };
        }
    }
}
