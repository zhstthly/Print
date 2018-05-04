using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrintFieldsLocationSetting
{
    public class GuideLine : DrawingControlBase
    {
        public override decimal SizePercentNow
        {
            get
            {
                return base.SizePercentNow;
            }

            set
            {
                base.SizePercentNow = value;
                Padding = Padding;
            }
        }

        public override Point FixedLocationInPage
        {
            get
            {
                return base.FixedLocationInPage;
            }

            set
            {
                base.FixedLocationInPage = value;
                Point controlInView = PaintConvert.PageToView(PaintManager.CurrentView.PageLocation,
                                        value.MultiplyPercentage(SizePercentNow));
                this.Location = new Point((int)controlInView.X, (int)controlInView.Y);
            }
        }

        public void HideWhenInScrollBar()
        {
            if (PaintManager.CurrentView == null)
                return;
            if(direction == GuideDirection.Left
                || direction == GuideDirection.Right)
            {
                if (this.Location.X > PaintManager.CurrentView.Size.Width - 17)
                    this.Visible = false;
                else
                {
                    this.Visible = true;
                    this.BringToFront();
                }
            }
            else
            {
                if (this.Location.Y > PaintManager.CurrentView.Size.Height - 17)
                    this.Visible = false;
                else
                {
                    this.Visible = true;
                    this.BringToFront();
                }
            }
        }

        GuideDirection direction;
        int padding;
        new public int Padding
        {
            get { return padding; }
            set
            {
                padding = value;
                if (PaintManager.CurrentView == null)
                    return;
                if (PaintManager.CurrentView.PaddingEnable)
                {
                    //添加页边距线
                    switch (direction)
                    {
                        case GuideDirection.Left:
                            FixedLocationInPage = new Point(padding, 0);
                            this.Location = this.Location.AddOffset(new Point(0, -PaintManager.CurrentView.PageLocation.Y));
                            this.Width = 1;
                            this.Height = PaintManager.CurrentView.Height - 17;
                            break;
                        case GuideDirection.Top:
                            FixedLocationInPage = new Point(0, padding);
                            this.Location = this.Location.AddOffset(new Point(-PaintManager.CurrentView.PageLocation.X, 0));
                            this.Width = PaintManager.CurrentView.Width - 17;
                            this.Height = 1;
                            break;
                        case GuideDirection.Right:
                            FixedLocationInPage = new Point(PaintManager.CurrentView.FixedPageSize.Width - (padding + 1), 0);
                            this.Location = this.Location.AddOffset(new Point(0, -PaintManager.CurrentView.PageLocation.Y));
                            this.Width = 1;
                            this.Height = PaintManager.CurrentView.Height - 17;
                            break;
                        case GuideDirection.Bottom:
                            FixedLocationInPage = new Point(0, PaintManager.CurrentView.FixedPageSize.Height - (padding + 1));
                            this.Location = this.Location.AddOffset(new Point(-PaintManager.CurrentView.PageLocation.X, 0));
                            this.Width = PaintManager.CurrentView.Width - 17;
                            this.Height = 1;
                            break;
                    }
                }
                else
                {
                    DrawingNone();
                }
            }
        }
        public GuideLine(GuideDirection direction)
        {
            this.CurrentField = new Models.FieldModel();
            this.direction = direction;
            Padding = Padding;
            this.BackColor = Color.Red;
        }

        Pen InitGraphics()
        {
            Pen pen = new Pen(Color.Red, 1);
            pen.DashStyle = DashStyle.Custom;
            pen.DashPattern = new float[] { 1f, 0.5f };
            return pen;
        }

        public void DrawingATransverseLine()
        {
            this.Width = 10000;
            this.Height = 1;
            //this.CreateGraphics().DrawLine(InitGraphics(), 0, 0, 10000, 0);
        }

        void DrawingAPortraitLine()
        {
            this.Width = 1;
            this.Height = 10000;
            //this.CreateGraphics().DrawLine(InitGraphics(), 0, 0, 0, 10000);
        }

        void DrawingNone()
        {
            this.Size = new Size(0, 0);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // GuideLine
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Name = "GuideLine";
            this.Size = new System.Drawing.Size(42, 36);
            this.ResumeLayout(false);

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //switch (direction)
            //{
            //    case GuideDirection.Left:
            //        DrawingAPortraitLine();
            //        break;
            //    case GuideDirection.Top:
            //        DrawingATransverseLine();
            //        break;
            //    case GuideDirection.Right:
            //        DrawingAPortraitLine();
            //        break;
            //    case GuideDirection.Bottom:
            //        DrawingATransverseLine();
            //        break;
            //}
        }
    }

    public enum GuideDirection
    {
        Left,
        Top,
        Right,
        Bottom
    }
}
