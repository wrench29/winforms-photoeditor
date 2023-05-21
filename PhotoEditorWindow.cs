using System.Text;

namespace photoeditor
{
    public partial class PhotoEditorWindow : Form
    {
        public Bitmap? ImageBitmap
        {
            get
            {
                return bitmap;
            }
            set
            {
                if (value != null)
                {
                    Width = value.Width + 18;
                    Height = value.Height + 69;
                    bitmap = value;
                    Refresh();
                }
            }
        }

        public string? ImagePath { get; set; }

        public bool IsChanged { get; set; } = false;

        private Bitmap? bitmap;
        private Point? startPoint, endPoint;
        private bool inOperation = false;
        private bool showCross = false;

        public PhotoEditorWindow()
        {
            InitializeComponent();
        }

        public PhotoEditorWindow(Bitmap bitmap) : this()
        {
            ImageBitmap = bitmap;
        }

        private void PhotoEditorWindow_Paint(object sender, PaintEventArgs e)
        {
            if (bitmap != null)
            {
                e.Graphics.DrawImage(bitmap, 0, 0);
                if (showCross)
                {
                    var pen = new Pen(Color.Red);
                    e.Graphics.DrawLine(pen, (Point)startPoint!, (Point)endPoint!);

                    var crossStartPoint = new Point(endPoint.Value.X, startPoint.Value.Y);
                    var crossEndPoint = new Point(startPoint.Value.X, endPoint.Value.Y);
                    e.Graphics.DrawLine(pen, crossStartPoint, crossEndPoint);

                    e.Graphics.DrawLine(pen, (Point)startPoint!, crossStartPoint);
                    e.Graphics.DrawLine(pen, crossStartPoint, (Point)endPoint!);
                    e.Graphics.DrawLine(pen, (Point)endPoint!, crossEndPoint);
                    e.Graphics.DrawLine(pen, crossEndPoint, (Point)startPoint!);
                }
            }
        }

        public void Impixel()
        {
            if (!inOperation)
            {
                inOperation = true;
                status_bar_label.Text = "Current mode: Selecting start point for Impixel";
                MouseClick += impixelFirstClick;
            }
        }

        private void impixelFirstClick(object? sender, MouseEventArgs e)
        {
            MouseClick -= impixelFirstClick;
            startPoint = e.Location;

            status_bar_label.Text = "Current mode: Selecting end point for Impixel";

            MouseDoubleClick += impixelSecondClick;
            MouseClick += impixelSecondClick;
            KeyPress += impixelDeselectKeypress;
            KeyPress += impixelForceEnd;
        }

        private void impixelDeselectKeypress(object? sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ((char)Keys.Delete) || e.KeyChar == ((char)Keys.Back))
            {
                MouseClick += impixelFirstClick;
                KeyPress -= impixelForceEnd;
                MouseDoubleClick -= impixelSecondClick;
                MouseClick -= impixelSecondClick;
                KeyPress -= impixelDeselectKeypress;

                startPoint = null;

                status_bar_label.Text = "Current mode: Selecting start point for Impixel";
            }
        }

        private void impixelForceEnd(object? sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                MouseDoubleClick -= impixelSecondClick;
                MouseClick -= impixelSecondClick;
                KeyPress -= impixelForceEnd;
                KeyPress -= impixelDeselectKeypress;

                endPoint = startPoint;
                status_bar_label.Text = "";

                var result = impixel(bitmap!, (Point)startPoint!, (Point)endPoint!);

                showCross = true;
                Refresh();
                showImpixelResult(result);
                showCross = false;
                Refresh();

                inOperation = false;
            }
        }

        private void impixelSecondClick(object? sender, MouseEventArgs e)
        {
            if (e.Clicks == 2 || e.Button == MouseButtons.Right)
            {
                MouseDoubleClick -= impixelSecondClick;
                MouseClick -= impixelSecondClick;
                KeyPress -= impixelDeselectKeypress;
                KeyPress -= impixelForceEnd;
                endPoint = e.Location;
                status_bar_label.Text = "";

                var result = impixel(bitmap!, (Point)startPoint!, (Point)endPoint!);

                showCross = true;
                Refresh();
                showImpixelResult(result);
                showCross = false;
                Refresh();

                inOperation = false;
            }
        }

        private void showImpixelResult(List<Color> list)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var color in list)
            {
                stringBuilder.Append($"[{color.R}, {color.G}, {color.B}], ");
            }

            MessageBox.Show(stringBuilder.ToString());
        }

        private List<Color> impixel(Bitmap bitmap, Point start, Point end)
        {
            List<Color> colors = new();

            for (int x = start.X; x <= end.X; x++)
            {
                for (int y = start.Y; y <= end.Y; y++)
                {
                    colors.Add(bitmap.GetPixel(x, y));
                }
            }

            return colors;
        }
    }
}
