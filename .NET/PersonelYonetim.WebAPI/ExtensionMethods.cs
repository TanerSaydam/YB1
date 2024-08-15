namespace PersonelYonetim.WebAPI;

public static class ExtensionMethods
{
    public static void IsItAnImageFileType(this IFormFile file)
    {
        using (var memoryStream = new MemoryStream())
        {
            file.CopyTo(memoryStream);

            var avatarArray = memoryStream.ToArray();

            //137 80 78 71 => png
            //255 216 255 224 => jpg

            if (avatarArray[0] != 137 && avatarArray[0] != 255)
            {
                throw new ArgumentException("Image type is not supported. You can only upload just JPG | PNG | GIF format");
            }
        }
    }
}
