using System.Collections.Generic;
using System.Windows.Forms;

namespace Flammabubble {
    public static class InterfacesToRender {
        public static List<Interface> GetInterfaces(Panel parentControl) {
            List<Interface> interfaces = new List<Interface>();

            // Add all the interfaces you want to render below
            // example: interfaces.Add(new InterfaceXXXX(parentControl));
            interfaces.Add(new InterfaceBasic(parentControl));

            return interfaces;
        }
    }
}
