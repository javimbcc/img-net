using System.Drawing;
using System.Drawing.Imaging;
using System.IO;


//PictureBox
namespace SubirImagenesAbbdd.Models.Conversiones
{
    public class ConvertirIMGaBYTE
    {
        //Método que nos convierte una imagen a array de bytes
        public byte[] Convertir(IFormFile urlImage)
        {
            byte[] imageBytes;

            using (MemoryStream ms = new MemoryStream())
            {
                urlImage.CopyTo(ms);
                ms.Position = 0;
                imageBytes = ms.ToArray();
            }
            return imageBytes;
        }
    }
}
