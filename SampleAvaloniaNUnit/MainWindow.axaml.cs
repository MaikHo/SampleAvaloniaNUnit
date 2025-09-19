using Avalonia.Controls;
using SampleAvaloniaNUnit.ViewModels;

namespace SampleAvaloniaNUnit;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new SampleVm(); // Set runtime DataContext
    }
}
