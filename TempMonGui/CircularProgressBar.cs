using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class CircularProgressBar : Control
{
    private int _value;
    private Color _progressColor = Color.FromArgb(255, 128, 0);

    public int Value
    {
        get => _value;
        set
        {
            if (value < 0 || value > 100)
                throw new ArgumentOutOfRangeException(nameof(value), "Value must be between 0 and 100.");
            _value = value;
            Invalidate();
        }
    }

    public Color ProgressColor
    {
        get => _progressColor;
        set
        {
            _progressColor = value;
            Invalidate();
        }
    }

    public CircularProgressBar()
    {
        SetStyle(ControlStyles.DoubleBuffer |
                 ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.UserPaint,
                 true);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        using (var brush = new SolidBrush(ForeColor))
        {
            e.Graphics.DrawString($"{Value}%", Font, brush, ClientRectangle, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
        }

        using (var pen = new Pen(ProgressColor, 10))
        {
            pen.StartCap = LineCap.Round;
            pen.EndCap = LineCap.Round;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = ClientRectangle;
            rect.Inflate(-5, -5);
            var startAngle = -90;
            var sweepAngle = (int)(Value / 100f * 360);
            e.Graphics.DrawArc(pen, rect, startAngle, sweepAngle);
        }
    }
}