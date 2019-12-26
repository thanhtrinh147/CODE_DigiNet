using D45D0180.Forms;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Grid;
using Lemon3;
using Lemon3.Controls.DevExp;
using Lemon3.Data;
using Lemon3.Functions;
using Lemon3.Messages;
using Lemon3.Resources;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace D45D0180
{
    /// <summary>
    /// Interaction logic for D45F0030.xaml
    /// </summary>
    public partial class D45F0030 : L3Page
    {
        DataTable dt;

        public D45F0030()
        {
            InitializeComponent();
            this.Title = L3Resource.rL3("Dinh_nghia_loai_dieu_kienU") + " - D45F0030";
        }
        public override void SetContentForL3Page()
        {

        }
        private void L3Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            CheckIDColumn(new GridColumn[] { COL_CodeW});
            tdbg.InputNumber288("n0",false, true,COL_OrderNum);
            LoadLanguage();
            LoadtdbGrid();
            tdbg.LockRow("1");
            btnSave.IsEnabled = L3Permissions.ReturnPermission("D45F0030") > 1;
            this.Cursor = Cursors.Arrow;
        }
        
        private void LoadtdbGrid()
        {
            String sSQL = "--Load Grid"+ Environment.NewLine;
            sSQL += "SELECT 	Cast(Right(Code,2) As Int) OrderN, CASE WHEN " + L3.STRLanguage + "= 84 THEN Description ELSE Description01 END Description," + Environment.NewLine;
            sSQL += "Code, Name, Name01, OrderNum, Disabled, IsVector, CodeW, NameT" + Environment.NewLine;
            sSQL += "FROM 		D45T0030  WITH(NOLOCK)" + Environment.NewLine;
            sSQL +=  "ORDER BY 	Code"+ Environment.NewLine;
            dt = L3SQLServer.ReturnDataTable(sSQL);
          
            L3DataSource.LoadDataSource(tdbg, dt);
            for (int i = 0; i < tdbg.VisibleRowCount; i++)
            {
                if (tdbg.GetCellValue(i, COL_OrderNum).ToString() == "0")
                {
                    tdbg.SetCellValue(i, COL_OrderNum, "");
                }
            }
        }

        private void LoadLanguage()
        {
            this.Title = L3Resource.rL3("Dinh_nghia_loai_dieu_kienU") + " - D45F0030";
            COL_CodeW.Header = L3Resource.rL3("Ma");
            COL_Description.Header = L3Resource.rL3("Dien_giai");
            COL_Disabled.Header = L3Resource.rL3("Su_dungU");
            COL_IsVector.Header = L3Resource.rL3("Vector_ngang");
            COL_Name.Header = L3Resource.rL3("Ten_tieng_vietU");
            COL_Name01.Header = L3Resource.rL3("Ten_tieng_anh_");
            COL_NameT.Header = L3Resource.rL3("Ten_tatU");
            COL_OrderNo.Header = L3Resource.rL3("STT");
            COL_OrderNum.Header = L3Resource.rL3("TT_hien_thi");
            //btnClose.Content = L3Resource.rL3("Dong_");
            btnSave.Content = L3Resource.rL3("Luu");
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            btnSave.Focus();
            if(AllowSave()==false)
            {
                return;
            }
            if (L3Msg.AskSave() == System.Windows.Forms.DialogResult.No)
            { return; }
            Boolean bRun= L3SQLServer.ExecuteSQL(SQLUpdateD45T0030());
            if(bRun==true)
            {
                L3Msg.SaveOK();
            }
            else
            {
                L3Msg.SaveNotOK();
            }

        }

        private Boolean AllowSave()
        {
            int numcheck = 0;
            for (int i = 0; i < tdbg.VisibleRowCount; i++)
            { 
                if(tdbg.GetCellValue(i, COL_IsVector).ToString()=="True")
                {
                    numcheck=numcheck+1;
                }
            }
            if(numcheck>1)
            {
                L3Msg.MyMsg(L3Resource.rL3("Ban_chi_duoc_thiet_lap_mot_loai_dieu_kien_theo_vector"));
                return false;
            }
            return true;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            //Application.Current.Windows[1].Close();
        }

        private string SQLUpdateD45T0030()
        {
            string sSQL = "--UPDATE D45T0030" + Environment.NewLine;
            for(int i=0;i<tdbg.VisibleRowCount;i++)
            {              
                sSQL += "UPDATE 	D45T0030" + Environment.NewLine;
                sSQL += "SET " + Environment.NewLine;
                sSQL += "Name =N" + L3SQLClient.SQLString(tdbg.GetCellValue(i, COL_Name)) + ", Name01 = N" + L3SQLClient.SQLString(tdbg.GetCellValue(i, COL_Name01)) + ", OrderNum = " + L3SQLClient.SQLString(tdbg.GetCellValue(i, COL_OrderNum)) + "," + Environment.NewLine;
                sSQL += "Disabled =" + L3SQLClient.SQLString(tdbg.GetCellValue(i, COL_Disabled)) + ", IsVector =" + L3SQLClient.SQLString(tdbg.GetCellValue(i, COL_IsVector)) + Environment.NewLine;
                sSQL += ",CodeW=" + L3SQLClient.SQLString(tdbg.GetCellValue(i, COL_CodeW)) + Environment.NewLine;
                sSQL += ",NameT=N" + L3SQLClient.SQLString(tdbg.GetCellValue(i, COL_NameT)) + Environment.NewLine;
                sSQL += "WHERE 	Code =" + L3SQLClient.SQLString(tdbg.GetCellValue(i, COL_Code)) + Environment.NewLine;
                
            }           
            return sSQL;
        }

        private void tdbgView_ValidateCell(object sender, DevExpress.Xpf.Grid.GridCellValidationEventArgs e)
        {
            if (e.Column.FieldName == "Disabled" || e.Column.FieldName == "IsVector")
            { return; }
            TableView view = sender as TableView;
            TextEdit edit = view.ActiveEditor as TextEdit;
                     
            if (edit.Text == "") return;
            switch (e.Column.FieldName)
            {
                case "CodeW":
                      int duplicate = dt.AsEnumerable().Where(w => w["CodeW"].ToString() == edit.Text).Count();
                    if (duplicate > 0)
                    {
                        D99D0041.D99C0008.MsgDuplicatePKey();
                        tdbg.SetFocusedRowCellValue(COL_CodeW, "");
                        e.IsValid = false;
                    }
                   
                    break;
                default:
                    break;
            }
        }    
        private void tdbg_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                return;
            }
        }
        int disable = 0;
        int isvector = 0;
        private void tdbgView_ColumnHeaderClick(object sender, ColumnHeaderClickEventArgs e)
        {
            switch (e.Column.FieldName)
            {
                case "Disabled":
                    tdbgView.AllowSorting = false;
                    if(disable==0)
                    {
                        for (int i = 0; i < tdbg.VisibleRowCount; i++)
                        {
                            tdbg.SetCellValue(i, COL_Disabled, 1);
                        }
                        disable = 1;
                    }else
                    {
                        for (int i = 0; i < tdbg.VisibleRowCount; i++)
                        {
                            tdbg.SetCellValue(i, COL_Disabled, 0);
                        }
                        disable = 0;
                    }
                    
                    break;
                case "IsVector":
                    tdbgView.AllowSorting = false;
                    if (isvector == 0)
                    {
                        for (int i = 0; i < tdbg.VisibleRowCount; i++)
                        {
                            tdbg.SetCellValue(i, COL_IsVector, true);
                        }
                        isvector = 1;
                    }
                    else
                    {
                        for (int i = 0; i < tdbg.VisibleRowCount; i++)
                        {
                            tdbg.SetCellValue(i, COL_IsVector, false);
                        }
                        isvector = 0;
                    }
                    break;
            }
            tdbgView.AllowSorting = true;
           
        }
        private void CheckIDColumn(GridColumn[] gridColumn, int iLength = 20, bool bFormula = false)
        {
            foreach (GridColumn col in gridColumn)
            {
                CustomTextEditSettings editSetting = new CustomTextEditSettings(col, true, iLength, bFormula);
                col.EditSettings = editSetting;
            }
        }
     
    }
}
