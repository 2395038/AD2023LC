   M S B A M L   `   `   `  ����D  @BubbleTea, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:BubbleTea	BubbleTea  5   	        BubbleTea.EmployeeMangment   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:BubbleTea     5   	     � Title$  EmployeeMangment��5   	   $	��600��6"   $	��811��6/   .��5	      � ���	#FFFFC1CC � RowDefinitions 5   
   �� 5      $	��80* �6   �� 5      $
��243* �6   �� 5      $
��112* �6    � ColumnDefinitions 5   
   �� 5      $	��50* �6   �� 5      $
��372* �6   �� 5      $
��339* �6   �� 5      $	��50* �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ label��5      $��1��6   $��0��6/   $ ��Employee Management System��6<   $
��Left=�6a   $��0,34,0,0q�6|   $	��Top=�6�   $��24(�6�   
�������$��55��6�   $	��382��6�   
���   �$
��Bold"�6�   $��2��6  �� 5   
   ���	#FFFFC1CC$��	0,0,338,4q�6(   $��1��6;   $��1��6K   $��2��6X   .+�5      �� -   5        $
 idlb��5      $��Employee ID��6#   $��Center=�69   $	��Top=�6V   $��14(�6n    �� Left$ 10��6|   
 �� Top$ 8��6�   
���   �$
��Bold"�6�   �� 5      -   5         ��Name$ id��5      $	 145��6"    �� TextWrapping$
 Wrap=�64   $ 12��6H   $	��185��6X   $��Center=�6d   $	��Top=�6�   $��14(�6�   �� 5      -   5        $ lnamelb��5      $��	Last Name��6&   $��14(�6:   $ 10��6H   $ 52��6Y   $��Center=�6i   $	��Top=�6�   
���   �$
��Bold"�6�   �� 5      -   5        $ lname��5      $	 145��6%   $
 Wrap=�67   $ 56��6K   $	��185��6[   $��14(�6g   $��Center=�6u   $	��Top=�6�   �� 5      -   5        $ label1_Copy1��5      $��
First Name��6+   $��14(�6@   $ 10��6N   $ 93��6_   $��Center=�6o   $	��Top=�6�   $
��Bold"�6�   
���   �6�   �� 5      -   5        $ fname��5      $	 145��6%   $
 Wrap=�67   $	 101��6K   $	��185��6\   $��14(�6h   $��Center=�6v   $	��Top=�6�   �� 5      -   5        $ label1_Copy2��5      $��Email��6+   $��14(�6;   $ 10��6I   $	 140��6Z   $��Center=�6k   $	��Top=�6�   $	��127��6�   
���   �$
��Bold"�6�   �� 5       -	   5        $ email��5       $	 145��6%   $
 Wrap=�67   $	 145��6K   $	��185��6\   $��14(�6h   $��Center=�6v   $	��Top=�6�   �� 5!      -
   5        $ label1_Copy3��5!      $��Phone��6+   $��14(�6;   $ 10��6I   $	 184��6Z   $
��Left=�6k   $��Center=�6�   
���   �$
��Bold"�6�   $	��132��6�   �� 5"      -   5        $ phone��5"      $	 145��6%   $
 Wrap=�67   $	 188��6K   $	��185��6\   $��14(�6h   $��Center=�6v   $	��Top=�6�   �� 5#      -   5        $ label1_Copy4��5#      $��
Department��6+   $��14(�6@   $ 10��6N   $	 230��6_   
���   �$
��Bold"�6�   $	��132��6�   $��Center=�6�   $	��Top=�6�   �� 5$      -   5         ��Name$
 dept��5$      $	 145��6%   $	 234��67   $	��185��6H   $��14(�6T   $��Center=�6b   $	��Top=�6   .@�5%      �� $��admin��6   �� 5&      $��employee��6   5'      �� 5(      -   5        $ label1_Copy��5(      $��Password��6*   $��14(�6=   $ 10��6K   $	 277��6\   
���   �$
��Bold"�6�   $	��132��6�   $��Center=�6�   $	��Top=�6�   �� 5)      -   5        $ password��5)      $	 145��6(   $
 Wrap=�6:   $	 281��6N   $	��185��6_   $��14(�6k   $��Center=�6y   $	��Top=�6�   5*      �� 5+   
   $��2��6   $��1,32,0,4q�6%   $��1��67   .+�5,      �� -   5        	 ��Name$	 insert��5,      $��INSERT��6%   
�������$��16(�6I   $��48��6W   
���   �$
��Bold"�6�   �� 5-      -   5        $	 Select��5-      $��SELECT��6%   $��44��66   
�������$��15(�6T   $
��Bold"�6w   
���   �6�   �� 5.      -   5        $	 update��5.      $��UPDATE��6%   
�������$��16(�6I   $��44��6W   
���   �$
��Bold"�6v   6�   �� 5/      -   5        $	 Delete��5/      $��DELETE��6%   $��44��66   
�������$��15(�6T   $
��Bold"�6b   
���   �6�   �� 50      -   5        $
	 show��50      $��SHOW ALL EMPLOYEES��6#   
�������$��16(�6S   $��44��6a   $
��Bold"�6�   
���   �6�   51      �� 52   
   -   5        $ search��52      $��2��6"   $
��Left=�62   $
 Wrap=�6M   $	��Top=�6a   $	��120��6y   $��
174,62,0,0q�6�   $��18��6�   
�������$��15(�6�   �� 53   
   -   5        $ label2��53      $��2��6    $��	Search ID��60   $
��Left=�6D   $	��Top=�6_   $��15(�6w   $��30��6�   $	��101��6�   $��	41,56,0,0q�6�   ���	#FFFEFEFE
���   �6�   &   System.Windows.Controls.DataGrid  54   
   -   5        
  Name$
 dataGrid��54      $��2��6%   $��2��62   $��0,5,0,28q�6F   ���	#FFFFC1CC
���   �$��1��6�   56      57      