using Lemon3;
using Lemon3.Controls.DevExp;
using Lemon3.Data;
using Lemon3.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace D27D1750
{
    /// <summary>
    /// Interaction logic for D27F1174.xaml
    /// </summary>
    public partial class D27F1174 : L3Window
    {
        private string _ObjectTypeID = "";
        private string _ObjectID = "";
        public string ObjectTypeID
        {
            get { return _ObjectTypeID; }
            set { _ObjectTypeID = value; }
        }
        public string ObjectID
        {
            get { return _ObjectID; }
            set { _ObjectID = value; }
        }
       
        //public EnumFormState FormState
        //{
        //    get { return _formState; }
        //    set { _formState = value; }
        //}
        public D27F1174()
        {
            InitializeComponent();
        }
        private EnumFormState _formState=EnumFormState.FormAdd;
        public EnumFormState FormState
        {
            set
            {
                _formState = value;                            
                switch (_formState)
                {
                    case EnumFormState.FormAdd:
                      
                        break;
                    case EnumFormState.FormEdit:
                        
                        break;
                    case EnumFormState.FormView:
                        COL_OCodeID.ReadOnly = true;
                        btnSave.IsEnabled = false;
                        break;
                    default:
                        break;
                }
            }
        }
        private void L3Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            LoadLanguage();
            LoadTDBD();
            LoadTDBGrid();
            this.Cursor = Cursors.Arrow;
            btnSave.IsEnabled = L3Permissions.ReturnPermission("D27F5654") >= 1;
            if(_formState == EnumFormState.FormView)
            {
                COL_OCodeID.ReadOnly = true;
                btnSave.IsEnabled = false;
                
            }
        }
        
        private void LoadLanguage()
        {
            this.Title = Lemon3.Resources.L3Resource.rL3("Ma_phan_tich") + " - D27F1174";
            COL_AnaCategoryID.Header = Lemon3.Resources.L3Resource.rL3("STT");
            COL_OCodeDesc.Header = Lemon3.Resources.L3Resource.rL3("TenU");
            COL_Description.Header = Lemon3.Resources.L3Resource.rL3("Dien_giaiU");
            COL_OCodeID.Header = Lemon3.Resources.L3Resource.rL3("Ma");
            btnSave.Content = Lemon3.Resources.L3Resource.rL3("Luu");
            
        }
        System.Data.DataTable dt = new System.Data.DataTable();
        private void LoadTDBD()
        {
            string sSQL = "-- Load DD Mã phân tích" + Environment.NewLine;
            sSQL += "EXEC D27P1274" + Environment.NewLine;
            sSQL += L3SQLClient.SQLString(L3.DivisionID) + "," + L3SQLClient.SQLString(L3.UserID) + "," + L3SQLClient.SQLString(Environment.MachineName) + "," ;
            sSQL += L3SQLClient.SQLString("") + "," + L3SQLClient.SQLString("") + "," + L3SQLClient.SQLString("LoadDDOCode");

            L3DataSource.LoadDataSource(tdbdOCodeID, sSQL);
             dt = L3SQLServer.ReturnDataTable(sSQL);
        
        }

        private void LoadTDBGrid()
        {
            string sSQL = "-- Load Grid" + Environment.NewLine;
            sSQL += "EXEC D27P1274" + Environment.NewLine;
            sSQL += L3SQLClient.SQLString(L3.DivisionID) + "," + L3SQLClient.SQLString(L3.UserID) + "," + L3SQLClient.SQLString(Environment.MachineName) + ",";
            sSQL += L3SQLClient.SQLString(_ObjectTypeID) + "," + L3SQLClient.SQLString(_ObjectID) + "," + L3SQLClient.SQLString("LoadGrid");

            //"'KH','001001'"
            L3DataSource.LoadDataSource(tdbg, sSQL);
        } 
       
        private string SQLUpdateObject()
        {
            string sSQL = "-- Load Grid" + Environment.NewLine;
            for (int i = 0; i < tdbg.VisibleRowCount; i++)
            {
                
                sSQL += "UPDATE 	Object " ;
                sSQL += "Set " + tdbg.GetCellValue(i, COL_AnaCategoryID).ToString() + "ID=" + L3SQLClient.SQLString(tdbg.GetCellValue(i, COL_OCodeID).ToString()) ;
                sSQL += " WHERE ObjectID =" + L3SQLClient.SQLString(_ObjectID) + " AND ObjectTypeID =" + L3SQLClient.SQLString(_ObjectTypeID) + Environment.NewLine;            
            }
            return sSQL;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            bool bRun = L3SQLServer.ExecuteSQL(SQLUpdateObject());
            if (bRun == true)
            {
                Lemon3.Messages.L3Msg.SaveOK();
            }
            else
            {
                Lemon3.Messages.L3Msg.SaveNotOK();
            }
        }

        private void tdbgView_FocusedRowChanged(object sender, DevExpress.Xpf.Grid.FocusedRowChangedEventArgs e)
        {
            if (tdbg.VisibleRowCount == 0)
            {
                return;
            }
            L3DataSource.LoadDataSource(tdbdOCodeID, L3DataTable.ReturnTableFilter(dt, "AnaCategoryID = " + L3SQLClient.SQLString(tdbg.GetFocusedRowCellValue(COL_AnaCategoryID).ToString()) ,true), L3.IsUniCode);
        }

        //private void tdbgView_CellValueChanged(object sender, DevExpress.Xpf.Grid.CellValueChangedEventArgs e)
        //{
        //    if (tdbg.VisibleRowCount == 0)
        //    {
        //        return;
        //    }
        //    tdbg.SetCellValueRowFocused(COL_OCodeDesc, tdbdOCodeID.ReturnValue("OcodeDesc").ToString());
        //}

        private void tdbgView_CellValueChanging(object sender, DevExpress.Xpf.Grid.CellValueChangedEventArgs e)
        {
            if (tdbg.VisibleRowCount == 0)
            {
                return;
            }
            tdbg.SetCellValueRowFocused(COL_OCodeDesc, tdbdOCodeID.ReturnValue("OcodeDesc").ToString());
           // tdbg.SetCellValueRowFocused(COL_OCodeID, tdbdOCodeID.ReturnValue("OcodeID").ToString());
        }
        private void PART_GridControl_Loaded(object sender, RoutedEventArgs e)
        {
            L3GridControl gc=sender as L3GridControl;
            gc.FilterString="";
        }
    }
}
