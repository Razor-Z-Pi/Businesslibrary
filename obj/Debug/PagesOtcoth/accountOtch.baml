   M S B A M L   `   `   `  ����H  DCourseLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:CourseLibrary.PagesOtcothCourseLibrary.PagesOtcoth  5      +    %CourseLibrary.PagesOtcoth.accountOtch   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:CourseLibrary.PagesOtcoth     5        N� Title$  accountOtch��5	      .��5      � .+�5   
   �� -   5         ��Name$ Printer��5      ._�5      &   System.Windows.Controls.DataGrid  -   5          Name$ datagrid��5         VerticalGridLinesBrush
 ����    HorizontalGridLinesBrush
 ����    AutoGenerateColumns .     ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6�   $��0q�6�      
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Руководитель��6)   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6?   �� *Profer.Name+6a     5      $	 Студент��6)   
 6:   �� *Student.Name+6]     5      $	 
Книга��6)   
 68   �� *	Book.Name+6X     5      $	 Дата выдачи��6)   
 6?   �� *DateOfIssue+ �� StringFormat$ {0:dd.MM.yyy}��6     5      $	 Дата принятия��6)   
 6B   �� *DateOfAdoption+$ {0:dd.MM.yyy}��6�     5      $#	 Количество книг��6)   
 6D   �� *NumberOfBooks+6h   5      5      5      5      