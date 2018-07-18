using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FormStandard
{
	public interface IImage
	{
		byte[] ResizeImage(byte[] imageData, float width, float height);

		int WidthOfImage(object image);
		int HeightOfImage(object image);

        object ObjectFromByteArray(byte[] imageByteArray);
		byte[] ByteArrayFromObject(object image);

		object LoadImage(string path);
		object ResizeImage(object bmp, float width, float height);
		object CropImage(object imageData, int left, int top, int right, int bottom);

        Task<object> RotatedByDegrees(object src, double degrees);
	}
}
