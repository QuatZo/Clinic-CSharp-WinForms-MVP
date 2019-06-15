using System;

namespace Clinic
{
    public class RoundedTextBox : TextBox
    {
        public Color color = Color.White;
        public int borderRadius = 25;
        public RoundedTextBox()
        {
            SetStyle(ControlStyles.UserPaint, true);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            RectangleF Rect = new RectangleF(0, 0, this.Width, this.Height);
            SolidBrush brush = new SolidBrush(color);
            GraphicsPath GraphPath = Functions.FillRoundedRectangle(e.Graphics, brush, Rect, borderRadius);
            this.Region = new Region(GraphPath);
        }
    }
}
