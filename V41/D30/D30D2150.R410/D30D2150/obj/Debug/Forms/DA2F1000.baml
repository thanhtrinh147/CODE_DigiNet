   M S B A M L   `   `   `  ����D  @D99D0451, Version=4.10.0.0, Culture=neutral, PublicKeyToken=nullQ6clr-namespace:Lemon3.Controls.DevExp;assembly=D99D0451Lemon3.Controls.DevExp  5   	   D @DA2D1050, Version=4.10.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:DA2D1050DA2D1050 5	   	      DA2D1050.DA2F1000   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     EL36clr-namespace:Lemon3.Controls.DevExp;assembly=D99D0451     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   f bDevExpress.Xpf.Grid.v17.1.Core, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa ]DevExpress.Xpf.Grid.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   5   	   ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5   	   ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5   	   <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  5   	   "localclr-namespace:DA2D1050  5	   	   -   5          N� Title$$  Danh mục dự án - DA2F1000��5   	   $	��680��6+   $
��1024��68    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $9 3/DA2D1050;component/Templates/ControlTemplates.xaml?�6%   �� 5      $8 2/D99D0451;component/Templates/Lemon3Templates.xaml?�6%   %    5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��1024* �6    � RowDefinitions 5   
   �� 5      $��30 �6   6*   �� 5      $
��240* �6   6,   �� 5      $
��380* �6   6,   �� 5      $��40 �6   6*   .+�5    
   � -   5        $��gridMainMenuControl��5       $��0��6*   $��0��6:   .+�5!      )  #DevExpress.Xpf.Bars.MainMenuControl  -   5        $��MainMenuControl1��5!   "   $
��Left=�6:   $��Center=�6U   ,  &DevExpress.Xpf.Bars.ToolBarControlBase   Items. 5"      '  !DevExpress.Xpf.Bars.BarButtonItem  -   5          Name$ tsbAdd��5"   $   !  DevExpress.Xpf.Bars.BarItem   Content)  #DevExpress.Xpf.Core.ObjectConverter$ Thêm 64   6C     5#      -   5        $ tsbEdit��5#   $   $ Sửa 65   6C     5$      -   5        $ 	tsbDelete��5$   $   $
 Xóa 67   6E   *  $DevExpress.Xpf.Bars.BarItemSeparator  5%        5&      -   5        $ tsbExportToExcel��5&   $   $ Xuất excel 6>   6S     5'        5(      -   5        $ 
tsbSysInfo��5(   $   $ Thông tin hệ thống 68   6U   5)      5*      *   $Lemon3.Controls.DevExp.L3GridControl  5,   
   -	   5        	  Name$
	 tdbg��5,   8   $��0��6   $��1��6+   )  #DevExpress.Xpf.Grid.DataControlBase
   AutoGenerateColumns$

 None=�6F   #   EnableSmartColumnsGeneration .  � ContextMenu 5/      �� 50      -
   5        $��ContextMenu1��50      .@�51      m� -   5        $��mnsAdd��51      $��Thêm��6-   6;   m� 52      -   5        $��mnsEdit��52      $��Sửa��6.   6;   m� 53      -   5        $��	mnsDelete��53      $
��Xóa��60   6=   m� 54      -   5        $��mnsExportToExcel��54      $��Xuất Excel��67   6K   m� 55      -   5        $��
mnsSysInfo��55      $��Thông tin hệ thống��61   6M   56      %	  DevExpress.Xpf.Grid.GridControl 	  View 58      #
  DevExpress.Xpf.Grid.TableView
  59      -   5        $��tdbgTableView��59        
  AllowPerPixelScrolling . &   DevExpress.Xpf.Grid.DataViewBase   ShowTotalSummary .  &   DevExpress.Xpf.Grid.GridViewBase   ShowGroupPanel .   
  ShowAutoFilterRow .  
  NewItemRowPosition$
 None=�5:          AllowEditing .  5=        	  Columns. 5?      $  DevExpress.Xpf.Grid.GridColumn  -   5          Name$ COL_ProjectTypeName��5?      $  DevExpress.Xpf.Grid.ColumnBase   	FieldName$ ProjectTypeName��6:   $  DevExpress.Xpf.Grid.BaseColumn   Header$ Loại dự án 6V      Width2  ,DevExpress.Xpf.Grid.GridColumnWidthConverter$
 170* 6j      MinWidth$	 170��6w   '    HorizontalHeaderContentAlignment$ Center=�6�   5@        5A      -   5        $ COL_ProjectID��5A      $ 	ProjectID��64   $	 Mã 6J   $
 110* 6V   $	 110��6c   $ Center=�6r     5B      -   5        $ COL_ProjectName��5B      $ ProjectName��66   $
 Tên 6N   $
 170* 6[   $	 170��6h   $ Center=�6w     5C      -   5        $ COL_StatusID��5C      $ StatusID��63   $ Trạng thái 6H   $
 110* 6\   $	 110��6i   $ Center=�6x     5D      -   5        $ COL_ExecuteDateFrom��5D      $ ExecuteDateFrom��6:   $ Ngày bắt đầu 6V   $ 90 6l   $ Center=�6w     5E      -   5        $ COL_ExecuteDateTo��5E      $ ExecuteDateTo��68   $ Ngày hoàn thành 6R   $ 90 6k   $ Center=�6v     5F      -   5        $ COL_ProAddress��5F      $ 
ProAddress��65   $ Địa chỉ 6L   $
 170* 6]   $	 170��6j   $ Center=�6y     5G      -   5        $ COL_ProjectDate��5G      $ ProjectDate��66   $ Ngày lập 6N   $ 90 6`   $ Center=�6k     5H      -   5        $ COL_DivisionID��5H      $ 
DivisionID��65      Visible .  6L     5I      -   5        $ COL_ProjectTypeID��5I      $ ProjectTypeID��68    .  6R     5J      -   5        $ COL_CreateUserID��5J      $ CreateUserID��67    .  6P     5K      -   5        $ COL_CreateDate��5K      $ 
CreateDate��65    .  6L     5L      -   5        $ COL_LastModifyUserID��5L      $ LastModifyUserID��6;    .  6X     5M      -   5        $ COL_LastModifyDate��5M      $ LastModifyDate��69    .  6U   5N      &   DevExpress.Xpf.Core.DXTabControl  5P   
   $��0��6   $��2��6*   $��0,2,0,0q�67   .@�5Q      #  DevExpress.Xpf.Core.DXTabItem  -   5        $��tabItem1��5Q      �  �DevExpress.Xpf.Core.Native.HeaderedSelectorItemBase`2[[DevExpress.Xpf.Core.DXTabControl, DevExpress.Xpf.Core.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a],[DevExpress.Xpf.Core.DXTabItem, DevExpress.Xpf.Core.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a]]   Header$ 1. Thông tin chính��6+   .��5R      � 
������ .+�5S      $   Lemon3.Controls.DevExp.L3Label  -    5          Name$ lblProjectID��5S   !   $	��Mã��67   $
��Left=�6D   $��10,2,0,0q�6_   $	��Top=�6q   $��83��6�   '   !Lemon3.Controls.DevExp.L3TextEdit  5T      -!   5          Name$ txtProjectID��5T   $   $
��Left=�6:   $��98,2,0,0q�6U   $	��Top=�6g   )  #DevExpress.Xpf.Editors.TextEditBase   	MaxLength$ 50��6   $	��159��6�     5U      -"   5        $ lblProjectName��5U   !   $
��Tên��69   $
��Left=�6G   $��	280,2,0,0q�6b   $	��Top=�6u   $	��103��6�     5V      -#   5        $ txtProjectName��5V   $   $
��Left=�6<   $��	388,2,0,0q�6W   $	��Top=�6j   $	 250��6�   $	��312��6�     5W      -$   5        $ lblProjectTypeID��5W   !   $��Loại dự án��6;   $
��Left=�6P   $��	717,2,0,0q�6k   $	��Top=�6~   $��63��6�   )   #Lemon3.Controls.DevExp.L3LookUpEdit  5X      -%   5           Name$  tdbcProjectTypeID��5X   B   +  %DevExpress.Xpf.Grid.LookUp.LookUpEdit!   AutoPopulateColumns! .  $
��Left=�6]   $��	785,2,0,0q�6x   $	��Top=�6�   $	��177��6�   +  %DevExpress.Xpf.Editors.LookUpEditBase"   ImmediatePopup" . *  $DevExpress.Xpf.Editors.PopupBaseEdit#   
PopupWidth$	# 350Q�5Y   <   $   DisplayMember$$ ProjectTypeName��5Z   &   %   ValueMember$% ProjectTypeID��6F      ProjectTypeIDResource&   PopupContentTemplate#& �   5[   &     5\      -&   5        $ lblProjectDate��5\   !   $��Ngày lập��69   $
��Left=�6L   $��	10,29,0,0q�6g   $	��Top=�6z   $��83��6�   '   !Lemon3.Controls.DevExp.L3DateEdit  5]      -'   5        '  Name$' c1dateProjectDate��5]   $   $
��Left=�6?   $��	98,29,0,0q�6Z   $	��Top=�6m   $	��159��6�     5^      -(   5        $ lblProAddress��5^   !   $��Địa chỉ��68   $
��Left=�6J   $��
280,29,0,0q�6e   $	��Top=�6y   $	��103��6�     5_      -)   5        $ txtProAddress��5_   $   $
��Left=�6;   $��
388,29,0,0q�6V   $	��Top=�6j   $	 500��6�   $	��574��6�     5`      -*   5        $ lblExecuteDateFrom��5`   !   $��Ngày bắt đầu��6=   $
��Left=�6T   $��	10,56,0,0q�6o   $	��Top=�6�   $��83��6�     5a      -+   5        $' c1dateExecuteDateFrom��5a   $   $
��Left=�6C   $��	98,56,0,0q�6^   $	��Top=�6q   $	��159��6�     5b      -,   5        $ lblExecuteDateTo��5b   !   $��Ngày hoàn thành��6;   $
��Left=�6U   $��
280,56,0,0q�6p   $	��Top=�6�   $	��103��6�     5c      --   5        $' c1dateExecuteDateTo��5c   $   $
��Left=�6A   $��
388,56,0,0q�6\   $	��Top=�6p   $	��312��6�     5d      -.   5        $ lblStatusID��5d   !   $��Trạng thái��66   $
��Left=�6K   $��
717,56,0,0q�6f   $	��Top=�6z   $��63��6�     5e      -/   5        $  tdbcStatusID��5e   &   ! .  $
��Left=�6Y   $��
785,56,0,0q�6t   $	��Top=�6�   $	��177��6�   " . $	# 350Q�5f   <   $$ 
StatusName��5g   &   $% StatusID��6A     StatusIDResource#& �  5h   &   �� 5i      -0   5        $��grpProjectScale��5i      $��Quy mô dự án��66   $��-9,83,-10,-5q�6L   .��5j      � .+�5k        -1   5        $	 tdbgProjectScale��5k   /   $

 None=�6I    .  5l   "   
  5m   &    .  .  .  ( 
  	AutoWidth( . 6�   . 5o   "     -2   5        $ COLD1_OrderNo��5o   1   $ OrderNo��6H   $	 STT 6\   $ Center=�6i   $ 50 6�   )   CellTemplate) 5p   &   �� 5q   *   .R�5r   .   �� $��Center=�68   ��5s   2   `� 5t   6   * `� Mode$* OneWay=�6C   + `� 	Converter+ 6Q   !  DA2D1050.RowNumberConverter  .1�5u   :   �� , �� Path$, RowData.RowHandle.Value�6B   �� 5v   :   $, View.DataControl�6B   5w   7   5y   /   5z   +   5|   #     5}   "   -3   5        $ COLD1_LandParcelNo��5}   1   $ LandParcelNo��6M   $ Số thửa 6f   $ Center=�6w   $	 110 6�     5~   "   -4   5        $ COLD1_MapNo��5~   1   $ MapNo��6F   $ Tờ bản đồ số 6X   $ Center=�6n   $	 110 6�     5   "   -5   5        $ COLD1_RecoveryArea��5   1   $ RecoveryArea��6M   $" Diện tích thu hồi (m²) 6f   $ Center=�6�   $	 110 6�     5�   "   -6   5        $ COLD1_IntersectArea��5�   1   $ IntersectArea��6N   $ Diện tích giao (m²) 6h   $ Center=�6�   $	 110 6�     5�   "   -7   5        $ COLD1_BoundaryArea��5�   1   $ BoundaryArea��6M   $# Diện tích trong ranh (m²) 6f   $ Center=�6�   $	 110 6�     5�   "   -8   5        $ COLD1_OutsideArea��5�   1   $ OutsideArea��6L   $$ Diện tích ngoài ranh (m²) 6d   $ Center=�6�   $	 110 6�     5�   "   -9   5        $ COLD1_PublicArea��5�   1   $ 
PublicArea��6K   $ Diện tích công (m²) 6b   $ Center=�6   $	 110 6�     5�   "   -:   5        $ COLD1_ProjectID��5�   1   $ 	ProjectID��6J    .  6`     5�   "   -;   5        $ COLD1_TransID��5�   1   $ TransID��6H    .  6\   5�      5�      5�      5�      5�        5�      -<   5        $��tabItem2��5�      $# 2. Thông tin quyết định��6+   .��5�      � 
������ .+�5�        -=   5        $	 tdbgDecisionInformation��5�   '   $

 None=�6H    . $��0,10,0,0q�6�    5�      
  5�       .  .   .  ( . 6z   . 5�        ->   5        $ COLD2_OrderNo��5�   )   $	 STT 6@   $ OrderNo��6M   $ Center=�6a   $ 50 6�   ) 5�      �� 5�   "   .R�5�   &   �� $��Center=�60   ��5�   *   `� 5�   .   $* OneWay=�6;   + 6I     .1�5�   2   �� $, RowData.RowHandle.Value�6:   �� 5�   2   $, View.DataControl�6:   5�   /   5�   '   5�   #   5�        5�      -?   5        $ COLD2_DecisionDesc��5�   )   $  Thông tin quyết định 6E   $ 
DecisionID��6c   $ Center=�6z   $	 140 6�   -   EditSettings- 5�      1   +Lemon3.Controls.DevExp.L3LookUpEditSettings  5�   "   -@   5        . �Name$. tdbdDecisionDescColumn��5�   :   <  6DevExpress.Xpf.Editors.Settings.LookUpEditSettingsBase/   AutoComplete/ . 0   ImmediatePopup0 . 3  -DevExpress.Xpf.Grid.LookUp.LookUpEditSettings1   AutoPopulateColumns1 .  2   DisplayMember$2 DecisionDesc��5�   &   3   ValueMember$3 
DecisionID��6C     DecisionIDResource;   5DevExpress.Xpf.Editors.Settings.PopupBaseEditSettings4    PopupContentTemplate#4 �  5�   &   5�        5�      -A   5        $ COLD2_DecisionID��5�   )   $ 
DecisionID��6C    .  6Z     5�      -B   5        $ COLD2_DecidedNo��5�   )   $
 Số 6B   $ 	DecidedNo��6N   $ Center=�6d     5�      -C   5        $ COLD2_DecidedDate��5�   )   $ Ngày 6D   $ DecidedDate��6R   $ Center=�6j   $ 90 6�     5�      -D   5        $ COLD2_Notes��5�   )   $ Ghi chú 6>   $ Notes��6O   $ Center=�6a   $	 200 6�     5�      -E   5        $ COLD2_ProjectID��5�   )   $ 	ProjectID��6B    .  6X     5�      -F   5        $ COLD2_TransID��5�   )   $ TransID��6@    .  6T   5�      5�      5�      5�      � 5�   
   $��0��6   $��3��6   .+�5�      %!   Lemon3.Controls.DevExp.L3Button!  -G   5        $��	btnAttach��5�      $��Đính kèm��6+   $
��Left=�6>   $��5,6,0,6q�6Y   $��28��6j   $��Center=�6v   $	��101��6�   6�   +"   %Lemon3.Controls.DevExp.L3SimpleButton"  5�      -H   5        $��btnSave��5�       $
��Lưu��6/   $��Right=�6=   $��	0,6,115,6q�6Y   $��28��6l   $��Center=�6x   $��76��6�   6�   "  5�      -I   5        $��
btnNotSave��5�       $��Không lưu��62   $��Right=�6F   $��0,0,5,0q�6b   $��27��6s   $��Center=�6   $	��107��6�   6�   5�      5�      5�      