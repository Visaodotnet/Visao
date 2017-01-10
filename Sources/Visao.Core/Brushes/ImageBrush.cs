namespace Visao
{
	public class ImageBrush : IBrush
	{
		public ImageBrush(string path)
		{
			this.Path = path;
		}

		public string Path { get; private set; }
	}
}
