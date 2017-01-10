namespace Visao
{
	using System;

	public class RoundRectangle : Rectangle
	{
		public RoundRectangle()
		{
		}

		public float CornerRadius { get; set; }

		public override Point[] Points
		{
			get
			{
				return base.Points; // TODO add curves to original rectangle
			}
		}
	}
}
