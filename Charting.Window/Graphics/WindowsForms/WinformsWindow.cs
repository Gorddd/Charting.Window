using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;

namespace Charting.Window.Graphics.WindowsForms;

class WinformsWindow : Form, IGraphics
{
    private OxyPlot.WindowsForms.PlotView plotView = new OxyPlot.WindowsForms.PlotView();

    public PlotModel PlotModel 
    {
        get => plotView.Model; 
        set => plotView.Model = value; 
    }

    public WinformsWindow()
    {
        InitializeComponent();
    }

    public void Start() => ShowDialog();
    public void Stop() => Hide();


    private void InitializeComponent()
    {
        this.SuspendLayout();
        // 
        // plotView
        // 
        this.plotView.Dock = System.Windows.Forms.DockStyle.Fill;
        this.plotView.Location = new System.Drawing.Point(0, 0);
        this.plotView.Name = "plotView";
        this.plotView.PanCursor = System.Windows.Forms.Cursors.Hand;
        this.plotView.Size = new System.Drawing.Size(396, 304);
        this.plotView.TabIndex = 0;
        this.plotView.Text = "plotView";
        this.plotView.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
        this.plotView.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
        this.plotView.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
        // 
        // WinformsWindow
        // 
        this.ClientSize = new System.Drawing.Size(396, 304);
        this.Controls.Add(this.plotView);
        this.Name = "WinformsWindow";
        this.ResumeLayout(false);
    }
}
