   M S B A M L   `   `   `  ����D  @Druzynav2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Druzynav2	Druzynav2  5   	       Druzynav2.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Druzynav2     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � ColumnDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      $��* �6   �� 5      $��2* �6   .+�5   
   �� $��0��6   .+�5      �� $��	40 40 0 0q�6   $��15(�6+   $
��Imie��69   �� 5      $��	40 40 0 0q�6   $��15(�6+   $��Nazwisko��69   �� 5      $��	40 40 0 0q�6   $��15(�6+   $
��Wiek��69   �� 5      $��	40 40 0 0q�6   $��15(�6+   $
��Waga��69   5      �� 5   
   $��1��6   .+�5      �� -   5         ��Name$ tbName��5      $��	40 40 0 0q�6&   �� 5      -   5        $ 	tbSurname��5      $��	40 40 0 0q�6)   �� 5      -   5         ��Name$ cbAge��5       �� SelectedIndex$ 0��6&   $��	40 40 0 0q�68   � 5       5      �� 5      $��* �6'   �� 5      $
��0.2* �6'   .+�5       �� -   5         ��Name$ tbweight��5       $��0 40 0 0q�6.   $
��0 kg��6@   $��1��6L   �� 5!      -   5         ��Name$ slweight��5!       � Maximum$	 100Q�6+    �� TickFrequency$	 0.1Q�69   	 �� IsSnapToTickEnabled	 . 
 � Value$
 50Q�6h   $��	35 40 0 0q�6s   $��0��6�   6�   5"      �� 5#      -   5         ��Name$ buttonOK��5#   ,   $��60��6   $��10q�6    $��Dodaj��6>   6N   �� 5$      -   5        $��60��5$      $��10q�6    $��Usuń��6,   6;   �� 5%      -   5        $��60��5%      $��10q�6    $��	Modyfikuj��6,   6@   5&      �� 5'   
   -	   5         ��Name$ lb_LisOfPlayers��5'      $��10 10 10 10q�6+   $��2��6@   6P   5*      5+      