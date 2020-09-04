using System;
using System.Runtime.InteropServices;

namespace NathansLevelBot
{
    /// <summary>
    /// Manages the execution of the mouse-clicks
    /// </summary>
    public static class MouseOperations
    {
        /// <summary>
        /// Possible flags of mouse actions
        /// </summary>
        [Flags]
        public enum MouseEventFlags
        {
            LeftDown = 0x00000002,
            LeftUp = 0x00000004,
            MiddleDown = 0x00000020,
            MiddleUp = 0x00000040,
            Move = 0x00000001,
            Absolute = 0x00008000,
            RightDown = 0x00000008,
            RightUp = 0x00000010
        }

        /// <summary>
        /// Returns true if cursor position was set by coordinates
        /// </summary>
        [DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetCursorPos(int x, int y);

        /// <summary>
        /// Returns true if cursor position red by mouse-position
        /// </summary>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCursorPos(out MousePoint lpMousePoint);

        /// <summary>
        /// Executes a new mouse event. E.g. LeftDown
        /// </summary>
        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        /// <summary>
        /// Sets the position of the cursor by coordinates
        /// </summary>
        public static void SetCursorPosition(int x, int y)
        {
            SetCursorPos(x, y);
        }

        /// <summary>
        /// Sets the position of the cursor by a mouse-point
        /// </summary>
        public static void SetCursorPosition(MousePoint point)
        {
            SetCursorPos(point.X, point.Y);
        }

        /// <summary>
        /// Returns the current mouse-point
        /// </summary>
        public static MousePoint GetCursorPosition()
        {
            MousePoint currentMousePoint;
            var gotPoint = GetCursorPos(out currentMousePoint);
            if (!gotPoint) { currentMousePoint = new MousePoint(0, 0); }
            return currentMousePoint;
        }

        /// <summary>
        /// Executes the specific mouse event on the current mouse position
        /// </summary>
        public static void MouseEvent(MouseEventFlags value)
        {
            MousePoint position = GetCursorPosition();

            mouse_event
                ((int)value,
                 position.X,
                 position.Y,
                 0,
                 0)
                ;
        }

        /// <summary>
        /// Entitiy of a mouse point
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct MousePoint
        {
            public int X;
            public int Y;

            public MousePoint(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
    }
}