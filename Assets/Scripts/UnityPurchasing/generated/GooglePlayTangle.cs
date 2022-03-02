// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("xQrD5aJptd3hBNQ+suyyxMaW7emACBuny5yZx4FTo44nmw8kuFkhaTcf8ZmYT2I1xS6Y3thrhzByxqdNpqXRnUyQ9bSLcp/MbSljTg5C6jMeO2f+1mkeRCGj1VmxzS0JQ+wARXX2+PfHdfb99XX29vdltSLhsKn/jBr17qpIe5BjsyxFOwMquU9pbRqAjDCmhulx4m21JpsMFNvbV+eroFZE+9g2MnTeyWrd5pdSTMFZMVkTx3X21cf68f7dcb9xAPr29vby9/RILb+bWJ7FN5J0hrXTGzN7NaapARGPJOiwU1Ju3lAit8rQYEMqUinXWl8rgFXEed9T8ALYlM6iKPpjnCdikHE+ZD2J7kWOrUqsR6nXP8bFwO9a2QLLwR51cPX09vf2");
        private static int[] order = new int[] { 13,3,2,4,6,6,11,11,9,13,12,13,13,13,14 };
        private static int key = 247;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
