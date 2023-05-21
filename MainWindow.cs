namespace photoeditor
{
    public partial class MainWindow : Form
    {
        private const string fileTypesFilter = "Image files(*.bmp;*.jpg;*.png;*.gif;" +
            "*.tiff)|*.bmp;*.jpg;*.png;*.gif;*.tiff";


        public MainWindow()
        {
            InitializeComponent();

            saveToolStripMenuItem.Enabled = false;
            saveAsToolStripMenuItem.Enabled = false;
            closeToolStripMenuItem.Enabled = false;
            infoToolStripMenuItem.Enabled = false;
            impixelToolStripMenuItem.Enabled = false;
            binarizeToolStripMenuItem.Enabled = false;
        }
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var photoEditorWindow = new PhotoEditorWindow();
            photoEditorWindow.MdiParent = this;
            photoEditorWindow.Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new();
            dialog.Filter = fileTypesFilter;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var fileName = dialog.FileName;
                openPhotoEditor(fileName);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var window = (PhotoEditorWindow)ActiveMdiChild;
            var path = window.ImagePath;
            if (path == null)
            {
                var res = saveAs(window);
                window.ImagePath = res;
                return;
            }
            window.ImageBitmap!.Save(path);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var window = (PhotoEditorWindow)ActiveMdiChild;
            var res = saveAs(window);
            window.ImagePath = res;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var child = (PhotoEditorWindow)ActiveMdiChild;
            if (child.IsChanged)
            {
                AskForSave(child);
            }
            child.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var child in MdiChildren)
            {
                if (child == null) continue;

                if (((PhotoEditorWindow)child).IsChanged)
                {
                    AskForSave((PhotoEditorWindow)child);
                }
            }

            Application.Exit();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var child = (PhotoEditorWindow)ActiveMdiChild;
            var bitmap = child.ImageBitmap;
            if (bitmap == null) return;

            const float Inch = 2.54f;

            var cmX = (bitmap.Width / bitmap.HorizontalResolution) * Inch;
            var cmY = (bitmap.Height / bitmap.VerticalResolution) * Inch;

            var info = new ImageFileInfo(
                child.ImagePath!.Split('\\').Last(),
                child.ImagePath!,
                child.ImagePath!.Split('.').Last(),
                bitmap.Width,
                bitmap.Height,
                cmX,
                cmY,
                bitmap.VerticalResolution,
                bitmap.HorizontalResolution,
                bitmap.PixelFormat.ToString(),
                Image.IsAlphaPixelFormat(bitmap.PixelFormat),
                Image.GetPixelFormatSize(bitmap.PixelFormat)
            );
            var infoForm = new InfoDialog(info);
            infoForm.Show();
        }

        public void AskForSave(PhotoEditorWindow window)
        {
            var res = MessageBox.Show(
                "Do you want to save?",
                "Warning, unsaved changes",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning
            );

            if (res == DialogResult.OK)
            {
                if (window.ImagePath != null)
                {
                    window.ImageBitmap!.Save(window.ImagePath);
                    window.IsChanged = false;
                    return;
                }
                saveAs(window);
            }
        }

        private string? saveAs(PhotoEditorWindow window)
        {
            var saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = fileTypesFilter;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var bitmap = window.ImageBitmap;
                bitmap!.Save(saveFileDialog.FileName);
                window.IsChanged = false;
                return saveFileDialog.FileName;
            }
            return null;
        }

        private void openPhotoEditor(string imagePath)
        {
            var bitmap = new Bitmap(Image.FromFile(imagePath));

            var child = (PhotoEditorWindow?)ActiveMdiChild;

            if (child != null && child.ImageBitmap == null)
            {
                child.ImageBitmap = bitmap;
                child.ImagePath = imagePath;
                updateState();
                return;
            }

            var photoEditorWindow = new PhotoEditorWindow(bitmap);
            photoEditorWindow.MdiParent = this;
            photoEditorWindow.ImagePath = imagePath;
            photoEditorWindow.Show();
        }

        private void MainWindow_MdiChildActivate(object sender, EventArgs e)
        {
            updateState();
        }

        private void updateState()
        {
            var isThereChildren =
                ActiveMdiChild != null &&
                ((PhotoEditorWindow)ActiveMdiChild).ImageBitmap != null;

            saveToolStripMenuItem.Enabled = isThereChildren;
            saveAsToolStripMenuItem.Enabled = isThereChildren;
            closeToolStripMenuItem.Enabled = isThereChildren;
            infoToolStripMenuItem.Enabled = isThereChildren;
            impixelToolStripMenuItem.Enabled = isThereChildren;
            binarizeToolStripMenuItem.Enabled = isThereChildren;
        }

        private void impixelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var child = (PhotoEditorWindow)ActiveMdiChild!;
            child.Impixel();
        }

        private void binarizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var child = (PhotoEditorWindow)ActiveMdiChild!;
            var bitmap = child.ImageBitmap!;

            var binarizeDialog = new BinarizeDialog();
            if (binarizeDialog.ShowDialog() != DialogResult.OK) return;

            var threshold = binarizeDialog.Threshold;

            im2bw(bitmap, out var outputImage, threshold);

            var photoEditorWindow = new PhotoEditorWindow(outputImage);
            photoEditorWindow.MdiParent = this;
            photoEditorWindow.IsChanged = true;
            photoEditorWindow.Show();
        }

        private void im2bw(Bitmap src, out Bitmap output, double threshold)
        {
            output = new Bitmap(src.Width, src.Height);

            for (int x = 0; x < src.Width; x++)
            {
                for (int y = 0; y < src.Height; y++)
                {
                    YIQ color = ColorOperations.RGBtoYIQ(src.GetPixel(x, y));

                    Color outputColor = Color.Black;

                    if (color.Y >= threshold)
                    {
                        outputColor = Color.White;
                    }

                    output.SetPixel(x, y, outputColor);
                }
            }
        }
    }
}
