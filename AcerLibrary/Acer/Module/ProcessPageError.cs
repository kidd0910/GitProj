using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Acer.Form;
using System.Web;

namespace AcerLibrary.Acer.Module
{
	class ProcessPageErrorModule : IHttpModule
	{
		// In the Init function, register for HttpApplication 
		// events by adding your handlers.
		public void Init(HttpApplication application)
		{
			application.BeginRequest	+=	(new EventHandler(this.Application_BeginRequest));
			application.EndRequest		+=	(new EventHandler(this.Application_EndRequest));
		}

		// Your BeginRequest event handler.
		private void Application_BeginRequest(Object source, EventArgs e)
		{
			FormUtil.Response.Filter		=	new ProcessPageError(FormUtil.Response.Filter);
		}

		// Your EndRequest event handler.
		private void Application_EndRequest(Object source, EventArgs e)
		{
		}

		public void Dispose()
		{
		}
	}

	class ProcessPageError : Stream
	{
		private	Stream	stream;

		public ProcessPageError(Stream stream)
		{
			this.stream	=	stream;
		}

		public override Boolean CanRead
		{
			get{return true;}
		}

		public override Boolean CanSeek
		{
			get{return false;}
		}

		public override Boolean CanWrite
		{
			get{return false;}
		}

		public override long Length
		{
			get{throw new NotSupportedException();}
		}

		public override long Position
		{
			get{throw new NotSupportedException();}
			set{throw new NotSupportedException();}
		}

		public override int Read(Byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException();
		}

		public override long Seek(long offset, System.IO.SeekOrigin direction)
		{
			throw new NotSupportedException();
		}

		public override void SetLength(long length)
		{
			throw new NotSupportedException();
		}

		public override void Close()
		{
			this.stream.Close();
			base.Close();
		}

		public override void Flush()
		{
			this.stream.Flush();
		}

		public override void Write(Byte[] buffer, int offset, int count)
		{
			if (FormUtil.Response.ContentType.Equals("text/html"))
			{
				String	content	=	UTF8Encoding.UTF8.GetString(buffer, offset, count);
			
				if (content.Contains("[HttpCompileException]") || content.Contains("[HttpException]"))
					content	=	"系統發生錯誤!";
				Byte[]	data	=	UTF8Encoding.UTF8.GetBytes(content);
        
				this.stream.Write(data, 0, data.Length);
			}
		}
	}
}
