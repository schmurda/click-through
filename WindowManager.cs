using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClickThrough
{
    public class WindowManager
    {
        private const int GWL_EXSTYLE           = -20;
        private const int WS_EX_LAYERED         = 0x80000;
        private const int WS_EX_TRANSPARENT     = 0x20;
        private const int LWA_ALPHA             = 0x2;

        private IntPtr _window;
        private bool _enabled = true;
        private uint _initialStyle;
        private uint _disabledStyle;
        private bool _transparent;
        private WindowPosition _pos;

        public WindowManager(GlobalEvents events)
        {
            events.OnMouseMove += OnMouseMove;
        }

        public void SelectCurrentWindow()
        {
            _window = GetForegroundWindow();
            _enabled = true;
            _transparent = false;
            _initialStyle = (uint) GetWindowLong(_window, GWL_EXSTYLE);
            _disabledStyle = _initialStyle | WS_EX_LAYERED | WS_EX_TRANSPARENT;
        }

        public void SetWindowPosition(WindowPosition pos)
        {
            _pos = pos;
            SetWindowPos(_window, new IntPtr(-1), pos.X, pos.Y, pos.Width, pos.Height, 0);
        }

        public void ToggleEnabled()
        {
            _enabled = !_enabled;
            EnableWindow(_window, _enabled);
            SetWindowLong(_window, GWL_EXSTYLE, _enabled ? _initialStyle : _disabledStyle);
        }

        private void OnMouseMove(int x, int y)
        {
            if (WindowPosition.Intersect(_pos, x, y) && !_transparent)
            {
                _transparent = true;
                SetLayeredWindowAttributes(_window, 0, 128, LWA_ALPHA);
            }
            else if (!WindowPosition.Intersect(_pos, x, y) && _transparent)
            {
                _transparent = false;
                SetLayeredWindowAttributes(_window, 0, 255, LWA_ALPHA);
            }
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint flags);

        [DllImport("user32.dll")]
        private static extern bool EnableWindow(IntPtr hWnd, bool enable);

        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);

        [DllImport("user32.dll")]
        private static extern bool SetLayeredWindowAttributes(IntPtr hWnd, uint crKey, byte bAlpha, uint dwFlags);
    }
}
