using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace ClickThrough
{
    public partial class ClickThrough : Form
    {
        private readonly GlobalEvents _eventManager = new GlobalEvents();
        private readonly WindowManager _winManager;

        private bool _setSelectKeyCombo;
        private Keys _selectCombo = Keys.F11 | Keys.Control;

        private bool _setEnableKeyCombo;
        private Keys _enableCombo = Keys.F12 | Keys.Control;

        private bool _setLeftKeyCombo;
        private Keys _leftCombo = Keys.F9 | Keys.Control;

        private bool _setRightKeyCombo;
        private Keys _rightCombo = Keys.F10 | Keys.Control;

        public ClickThrough()
        {
            InitializeComponent();
            _winManager = new WindowManager(_eventManager);
        }

        private void ClickThrough_Load(object sender, EventArgs e)
        {
            btnSelectShortcut.Text = "Select Shortcut: " + _selectCombo;
            btnEnableShortcut.Text = "Enable Shortcut: " + _enableCombo;
            btnLeftWindow.Text = "Left Window: " + _leftCombo;
            btnRightWindow.Text = "Right Window: " + _rightCombo;
            
            _eventManager.OnKeyDown += OnKeyDown;
            _eventManager.Listen();
        }

        private void OnKeyDown(Keys key)
        {
            if (_setSelectKeyCombo)
            {
                _selectCombo = key;
                btnSelectShortcut.Text = "Save Shortcut: " + _selectCombo;
            }
            else if (_setEnableKeyCombo)
            {
                _enableCombo = key;
                btnEnableShortcut.Text = "Save Shortcut: " + _enableCombo;
            }
            else if (_setLeftKeyCombo)
            {
                _leftCombo = key;
                btnLeftWindow.Text = "Save Shortcut: " + _leftCombo;
            }
            else if (_setRightKeyCombo)
            {
                _rightCombo = key;
                btnRightWindow.Text = "Save Shortcut: " + _rightCombo;
            }
            else if (key == _selectCombo)
            {
                _winManager.SelectCurrentWindow();
            }
            else if (key == _enableCombo)
            {
                _winManager.ToggleEnabled();
            }
            else if (key == _leftCombo)
            {
                _winManager.SetWindowPosition(WindowPosition.LeftMonitor);
            }
            else if (key == _rightCombo)
            {
                _winManager.SetWindowPosition(WindowPosition.RightMonitor);
            }
        }

        private void ClearSetShortcuts()
        {
            _setSelectKeyCombo = false;
            _setEnableKeyCombo = false;
            _setLeftKeyCombo = false;
            _setRightKeyCombo = false;
        }

        private void btnSelectShortcut_Click(object sender, EventArgs e)
        {
            ClearSetShortcuts();
            _setSelectKeyCombo = !_setSelectKeyCombo;
            ((Button) sender).Text = _setSelectKeyCombo 
                ? _selectCombo.ToString() 
                : "Select Shortcut: " + _selectCombo;
        }

        private void btnEnableShortcut_Click(object sender, EventArgs e)
        {
            ClearSetShortcuts();
            _setEnableKeyCombo = !_setEnableKeyCombo;
            ((Button) sender).Text = _setEnableKeyCombo
                ? _enableCombo.ToString()
                : "Enable Shortcut: " + _enableCombo;
        }

        private void btnLeftWindow_Click(object sender, EventArgs e)
        {
            ClearSetShortcuts();
            _setLeftKeyCombo = !_setLeftKeyCombo;
            ((Button) sender).Text = _setLeftKeyCombo
                ? _leftCombo.ToString()
                : "Left Window Shortcut: " + _leftCombo;
        }

        private void btnRightWindow_Click(object sender, EventArgs e)
        {
            ClearSetShortcuts();
            _setRightKeyCombo = !_setRightKeyCombo;
            ((Button) sender).Text = _setRightKeyCombo
                ? _rightCombo.ToString()
                : "Right Window Shortcut: " + _rightCombo;
        }
    }
}