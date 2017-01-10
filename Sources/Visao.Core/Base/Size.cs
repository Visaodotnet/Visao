namespace Visao
{
	using System;

	/// <summary>
	/// Stores the width and height of a rectangle.
	/// </summary>
	public struct Size : IEquatable<Size>
	{
		#region Fields

		private float width;

		private float height;

		#endregion

		#region Constructors

		public Size(float width, float height) : this()
		{
			Width = width;
			Height = height;
		}

		#endregion

		#region Public Members

		public float Width
		{
			get { return width; }
			set
			{
				if (width < 0)
					throw new ArgumentOutOfRangeException();
				width = value;
			}
		}

		public float Height
		{
			get { return height; }
			set
			{
				if (height < 0)
					throw new ArgumentOutOfRangeException();
				height = value;
			}
		}

		public bool IsEmpty => Width == 0 && Height == 0;

		/// <summary>
		/// Returns a Size instance equal to (0, 0).
		/// </summary>
		public static readonly Size Empty = new Size();

		/// <summary>
		/// Returns a Size instance equal to (0, 0).
		/// </summary>
		public static readonly Size Zero = new Size();

		/// <summary>
		/// Compares two instances for equality.
		/// </summary>
		/// <param name="left">The first instance.</param>
		/// <param name="right">The second instance.</param>
		/// <returns>True, if left is equal to right; false otherwise.</returns>
		public static bool operator ==(Size left, Size right) => left.Equals(right);

		/// <summary>
		/// Compares two instances for inequality.
		/// </summary>
		/// <param name="left">The first instance.</param>
		/// <param name="right">The second instance.</param>
		/// <returns>True, if left is not equal to right; false otherwise.</returns>
		public static bool operator !=(Size left, Size right) => !left.Equals(right);

		/// <summary>
		/// Indicates whether this instance is equal to the specified object.
		/// </summary>
		/// <param name="obj">The object instance to compare to.</param>
		/// <returns>True, if both instances are equal; false otherwise.</returns>
		public override bool Equals(object obj)
		{
			if (obj is Size)
				return Equals((Size)obj);

			return false;
		}

		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		/// <returns>A <see cref="System.Int32"/> that represents the hash code for this instance./></returns>
		public override int GetHashCode() => Width.GetHashCode() ^ Height.GetHashCode();

		/// <summary>
		/// Returns a <see cref="System.String"/> that describes this instance.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that describes this instance.</returns>
		public override string ToString() => $"{{{Width}, {Height}}}";

		#endregion

		#region IEquatable<Size> Members

		/// <summary>
		/// Indicates whether this instance is equal to the specified Size.
		/// </summary>
		/// <param name="other">The instance to compare to.</param>
		/// <returns>True, if both instances are equal; false otherwise.</returns>
		public bool Equals(Size other) => Width == other.Width && Height == other.Height;

		#endregion
	}
}
