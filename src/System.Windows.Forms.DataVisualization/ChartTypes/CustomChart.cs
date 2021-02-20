using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Windows.Forms.DataVisualization.Charting.ChartTypes
{
    /// <summary>
    /// Base class for custom chart implementations
    /// </summary>
    public abstract class CustomChart : IChartType
    {
        public abstract string Name { get; }
        public abstract bool Stacked { get; }
        public abstract bool SupportStackedGroups { get; }
        public abstract bool StackSign { get; }
        public abstract bool RequireAxes { get; }
        public abstract bool CircularChartArea { get; }
        public abstract bool SupportLogarithmicAxes { get; }
        public abstract bool SwitchValueAxes { get; }
        public abstract bool SideBySideSeries { get; }
        public abstract bool DataPointsInLegend { get; }
        public abstract bool ApplyPaletteColorsToPoints { get; }
        public abstract bool ExtraYValuesConnectedToYAxis { get; }
        public abstract bool ZeroCrossing { get; }
        public abstract int YValuesPerPoint { get; }
        public abstract bool SecondYScale { get; }
        public abstract bool HundredPercent { get; }
        public abstract bool HundredPercentSupportNegative { get; }

        public abstract LegendImageStyle GetLegendImageStyle(Series series);

        public bool IsDisposed { get; private set; }

        Image IChartType.GetImage(ChartTypeRegistry registry)
        {
            return GetImage(registry);
        }

        protected virtual Image GetImage(IChartTypeRegistry registry)
        {
            return (Image)registry.ResourceManager.GetObject(Name + "ChartType");
        }

        public abstract void Paint(ChartGraphics graph, ChartArea area, Series seriesToDraw);
        void IChartType.Paint(ChartGraphics graph, CommonElements common, ChartArea area, Series seriesToDraw)
        {
            Paint(graph, area, seriesToDraw);
        }

        protected abstract double GetYValue(ChartArea area, Series series, DataPoint point, int pointIndex, int yValueIndex);
        double IChartType.GetYValue(CommonElements common, ChartArea area, Series series, DataPoint point, int pointIndex, int yValueIndex)
        {
            return GetYValue(area, series, point, pointIndex, yValueIndex);
        }

        protected abstract void AddSmartLabelMarkerPositions(ChartArea area, Series series, ArrayList list);
        void IChartType.AddSmartLabelMarkerPositions(CommonElements common, ChartArea area, Series series, ArrayList list)
        {
            AddSmartLabelMarkerPositions(area, series, list);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            IsDisposed = true;
        }
    }
}
