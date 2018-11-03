using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza {
    class Utility {
        public static String quote(String str) {
            return String.Format("\'{0}\'", str);
        }
        public static String normalize(String str) {
            String result = String.Format("[{0}]", str);
            Console.WriteLine(result);
            return result;
        }
    }
}
