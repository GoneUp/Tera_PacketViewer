using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PacketViewer
{
    public class Program
    {
        [STAThreadAttribute]
        public static void Main()
        {
            try
            {
                AppDomain.CurrentDomain.AssemblyResolve += OnResolveAssembly;
                App.Main();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Assembly Err: " + ex);
            }
            
        }

        private static Assembly OnResolveAssembly(object sender, ResolveEventArgs args)
        {
            

            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            AssemblyName assemblyName = new AssemblyName(args.Name);

            string path = assemblyName.Name + ".dll";
            if (assemblyName.CultureInfo.Equals(CultureInfo.InvariantCulture) == false)
            {
                path = String.Format(@"{0}\{1}", assemblyName.CultureInfo, path);
            }
            else
            {
                //fix for our subfolder
                path = String.Format("PacketViewer.Libs.{0}.dll", assemblyName.Name);
            }
            
            using (Stream stream = executingAssembly.GetManifestResourceStream(path))
            {
                if (stream == null)
                    return null;

                byte[] assemblyRawBytes = new byte[stream.Length];
                stream.Read(assemblyRawBytes, 0, assemblyRawBytes.Length);
                return Assembly.Load(assemblyRawBytes);
            }
        }
    }
}
