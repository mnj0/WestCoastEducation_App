using Avalonia.Controls;
using Avalonia.Interactivity;

namespace WestCoastEducation_App.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    private void OnMinimize(object? s, RoutedEventArgs e) => WindowState = WindowState.Minimized;
    private void OnMaximize(object? s, RoutedEventArgs e) =>
    WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
    private void OnClose(object? s, RoutedEventArgs e) => Close();
}