using System;
using System.Runtime.InteropServices;

namespace MacroLibrary
{
	public struct POINT
	{
		#region Constructor
		public POINT(int X, int Y)
		{
			_X = X;
			_Y = Y;
		}
		#endregion

		#region Field
		int _X;
		int _Y;
		#endregion

		#region Property
		public int X
		{
			set => _X = value;
			get => _X;
		}

		public int Y
		{
			set => _Y = value;
			get => _Y;
		}
		#endregion
	}

	internal static class Win32API
	{
		#region Global
		[DllImport("Kernel32.dll")]
		public static extern int GetLastError();

		/// <returns>
		/// 상위 비트가 1이면 눌러져있는 것 입니다.
		/// 하위 비트가 1이면 토글되어 있는 것 입니다.
		/// </returns>
		[DllImport("user32.dll")]
		public static extern int GetKeyState([In] int vVirtKey);
		#endregion

		#region Mouse
		[DllImport("user32.dll")]
		public static extern void mouse_event([In] int dwFlags, [In] int dx, [In] int dy, [In] int dwData, [In] IntPtr dwExtraInfo);

		/// <returns>실패했으면 0을 반환합니다. GetLastError함수로 오류코드를 읽을 수 있습니다.</returns>
		[DllImport("user32.dll")]
		public static extern bool GetCursorPos([Out] out POINT lpPoint);

		/// <returns>실패했으면 0을 반환합니다. GetLastError함수로 오류코드를 읽을 수 있습니다.</returns>
		[DllImport("user32.dll")]
		public static extern bool SetCursorPos([In] int X, [In] int Y);
		#endregion

		#region Keyboard
		[DllImport("user32.dll")]
		public static extern void keybd_event([In]byte bVk, [In]byte bScan, [In]int dwFlags, [In]IntPtr dwExtraInfo);
		#endregion

	}
}