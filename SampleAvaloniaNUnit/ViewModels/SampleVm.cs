using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SampleAvaloniaNUnit.ViewModels
{
    /// <summary>
    /// Small sample view model with INotifyPropertyChanged and a text property.
    /// </summary>
    public sealed class SampleVm : INotifyPropertyChanged
    {
        private string _text = string.Empty;

        /// <summary>
        /// Two-way bound property, e.g. to TextBox.Text.
        /// </summary>
        public string Text
        {
            get => _text;                                     // return current value
            set
            {
                if (_text == value) return;                   // avoid duplicate events
                _text = value;                                // set new value
                OnPropertyChanged();                          // notify UI
            }
        }

        /// <summary>
        /// Standard event for property changes.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Helper method to raise PropertyChanged.
        /// </summary>
        private void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
