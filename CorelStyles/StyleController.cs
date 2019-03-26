using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Bonus630.vsta.FacaCaixaAuto.CorelStyles
{
    public class StyleController
    {
        string currentTheme = "";
        ResourceDictionary Resources;
        Corel.Interop.VGCore.Application corelApp;
        public StyleController(ResourceDictionary resource, Corel.Interop.VGCore.Application app)
        {
            Resources = resource;
            corelApp = app;
            corelApp.OnApplicationEvent += CorelApp_OnApplicationEvent;
        }
        #region controle style
        //Keys resources name follow the resource order to add a new value
        private readonly string[] StyleKeys = new string[] {
         "Button.MouseOver.Background" ,
         "Button.MouseOver.Border",
         "Button.Static.Border" ,
         "Button.Static.Background" ,
         "Button.Pressed.Background" ,
         "Button.Pressed.Border" ,
         "Button.Disabled.Foreground",
         "Button.Disabled.Background",
         "Default.Static.Foreground" ,
         "Default.Static.Background",
         "Container.Text.Static.Background" ,
         "Container.Text.Static.Foreground" ,
         "Container.Static.Background" ,
         "Default.Static.Inverted.Foreground" ,
         "ComboBox.Border.Popup.Item.MouseOver"
        };
      
        private void LoadStyle(string name)
        {

            string style = name.Substring(name.LastIndexOf("_") + 1);
            for (int i = 0; i < StyleKeys.Length; i++)
            {
                this.Resources[StyleKeys[i]] = this.Resources[string.Format("{0}.{1}", style, StyleKeys[i])];
            }
        }
        private void CorelApp_OnApplicationEvent(string EventName, ref object[] Parameters)
        {
            //Debug.WriteLine(EventName);
            if (EventName.Equals("WorkspaceChanged") || EventName.Equals("OnColorSchemeChanged"))
            {

                LoadThemeFromPreference();

            }
        }
        public void LoadThemeFromPreference()
        {
            try
            {
                string result = string.Empty;
#if X8
                 result = corelApp.GetApplicationPreferenceValue("WindowScheme", "Colors").ToString();
#endif
#if X9
                  result = corelApp.GetApplicationPreferenceValue("WindowScheme", "Colors").ToString();
#endif
#if X10
                  result = corelApp.GetApplicationPreferenceValue("WindowScheme", "Colors").ToString();
#endif
#if X11
                  result = corelApp.GetApplicationPreferenceValue("WindowScheme", "Colors").ToString();
#endif
                if (!result.Equals(currentTheme))
                {
                    if (!result.Equals(string.Empty))
                    {
                        currentTheme = result;
                        LoadStyle(currentTheme);
                    }
                }
            }
            catch { }
        }
        #endregion
    }
}
