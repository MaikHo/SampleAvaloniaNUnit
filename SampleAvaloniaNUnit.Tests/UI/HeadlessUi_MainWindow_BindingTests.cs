using Avalonia.Controls;
using Avalonia.Headless;
using Avalonia.Headless.NUnit;
using NUnit.Framework;
using SampleAvaloniaNUnit;                  // MainWindow
using SampleAvaloniaNUnit.ViewModels;       // SampleVm

namespace SampleAvaloniaNUnit.Tests.UI
{
    /// <summary>
    /// Headless UI tests for the MainWindow binding (two-way between TextBox and SampleVm).
    /// </summary>
    [TestFixture]
    [Category("UI")]
    [NonParallelizable]
    public sealed class HeadlessUi_MainWindow_BindingTests
    {
        /// <summary>
        /// UI→VM: Input in the TextBox updates SampleVm.Text.
        /// </summary>
        [AvaloniaTest]
        public void Text_input_updates_viewmodel()
        {
            var win = new MainWindow();                         // real app view
            var vm  = new SampleVm();
            win.DataContext = vm;                               // set VM at runtime (overrides default)
            win.Show();                                         // open offscreen

            var input = win.FindControl<TextBox>("InputBox");   // x:Name="InputBox"
            Assert.That(input, Is.Not.Null);

            input.Focus();
            //win.TextInput("Avalonia UI");                       // simulate input
            win.KeyTextInput("Avalonia UI");

            Assert.That(vm.Text, Is.EqualTo("Avalonia UI"));    // VM accepted the text
        }

        /// <summary>
        /// VM→UI: When the view model changes the text, the TextBox displays it.
        /// </summary>
        [AvaloniaTest]
        public void Viewmodel_change_updates_textbox()
        {
            var win = new MainWindow();
            var vm  = new SampleVm { Text = "Start" };
            win.DataContext = vm;
            win.Show();

            var input = win.FindControl<TextBox>("InputBox");
            Assert.That(input, Is.Not.Null);

            vm.Text = "From VM";                                // VM changes value
            Assert.That(input!.Text, Is.EqualTo("From VM"));    // UI follows
        }
    }
}
