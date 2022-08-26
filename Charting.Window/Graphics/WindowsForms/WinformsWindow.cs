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

    public new Color BackColor
    {
        get => plotView.BackColor;
        set => plotView.BackColor = value;
    }

    public int VisiblePoints { get; set; }
    
    public WinformsWindow()
    {
        InitializeComponent();
    }

    public void Start() => ShowDialog();
    public void Stop() => Hide();
    public void UpdateArea()
    {
        var lastX = PlotModel.Series
            .Select(series => (FunctionSeries)series)
            .Max(series => series.Points.Last().X); //Getting last X coordinate among all graphs

        PlotModel.DefaultXAxis?.Zoom(lastX - VisiblePoints, lastX); // - 10 это нужно в дизайн билдере им указывать, чтобы мы понимали на скок хотим

        plotView.Refresh();
    }


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
