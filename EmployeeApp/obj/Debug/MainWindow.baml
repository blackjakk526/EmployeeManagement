   M S B A M L   `   `   `  ����F  BEmployeeApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:EmployeeAppEmployeeApp  5   	       EmployeeApp.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:EmployeeApp     5   	     � Title$  Employee Management��5   	   $	��450��6%   $	��800��62   ���	#FF7C7A7A � WindowStartupLocation$ CenterScreen=�5	   	   .��5
      � .+�5   
   �� -   5         ��Name$ NameBox��5      $
��Left=�6#   $	��253��6>   $��	31,22,0,0q�6K   $	��Top=�6^   $	��463��6v   6�   �� 5   
   -   5        $
��Add ��5      $
��Left=�6    $��33��6;   $��
573,23,0,0q�6G   $	��Top=�6[   $	��126��6s   6   �� 5   
   -   5        $��Edit ��5      $
��Left=�6!   $��33��6<   $��
573,69,0,0q�6H   $	��Top=�6\   $	��126��6t   6�   �� 5   
   -   5        $��Delete��5      $
��Left=�6"   $��33��6=   $��573,113,0,0q�6I   $	��Top=�6^   $	��126��6v   6�   �� 5   
   -   5         ��Name$ Search��5      $
��Left=�6"   $��37��6=   $��
31,364,0,0q�6I    �� TextWrapping$
 Wrap=�6]   $	��Top=�6q   $	��256��6�   6�   �� 5   
   -   5         ��Name$ 	textBlock��5      $
��Left=�6'   $��24��6B   $��
31,335,0,0q�6N   $
��Wrap=�6b   $��Search��6v   $	��Top=�6�   $	��127��6�   �� 5   
   -   5         ��Name$
 Sort��5      $
��Left=�6!   $��31��6<   $��573,195,0,0q�6H   $	��Top=�6]   $	��148��6u    �� SelectedIndex$ 2��6�   6�   �� 5   
   -   5        $ 
textBlock1��5      $
��Left=�6(   $��21��6C   $��573,169,0,0q�6O   $
��Wrap=�6d   $��Sort By:��6x   $	��Top=�6�   $��47��6�   �� 5   
   -	   5        $ 
Parameters��5      $
��Left=�6'   $��37��6B   $��322,364,0,0q�6N   $	��Top=�6c   $	��156��6{   �� 5   
   -
   5        $ 
textBlock2��5      $
��Left=�6(   $��20��6C   $��323,339,0,0q�6O   $
��Wrap=�6d   $��
Parameters��6x   $	��Top=�6�   $��60��6�   �� 5   
   -   5         ��Name$ Author_Information��5      $��Author Information��6,   $
��Left=�6I   $��26��6d   $��593,375,0,0q�6p   $	��Top=�6�   $	��128��6�   6�   5      5      