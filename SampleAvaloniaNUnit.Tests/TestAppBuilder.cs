using Avalonia;                                   // import AppBuilder types
using Avalonia.Headless;                          // import headless platform extensions
using SampleAvaloniaNUnit;                        // access the real app class from the app project

[assembly: AvaloniaTestApplication(typeof(SampleAvaloniaNUnit.Tests.TestAppBuilder))]
// ^ Registers the AppBuilder factory type for every [AvaloniaTest] method in this assembly.
//   Avalonia.Headless calls BuildAvaloniaApp() once before UI tests run.

namespace SampleAvaloniaNUnit.Tests
{
    /// <summary>
    /// Provides the AppBuilder for headless UI tests.
    /// Uses the real app (App.axaml) from the production project, just without a visible window.
    /// </summary>
    public static class TestAppBuilder
    {
        /// <summary>
        /// Configures Avalonia for headless tests (UI thread, dispatcher, offscreen rendering).
        /// </summary>
        /// <returns>Initialized AppBuilder for headless tests.</returns>
        public static AppBuilder BuildAvaloniaApp()   // public factory method that Avalonia.Headless finds via reflection
            => AppBuilder                             // creates a new AppBuilder
                .Configure<App>()                     // uses your app class (loads App.axaml + styles/theme)
                .UseHeadless(new AvaloniaHeadlessPlatformOptions
                {                                     // options for the headless backend (defaults are usually enough)
                    // e.g. UseHeadlessDrawing = true if specialized drawing is required
                });                                   // returns the AppBuilder; headless configures windowing/rendering offscreen
    }
}
