using System.Windows.Forms;

namespace WinFormsMVC
{
    public interface IView
    {
        string Title { get; set; }

        Form Form { get; }

        void Close();
    }
}
