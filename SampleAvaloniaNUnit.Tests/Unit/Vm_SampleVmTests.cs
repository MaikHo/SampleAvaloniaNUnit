using NUnit.Framework;
using SampleAvaloniaNUnit.ViewModels;

namespace SampleAvaloniaNUnit.Tests.Unit
{
    /// <summary>
    /// Pure view model tests (no AvaloniaTest / no UI).
    /// </summary>
    [TestFixture]
    [Category("Unit")]
    public sealed class Vm_SampleVmTests
    {
        [Test]
        public void Initial_state_is_empty()
        {
            var vm = new SampleVm();
            Assert.That(vm.Text, Is.Empty);
        }

        [Test]
        public void Setting_text_raises_PropertyChanged()
        {
            var vm = new SampleVm();
            var raised = false;

            vm.PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == nameof(SampleVm.Text))
                    raised = true;
            };

            vm.Text = "Hello";
            Assert.That(raised, Is.True);
            Assert.That(vm.Text, Is.EqualTo("Hello"));
        }
    }
}
