namespace Visao.iOS
{
	using System;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Text;
	using OpenTK.Graphics.ES30;

	public class Shader
	{
		public Shader(ShaderProgram program, string programName, ShaderType type)
		{
			this.program = LoadResource(programName);
			this.type = type;
			this.Program = program;
		}

		private readonly string program;

		private readonly ShaderType type;

		public ShaderProgram Program { get; private set; }

		public int ID { get; private set; }

		private List<string> attributes = new List<string>();

		private Dictionary<string,int> uniforms = new Dictionary<string, int>();

		public IEnumerable<string> Attributes => attributes;

		public void AddAttribute(string name)
		{
			this.attributes.Add(name);
		}

		public void AddUniform(string name)
		{
			this.uniforms[name] = 0;
		}

		public void Load()
		{
			this.ID = GL.CreateShader(this.type);

			GL.ShaderSource(this.ID, this.program);
			GL.CompileShader(this.ID);

			int compiled = 0;

			GL.GetShader(this.ID, ShaderParameter.CompileStatus, out compiled);

			if (compiled == 0)
			{
				var length = 0;
				string message = null;

				GL.GetShader(this.ID, ShaderParameter.InfoLogLength, out length);

				if (length > 0)
				{
					var log = new StringBuilder(length);
					GL.GetShaderInfoLog(this.ID, length, out length, log);
					message = log.ToString();
				}

				GL.DeleteShader(this.ID);

				throw new InvalidOperationException("Unable to compile shader : " + message);
			}
			else
			{
				// Attach to program
				GL.AttachShader(this.Program.ID, this.ID);

				//Bind attributes
				for (int i = 0; i < this.attributes.Count; i++)
				{
					GL.BindAttribLocation(this.Program.ID, i, this.attributes[i]);
				}
			}
		}

		public void UpdateUniforms()
		{
			//Get uniforms
			foreach (var uniform in this.uniforms.Keys)
			{
				uniforms[uniform] = GL.GetUniformLocation(this.Program.ID, uniform);
			}
		}

		public void Dispose()
		{
			GL.DeleteShader(this.ID);
		}

		#region Embedded shaders

		private static string LoadResource(string name)
		{
			var assembly = typeof(Shader).GetTypeInfo().Assembly;
			var rname = $"{assembly.GetName().Name}.Shaders.Programs.{name}";
			var stream = assembly.GetManifestResourceStream(rname);
			return new System.IO.StreamReader(stream).ReadToEnd();
		}

		#endregion
	}
}
