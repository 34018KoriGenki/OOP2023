using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallApp {
    class Program : Form {
        private Timer moveTimer;        //タイマー用
        Obj ballObj;
        Bar bar;
        PictureBox pbBall;//画像を表示するコントロール
        PictureBox pb;
        private List<Obj> Balls = new List<Obj>();    //ボールインスタンス格納用
        private List<PictureBox> pbs = new List<PictureBox>();      //表示用

        static void Main(string[] args) {
            Application.Run(new Program());
        }
        public Program() {
            //this.Width = 1200;      //幅プロパティ
            //this.Height = 800;      //高さプロパティ
            this.Size = new Size(800, 600);
            this.BackColor = Color.Green;
            this.Text = "BallGame";

            this.MouseClick += Program_MouseClick;
            this.KeyDown += Program_KeyDown;

            bar = new Bar(this.Height * 2 / 3, this.Width / 2);
            pb = new PictureBox
            {
                Size = new Size(100, 5),
                Image = bar.Image,
                Location = new Point(this.Width / 2, this.Height * 2 / 3),//画像の位置
                SizeMode = PictureBoxSizeMode.StretchImage,//画像の表示モード
                Parent = this
            };


            moveTimer = new Timer();
            moveTimer.Interval = 1;     //タイマーのインターバル(ms)
            moveTimer.Tick += MoveTimer_Tick;       //デリゲート登録
        }

        private void Program_KeyDown(object sender, KeyEventArgs e) {
            bar.Move(e, this, pb);
            pb.Location = new Point((int)bar.PosX, this.Height * 2 / 3);
            Console.WriteLine(bar.PosX);
        }

        //イベントハンドラ(マウスクリック時)
        private void Program_MouseClick(object sender, MouseEventArgs e) {
            //ボールインスタンス生成

            if (e.Button != MouseButtons.Middle)
            {
                ballAppear(e);
            }
            else if (Obj.Count - 1 > -1)
            {
                Remove();
            }

            this.Text = "BallGame 総数：" + Obj.Count + " サッカーボール：" + SoccerBall.SoccerCount + " テニスボール：" + TennisBall.TennisCount;
            moveTimer.Start();
        }

        private void Remove() {
            if (SoccerBall.SoccerCount - 1 > -1 && Balls[Obj.Count - 1].GetType() == typeof(SoccerBall))
            {
                SoccerBall.SoccerCount--;
            }
            else if (TennisBall.TennisCount - 1 > -1 && Balls[Obj.Count - 1].GetType() == typeof(TennisBall))
            {
                TennisBall.TennisCount--;
            }
            Balls.RemoveAt(Obj.Count - 1);
            pbs[Obj.Count - 1].Size = new Size();
            pbs.RemoveAt(Obj.Count - 1);
            Obj.Count--;
        }

        private void ballAppear(MouseEventArgs e) {
            pbBall = new PictureBox();//画像を表示するコントロール
            if (e.Button == MouseButtons.Left)
            {
                ballObj = new SoccerBall(e.X - 25, e.Y - 25);
                pbBall.Size = new Size(50, 50);//画像の表示サイズ
            }
            else if (e.Button == MouseButtons.Right)
            {
                ballObj = new TennisBall(e.X - 25, e.Y - 25);
                pbBall.Size = new Size(25, 25);//画像の表示サイズ
            }
            pbBall.Image = ballObj.Image;
            pbBall.Location = new Point((int)ballObj.PosX, (int)ballObj.PosY);//画像の位置
            pbBall.SizeMode = PictureBoxSizeMode.StretchImage;//画像の表示モード
            pbBall.Parent = this;
            Balls.Add(ballObj);
            pbs.Add(pbBall);
        }

        //イベントハンドラ(タイマータイムアウト時)
        private void MoveTimer_Tick(object sender, EventArgs e) {
            for (int i = 0; i < Balls.Count(); i++)
            {
                Balls[i].Move(this, pbs[i]);  //移動(メソッドにメッセージを送っている)
                pbs[i].Location = new Point((int)Balls[i].PosX, (int)Balls[i].PosY);//画像の位置
                bar.Reflection(Balls[i],pbs[i],pb,this);
            }
        }
    }
}