namespace Visao
{
	using System.Collections.Generic;

	public interface ILayout : IView
	{
		IEnumerable<IView> Children { get; }

		void AddView(IView child);

		void RemoveView(IView child);

		void Layout();

		void RequestLayout();
	}
}
