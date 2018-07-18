using System;
namespace FormStandard
{
	public interface ICaptureScreen
	{
        void CaptureScreenToAlbum();
        void SaveImageToAlbum(object oImage);
	}
}
