using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;

namespace Charting.Window.Core;

class GraphWindow : Form
{
    private OxyPlot.WindowsForms.PlotView plotView;

    public GraphWindow(Func<double, double> func, string? title = null)
    {
        InitializeComponent();

        var model = new PlotModel { Title = title };
        model.Series.Add(new FunctionSeries(func, 0, 10, 0.01));
        plotView.Model = model;
    }

    private void InitializeComponent()
    {
            this.plotView = new OxyPlot.WindowsForms.PlotView();
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
            // GraphWindow
            // 
            this.ClientSize = new System.Drawing.Size(396, 304);
            this.Controls.Add(this.plotView);
            this.Name = "GraphWindow";
            this.ResumeLayout(false);

    }
}
