   M S B A M L   `   `   `  ���� D  @D99D0451, Version=4.10.0.0, Culture=neutral, PublicKeyToken=nullQ6clr-namespace:Lemon3.Controls.DevExp;assembly=D99D0451Lemon3.Controls.DevExp   D49D2150   D27D1750.D27F1330   =L36clr-namespace:Lemon3.Controls.DevExp;assembly=D99D0451  W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  ?dxe5http://schemas.devexpress.com/winfx/2008/xaml/editors  f bDevExpress.Xpf.Grid.v17.1.Core, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa ]DevExpress.Xpf.Grid.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid   <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  -   $	��680��$
��1024��  N� Title$&   Thông tin gửi mail - D27F1330�� � 	Resources  �� MergedDictionaries �� Source��  �� $9 3/D27D1750;component/Templates/ControlTemplates.xaml?��� $8 2/D99D0451;component/Templates/Lemon3Templates.xaml?�%    .��� .+��  � RowDefinitions �� $��30 ��� .+�)  #DevExpress.Xpf.Bars.MainMenuControl  -     Name$ MainMenuControl1��$��2��,  &DevExpress.Xpf.Bars.ToolBarControlBase   Items. '  !DevExpress.Xpf.Bars.BarButtonItem  -     Name$ tsbAdd��!  DevExpress.Xpf.Bars.BarItem   Content)  #DevExpress.Xpf.Core.ObjectConverter$ Thêm   -   $ tsbEdit��$ Sửa   -   $ 	tsbDelete��$
 Xóa *  $DevExpress.Xpf.Bars.BarItemSeparator    -   $ 
tsbListAll��$ Liệt kê tất cả � $��1��	 � ColumnDefinitions	 �� $��5* ��� $��5* �.+�*   $Lemon3.Controls.DevExp.L3GridControl  -   
  Name$

 tdbg��$��0��)  #DevExpress.Xpf.Grid.DataControlBase   AutoGenerateColumns$
 None=�#   EnableSmartColumnsGeneration . $��Visible=� � ContextMenu �� -   $��ContextMenu1��.@�m� -	   $��mnsAdd��$��Thêm��m� -
   $��mnsEdit��$��Sửa��m� -   $��	mnsDelete��$
��Xóa���� m� -   $��
mnsListAll��$��Liệt kê tất cả��%	  DevExpress.Xpf.Grid.GridControl 	  View #
  DevExpress.Xpf.Grid.TableView
  -    
 Name$ tdbgView�� 
  AllowPerPixelScrolling . &   DevExpress.Xpf.Grid.DataViewBase   ShowTotalSummary .     ShowFilterPanelMode$ Never=� 
  ShowAutoFilterRow .     AllowEditing .   
  	AutoWidth .   	  Columns. $  DevExpress.Xpf.Grid.GridColumn  -     Name$ COL_OrderNo��$  DevExpress.Xpf.Grid.ColumnBase   	FieldName$ OrderNo��$  DevExpress.Xpf.Grid.BaseColumn   Header$	 STT '    HorizontalHeaderContentAlignment$ Center=�   Width2  ,DevExpress.Xpf.Grid.GridColumnWidthConverter$ 50    MinWidth$ 50��  -   $ COL_InforEmailName��$ InforEmailName��$ Loại nghiệp vụ $ Center=�$	 170 $	 320��  -   $ COL_InforEmailID��$ InforEmailID��$   $ Center=�$ 10    Visible .    -   $ COL_Subject��$ Subject��$ Tiêu đề $ Center=�$	 170 $	 270��  -   $ COL_ReportID��$ ReportID��$   $ Center=�$ 10  .    -   $ COL_Content��$ Content��$   $ Center=�$	 170  .  � $��1��$��5,-10,-5,10q� �� $	��300 ��� $��40 �.+�'   !Lemon3.Controls.DevExp.L3GroupBox  -     Name$ GroupDetail��$��Stretch=�$��Stretch=�$��0,0,10,0q����� -    ��Name$ 	grpheader��$
��Bold"�
chi tiết.��� -   $��GridD�� �� $��1* ��� $��1* ��� $��2* ��� $��1* ��� $��1* ��� $��1* ��� $��1* �	 �� $��1* ��� $��1* ��� $��1* ��� $��1* ��� $��1* ��� $��1* ��� $��1* ��� $��1* ��� $��1* ��� $��1* ��� $��1* ��� $��1* �.+�$   Lemon3.Controls.DevExp.L3Label  -      Name$  lblInforEmailID��$��Loại nghiệp vụ��$��0��$��3��$
��Left=�$��10,0,0,0q�$��Center=�  -   $  lblReportID��$��Mẫu file đính kèm��$��1��$��3��$
��Left=�$��10,0,0,0q�$��Center=�  -   $  
lblSubject��$��Tiêu đề��$��2��$��3��$
��Left=�$��10,0,0,0q�$��Center=�  -   $  
lblContent��$��
Nội dung��$��3��$��3��$
��Left=�$��10,0,0,0q�$��Center=�)   #Lemon3.Controls.DevExp.L3LookUpEdit  -   !  Name$! tdbcInforEmailID��$��3��$��9��$��Stretch=�$��Center=�+  %DevExpress.Xpf.Grid.LookUp.LookUpEdit"   AutoPopulateColumns" .  +  %DevExpress.Xpf.Editors.LookUpEditBase#   AutoComplete# . $   ImmediatePopup$ . *  $DevExpress.Xpf.Editors.PopupBaseEdit%   
PopupWidth$	% 350Q�&   DisplayMember$& InforEmailName��'   ValueMember$' InforEmailID��   InforEmailIDTemplate(   PopupContentTemplate#( �     -   $! tdbcReportID��$��1��$��3��$��4��$��Stretch=�$��Center=�$��0,0,10,0q�" .  # . $ . $	% 300Q�$& ReportID��$' ReportID��  ReportIDTemplate#( �  '   !Lemon3.Controls.DevExp.L3TextEdit  -   $��txtReportName��$��1��$��7��$��5��$��Stretch=�$��Center=�%  DevExpress.Xpf.Editors.BaseEdit)   
IsReadOnly) .   -   $��
txtSubject��$��2��$��3��$��9��$��Stretch=�$��Center=�$��40��)  #DevExpress.Xpf.Editors.TextEditBase$*   HorizontalScrollBarVisibility$
* Auto=�"+   VerticalScrollBarVisibility$
+ Auto=�  -   $��
txtContent��$��3��$��3��$��9��$��3��$��Stretch=�$��Stretch=�,   AcceptsReturn, . -   	MaxLength$	- 500��.   TextWrapping$
. Wrap=�/   PrintTextWrapping$
/ WrapX�$
* Auto=�$
+ Auto=�+   %Lemon3.Controls.DevExp.L3SimpleButton  -    $��	btnChoose��$��Chọn tham số��$��6��$��10��$��2��$��Stretch=�$��Stretch=�$��27��$��0,10,0,0q�� $��1��.+�� 	 �� �� $
��auto ��� $
��auto �.+�  -!   $��btnSave��$��1��$
��Lưu��$��Right=�$��Center=�$��0,0,10,0q�$	��100��$��27��  -"   $��
btnNotSave��$��2��$��Không lưu��$��Right=�$��Center=�$��0,0,10,0q�$	��120��$��27��