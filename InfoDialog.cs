namespace photoeditor
{
    public record class ImageFileInfo(
        string FileName,
        string Path,
        string Extension,
        int SizePxX,
        int SizePxY,
        int SizeCmX,
        int SizeCmY,
        int Resolution,
        string PixelsFormat,
        bool HasTransparency,
        int BitsPerPixel
    );
    public partial class InfoDialog : Form
    {
        public InfoDialog(ImageFileInfo info)
        {
            InitializeComponent();

            filename_label.Text = info.FileName;
            path_label.Text = info.Path;
            extension_label.Text = info.Extension;
            size_px_label.Text = $"{info.SizePxX}x{info.SizePxY}";
            size_cm_label.Text = $"{info.SizeCmX}x{info.SizeCmY}";
            resolution_label.Text = info.Resolution.ToString();
            pixels_format.Text = info.PixelsFormat;
            has_transparency_label.Text = info.HasTransparency.ToString();
            bits_per_pixel_label.Text = info.BitsPerPixel.ToString();
        }
    }
}
