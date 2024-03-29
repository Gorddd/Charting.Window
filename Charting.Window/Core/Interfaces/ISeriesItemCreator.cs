﻿using OxyPlot.Series;

namespace Charting.Window.Core;

public interface ISeriesItemCreator
{
    Series CreateSeries();

    void UpdateSeries(Series series);
}

