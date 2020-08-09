using System;
using System.IO;

namespace FormStandard
{
    public interface ISaveToAlbum
    {
        void SaveImageStreamToAlbum(string fileName, Stream stream);
    }
}
