   M S B A M L   `   `   `  ���� D  @D99D0451, Version=4.10.0.0, Culture=neutral, PublicKeyToken=nullQ6clr-namespace:Lemon3.Controls.DevExp;assembly=D99D0451Lemon3.Controls.DevExp   DA2D1050   DA2D1050.DA2F1010   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     EL36clr-namespace:Lemon3.Controls.DevExp;assembly=D99D0451     f bDevExpress.Xpf.Grid.v17.1.Core, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa ]DevExpress.Xpf.Grid.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  j	 fDevExpress.Xpf.LayoutControl.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol 	 ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  -     N� Title$G  ADanh mục các loại phí hỗ trợ bồi thường - DA2F1010��$	��680��$
��1024�� � 	Resources  �� MergedDictionaries �� Source��  �� $9 3/DA2D1050;component/Templates/ControlTemplates.xaml?��� $8 2/D99D0451;component/Templates/Lemon3Templates.xaml?�%    .���  � ColumnDefinitions �� $
��554* ��� $	��470 � � RowDefinitions �� $��20 ��� $
��660* �.+�)  #DevExpress.Xpf.Bars.MainMenuControl  -   $��MainMenuControl1��$��Stretch=�$��0��$��0��$��2��,  &DevExpress.Xpf.Bars.ToolBarControlBase   Items. '  !DevExpress.Xpf.Bars.BarButtonItem  -    �Name$ tsbAdd��!  DevExpress.Xpf.Bars.BarItem   Content)  #DevExpress.Xpf.Core.ObjectConverter$ Thêm   -   $ tsbEdit��$ Sửa   -   $ 	tsbDelete��$
 Xóa *  $DevExpress.Xpf.Bars.BarItemSeparator    -   $ 
tsbListAll��$ Liệt kê tất cả     -   $ 
tsbSysInfo��$ Thông tin hệ thống � $��1��$��1��$��
10,0,10,10q�.+�'   !Lemon3.Controls.DevExp.L3GroupBox  -   $
��grpD��$��Thông tin chi tiết��.��� -	   $��gridD��.+�$   Lemon3.Controls.DevExp.L3Label  -
   $��lblCostTypeID��$��Nhóm��$
��Left=�$��0,14,0,0q�$	��Top=�)	   #Lemon3.Controls.DevExp.L3LookUpEdit	  -   $��tdbcCostTypeID��*
  $DevExpress.Xpf.Editors.PopupBaseEdit	 
  
PopupWidth$		 350Q�+  %DevExpress.Xpf.Grid.LookUp.LookUpEdit
   AutoPopulateColumns
 .  $
��Left=�$��
92,14,-9,0q�$	��Top=�+  %DevExpress.Xpf.Editors.LookUpEditBase   ValueMember$ 
CostTypeID��   DisplayMember$ CostTypeName��$	��340��   
CostTypeID 
  PopupContentTemplate# �     -   $��	lblCostID��$	��Mã��$
��Left=�$��0,40,0,0q�$	��Top=�'   !Lemon3.Controls.DevExp.L3TextEdit  -   $��	txtCostID��$
��Left=�$��	92,40,0,0q�$	��Top=�$	��150��	  -   $��
tdbcUnitID��$		 350Q�
 .  $
��Left=�$��292,40,-9,0q�$	��Top=�$ UnitID��$ UnitID��$	��140��  UnitIDStadard# �    -   $��	lblUnitID��$
��ĐVT��$
��Left=�$��
251,40,0,0q�$	��Top=�  -   $��txtDescription��$
��Left=�$��
92,67,-9,0q�$	��Top=�$	��340��  -   $��lblDescription��$��Diễn giải��$
��Left=�$��0,70,0,0q�$	��Top=�	  -   $��tdbcAnaTypeID��$		 350Q�
 .  $
��Left=�$��	92,92,0,0q�$	��Top=�$��67��$ 	AnaTypeID��$ 	AnaTypeID��  AnaTypeIDStadard# �    -   $��lblAnaTypeID��$��Loại liên kết KM��$
��Left=�$��0,93,0,7q�$��89��	  -   $��	tdbcAnaID��$		 350Q�
 .  $
��Left=�$��166,93,-9,0q�$	��Top=�$	��266��$ AnaID��$ AnaID��  AnaIDStadard# �  +   %Lemon3.Controls.DevExp.L3SimpleButton  -     Name$ btnSave��$��_Lưu��$
��Left=�$��27��$��105,166,0,0q�$	��Top=�$��78��  -   $ btnNext��$��Lưu và nhập _tiếp��$
��Left=�$��27��$��188,166,0,0q�$	��Top=�$	��142��  -   $ 
btnNotSave��$��_Không lưu��$
��Left=�$��27��$��335,166,0,0q�$	��Top=�$	��107��*   $Lemon3.Controls.DevExp.L3GridControl  -     Name$
 tdbg��$��0��$��1��)  #DevExpress.Xpf.Grid.DataControlBase   SelectionMode$	 Row=�   AutoGenerateColumns$ AddNew=�#   EnableSmartColumnsGeneration .  � ContextMenu �� -   $��ContextMenu1��.@�m� -   $��mnsAdd��$��Thêm��m� -   $��mnsEdit��$��Sửa��m� -   $��	mnsDelete��$
��Xóa���� m� -   $��
mnsListAll��$��Liệt kê tất cả���� m� -   $��
mnsSysInfo��$��Thông tin hệ thống��%  DevExpress.Xpf.Grid.GridControl   View #  DevExpress.Xpf.Grid.TableView  -     Name$ tdbgTableView��&   DevExpress.Xpf.Grid.DataViewBase   ShowFilterPanelMode$ Never=�   AllowPerPixelScrolling .    ShowTotalSummary .     AllowEditing .     ShowAutoFilterRow .    Columns. $  DevExpress.Xpf.Grid.GridColumn  -      Name$ COL_CostTypeName��$  DevExpress.Xpf.Grid.ColumnBase   	FieldName$ CostTypeName��$  DevExpress.Xpf.Grid.BaseColumn   Header$ Nhóm    Width2  ,DevExpress.Xpf.Grid.GridColumnWidthConverter$	 130 '     HorizontalHeaderContentAlignment$  Center=�  -!   $ 
COL_CostID��$	 Mã $ CostID��$  Center=�$	 110   -"   $ COL_Description��$ Diễn giải $ Description��$  Center=�$	 170   -#   $ 
COL_UnitID��$ ĐVT (Mặc định) $ UnitID��$  Center=�$	 110   -$   $ COL_AnaTypeID��$ Loại khoản mục $ 	AnaTypeID��$  Center=�$	 110   -%   $ 	COL_AnaID��$ Khoản mục chi tiết $ AnaID��$  Center=�$	 140   -&   $ COL_CostTypeID��$ 
CostTypeID��!   Visible! .    -'   $ COL_CreateUserID��$ CreateUserID��! .    -(   $ COL_CreateDate��$ 
CreateDate��! .    -)   $ COL_LastModifyUserID��$ LastModifyUserID��! .    -*   $ COL_LastModifyDate��$ LastModifyDate��! .  