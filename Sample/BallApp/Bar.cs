using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace BallApp {
    class Bar {
        private double posX;
        private double posY;
        private Image image;
        private double moveX;
        private double moveY;
        public Bar(double xp, double yp) {
            this.Image = Image.FromFile(@"pic\bar.png");
            PosX = xp;
            PosY = yp;
            MoveX = 10;
            MoveY = 10;
        }

        public double PosX { get => posX; set => posX = value; }
        public double PosY { get => posY; set => posY = value; }
        public Image Image { get => image; set => image = value; }
        public double MoveX { get => moveX; set => moveX = value; }
        public double MoveY { get => moveY; set => moveY = value; }

        public void Move(KeyEventArgs e, Program form, PictureBox pb) {

            if (e.KeyCode == Keys.Right && (PosX + MoveX) <= (form.Width - pb.Width))
            {
                PosX += MoveX;
            }
            else if (e.KeyCode == Keys.Left && (PosX - MoveX) >= 0)
            {
                PosX -= MoveX;
            }
        }

        public void Reflection(Obj obj, PictureBox pbs, PictureBox pb,Program form) {
            if (this.PosX + pb.Width >= obj.PosX && this.PosX <= obj.PosX&&this.PosY+pbs.Height>=obj.PosY&& this.PosY - pbs.Height <= obj.PosY)
            {
                obj.MoveY*=-1;
                Console.WriteLine("a");
            }
        }

    }
}