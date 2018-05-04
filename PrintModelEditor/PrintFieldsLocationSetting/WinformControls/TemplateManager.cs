using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using PrintFieldsLocationSetting.Models;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using PrintFieldsLocationSetting.WinformControls;
using Infrastructure;

namespace PrintFieldsLocationSetting
{
    public partial class DataManager : UserControl
    {
        BindingList<FieldModel> fieldBindingList = new BindingList<FieldModel>();
        BindingList<DataBlockTemplateModel> dataBlockTemplateBindingList = new BindingList<DataBlockTemplateModel>();
        public Guid ModelID { get; set; }
        public DataManager()
        {
            InitializeComponent();
            dgv_Fields.DataSource = fieldBindingList;
        }

        public int BindingListCount()
        {
            return fieldBindingList.Count();
        }

        public void BindingData(Guid modelID)
        {
            ModelID = modelID;
            DeleteAllFieldControls();
            List<FieldModel> fmList = PrintDatas.fieldModelList.Where(p => p.ModelID == modelID)
                .OrderBy(p => p.FieldName).ToList();
            foreach (FieldModel fm in fmList)
            {
                FieldBindingListAddingNew(fm);
            }
            PaintManager.CurrentView.UnSelectAll();
            SelectTop1();
        }

        public void SelectByID(Guid id)
        {
            foreach(DataGridViewRow row in dgv_Fields.Rows)
            {
                FieldModel fm = row.DataBoundItem as FieldModel;
                if (fm.FieldID == id)
                    row.Selected = true;
            }
        }

        public void SelectNone()
        {
            if (dgv_Fields.SelectedRows.Count > 0)
            {
                dgv_Fields.SelectedRows[0].Selected = false;
            }
        }

        public void SelectTop1()
        {
            if (dgv_Fields.Rows.Count > 0)
            {
                dgv_Fields.Rows[0].Selected = true;
                FieldModel fm = dgv_Fields.Rows[0].DataBoundItem as FieldModel;
                PaintManager.CurrentView.SelectFieldControlByID(fm.FieldID);
            }
        }

        public DrawingControlBase FieldModelListAddingNew(FieldModel fm)
        {
            PrintDatas.fieldModelList.Add(fm);
            return FieldBindingListAddingNew(fm);
        }

        private DrawingControlBase FieldBindingListAddingNew(FieldModel fm)
        {
            fieldBindingList.Add(fm);
            switch (fm.FieldType)
            {
                case FieldType.DataBlock:
                    DataBlockContainer dbc = PaintManager.CurrentView.CreateADataBlock(fm);
                    dgv_Fields.Refresh();
                    return dbc;
                case FieldType.Line:
                    SplitterControl sc = PaintManager.CurrentView.CreateASplitter(fm);
                    dgv_Fields.Refresh();
                    return sc;
                default:
                    bool editing = true;
                    if (!string.IsNullOrEmpty(fm.FieldName))
                        editing = false;
                    FieldControl fc = PaintManager.CurrentView.CreateAField(fm, editing);
                    dgv_Fields.Refresh();
                    return fc;
            }
            
        }

        public void PasteModelData(Guid modelID)
        {
            List<FieldModel> copyList = PrintDatas.fieldModelList.Where(f => f.ModelID == PaintManager.CopyModelId).ToList();
            foreach (FieldModel fm in copyList)
            {
                PrintDatas.fieldModelList.Add(fm.Copy(ModelID));
            }
            PaintManager.CurrentDataManager.ModelID = new Guid();
            BindingData(modelID);
        }

        public void DeleteDataByModel(Guid modelId)
        {
            PrintDatas.fieldModelList = PrintDatas.fieldModelList.Where(p => p.ModelID != modelId).ToList();
        }

        void DeleteAllFieldControls()
        {
            PaintManager.CurrentView.ClearFieldControl();
            fieldBindingList.Clear();
        }

        public void DeleteField(DrawingControlBase dcb,bool repeatRemove = false)
        {
            foreach(FieldModel fm in PrintDatas.fieldModelList)
            {
                if (fm.FieldID == dcb.CurrentField.FieldID)
                {
                    PrintDatas.fieldModelList.Remove(fm);
                    if(!repeatRemove)
                        fieldBindingList.Remove(fm);
                    PaintManager.CurrentView.RemoveFieldControlByControl(dcb);
                    break;
                }
            }
            dgv_Fields.Refresh();
        }

        private void dgv_Fields_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DeleteField(DrawingControlBase.Current, true);
        }

        public void SyncField(FieldModel fm)
        {
            dgv_Fields.Refresh();
        }

        private void dgv_Fields_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Fields.Columns[e.ColumnIndex].DataPropertyName == "Enable")
            {
                dgv_Fields.CommitEdit(DataGridViewDataErrorContexts.Commit);
                FieldModel fm = dgv_Fields.CurrentRow.DataBoundItem as FieldModel;
                PaintManager.CurrentView.SetEnableFieldControlByID(fm.FieldID, fm.Enable);
            }
        }

        private void dgv_Fields_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_Fields.SelectedRows.Count == 0)
            {
                foreach (DataGridViewRow row in dgv_Fields.Rows)
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }
            else
            {
                foreach (DataGridViewRow row in dgv_Fields.Rows)
                {
                    if (row != dgv_Fields.SelectedRows[0])
                        row.DefaultCellStyle.BackColor = Color.White;
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.LightSeaGreen;
                        FieldModel fm = row.DataBoundItem as FieldModel;
                        PaintManager.CurrentView.SelectFieldControlByID(fm.FieldID);
                    }
                }
            }
        }

        public bool NeedSyncDataFile()
        {
            return true;
            //using (WebClient wc = new WebClient())
            //{
            //    byte[] getBytes = wc.DownloadData(ConfigManager.ServerFieldModelPath);
            //    List<FieldModel> fieldLastList = JsonConvert.DeserializeObject<List<FieldModel>>(Encoding.UTF8.GetString(getBytes));
            //    if (fieldLastList.Count == PrintDatas.fieldModelList.Count &&
            //        fieldLastList.Count(f => !PrintDatas.fieldModelList.Contains(f)) == 0)
            //        return false;
            //    return true;
            //}
        }
    }
}
