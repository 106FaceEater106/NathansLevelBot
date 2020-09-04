using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace NathansLevelBot
{
    /// <summary>
    /// Manages the execution of the key-presses
    /// </summary>
    public static class KeyOperations
    {
        #region Keys
        const int keyDown = 0x0001;
        const int keyUp = 0x0002;
        const int A = 0x41;
        const int B = 0x42;
        const int C = 0x43;
        const int D = 0x44;
        const int E = 0x45;
        const int F = 0x46;
        const int G = 0x47;
        const int H = 0x48;
        const int I = 0x49;
        const int J = 0x4A;
        const int K = 0x4B;
        const int L = 0x4C;
        const int M = 0x4D;
        const int N = 0x4E;
        const int O = 0x4F;
        const int P = 0x50;
        const int Q = 0x51;
        const int R = 0x52;
        const int S = 0x53;
        const int T = 0x54;
        const int U = 0x55;
        const int V = 0x56;
        const int W = 0x57;
        const int X = 0x58;
        const int Y = 0x59;
        const int Z = 0x5A;
        const int F1 = 0x70;
        const int F2 = 0x71;
        #endregion

        /// <summary>
        /// Import of key-press-event
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        /// <summary>
        /// Executes a specific sequence of key-presses out of the UsedButtons.json
        /// </summary>
        public static void PressCombo()
        {
            Press(F2);
            Thread.Sleep(10);
            Press(W);
            Thread.Sleep(10);
            Press(E);
            Thread.Sleep(10);
        }

        /// <summary>
        /// Executes for each letter in the word the key-press
        /// </summary>
        public static void PressKey(string word)
        {
            List<byte> keys = new List<byte>();

            foreach (char c in word)
            {
                #region FindKey
                if (c == 'A' || c == 'a')
                    keys.Add(A);
                else if (c == 'B' || c == 'b')
                    keys.Add(B);
                else if (c == 'C' || c == 'c')
                    keys.Add(C);
                else if (c == 'D' || c == 'd')
                    keys.Add(D);
                else if (c == 'E' || c == 'e')
                    keys.Add(E);
                else if (c == 'F' || c == 'f')
                    keys.Add(F);
                else if (c == 'G' || c == 'g')
                    keys.Add(G);
                else if (c == 'H' || c == 'h')
                    keys.Add(H);
                else if (c == 'I' || c == 'i')
                    keys.Add(I);
                else if (c == 'J' || c == 'j')
                    keys.Add(J);
                else if (c == 'K' || c == 'k')
                    keys.Add(K);
                else if (c == 'L' || c == 'l')
                    keys.Add(L);
                else if (c == 'M' || c == 'm')
                    keys.Add(M);
                else if (c == 'N' || c == 'n')
                    keys.Add(N);
                else if (c == 'O' || c == 'o')
                    keys.Add(O);
                else if (c == 'P' || c == 'p')
                    keys.Add(P);
                else if (c == 'Q' || c == 'q')
                    keys.Add(Q);
                else if (c == 'R' || c == 'r')
                    keys.Add(R);
                else if (c == 'S' || c == 's')
                    keys.Add(S);
                else if (c == 'T' || c == 't')
                    keys.Add(T);
                else if (c == 'U' || c == 'u')
                    keys.Add(U);
                else if (c == 'V' || c == 'v')
                    keys.Add(V);
                else if (c == 'W' || c == 'w')
                    keys.Add(W);
                else if (c == 'X' || c == 'x')
                    keys.Add(X);
                else if (c == 'Y' || c == 'y')
                    keys.Add(Y);
                else if (c == 'Z' || c == 'z')
                    keys.Add(Z);
                #endregion
            }

            foreach (byte key in keys)
            {
                Press(key);
                Thread.Sleep(10);
            }
        }

        /// <summary>
        /// Executes the key-press
        /// </summary>
        private static void Press(byte key)
        {
            keybd_event(key, 0, keyDown, 0);
            Thread.Sleep(10);
            keybd_event(key, 0, keyUp, 0);
        }
    }
}