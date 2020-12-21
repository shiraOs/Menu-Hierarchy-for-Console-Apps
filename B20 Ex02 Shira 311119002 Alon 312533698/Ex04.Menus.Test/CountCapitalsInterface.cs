using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal class CountCapitalsInterface : IClicked
    {
        public void Execute()
        {
            MethodsDelegates.CountCapitals();
        }
    }
}