using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal class ShowDateInterface : IClicked
    {
        public void Execute()
        {
            MethodsDelegates.ShowDate();
        }
    }
}