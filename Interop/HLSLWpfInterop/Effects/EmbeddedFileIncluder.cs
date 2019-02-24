using SharpDX.D3DCompiler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HLSLWpfInterop.Effects
{
    internal class EmbeddedFileIncluder:
        Include
    {
        private static readonly Uri BasePackedUri =
            new Uri("pack://application:,,,/Effects/", UriKind.Absolute);

        protected virtual Uri BaseUri => BasePackedUri;

        public IDisposable Shadow { get; set; }

        public virtual void Close(Stream stream) {}

        public Stream Open(IncludeType type, string fileName, Stream parentStream) =>
            GetResourceStream(fileName);

        public string GetFileData(string fileName)
        {
            using (var raw = GetResourceStream(fileName))
            {
                var reader = new StreamReader(raw);
                return reader.ReadToEnd();
            }
        }

        private Stream GetResourceStream(string fileName) =>
            Application.GetResourceStream(new Uri(BaseUri, fileName)).Stream;

        public Stream Open(string fileName) => Open(IncludeType.Local, fileName, null);

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
        ~EmbeddedFileIncluder()
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
