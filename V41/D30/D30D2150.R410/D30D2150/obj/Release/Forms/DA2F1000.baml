   M S B A M L   `   `   `  ���� D  @D99D0451, Version=4.10.0.0, Culture=neutral, PublicKeyToken=nullQ6clr-namespace:Lemon3.Controls.DevExp;assembly=D99D0451Lemon3.Controls.DevExp  D @DA2D1050, Version=4.10.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:DA2D1050DA2D1050    DA2D1050.DA2F1000   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     EL36clr-namespace:Lemon3.Controls.DevExp;assembly=D99D0451     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     f bDevExpress.Xpf.Grid.v17.1.Core, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa ]DevExpress.Xpf.Grid.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  "localclr-namespace:DA2D1050  -     N� Title$$  Danh mục dự án - DA2F1000��$	��680��$
��1024�� � 	Resources  �� MergedDictionaries �� Source��  �� $9 3/DA2D1050;component/Templates/ControlTemplates.xaml?��� $8 2/D99D0451;component/Templates/Lemon3Templates.xaml?�%    .���  � ColumnDefinitions �� $��1024* � � RowDefinitions �� $��30 ��� $
��240* ��� $
��380* ��� $��40 �.+�� -   $��gridMainMenuControl��$��0��$��0��.+�)  #DevExpress.Xpf.Bars.MainMenuControl  -   $��MainMenuControl1��$
��Left=�$��Center=�,  &DevExpress.Xpf.Bars.ToolBarControlBase   Items. '  !DevExpress.Xpf.Bars.BarButtonItem  -     Name$ tsbAdd��!  DevExpress.Xpf.Bars.BarItem   Content)  #DevExpress.Xpf.Core.ObjectConverter$ Thêm   -   $ tsbEdit��$ Sửa   -   $ 	tsbDelete��$
 Xóa *  $DevExpress.Xpf.Bars.BarItemSeparator    -   $ tsbExportToExcel��$ Xuất excel     -   $ 
tsbSysInfo��$ Thông tin hệ thống *   $Lemon3.Controls.DevExp.L3GridControl  -	   	  Name$
	 tdbg��$��0��$��1��)  #DevExpress.Xpf.Grid.DataControlBase
   AutoGenerateColumns$

 None=�#   EnableSmartColumnsGeneration .  � ContextMenu �� -
   $��ContextMenu1��.@�m� -   $��mnsAdd��$��Thêm��m� -   $��mnsEdit��$��Sửa��m� -   $��	mnsDelete��$
��Xóa��m� -   $��mnsExportToExcel��$��Xuất Excel��m� -   $��
mnsSysInfo��$��Thông tin hệ thống��%	  DevExpress.Xpf.Grid.GridControl 	  View #
  DevExpress.Xpf.Grid.TableView
  -   $��tdbgTableView�� 
  AllowPerPixelScrolling . &   DevExpress.Xpf.Grid.DataViewBase   ShowTotalSummary .  &   DevExpress.Xpf.Grid.GridViewBase   ShowGroupPanel .   
  ShowAutoFilterRow .  
  NewItemRowPosition$
 None=�   AllowEditing .   	  Columns. $  DevExpress.Xpf.Grid.GridColumn  -     Name$ COL_ProjectTypeName��$  DevExpress.Xpf.Grid.ColumnBase   	FieldName$ ProjectTypeName��$  DevExpress.Xpf.Grid.BaseColumn   Header$ Loại dự án    Width2  ,DevExpress.Xpf.Grid.GridColumnWidthConverter$
 170*    MinWidth$	 170��'    HorizontalHeaderContentAlignment$ Center=�  -   $ COL_ProjectID��$ 	ProjectID��$	 Mã $
 110* $	 110��$ Center=�  -   $ COL_ProjectName��$ ProjectName��$
 Tên $
 170* $	 170��$ Center=�  -   $ COL_StatusID��$ StatusID��$ Trạng thái $
 110* $	 110��$ Center=�  -   $ COL_ExecuteDateFrom��$ ExecuteDateFrom��$ Ngày bắt đầu $ 90 $ Center=�  -   $ COL_ExecuteDateTo��$ ExecuteDateTo��$ Ngày hoàn thành $ 90 $ Center=�  -   $ COL_ProAddress��$ 
ProAddress��$ Địa chỉ $
 170* $	 170��$ Center=�  -   $ COL_ProjectDate��$ ProjectDate��$ Ngày lập $ 90 $ Center=�  -   $ COL_DivisionID��$ 
DivisionID��   Visible .    -   $ COL_ProjectTypeID��$ ProjectTypeID�� .    -   $ COL_CreateUserID��$ CreateUserID�� .    -   $ COL_CreateDate��$ 
CreateDate�� .    -   $ COL_LastModifyUserID��$ LastModifyUserID�� .    -   $ COL_LastModifyDate��$ LastModifyDate�� .  &   DevExpress.Xpf.Core.DXTabControl  $��0��$��2��$��0,2,0,0q�.@�#  DevExpress.Xpf.Core.DXTabItem  -   $��tabItem1���  �DevExpress.Xpf.Core.Native.HeaderedSelectorItemBase`2[[DevExpress.Xpf.Core.DXTabControl, DevExpress.Xpf.Core.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a],[DevExpress.Xpf.Core.DXTabItem, DevExpress.Xpf.Core.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a]]   Header$ 1. Thông tin chính��.��� 
������ .+�$   Lemon3.Controls.DevExp.L3Label  -      Name$ lblProjectID��$	��Mã��$
��Left=�$��10,2,0,0q�$	��Top=�$��83��'   !Lemon3.Controls.DevExp.L3TextEdit  -!     Name$ txtProjectID��$
��Left=�$��98,2,0,0q�$	��Top=�)  #DevExpress.Xpf.Editors.TextEditBase   	MaxLength$ 50��$	��159��  -"   $ lblProjectName��$
��Tên��$
��Left=�$��	280,2,0,0q�$	��Top=�$	��103��  -#   $ txtProjectName��$
��Left=�$��	388,2,0,0q�$	��Top=�$	 250��$	��312��  -$   $ lblProjectTypeID��$��Loại dự án��$
��Left=�$��	717,2,0,0q�$	��Top=�$��63��)   #Lemon3.Controls.DevExp.L3LookUpEdit  -%      Name$  tdbcProjectTypeID��+  %DevExpress.Xpf.Grid.LookUp.LookUpEdit!   AutoPopulateColumns! .  $
��Left=�$��	785,2,0,0q�$	��Top=�$	��177��+  %DevExpress.Xpf.Editors.LookUpEditBase"   ImmediatePopup" . *  $DevExpress.Xpf.Editors.PopupBaseEdit#   
PopupWidth$	# 350Q�$   DisplayMember$$ ProjectTypeName��%   ValueMember$% ProjectTypeID��   ProjectTypeIDResource&   PopupContentTemplate#& �     -&   $ lblProjectDate��$��Ngày lập��$
��Left=�$��	10,29,0,0q�$	��Top=�$��83��'   !Lemon3.Controls.DevExp.L3DateEdit  -'   '  Name$' c1dateProjectDate��$
��Left=�$��	98,29,0,0q�$	��Top=�$	��159��  -(   $ lblProAddress��$��Địa chỉ��$
��Left=�$��
280,29,0,0q�$	��Top=�$	��103��  -)   $ txtProAddress��$
��Left=�$��
388,29,0,0q�$	��Top=�$	 500��$	��574��  -*   $ lblExecuteDateFrom��$��Ngày bắt đầu��$
��Left=�$��	10,56,0,0q�$	��Top=�$��83��  -+   $' c1dateExecuteDateFrom��$
��Left=�$��	98,56,0,0q�$	��Top=�$	��159��  -,   $ lblExecuteDateTo��$��Ngày hoàn thành��$
��Left=�$��
280,56,0,0q�$	��Top=�$	��103��  --   $' c1dateExecuteDateTo��$
��Left=�$��
388,56,0,0q�$	��Top=�$	��312��  -.   $ lblStatusID��$��Trạng thái��$
��Left=�$��
717,56,0,0q�$	��Top=�$��63��  -/   $  tdbcStatusID��! .  $
��Left=�$��
785,56,0,0q�$	��Top=�$	��177��" . $	# 350Q�$$ 
StatusName��$% StatusID��  StatusIDResource#& �  �� -0   $��grpProjectScale��$��Quy mô dự án��$��-9,83,-10,-5q�.��� .+�  -1   $	 tdbgProjectScale��$

 None=� .  
   .  .  .  ( 
  	AutoWidth( . .   -2   $ COLD1_OrderNo��$ OrderNo��$	 STT $ Center=�$ 50 )   CellTemplate) �� .R��� $��Center=���`� * `� Mode$* OneWay=�+ `� 	Converter+ !  DA2D1050.RowNumberConverter  .1��� , �� Path$, RowData.RowHandle.Value��� $, View.DataControl�  -3   $ COLD1_LandParcelNo��$ LandParcelNo��$ Số thửa $ Center=�$	 110   -4   $ COLD1_MapNo��$ MapNo��$ Tờ bản đồ số $ Center=�$	 110   -5   $ COLD1_RecoveryArea��$ RecoveryArea��$" Diện tích thu hồi (m²) $ Center=�$	 110   -6   $ COLD1_IntersectArea��$ IntersectArea��$ Diện tích giao (m²) $ Center=�$	 110   -7   $ COLD1_BoundaryArea��$ BoundaryArea��$# Diện tích trong ranh (m²) $ Center=�$	 110   -8   $ COLD1_OutsideArea��$ OutsideArea��$$ Diện tích ngoài ranh (m²) $ Center=�$	 110   -9   $ COLD1_PublicArea��$ 
PublicArea��$ Diện tích công (m²) $ Center=�$	 110   -:   $ COLD1_ProjectID��$ 	ProjectID�� .    -;   $ COLD1_TransID��$ TransID�� .    -<   $��tabItem2��$# 2. Thông tin quyết định��.��� 
������ .+�  -=   $	 tdbgDecisionInformation��$

 None=� . $��0,10,0,0q� 
   .  .   .  ( . .   ->   $ COLD2_OrderNo��$	 STT $ OrderNo��$ Center=�$ 50 ) �� .R��� $��Center=���`� $* OneWay=�+   .1��� $, RowData.RowHandle.Value��� $, View.DataControl�  -?   $ COLD2_DecisionDesc��$  Thông tin quyết định $ 
DecisionID��$ Center=�$	 140 -   EditSettings- 1   +Lemon3.Controls.DevExp.L3LookUpEditSettings  -@   . �Name$. tdbdDecisionDescColumn��<  6DevExpress.Xpf.Editors.Settings.LookUpEditSettingsBase/   AutoComplete/ . 0   ImmediatePopup0 . 3  -DevExpress.Xpf.Grid.LookUp.LookUpEditSettings1   AutoPopulateColumns1 .  2   DisplayMember$2 DecisionDesc��3   ValueMember$3 
DecisionID��  DecisionIDResource;   5DevExpress.Xpf.Editors.Settings.PopupBaseEditSettings4    PopupContentTemplate#4 �    -A   $ COLD2_DecisionID��$ 
DecisionID�� .    -B   $ COLD2_DecidedNo��$
 Số $ 	DecidedNo��$ Center=�  -C   $ COLD2_DecidedDate��$ Ngày $ DecidedDate��$ Center=�$ 90   -D   $ COLD2_Notes��$ Ghi chú $ Notes��$ Center=�$	 200   -E   $ COLD2_ProjectID��$ 	ProjectID�� .    -F   $ COLD2_TransID��$ TransID�� .  � $��0��$��3��.+�%!   Lemon3.Controls.DevExp.L3Button!  -G   $��	btnAttach��$��Đính kèm��$
��Left=�$��5,6,0,6q�$��28��$��Center=�$	��101��+"   %Lemon3.Controls.DevExp.L3SimpleButton"  -H   $��btnSave��$
��Lưu��$��Right=�$��	0,6,115,6q�$��28��$��Center=�$��76��"  -I   $��
btnNotSave��$��Không lưu��$��Right=�$��0,0,5,0q�$��27��$��Center=�$	��107��