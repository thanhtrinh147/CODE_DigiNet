   M S B A M L   `   `   `  ���� D  @D99D0451, Version=4.10.0.0, Culture=neutral, PublicKeyToken=nullQ6clr-namespace:Lemon3.Controls.DevExp;assembly=D99D0451Lemon3.Controls.DevExp   D49D2150   D49D2150.D49F2131   =L36clr-namespace:Lemon3.Controls.DevExp;assembly=D99D0451  W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  f bDevExpress.Xpf.Grid.v17.1.Core, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa ]DevExpress.Xpf.Grid.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  d	 `DevExpress.Xpf.Docking.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a@dxdo5http://schemas.devexpress.com/winfx/2008/xaml/docking 	 -     � Title$5  /D49D2131 - Cập nhật Kế hoạch thu tiền��$	��680��$
��1024�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � 	Resources  �� MergedDictionaries �� Source��  �� $9 3/D49D2150;component/Templates/ControlTemplates.xaml?��� $8 2/D99D0451;component/Templates/Lemon3Templates.xaml?��� $1 +/D99D0451;component/Styles/Lemon3Style.xaml?�%    .���  � RowDefinitions �� $��70 ��� �� $��35 �.+�'   !Lemon3.Controls.DevExp.L3GroupBox  $��0��$��5,0,5,0q�$��Stretch=�$��Stretch=����� -    ��Name$ grpCon��$
��Bold"�Điều kiện lọc.���  � ColumnDefinitions �� $
��auto ��� �� $
��auto ��� �� $
��auto ��� $��* ��� $
��auto ��� $
��auto ��� $
��auto �.+�$   Lemon3.Controls.DevExp.L3Label  -   	  Name$	 lblProjectName��$��Dự án��$��Center=�$��Center=�$��0��$��	10,0,10,0q�)   #Lemon3.Controls.DevExp.L3LookUpEdit  -   
  Name$
 tdbcProjectID��$��1��$��Stretch=�$��Center=�+  %DevExpress.Xpf.Grid.LookUp.LookUpEdit   AutoPopulateColumns .  +  %DevExpress.Xpf.Editors.LookUpEditBase   AutoComplete .    ImmediatePopup . *  $DevExpress.Xpf.Editors.PopupBaseEdit   
PopupWidth$	 350Q�   DisplayMember$ ProjectName��   ValueMember$ 	ProjectID��   ProjectIDTemplate   PopupContentTemplate# �   )  #DevExpress.Xpf.Editors.TextEditBase"   VerticalScrollBarVisibility$ Disabled=�  -   $	 lblContractNo��$��Số hợp đồng��$��Center=�$��Center=�$��2��$��	10,0,10,0q�  -   $
 tdbcContractNo��$��3��$��Stretch=�$��Center=� .   .  . $	 350Q�$ 
ContractNo��$ 
ContractID��  ContractIDTemplate# �    -   $	 lblObjectID��$��Khách hàng��$��Center=�$��Center=�$��4��$��	10,0,10,0q�  -   $
 tdbcObjectID��$��5��$��Stretch=�$��Center=� .   .  . $	 350Q�$ 
ObjectName��$ ObjectID��  ObjectIDTemplate# �  +   %Lemon3.Controls.DevExp.L3SimpleButton  -	     Name$ 	btnFilter��$��Lọc��$��10��$��Stretch=�$��Center=�$��27��$
��auto��$��5,0,5,0q�  -
   $ btnEdit��$��Sửa��$��10��$��Stretch=�$��Center=�$��27��$
��auto��$��5,0,5,0q�$y�Hidden=�'	   !Lemon3.Controls.DevExp.L3CheckBox	  -    	 Name$ chkIsByContract��$%��Cập nhật theo hợp đồng��$
��Left=�$��Center=�$��6��$��	10,0,10,0q� d� 	IsChecked$
 TrueY�	  -   $ chkIsRoundMonth��$��Làm tròn tháng��$
��Left=�$��Center=�$��7��$��	10,0,10,0q�$
 TrueY�*
   $Lemon3.Controls.DevExp.L3GridControl
  -    
 Name$
 tdbg��$��1��$��5,5,5,5q�)  #DevExpress.Xpf.Grid.DataControlBase   AutoGenerateColumns$
 None=�#   EnableSmartColumnsGeneration . $��Visible=�%  DevExpress.Xpf.Grid.GridControl   View #  DevExpress.Xpf.Grid.TableView  -     Name$ tdbgView��   AllowPerPixelScrolling . &   DevExpress.Xpf.Grid.DataViewBase   ShowTotalSummary .     ShowFilterPanelMode$ Never=�   ShowAutoFilterRow .     NewItemRowPosition$ Bottom=�    AllowColumnMoving  .  !   AllowEditing! . "   	AutoWidth" .  &   DevExpress.Xpf.Grid.GridViewBase#   ShowGroupPanel# .  $   Columns.$ $  DevExpress.Xpf.Grid.GridColumn  -   %  Name$% COL_TransID��$  DevExpress.Xpf.Grid.ColumnBase&   	FieldName$& TransID��$  DevExpress.Xpf.Grid.BaseColumn'   Header)  #DevExpress.Xpf.Core.ObjectConverter$'   '(    HorizontalHeaderContentAlignment$( Center=�)   Width2  ,DevExpress.Xpf.Grid.GridColumnWidthConverter$) 50 *   Visible* .    -   $% COL_TranMonth��$& 	TranMonth��$'   $( Center=�$	) 170 * .    -   $% COL_TranYear��$& TranYear��$'   $( Center=�$) 10 * .    -   $% COL_CreateUserID��$& CreateUserID��$'   $( Center=�$	) 170 * .    -   $% COL_CreateDate��$& 
CreateDate��$'   $( Center=�$) 10 * .    -   $% COL_LastModifyUserID��$& LastModifyUserID��$'   $( Center=�$	) 170 * .    -   $% COL_LastModifyDate��$& LastModifyDate��$'   $( Center=�$) 50 * .    -   $% COL_ContractID��$& 
ContractID��$'   $( Center=�$	) 170 * .    -   $% COL_ServiceTypeID��$& ServiceTypeID��$'   $( Center=�$) 10 * .    -   $% COL_CurrencyID��$& 
CurrencyID��$'   $( Center=�$	) 170 * .    -   $% COL_ExchageRate��$& ExchageRate��$'   $( Center=�$) 10 * .    -   $% COL_ConversionFactor��$& ConversionFactor��$'   $( Center=�$	) 170 * .    -   $% COL_IsSelected��$& 
IsSelected��$' Chọn $( Center=�$) 50 * .  +   VisibleIndex$+ 0��,   Fixed$
, Left=�-   EditSettings- 7  1DevExpress.Xpf.Editors.Settings.CheckEditSettings    -   $% COL_PeriodID��$& PeriodID��$
' Kỳ $( Center=�$) 80   -   $% COL_ProjectID��$& 	ProjectID��$' Dự án $( Center=�$	) 110 * .    -   $% COL_ProjectName��$& ProjectName��$' Tên dự án $( Center=�$	) 140 * .    -   $% COL_ContractNo��$& 
ContractNo��$' Số hợp đồng $( Center=�$	) 110 * .    -    $% COL_ObjectID��$& ObjectID��$' Khách hàng $( Center=�$	) 110 * .    -!   $% COL_ObjectName��$& 
ObjectName��$' Tên khách hàng $( Center=�$	) 140 * .    -"   $% COL_ProductID��$& 	ProductID��$' Mã dịch vụ $( Center=�$	) 110 - 1   +Lemon3.Controls.DevExp.L3LookUpEditSettings  -#   .  Name$. tdbdProductID��6  0DevExpress.Xpf.Editors.Settings.BaseEditSettings!/   HorizontalContentAlignment$
/ Left=�<  6DevExpress.Xpf.Editors.Settings.LookUpEditSettingsBase0   AutoComplete0 . 3  -DevExpress.Xpf.Grid.LookUp.LookUpEditSettings1   AutoPopulateColumns1 .  2   ImmediatePopup2 . ;  5DevExpress.Xpf.Editors.Settings.PopupBaseEditSettings3   
PopupWidth$	3 320Q�4   DisplayMember$4 	ProductID��5   ValueMember$5 	ProductID��  ProductIDTemplate6   PopupContentTemplate#6 �    -$   $% COL_ProductName��$& ProductName��$' Tên dịch vụ $( Center=�$	) 140 7   ReadOnly7 .   -%   $% COL_ServiceTypeName��$& ServiceTypeName��$' Loại dịch vụ $( Center=�$	) 110   -&   $% 
COL_UnitID��$& UnitID��$
' ĐVT $( Center=�$) 80 -   -'   $. 
tdbdUnitID��1 .  0 . $	3 350Q�2 . $4 UnitID��$5 UnitID��6 �� .R�
  $��PART_GridControl��-(   $   $& 	ProductID��$	' Mã $	) 100 $( Center=�8   AutoFilterCriteria$8 ContainsX�* .    $& ProductName��$
' Tên $	) 240 $( Center=�$8 ContainsX�* .    $& UnitID��$
' ĐVT $	) 240 $( Center=�$8 ContainsX�  $& ConversionFactor��$' ConversionFactor $	) 240 $( Center=�$8 ContainsX�* .     " . 9   ShowVerticalLines9 . :   ShowHorizontalLines: .  . $ Never=�  -)   $% COL_OQuantity��$& 	OQuantity��$' Số lượng $( Center=�$	) 110   -*   $% COL_UnitPrice��$& 	UnitPrice��$' 
Đơn giá $( Center=�$	) 110   -+   $% COL_OAmount��$& OAmount��$' Thành tiền $( Center=�$	) 110   -,   $% COL_VATGroupID��$& 
VATGroupID��$' Nhóm thuế $( Center=�$	) 110 -   --   $. tdbdVATGroupID��$
/ Left=�0 . 1 .  2 . $	3 320Q�$4 ID��$5 ID��  VATGroupIDTemplate#6 �    -.   $% COL_VATRate��$& VATRate��$' 	Tỷ lệ $( Center=�$	) 110   -/   $% COL_VATOAmount��$& 
VATOAmount��$' Thuế $( Center=�$	) 110   -0   $% COL_TotalOAmount��$& TotalOAmount��$' TT sau thuế $( Center=�$	) 110   -1   $% COL_FromDate��$& FromDate��$' 
Từ ngày $( Center=�$	) 110   -2   $% 
COL_ToDate��$& ToDate��$' Đến ngày $( Center=�$	) 110   -3   $% COL_Note��$
& Note��$' Ghi chú $( Center=�$	) 170   -4   $% COL_IsDetailInvoice��$& IsDetailInvoice��$"' Xuất hóa đơn chi tiết $( Center=�$	) 140 -     -5   $% COL_DetailInvoice��$&  ��$' Chi tiết hóa đơn $( Center=�$	) 110 * .  ;   CellTemplate; �� .R�'  !DevExpress.Xpf.Editors.ButtonEdit  <   ShowText< .  =   AllowDefaultButton$= FalseX�%  DevExpress.Xpf.Editors.BaseEdit>   
ShowBorder> .  ?   Buttons.? '  !DevExpress.Xpf.Editors.ButtonInfo  @  Name$@ btnInvoiceDetail��-6   A   Content$A 
Chi tiết B � ToolTip$B 
Chi tiết��C �� 	IsEnabledC �� D �� Path$!D RowData.Row.IsDetailInvoice�  -7   $% 
COL_Attack��E   AllowAutoFilterE .  $' Đính kèm $) 80 $( Center=�* .  ; �� .R�  < .  $= FalseX�> .  .?   $@ 	btnAttack��-8   $A Đính kèm $B Đính kèm��� $��2��$��5,0,5,5q�.+��  �� �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+�  -9   $��btnExportBeforeRevenue��$��1��$��Trích trước doanh thu��$��Right=�$��Center=�$��0,0,5,0q�$
��auto��$��27��{�.    -:   $��btnPaymentRequest��$��2��$��Đề nghị thanh toán��$��Right=�$��Center=�$��0,0,5,0q�$
��auto��$��27��{�.    -;   $��btnSave��$��3��$
��Lưu��$��Right=�$��Center=�$��0,0,5,0q�$��80��$��27��  -<   $��btnNext��$��4��$��Nhập tiếp��$��Right=�$��Center=�$��0,0,0,0q�$
��auto��$��27��