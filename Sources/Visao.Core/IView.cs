namespace Visao
{
	public interface IView
	{
		bool IsVisible { get; set; }

		Point Location { get; }

		Size Size { get; }

		void RequestDraw();

		void Draw(IContext context);
	}
}
