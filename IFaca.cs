using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bonus630.vsta.FacaCaixaAuto
{
    /// <summary>
    /// Assina os métodos necessários e auxilia no gerenciamento das facas na interface com usuário, dispensando modificações na mesma
    /// </summary>
    interface IFaca
    {
        void SetValues(string height, string width, string length);
        void Draw();
        void Mirror();
        void UpDown();
        double CalcVolume();
        
    }
}
