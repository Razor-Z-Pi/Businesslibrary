   M S B A M L   `   `   `  ����H  DCourseLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:CourseLibrary.PagesOtcothCourseLibrary.PagesOtcoth  5      '    !CourseLibrary.PagesOtcoth.stdOtch   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:CourseLibrary.PagesOtcoth     5        N� Title$  stdOtch��5	      .��5      � .+�5   
   �� -   5         ��Name$ Printer��5      ._�5      &   System.Windows.Controls.DataGrid  -   5          Name$ datagrid��5         VerticalGridLinesBrush
 ����    HorizontalGridLinesBrush
 ����    AutoGenerateColumns .  $��0q�6�      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6�      
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Имя��6*   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 67   �� *Name+6R     5      $	 Фамилия��6)   
 6:   �� *FName+6V     5      $	 Отчество��6)   
 6;   �� *LName+6W     5      $!	 Серия паспорта��6)   
 6B   �� *Pasport_seria+6f     5      $!	 Номер телефона��6)   
 6C   �� *	Telephone+6c     5      $	 
Адрес��6)   
 69   �� *Address.Strets+6^     5      $	 
Книга��6)   
 6:   �� *	Book.Name+6Z   5      5      5      5      