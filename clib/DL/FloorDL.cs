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

        public void add_list(int h,int w,PictureBox a)
        {
            Floor k = new Floor(w, 60,h,w,a);
            Floors.Add(k);
            onAdd?.Invoke(k.Pb, EventArgs.Empty);
        }
    }
}
