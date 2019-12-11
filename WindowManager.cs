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

        //private const long WS_CAPTION           = 0x00C00000L;
        //private const long WS_THICKFRAME        = 0x00040000L;
        //private const long WS_MINIMIZEBOX       = 0x00020000L;
        //private const long WS_MAXIMIZEBOX       = 0x00010000L;
        //private const long WS_SYSMENU           = 0x00080000L;

        //private const long WS_EX_DLGMODALFRAME  = 0x00000001L;
        //private const long WS_EX_CLIENTEDGE     = 0x00000200L;
        //private const long WS_EX_STATICEDGE     = 0x00020000L;

        private const int WS_EX_LAYERED        = 0x80000;
        private const int WS_EX_TRANSPARENT    = 0x20;

        private const int LWA_ALPHA             = 0x2;

        private IntPtr _window;
        private WindowPosition _pos;
        private bool _enabled = true;
        private uint _initialStyle;
        private uint _disabledStyle;
        private bool _transparent;

        public WindowManager(GlobalEvents events)
        {
            events.OnMouseMove += OnMouseMove;
        }

        public void SelectCurrentWindow()
        {
            Reset();
            _window = GetForegroundWindow();
            _initialStyle = (uint) GetWindowLong(_window, GWL_EXSTYLE);
            _disabledStyle = _initialStyle | WS_EX_LAYERED | WS_EX_TRANSPARENT;
        }

        public void SetWindowPosition(WindowPosition pos)
        {
            if (_window == IntPtr.Zero)
            {
                return;
            }

            _pos = pos;
            SetWindowPos(_window, new IntPtr(-1), pos.Location.X, pos.Location.Y, pos.Size.Width, pos.Size.Height, 0);
        }

        public void ToggleEnabled()
        {
            if (_window == IntPtr.Zero)
            {
                return;
            }

            _enabled = !_enabled;
            EnableWindow(_window, _enabled);
            SetWindowLong(_window, GWL_EXSTYLE, _enabled ? _initialStyle : _disabledStyle);
        }

        private void OnMouseMove(int x, int y)
        {
            if (_window == IntPtr.Zero)
            {
                return;
            }

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

        private void Reset()
        {
            _window = IntPtr.Zero;
            _enabled = true;
            _initialStyle = 0;
            _disabledStyle = 0;
            _transparent = false;
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
