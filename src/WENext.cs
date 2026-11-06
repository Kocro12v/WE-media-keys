// WENext.cs - sends a single Windows media key.
// Build: csc /target:winexe /optimize+ /out:WENext.exe WENext.cs
using System;
using System.Runtime.InteropServices;

class MediaKey
{
    [DllImport("user32.dll")]
    static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

    static void Main()
    {
        // VK_MEDIA_NEXT_TRACK
        keybd_event(0xB0, 0, 0, UIntPtr.Zero);
        keybd_event(0xB0, 0, 2, UIntPtr.Zero);
    }
}
