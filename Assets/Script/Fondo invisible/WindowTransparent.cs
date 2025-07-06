using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System;

public class WindowTransparent : MonoBehaviour
{
    // importal user32.dll para usar funciones Windows API 
    [DllImport("user32.dll")]
    public static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);

    // Definir borde de los margenes
    private struct MARGINS
    {
        public int cxLeftWidth;
        public int cxRightWidth;
        public int cyTopHeight;
        public int cyBottomHeight;
    }

    // imrpotal user32.dll para conseguir ek ventana activo (HWND)
    [DllImport("user32.dll")]
    private static extern IntPtr GetActiveWindow();

    // importal Dwmapi.dll para expandir la ventana
    [DllImport("Dwmapi.dll")]
    private static extern uint DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS margins);

    // importal user32.dll cambiar stats de la ventana
    [DllImport("user32.dll")]
    private static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);

    // cambiar lugar de la ventana
    [DllImport("user32.dll", SetLastError = true)]
    static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

    // cambiar opacidad ventana
    [DllImport("user32.dll")]
    static extern int SetLayeredWindowAttributes(IntPtr hWnd, uint crKey, byte bAlpha, uint dwFlags);

    const int GWL_EXSTYLE = -20;  // indice estilos extendidos de la ventana
    const uint WS_EX_LAYERED = 0x00080000;  // estilo extendido para que la ventana sea en capas
    const uint WS_EX_TRANSPARENT = 0x00000020;  // Estilo extendido para que la ventana sea clickeable 
    static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);  // ventana siempre por encima de las dem¨¢s 
    const uint LWA_COLORKEY = 0x00000001;  // Bandera para usar un color clave como transparencia
    private IntPtr hWnd;  // Manejador de la ventana activa

    private void Start()
    {
        // MessageBox(new IntPtr(0), "Hello world", "Hello Dialog", 0);

#if !UNITY_EDITOR
        // la ventana actual
        hWnd = GetActiveWindow();
 
        // definir borde de las ventanas
        MARGINS margins = new MARGINS { cxLeftWidth = -1 };
 
        // expandir el borde de las vetnanas
        DwmExtendFrameIntoClientArea(hWnd, ref margins);
 
        // cambiar el estilo de ventana por capas y hacerlo transparente
        SetWindowLong(hWnd, GWL_EXSTYLE, WS_EX_LAYERED | WS_EX_TRANSPARENT);
 
        // definir el colorkey de la ventana
        SetLayeredWindowAttributes(hWnd, 0x00FF00, 0, LWA_COLORKEY);
 
        // dejar siempre la ventana  arriba de todo
        SetWindowPos(hWnd, HWND_TOPMOST, 0, 0, 0, 0, 0);
#endif

        // run in bakcfround
        Application.runInBackground = true;
    }
    public void SetWindowClickable(bool clickable)
    {
#if !UNITY_EDITOR
        uint style = WS_EX_LAYERED;
        if (!clickable)
            style |= WS_EX_TRANSPARENT;

        SetWindowLong(hWnd, GWL_EXSTYLE, style);
#endif
    }
}