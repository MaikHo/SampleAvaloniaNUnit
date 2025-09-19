using Avalonia.Controls;
using Avalonia.Headless; // access to controls (TextBox, Window)
using Avalonia.Headless.NUnit;         // [AvaloniaTest] attribute and input helpers
using NUnit.Framework;                 // NUnit attributes/asserts

namespace SampleAvaloniaNUnit.Tests
{
    /// <summary>
    /// Sample headless UI tests for Avalonia control interaction.
    /// </summary>
    public sealed class HeadlessUiTests
    {
        /// <summary>
        /// Proof-of-concept test.
        /// Simulates text input into a TextBox and verifies the resulting text.
        /// </summary>
        [AvaloniaTest]                            // sets up UI thread/dispatcher + headless top-level for this test case
        public void TextBox_receives_text_via_simulated_input() // descriptive test name
        {
            var textBox = new TextBox();          // instantiate control (still without top-level)
            var window  = new Window               // create top-level (required for focus/input)
            {
                Content = textBox                 // attach control to the visual tree
            };

            window.Show();                        // open top-level (headless/offscreen)
            textBox.Focus();                      // set focus – required for input events
            window.KeyTextInput("Hello World");   // simulate keyboard input headlessly
            //Assert.AreEqual("Hello World", textBox.Text); // verify expectation
            Assert.That(textBox.Text, Is.EqualTo("Hello World"));
        }
    }
}
