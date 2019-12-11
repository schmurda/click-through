using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClickThrough
{
    public class Shortcut
    {
        public Keys KeyCombination { get; set; } = Keys.None;

        public WindowActions WindowAction 
        {
            get { return _windowAction; }
            set 
            {
                _windowAction = value;
                AddActionOptions();
            }
        }

        public ReadOnlyCollection<ShortcutOption> Options 
        {
            get { return _options.AsReadOnly(); }
        }

        private WindowActions _windowAction;
        private readonly List<ShortcutOption> _options = new List<ShortcutOption>();

        public Shortcut(WindowActions windowAction)
        {
            WindowAction = windowAction;
        }

        private void AddActionOptions()
        {
            _options.Clear();

            switch (_windowAction)
            {
                case WindowActions.Move:
                {
                    _options.Add(new PositionOption());
                    break;
                }

                case WindowActions.Select:
                    break;
                case WindowActions.ClickThrough:
                    break;
            }
        }


        public override string ToString()
        {
            return KeyCombination == Keys.None ? "New Shortcut" : KeyCombination.ToString();
        }
    }
}
