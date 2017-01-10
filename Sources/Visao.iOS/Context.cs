namespace Visao.iOS
{
	using System;
	using OpenTK.Graphics.ES30;

	public class Context : IContext
	{
		public Context()
		{
		}

		public void Begin(IPolygon area)
		{
			GL.Clear(ClearBufferMask.ColorBufferBit);
			GL.ClearColor(1f, 0.6f, 0.65f, 1);

			GL.UseProgram(this.Program.ID);

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
