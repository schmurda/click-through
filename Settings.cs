using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickThrough
{
    public class Settings
    {
        public List<Shortcut> Shortcuts { get; set; } = new List<Shortcut>();

        public Settings()
        {
            Shortcuts.Add(new Shortcut(WindowActions.Move));
        }
    }
}
