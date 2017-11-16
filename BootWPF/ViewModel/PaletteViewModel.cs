using BootWPF.Helpers;
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BootWPF.ViewModel
{
    class PaletteViewModel : ObservableObject
    {
        public IEnumerable<Swatch> Swatches { get; set; }

        public PaletteViewModel()
        {
            Swatches = new SwatchesProvider().Swatches;
        }

        public ICommand SetThemeCommand
        {
            get
            {
                return new DelegateCommand(o => ChangeTheme((bool)o));
            }
        }

        private void ChangeTheme(bool IsDark)
        {
            new PaletteHelper().SetLightDark(IsDark);
        }
    }
}
