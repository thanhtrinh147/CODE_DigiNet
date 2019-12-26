using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using DevExpress.Xpf.Grid;
using Lemon3.Controls.DevExp;
using System.Windows.Media.Imaging;
using DevExpress.Xpf.Editors.Settings;
using Lemon3.Functions;
using Lemon3;
using System.IO;
using Lemon3.Resources;
using Lemon3.Messages;
using System.Windows;
using Lemon3.Data;
using System.Windows.Forms;

namespace D45D0180
{
    public class D45X0002
    {
        public static void DeleteGridEvent(GridControl tdbg, GridViewBase tdbgView, DataTable _dtGrid, string sFieldID = "", bool Disabled = true)
        {
            try
            {
                if (_dtGrid == null || !(_dtGrid.Rows.Count > 0))
                {
                    return;
                }
                int iRow = 0;
                DataTable _dtView = new DataTable();
                tdbg.Focusable = false;
                DataRow[] dr = _dtGrid.Select(sFieldID + " = " + L3SQLClient.SQLString(tdbg.GetFocusedRowCellValue(sFieldID).ToString()));

                if (Disabled == false)
                {
                    var obj = _dtGrid.Select("Disabled = 0");
                    if (obj != null && obj.Count() > 0)
                    {
                        _dtView = obj.CopyToDataTable();
                        var drv = _dtView.AsEnumerable().Where(c => c["Disabled"] != null && c["Disabled"].ToString() == "0");
                        if (drv != null)
                            if (drv.Count() > 1)
                                iRow = _dtView.Rows.IndexOf(drv.ToArray()[drv.Count() - 2]);
                            else
                                iRow = 0;
                    }
                    else
                        iRow = 0;
                }
                else
                    iRow = _dtGrid.Rows.IndexOf(dr[0]);
                tdbgView.FocusedRowHandle = (iRow >= tdbg.VisibleRowCount - 1) ? iRow - 1 : iRow;
                var loopTo = dr.Length - 1;
                for (int i = 0; i <= loopTo; i++)
                    _dtGrid.Rows.Remove(dr[i]);

                tdbg.RefreshData(); // sửa lỗi FetchRowStyle ID 89865 ngày 09/12/2016
                _dtGrid.AcceptChanges();
                //if (_dtGrid.Rows.Count > 0)
                //{
                //    //if (Disabled == false)
                //    //{
                //    //    var obj = _dtGrid.Select("Disabled = 0");
                //    //    if (obj != null && obj.Count() > 0)
                //    //    {
                //    //        _dtView = obj.CopyToDataTable();
                //    //        var drv = _dtView.AsEnumerable().Where(c => c["Disabled"] != null && c["Disabled"].ToString() == "0");
                //    //        if (drv != null)
                //    //            iRow = _dtView.Rows.IndexOf(drv.Last());
                //    //    }
                //    //    else
                //    //        iRow = 0;
                //}
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace);
            }

        }

        public static bool CheckValidDateFromTo(L3DateEdit dateFrom, L3DateEdit dateTo, int Index = -1, bool bObligatory = true)
        {
            // Chưa nhập giá trị Từ Đến
            if (bObligatory & dateFrom.Text == "" & dateTo.Text == "")
            {
                D99D0041.D99C0008.MsgNotYetChoose(Lemon3.Resources.L3Resource.rL3("Ngay"));
                dateFrom.Focus();
                return false;
            }
            if (dateTo.Text == "")
                dateTo.EditValue = Convert.ToDateTime(((DateTime)dateFrom.EditValue).ToString("dd/MM/yyyy hh:mm:ss"));
            else if (dateFrom.Text == "")
                dateFrom.EditValue = Convert.ToDateTime(((DateTime)dateTo.EditValue).ToString("dd/MM/yyyy hh:mm:ss"));
            else if (Convert.ToDateTime((dateFrom.EditValue)) > Convert.ToDateTime((dateTo.EditValue)))
            {
                D99D0041.D99C0008.MsgNotYetChoose(Lemon3.Resources.L3Resource.rL3("MSG000013"));
                dateFrom.Focus();
                return false;
            }
            return true;
        }
        public static void SetImageButton(L3SimpleButton button, string UriPath)
        {
            //"pack://application:,,,/D45D0180;component/Bitmaps/ICONS/ExportToExcel.gif"
            BitmapImage ico = new BitmapImage();
            ico.BeginInit();
            ico.UriSource = new Uri("pack://application:,,,/D45D0180;component/Bitmaps/ICONS/ExportToExcel.gif");
            ico.EndInit();
            button.Glyph = ico;
        }
        public static void UpdateTDBGOrderNum(GridControl tdbg, int COL_OrderNum, int col_Value = -1, bool bUseFilterBar = false)
        {
            // Update cho trường hợp AfterDelete
            if (col_Value == -1)
            {
                if (bUseFilterBar)
                {
                    var loopTo = tdbg.VisibleRowCount - 1;
                    for (int i = 0; i <= loopTo; i++)
                        tdbg.SetCellValue(i, tdbg.Columns.ElementAt(COL_OrderNum), i + 1);
                }
                else
                {
                    bool bFocus = tdbg.IsFocused;
                    tdbg.IsEnabled = false;
                    var loopTo1 = tdbg.VisibleRowCount - 1;
                    for (int i = 0; i <= loopTo1; i++)
                        tdbg.SetCellValue(i, tdbg.Columns.ElementAt(COL_OrderNum), i + 1);
                    tdbg.IsEnabled = true;
                    if (bFocus)
                        tdbg.Focus();
                }
            }
            else //Update cho trường hợp AfterColUpdate
                if (L3ConvertType.L3String(tdbg.GetFocusedRowCellValue(tdbg.Columns.ElementAt(col_Value))) != "")
            {
                tdbg.SetCellValue(tdbg.GetSelectedRowHandles().First(), tdbg.Columns.ElementAt(col_Value), tdbg.GetSelectedRowHandles().First() + 1);
                tdbg.SetCellValue(tdbg.GetSelectedRowHandles().First(), tdbg.Columns.ElementAt(COL_OrderNum), tdbg.GetSelectedRowHandles().First() + 1);
            }
        }

        protected static string xmlPath = L3.ApplicationPath + @"\D45D0180.D45X0002.xml";
        public static void WriteXML(DataTable _dt)
        {
            DataSet ds = new DataSet();
            DataTable dt = _dt.Copy();
            ds.Tables.Add(dt);
            //if (xmlPath == "")
            //    xmlPath = L3.ApplicationPath + @"\D45D0180.D45X0002.xml";
            using (StreamWriter fs = new StreamWriter(xmlPath))
            {
                ds.WriteXml(fs, XmlWriteMode.WriteSchema);
            }
        }

        public static DataTable ReadXML()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                ds.ReadXml(xmlPath, XmlReadMode.ReadSchema);
                dt = ds.Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                L3Msg.MyMsg(ex.Message + Environment.NewLine + ex.StackTrace);
                return dt;
            }
        }

        #region "Export Excel"
        protected const string FieldName = "FieldName";
        protected const string Format = "Format";
        protected const string MergeRelative = "MergeRelative";
        protected const string IsMerge = "IsMerge";
        protected const string FooterText = "FooterText";
        protected const string DataWidth = "DataWidth";
        protected const string IsExport = "IsExport";
        protected const string IsDateTime = "IsDateTime";
        protected const string IsSum = "IsSum";
        protected const string Grouped = "Grouped";
        protected const string Obligatory = "Obligatory";
        protected const string NumberFormat = "NumberFormat";
        protected const string IsUnicode = "IsUnicode";
        protected const string IsUsed = "IsUsed";
        protected const string DataType = "DataType";
        protected const string OrderNo = "OrderNo";
        protected const string OrderNum = "OrderNum";
        protected const string Description = "Description";

        protected static DataTable CreateTableForExportExcel()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(OrderNo, typeof(System.Int32));
            dt.Columns.Add(Description, typeof(System.String));
            dt.Columns.Add(IsUsed, typeof(System.Boolean));
            dt.Columns.Add(IsUnicode, typeof(System.Boolean));
            dt.Columns.Add(NumberFormat, typeof(System.Byte));
            dt.Columns.Add(DataType, typeof(System.String));
            dt.Columns.Add(FieldName, typeof(System.String));
            dt.Columns.Add(Grouped, typeof(System.Byte));
            dt.Columns.Add(IsSum, typeof(System.Byte));
            dt.Columns.Add(IsDateTime, typeof(System.Byte));
            dt.Columns.Add(IsExport, typeof(System.Byte));
            dt.Columns.Add(FooterText, typeof(System.Object));
            dt.Columns.Add(IsMerge, typeof(System.Byte));
            dt.Columns.Add(MergeRelative, typeof(System.String));
            dt.Columns.Add(Format, typeof(System.String));
            dt.Columns.Add(OrderNum, typeof(System.Int32));
            dt.Columns.Add(Obligatory, typeof(System.Byte));
            dt.Columns.Add(DataWidth, typeof(System.Int32));
            return dt;
        }

        /// <summary>
        /// Export excel with dynamic columns 
        /// </summary>
        public static DataTable CreateTableForExcelOnly(GridControl devGrid)
        {
            DataTable dtExcel = CreateTableForExportExcel();
            int i = 0;
            DataRow dtRow;
            string sDataType;
            foreach (GridColumn column in devGrid.Columns)
            {

                if (!column.Visible) continue;
                i += 1;
                dtRow = dtExcel.NewRow();
                dtRow[FieldName] = column.FieldName;
                dtRow[Description] = column.Header;
                dtRow[OrderNum] = i;
                dtRow[OrderNo] = 0;
                sDataType = column.FieldType.Name;
                dtRow[DataType] = sDataType;
                dtRow[NumberFormat] = 0;
                dtRow[Format] = "";
                dtRow[IsDateTime] = 0;
                sDataType = sDataType.ToLower();
                if (sDataType.Contains("int") || sDataType == "byte")
                {
                    dtRow[DataType] = "N2";
                }
                else if (sDataType == "decimal" || sDataType == "double" || sDataType == "single")
                {
                    dtRow[DataType] = "N";
                    if (sDataType == "decimal")
                    {
                        string sFormat = column.EditSettings.DisplayFormat;
                        //TextEditSettings textEdit = (TextEditSettings)column.EditSettings;
                        //string sFormat = L3ConvertType.L3String(textEdit.Mask);

                        if (sFormat != null && !string.IsNullOrEmpty(sFormat))
                        {
                            if (sFormat.Contains("%") & sFormat.Contains("."))
                            {
                                dtRow[DataType] = "0." + sFormat.Split('.')[1];
                            }
                            else if (sFormat.ToLower().Contains("p"))
                            {
                                dtRow[DataType] = "Percent";
                            }
                            else if (sFormat.Contains("."))
                            {
                                string[] arr = sFormat.Split(Convert.ToChar("."));
                                dtRow[NumberFormat] = arr[arr.Length - 1].Length;
                            }
                            else if (sFormat.ToLower().Contains("n"))
                            {
                                dtRow[NumberFormat] = sFormat.Substring(4, 1);
                            }
                        }
                    }
                }
                else if (sDataType == "datetime")
                {
                    dtRow[DataType] = "D";
                    dtRow[IsDateTime] = 0;
                    if (column.EditSettings.DisplayFormat.StartsWith("HH:ss")) dtRow[IsDateTime] = 2;
                    dtRow[Format] = column.EditSettings.DisplayFormat;
                }
                else
                {
                    dtRow[DataType] = "S";
                }
                dtRow[NumberFormat] = L3ConvertType.L3String(dtRow[NumberFormat]).ToUpper();
                dtRow[IsUsed] = 1;
                dtRow[IsUnicode] = 0;
                dtRow[IsSum] = 0;
                if (column.HasTotalSummaries)
                {
                    if (column.TotalSummaries[0].Item.SummaryType != DevExpress.Data.SummaryItemType.Count)
                    {
                        dtRow[IsSum] = 1;
                    }
                }
                dtRow[Obligatory] = false;
                dtRow[Grouped] = 0;
                dtRow[IsExport] = 0;
                dtRow[DataWidth] = 0;
                dtRow[FooterText] = column.TotalSummaryText;
                dtRow[IsMerge] = 0;
                dtRow[MergeRelative] = 0;
                dtExcel.Rows.Add(dtRow);
            }
            return dtExcel;
        }
        #endregion
        private bool CheckValidPeriodFromTo(L3LookUpEdit tdbcPeriodFrom, L3LookUpEdit tdbcPeriodTo)
        {
            int iFrom = 0;
            int iTo = 0;
            iFrom = L3ConvertType.L3Int(tdbcPeriodFrom.ReturnValue("TranYear")) * 100 + L3ConvertType.L3Int(tdbcPeriodFrom.ReturnValue("TranMonth"));
            iTo = L3ConvertType.L3Int(tdbcPeriodTo.ReturnValue("TranYear")) * 100 + L3ConvertType.L3Int(tdbcPeriodTo.ReturnValue("TranMonth"));
            if (iFrom > iTo)
            {
                D99D0041.D99C0008.MsgL3(L3Resource.rL3("MSG000014"));
                tdbcPeriodTo.Focus();
                return false;
            }
            return true;
        }

        // #---------------------------------------------------------------------------------------------------
        // # Title: SQLStoreD45P5555
        // # Created User: 
        // # Created Date: 24/07/2019 02:04:03
        // #---------------------------------------------------------------------------------------------------
        public static string SQLStoreD45P5555(int mode, string FormID, string Key01ID)
        {
            string sSQL = "";
            sSQL += ("-- Kiem tra truoc khi sua - xoa" + Environment.NewLine);
            sSQL += "Exec D45P5555 ";
            sSQL += L3SQLClient.SQLString(L3.DivisionID) + L3.COMMA; // DivisionID, varchar[20], NOT NULL
            sSQL += L3SQLClient.SQLNumber(L3.TranMonth) + L3.COMMA; // TranMonth, tinyint, NOT NULL
            sSQL += L3SQLClient.SQLNumber(L3.TranYear) + L3.COMMA; // TranYear, smallint, NOT NULL
            sSQL += L3SQLClient.SQLString(L3.STRLanguage) + L3.COMMA; // Language, varchar[20], NOT NULL
            sSQL += L3SQLClient.SQLString(L3.UserID) + L3.COMMA; // UserID, varchar[20], NOT NULL
            sSQL += L3SQLClient.SQLString(Environment.MachineName) + L3.COMMA; // HostID, varchar[20], NOT NULL
            sSQL += L3SQLClient.SQLNumber(mode) + L3.COMMA; // Mode, int, NOT NULL
            sSQL += L3SQLClient.SQLString(FormID) + L3.COMMA; // FormID, varchar[20], NOT NULL
            sSQL += L3SQLClient.SQLString(Key01ID) + L3.COMMA; // Key01ID, varchar[20], NOT NULL
            sSQL += L3SQLClient.SQLString("") + L3.COMMA; // Key02ID, varchar[20], NOT NULL
            sSQL += L3SQLClient.SQLString("") + L3.COMMA; // Key03ID, varchar[20], NOT NULL
            sSQL += L3SQLClient.SQLString("") + L3.COMMA; // Key04ID, varchar[20], NOT NULL
            sSQL += L3SQLClient.SQLString("") + L3.COMMA; // Key05ID, varchar[20], NOT NULL
            sSQL += L3SQLClient.SQLNumber(0); // Num01, int, NOT NULL
            return sSQL;
        }
        /// <summary>
        /// Nếu store trả ra Status <> 0 thì xuất Message theo dạng FontMessage
        /// Nếu store trả ra MsgAsk = 0 thì xuất Message nút Ok,  MsgAsk = 1 thì xuất Message nút Yes, No
        /// </summary>
        /// <param name="SQL"></param>
        /// <param name="sStatus"></param>
        /// <returns></returns>
        public static bool CheckMyStore(string SQL, ref bool bEdit)
        {
            DataTable dt = new DataTable();
            string sMsg;
            bool bMsgAsk = false;
            dt = L3SQLServer.ReturnDataTable(SQL);
            if (dt.Rows.Count > 0)
            {
                if (dt.AsEnumerable().ToArray()[0]["Status"].ToString() == "0")
                {
                    bEdit = true;
                    dt = null/* TODO Change to default(_) if this is not a reference type */;
                    return true;
                }
                sMsg = dt.AsEnumerable().ToArray()[0]["Message"].ToString();
                //bool bFontMessage = false;
                //if (dt.Columns.Contains("FontMessage"))
                //    bFontMessage = true;
                if (dt.Columns.Contains("MsgAsk"))
                {
                    if (L3ConvertType.L3Byte(dt.AsEnumerable().ToList()[0]["MsgAsk"]) == 1)
                        bMsgAsk = true;
                }

                if (bMsgAsk) //YesNo
                {
                    if (D99D0041.D99C0008.MsgAsk(sMsg, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        bEdit = false;
                        return true;
                    }
                    else
                    {
                        bEdit = false;
                        return false;
                    }
                }
                else //OKOnly
                {
                    D99D0041.D99C0008.MsgL3(sMsg, D99D0041.L3MessageBoxIcon.Exclamation);
                    bEdit = false;
                    return false;
                }
            }
            else
            {
                D99D0041.D99C0008.MsgL3("Không có dòng nào trả ra từ Store");
                bEdit = false;
                return false;
            }
        }
    }
}
