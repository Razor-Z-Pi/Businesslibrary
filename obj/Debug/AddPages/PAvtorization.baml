   M S B A M L   `   `   `  ����H  DCourseLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:CourseLibrary.AddPagesCourseLibrary.AddPages  5      *    $CourseLibrary.AddPages.PAvtorization   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:CourseLibrary.AddPages     5        N� Title$  PAvtorization��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   .+�5   
   �� $��0��6   $��0��6%   .+�5      �� $��Center=�6   $��Center=�65   $
��0 25q�6R   .+�5      ��  �� TextAlignment$ Center=�6   $��
Логин��63   6B   5       5!      �� 5#   
   $��0��6   $��1��6%   .+�5$      �� $��Center=�6   $��Center=�65   $
��0 25q�6R   .+�5%      �� $ Center=�6   $��Пароль��63   6C   5&      5'      �� 5)   
   $��0��6   $��2��6%   .+�5*      �� $��Center=�6   $��Center=�65   $
��0 25q�6R   .+�5+      �� $ Center=�6   $��Руководитель��63   6I   5,      5-      �� 51   
   $��1��6   $��0��6%   .+�52      �� $��Center=�6   $��Center=�65   $
��0 25q�6R   .+�53      �� -   5         ��Name$ login��53   c    �� 	MaxLength$ 12��61    �� TextAlignment$ Center=�6@   $	��200��6W   ��6   �� *Login+6t   54      55      �� 57   
   $��1��6   $��1��6%   .+�58      �� $��Center=�6   $��Center=�65   $
��0 25q�6R   .+�59      �� -   5        $ password��59   f   $ 12��64   $ Center=�6C   $	��200��6Z   ��6   �� *
Password+6z   5:      5;      �� 5=   
   $��1��6   $��2��6%   .+�5>      �� $��Center=�6   $��Center=�65   $
��0 25q�6R   .+�5?      �� -   5         ��Name$ 
cmb_profer��5?   b   $	��200��6=    �� DisplayMemberPath$
 Name��6I   	 �� SelectedItem	 6   �� *
id_Pofer+6x   5@      5A      �� 5E   
   -   5        
 ��Name$
 btn_save��5E   �   $��2��6   $��3��6%   $��80��62   $��30��6=   $��10q�6I   $��Bottom=�6U   $��Сохранить��6p    � 	Resources 5F       �� 
TargetType �� Property �� Value��%_   '��       �� 5G      " ��6   .�5H      ��  �@��CornerRadius$ 15��65   5I      5J      5K      5L      5M      