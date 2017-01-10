namespace Visao.iOS
{
	using System;

	public class Context : IContext
	{
		public Context()
		{
		}

		public void Begin(IPolygon area)
		{
			throw new NotImplementedException();
		}

		public void Fill(IPolygon shape, IBrush brush)
		{
			throw new NotImplementedException();
		}

		public void Line(IPolygon shape, IBrush brush, float thickness)
		{
			throw new NotImplementedException();
		}

		public void ShadowInside(IPolygon shape, IBrush brush, float size)
		{
			throw new NotImplementedException();
		}

		public void ShadowOutside(IPolygon shape, IBrush brush, float size)
		{
			throw new NotImplementedException();
		}

		public Rectangle Text(string text, IBrush brush, Rectangle location)
		{
			throw new NotImplementedException();
		}
	}
}
