using System;

namespace Ex04.Menus.Delegates
{
    public delegate void ClickInvoker();  
    
    internal class MenuItem
    {
        internal event ClickInvoker Clicked;

        private readonly int r_Index;
        private string m_Title;        
        private bool m_IsMenu = false;

        internal MenuItem(int i_Index, string i_Title, ClickInvoker i_Clicked)
        {
            r_Index = i_Index;
            m_Title = i_Title;
            Clicked += i_Clicked;
        }

        internal string Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }

        internal bool IsMenu
        {
            get { return m_IsMenu; }
            set { m_IsMenu = value; }
        }

        public int Index
        {
            get { return r_Index; }
        }

        public void Show()
        {
            Console.WriteLine("{0}. {1}", Index, Title);
        }

        public void OnClicked()
        {
            if (Clicked != null)
            {
                Clicked.Invoke();
            }
        }
    }
}