   M S B A M L   `   `   `  ����H  DCourseLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CourseLibraryCourseLibrary  5   	       CourseLibrary.Otchot   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:CourseLibrary     5   	     � Title$  Otchot��5   	   $	��450��6   $	��800��6%   .��5	      �  � RowDefinitions 5
   
   �� 5      $��50 �6   6*   �� 5      6   �� 5      $��80 �6   6*   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   
���""��$��2��6R   .+�5      �� -   5         ��Name$ btnClose��5   :   $	��185��6   
������ $��0q�6c   .��5      �� $ 
Horizontal=�6   .+�5      �� $��./icon/back.png��6   $��43��65   $��75��6A   6N   �� 5      $��Center=�6    $!��Вернутся назад��6;   6S   5      5      �� 5      $!��Мастер отчётов��6    �� TextAlignment$ Center=�5      $��Center=�5      $��Center=�5      $��88 10q�5      $��32(�5      
�������$��Oswald sans-serif)�5       69   5!      �� 5%   
   -   5         ��Name$ Printers��5%      $��1��6#   
��� � �._�5&       � -   5          �Name$ 
frmPrinter��5&   4     � NavigationUIVisibility$ Hidden=�6   6J   5'      �� 5+   
   $��2��6   
��� � �.+�5,      ��  �� CornerRadius$ 50��6      font#��[  6'   ._�5-      �� $ 50��6   $	��400��6+     header-left#��[ 67   ._�5.      �� $ 
Horizontal=�6!   $��Center=�6:   $	��400��6W   $��80��6c   .+�5/      �� -   5        $ student��5/   !   $��Студенты��62   $��30��6E   $��80��6Q   $
��10 0q�6\   	 � 	Resources	 50      
 �� 
TargetType �� Property �� Value��%_   '��       �� 51   "   "
 ��6(   .�52   &   ��  �@��CornerRadius$ 15��6E   53   #   54      55      �� 56      -   5        $ books��56   !   $��
Книги��60   $��30��6@   $��80��6L   $
��10 0q�6W   	 57      ��%_   '��       �� 58   "   "
 ��6(   .�59   &   ��  �@��CornerRadius$ 15��6E   5:   #   5;      5<      �� 5=      -   5        $ 
accounting��5=   !   $��Учёт��65   $��30��6D   $��80��6P   $
��10 0q�6[   	 5>      ��%_   '��       �� 5?   "   "
 ��6(   .�5@   &   ��  �@��CornerRadius$ 15��6E   5A   #   5B      5C      �� 5D      -   5        $ Printer��5D   !   $��Печать��62   $��30��6C   $��80��6O   $
��10 0q�6Z   	 5E      ��%_   '��       �� 5F   "   "
 ��6(   .�5G   &   ��  �@��CornerRadius$ 15��6E   5H   #   5I      5J      5K      5L      5M      5N      5O      5P      