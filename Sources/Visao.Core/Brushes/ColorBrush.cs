namespace Visao
{
	public class ColorBrush : IBrush
	{
		public ColorBrush(Color color)
		{
			this.Color = color;
		}

		public Color Color { get; private set; }
	}
}
