using System;
namespace Visao
{
	public class Rectangle : IPolygon, IEquatable<Rectangle>
	{
		#region Constructors

		public Rectangle() : this(0,0,0,0)
		{
		}

		/// <summary>
		/// Constructs a new Rectangle instance.
		/// </summary>
		/// <param name="location">The top-left corner of the Rectangle.</param>
		/// <param name="size">The width and height of the Rectangle.</param>
		public Rectangle(Point location, Size size)
		{
			Location = location;
			Size = size;
		}

		/// <summary>
		/// Constructs a new Rectangle instance.
		/// </summary>
		/// <param name="x">The x coordinate of the Rectangle.</param>
		/// <param name="y">The y coordinate of the Rectangle.</param>
		/// <param name="width">The width coordinate of the Rectangle.</param>
		/// <param name="height">The height coordinate of the Rectangle.</param>
		public Rectangle(int x, int y, int width, int height) : this(new Point(x, y), new Size(width, height))
		{ }

		#endregion

		#region Public Members

		/// <summary>
		/// Gets or sets the x coordinate of the Rectangle.
		/// </summary>
		public float X
		{
			get { return Location.X; }
			set { Location = new Point(value, Y); }
		}

		/// <summary>
		/// Gets or sets the y coordinate of the Rectangle.
		/// </summary>
		public float Y
		{
			get { return Location.Y; }
			set { Location = new Point(X, value); }
		}

		/// <summary>
		/// Gets or sets the width of the Rectangle.
		/// </summary>
		public float Width
		{
			get { return Size.Width; }
			set { Size = new Size(value, Height); }
		}

		/// <summary>
		/// Gets or sets the height of the Rectangle.
		/// </summary>
		public float Height
		{
			get { return Size.Height; }
			set { Size = new Size(Width, value); }
		}

		/// <summary>
		/// Gets or sets a <see cref="Point"/> representing the x and y coordinates
		/// of the Rectangle.
		/// </summary>
		public Point Location { get; set; }

		/// <summary>
		/// Gets or sets a <see cref="Size"/> representing the width and height
		/// of the Rectangle.
		/// </summary>
		public Size Size { get; set; }

		/// <summary>
		/// Gets the y coordinate of the top edge of this Rectangle.
		/// </summary>
		public float Top { get { return Y; } }

		/// <summary>
		/// Gets the x coordinate of the right edge of this Rectangle.
		/// </summary>
		public float Right { get { return X + Width; } }

		/// <summary>
		/// Gets the y coordinate of the bottom edge of this Rectangle.
		/// </summary>
		public float Bottom { get { return Y + Height; } }

		/// <summary>
		/// Gets the x coordinate of the left edge of this Rectangle.
		/// </summary>
		public float Left { get { return X; } }

		/// <summary>
		/// Defines the empty Rectangle.
		/// </summary>
		public static readonly Rectangle Zero = new Rectangle();

		#region IPolygon

		public virtual Point[] Points => new [] 
		{
			this.Location,
			this.Location + new Point(Width,0),
			this.Location + new Point(Width,Height),
			this.Location + new Point(0,Height),
		};

		#endregion

		#region Contains

		/// <summary>
		/// Tests whether this instance contains the specified x, y coordinates.
		/// </summary>
		/// <param name="x">The x coordinate to test.</param>
		/// <param name="y">The y coordinate to test.</param>
		/// <returns>True if this instance contains the x, y coordinates; false otherwise.</returns>
		/// <remarks>The left and top edges are inclusive. The right and bottom edges
		/// are exclusive.</remarks>
		public bool Contains(float x, float y)
		{
			return x >= Left && x < Right &&
				y >= Top && y < Bottom;
		}

		/// <summary>
		/// Tests whether this instance contains the specified Point.
		/// </summary>
		/// <param name="point">The <see cref="Point"/> to test.</param>
		/// <returns>True if this instance contains point; false otherwise.</returns>
		/// <remarks>The left and top edges are inclusive. The right and bottom edges
		/// are exclusive.</remarks>
		public bool Contains(Point point)
		{
			return point.X >= Left && point.X < Right &&
				point.Y >= Top && point.Y < Bottom;
		}

		/// <summary>
		/// Tests whether this instance contains the specified Rectangle.
		/// </summary>
		/// <param name="rect">The <see cref="Rectangle"/> to test.</param>
		/// <returns>True if this instance contains rect; false otherwise.</returns>
		/// <remarks>The left and top edges are inclusive. The right and bottom edges
		/// are exclusive.</remarks>
		public bool Contains(Rectangle rect)
		{
			return Contains(rect.Location) && Contains(rect.Location + rect.Size);
		}

		#endregion

		#region Operators

		/// <summary>
		/// Compares two instances for equality.
		/// </summary>
		/// <param name="left">The first instance.</param>
		/// <param name="right">The second instance.</param>
		/// <returns>True, if left is equal to right; false otherwise.</returns>
		public static bool operator ==(Rectangle left, Rectangle right)
		{
			return left.Equals(right);
		}

		/// <summary>
		/// Compares two instances for inequality.
		/// </summary>
		/// <param name="left">The first instance.</param>
		/// <param name="right">The second instance.</param>
		/// <returns>True, if left is not equal to right; false otherwise.</returns>
		public static bool operator !=(Rectangle left, Rectangle right)
		{
			return !left.Equals(right);
		}

		/// <summary>
		/// Union the specified a and b.
		/// </summary>
		/// <param name="a">The alpha component.</param>
		/// <param name="b">The blue component.</param>
		public static Rectangle Union(Rectangle a, Rectangle b)
		{
			int x1 = Math.Min(a.X, b.X);
			int x2 = Math.Max(a.X + a.Width, b.X + b.Width);
			int y1 = Math.Min(a.Y, b.Y);
			int y2 = Math.Max(a.Y + a.Height, b.Y + b.Height);

			return new Rectangle(x1, y1, x2 - x1, y2 - y1);
		}

		/// <summary>
		/// Indicates whether this instance is equal to the specified object.
		/// </summary>
		/// <param name="obj">The object instance to compare to.</param>
		/// <returns>True, if both instances are equal; false otherwise.</returns>
		public override bool Equals(object obj)
		{
			if (obj is Rectangle)
				return Equals((Rectangle)obj);

			return false;
		}

		/// <summary>
		/// Returns the hash code for this instance.
		/// </summary>
		/// <returns>A <see cref="System.Int32"/> that represents the hash code for this instance./></returns>
		public override int GetHashCode()
		{
			return Location.GetHashCode() & Size.GetHashCode();
		}

		#endregion

		#region IEquatable<Rectangle> Members

		/// <summary>
		/// Indicates whether this instance is equal to the specified Rectangle.
		/// </summary>
		/// <param name="other">The instance to compare to.</param>
		/// <returns>True, if both instances are equal; false otherwise.</returns>
		public bool Equals(Rectangle other)
		{
			return Location.Equals(other.Location) &&
				Size.Equals(other.Size);
		}

		#endregion

		/// <summary>
		/// Returns a <see cref="System.String"/> that describes this instance.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that describes this instance.</returns>
		public override string ToString()
		{
			return String.Format("{{{0}-{1}}}", Location, Location + Size);
		}
	}
}
