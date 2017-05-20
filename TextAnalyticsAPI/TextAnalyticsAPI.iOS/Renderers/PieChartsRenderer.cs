using TextAnalyticsAPI.Custom;
using TextAnalyticsAPI.iOS.Renderers;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(PieChartsView), typeof(PieChartsRenderer))]

namespace TextAnalyticsAPI.iOS.Renderers
{
    /// <summary>
    /// CrossPieCharts Renderer
    /// </summary>
    public class PieChartsRenderer //: TRender (replace with renderer type
    {
        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public static void Init()
        {
        }
    }
}