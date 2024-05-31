using System.Diagnostics;
using System.Reflection;

namespace Lr03_Lampart
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}