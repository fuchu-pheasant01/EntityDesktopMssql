   M S B A M L   `   `   `  ����M  IWpfStarterLearning, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:WpfStarterLearningWpfStarterLearning  5   	   #    WpfStarterLearning.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:WpfStarterLearning     5   	   -   5          �Name$  MainWindow1��5   	    � Title$! テストWpfウィンドウ��5   	   $	��600��6   $	��800��6*   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      $��* �6   .+�5   
   o� $
��Left=�6   $��22��6*   $��	10,10,0,0q�66   $	��Top=�6I   $	��772��6a   $��4��6m   .@�5      m� $��ファイル(_F)��6   .@�5      m� $��
終了(_X)��6   5      m� 5      $��
編集(_E)��6   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	DataGrid1��5         AutoGenerateColumns . $
��Left=�6Y   $	��200��6t   $��	10,40,0,0q�6�   $	��Top=�6�   $	��772��6�   $��4��6�   ��6&   �� 6�   �� 5   
   -   5         ��Name$ RichTextBox1��5      $
��Left=�6,   $	��118��6G   $��
10,250,0,0q�6T   $	��Top=�6h   $	��376��6�   $��2��6�   . �5      /� .T�5      J� .*�6   .*�5      �� $�RichTextBox��6   5      5       5!      �� 5"   
   -   5         ��Name$ ButtonDbRead��5"      $��DB読み出しテスト��6'   $
��Left=�6;   $��	10,62,0,0q�6V   $	��Top=�6i   $	��178��6�   $��80��6�   $��1��6�   �� 5#   
   -   5        $ ButtonTimer��5#      $��タイマーテスト��6&   $
��Left=�68   $��	10,62,0,0q�6S   $	��Top=�6f   $	��178��6~   $��80��6�    J� RenderTransformOrigin$ 0.536,0.512&�6�   $��1��6�   $��1��6�   �� 5$   
   -   5        $ ButtonXmlRead��5$      $��Xml読み出しテスト��6(   $��2��6=   $
��Left=�6M   $��	10,17,0,0q�6h   $��1��6{   $	��Top=�6�   $	��178��6�   $��65��6�   �� 5%   
   -   5        $ ButtonXmlWrite��5%      $��Xml書き込みテスト��6)   $��2��6>   $
��Left=�6N   $��
10,115,0,0q�6i   $��1��6}   $	��Top=�6�   $	��178��6�   $��65��6�   5&      5'      