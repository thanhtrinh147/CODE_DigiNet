   M S B A M L   `   `   `  ����D  @D99D0451, Version=4.10.0.0, Culture=neutral, PublicKeyToken=nullQ6clr-namespace:Lemon3.Controls.DevExp;assembly=D99D0451Lemon3.Controls.DevExp  5   	    DA2D1050   DA2D1050.DA2F1010   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   EL36clr-namespace:Lemon3.Controls.DevExp;assembly=D99D0451     5   	   f bDevExpress.Xpf.Grid.v17.1.Core, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa ]DevExpress.Xpf.Grid.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   5   	   ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  5   	   j	 fDevExpress.Xpf.LayoutControl.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aFdxlc;http://schemas.devexpress.com/winfx/2008/xaml/layoutcontrol 	 5   	   ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5      <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  5	   	   -   5          N� Title$G  ADanh mục các loại phí hỗ trợ bồi thường - DA2F1010��5
   	   $	��680��6D   $
��1024��6Q    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $9 3/DA2D1050;component/Templates/ControlTemplates.xaml?�6%   �� 5      $8 2/D99D0451;component/Templates/Lemon3Templates.xaml?�6%   %    5      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��554* �6   �� 5      $	��470 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��660* �6   .+�5   
   )  #DevExpress.Xpf.Bars.MainMenuControl  -   5        $��MainMenuControl1��5      $��Stretch=�66   $��0��6T   $��0��6d   $��2��6q   ,  &DevExpress.Xpf.Bars.ToolBarControlBase   Items. 5      '  !DevExpress.Xpf.Bars.BarButtonItem  -   5         �Name$ tsbAdd��5       !  DevExpress.Xpf.Bars.BarItem   Content)  #DevExpress.Xpf.Core.ObjectConverter$ Thêm 6.   6=     5      -   5        $ tsbEdit��5       $ Sửa 6/   6=     5       -   5        $ 	tsbDelete��5        $
 Xóa 61   6?   *  $DevExpress.Xpf.Bars.BarItemSeparator  5!        5"      -   5        $ 
tsbListAll��5"       $ Liệt kê tất cả 62   6K     5#        5$      -   5        $ 
tsbSysInfo��5$       $ Thông tin hệ thống 62   6O   5%      � 5&   
   $��1��6   $��1��6    $��
10,0,10,10q�6-   .+�5'      '   !Lemon3.Controls.DevExp.L3GroupBox  -   5        $
��grpD��5'      $��Thông tin chi tiết��6(   .��5(      � -	   5        $��gridD��5(      .+�5)      $   Lemon3.Controls.DevExp.L3Label  -
   5        $��lblCostTypeID��5)   !   $��Nhóm��66   $
��Left=�6E   $��0,14,0,0q�6`   $	��Top=�6r   )	   #Lemon3.Controls.DevExp.L3LookUpEdit	  5*      -   5        $��tdbcCostTypeID��5*   &   *
  $DevExpress.Xpf.Editors.PopupBaseEdit	 
  
PopupWidth$		 350Q�6<   +  %DevExpress.Xpf.Grid.LookUp.LookUpEdit
   AutoPopulateColumns
 .  $
��Left=�6i   $��
92,14,-9,0q�6�   $	��Top=�6�   +  %DevExpress.Xpf.Editors.LookUpEditBase   ValueMember$ 
CostTypeID��6�      DisplayMember$ CostTypeName��6�   $	��340��6�      
CostTypeID 
  PopupContentTemplate# �   6�     5+      -   5        $��	lblCostID��5+   .   $	��Mã��6!   $
��Left=�6?   $��0,40,0,0q�6Z   $	��Top=�6l   '   !Lemon3.Controls.DevExp.L3TextEdit  5,      -   5        $��	txtCostID��5,   $   $
��Left=�65   $��	92,40,0,0q�6P   $	��Top=�6c   $	��150��6{   	  5-      -   5        $��
tdbcUnitID��5-   &   $		 350Q�68   
 .  $
��Left=�6e   $��292,40,-9,0q�6�   $	��Top=�6�   $ UnitID��6�   $ UnitID��6�   $	��140��6�     UnitIDStadard# �  6�     5.      -   5        $��	lblUnitID��5.   !   $
��ĐVT��62   $
��Left=�6@   $��
251,40,0,0q�6[   $	��Top=�6o     5/      -   5        $��txtDescription��5/   $   $
��Left=�6:   $��
92,67,-9,0q�6U   $	��Top=�6i   $	��340��6�     50      -   5        $��lblDescription��50   !   $��Diễn giải��67   $
��Left=�6K   $��0,70,0,0q�6f   $	��Top=�6x   	  51      -   5        $��tdbcAnaTypeID��51   &   $		 350Q�6;   
 .  $
��Left=�6h   $��	92,92,0,0q�6�   $	��Top=�6�   $��67��6�   $ 	AnaTypeID��6�   $ 	AnaTypeID��6�     AnaTypeIDStadard# �  6�   6%    52      -   5        $��lblAnaTypeID��52   !   $��Loại liên kết KM��65   $
��Left=�6P   $��0,93,0,7q�6k   $��89��6}   	  53      -   5        $��	tdbcAnaID��53   &   $		 350Q�68   
 .  $
��Left=�6e   $��166,93,-9,0q�6�   $	��Top=�6�   $	��266��6�   $ AnaID��6�   $ AnaID��6�     AnaIDStadard# �  6�   54      55      +   %Lemon3.Controls.DevExp.L3SimpleButton  56      -   5          Name$ btnSave��56       $��_Lưu��61   $
��Left=�6@   $��27��6[   $��105,166,0,0q�6g   $	��Top=�6|   $��78��6�   6�     57      -   5        $ btnNext��57       $��Lưu và nhập _tiếp��61   $
��Left=�6M   $��27��6h   $��188,166,0,0q�6t   $	��Top=�6�   $	��142��6�   6�     58      -   5        $ 
btnNotSave��58       $��_Không lưu��64   $
��Left=�6I   $��27��6d   $��335,166,0,0q�6p   $	��Top=�6�   $	��107��6�   6�   59      *   $Lemon3.Controls.DevExp.L3GridControl  5;   
   -   5          Name$
 tdbg��5;      $��0��6)   $��1��69   )  #DevExpress.Xpf.Grid.DataControlBase   SelectionMode$	 Row=�6F      AutoGenerateColumns$ AddNew=�6Z   #   EnableSmartColumnsGeneration .  � ContextMenu 5=      �� 5>      -   5        $��ContextMenu1��5>      .@�5?      m� -   5        $��mnsAdd��5?      $��Thêm��6-   6;   m� 5@      -   5        $��mnsEdit��5@      $��Sửa��6.   6;   m� 5A      -   5        $��	mnsDelete��5A      $
��Xóa��60   6=   �� 5B      m� 5C      -   5        $��
mnsListAll��5C      $��Liệt kê tất cả��61   6I   �� 5D      m� 5E      -   5        $��
mnsSysInfo��5E      $��Thông tin hệ thống��61   6M   5F      %  DevExpress.Xpf.Grid.GridControl   View 5H      #  DevExpress.Xpf.Grid.TableView  5I      -   5          Name$ tdbgTableView��5I       &   DevExpress.Xpf.Grid.DataViewBase   ShowFilterPanelMode$ Never=�67      AllowPerPixelScrolling .    ShowTotalSummary .     AllowEditing .     ShowAutoFilterRow . 5L         Columns. 5N      $  DevExpress.Xpf.Grid.GridColumn  -    5          Name$ COL_CostTypeName��5N      $  DevExpress.Xpf.Grid.ColumnBase   	FieldName$ CostTypeName��67   $  DevExpress.Xpf.Grid.BaseColumn   Header$ Nhóm 6P      Width2  ,DevExpress.Xpf.Grid.GridColumnWidthConverter$	 130 6^   '     HorizontalHeaderContentAlignment$  Center=�6j     5O      -!   5        $ 
COL_CostID��5O      $	 Mã 61   $ CostID��6=   $  Center=�6P   $	 110 6z     5P      -"   5        $ COL_Description��5P      $ Diễn giải 66   $ Description��6I   $  Center=�6a   $	 170 6�     5Q      -#   5        $ 
COL_UnitID��5Q      $ ĐVT (Mặc định) 61   $ UnitID��6I   $  Center=�6\   $	 110 6�     5R      -$   5        $ COL_AnaTypeID��5R      $ Loại khoản mục 64   $ 	AnaTypeID��6L   $  Center=�6b   $	 110 6�     5S      -%   5        $ 	COL_AnaID��5S      $ Khoản mục chi tiết 60   $ AnaID��6L   $  Center=�6^   $	 140 6�     5T      -&   5        $ COL_CostTypeID��5T      $ 
CostTypeID��65   !   Visible! .  6L     5U      -'   5        $ COL_CreateUserID��5U      $ CreateUserID��67   ! .  6P     5V      -(   5        $ COL_CreateDate��5V      $ 
CreateDate��65   ! .  6L     5W      -)   5        $ COL_LastModifyUserID��5W      $ LastModifyUserID��6;   ! .  6X     5X      -*   5        $ COL_LastModifyDate��5X      $ LastModifyDate��69   ! .  6T   5Y      5Z      5[      