namespace photoeditor
{
    public partial class PhotoEditorWindow : Form
    {
        public Bitmap? ImageBitmap 
        {   get
            {
                return bitmap;
            }
            set 
            { 
                if (value != null) {
                    Width = value.Width + 18;
                    Height = value.Height + 47;
                    bitmap = value;
                    Refresh();
                }
            } 
        }

        public bool IsChanged { get; set; } = false;

        Bitmap? bitmap;

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
            }
        }
    }
}
