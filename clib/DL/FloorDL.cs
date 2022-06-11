using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clib.BL;
using System.Windows.Forms;
namespace clib.DL
{
    public class FloorDL
    {
        private List<Floor> floors = new List<Floor>();
        public EventHandler onAdd;

        public List<Floor> Floors { get => floors; set => floors = value; }

        public void add_list(int a,int b,int top,int left,PictureBox v)
        {
            Floor k = new Floor(a, b,top,left,v);
            Floors.Add(k);
            onAdd?.Invoke(k.Pb, EventArgs.Empty);
        }
    }
}
