   M S B A M L   `   `   `  ����>  :WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WPFWPF  5   	       WPF.LZSS_Window   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:WPF     5   	     � Title$  LZSS_Window��5   	   $	��450��6   $	��800��6*   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��0.4* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      $��0.18* �6   �� 5      $��0.45* �6   .+�5   
   �� -   5         ��Name$ Message��5   /   $��0��6   $��0��6    �� TextWrapping$
 Wrap=�6@   $��Enter Message��6T   $	��Top=�6i   $	��120��6�   �� 5   
   -   5        $ DMessage��5   /   $��0��6   $��2��6   $
 Wrap=�6B   $�� ��6V   $	��Top=�6^   $	��120��6v   $��0.4,0,-0.4,0q�6�   �� 5   
   -   5        $ CompressionMessage��5   /   $��1��6   $��0��6   $
��Left=�6K   $
 Wrap=�6f   $	��Top=�6{   $	��300��6�   $	��351��6�   �� 5   
   -   5        $ DecompessionMessage��5   /   $��1��6   $��2��6   $
��Left=�6M   $
 Wrap=�6i   $	��Top=�6}   $	��300��6�   $	��316��6�   $��0.4,0,-0.4,0q�6�   �� 5   
   $��1��6   $��1��6"   .+�5      �� -   5         ��Name$ StartCompress��5      $��Start compress��6,   $
��Left=�6E   $	��Top=�6a   $	��126��6y   $��25��6�   �� 5      -   5        $ CompressAll��5      $��Compress All��6*   $
��Left=�6A   $	��Top=�6]   $	��126��6u   $��25��6�   �� 5      -   5        $ StartDecompress��5      $��Start decompress��6.   $
��Left=�6I   $	��Top=�6e   $	��126��6}   $��25��6�   6�   �� 5      -   5        $ 
Decompress��5      $��Decompress All��6)   $
��Left=�6B   $	��Top=�6^   $	��126��6v   $��25��6�   6�   �� 5      -	   5         ��Name$ t1��5      Compression rate:67   �� 5       -
   5        $ timeC��5       6)   �� 5!      -   5        $ t2��5!      Deecompression rate:6:   �� 5"      -   5        $ timeD��5"      6)   5#      5%      5&      