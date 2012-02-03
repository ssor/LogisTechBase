
namespace LogisTechBase
{
    using System.Drawing;
    using GMap.NET.WindowsForms;
    using GMap.NET.WindowsForms.Markers;
    using GMap.NET;

    public class GMapMarkerPoint : GMapMarker
    {
        public Pen Pen;
        SolidBrush shadowBrush = null;
        Color customColor = Color.FromArgb(80, Color.Blue);
        string text = null;
        //Font drawFont = SystemFonts.DefaultFont;
        Font drawFont = new Font(SystemFonts.DefaultFont, FontStyle.Bold);
        SolidBrush drawBrush = new SolidBrush(Color.White);
        public GMapMarkerGoogleGreen InnerMarker;

        public GMapMarkerPoint(PointLatLng p,string strDraw)
            : base(p)
        {
            text = strDraw;
            //Pen = new Pen(Brushes.Blue, 5);
            shadowBrush = new SolidBrush(customColor);

            // do not forget set Size of the marker
            // if so, you shall have no event on it ;}
            Size = new System.Drawing.Size(20, 20);
            Offset = new System.Drawing.Point(-Size.Width / 2, -Size.Height / 2);
        }

        public override void OnRender(Graphics g)
        {
            //g.DrawRectangle(
            //    Pen,
            //    new System.Drawing.Rectangle(
            //        LocalPosition.X, LocalPosition.Y, Size.Width, Size.Height)
            //);
            Rectangle rect = new Rectangle(LocalPosition.X, LocalPosition.Y, Size.Width, Size.Height);
            g.FillEllipse(shadowBrush, rect);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            g.DrawString(text, drawFont, drawBrush, rect,sf);
        }
    }
}
