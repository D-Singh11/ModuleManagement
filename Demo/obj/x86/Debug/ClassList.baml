   M S B A M L   `   `   `  ����  Demo    Presentation.ClassList   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$#  List of all Enrolled Students��5   	   $	��300��6/   $��577.672��6<    � 
ResizeMode$ NoResize=�6L   ���	#FFE8E8E8.��5      � .+�5   
   � .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ 
dg_ShowAll��5         CanUserReorderColumns .     CanUserResizeColumns .   J� RenderTransformOrigin$ 0.494,0.491&�6f      
IsReadOnly .  � UseLayoutRounding . !   EnableColumnVirtualization . 	   AutoGenerateColumns	 .  ���	#FFEEEEF2
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5	      ,  &System.Windows.Controls.DataGridColumn   Header$ Matriculation no.��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6@   �� *	pMatric+  5
      $ 
First name��6%    69   �� *pFirst_Name+  5      $ Sur name��6%    67   �� *	pSur_Name+  5      $ D.o.b��6%    64   �� *pDob+ �� StringFormat$ {0:dd/MM/yyyy}��  5      $ Coursework mark��6%    6>   �� *pCoursework_Mark+  5      $ 	Exam mark��6%    68   �� *
pExam_Mark+  5      $ Percentage (%)��6%    6=   �� *
pPercent+5      5      5      5      