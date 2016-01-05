using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace ConsoleApplication1
{
    public class PacketWriter : BinaryWriter
    {
        private MemoryStream _ms;
        public PacketWriter()
            :base()
        {
            _ms = new MemoryStream();
            OutStream = _ms;
        }
        public void Write(Image image)
        {
            var ms = new MemoryStream();
            image.Save(ms, ImageFormat.Png);
            ms.Close();
            byte[] imageBytes = ms.ToArray();
            Write(imageBytes.Length);
            Write(imageBytes);
        }
        public byte [] GetBytes()
        {
            Close();
            byte[] data = _ms.ToArray();
            return data;
        }

    }
    public class PacketReader : BinaryReader
    {
        public PacketReader(byte[] data)
            :base(new MemoryStream (data))
        {

        }
        public Image ReadImage()
        {
            int len = ReadInt32();
            byte[] bytes = ReadBytes(len);
            Image img;
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                img = Image.FromStream(ms);
            }
            return img;
        }
    }
}
