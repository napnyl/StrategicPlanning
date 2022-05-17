using DevExpress.LookAndFeel;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StPlanning.Core
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //Application.EnableVisualStyles();
            //UserLookAndFeel.Default.SetSkinStyle("VS2010");
            //DevExpress.Skins.SkinManager.EnableFormSkins();
            //Application.SetCompatibleTextRenderingDefault(false);
            //DevExpress.XtraSplashScreen.SplashScreenManager.RegisterUserSkins(typeof(DevExpress.UserSkins.BonusSkins).Assembly);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmDiagramTest());
            Application.Run(new Main());
        }
    }
}
