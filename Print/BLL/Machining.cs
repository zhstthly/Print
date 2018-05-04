using DataEntity;
using Infrastructure;
using PrintEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Machining
    {
        public static OrderPrintDataDTO MachiningOrder(OrderPrintDataDTO obj)
        {
            if (obj.BoxNo != null)
                obj.BoxNo = "#" + obj.BoxNo;
            obj.TempTotalQuantity = obj.OrderDetailPrintDataDtos.Sum(o => o.Quantity);
            return obj;
        }

        public static string MachiningPictureGroup(string bindingText ,object obj)
        {
            if (obj is OrderPrintDataDTO)
            {
                var odpdDTO = obj as OrderPrintDataDTO;
                var expressSetting = ConfigManager.ConfigInfo.ExpList.Find(e => e.ExpressCompanyId == odpdDTO.ExpressId);
                if (expressSetting != null)
                {
                    var pictureGroup = DataManager.PictureGroupM.Find(p => p.ID == expressSetting.PictureGroup);
                    if (pictureGroup != null)
                        return pictureGroup.GroupName;
                }
            }
            return bindingText;
        }

        public static void MachiningSenderInfo(object obj)
        {
            if (obj is OrderPrintDataDTO)
            {
                OrderPrintDataDTO orderPD = obj as OrderPrintDataDTO;
                orderPD.SenderInfo = DataManager.PrintSenderDTOList.Find(p => p.CompanyID == orderPD.SaleFilialeId
                && p.SalePlatformID == orderPD.SalePlatformId) ?? DataManager.PrintSenderDTOList.Find(p => p.CompanyID == orderPD.SaleFilialeId
                  && p.SalePlatformID == new Guid());
            }
        }

        public static void MachiningQRCodeUseFields(Dictionary<string, object> extends, object obj)
        {
            if (obj is OrderPrintDataDTO)
            {
                var odpdDTO = obj as OrderPrintDataDTO;
                extends.Add("SaleFilialeId", odpdDTO.SaleFilialeId);
                extends.Add("OrderNos",odpdDTO.OrderNos);
                extends.Add("SalePlatformId", odpdDTO.SalePlatformId);
                extends.Add("TotalBillNo", odpdDTO.TotalBillNo);
                extends.Add("DimensionalCodeDto", odpdDTO.DimensionalCodeDto);
            }
        }
    }
}
