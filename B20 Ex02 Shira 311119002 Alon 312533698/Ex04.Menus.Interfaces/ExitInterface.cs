using System;

namespace Ex04.Menus.Interfaces
{
    internal class ExitInterface : IClicked
    {
        public void Execute()
        {
            Environment.Exit(-1);
        }
    }
}