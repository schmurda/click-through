using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickThrough
{
    public class  ShortcutOption
    {
        public string Type { get; }

        protected ShortcutOption(string type)
        {
            Type = type;
        }

        public override string ToString()
        {
            return Type;
        }
    }

    public class PositionOption : ShortcutOption
    {
        [DisplayName("Window Position")]
        public WindowPosition WindowPosition { get; set; } = new WindowPosition();

        public PositionOption() : base("Position")
        {
        }
    }
}
