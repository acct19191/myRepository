   M S B A M L   `   `   `  ����\  XTest Task for Prodactivity Inside, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:Test_Task_for_Prodactivity_Inside!Test_Task_for_Prodactivity_Inside  5   	   2    ,Test_Task_for_Prodactivity_Inside.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Alocal/clr-namespace:Test_Task_for_Prodactivity_Inside     5   	     � Title$  
MainWindow��5   	   $��459.104��6   $��489.451��6-    � WindowStartupLocation$ CenterScreen=�6>    � DataContext 5	      >   8Test_Task_for_Prodactivity_Inside.CurrencyConverterModel  5
   
   6)   .��5      � 
������� � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   �� 5      6!    � RowDefinitions 5   
   �� 5      $��2* �6   6*   �� 5      6   �� 5      6   �� 5      6   �� 5      $��2* �6   6*   .+�5   
   �� 
�������$��5q�6)   $��Center=�64   $��Center=�6V   $��20(�6z   $��2��6�   $
��Bold"�6�   ��6�   �� *
FirstValue+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5   
   
�������$��5q�6)   $��Center=�64   $��Center=�6V   $��20(�6z   $��2��6�   $��2��6�   $
��Bold"�6�   ��6�   �� *SecondValue+$ PropertyChanged=�6�   �� 5   
   $��5q�6   $��14(�6s   $#��Изменить Валюту��6�   $��3��6�   $
��Bold"�6�   ��6   �� *OpenFirstChangeCurrencyWindow+$ PropertyChanged=�6�   �� 5   
   $��5q�6   $��14(�5      $#��Изменить Валюту��6   $��2��69   $��3��6I   $
��Bold"�6V   ��5      �� * OpenSecondChangeCurrencyWindow+$ PropertyChanged=�5   j   �� 5   
   $
��Wrap=�6    �� TextAlignment$ Center=�6)   $��1��6@   $��20(�6M   $��Center=�6[   $
��Bold"�6�   ��6v   �� *First+$ PropertyChanged=�6�   �� 5   
   $
��Wrap=�6   $ Center=�6(   $��1��6?   $��20(�6L   $��Center=�6Z   $��2��6u   $
��Bold"�6�   ��6�   �� *Second+$ PropertyChanged=�6�   �� 5    
   $��1��6   $��2��6"   $!��Без названия.png��6/   $
��Fill=�6I   5"      5#      