using System;
using System.Drawing;
using System.IO;
using System.Text;

namespace NewSidikJariGUI
{
class FingerprintConverter {
    public static string ConvertBinaryToASCII(string binaryString) {
        StringBuilder asciiString = new StringBuilder();
        for (int i = 0; i < binaryString.Length; i += 8) {
            string byteString = binaryString.Substring(i, Math.Min(8, binaryString.Length - i));
            int asciiValue = Convert.ToInt32(byteString, 2);
            asciiString.Append((char)asciiValue);
        }
        return asciiString.ToString();
    }

    public static string ConvertToBinary(string imagePath) {
        // Memuat gambar dari path yang diberikan
        Bitmap bitmap = new Bitmap(imagePath);
        StringBuilder binaryString = new StringBuilder();

        // Loop melalui setiap pixel dalam gambar
        for (int y = 0; y < bitmap.Height; y++) {
            for (int x = 0; x < bitmap.Width; x++) {
                // Mendapatkan warna pixel
                Color pixelColor = bitmap.GetPixel(x, y);

                // Asumsi: jika pixel tidak berwarna putih, kita anggap sebagai hitam
                // (hitam dalam gambar biner diwakili oleh 0, putih diwakili oleh 1)
                if (pixelColor.R < 128) {
                    binaryString.Append("0");
                } else {
                    binaryString.Append("1");
                }
            }
        }
        return ConvertBinaryToASCII(binaryString.ToString());
    }
}
}