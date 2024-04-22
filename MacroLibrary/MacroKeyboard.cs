using System;
using System.Threading;
using System.Windows.Input;

namespace MacroLibrary
{
	public class MacroKeyboard
	{
		#region Method
		public MacroKeyboard Wait(int Interval)
		{
			Thread.Sleep(Interval);

			return this;
		}

		public MacroKeyboard Down(Key Key)
		{
			byte vk = KeyToVK(Key);

			Win32API.keybd_event(vk, (byte)Win32API.MapVirtualKeyA(vk, (uint)MapType.VK_TO_SC), 0, UIntPtr.Zero);

			return this;
		}

		public MacroKeyboard Up(Key Key)
		{
			byte vk = KeyToVK(Key);

			Win32API.keybd_event(vk, (byte)Win32API.MapVirtualKeyA(vk, (uint)MapType.VK_TO_SC), 2, UIntPtr.Zero);

			return this;
		}

		public KeyState GetKeyState(Key Key)
		{
			var s = Win32API.GetKeyState(KeyToVK(Key));

			KeyState ks = default;

			if (Math.Sign(s) == -1)
				ks |= KeyState.D;
			if ((s & 1) == 1)
				ks |= KeyState.T;

			return ks;
		}
		#endregion

		#region Helper
		byte KeyToVK(Key Key)
		{
			return (byte)KeyInterop.VirtualKeyFromKey(Key);
		}
		#endregion
	}
}