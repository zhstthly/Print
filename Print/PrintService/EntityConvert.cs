using BLL;
using DataEntity;
using Infrastructure;
using PrintEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PrintServer
{
    public class EntityConvert<T>
    {
        public static PrintEditResultModel Objs2Fields(PrintEditResultModel model, object obj)
        {
            //寄件人信息(要首先加）
            Machining.MachiningSenderInfo(obj);
            //打印字段转换
            ChangeNotImageFields(model, obj);
            //电子发票和二维码打印（原程序使用）
            Machining.MachiningQRCodeUseFields(model.Extends, obj);
            //处理打印单里的图片信息
            FieldModel[] imageFields = model.Fields.Where(f => f.PrintType == PrintEntity.PrintType.Dynamic
                                       && f.FieldType == FieldType.Image).ToArray();
            foreach(FieldModel fm in imageFields)
            {
                fm.BindingText = Machining.MachiningPictureGroup(fm.BindingText, obj);
            }
            //获取打印纸张信息
            model.PageModel = DataManager.PageM.Find(p => p.PageID == model.TemplateModel.BindingPage);
            return model;
        }

        //泛型T表示数据块
        static PrintEditResultModel ChangeNotImageFields(PrintEditResultModel model, object obj)
        {
            if (obj == null)
                return model;
            Type t = obj.GetType();
            string className = t.Name;
            PropertyInfo[] PropertyList = t.GetProperties();
            //先获取所有属性(实体类到打印字段的映射，图片除外，因为图片的获取方式是下载的）
            foreach (PropertyInfo item in PropertyList)
            {
                //判断是否数据替换
                if (item.PropertyType.Namespace == "System.Collections.Generic")
                {
                    //数据集处理（注：一个打印单至多只能有一个数据集）
                    List<T> dataBlock = item.GetValue(obj) as List<T>;
                    List<List<DataBlockMapping>> dbmListList = new List<List<DataBlockMapping>>();
                    foreach (T db in dataBlock)
                    {
                        List<DataBlockMapping> dbmList = new List<DataBlockMapping>();
                        Type tdb = db.GetType();
                        string dbClassName = tdb.Name;
                        PropertyInfo[] dbPropertyList = tdb.GetProperties();
                        foreach (PropertyInfo dbitem in dbPropertyList)
                        {
                            object pfbm = DataManager.PrintFieldsBM.Where(p => p.ClassName == dbClassName
                                            && p.DataName == dbitem.Name).SingleOrDefault();
                            if (pfbm != null)
                            {
                                dbmList.Add(new DataBlockMapping()
                                {
                                    PrintName = (pfbm as PrintFieldsBindingModel).PrintName,
                                    DataValue = dbitem.GetValue(db).ToString()
                                });
                            }
                        }
                        dbmListList.Add(dbmList);
                    }
                    model.DataEntity = dbmListList;
                }
                else
                {
                    Type type = item.PropertyType;
                    //判断是否是基础数据类型
                    if (type == typeof(string) || type == typeof(Guid) || type.IsValueType || type == typeof(DateTime))
                    {
                        object pfbm = DataManager.PrintFieldsBM.Where(p => p.ClassName == className
                                    && p.DataName == item.Name).SingleOrDefault();
                        if (pfbm != null)
                        {
                            FieldModel[] fms = model.Fields.Where(f => f.FieldName == ((PrintFieldsBindingModel)pfbm).PrintName
                                                                && f.PrintType == PrintEntity.PrintType.Dynamic
                                                                && f.FieldType != FieldType.Image).ToArray();
                            foreach (FieldModel fm in fms)
                            {
                                if (type == typeof(decimal) && (decimal)item.GetValue(obj) == 0)
                                    fm.BindingText = "";
                                else
                                    fm.BindingText = item.GetValue(obj) == null ? "" : item.GetValue(obj).ToString();
                            }
                        }
                    }
                    else
                    {
                        Objs2Fields(model, item.GetValue(obj));
                    }
                }
            }
            return model;
        }
    }
}
