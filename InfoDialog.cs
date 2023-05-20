namespace photoeditor
{
    public record class ImageFileInfo(
        string FileName,
        string Path,
        string Extension,
        int SizePxX,
        int SizePxY,
        float SizeCmX,
        float SizeCmY,
        float VResolution,
        float HResolution,
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
            size_cm_label.Text = $"{info.SizeCmX:0.##}x{info.SizeCmY:0.##}";
            resolution_label.Text = $"Horizontal: {info.HResolution} Vertical: {info.VResolution}";
            pixels_format.Text = info.PixelsFormat;
            has_transparency_label.Text = info.HasTransparency.ToString();
            bits_per_pixel_label.Text = info.BitsPerPixel.ToString();
        }
    }
}
