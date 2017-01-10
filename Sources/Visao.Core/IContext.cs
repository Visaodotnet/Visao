namespace Visao
{
	public interface IContext
	{
		/// <summary>
		/// Begin to draw in the given cropped area.
		/// </summary>
		/// <param name="area">Area.</param>
		void Begin(IPolygon area);

		void Line(IPolygon shape, IBrush brush, float thickness);

		void Fill(IPolygon shape, IBrush brush);

		Rectangle Text(string text, IBrush brush, Rectangle location);

		void ShadowOutside(IPolygon shape, IBrush brush, float size);

		void ShadowInside(IPolygon shape, IBrush brush, float size);
	}
}
