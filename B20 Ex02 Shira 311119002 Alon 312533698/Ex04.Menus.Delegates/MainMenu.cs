using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex04.Menus.Delegates
{    
    public delegate void UpdateLevelSubMenuDelegate(int i_NewLevel);

    public class MainMenu
    {
        internal event UpdateLevelSubMenuDelegate BecameSubMenu;

        private readonly List<MenuItem> r_MenuItems = new List<MenuItem>();
        private string m_Title;
        private int m_Index = 0;
        private int m_Level;

        public MainMenu(string i_Title)
        {
            //// Default State of any menu is MainMenu (level is 1, option 0 is exit system) 
            
            m_Title = i_Title;
            m_Level = 1;
            AddMenuItem("Exit", exit_Clicked);
        }

        internal string Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }

        private int Level
        {
            get { return m_Level; }
            set { m_Level = value; }
        }

        private int Index
        {
            get { return m_Index; }
            set { m_Index = value; }
        }

        private List<MenuItem> MenuItems
        {
            get { return r_MenuItems; }
        }

        public void AddMenuItem(string i_MenuItemTitle, ClickInvoker i_FunctionToAdd)
        {
            //// Adds new item to the menu - gets item name, and function to do
            //// Add the item to next available index in menu 
            
            MenuItems.Add(new MenuItem(Index++, i_MenuItemTitle, i_FunctionToAdd));
        }

        public void AddMenuItem(MainMenu io_SubMenu)
        {
            //// Gets a new SubMenu to add the menu.
            //// Change SubMenu option 0 from "Exit" to "Back" & add the SubMenu to next available index in menu.
            //// Update both [option 0 and new sub menu] flag "IsMenu" to be recognized as submenu.

            io_SubMenu.MenuItems[0].Title = "Back";
            io_SubMenu.MenuItems[0].IsMenu = true;
            io_SubMenu.MenuItems[0].Clicked -= io_SubMenu.exit_Clicked;
            io_SubMenu.MenuItems[0].Clicked += Show;

            AddMenuItem(io_SubMenu.Title, io_SubMenu.Show);
            MenuItems[MenuItems.Count() - 1].IsMenu = true;
            io_SubMenu.OnBecameSubMenu(Level + 1);
            BecameSubMenu += io_SubMenu.OnBecameSubMenu;
        }

        private void OnBecameSubMenu(int io_NewLevel)
        {
            Level = io_NewLevel;

            if (BecameSubMenu != null)
            {
                BecameSubMenu.Invoke(io_NewLevel + 1);
            }
        }

        private void exit_Clicked()
        {
            Environment.Exit(-1);
        }

        public void Show()
        {            
            bool quit = false;

            printMenu();

            while (!quit)
            {
                getInput(out int choice);
                Console.Clear();
                MenuItems[choice].OnClicked();

                if (MenuItems[choice].IsMenu)
                {
                    quit = true;
                }
                else
                {
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    printMenu();
                }
            }
        }    

        private void printMenu()
        {
            Console.Clear();
            Console.WriteLine("Menu level: {0}{1}====={2}=====", Level, Environment.NewLine, Title);

            foreach (MenuItem currMenuItem in MenuItems)
            {
                currMenuItem.Show();                
            }
        }

        private void getInput(out int io_Input)
        {
            io_Input = -1;

            Console.WriteLine("Please choose one of these options or press 0 to Quit/Back:");

            while (!int.TryParse(Console.ReadLine(), out io_Input) || io_Input < 0 || io_Input >= MenuItems.Count())
            {
                Console.WriteLine("Wrong Input - Try Again!");
            }
        }
    }
}