using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ClickThrough
{
    public class GlobalEvents
    {
        private const int WH_KEYBOARD_LL    = 13;
        private const int WH_MOUSE_LL       = 14;

        private const int WM_KEYDOWN        = 0x0100;
        private const int WM_KEYUP          = 0x0101;
        private const int WM_MOUSEMOVE      = 0x0200;

        private const int VK_SHIFT          = 0x10;
        private const int VK_CONTROL        = 0x11;
        private const int VK_MENU           = 0x12;
        private const int VK_CAPITAL        = 0x14;

        private IntPtr _keyboardHook;
        private IntPtr _mouseHook;

        public GlobalKeyEvent OnKeyDown;
        public GlobalKeyEvent OnKeyUp;
        public GlobalMouseEvent OnMouseMove;

        public void Listen()
        {
            _keyboardHook = SetWindowsHookEx(WH_KEYBOARD_LL, KeyboardCallback, GetModuleHandle("user32.dll"), 0);
            _mouseHook = SetWindowsHookEx(WH_MOUSE_LL, MouseCallback, GetModuleHandle("user32.dll"), 0);
        }

        public void Stop()
        {
            UnhookWindowsHookEx(_keyboardHook);
            UnhookWindowsHookEx(_mouseHook);

            _keyboardHook = IntPtr.Zero;
            _mouseHook = IntPtr.Zero;
        }

        private IntPtr KeyboardCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                var vkCode = (Keys) Marshal.ReadInt32(lParam);
                vkCode = AddModifiers(vkCode);

                if (wParam == (IntPtr) WM_KEYDOWN)
                {
                    OnKeyDown?.Invoke(vkCode);
                }

                if (wParam == (IntPtr) WM_KEYUP)
                {
                    OnKeyUp?.Invoke(vkCode);
                }
            }

            return CallNextHookEx(_keyboardHook, nCode, wParam, lParam);
        }

        private IntPtr MouseCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr) WM_MOUSEMOVE)
            {
                int x = Cursor.Position.X;
                int y = Cursor.Position.Y;
                OnMouseMove?.Invoke(x, y);
            }

            return CallNextHookEx(_mouseHook, nCode, wParam, lParam);
        }

        private static Keys AddModifiers(Keys key)
        {
            if ((GetKeyState(VK_CAPITAL) & 0x0001) != 0)
                key |= Keys.CapsLock;
            if ((GetKeyState(VK_SHIFT) & 0x8000) != 0)
                key |= Keys.Shift;
            if ((GetKeyState(VK_CONTROL) & 0x8000) != 0)
                key |= Keys.Control;
            if ((GetKeyState(VK_MENU) & 0x8000) != 0)
                key |= Keys.Alt;

            return key;
        }

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelProc lpfn, IntPtr hmod, uint dwThread);

        [DllImport("user32.dll")]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll")]
        private static extern short GetKeyState(int vkCode);

        private delegate IntPtr LowLevelProc(int nCode, IntPtr wParam, IntPtr lParam);

        public delegate void GlobalKeyEvent(Keys key);
        public delegate void GlobalMouseEvent(int x, int y);
    }
}
