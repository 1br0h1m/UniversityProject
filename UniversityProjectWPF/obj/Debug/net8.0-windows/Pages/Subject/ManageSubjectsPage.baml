   M S B A M L   `   `   `  ����O  KUniversityProjectWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:UniversityProjectWPF.Pages.Subject"UniversityProjectWPF.Pages.Subject  5      ;    5UniversityProjectWPF.Pages.Subject.ManageSubjectsPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Blocal0clr-namespace:UniversityProjectWPF.Pages.Subject     5        N� Title$  ManageSubjectsPage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��0.8* �6   .+�5   
   �� $��0��6   ��6"   �� *
Subjects+ �� SelectedItem 5      �� *SelectedSubject+��5      �� 5      .R�5      �� $��5q�6!   .+�5      �� $��18(�6$   ��62   ��  �� Path$ Id��� 5      ��6$   �� $
 Name�5      5      5      �� 5   
   $��1��6    � DataContext 6%   �� *SelectedSubject+.+�5      �� $
��Name��6   �� 5      ��6   �� *
TempName+ �� UpdateSourceTrigger$ PropertyChanged=��� 5       $
��Save��6   $
��0,10q�5"      $
��10,2q�6#   ��5!      �� *SaveCommand+5"   #   �� 5#      $��Delete��6   $
��0,10q�5%      $
��10,2q�6#   ��5$      �� *DeleteCommand+5%   #   5&      5'      5(      