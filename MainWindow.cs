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

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var child = (PhotoEditorWindow)ActiveMdiChild;
            if (child.IsChanged)
            {
                askForSave(child);
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
                    askForSave((PhotoEditorWindow)child);
                }
            }

            Application.Exit();
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void askForSave(PhotoEditorWindow window)
        {

        }

        private void openPhotoEditor(string imagePath)
        {
            var bitmap = new Bitmap(Image.FromFile(imagePath));

            var child = (PhotoEditorWindow?)ActiveMdiChild;

            if (child != null && child.ImageBitmap == null)
            {
                child.ImageBitmap = bitmap;
                return;
            }

            var photoEditorWindow = new PhotoEditorWindow(bitmap);
            photoEditorWindow.MdiParent = this;
            photoEditorWindow.Show();
        }

        private void MainWindow_MdiChildActivate(object sender, EventArgs e)
        {
            var isThereChildren = ActiveMdiChild == null;
            
            saveToolStripMenuItem.Enabled = !isThereChildren;
            saveAsToolStripMenuItem.Enabled = !isThereChildren;
            closeToolStripMenuItem.Enabled = !isThereChildren;
            infoToolStripMenuItem.Enabled = !isThereChildren;
        }
    }
}