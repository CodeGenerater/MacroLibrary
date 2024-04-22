using System;

namespace MacroLibrary
{
	[Flags]
	internal enum MouseEventFlag : int
	{
		Move = 0x0001,
		LDown = 0x0002,
		LUp = 0x0004,
		RDown = 0x0008,
		RUp = 0x0010,
		MDown = 0x0020,
		MUp = 0x0040,
		XDown = 0x0080,
		XUp = 0x0100,
		Wheel = 0x0800,
		HWheel = 0x1000,
		Absolute = 0x8000,
	}

	/// <summary>
	/// 마우스 버튼의 열거형입니다.
	/// </summary>
	public enum mBtn
	{
		/// <summary>
		/// Left
		/// </summary>
		L = 1,
		/// <summary>
		/// Right
		/// </summary>
		R = 2,
		/// <summary>
		/// Middle
		/// </summary>
		M = 4,
		X1 = 5,
		X2 = 6,
	}

	[Flags]
	public enum KeyState
	{
		/// <summary>
		/// Up
		/// </summary>
		U = 0x0,
		/// <summary>
		/// Down
		/// </summary>
		D = 0x1,
		/// <summary>
		/// Toggled
		/// </summary>
		T = 0x2,
	}

	internal enum MapType
	{
		VK_TO_SC = 0,
		SC_TO_VK = 1,
		VK_TO_CHAR = 2,
		SC_TO_VK_EX = 3,
	}
}