using SharpDX.D3DCompiler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HLSLWpfInterop
{
    internal class ShaderSourceResolver:
        Include
    {
        public IDisposable Shadow { get; set; }

        //private HashSet<IDisposable> OpenedStreams = new HashSet<IDisposable>();

        public void Close(Stream stream)
        {
            //if(OpenedStreams.Remove(stream))
            //{
            stream.Dispose();
            //}
        }

        public Stream Open(IncludeType type, string fileName, Stream parentStream)
        {
            using (var stream = Application.GetResourceStream(new Uri($@"pack://application:,,,/Effects/{fileName}")).Stream)
            {
                var reader = new StreamReader(stream);
                var source = reader.ReadToEnd();
                var bytes = Encoding.ASCII.GetBytes(source);
                return new MemoryStream(bytes);
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                Shadow?.Dispose();
                disposedValue = true;
            }
        }
        ~ShaderSourceResolver()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
