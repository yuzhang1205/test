using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;


namespace winformtest
{
    public partial class Form1 : Form
    {
        Image img;
        DataTable dts=new DataTable();
        public Form1()
        {
            InitializeComponent();
            initdgv();
        }
        public void initdgv()
        {
            string data = "2018/05/26";
            float de = 2.8f;
            float dd = de / 2;
            DataTable dt = new DataTable();
            dt.Columns.Add("ss");
            dt.Columns.Add("naffme");
            DataRow dr = dt.NewRow();
            object[] obj = { dd, data.Replace("/","-") };
            dr.ItemArray = obj;
            dt.Rows.Add(dr);
            dt.Columns["ss"].DefaultValue = "ssd";
            this.dGView.DataSource = dt;

            StartWaiting();
            Draw();
            SetNewSize();
        }

        private void dgv_click(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("name");
            DataRow dr = dt.NewRow();
            object[] obj = { 2, "yy" };
            dr.ItemArray = obj;
            dt.Rows.Add(dr);
            this.dGView.DataSource = dt;
            this.dts = dt;
        }
        
#region 等待界面
        private int count = -1;
    private ArrayList images = new ArrayList();
    public Bitmap[] bitmap = new Bitmap[8];
    private int _value = 1;
    private Color _circleColor = Color.Red;
    private float _circleSize = 0.8f;

    private int width = 200;//设置圆的宽
    private int height = 200;////设置圆的高

    public Bitmap DrawCircle(int j)
    {
        const float angle = 360.0F / 8;
        Bitmap map = new Bitmap(150, 150);
        Graphics g = Graphics.FromImage(map);

        g.TranslateTransform(width / 2.0F, height / 2.0F);
        g.RotateTransform(angle * _value);
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        g.SmoothingMode = SmoothingMode.AntiAlias;
        int[] a = new int[8] { 25, 50, 75, 100, 125, 150, 175, 200 };
        for (int i = 1; i <= 8; i++)
        {
            int alpha = a[(i + j - 1) % 8];
            Color drawColor = Color.FromArgb(alpha, _circleColor);
            using (SolidBrush brush = new SolidBrush(drawColor))
            {
                float sizeRate = 3.5F / _circleSize;
                float size = width / (6 * sizeRate);
                float diff = (width / 10.0F) - size;
                float x = (width / 80.0F) + diff;
                float y = (height / 80.0F) + diff;
                g.FillEllipse(brush, x, y, size, size);
                g.RotateTransform(angle);
            }
        }
        return map;
    }

    public void Draw()
    {
        for (int j = 0; j < 8; j++)
        {
            bitmap[7 - j] = DrawCircle(j);
        }
    }

    protected override void OnResize(EventArgs e)
    {
        SetNewSize();
        base.OnResize(e);
    }

    protected override void OnSizeChanged(EventArgs e)
    {
        SetNewSize();
        base.OnSizeChanged(e);
    }

    private void SetNewSize()
    {
        int size = Math.Max(width, height);
        pictureBox.Size = new Size(size, size);
    }

    public void set()
    {
        for (int i = 0; i < 8; i++)
        {
            Draw();
            Bitmap map = new Bitmap((bitmap[i]), new Size(120, 110));
            images.Add(map);
        }
        pictureBox.Image = (Image)images[0];
        pictureBox.Size = pictureBox.Image.Size;
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
        set();
        count = (count + 1) % 8;
        pictureBox.Image = (Image)images[count];
    }

    private void StartWaiting()
    {
        timer1.Start();
        pictureBox.Visible = true;

        progressBar1.Visible = true;
        progressBar1.Enabled = true;
    }

    private void StopWaiting()
    {
        timer1.Stop();
        pictureBox.Visible = false;

        progressBar1.Visible = false;
        progressBar1.Enabled = false;
    }

    #endregion
    private void dgv_Mouseclick(object sender, DataGridViewCellMouseEventArgs e)
        {
            float xo = 39.909209536859834f;//圆点x
            float yo = 116.3225715637207f;//圆点y
            float x1 = 39.960026f;//圆边上一点坐标x
            float y1 = 116.38882f;//圆边上一点坐标y
            Matrix rotation = new Matrix();
            rotation.RotateAt(60, new System.Drawing.PointF(xo, yo));//60为角度，如12边行为30

            PointF[] pointf = new PointF[] { new PointF(x1, y1) };
            List<PointF> lst = new List<PointF>();
            for (int i = 0; i < 5; i++)
            {
                rotation.TransformPoints(pointf);
                lst.Add(pointf[0]);
            }
            //lst  中包含六边形的六个点
            Console.ReadLine();
        }
        /// <summary>
        /// 在图片上画框
        /// </summary>
        /// <param name="bmp">原始图</param>
        /// <param name="p0">起始点</param>
        /// <param name="p1">终止点</param>
        /// <param name="RectColor">矩形框颜色</param>
        /// <param name="LineWidth">矩形框边界</param>
        /// <returns></returns>
        public static Bitmap DrawRectangleInPicture(Bitmap bmp, Point p0, Point p1, Color RectColor, int LineWidth, DashStyle ds)
        {
            if (bmp == null) return null;


            Graphics g = Graphics.FromImage(bmp);

            Brush brush = new SolidBrush(RectColor);
            Pen pen = new Pen(brush, LineWidth);
            pen.DashStyle = ds;

            g.DrawRectangle(pen, new Rectangle(p0.X, p0.Y, Math.Abs(p0.X - p1.X), Math.Abs(p0.Y - p1.Y)));

            g.Dispose();

            return bmp;
        }


        /// <summary>
        /// 在图片上画椭圆
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="p0"></param>
        /// <param name="RectColor"></param>
        /// <param name="LineWidth"></param>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static Bitmap DrawRoundInPicture(Bitmap bmp, Point p0, Point p1, Color RectColor, int LineWidth, DashStyle ds)
        {
            if (bmp == null) return null;

            Graphics g = Graphics.FromImage(bmp);

            Brush brush = new SolidBrush(RectColor);
            Pen pen = new Pen(brush, LineWidth);
            pen.DashStyle = ds;

            g.DrawEllipse(pen, new Rectangle(p0.X, p0.Y, Math.Abs(p0.X - p1.X), Math.Abs(p0.Y - p1.Y)));

            g.Dispose();

            return bmp;
        }
    }
}
