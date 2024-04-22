using System;
using System.Threading;
using System.ComponentModel;

namespace MacroLibrary
{
	[Flags]
	internal enum MouseEventFlag : int
	{
		Move		= 0x0001,
		LDown		= 0x0002,
		LUp			= 0x0004,
		RDown		= 0x0008,
		RUp			= 0x0010,
		MDown		= 0x0020,
		MUp			= 0x0040,
		XDown		= 0x0080,
		XUp			= 0x0100,
		Wheel		= 0x0800,
		HWheel		= 0x1000,
		Absolute	= 0x8000,
	}

	/// <summary>
	/// 마우스 버튼의 열거형입니다.
	/// </summary>
	public enum mBtn
	{
		L	= 1,
		R	= 2,
		M	= 3,
		X1	= 4,
		X2	= 5,
	}

	[Flags]
	public enum BtnState
	{
		U		= 0x0,
		Up		= 0x0,
		D		= 0x1,
		Down	= 0x1,
		T		= 0x2,
		Toggled	= 0x2,
	}

	public class MacroMouse
	{
		#region Property
		public POINT XY
		{
			set
			{
				if (Win32API.SetCursorPos(value.X, value.Y) == false)
					throw new Win32Exception(Win32API.GetLastError(), "마우스 커서 위치 설정에 실패했습니다.");
			}
			get
			{
				if (Win32API.GetCursorPos(out POINT p) == false)
					throw new Win32Exception(Win32API.GetLastError(), "마우스 커서 위치 가져오기에 실패했습니다.");
				return p;
			}
		}

		public int X
		{
			set => Win32API.SetCursorPos(value, XY.Y);
			get => XY.X;
		}

		public int Y
		{
			set => Win32API.SetCursorPos(XY.X, value);
			get => XY.Y;
		}
		#endregion

		#region Method
		public MacroMouse MoveTo(int X, int Y)
		{
			XY = new POINT(X, Y);

			return this;
		}

		public MacroMouse Down(mBtn Btn)
		{
			switch (Btn)
			{
				case mBtn.L:
					Win32API.mouse_event((int)MouseEventFlag.LDown, 0, 0, 0, IntPtr.Zero);
					break;
				case mBtn.R:
					Win32API.mouse_event((int)MouseEventFlag.RDown, 0, 0, 0, IntPtr.Zero);
					break;
				case mBtn.M:
					Win32API.mouse_event((int)MouseEventFlag.MDown, 0, 0, 0, IntPtr.Zero);
					break;
				case mBtn.X1:
					Win32API.mouse_event((int)MouseEventFlag.XDown, 0, 0, 1, IntPtr.Zero);
					break;
				case mBtn.X2:
					Win32API.mouse_event((int)MouseEventFlag.XDown, 0, 0, 2, IntPtr.Zero);
					break;
			}

			return this;
		}

		public MacroMouse Up(mBtn Btn)
		{
			switch (Btn)
			{
				case mBtn.L:
					Win32API.mouse_event((int)MouseEventFlag.LUp, 0, 0, 0, IntPtr.Zero);
					break;
				case mBtn.R:
					Win32API.mouse_event((int)MouseEventFlag.RUp, 0, 0, 0, IntPtr.Zero);
					break;
				case mBtn.M:
					Win32API.mouse_event((int)MouseEventFlag.MUp, 0, 0, 0, IntPtr.Zero);
					break;
				case mBtn.X1:
					Win32API.mouse_event((int)MouseEventFlag.XUp, 0, 0, 1, IntPtr.Zero);
					break;
				case mBtn.X2:
					Win32API.mouse_event((int)MouseEventFlag.XUp, 0, 0, 2, IntPtr.Zero);
					break;
			}

			return this;
		}

		public MacroMouse Wait(int Interval)
		{
			Thread.Sleep(Interval);

			return this;
		}
		#endregion
	}
}