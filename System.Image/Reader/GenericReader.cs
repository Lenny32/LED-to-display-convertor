using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace System.Image.Reader
{
    public class GenericReader : IDisposable
    {
        private Stream _imageStream;

        

        public GenericReader(string location)
        {
            var bytes = File.ReadAllBytes(location);
            _imageStream = new MemoryStream(bytes);
        }

        public GenericReader(Stream stream)
        {
            _imageStream = stream;
        }



        public Image<Rgba32> Read()
        {
            var image = SixLabors.ImageSharp.Image.Load(_imageStream);
            return image;
        }

        public string GetFormat()
        {
            var format = SixLabors.ImageSharp.Image.DetectFormat(_imageStream);
            return format.Name;
        }


        private bool _isDisposed = false;
        public void Dispose()
        {
            lock (_imageStream)
            {
                if (!_isDisposed)
                {
                    _isDisposed = true;
                    _imageStream.Dispose();
                }
            }
            
        }
    }
}
