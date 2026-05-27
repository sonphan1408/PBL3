using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GUI.Client
{
    public class RoundedPanel : Panel
    {
        public int BorderRadius { get; set; } = 20;
        public Color GradientStartColor { get; set; } = Color.Transparent;
        public Color GradientEndColor { get; set; } = Color.Transparent;
        public float GradientAngle { get; set; } = 90F;

        // Custom property to allow gradient background along with rounded corners
        private bool useGradient = false;
        public bool UseGradient 
        { 
            get { return useGradient; } 
            set { useGradient = value; this.Invalidate(); } 
        }

        public bool DrawBankCardPattern { get; set; } = false;

        public RoundedPanel()
        {
            this.DoubleBuffered = true;
            this.BackColor = Color.White;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            
            using (GraphicsPath path = GetRoundPath(rect, BorderRadius))
            {
                if (UseGradient)
                {
                    using (LinearGradientBrush brush = new LinearGradientBrush(rect, GradientStartColor, GradientEndColor, GradientAngle))
                    {
                        e.Graphics.FillPath(brush, path);
                    }
                }
                else
                {
                    using (SolidBrush brush = new SolidBrush(this.BackColor))
                    {
                        e.Graphics.FillPath(brush, path);
                    }
                }

                if (DrawBankCardPattern)
                {
                    using (SolidBrush circleBrush = new SolidBrush(Color.FromArgb(40, 255, 255, 255)))
                    {
                        e.Graphics.FillEllipse(circleBrush, rect.Width - 100, rect.Height - 80, 150, 150);
                        e.Graphics.FillEllipse(circleBrush, rect.Width - 140, rect.Height - 120, 150, 150);
                        e.Graphics.FillEllipse(circleBrush, -30, -30, 100, 100);
                    }
                }

                // Create region so controls outside the rounded borders are clipped
                this.Region = new Region(path);
            }
        }

        private GraphicsPath GetRoundPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float d = radius * 2F;
            
            // Adjust bounds slightly to avoid clipping border right at the edge
            RectangleF r = new RectangleF(rect.X, rect.Y, rect.Width - 1, rect.Height - 1);

            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
