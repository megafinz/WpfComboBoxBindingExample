﻿namespace ComboBoxBindingExample;

public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();
        
        DataContext = new MainViewModel();
    }
}
