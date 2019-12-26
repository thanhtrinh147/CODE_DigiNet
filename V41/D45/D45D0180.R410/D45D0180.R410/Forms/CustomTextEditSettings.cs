using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Editors.Settings;
using DevExpress.Xpf.Grid;
using Lemon3.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace D45D0180.Forms
{
    class CustomTextEditSettings : TextEditSettings
    {
        // override te
        private bool sign = false;
        private bool bIsCheckID = false;
        private int iLengthCheckID = 0;
        private bool bFormulaCheckID = false;

        private string sNumberFormat;
        private GridControl devGrid;
        private bool ShowZero;
        private TableView tbl;
        private DevExpress.Xpf.Editors.TextEdit text;
        public CustomTextEditSettings(GridControl devGrid, string sNumberFormat, bool sign, bool ShowZero)
        {
            this.devGrid = devGrid;
            this.sNumberFormat = sNumberFormat;
            this.sign = sign;
            this.ShowZero = ShowZero;
            tbl = (TableView)devGrid.View;
        }
       
        public CustomTextEditSettings(GridColumn col, bool isCheckID, int iLength, bool bFormula)
        {
            if (!isCheckID) return;
            this.bIsCheckID = isCheckID;
            this.iLengthCheckID = iLength;
            this.bFormulaCheckID = bFormula;
            this.CreateEditor();
        }

        int iShowMSG = 0;
        void editor_KeyDown(object sender, KeyEventArgs e)
        {
            TextEdit textEdit = sender as TextEdit;
            if (e.Key != Key.LeftAlt && e.Key != Key.RightAlt) return;
            if (e.Key == Key.N)
            {
                textEdit.Tag = textEdit.Tag.ToString() + "; true";
            }
        }
        void editor_Validate(object sender, DevExpress.Xpf.Editors.ValidationEventArgs e)
        {
            DevExpress.Xpf.Editors.TextEdit textEdit = sender as DevExpress.Xpf.Editors.TextEdit;

            if (textEdit.IsReadOnly || textEdit.IsEnabled == false)
                return;
            if (L3ConvertType.L3String(e.Value) == "")
                return;
            textEdit.Text = ReplaceCharactorEnter(textEdit.Text);
            int posFrom = 0;
            if (L3ConvertType.L3Bool(textEdit.Tag) == false)
            {
                posFrom = IndexIdCharactor(e.Value.ToString());
            }
            else
            {
                posFrom = IndexFormulaCharactor(textEdit.Text);
            }
            int posTo = 1;
            switch (posFrom)
            {
                case -1:
                    //thá»a Ä‘iá»u kiá»‡n
                    break;
                case -2:
                    //VÆ°á»£t chiá»u dÃ i
                    break;
                default:
                    //vi pháº¡m
                    // Set thuá»™c tÃ­nh e.IsValid thÃ¬ Sá»± kiá»‡n bá»‹ callback => fix 2 láº§n thÃ´ng bÃ¡o
                    iShowMSG++;
                    if (iShowMSG == 1)
                    {
                        D99D0041.D99C0008.MsgL3(Lemon3.Resources.L3Resource.rL3("Ma_co_ky_tu_khong_hop_le"));
                    }
                    textEdit.Focus();
                    e.IsValid = false;
                    textEdit.Select(posFrom, posTo);
                    break;
            }
            if (iShowMSG > 1)
            {
                iShowMSG = 0;
            }
        }

        private string ReplaceCharactorEnter(string sInput)
        {
            string result = null;
            result = Regex.Replace(sInput, "\\s+", "");             //replace khoáº£ng tráº¯ng thÃ nh rá»—ng
            result = Regex.Replace(result, "\\r\\n", "");             //replace kÃ½ tá»± xuá»‘ng hÃ ng thÃ nh rá»—ng
            int unicode = 10;
            char character = (char)unicode;
            string text = character.ToString();
            result = Regex.Replace(result, text, "");             //replace kÃ½ tá»± xuá»‘ng hÃ ng thÃ nh rá»—ng
            return result;
        }
        private int IndexIdCharactor(string str)
        {
            //  If str.Length > iLength Then Return -2 'vÆ°á»£t chiá»u dÃ i
            //BackSpace: 8
            int iNum = 0;
            foreach (char c in str)
            {
                iNum = (int)c;
                if (iNum == 10 || iNum == 13 || iNum < 33 || iNum > 127 || iNum == 37 || iNum == 39 || iNum == 91 || iNum == 93 || iNum == 94)
                    return str.IndexOf(c);
            }
            return -1;
        }
        private int IndexFormulaCharactor(string str)
        {
            //  If str.Length > iLength Then Return -2 'vÆ°á»£t chiá»u dÃ i
            //BackSpace: 8
            int iNum = 0;
            foreach (char c in str)
            {
                iNum = (int)Char.GetNumericValue(c);
                if (iNum < 33 || iNum > 127 || iNum == 94)
                    return str.IndexOf(c);
            }
            return -1;
        }





        public override DevExpress.Xpf.Editors.IBaseEdit CreateEditor(bool assignEditorSettings, IDefaultEditorViewInfo defaultViewInfo,
            DevExpress.Xpf.Editors.Helpers.EditorOptimizationMode optimizationMode)
        {
            var editor = base.CreateEditor(assignEditorSettings, defaultViewInfo, optimizationMode);
            if (editor is DevExpress.Xpf.Editors.TextEdit)
            {
                if (bIsCheckID)
                {
                    var textEdit = editor as DevExpress.Xpf.Editors.TextEdit;
                    textEdit.CharacterCasing = System.Windows.Controls.CharacterCasing.Upper;
                    textEdit.MaxLength = iLengthCheckID;
                    textEdit.Tag = bFormulaCheckID.ToString();
                    textEdit.ValidateOnTextInput = false;
                    textEdit.KeyDown += editor_KeyDown;
                    textEdit.Validate += editor_Validate;
                }
                else
                {
                    ((DevExpress.Xpf.Editors.TextEdit)editor).MaskType = DevExpress.Xpf.Editors.MaskType.RegEx;
                    ((DevExpress.Xpf.Editors.TextEdit)editor).Mask = "\\d+";
                    ((DevExpress.Xpf.Editors.TextEdit)editor).AllowNullInput = !ShowZero;
                    //              
                    ((DevExpress.Xpf.Editors.TextEdit)editor).EditValueChanging += EditValueChanged;
                }
            }
            return editor;
        }

        public bool IsNumber(string pText)
        {
            if (sign)
            {
                var regex = new Regex("-");
                return regex.IsMatch(pText);
            }
            else
            {
                return false;
            }
        }


        private void textEditSettings_KeyDown(object sender, KeyEventArgs e)
        {
            var text = sender as DevExpress.Xpf.Editors.TextEdit;
            var displayText = text.DisplayText;
            if (sign)
                if (e.Key == Key.Subtract)
                    text.EditValue = displayText;
        }

        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);
            MaskType = DevExpress.Xpf.Editors.MaskType.RegEx;
            Mask = "\\d+";
        }

        private void EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangingEventArgs e)
        {
            text = (DevExpress.Xpf.Editors.TextEdit)sender;
            var s = e.OldValue;
            if (e.NewValue != null && e.NewValue.ToString() != "")
            {
                var check = IsNumber(e.NewValue.ToString());
                if (check)
                {
                    e.Handled = true;
                    e.IsCancel = true;

                    // e.NewValue =  e.NewValue.ToString().Replace('-', '');
                }
                else
                {
                    text.MaskType = DevExpress.Xpf.Editors.MaskType.Numeric;
                    text.Mask = "n2";
                }
            }
        }
    }
}
