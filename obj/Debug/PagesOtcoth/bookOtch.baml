   M S B A M L   `   `   `  ����H  DCourseLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:CourseLibrary.PagesOtcothCourseLibrary.PagesOtcoth  5      (    "CourseLibrary.PagesOtcoth.bookOtch   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:CourseLibrary.PagesOtcoth     5        N� Title$  bookOtch��5	      .��5      � .+�5   
   �� -   5         ��Name$ Printer��5      ._�5      &   System.Windows.Controls.DataGrid  -   5          Name$ datagrid��5         VerticalGridLinesBrush
 ����    HorizontalGridLinesBrush
 ����    AutoGenerateColumns .  $��0q�6�      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 6�      
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Имя��6)   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 66   �� *Name+6Q     5      $	 Жанр��6)   
 67   �� *
Genre.Name+6X     5      $	 
Автор��6)   
 68   �� *
Avtor.Name+6Y     5      $7	 1Количество страниц в книги��6)   
 6N   �� *NumberOfLines+6r     5      $#	 Количество книг��6)   
 6D   �� *Amount+6a   5      5      5      5      