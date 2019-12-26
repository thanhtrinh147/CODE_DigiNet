using DevExpress.Utils;
using DevExpress.Xpf.Grid;
using DevExpress.XtraEditors.DXErrorProvider;
using Lemon3;
using Lemon3.Controls.DevExp;
using Lemon3.Data;
using Lemon3.Functions;
using Lemon3.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace D27D1750
{
    /// <summary>
    /// Interaction logic for D27F2114.xaml
    /// </summary>
    public partial class D27F2114 : L3Window
    {
        private string _projectID = "";
        public string ProjectID
        {
            get { return _projectID; }
            set { _projectID = value; }
        }
        private string _projectName = "";
        public string ProjectName
        {
            get { return _projectName; }
            set { _projectName = value; }
        }

        public D27F2114()
        {
            InitializeComponent();
        }
        private EnumFormState _formState = EnumFormState.FormAdd;
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
                        
                        break;
                    default:
                        break;
                }
            }
        }
        private void L3Window_Loaded(object sender, RoutedEventArgs e)
        {

            this.Cursor = System.Windows.Input.Cursors.Wait;
            

            LoadLanguage();
            this.SetBackColorObligatory(null, new GridColumn[] { COL_DateFrom, COL_BookingNum});
            
            tdbg.InputDate(COL_DateTo);
            tdbg.InputDate(COL_DateFrom);
            tdbg.InputNumber288("n0", false, true,COL_BookingNum);

            txtProjectID.Text = _projectID;
            
            txtProjectName.Text = _projectName;
            btnSave.SetImage(ImageType.Save);
            btnClose.SetImage(ImageType.Close);
            LoadTDBGrid();
            
            //tdbg.Columns["BookingNum"].AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
            this.Cursor = System.Windows.Input.Cursors.Arrow;
       
        }
        




        private void LoadLanguage()
        {
            this.Title = Lemon3.Resources.L3Resource.rL3("Thiet_lap_so_lan_giu_cho") + " - D27F2114";
            lblProjectID.Content = Lemon3.Resources.L3Resource.rL3("Du_an");
            COL_Status.Header = Lemon3.Resources.L3Resource.rL3("STT");
            COL_DateFrom.Header = Lemon3.Resources.L3Resource.rL3("Tu_ngay");
            COL_DateTo.Header = Lemon3.Resources.L3Resource.rL3("Den_ngay");
            COL_BookingNum.Header = Lemon3.Resources.L3Resource.rL3("So_lan_giu_cho");
            btnSave.Content = Lemon3.Resources.L3Resource.rL3("Luu");
            btnClose.Content = Lemon3.Resources.L3Resource.rL3("DongU1");
        }
        System.Data.DataTable dt;
        private void LoadTDBGrid()
        {
            dt = Lemon3.Data.L3SQLServer.ReturnDataTable(SQLStoreD27P1114());
            L3DataSource.LoadDataSource(tdbg, SQLStoreD27P1114());
            if (tdbg.VisibleRowCount == 0)
            { tdbgView.AddNewRow(); }
        }

        private string SQLStoreD27P1114()
        {
            String sSQL = "--Đổ nguồn cho lưới "+Environment.NewLine;
            
            //sSQL+="EXEC D27P1114 '','','\"DUAN1\"','Grild'";          
            sSQL += "EXEC D27P1114";
            sSQL += L3SQLClient.SQLString(L3.UserID) + ",";
            sSQL += L3SQLClient.SQLString(Environment.MachineName) + ",";
            sSQL += L3SQLClient.SQLString(_projectID) + ",";
            sSQL += L3SQLClient.SQLString("Grild");
            return sSQL;
        }
       
        private void tdbgView_CellValueChanging(object sender, DevExpress.Xpf.Grid.CellValueChangedEventArgs e)
        {
            if (L3ConvertType.L3Int(tdbg.GetFocusedRowCellValue(COL_Status)) == 1)
            {
                if (e.Column == COL_DateFrom)
                {
                    Lemon3.Messages.L3Msg.MyMsg(L3Resource.rL3("Du_an_da_co_phieu_giu_cho_Khong_duoc_sua_gia_tri_Tu_ngay"));

                    e.Source.CancelRowEdit();
                    return;
                }
                //if (e.Column == COL_BookingNum)
                //{
                //    Lemon3.Messages.L3Msg.MyMsg(L3Resource.rL3("Du_an_da_co_phieu_giu_cho_Khong_duoc_sua_gia_tri_Tu_ngay"));

                //    e.Source.CancelRowEdit();
                //    return;
                //}
            }
            
        }
        bool check = false;
        private void tdbgView_CellValueChanged(object sender, DevExpress.Xpf.Grid.CellValueChangedEventArgs e)
        {

            if (e.Column == COL_DateTo)
            {
               
                if (tdbg.GetCellValue(tdbgView.FocusedRowHandle, COL_DateTo) != null && tdbg.GetCellValue(tdbgView.FocusedRowHandle, COL_DateTo).ToString() != "")
                {
                    if (Convert.ToDateTime(tdbg.GetFocusedRowCellValue(COL_DateFrom)).CompareTo( Convert.ToDateTime(tdbg.GetFocusedRowCellValue(COL_DateTo)))==1)
                    {
                        Lemon3.Messages.L3Msg.MyMsg(L3Resource.rL3("Ngay_den_khong_duoc_nho_hon_Ngay_tu"));
                        e.Source.CancelRowEdit();
                        return;
                    }
                    if (tdbgView.FocusedRowHandle >= tdbg.VisibleRowCount - 1)
                    {
                        if (check == false)
                        {
                            DateTime time = Convert.ToDateTime(tdbg.GetFocusedRowCellValue(COL_DateTo)).AddDays(1);
                            tdbgView.AddNewRow();
                            int newRowHandle = DataControlBase.NewItemRowHandle;
                            check = true;
                            tdbg.SetCellValue(newRowHandle, COL_DateFrom, time);
                            check = false;
                            return;
                        }
                    }
                    else
                    {
                        tdbg.SetCellValue(tdbgView.FocusedRowHandle + 1, COL_DateFrom, Convert.ToDateTime(tdbg.GetFocusedRowCellValue(COL_DateTo)).AddDays(1));
                        return;
                    }
                }
                else     //===========
                {
                    if (L3ConvertType.L3Int(tdbg.GetFocusedRowCellValue(COL_Status)) == 1)
                    {
                        if (tdbgView.FocusedRowHandle >= tdbg.VisibleRowCount - 1)
                        {
                            Lemon3.Messages.L3Msg.MyMsg(L3Resource.rL3("Du_an_da_co_phieu_giu_choKhong_duoc_phep_xoa"));
                            e.Source.CancelRowEdit();
                            return;
                        }
                        else
                        {
                            if (L3ConvertType.L3Int(tdbg.GetCellValue(tdbgView.FocusedRowHandle + 1, COL_Status)) == 1)
                            {
                                Lemon3.Messages.L3Msg.MyMsg(L3Resource.rL3("Du_an_da_co_phieu_giu_choKhong_duoc_phep_xoa"));
                                e.Source.CancelRowEdit();
                                return;
                            }
                            else
                            {

                                Lemon3.Messages.L3Msg.MyMsg(L3Resource.rL3("Du_an_da_co_phieu_giu_choKhong_duoc_phep_xoa"));
                                e.Source.CancelRowEdit();
                                tdbgView.DeleteRow(tdbgView.FocusedRowHandle + 1);
                                return;

                            }

                        }
                    }
                    else
                    {
                        if (tdbgView.FocusedRowHandle >= tdbg.VisibleRowCount - 1)
                        {

                            return;
                        }
                        else
                        {
                            if (L3ConvertType.L3Int(tdbg.GetCellValue(tdbgView.FocusedRowHandle + 1, COL_Status)) == 1)
                            {
                                Lemon3.Messages.L3Msg.MyMsg(L3Resource.rL3("Du_an_da_co_phieu_giu_choKhong_duoc_phep_xoa"));
                                e.Source.CancelRowEdit();
                                return;
                            }
                            else
                            {
                                tdbgView.DeleteRow(tdbgView.FocusedRowHandle + 1);
                                return;
                            }

                        }
                    }
                }

                #region    code cu

                //--------------------------------------cu~
                //    if (L3ConvertType.L3Int(tdbg.GetFocusedRowCellValue(COL_Status)) != 1)
                //    {
                //        if ((tdbgView.FocusedRowHandle < 0 || tdbgView.FocusedRowHandle >= tdbg.VisibleRowCount - 2))
                //        {
                //            if (tdbg.GetCellValue(tdbgView.FocusedRowHandle, COL_DateTo) == null || tdbg.GetCellValue(tdbgView.FocusedRowHandle, COL_DateTo).ToString() == "")
                //            {
                //                tdbgView.DeleteRow(tdbgView.FocusedRowHandle + 1);
                //                return;
                //            }
                //        }
                //    }
                //    else
                //    {
                //        if (tdbgView.FocusedRowHandle <= tdbg.VisibleRowCount - 1)
                //        {
                //            Lemon3.Messages.L3Msg.MyMsg(L3Resource.rL3("Du_an_da_co_phieu_giu_choKhong_duoc_phep_xoa"));
                //            e.Source.CancelRowEdit();
                //            tdbgView.DeleteRow(tdbgView.FocusedRowHandle + 1);
                //            return;
                //        }

                //    }
                //    if (L3ConvertType.L3Int(tdbg.GetFocusedRowCellValue(COL_Status)) == 1)
                //    {
                //        if (tdbg.GetFocusedRowCellValue(COL_DateTo).ToString() == "")
                //        {
                //            Lemon3.Messages.L3Msg.MyMsg(L3Resource.rL3("Du_an_da_co_phieu_giu_choKhong_duoc_phep_xoa"));
                //            e.Source.CancelRowEdit();
                //            //tdbgView.FocusedColumn = COL_DateTo;
                //            //tdbgView.FocusedRowHandle = tdbgView.FocusedRowHandle;
                //            //tdbgView.ShowEditor();
                //            return;

                //        }

                //    }


                //    if ((tdbgView.FocusedRowHandle < 0 || tdbgView.FocusedRowHandle >= tdbg.VisibleRowCount - 1))
                //    {

                //        if (check == false)
                //        {
                //            DateTime time = Convert.ToDateTime(tdbg.GetFocusedRowCellValue(COL_DateTo)).AddDays(1);
                //            tdbgView.AddNewRow();
                //            int newRowHandle = DataControlBase.NewItemRowHandle;
                //            check = true;
                //            tdbg.SetCellValue(newRowHandle, COL_DateFrom, time);
                //            check = false;
                //        }

                //    }
                //    else
                //    {
                //        if (tdbg.GetFocusedRowCellValue(COL_DateTo).ToString() == "")
                //        { }
                //        else
                //        {
                //            tdbg.SetCellValue(tdbgView.FocusedRowHandle + 1, COL_DateFrom, Convert.ToDateTime(tdbg.GetFocusedRowCellValue(COL_DateTo)).AddDays(1));                  
                //        }                      
                //    }


                //}

                #endregion
                
            }
         
            if (e.Column == COL_BookingNum)
            {
                if (L3ConvertType.L3Int(tdbg.GetFocusedRowCellValue(COL_Status)) == 1)
                {
                    if (tdbg.GetFocusedRowCellValue(COL_BookingNum).ToString() == "")
                    {
                        Lemon3.Messages.L3Msg.MyMsg(L3Resource.rL3("Du_an_da_co_phieu_giu_choKhong_duoc_phep_xoa"));
                        e.Source.CancelRowEdit();
                        tdbg.SetCellValue(tdbgView.FocusedRowHandle, COL_BookingNum, L3ConvertType.L3Int(dt.Rows[tdbgView.FocusedRowHandle]["BookingNum"]));

                        return;
                    }
                    if (L3ConvertType.L3Int(tdbg.GetFocusedRowCellValue(COL_BookingNum)) < L3ConvertType.L3Int(dt.Rows[tdbgView.FocusedRowHandle]["BookingNum"]))
                    {
                        Lemon3.Messages.L3Msg.MyMsg(L3Resource.rL3("Du_an_da_co_phieu_giu_cho_Vui_long_nhap_so_lan_lon_hon_hoac_bang_so_lan_da_thiet_lap"));
                        e.Source.CancelRowEdit();
                        tdbg.SetCellValue(tdbgView.FocusedRowHandle, COL_BookingNum, L3ConvertType.L3Int(dt.Rows[tdbgView.FocusedRowHandle]["BookingNum"]));

                        return;
                    }

                }
            }  
        }

        private bool allowSave()
        {
                      
            for (int i = 0; i < tdbg.VisibleRowCount ; i++)
            {

                if (i < tdbg.VisibleRowCount - 1)
                {
                    if (Convert.ToDateTime(tdbg.GetCellValue(i, COL_DateFrom)).CompareTo(Convert.ToDateTime(tdbg.GetCellValue(i, COL_DateTo))) == 1)
                    {
                        Lemon3.Messages.L3Msg.MyMsg(L3Resource.rL3("Ngay_den_khong_duoc_nho_hon_Ngay_tu"));
                        tdbgView.FocusedRowHandle = i;
                        tdbgView.FocusedColumn = COL_DateTo;
                        return false;
                    }
                }
                if (tdbg.GetCellValue(i, COL_DateFrom) == null || tdbg.GetCellValue(i, COL_DateFrom).ToString() == "")
                    {
                        Lemon3.Messages.L3Msg.MyMsg(L3Resource.rL3("Khong_duoc_de_trong_Tu_ngay"));
                        tdbgView.FocusedRowHandle = i;
                        tdbgView.FocusedColumn = COL_DateFrom;
                        return false;
                    }

                    if (i < tdbg.VisibleRowCount - 1 && tdbg.VisibleRowCount>1)
                    {
                        if (tdbg.GetCellValue(i, COL_DateTo) == null || tdbg.GetCellValue(i, COL_DateTo).ToString() == "")
                        {
                            Lemon3.Messages.L3Msg.MyMsg(L3Resource.rL3("Khong_duoc_de_trong_Den_ngay"));
                            tdbgView.FocusedRowHandle = i;
                            tdbgView.FocusedColumn = COL_DateTo;
                            return false;
                        }

                        if (Convert.ToDateTime(tdbg.GetCellValue(i, COL_DateTo)).AddDays(1) != Convert.ToDateTime(tdbg.GetCellValue(i + 1, COL_DateFrom)))
                        {
                            Lemon3.Messages.L3Msg.MyMsg(L3Resource.rL3("Thoi_gian_khong_hop_leU"));
                            tdbgView.FocusedRowHandle = i;
                            tdbgView.FocusedColumn = COL_DateTo;
                            return false;
                        }  
                    }
                     
                //}
                
                if (tdbg.GetCellValue(i, COL_BookingNum).ToString()=="")
                {
                    Lemon3.Messages.L3Msg.MyMsg(L3Resource.rL3("Khong_duoc_de_trong_So_lan_giu_cho"));
                    tdbgView.FocusedRowHandle = i;
                    tdbgView.FocusedColumn = COL_BookingNum;
                    return false;
                }

                if (L3ConvertType.L3Int(tdbg.GetCellValue(i, COL_BookingNum)) == 0)
                {
                    Lemon3.Messages.L3Msg.MyMsg(L3Resource.rL3("So_lan_dat_cho_phai_lon_hon_0"));
                    tdbgView.FocusedRowHandle = i;
                    tdbgView.FocusedColumn = COL_BookingNum;
                    return false;
                }
            }
            return true;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            btnSave.Focus();
            if (allowSave() == false)
            {
                return;
            }                   
            if (Lemon3.Messages.L3Msg.AskSave() == System.Windows.Forms.DialogResult.No) return;
            bool bRun = L3SQLServer.ExecuteSQL(SQLInsertD27T1522());
            if (bRun == true)
            {
                LoadTDBGrid();
                Lemon3.Messages.L3Msg.SaveOK();
            }
            else
            {
                Lemon3.Messages.L3Msg.SaveNotOK();
            }
        }
        private string SQLInsertD27T1522()
        {
            string sSQL = "--Insert D27T1522"+Environment.NewLine;
            sSQL+="BEGIN TRAN"+Environment.NewLine;
            sSQL += "DELETE 	D27T1522 WHERE 	ProjectID =" + L3SQLClient.SQLString(_projectID) + Environment.NewLine;
              for (int i = 0; i < tdbg.VisibleRowCount; i++)
            {
                sSQL+="INSERT INTO D27T1522 (ProjectID, DateFrom, DateTo, BookingNum)"+Environment.NewLine;
                sSQL+="VALUES ("+L3SQLClient.SQLString(_projectID)+",";
                sSQL += L3SQLClient.SQLDateSave(tdbg.GetCellValue(i,COL_DateFrom)) + ",";
                if (tdbg.GetCellValue(i, COL_DateTo).ToString()=="")
                {                 
                    sSQL += "NULL"+",";
                }else
                {
                    sSQL += L3SQLClient.SQLDateSave(tdbg.GetCellValue(i, COL_DateTo)) + ",";
                }              
                sSQL+=tdbg.GetCellValue(i,COL_BookingNum);
                sSQL+=")"+Environment.NewLine;
                  
             }
            sSQL+="COMMIT TRAN ";        
            return sSQL;
        }
        
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

      
      

        private void tdbgView_ShowingEditor(object sender, ShowingEditorEventArgs e)
        {
            if (e.Column == COL_DateFrom)
            {
                e.Cancel = (tdbgView.FocusedRowHandle > 0);
            }
        }

        private void tdbgView_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Tab)
            {
                if (tdbgView.FocusedRowHandle >=tdbg.VisibleRowCount-2)
                {                 
                    tdbgView.FocusedRowHandle = tdbgView.FocusedRowHandle - 1;
                    tdbgView.FocusedColumn = COL_BookingNum;
                    tdbgView.ShowEditor();
                }            
            }
        }


    }
}
