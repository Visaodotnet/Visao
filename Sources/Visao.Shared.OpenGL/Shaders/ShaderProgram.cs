namespace Visao.iOS
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Text;
	using OpenTK.Graphics.ES30;

	public class ShaderProgram
	{
		public ShaderProgram()
		{
		}

		public int ID { get; private set; }

		private List<Shader> shaders = new List<Shader>();

		public IEnumerable<Shader> Shaders => shaders.ToArray();

		public void AddShader(Shader shader)
		{
			this.shaders.Add(shader);
		}

		public Shader CreateShader(string name, ShaderType type)
		{
			var shader = new Shader(this, name, type);
			this.AddShader(shader);
			return shader;
		}

		public void Load()
		{
			this.ID = GL.CreateProgram();

			try
			{
				foreach (var shader in this.Shaders)
				{
					shader.Load();
				}

				GL.LinkProgram(this.ID);

				int linked;
				GL.GetProgram(this.ID, ProgramParameter.LinkStatus, out linked);

				if (linked == 0) // Failed
				{
					int length = 0;
					GL.GetProgram(this.ID, ProgramParameter.InfoLogLength, out length);
					if (length > 0)
					{
						var log = new StringBuilder(length);
						GL.GetProgramInfoLog(this.ID, length, out length, log);
						Debug.WriteLine("Couldn't link program: " + log.ToString());
					}

					throw new InvalidOperationException("Unable to link program");
				}
				else // Success
				{
					foreach (var shader in this.Shaders)
					{
						shader.UpdateUniforms();
					}
				}
			}
			catch (Exception ex)
			{
				this.Dispose();
				throw ex;
			}


		}

		public void Dispose()
		{
			GL.DeleteProgram(this.ID);

			foreach (var shader in this.Shaders)
			{
				shader.Dispose();
			}
		}
	}
}
