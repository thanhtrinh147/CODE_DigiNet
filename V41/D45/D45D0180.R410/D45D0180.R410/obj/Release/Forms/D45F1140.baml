   M S B A M L   `   `   `  ���� D  @D99D0451, Version=4.10.0.0, Culture=neutral, PublicKeyToken=nullQ6clr-namespace:Lemon3.Controls.DevExp;assembly=D99D0451Lemon3.Controls.DevExp   D45D0180   D45D0180.D45F1140   =L36clr-namespace:Lemon3.Controls.DevExp;assembly=D99D0451  W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  f bDevExpress.Xpf.Grid.v17.1.Core, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa ]DevExpress.Xpf.Grid.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  @dxdo5http://schemas.devexpress.com/winfx/2008/xaml/docking  -     N� Title$+  %Khai báo sàn giao dịch - D27F1640��$	��680��$
��1024�� � 	Resources  �� MergedDictionaries �� Source��  �� $9 3/D45D0180;component/Templates/ControlTemplates.xaml?��� $8 2/D99D0451;component/Templates/Lemon3Templates.xaml?�%    .���  � RowDefinitions �� $��30 ��� �� $��30 �.+�)  #DevExpress.Xpf.Bars.MainMenuControl  -     Name$ MainMenuControl1��$��2��,  &DevExpress.Xpf.Bars.ToolBarControlBase   Items. '  !DevExpress.Xpf.Bars.BarButtonItem  -     Name$ tsbAdd��!  DevExpress.Xpf.Bars.BarItem   Content)  #DevExpress.Xpf.Core.ObjectConverter$ Thêm   -   $ tsbEdit��$ Sửa   -   $ 	tsbDelete��$
 Xóa *  $DevExpress.Xpf.Bars.BarItemSeparator    -   $ 
tsbListAll��$ Liệt kê tất cả     -   $ 
tsbSysInfo��$ Thông tin hệ thống � $��1��	 � ColumnDefinitions	 �� $��5* ��� $��5* �.+�*   $Lemon3.Controls.DevExp.L3GridControl  -   
  Name$

 tdbg��$��0��)  #DevExpress.Xpf.Grid.DataControlBase   AutoGenerateColumns$
 None=�   SelectionMode$	 Row=�#   EnableSmartColumnsGeneration . $��Visible=� � ContextMenu �� -	   $��ContextMenu1��.@�m� -
   $��mnsAdd��$��Thêm��m� -   $��mnsEdit��$��Sửa��m� -   $��	mnsDelete��$
��Xóa���� m� -   $��
mnsListAll��$��Liệt kê tất cả���� m� -   $��
mnsSysInfo��$��Thông tin hệ thống��%	  DevExpress.Xpf.Grid.GridControl 	  View #
  DevExpress.Xpf.Grid.TableView
  -    
 Name$ tdbgView�� 
  AllowPerPixelScrolling . &   DevExpress.Xpf.Grid.DataViewBase   ShowTotalSummary .     ShowFilterPanelMode$ Never=� 
  ShowAutoFilterRow . &   DevExpress.Xpf.Grid.GridViewBase   ShowGroupPanel .     AllowEditing .  
  	AutoWidth .   	  Columns. $  DevExpress.Xpf.Grid.GridColumn  -     Name$ COL_OrderNo��$  DevExpress.Xpf.Grid.ColumnBase   	FieldName$  ��$  DevExpress.Xpf.Grid.BaseColumn   Header$	 STT '    HorizontalHeaderContentAlignment$ Center=�   Width2  ,DevExpress.Xpf.Grid.GridColumnWidthConverter$ 50    MinWidth$ 50��  -   $ COL_CODE��$
 CODE��$ Mã loại điều kiện $ Center=�$	 110 $	 110��  -   $ COL_Name��$
 Name��$  Tên loại điều kiện $ Center=�$	 170 $	 170��  -   $ COL_ConditionID��$ ConditionID��$ Mã điều kiện $ Center=�$	 110   -   $ 	COL_NameT��$ NameT��$ 
Tên tắt $ Center=�$	 110 $	 110��  -   $ COL_Description��$ Description��$ Diễn giải $ Center=�$	 170   -   $ 	COL_Notes��$ Notes��$ Ghi chú $ Center=�$	 170   -   $ COL_Disabled��$ Disabled��$	 KSD $ Center=�$ 50    Fixed$ Right=�    EditSettings  7  1DevExpress.Xpf.Editors.Settings.CheckEditSettings    -   $ 	COL_CodeW��$ CodeW��$   $ Center=�$	 170 !   Visible! .    -   $ COL_CreateUserID��$ CreateUserID��$   $ Center=�$	 170 ! .    -   $ COL_CreateDate��$ 
CreateDate��$   $ Center=�$	 170 ! .    -   $ COL_LastModifyUserID��$ LastModifyUserID��$   $ Center=�$	 170 ! .    -   $ COL_LastModifyDate��$ LastModifyDate��$   $ Center=�$	 170 ! .  � $��0,4,0,-4q�$��1�� �� $	��250 ��� $��40 ��� .+�'   !Lemon3.Controls.DevExp.L3GroupBox  -   "  Name$" GroupDetail��$��Stretch=�$��Stretch=�$��5,0,5,0q����� -   # ��Name$# 	grpheader��$
��Bold"�
Chi tiết.��� -   $��GridD�� �� $��1* ��� $��1* ��� $��1* ��� $��1* ��� $��1* �	 �� $
��auto ��� $��1* ��� $��1* ��� $��1* ��� $��1* ��� $��1* ��� $��1* ��� $��1* ��� $��1* ��� $��1* ��� $��1* �.+�$   Lemon3.Controls.DevExp.L3Label  -    $  Name$$ lblConditionID��$��Mã điều kiện��$��0��$��1��$
��Left=�$��0,0,5,0q�$��Center=�  -!   $$ lblCode��$��Mã loại điều kiện��$��0��$��5��$��3��$
��Left=�$��10,0,0,0q�$��Center=�  -"   $$ lblDescription��$��Diễn giải��$��1��$��3��$
��Left=�$��0,0,0,0q�$��Center=�  -#   $$ lblNotes��$��Ghi chú��$��2��$��3��$
��Left=�$��0,0,0,0q�$��Center=�)   #Lemon3.Controls.DevExp.L3LookUpEdit  -$   %  Name$% tdbcCode��$��8��$��3��$��Stretch=�$��Center=�+  %DevExpress.Xpf.Grid.LookUp.LookUpEdit&   AutoPopulateColumns& .  +  %DevExpress.Xpf.Editors.LookUpEditBase'   AutoComplete' . (   ImmediatePopup( . *  $DevExpress.Xpf.Editors.PopupBaseEdit)   
PopupWidth$	) 350Q�%  DevExpress.Xpf.Editors.BaseEdit*   
IsReadOnly* . +   DisplayMember$
+ Name��,   ValueMember$, CodeW��   tdbcCode-   PopupContentTemplate#- �   '   !Lemon3.Controls.DevExp.L3TextEdit  -%   $��txtConditionID��$��0��$��1��$��4��$��Stretch=�$��Center=�* .   -&   $��txtDescription��$��1��$��1��$��7��$��Stretch=�$��Center=�  -'   $��txtNotes��$��2��$��1��$��10��$��3��$��Stretch=�$��Stretch=�)  #DevExpress.Xpf.Editors.TextEditBase.   AcceptsReturn. . /   	MaxLength$	/ 500��0   TextWrapping$
0 Wrap=�1   PrintTextWrapping$
1 WrapX�$2   HorizontalScrollBarVisibility$
2 Auto=�"3   VerticalScrollBarVisibility$
3 Auto=�(   "Lemon3.Controls.DevExp.L3CheckEdit  -(   4  Name$4 chkDisabled��$��8��$��1��$��3��$��15,0,0,0q�$
��Left=�$��Center=�$��Normal"�&   DevExpress.Xpf.Editors.CheckEdit5   Content$5 Không sử dụng � $��1��.+�� 	 �� �� $
��auto ��� $
��auto ��� $
��auto �.+�+   %Lemon3.Controls.DevExp.L3SimpleButton  -)   $��btnSave��$��1��$
��Lưu��$��Right=�$��Center=�$��0,0,10,0q�$��80��$��27��{�.    -*   $��btnNext��$��2��$��Nhập tiếp��$��Right=�$��Center=�$��0,0,10,0q�$	��140��$��27��{�.    -+   $��
btnNotSave��$��3��$��Không lưu��$��Right=�$��Center=�$��0,0,10,0q�$	��120��$��27��{�.  � $��2��	 �� $��5* ��� $��5* �.+�'   !Lemon3.Controls.DevExp.L3CheckBox  -,   6  Name$6 chkViewDisable��$��10,0,0,0q�$
��Left=�$��Center=�$��Normal"�$*��$Hiển thị dữ liệu đã chọn��