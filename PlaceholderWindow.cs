using System;
using System.Windows.Forms;

namespace ClickThrough
{
    public partial class PlaceholderWindow : Form
    {
        private readonly WindowPosition _position = new WindowPosition();

        public PlaceholderWindow()
        {
            InitializeComponent();
        }

        private void PlaceholderWindow_Changed(object sender, EventArgs e)
        {
            _position.Location = Location;
            _position.Size = Size;
            lblSize.Text = _position.ToString();
        }

        public WindowPosition GetWindowPosition()
        {
            return _position;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Confirm?.Invoke(this, EventArgs.Empty);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        public event EventHandler Confirm;
    }
}
