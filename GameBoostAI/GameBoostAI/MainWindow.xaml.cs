using System;
using System.Windows;
using System.Windows.Controls;

namespace GameBoostAI;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        LoadHardware();
    }

    private void LoadHardware()
    {
        CpuValue.Text = Environment.ProcessorCount + " Threads";

        double ram = GC.GetGCMemoryInfo().TotalAvailableMemoryBytes
                     / (1024.0 * 1024 * 1024);

        RamValue.Text = ram > 0
            ? ram.ToString("0.0") + " GB"
            : "Unavailable";

        WindowsValue.Text = Environment.OSVersion.Version.ToString();
    }

    private void Analyze_Click(object sender, RoutedEventArgs e)
    {
        string game = (GameSelector.SelectedItem as ComboBoxItem)?.Content?.ToString()
                      ?? "Unknown game";

        string mode = (ModeSelector.SelectedItem as ComboBoxItem)?.Content?.ToString()
                      ?? "Balanced Mode";

        string target = (TargetSelector.SelectedItem as ComboBoxItem)?.Content?.ToString()
                        ?? "Windows settings only";

        StatusText.Text = "Analysis completed!";

        DetailsText.Text =
            $"Selected game: {game}\n\n" +
            $"Optimization mode: {mode}\n\n" +
            $"Optimization target: {target}\n\n" +
            $"Detected processor threads: {Environment.ProcessorCount}\n\n" +
            "This is an initial analysis. More hardware detection " +
            "and game-specific recommendations will be added in future versions.";
    }

    private void Optimize_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show(
            "Your optimization profile is ready for review.\n\n" +
            "Automatic system changes are not enabled in this version.",
            "GAMEBOOST AI",
            MessageBoxButton.OK,
            MessageBoxImage.Information);
    }
}
