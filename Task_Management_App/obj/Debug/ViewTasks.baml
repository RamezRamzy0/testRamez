   M S B A M L   `   `   `  ����N  JTask_Management_App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Task_Management_AppTask_Management_App  5      #    Task_Management_App.ViewTasks   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:Task_Management_App     5        N� Title$  	ViewTasks��5	       N� 
Background
 �����.��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      �� 5      .+�5   
   �� -   5        $��hello_username_field��5      $��Center=�6,   $��Center=�6I   $
��Bold"�6d   $��30(�6v   � 5   
   $��1��6   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��Data_grid_tasks��5      $	��120��6/   $	��Top=�6<   $��
10,10,10,0q�6T   �� 5      $��TaskID :��6   $��95��6'   $��40��62   $��24(�6>   $��DemiBold"�6L   $��23,171,587,34q�6b   �� 5      -   5        $��TaskID_field��5      
�������$��20(�6A   $��60��6O   $��25��6Z   $��118,182,522,38q�6f   �� 5      $��Status :��6   $��95��6'   $��40��62   $��24(�6>   $��DemiBold"�6L   $��219,171,386,34q�6b   �� 5      -   5        $��	Combo_box��5      $	��150��6(   $��40��64   $��319,174,231,31q�6@   .@�5      �� $��	Completed��6   �� 5       $��Pending��6   �� 5!      $��In Progress��6   5"      �� 5$      -   5        $
��Save��5$      $��24(�6$   $	��100��62   $��40��6>   $��552,174,48,31q�6J   6a   5'      � 5*   
   $��2��6   .+�5+      �� $��	Completed��6   
�������$��50��6?   $��24(�6K   $��DemiBold"�6Y   $	��130��6o   $��10,12,560,183q�6{     5-      -   5        $��Data_grid_complete_tasks��5-      $	��120��67   $��
10,10,10,0q�6D   5.      51      52      