using System.Windows.Forms;

namespace Charting.Window.Core;

class GraphWindow : Form
{
    public GraphWindow()
    {

    }

    private void InitializeComponent()
    {
            this.SuspendLayout();
            // 
            // GraphWindow
            // 
            this.ClientSize = new System.Drawing.Size(406, 395);
            this.Name = "GraphWindow";
            this.ResumeLayout(false);

    }
}
