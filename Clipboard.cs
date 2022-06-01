using UnityEngine;

namespace BSS_WindowsUtilities
{
    /// <summary>
    /// A class to help manage the Windows Clipboard
    /// </summary>
    public static class Clipboard
    {
        /// <summary>
        /// Puts the string into the Clipboard.
        /// </summary>
        public static void CopyToClipboard(this string str)
        {
            GUIUtility.systemCopyBuffer = str;
        }
    }
}