namespace platformeur
{
    public partial class Form1 : Form
    {
        bool droite, gauche;
        bool jump;
        int saut =30;
        int timesaut = 0;
        int vitesse=10;
        int vitessem = 3;
        int gravitation = 15 ;
        int piece = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void support(object sender, EventArgs e) 
        { 
            
        }

        private void player_Click(object sender, EventArgs e)
        {
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click (object sender, EventArgs e)
        {

        }
        private void gravity()
        {
            foreach (Control m in this.Controls)
            {
                if (m is PictureBox && (string)m.Tag == "monstre")
                {
                    m.Top += gravitation;
                    m.BringToFront();
                    m.Left += vitessem;
                }
            }
        }

        private void gravityr()
        {
            foreach (Control m in this.Controls)
            {
                if (m is PictureBox && (string)m.Tag == "rouge")
                {
                    m.Top += gravitation;
                    m.BringToFront();
                    m.Left += vitessem;
                    if (m.Left < 773 || m.Left > 938)
                    {
                        vitessem = -vitessem;
                    }
                }
            }
        }

        private void plateform()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "supportmoove")
                {

                    x.Left += vitessem;
                    if (x.Left < 554 ||x.Left > 1100)
                    {
                        vitessem = -vitessem;
                    }
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        player.Top -= gravitation;
                        timesaut = 10;
                        if (x.Left < 554 || x.Left > 1100)
                        {
                            player.Left -= vitessem;
                        }
                        else
                        {
                            player.Left += vitessem;
                        }
                    }
                }
            }
        }

        private void mooveevent(object sender, EventArgs e)
        {
            saut = 30;
            player.Top += gravitation;
            gravity();
            gravityr();
            plateform();
           
          
            if (gauche == true && player.Left > 0)
            {
                player.Left -= vitesse;
            }
            if (droite == true && player.Left < 2000)
            {
                player.Left += vitesse;
            }
            if (jump == true && player.Top > 0 && timesaut > 0)
            {
                player.Top -= saut;
                timesaut -= 1;
                saut -= 2;
            }
            foreach (Control x in this.Controls)
            {
                foreach (Control m in this.Controls)
                {
                    if (m is PictureBox && (string)m.Tag == "monstre")
                    {

                        if (player.Bounds.IntersectsWith(m.Bounds))
                        {
                            this.Controls.Remove(player);

                        }
                        if (x is PictureBox && (string)x.Tag == "support")
                        {
                            if (m.Bounds.IntersectsWith(x.Bounds))
                            {
                                m.Top -= gravitation;
                            }
                        }
                    }

                    if (x is PictureBox && (string)x.Tag == "support")
                    {

                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            player.Top -= gravitation;
                            timesaut = 10;
                        }
                    }

                    if (x is PictureBox && (string)x.Tag == "supportmoove")
                    {
                        
                    }
                    if (x is PictureBox && (string)x.Tag == "piece")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds))
                        {
                            this.Controls.Remove(x);
                            piece += 1;
                            this.label1.Text = piece.ToString();
                            break;
                        }

                    }
                    if (m is PictureBox && (string)m.Tag == "rouge")
                    {

                        if (player.Bounds.IntersectsWith(m.Bounds))
                        {
                            this.Controls.Remove(player);

                        }
                        if (x is PictureBox && (string)x.Tag == "support")
                        {
                            if (m.Bounds.IntersectsWith(x.Bounds))
                            {
                                m.Top -= gravitation;
                            }
                        }
                    }

                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Left)
            {
                gauche=true;
            }
            if (e.KeyCode == Keys.Right)
            {
                droite = true;
            }
            if (e.KeyCode == Keys.Space)
            {
                jump = true; 
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }


        private void label1_Click(object sender, EventArgs e)
        {
            
        
        }

        private void pieceAdd(object sender, ControlEventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
         
        }

        private void monstre_Click(object sender, EventArgs e)
        {
           
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                gauche = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                droite = false;
            }
            if (e.KeyCode == Keys.Space)
            {
                jump = false;
                timesaut = 0;
            }
        }
    }
}